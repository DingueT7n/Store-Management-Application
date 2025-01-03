using Store.ApplicationUI.Code.Helper;
using Store.ApplicationUI.Gui.LoadingGui;
using Store.Core.Entities.Customers;
using Store.Core.Entities.Suppliers;
using Store.Infrastructure.Data;
using Store.Infrastructure.Repositories;

namespace Store.ApplicationUI.Gui.SupplierGui.SupplierReportsGui
{
    public partial class SupplierReportsUserControl : UserControl
    {
        private static MainForm? _main;
        private static ApplicationDbContext _context;
        public static SupplierReportRepository? supplierReportRepository;
        private static SupplierReportsUserControl? _supplierReportsUserControl;  // _supplierReportsUserControl
        public SupplierReportsUserControl()
        {
            InitializeComponent();
        }
        public static bool CheckInstance()
        {
            return (_supplierReportsUserControl == null);

        }
        public static SupplierReportsUserControl Instance(MainForm main)
        {
            _main = main;
            // If the instance is null, create a new one and assign it to the static field
            if (CheckInstance())
            {
                _context = new ApplicationDbContext();

                supplierReportRepository = new SupplierReportRepository(_context);

                _supplierReportsUserControl = new SupplierReportsUserControl();

            }

            // Return the singleton instance
            _supplierReportsUserControl.LoadData();
            return _supplierReportsUserControl;
        }

        public async void SetProductsToDgv(int skip)
        {

            var SuppliersMoneyList = supplierReportRepository.GetAllData(skip, Properties.Settings.Default.NoOfDataInDgvs);

            var uniqueSupplierCount = SuppliersMoneyList.Result
                .Select(x => x.Supplier.Id)
                .Distinct()
                .Count();
            DgvِCustomer.DataSource = SuppliersMoneyList.Result;
            double value = SuppliersMoneyList.count / Convert.ToDouble(Properties.Settings.Default.NoOfDataInDgvs);
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

            if (DgvِCustomer.Rows.Count > 0)
            {
                if (DgvِCustomer.SelectedRows.Count > 0)
                {
                    //lblPayFacture.Text = $" فاتورة رقم {DgvِCustomer.Columns[7].HeaderCell.Value} الدين : {DgvِCustomer.Columns[1].HeaderCell.Value} دج";
                    //lblPayAllDebts.Text = $"دج {CustomerMoneyList.Sum(x => x.Price)}";
                    lblTotalDebt.Text = $"مجموع مدفوعات الموردين في الجدول:{SuppliersMoneyList.Result.Sum(x => x.Price)}";
                    lblTotalCustomers.Text = $"مجموع الموردين:{uniqueSupplierCount}";

                }
            }
        }

        public static void RefreshDgv()
        {
            //DgvِCustomer.DataSource = await Task.Run(() => productsRepository.GetAllProducts());
            _supplierReportsUserControl.LoadData();
        }
        // methodes 
        public async void LoadData()
        {


            //ShowLoading
            LoadingForm.Instance(_main).Show();
            if (await Task.Run(() => supplierReportRepository.IsConnected()))
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
            lblEmptyData.Visible = dgvHelper.IsEmpty(DgvِCustomer);
        }

        private void SetColumns()
        {
            //DgvِCustomer.Columns[0].HeaderCell.Value = "المعرف";
            DgvِCustomer.Columns[0].HeaderCell.Value = "معرف المورد";
            DgvِCustomer.Columns[1].HeaderCell.Value = "معرف الفاتورة";
            DgvِCustomer.Columns[2].HeaderCell.Value = "اسم المورد";
            DgvِCustomer.Columns[3].HeaderCell.Value = "الدين المدفوع";
            DgvِCustomer.Columns[4].HeaderCell.Value = "تاريخ الفاتورة";
            DgvِCustomer.Columns[5].HeaderCell.Value = "وقت العملية";
            DgvِCustomer.Columns[6].HeaderCell.Value = "شراء";
            DgvِCustomer.Columns[7].HeaderCell.Value = "مورد";
            DgvِCustomer.Columns[8].HeaderCell.Value = "رقم التقرير";

            DgvِCustomer.Columns[6].Visible = false;
            DgvِCustomer.Columns[7].Visible = false;
            DgvِCustomer.Columns[0].Visible = false;
        }

