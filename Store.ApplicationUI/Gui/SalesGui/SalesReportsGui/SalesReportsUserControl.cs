using Store.ApplicationUI.Code.Helper;
using Store.ApplicationUI.Gui.LoadingGui;
using Store.Infrastructure.Repositories;

namespace Store.ApplicationUI.Gui.SalesGui.SalesReportsGui
{
    public partial class SalesReportsUserControl : UserControl
    {
        private static MainForm? _main;
        public static SalesRepository? salesRepository;
        private static SalesReportsUserControl? _salesReportsUserControl;
        public SalesReportsUserControl()
        {
            InitializeComponent();
        }
        public static bool CheckInstance()
        {
            return (_salesReportsUserControl == null);
        }
        public static SalesReportsUserControl Instance(MainForm main)
        {
            _main = main;
            // If the instance is null, create a new one and assign it to the static field
            if (CheckInstance())
            {
                salesRepository = new SalesRepository(MainForm.Context);

                _salesReportsUserControl = new SalesReportsUserControl();

            }

            // Return the singleton instance
            _salesReportsUserControl.LoadData();
            return _salesReportsUserControl;
        }
        public async void SetProductsToDgv()
        {
            ////DgvSales.DataSource = await Task.Run(() => productsRepository.GetAll(p => p.Category));
            //var CustomerMoneyList = MainForm.Context.CustomersReports.
            //    Include(x => x.Customer).Include(x => x.Sale)
            //    .ToList();
            DgvSales.DataSource = salesRepository.GetAllSalesWithDetails();
            //var uniqueCustomerCount = CustomerMoneyList
            //    .Select(x => x.Customer.Id) // Replace CustomerId with the actual unique identifier property
            //    .Distinct()
            //    .Count();
            //DgvSales.DataSource = CustomerMoneyList;
            //if (DgvSales.Rows.Count > 0)
            //{
            //    if (DgvSales.SelectedRows.Count > 0)
            //    {
            //        //lblPayFacture.Text = $" فاتورة رقم {DgvSales.Columns[7].HeaderCell.Value} الدين : {DgvSales.Columns[1].HeaderCell.Value} دج";
            //        //lblPayAllDebts.Text = $"دج {CustomerMoneyList.Sum(x => x.Price)}";
            //        lblTotalDebt.Text = $"مجموع مدفوعات الموردين في الجدول:{CustomerMoneyList.Sum(x => x.Price)}";
            //        lblTotalCustomers.Text = $"مجموع الموردين:{uniqueCustomerCount}";

            //    }
            //}
        }

        public static void RefreshDgv()
        {
            //DgvSales.DataSource = await Task.Run(() => productsRepository.GetAllProducts());
            _salesReportsUserControl.LoadData();
        }
        // methodes 
        public async void LoadData()
        {


            //ShowLoading
            LoadingForm.Instance(_main).Show();
            if (await Task.Run(() => salesRepository.IsConnected()))
            {
                //Start Load Data

                // if its an admin or Normal user 

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
            lblEmptyData.Visible = dgvHelper.IsEmpty(DgvSales);
        }

        private void SetColumns()
        {
            //DgvSales.Columns[0].HeaderCell.Value = "المعرف";



            DgvSales.Columns[0].HeaderCell.Value = "معرف الفاتورة";
            DgvSales.Columns[1].HeaderCell.Value = "اسم المورد";
            DgvSales.Columns[2].HeaderCell.Value = "التاريخ";
            DgvSales.Columns[3].HeaderCell.Value = "الوقت";
            DgvSales.Columns[4].HeaderCell.Value = "اسم المنتج";
            DgvSales.Columns[5].HeaderCell.Value = "الكمية";
            DgvSales.Columns[6].HeaderCell.Value = "سعر المنتج";
            DgvSales.Columns[7].HeaderCell.Value = "التخفيض";
            DgvSales.Columns[8].HeaderCell.Value = "السعر الاجمالي";
            DgvSales.Columns[9].HeaderCell.Value = "البائع";
            DgvSales.Columns[10].HeaderCell.Value = "حسبة الفاتورة";
            DgvSales.Columns[11].HeaderCell.Value = "المدفوع";
            DgvSales.Columns[12].HeaderCell.Value = "الباقي";


            DgvSales.Columns[3].Width = 50;
            //DgvSales.Columns[6].Visible = false;
            //DgvSales.Columns[7].Visible = false;
            //DgvSales.Columns[4].Visible = false;



        }

        private void btnSearch_Click(object sender, EventArgs e)
        {
            if (rbBoth.Checked)
            {
                DgvSales.DataSource = salesRepository.SearchBoth(txtSearch.Text, dtpFrom.Value, dtpTo.Value);
                lblEmptyData.Visible = dgvHelper.IsEmpty(DgvSales);

            }
            else if (rbCustomerAndOrder.Checked)
            {
                DgvSales.DataSource = salesRepository.SearchOnlySupplier(txtSearch.Text);
                lblEmptyData.Visible = dgvHelper.IsEmpty(DgvSales);
            }
            else
            {
                DgvSales.DataSource = salesRepository.SearchSalesByDate(dtpFrom.Value, dtpTo.Value);
                lblEmptyData.Visible = dgvHelper.IsEmpty(DgvSales);
            }

            txtSearch.Text = string.Empty;
        }
    }
}
