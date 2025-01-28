using Microsoft.EntityFrameworkCore;
using Store.ApplicationUI.Code.Helper;
using Store.ApplicationUI.Code.Models;
using Store.ApplicationUI.Gui.CaisseAndBankGui;
using Store.ApplicationUI.Gui.GeneralSettingsGui.UserRolesGui;
using Store.ApplicationUI.Gui.LoadingGui;
using Store.ApplicationUI.Gui.ProductsGui;
using Store.ApplicationUI.Gui.SalesGui.PosGui;
using Store.Infrastructure.Data;
using Store.Infrastructure.Repositories;

namespace Store.ApplicationUI.Gui.HomeGui
{
    public partial class HomeUserControl : UserControl
    {
        private static HomeUserControl? _homeUserControl;
        private static ApplicationDbContext _context;
        private static ProductsRepository _repository;

        private static MainForm? _main;

        public HomeUserControl()
        {
            InitializeComponent();



        }

        public static HomeUserControl Instance(MainForm main)
        {
            _main = main;
            // If the instance is null, create a new one and assign it to the static field
            if (_homeUserControl == null)
            {
                _homeUserControl = new HomeUserControl();
                _context = new ApplicationDbContext();
                _repository = new ProductsRepository(_context);
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
                var buysCountTask = await _context.Buys.CountAsync();
                var customersCountTask = await _context.Customers.CountAsync();
                var employeesCountTask = await _context.Employees.CountAsync();
                var salesCountTask = await _context.Sales.CountAsync();
                var deservedCountTask = await _context.Deserveds.CountAsync();
                var productsCountTask = await _context.Products.CountAsync();
                var suppliersCountTask = await _context.Suppliers.CountAsync();

                SummaryDataBuys.Text = buysCountTask.ToString();
                SummaryDataCustomers.Text = customersCountTask.ToString();
                SummaryDataEmployees.Text = employeesCountTask.ToString();
                SummaryDataSales.Text = salesCountTask.ToString();
                SummaryDataDeserved.Text = deservedCountTask.ToString();
                SummaryDataProducts.Text = productsCountTask.ToString();
                SummaryDataSuppliers.Text = suppliersCountTask.ToString();
                var result = await _context.Users
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
            catch (Exception ex)
            {
                ToasterHelper.ShowErrorHappened(ex.Message);
                throw;
            }
        }



        private void timer1_Tick(object sender, EventArgs e)
        {
            lblhora.Text = DateTime.Now.ToString("hh:mm:ss ");
            lblFecha.Text = DateTime.Now.ToLongDateString();
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
                if (LocalUser.User.UserCaisseAndBank.CaissesAndBanks)
                {
                    _main.CloseSubPanels();
                    PosForm posForm = new PosForm(_main);
                    posForm.ShowDialog();
                    _main.Show();
                }
        }
    }
}
