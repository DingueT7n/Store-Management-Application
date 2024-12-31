using Store.ApplicationUI.Code.Helper;
using Store.ApplicationUI.Gui.LoadingGui;
using Store.Infrastructure.Data;
using Store.Infrastructure.Repositories;

namespace Store.ApplicationUI.Gui.EmployeesGui.EmployeeBorrowsItemReport
{
    public partial class EmployeeBorrowItemReportUserControl : UserControl
    {
        private static MainForm? _main;
        private static ApplicationDbContext _contex;
        public static EmployeeBorrowItemRepository? EmployeeBorrowItemRepository;
        private static EmployeeBorrowItemReportUserControl? _storeDamagedProductUserControl;

        public EmployeeBorrowItemReportUserControl()
        {
            InitializeComponent();
        }
        public static bool CheckInstance()
        {
            return (_storeDamagedProductUserControl == null);
        }
        public static EmployeeBorrowItemReportUserControl Instance(MainForm main)
        {
            _main = main;
            // If the instance is null, create a new one and assign it to the static field
            if (CheckInstance())
            {
                _contex = new ApplicationDbContext();
                EmployeeBorrowItemRepository = new EmployeeBorrowItemRepository(_contex);

                _storeDamagedProductUserControl = new EmployeeBorrowItemReportUserControl();

            }

            // Return the singleton instance
            _storeDamagedProductUserControl.LoadData();
            return _storeDamagedProductUserControl;
        }
        public async void SetProductsToDgv(string t1, string barcode)
        {
            ////DgvSales.DataSource = await Task.Run(() => productsRepository.GetAll(p => p.Category));
            //var CustomerMoneyList = MainForm.Context.CustomersReports.
            //    Include(x => x.Customer).Include(x => x.Sale)
            //    .ToList();

            var data = EmployeeBorrowItemRepository.GetAllEmpBorrowsItem(t1, barcode, dtpFrom.Value, dtpTo.Value);
            DgvSales.DataSource = data;

        }
        void RefreshDgv()
        {
            string t1 = string.Empty;

            if (rbStoresFrom.Checked) t1 = cmbEmployees.Text;

            SetProductsToDgv(t1, txtSearch.Text);
            SetColumns();
            lblEmptyData.Visible = dgvHelper.IsEmpty(DgvSales);
        }
        public async void LoadData()
        {
            dtpTo.Value = DateTime.Now;

            //ShowLoading
            LoadingForm.Instance(_main).Show();
            if (await Task.Run(() => EmployeeBorrowItemRepository.IsConnected()))
            {
                //Start Load Data
                cmbEmployees.DataSource = _contex.Employees.ToList();
                cmbEmployees.DisplayMember = "EmployeeName";
                cmbEmployees.ValueMember = "Id";


                // if its an admin or Normal user 
                RefreshDgv();
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
            //DgvSales.Columns[0].HeaderCell.Value = "المعرف"; ""    



            DgvSales.Columns[0].HeaderCell.Value = "معرف المنتج";
            DgvSales.Columns[1].HeaderCell.Value = "اسم المنتج";
            DgvSales.Columns[2].HeaderCell.Value = "معرف الموظف";
            DgvSales.Columns[3].HeaderCell.Value = "تاريخ السحب";
            DgvSales.Columns[4].HeaderCell.Value = "وقت السحب";
            DgvSales.Columns[5].HeaderCell.Value = "الكمية";
            DgvSales.Columns[6].HeaderCell.Value = "اسم الموظف";
            DgvSales.Columns[7].HeaderCell.Value = "المنتج";
            DgvSales.Columns[8].HeaderCell.Value = "معرف العملية";

            //DgvSales.Columns[8].Visible = false;
            DgvSales.Columns[7].Visible = false;
            //DgvSales.Columns[4].Visible = false;



        }
        private void button2_Click(object sender, EventArgs e)
        {
            try
            {
                if (MsgHelper.ShowDeleteDialog())
                {
                    for (int i = 0; i <= DgvSales.Rows.Count - 1; i++)
                    {
                        var deleteedRefund = _contex.EmployeesBorrowItems.Where(x => x.Id == Convert.ToInt32(DgvSales.Rows[i].Cells[8].Value.ToString())).FirstOrDefault();
                        if (deleteedRefund != null)
                        {
                            _contex.Remove(deleteedRefund);
                            _contex.SaveChanges();
                        }
                    }
                    Code.Helper.ToasterHelper.ShowDeletedToast();

                    DgvSales.DataSource = null;
                    RefreshDgv();
                }
            }
            catch (Exception)
            {
                throw;
            }
        }

        private void rbStoresFromAll_CheckedChanged(object sender, EventArgs e)
        {
            cmbEmployees.Enabled = false;
            RefreshDgv();
        }

        private void rbStoresFrom_CheckedChanged(object sender, EventArgs e)
        {
            cmbEmployees.Enabled = true;
            RefreshDgv();
        }

        private void cmbStoresFrom_SelectionChangeCommitted(object sender, EventArgs e)
        {
            RefreshDgv();
        }

        private void btnSearch_Click(object sender, EventArgs e)
        {
            RefreshDgv();
        }

        private void btnExportCustomer_Click(object sender, EventArgs e)
        {

        }
    }
}
