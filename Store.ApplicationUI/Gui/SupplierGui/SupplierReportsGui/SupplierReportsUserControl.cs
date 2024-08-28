using Microsoft.EntityFrameworkCore;
using Store.ApplicationUI.Code.Helper;
using Store.ApplicationUI.Gui.LoadingGui;
using Store.Infrastructure.Repositories;

namespace Store.ApplicationUI.Gui.SupplierGui.SupplierReportsGui
{
    public partial class SupplierReportsUserControl : UserControl
    {
        private static MainForm? _main;
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
                supplierReportRepository = new SupplierReportRepository(MainForm.Context);

                _supplierReportsUserControl = new SupplierReportsUserControl();

            }

            // Return the singleton instance
            _supplierReportsUserControl.LoadData();
            return _supplierReportsUserControl;
        }

        public async void SetProductsToDgv()
        {
            //DgvِCustomer.DataSource = await Task.Run(() => productsRepository.GetAll(p => p.Category));
            var CustomerMoneyList = MainForm.Context.SuppliersReports.
                Include(x => x.Supplier).Include(x => x.Buy)
                .ToList();
            var uniqueCustomerCount = CustomerMoneyList
                .Select(x => x.Supplier.Id) // Replace CustomerId with the actual unique identifier property
                .Distinct()
                .Count();
            DgvِCustomer.DataSource = CustomerMoneyList;
            if (DgvِCustomer.Rows.Count > 0)
            {
                if (DgvِCustomer.SelectedRows.Count > 0)
                {
                    //lblPayFacture.Text = $" فاتورة رقم {DgvِCustomer.Columns[7].HeaderCell.Value} الدين : {DgvِCustomer.Columns[1].HeaderCell.Value} دج";
                    //lblPayAllDebts.Text = $"دج {CustomerMoneyList.Sum(x => x.Price)}";
                    lblTotalDebt.Text = $"مجموع مدفوعات الموردين في الجدول:{CustomerMoneyList.Sum(x => x.Price)}";
                    lblTotalCustomers.Text = $"مجموع الموردين:{uniqueCustomerCount}";

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
            if (rbBoth.Checked)
            {
                DgvِCustomer.DataSource = supplierReportRepository.SearchBoth(txtSearch.Text, dtpFrom.Value, dtpTo.Value);
                lblEmptyData.Visible = dgvHelper.IsEmpty(DgvِCustomer);

            }
            else if (rbSupplierAndOrder.Checked)
            {
                DgvِCustomer.DataSource = supplierReportRepository.SearchOnlyCustomer(txtSearch.Text);
                lblEmptyData.Visible = dgvHelper.IsEmpty(DgvِCustomer);
            }
            else
            {


                DgvِCustomer.DataSource = supplierReportRepository.SearchOnlyDate(dtpFrom.Value, dtpTo.Value);
                lblEmptyData.Visible = dgvHelper.IsEmpty(DgvِCustomer);

            }

            txtSearch.Text = string.Empty;
        }

        private void SupplierReportsUserControl_Load(object sender, EventArgs e)
        {
            dtpTo.Value = DateTime.Now;
        }
    }
}
