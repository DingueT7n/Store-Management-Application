using System.Globalization;
using Microsoft.EntityFrameworkCore;
using Store.ApplicationUI.Code.GUIHelper;
using Store.ApplicationUI.Code.Helper;
using Store.ApplicationUI.Code.Models;
using Store.ApplicationUI.Code.System;
using Store.ApplicationUI.Gui.BuysGui;
using Store.ApplicationUI.Gui.CaisseAndBankGui;
using Store.ApplicationUI.Gui.CaisseAndBankGui.FondCaisseGui;
using Store.ApplicationUI.Gui.CustomersGui.CustomerAccountGui;
using Store.ApplicationUI.Gui.GeneralSettingsGui.UserRolesGui;
using Store.ApplicationUI.Gui.LoadingGui;
using Store.ApplicationUI.Gui.ProductsGui;
using Store.ApplicationUI.Gui.ReturnsGui;
using Store.ApplicationUI.Gui.SalesGui;
using Store.ApplicationUI.Gui.SalesGui.PosGui;
using Store.ApplicationUI.Gui.SupplierGui.SupplierAccountGui;
using Store.Infrastructure.Data;

namespace Store.ApplicationUI.Gui.HomeGui
{
    public partial class HomeUserControl : UserControl, IKeyAwareControl
    {

        private readonly ApplicationDbContext _context;
        private readonly MainForm _main;
        private readonly ControlManager _controlManager;

        public HomeUserControl(ApplicationDbContext context, MainForm main, ControlManager controlManager)
        {
            _context = context;
            _main = main;
            InitializeComponent();
            _controlManager = controlManager;

            animationTimer.Interval = 10; // Animation speed
            animationTimer.Tick += AnimationTimer_Tick;

            textAnimationTimer.Interval = 100; // Text fade effect speed
            textAnimationTimer.Tick += TextAnimationTimer_Tick;

        }


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



        private void TextAnimationTimer_Tick(object sender, EventArgs e)
        {

        }

        public async Task LoadData()
        {


            //ShowLoading
            LoadingForm.Instance(_main).Show();
            if (await _context.Database.CanConnectAsync())
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
        //private int panelWidth = 200; // Default width of panel
        //private int expandedWidth = 400; // Maximum width when expanded
        private bool isExpanding = false; // Tracks panel animation direction
        private System.Windows.Forms.Timer animationTimer = new System.Windows.Forms.Timer(); // Timer for animations
        private System.Windows.Forms.Timer textAnimationTimer = new System.Windows.Forms.Timer(); // Timer for text effects
        //private Color originalColor = Color.Black; // Default label color
        //private bool textFading = false; // Tracks text fading animation


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
                    UserRolesForm userRolesForm = _controlManager.GetF<UserRolesForm>();

                    userRolesForm.ShowDialog();
                }

        }

        private void tiltAddProduct_ItemClick(object sender, DevExpress.XtraEditors.TileItemEventArgs e)
        {
            if (LocalUser.User is not null)
                if (LocalUser.User.UserProductAndStore.AddProduct)
                {
                    _main.CloseSubPanels();
                    AddProductForm addProductForm = _controlManager.GetF<AddProductForm>();

                    addProductForm.ShowDialog();
                }
        }

        private void tiltSuppAccount_ItemClick(object sender, DevExpress.XtraEditors.TileItemEventArgs e)
        {
            if (LocalUser.User is not null)
                if (LocalUser.User.UserCustomer.CustomerAccount)
                {
                    _main.CloseSubPanels();
                    _main.SetBytilt(_controlManager.Get<CustomerAccountUserControl>());
                }
        }

        private void tiltCustomersAccount_ItemClick(object sender, DevExpress.XtraEditors.TileItemEventArgs e)
        {
            if (LocalUser.User is not null)
                if (LocalUser.User.UserSupplier.SuppliersAccount)
                {
                    _main.CloseSubPanels();
                    _main.SetBytilt(_controlManager.Get<SupplierAccountUserControl>());
                }
        }

        private void tiltBuys_ItemClick(object sender, DevExpress.XtraEditors.TileItemEventArgs e)
        {
            if (LocalUser.User is not null)
                if (LocalUser.User.UserBuy.NewBuy)
                {
                    _main.CloseSubPanels();
                    //_main.SetBytilt(Gui.BuysGui.BuysUserControl.Instance(_main));
                    _main.SetBytilt(_controlManager.Get<BuysUserControl>());

                }
        }

        private void tiltSales_ItemClick(object sender, DevExpress.XtraEditors.TileItemEventArgs e)
        {
            if (LocalUser.User is not null)
                if (LocalUser.User.UserSale.NewSale)
                {
                    _main.CloseSubPanels();
                    _main.SetBytilt(_controlManager.Get<SalesUserControl>());
                }
        }

        private void tiltCaisse_ItemClick(object sender, DevExpress.XtraEditors.TileItemEventArgs e)
        {
            if (LocalUser.User is not null)
                if (LocalUser.User.UserCaisseAndBank.CaissesAndBanks)
                {
                    CaisseDetailsForm caisseDetailsForm = _controlManager.GetF<CaisseDetailsForm>();

                    caisseDetailsForm.ShowDialog();
                    _main.CloseSubPanels();
                }
        }

        private void tiltStatistiocs_ItemClick(object sender, DevExpress.XtraEditors.TileItemEventArgs e)
        {
            if (LocalUser.User is not null)
                if (LocalUser.User.UserSetting.Statistics)
                {
                    _main.CloseSubPanels();

                    _main.SetBytilt(_controlManager.Get<StatisticsUserControl>());
                }
        }

        private void tiltReturns_ItemClick(object sender, DevExpress.XtraEditors.TileItemEventArgs e)
        {
            if (LocalUser.User is not null)
                if (LocalUser.User.UserRefund.RefundProduct)
                {
                    _main.CloseSubPanels();


                    _main.SetBytilt(_controlManager.Get<ReturnUserControl>());

                }
        }

        private async void tiltPos_ItemClick(object sender, DevExpress.XtraEditors.TileItemEventArgs e)
        {
            if (LocalUser.User is not null)
                if (LocalUser.User.UserSale.NewSale)
                {
                    if (Code.Helper.VerificationSettingsHelper.IsAllSettingsAreApplied(_context))
                    {

                        var caisse = await _context.Caisses.FirstOrDefaultAsync(x => x.Id == Properties.Settings.Default.DefaultCaisseId);
                        if (caisse != null)
                        {
                            if (caisse.Status == Core.Entities.Caisses.CaisseStatus.Closed)
                            {
                                OpenOrCloseCaisseForm Form = _controlManager.GetF<OpenOrCloseCaisseForm>();
                                Form.ShowDialog();
                            }
                            else if (caisse.Status == Core.Entities.Caisses.CaisseStatus.Open)
                            {
                                this.Hide();
                                PosForm posForm = _controlManager.GetF<PosForm>();

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

        private async void HomeUserControl_Load(object sender, EventArgs e)
        {
            await LoadData();

        }
    }
}
