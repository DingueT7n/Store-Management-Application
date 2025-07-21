using System.Globalization;
using Microsoft.EntityFrameworkCore;
using Store.ApplicationUI.Code.GUIHelper;
using Store.ApplicationUI.Code.Helper;
using Store.ApplicationUI.Code.Models;
using Store.ApplicationUI.Gui.CaisseAndBankGui;
using Store.ApplicationUI.Gui.CaisseAndBankGui.FondCaisseGui;
using Store.ApplicationUI.Gui.GeneralSettingsGui.UserRolesGui;
using Store.ApplicationUI.Gui.LoadingGui;
using Store.ApplicationUI.Gui.ProductsGui;
using Store.ApplicationUI.Gui.SalesGui.PosGui;
using Store.Infrastructure.Data;

namespace Store.ApplicationUI.Gui.HomeGui
{
    public partial class HomeUserControl : UserControl, IKeyAwareControl
    {
        private static HomeUserControl? _homeUserControl;
        private static ApplicationDbContext? _context;
        private static MainForm? _main;

        public HomeUserControl()
        {
            InitializeComponent();
            animationTimer.Interval = 10; // Animation speed
            animationTimer.Tick += AnimationTimer_Tick;

            textAnimationTimer.Interval = 100; // Text fade effect speed
            textAnimationTimer.Tick += TextAnimationTimer_Tick;

            // Set default size and handlers
            //panelTimes.Width = panelWidth;
            //panelTimes.MouseHover += PanelTimes_MouseHover;
            //panelTimes.MouseLeave += PanelTimes_MouseLeave;
            //panelTimes.Click += PanelTimes_Click;


        }
        private void PanelTimes_MouseHover(object sender, EventArgs e)
        {
            isExpanding = true; // Expand panel
            animationTimer.Start();
        }

        private void PanelTimes_MouseLeave(object sender, EventArgs e)
        {
            isExpanding = false; // Shrink panel
            animationTimer.Start();
        }

        //private void PanelTimes_Click(object sender, EventArgs e)
        //{
        //    panelTimes.BackColor = Color.LightBlue; // Highlight on click
        //    Task.Delay(200).ContinueWith(_ =>
        //    {
        //        this.Invoke(new Action(() => panelTimes.BackColor = SystemColors.Control)); // Reset after delay
        //    });
        //}

        private void AnimationTimer_Tick(object sender, EventArgs e)
        {
            if (isExpanding)
            {
                //if (panelTimes.Width < expandedWidth)
                //{
                //    panelTimes.Width += 10; // Expand width
                //}
                //else
                //{
                //    animationTimer.Stop();
                //}
            }
            else
            {
                //if (panelTimes.Width > panelWidth)
                //{
                //    panelTimes.Width -= 10; // Shrink width
                //}
                //else
                //{
                //    animationTimer.Stop();
                //}
            }
        }

        private void LblTimer_Hover(object sender, EventArgs e)
        {
            textFading = true;
            textAnimationTimer.Start();
        }

        private void LblTimer_Leave(object sender, EventArgs e)
        {
            textFading = false;
            textAnimationTimer.Start();
        }

        private void TextAnimationTimer_Tick(object sender, EventArgs e)
        {

        }
        public static HomeUserControl Instance(MainForm main)
        {
            _main = main;
            // If the instance is null, create a new one and assign it to the static field
            if (_homeUserControl == null)
            {
                _homeUserControl = new HomeUserControl();
                _context = new ApplicationDbContext();

            }
            _ = _homeUserControl.LoadData();
            // Return the singleton instance
            return _homeUserControl;
        }

        public async Task LoadData()
        {


            //ShowLoading
            LoadingForm.Instance(_main).Show();
            if (await Task.Run(() => _context.Database.CanConnect()))
            {
                //Start Load Data


                await GetStatics();


                //_data.Clear();
            }
            else
            {

                LoadingForm.Instance(_main).Hide();
                //No Connection
                MsgHelper.ShowServerError();
            }
            //Hideloading
            LoadingForm.Instance(_main).Hide();
            // Show EmptyDAta

        }