        private void btnRefresh_Click(object sender, EventArgs e)
        {
            ToasterHelper.PlayNotificationSound();
            LoadData();
        }

        private void rbDateSearch_CheckedChanged(object sender, EventArgs e)
        {
            txtSearch.Enabled = false;
            dtpTo.Enabled = true;
            dtpFrom.Enabled = true;
        }

        private void rbSupplierAndOrder_CheckedChanged(object sender, EventArgs e)
        {
            dtpTo.Enabled = false;
            dtpFrom.Enabled = false;
            txtSearch.Enabled = true;
        }

        private void rbBoth_CheckedChanged(object sender, EventArgs e)
        {
            dtpTo.Enabled = true;
            dtpFrom.Enabled = true;
            txtSearch.Enabled = true;
        }

        private void btnSearch_Click(object sender, EventArgs e)
        {

            int take = Properties.Settings.Default.NoOfDataInDgvs;
            int selectedi = cmbpagination.SelectedIndex;
            //int skip = Convert.ToInt32(cmbpagination.SelectedIndex) * take > -1 ? Convert.ToInt32(cmbpagination.SelectedIndex) * take : 0;


            if (selectedi == -1)
            {
                selectedi = 0;

            }
            int skip = selectedi * take;
            SupplierReportDto a = new SupplierReportDto();
            DgvِCustomer.DataSource = new List<CustomerReport>();
            if (rbBoth.Checked)
            {
                a = supplierReportRepository.SearchBoth(txtSearch.Text, dtpFrom.Value, dtpTo.Value, take, skip);


            }
            else if (rbSupplierAndOrder.Checked)
            {
                a = supplierReportRepository.SearchOnlySupplier(txtSearch.Text, take, skip);

            }
            else
            {
                a = supplierReportRepository.SearchOnlyDate(dtpFrom.Value, dtpTo.Value, take, skip);

            }
            DgvِCustomer.DataSource = a.Result;

            PaginationHide();
            lblEmptyData.Visible = dgvHelper.IsEmpty(DgvِCustomer);
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
            int uniqueSupplierCount = 0;

            uniqueSupplierCount = a.Result
               .Select(x => x.Supplier.Id) // Replace CustomerId with the actual unique identifier property
               .Distinct()
               .Count();

            if (DgvِCustomer.Rows.Count > 0)
            {
                if (DgvِCustomer.SelectedRows.Count > 0)
                {
                    //lblPayFacture.Text = $" فاتورة رقم {DgvِCustomer.Columns[7].HeaderCell.Value} الدين : {DgvِCustomer.Columns[1].HeaderCell.Value} دج";
                    //lblPayAllDebts.Text = $"دج {CustomerMoneyList.Sum(x => x.Price)}";
                    lblTotalDebt.Text = $"مجموع مدفوعات الموردين في الجدول:{a.Result.Sum(x => x.Price)}";
                    lblTotalCustomers.Text = $"مجموع الموردين:{uniqueSupplierCount}";

                }
            }
            SetColumns();
        }

        private void SupplierReportsUserControl_Load(object sender, EventArgs e)
        {
            dtpTo.Value = DateTime.Now;
        }

        private void btnNext_Click(object sender, EventArgs e)
        {
            ToasterHelper.PlayNotificationSound();
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
        void PaginationHide()
        {
            btnNext.Enabled = cmbpagination.SelectedIndex < cmbpagination.Items.Count - 1 && !dgvHelper.IsEmpty(DgvِCustomer);
            btnPrev.Enabled = cmbpagination.SelectedIndex > 0 && !dgvHelper.IsEmpty(DgvِCustomer);
            cmbpagination.Enabled = !dgvHelper.IsEmpty(DgvِCustomer);
        }
        private void btnPrev_Click(object sender, EventArgs e)
        {

            ToasterHelper.PlayNotificationSound();
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
            ToasterHelper.PlayNotificationSound();
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
    }
}
