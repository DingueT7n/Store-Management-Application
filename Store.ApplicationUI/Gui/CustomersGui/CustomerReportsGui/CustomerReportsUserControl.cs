using Microsoft.EntityFrameworkCore;
using Store.ApplicationUI.Code.Helper;
using Store.ApplicationUI.Gui.LoadingGui;
using Store.Core.Entities.Customers;
using Store.Infrastructure.Data;
using Store.Infrastructure.Repositories;

namespace Store.ApplicationUI.Gui.CustomersGui.CustomerReportsGui
{
    public partial class CustomerReportsUserControl : UserControl
    {
        private static MainForm? _main;
        private static ApplicationDbContext _context;
        public static CustomerReportRepository? customerReportRepository;
        private static CustomerReportsUserControl? _customerReportsUserControl;  // _customerReportsUserControl

        public CustomerReportsUserControl()
        {
            InitializeComponent();
        }
        public static bool CheckInstance()
        {
            return (_customerReportsUserControl == null);

        }
        public static CustomerReportsUserControl Instance(MainForm main)
        {
            _main = main;
            // If the instance is null, create a new one and assign it to the static field
            if (CheckInstance())
            {
                _context = new ApplicationDbContext();

                customerReportRepository = new CustomerReportRepository(_context);

                _customerReportsUserControl = new CustomerReportsUserControl();

            }

            // Return the singleton instance
            _customerReportsUserControl.LoadData();
            return _customerReportsUserControl;
        }

