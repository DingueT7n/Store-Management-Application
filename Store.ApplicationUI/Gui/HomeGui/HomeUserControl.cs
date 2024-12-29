using DevExpress.Data.Linq.Helpers;
using Microsoft.EntityFrameworkCore;
using Store.ApplicationUI.Code.Helper;
using Store.ApplicationUI.Gui.CaisseAndBankGui;
using Store.ApplicationUI.Gui.GeneralSettingsGui.UserRolesGui;
using Store.ApplicationUI.Gui.LoadingGui;
using Store.ApplicationUI.Gui.ProductsGui;
using Store.ApplicationUI.Gui.SalesGui.PosGui;
using Store.Core.Entities.Suppliers;
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
            _homeUserControl.LoadData();
            // Return the singleton instance
            return _homeUserControl;
        }

        public async void LoadData()
        {


            //ShowLoading
            LoadingForm.Instance(_main).Show();
            if (await Task.Run(() => _context.Database.CanConnect()))
            {
                //Start Load Data

                GetStatics();
                SetProductsToDgv();
                SetColumns();

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
            lblEmptyData.Visible = dgvHelper.IsEmpty(DgvProducts);
            lblEmptyData1.Visible = dgvHelper.IsEmpty(dgvDataOutdated);
            lblEmptyData2.Visible = dgvHelper.IsEmpty(dataDebtSuppliers);
            lblEmptyData3.Visible = dgvHelper.IsEmpty(dataCustomerDebts);
        }

        private void GetStatics()
        {
            SummaryDataBuys.Text = _context.Buys.Count().ToString();
            SummaryDataCustomers.Text = _context.Customers.Count().ToString();
            SummaryDataEmployees.Text = _context.Employees.Count().ToString();
            SummaryDataSales.Text = _context.Sales.Count().ToString();
            SummaryDataDeserved.Text = _context.Deserveds.Count().ToString();
            SummaryDataProducts.Text = _context.Products.Count().ToString();
            SummaryDataSuppliers.Text = _context.Suppliers.Count().ToString();

            var user = _context.Users
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
            .FirstOrDefault(u => u.UserName == "hg" && u.Password == "g");
            Code.Models.LocalUser.User = user;



        }
        private void SetColumns()
        {
            DgvProducts.Columns[0].HeaderCell.Value = "باركود";
            DgvProducts.Columns[1].HeaderCell.Value = "اسم المنتج";
            DgvProducts.Columns[2].HeaderCell.Value = "الكمية";
            DgvProducts.Columns[3].HeaderCell.Value = "تاريخ انتهاء الصلاحية";
            DgvProducts.Columns[4].HeaderCell.Value = "اسم الصنف";

            //DgvProducts.Columns[6].HeaderCell.Value = "قيمة الضريبة";
            //DgvProducts.Columns[7].HeaderCell.Value = "سعر البيع باحتساب الضريبة";
            //DgvProducts.Columns[8].HeaderCell.Value = "خاضع للضريبة؟";
            //DgvProducts.Columns[9].HeaderCell.Value = "تاريخ انتهاء الصلاحية";
            //DgvProducts.Columns[10].HeaderCell.Value = "كمية التنبيه";
            //DgvProducts.Columns[11].HeaderCell.Value = "اقصى تخفيض";
            //DgvProducts.Columns[12].HeaderCell.Value = "صورة المنتج";

            //DgvProducts.Columns[13].HeaderCell.Value = "معرف الصنف";
            //DgvProducts.Columns[14].HeaderCell.Value = "اسم الصنف";
            //DgvProducts.Columns[15].HeaderCell.Value = "معرف المنتج";

            dgvDataOutdated.Columns[0].HeaderCell.Value = "باركود";
            dgvDataOutdated.Columns[1].HeaderCell.Value = "اسم المنتج";
            dgvDataOutdated.Columns[2].HeaderCell.Value = "المخزن";
            dgvDataOutdated.Columns[3].HeaderCell.Value = "الكمية";
            dgvDataOutdated.Columns[4].HeaderCell.Value = "تاريخ انتهاء الصلاحية";


            dataDebtSuppliers.Columns[0].HeaderCell.Value = "رقم الفاتورة";
            dataDebtSuppliers.Columns[1].HeaderCell.Value = "اسم المورد";
            dataDebtSuppliers.Columns[2].HeaderCell.Value = "الثمن";
            dataDebtSuppliers.Columns[3].HeaderCell.Value = "تاريخ الفاتورة";
            dataDebtSuppliers.Columns[4].HeaderCell.Value = "تاريخ الاستحقاق";

            dataCustomerDebts.Columns[0].HeaderCell.Value = "رقم الفاتورة";
            dataCustomerDebts.Columns[1].HeaderCell.Value = "اسم العميل";
            dataCustomerDebts.Columns[2].HeaderCell.Value = "الثمن";
            dataCustomerDebts.Columns[3].HeaderCell.Value = "تاريخ الفاتورة";
            dataCustomerDebts.Columns[4].HeaderCell.Value = "تاريخ الاستحقاق";

        }
        public async void SetProductsToDgv()
        {
            var data = _repository.GetAllProductMinQty();
            DgvProducts.DataSource = data;
            var dataOutDated = _repository.GetAllProductOutdated();
            dgvDataOutdated.DataSource = dataOutDated;

            var dataReminderDateIsUpSupplier = GetAllDebtSuppliers();
            dataDebtSuppliers.DataSource = dataReminderDateIsUpSupplier;

            var dataReminderDateIsUpCustomer = GetAllDebtCustomer();
            dataCustomerDebts.DataSource = dataReminderDateIsUpCustomer;
        }
        public List<SupplierDebts> GetAllDebtSuppliers()
        {
            try
            {
                var products = _context.SuppliersMoneys
                                .Where(x => x.Reminder_Date <= DateTime.Now)
                    .Select(bd => new SupplierDebts
                    {
                        Order_ID = bd.Order_ID,
                        SupplierName = bd.SupplierName,
                        Price = bd.Price,
                        Order_Date = bd.Order_Date,
                        Reminder_Date = bd.Reminder_Date
                    })
                    .ToList();
                return products;
            }
            catch (Exception ex)
            {

                throw new Exception("Error retrieving the buyFactures", ex);
            }
        }
        public List<SupplierDebts> GetAllDebtCustomer()
        {
            try
            {
                var products = _context.CustomersMoneys
                                .Where(x => x.Reminder_Date <= DateTime.Now)
                    .Select(bd => new SupplierDebts
                    {
                        Order_ID = bd.Order_ID,
                        SupplierName = bd.Cust_Name,
                        Price = bd.Price,
                        Order_Date = bd.Order_Date,
                        Reminder_Date = bd.Reminder_Date
                    })
                    .ToList();
                return products;
            }
            catch (Exception ex)
            {

                throw new Exception("Error retrieving the buyFactures", ex);
            }
        }
        private void timer1_Tick(object sender, EventArgs e)
        {
            lblhora.Text = DateTime.Now.ToString("hh:mm:ss ");
            lblFecha.Text = DateTime.Now.ToLongDateString();
        }

        private void tiltUsersManagment_ItemClick(object sender, DevExpress.XtraEditors.TileItemEventArgs e)
        {
            _main.CloseSubPanels();
            UserRolesForm userRolesForm = UserRolesForm.Instance(_main);

            userRolesForm.Show();

        }

        private void tiltAddProduct_ItemClick(object sender, DevExpress.XtraEditors.TileItemEventArgs e)
        {
            _main.CloseSubPanels();
            AddProductForm addProductForm = AddProductForm.Instance(_main);

            addProductForm.Show();
        }

        private void tiltSuppAccount_ItemClick(object sender, DevExpress.XtraEditors.TileItemEventArgs e)
        {
            _main.CloseSubPanels();
            _main.SetBytilt(Gui.CustomersGui.CustomerAccountGui.CustomerAccountUserControl.Instance(_main));

        }

        private void tiltCustomersAccount_ItemClick(object sender, DevExpress.XtraEditors.TileItemEventArgs e)
        {
            _main.CloseSubPanels();
            _main.SetBytilt(Gui.SupplierGui.SupplierAccountGui.SupplierAccountUserControl.Instance(_main));

        }

        private void tiltBuys_ItemClick(object sender, DevExpress.XtraEditors.TileItemEventArgs e)
        {
            _main.CloseSubPanels();
            _main.SetBytilt(Gui.BuysGui.BuysUserControl.Instance(_main));
        }

        private void tiltSales_ItemClick(object sender, DevExpress.XtraEditors.TileItemEventArgs e)
        {
            _main.CloseSubPanels();
            _main.SetBytilt(Gui.SalesGui.SalesUserControl.Instance(_main));
        }

        private void tiltCaisse_ItemClick(object sender, DevExpress.XtraEditors.TileItemEventArgs e)
        {
            CaisseDetailsForm caisseDetailsForm = CaisseDetailsForm.Instance(_main);
            caisseDetailsForm.Show();
            _main.CloseSubPanels();
        }

        private void tiltStatistiocs_ItemClick(object sender, DevExpress.XtraEditors.TileItemEventArgs e)
        {
            _main.CloseSubPanels();

            _main.SetBytilt(Gui.HomeGui.StatisticsUserControl.Instance(_main));

        }

        private void tiltReturns_ItemClick(object sender, DevExpress.XtraEditors.TileItemEventArgs e)
        {
            _main.CloseSubPanels();

            _main.SetBytilt(Gui.ReturnsGui.ReturnUserControl.Instance(_main));
        }

        private void tiltPos_ItemClick(object sender, DevExpress.XtraEditors.TileItemEventArgs e)
        {
            _main.CloseSubPanels();
            PosForm posForm = new PosForm();
            posForm.ShowDialog();
            _main.Show();
        }
    }
}
