using Microsoft.EntityFrameworkCore;
using Store.ApplicationUI.Code.Helper;
using Store.ApplicationUI.Gui.LoadingGui;
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

        public async void SetProductsToDgv()
        {
            //DgvِCustomer.DataSource = await Task.Run(() => productsRepository.GetAll(p => p.Category));
            var CustomerMoneyList = _context.CustomersReports.
                Include(x => x.Customer).Include(x => x.Sale)
                .ToList();
            var uniqueCustomerCount = CustomerMoneyList
                .Select(x => x.Customer.Id) // Replace CustomerId with the actual unique identifier property
                .Distinct()
                .Count();
            DgvِCustomer.DataSource = CustomerMoneyList;
            if (DgvِCustomer.Rows.Count > 0)
            {
                if (DgvِCustomer.SelectedRows.Count > 0)
                {
                    //lblPayFacture.Text = $" فاتورة رقم {DgvِCustomer.Columns[7].HeaderCell.Value} الدين : {DgvِCustomer.Columns[1].HeaderCell.Value} دج";
                    //lblPayAllDebts.Text = $"دج {CustomerMoneyList.Sum(x => x.Price)}";
                    lblTotalDebt.Text = $"مجموع مدفوعات العملاء في الجدول:{CustomerMoneyList.Sum(x => x.Price)}";
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
            if (rbBoth.Checked)
            {
                DgvِCustomer.DataSource = customerReportRepository.SearchBoth(txtSearch.Text, dtpFrom.Value, dtpTo.Value);
                lblEmptyData.Visible = dgvHelper.IsEmpty(DgvِCustomer);

            }
            else if (rbCustomerAndOrder.Checked)
            {
                DgvِCustomer.DataSource = customerReportRepository.SearchOnlyCustomer(txtSearch.Text);
                lblEmptyData.Visible = dgvHelper.IsEmpty(DgvِCustomer);
            }
            else
            {


                DgvِCustomer.DataSource = customerReportRepository.SearchOnlyDate(dtpFrom.Value, dtpTo.Value);
                lblEmptyData.Visible = dgvHelper.IsEmpty(DgvِCustomer);

            }

            txtSearch.Text = string.Empty;
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

            if (cmbpagination.SelectedIndex < cmbpagination.Items.Count - 1)
            {
                cmbpagination.SelectedIndex += 1;
                int skip = cmbpagination.SelectedIndex * Properties.Settings.Default.NoOfDataInDgvs;
                btnSearch_Click(sender, e);
            }
        }

        private void btnPrev_Click(object sender, EventArgs e)
        {
            if (cmbpagination.SelectedIndex > 0)
            {
                cmbpagination.SelectedIndex -= 1;
                int skip = cmbpagination.SelectedIndex * Properties.Settings.Default.NoOfDataInDgvs;
                btnSearch_Click(sender, e);
            }
        }

        private void cmbpagination_SelectionChangeCommitted(object sender, EventArgs e)
        {
            if (cmbpagination.SelectedIndex == -1)
            {
                cmbpagination.SelectedIndex = 0;
            }
            else
            {
                int skip = cmbpagination.SelectedIndex * Properties.Settings.Default.NoOfDataInDgvs;
                btnSearch_Click(sender, e);
            }
        }
    }
}
