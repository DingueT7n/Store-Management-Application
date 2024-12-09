using Store.ApplicationUI.Code.Helper;
using Store.ApplicationUI.Gui.LoadingGui;
using Store.Core.Entities.Sales;
using Store.Infrastructure.Data;
using Store.Infrastructure.Repositories;

namespace Store.ApplicationUI.Gui.SalesGui.SalesReportsGui
{
    public partial class SalesReportsUserControl : UserControl
    {
        private static MainForm? _main;
        private static ApplicationDbContext _contex;
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
                _contex = new ApplicationDbContext();
                salesRepository = new SalesRepository(_contex);

                _salesReportsUserControl = new SalesReportsUserControl();

            }

            // Return the singleton instance
            _salesReportsUserControl.LoadData();
            return _salesReportsUserControl;
        }
        public async void SetProductsToDgv(int skip)
        {
            ////DgvSales.DataSource = await Task.Run(() => productsRepository.GetAll(p => p.Category));
            //var CustomerMoneyList = MainForm.Context.CustomersReports.
            //    Include(x => x.Customer).Include(x => x.Sale)
            //    .ToList();
            var data = salesRepository.GetAllSalesWithDetails(Properties.Settings.Default.NoOfDataInDgvs, skip);
            DgvSales.DataSource = data.result;
            double value = data.count / Convert.ToDouble(Properties.Settings.Default.NoOfDataInDgvs);
            int PageValue = Convert.ToInt32(Math.Round(value, MidpointRounding.AwayFromZero));
            cmbpagination.Items.Clear();
            for (int i = 0; i < PageValue; i++)
            {
                cmbpagination.Items.Add(i + 1);

            }
            if (cmbpagination.Items.Count > 0)
            {
                cmbpagination.SelectedIndex = 0;
            }
            PaginationHide();

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

            dtpTo.Value = DateTime.Now;
            //ShowLoading
            LoadingForm.Instance(_main).Show();
            if (await Task.Run(() => salesRepository.IsConnected()))
            {
                //Start Load Data

                // if its an admin or Normal user 

                SetProductsToDgv(0);
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
            int take = Properties.Settings.Default.NoOfDataInDgvs;
            int selectedi = cmbpagination.SelectedIndex;

            if (selectedi == -1)
            {
                selectedi = 0;

            }
            int skip = selectedi * take;
            ResultSaleDetailDto a = new ResultSaleDetailDto();
            DgvSales.DataSource = new List<SaleDetailDto>();
            if (rbBoth.Checked)
            {
                a = salesRepository.SearchBoth(txtSearch.Text, dtpFrom.Value, dtpTo.Value, take, skip);

            }
            else if (rbCustomerAndOrder.Checked)
            {
                a = salesRepository.SearchOnlySupplier(txtSearch.Text, take, skip);

            }
            else
            {
                a = salesRepository.SearchSalesByDate(dtpFrom.Value, dtpTo.Value, take, skip);

            }
            DgvSales.DataSource = a.result;

            lblEmptyData.Visible = dgvHelper.IsEmpty(DgvSales);
            int totalRecords = a.count;
            int pageValue = (int)Math.Ceiling((double)totalRecords / take);
            cmbpagination.Items.Clear();

            for (int i = 0; i < pageValue; i++)
            {
                cmbpagination.Items.Add(i + 1);
            }
            if (selectedi < cmbpagination.Items.Count && cmbpagination.Items.Count > 0)
            {
                cmbpagination.SelectedIndex = selectedi;

            }
            PaginationHide();


        }

        private void cmbpagination_SelectedIndexChanged(object sender, EventArgs e)
        {
            //if (cmbpagination.SelectedIndex == -1)
            //{
            //    cmbpagination.SelectedIndex = 0;
            //}
            //else
            //{
            //    int skip = cmbpagination.SelectedIndex * Properties.Settings.Default.NoOfDataInDgvs;
            //    SetProductsToDgv(skip);
            //}
        }
        void PaginationHide()
        {
            btnNext.Enabled = cmbpagination.SelectedIndex < cmbpagination.Items.Count - 1 && !dgvHelper.IsEmpty(DgvSales);
            btnPrev.Enabled = cmbpagination.SelectedIndex > 0 && !dgvHelper.IsEmpty(DgvSales);
            cmbpagination.Enabled = !dgvHelper.IsEmpty(DgvSales);
        }
        private void btnNext_Click(object sender, EventArgs e)
        {

            if (cmbpagination.SelectedIndex == -1)
            {
                cmbpagination.SelectedIndex = 0;  // Set to first page if no page is selected
            }

            if (cmbpagination.SelectedIndex < cmbpagination.Items.Count - 1)
            {
                cmbpagination.SelectedIndex += 1;
                btnSearch_Click(sender, e);
            }
        }

        private void btnPrev_Click(object sender, EventArgs e)
        {
            if (cmbpagination.SelectedIndex == -1)
            {
                cmbpagination.SelectedIndex = 0;
            }

            if (cmbpagination.SelectedIndex > 0)
            {
                cmbpagination.SelectedIndex -= 1;
                btnSearch_Click(sender, e);
            }
        }

        private void cmbpagination_SelectionChangeCommitted(object sender, EventArgs e)
        {
            if (cmbpagination.SelectedIndex == -1)
            {
                cmbpagination.SelectedIndex = 0;
            }
            //else if (cmbpagination.Items.Count == 1)
            //{
            //    return;
            //}
            else
            {

                btnSearch_Click(sender, e);
            }
        }

        private void btnExportCustomer_Click(object sender, EventArgs e)
        {

        }
    }
}