        public async void SetProductsToDgv(int skip)
        {
            var CustomerMoneyList = customerReportRepository.GetAllData(skip, Properties.Settings.Default.NoOfDataInDgvs);
            var uniqueCustomerCount = CustomerMoneyList.Result
                .Select(x => x.Customer.Id) // Replace CustomerId with the actual unique identifier property
                .Distinct()
                .Count();

            DgvِCustomer.DataSource = CustomerMoneyList.Result;

            double value = CustomerMoneyList.count / Convert.ToDouble(Properties.Settings.Default.NoOfDataInDgvs);
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
                    lblTotalDebt.Text = $"مجموع مدفوعات العملاء في الجدول:{CustomerMoneyList.Result.Sum(x => x.Price)}";
                    lblTotalCustomers.Text = $"مجموع العملاء:{uniqueCustomerCount}";
                }
            }
        }

        public static void RefreshDgv()
        {
            //DgvِCustomer.DataSource = await Task.Run(() => productsRepository.GetAllProducts());
            _customerReportsUserControl.LoadData();
        }
        // methodes 
        public async void LoadData()
        {


            //ShowLoading
            LoadingForm.Instance(_main).Show();
            if (await Task.Run(() => customerReportRepository.IsConnected()))
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



            DgvِCustomer.Columns[0].HeaderCell.Value = "معرف العميل";
            DgvِCustomer.Columns[1].HeaderCell.Value = "معرف الفاتورة";
            DgvِCustomer.Columns[2].HeaderCell.Value = "اسم العميل";
            DgvِCustomer.Columns[3].HeaderCell.Value = "الدين المدفوع";
            DgvِCustomer.Columns[4].HeaderCell.Value = "تاريخ الفاتورة";
            DgvِCustomer.Columns[5].HeaderCell.Value = "وقت العملية";
            DgvِCustomer.Columns[6].HeaderCell.Value = "بيع";
            DgvِCustomer.Columns[7].HeaderCell.Value = "عميل";
            DgvِCustomer.Columns[8].HeaderCell.Value = "رقم التقرير";

            DgvِCustomer.Columns[6].Visible = false;
            DgvِCustomer.Columns[7].Visible = false;
            //DgvِCustomer.Columns[4].Visible = false;



        }

        private void btnRefresh_Click(object sender, EventArgs e)
        {
            LoadData();
        }
        private void btnSearch_Click(object sender, EventArgs e)
        {
            try
            {


                int take = Properties.Settings.Default.NoOfDataInDgvs;
                int selectedi = cmbpagination.SelectedIndex;
                //int skip = Convert.ToInt32(cmbpagination.SelectedIndex) * take > -1 ? Convert.ToInt32(cmbpagination.SelectedIndex) * take : 0;


                if (selectedi == -1)
                {
                    selectedi = 0;

                }
                int skip = selectedi * take;
                CustomerReportDto a = new CustomerReportDto();
                DgvِCustomer.DataSource = new List<CustomerReport>();
                if (rbBoth.Checked)
                {
                    a = customerReportRepository.SearchBoth(txtSearch.Text, dtpFrom.Value, dtpTo.Value, take, skip);


                }
                else if (rbCustomerAndOrder.Checked)
                {
                    a = customerReportRepository.SearchOnlyCustomer(txtSearch.Text, take, skip);

                }
                else
                {
                    a = customerReportRepository.SearchOnlyDate(dtpFrom.Value, dtpTo.Value, take, skip);
                }
                DgvِCustomer.DataSource = a.Result;

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
                var uniqueCustomerCount = a.Result
                    .Select(x => x.Customer.Id) // Replace CustomerId with the actual unique identifier property
                    .Distinct()
                    .Count();
                PaginationHide();
                if (DgvِCustomer.Rows.Count > 0)
                {
                    if (DgvِCustomer.SelectedRows.Count > 0)
                    {
                        lblTotalDebt.Text = $"مجموع مدفوعات العملاء في الجدول:{a.Result.Sum(x => x.Price)}";
                        lblTotalCustomers.Text = $"مجموع العملاء:{uniqueCustomerCount}";
                    }
                }
            }
            catch (Exception ex)
            {

                MessageBox.Show(ex.Message);
            }
        }

        private void rbCustomerAndOrder_CheckedChanged(object sender, EventArgs e)
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

        private void rbDateSearch_CheckedChanged(object sender, EventArgs e)
        {
            txtSearch.Enabled = false;
            dtpTo.Enabled = true;
            dtpFrom.Enabled = true;
        }

        private void CustomerReportsUserControl_Load(object sender, EventArgs e)
        {
            dtpTo.Value = DateTime.Now;
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
        void PaginationHide()
        {
            btnNext.Enabled = cmbpagination.SelectedIndex <= cmbpagination.Items.Count - 1 && !dgvHelper.IsEmpty(DgvِCustomer);
            btnPrev.Enabled = cmbpagination.SelectedIndex >= 0 && !dgvHelper.IsEmpty(DgvِCustomer);
            cmbpagination.Enabled = !dgvHelper.IsEmpty(DgvِCustomer);
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

        private void btnDeleteCurrentPage_Click(object sender, EventArgs e)
        {
            if (MsgHelper.ShowDeleteDialog())
            {
                for (int i = 0; i < DgvِCustomer.Rows.Count; i++)
                {
                    customerReportRepository.DeleteAsync(DgvِCustomer.Rows[i].Cells[8].Value.ToString());
                }
                LoadData();

            }
        }

        private async void btnDeleteReportsInPeriod_Click(object sender, EventArgs e)
        {
            if (MsgHelper.ShowDeleteDialog())
            {
                try
                {
                    var query = _context.CustomersReports
                        .Where(x => dtpFrom.Value <= x.Date && x.Date <= dtpTo.Value)
                        .ToList();

                    if (query.Any())
                    {
                        _context.CustomersReports.RemoveRange(query);
                        await _context.SaveChangesAsync();
                    }
                    else
                    {

                        MessageBox.Show("لا توجد بيانات في الفترة المحددة", "معلومة", MessageBoxButtons.OK, MessageBoxIcon.Information);
                    }
                    LoadData();
                }
                catch (Exception ex)
                {
                    // Handle or log the exception
                    MessageBox.Show($"An error occurred: {ex.Message}", "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
                }
            }
        }

        private void btnDeleteAllReports_Click(object sender, EventArgs e)
        {
            if (MsgHelper.ShowDeleteDialog())
            {
                try
                {
                    _context.Database.ExecuteSqlRaw($"DELETE FROM [CustomersReports]");

                    LoadData();
                }
                catch (Exception ex)
                {
                    // Handle or log the exception
                    MessageBox.Show($"لقد حدث خطأ {ex.Message}", "خطأ برمجي", MessageBoxButtons.OK, MessageBoxIcon.Error);
                }
            }
        }

        private void btnExportCustomer_Click(object sender, EventArgs e)
        {

        }

        private void button1_Click(object sender, EventArgs e)
        {

        }

        private void button2_Click(object sender, EventArgs e)
        {

        }
    }
}