        private async Task GetStatics()
        {
            try
            {


                // Run the database queries asynchronously
                var buysCountTask = await _context.Buys.AsNoTracking().CountAsync();
                var customersCountTask = await _context.Customers.AsNoTracking().CountAsync();
                var employeesCountTask = await _context.Employees.AsNoTracking().CountAsync();
                var salesCountTask = await _context.Sales.AsNoTracking().CountAsync();
                var deservedCountTask = await _context.Deserveds.AsNoTracking().CountAsync();
                var productsCountTask = await _context.Products.AsNoTracking().CountAsync();
                var suppliersCountTask = await _context.Suppliers.AsNoTracking().CountAsync();
                var Alerts = await _context.AlertsTable.Where(x => x.IsResolved == false).AsNoTracking().CountAsync();
                var productMinQty = await _context.Products.Where(x => x.MinQty >= x.Quentity).AsNoTracking().CountAsync();

                SummaryDataBuys.Text = buysCountTask.ToString();
                SummaryDataCustomers.Text = customersCountTask.ToString();
                SummaryDataEmployees.Text = employeesCountTask.ToString();
                SummaryDataSales.Text = salesCountTask.ToString();
                SummaryDataDeserved.Text = deservedCountTask.ToString();
                SummaryDataProducts.Text = productsCountTask.ToString();
                SummaryDataSuppliers.Text = suppliersCountTask.ToString();
                if (Alerts > 0 || productMinQty > 0)
                {
                    _main.btnStatusAlert.Caption = $"التنبيهات {Alerts}";
                    _main.btnStatusAlert.Visibility = DevExpress.XtraBars.BarItemVisibility.Always;
                }
                else
                    _main.btnStatusAlert.Visibility = DevExpress.XtraBars.BarItemVisibility.Never;

                if (LocalUser.User is null)
                {
                    var result = await _context.Users.AsNoTracking()
                                .Include(u => u.UserBuy)
                                .Include(u => u.UserCaisseAndBank)
                                .Include(u => u.UserCustomer)
                                .Include(u => u.UserDeservedAndTax)
                                .Include(u => u.UserEmployee)
                                .Include(u => u.UserProductAndStore)
                                .Include(u => u.UserRefund)
                                .Include(u => u.UserSale)
                                .Include(u => u.UserSetting)
                                .Include(u => u.UserSupplier)
                                .FirstOrDefaultAsync(u => u.UserName == "Admin" && u.Password == "123");
                    LocalUser.User = result;
                }
                _main.lblUserName.Caption = LocalUser.User.UserName;
            }
            catch (Exception ex)
            {
                ToasterHelper.ShowErrorHappened(ex.Message);
                throw;
            }
        }

        // Animation-related variables
        private int panelWidth = 200; // Default width of panel
        private int expandedWidth = 400; // Maximum width when expanded
        private bool isExpanding = false; // Tracks panel animation direction
        private System.Windows.Forms.Timer animationTimer = new System.Windows.Forms.Timer(); // Timer for animations
        private System.Windows.Forms.Timer textAnimationTimer = new System.Windows.Forms.Timer(); // Timer for text effects
        private Color originalColor = Color.Black; // Default label color
        private bool textFading = false; // Tracks text fading animation


        private void timer1_Tick(object sender, EventArgs e)
        {
            CultureInfo arCulture = new CultureInfo("ar-DZ"); // Arabic (Algeria)
            arCulture.DateTimeFormat.AMDesignator = "ص"; // Arabic for AM
            arCulture.DateTimeFormat.PMDesignator = "م"; // Arabic for PM

            //lblhora.Text = DateTime.Now.ToString("hh:mm:ss tt", arCulture);
            _main.lblTIme.Caption = DateTime.Now.ToString("hh:mm:ss tt", arCulture);

            string gregorianDate = Code.Helper.FactureHelper.GetGregorianDate();
            string hijriDate = Code.Helper.FactureHelper.GetHijriDate(false);
            // Combine both dates into the label
            _main.lblDate.Caption = $"{gregorianDate} الموافق لـ {hijriDate}";

            //lblFecha.Text = $"التاريخ الميلادي: {gregorianDate} \nالتاريخ الهجري: {hijriDate}";
        }

        private void tiltUsersManagment_ItemClick(object sender, DevExpress.XtraEditors.TileItemEventArgs e)
        {
            if (LocalUser.User is not null)
                if (LocalUser.User.UserSetting.UserPermession)
                {
                    _main.CloseSubPanels();
                    UserRolesForm userRolesForm = UserRolesForm.Instance(_main);

                    userRolesForm.Show();
                }

        }

        private void tiltAddProduct_ItemClick(object sender, DevExpress.XtraEditors.TileItemEventArgs e)
        {
            if (LocalUser.User is not null)
                if (LocalUser.User.UserProductAndStore.AddProduct)
                {
                    _main.CloseSubPanels();
                    AddProductForm addProductForm = AddProductForm.Instance(_main);

                    addProductForm.Show();
                }
        }

        private void tiltSuppAccount_ItemClick(object sender, DevExpress.XtraEditors.TileItemEventArgs e)
        {
            if (LocalUser.User is not null)
                if (LocalUser.User.UserCustomer.CustomerAccount)
                {
                    _main.CloseSubPanels();
                    _main.SetBytilt(Gui.CustomersGui.CustomerAccountGui.CustomerAccountUserControl.Instance(_main));
                }
        }

        private void tiltCustomersAccount_ItemClick(object sender, DevExpress.XtraEditors.TileItemEventArgs e)
        {
            if (LocalUser.User is not null)
                if (LocalUser.User.UserSupplier.SuppliersAccount)
                {
                    _main.CloseSubPanels();
                    _main.SetBytilt(Gui.SupplierGui.SupplierAccountGui.SupplierAccountUserControl.Instance(_main));
                }
        }

        private void tiltBuys_ItemClick(object sender, DevExpress.XtraEditors.TileItemEventArgs e)
        {
            if (LocalUser.User is not null)
                if (LocalUser.User.UserBuy.NewBuy)
                {
                    _main.CloseSubPanels();
                    _main.SetBytilt(Gui.BuysGui.BuysUserControl.Instance(_main));
                }
        }

        private void tiltSales_ItemClick(object sender, DevExpress.XtraEditors.TileItemEventArgs e)
        {
            if (LocalUser.User is not null)
                if (LocalUser.User.UserSale.NewSale)
                {
                    _main.CloseSubPanels();
                    _main.SetBytilt(Gui.SalesGui.SalesUserControl.Instance(_main));
                }
        }

        private void tiltCaisse_ItemClick(object sender, DevExpress.XtraEditors.TileItemEventArgs e)
        {
            if (LocalUser.User is not null)
                if (LocalUser.User.UserCaisseAndBank.CaissesAndBanks)
                {
                    CaisseDetailsForm caisseDetailsForm = CaisseDetailsForm.Instance(_main);
                    caisseDetailsForm.Show();
                    _main.CloseSubPanels();
                }
        }

        private void tiltStatistiocs_ItemClick(object sender, DevExpress.XtraEditors.TileItemEventArgs e)
        {
            if (LocalUser.User is not null)
                if (LocalUser.User.UserSetting.Statistics)
                {
                    _main.CloseSubPanels();

                    _main.SetBytilt(Gui.HomeGui.StatisticsUserControl.Instance(_main));
                }
        }

        private void tiltReturns_ItemClick(object sender, DevExpress.XtraEditors.TileItemEventArgs e)
        {
            if (LocalUser.User is not null)
                if (LocalUser.User.UserRefund.RefundProduct)
                {
                    _main.CloseSubPanels();

                    _main.SetBytilt(Gui.ReturnsGui.ReturnUserControl.Instance(_main));
                }
        }

        private void tiltPos_ItemClick(object sender, DevExpress.XtraEditors.TileItemEventArgs e)
        {
            if (LocalUser.User is not null)
                if (LocalUser.User.UserSale.NewSale)
                {
                    if (Code.Helper.VerificationSettingsHelper.IsAllSettingsAreApplied(_context))
                    {
                        _context = new ApplicationDbContext();
                        var caisse = _context.Caisses.FirstOrDefault(x => x.Id == Properties.Settings.Default.DefaultCaisseId);
                        if (caisse != null)
                        {
                            if (caisse.Status == Core.Entities.Caisses.CaisseStatus.Closed)
                            {
                                OpenOrCloseCaisseForm Form = new OpenOrCloseCaisseForm(_main);
                                Form.ShowDialog();
                            }
                            else if (caisse.Status == Core.Entities.Caisses.CaisseStatus.Open)
                            {
                                this.Hide();
                                PosForm posForm = new PosForm(_main);
                                posForm.ShowDialog();
                                this.Show();

                            }
                        }


                    }
                }
            ToasterHelper.PlayNotificationSound();


        }
        private void HomeUserControl_KeyDown(object sender, KeyEventArgs e)
        {

        }

        public void HandleKeyDown(Keys key)
        {
            if (key == Keys.F12)
            {
                tiltPos_ItemClick(null, null);
            }
            else if (key == Keys.F10)
            {
                tiltStatistiocs_ItemClick(null, null);
            }
            else if (key == Keys.F5)
            {
                tiltAddProduct_ItemClick(null, null);

            }
            else if (key == Keys.F4)
            {
                tiltUsersManagment_ItemClick(null, null);

            }
            else if (key == Keys.F1)
            {
                tiltBuys_ItemClick(null, null);

            }
            else if (key == Keys.F2)
            {
                tiltSales_ItemClick(null, null);

            }
        }
    }
}
