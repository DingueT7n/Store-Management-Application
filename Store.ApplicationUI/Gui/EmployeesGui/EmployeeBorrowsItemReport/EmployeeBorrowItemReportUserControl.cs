using Microsoft.EntityFrameworkCore;
using Store.ApplicationUI.Code.Helper;
using Store.ApplicationUI.Gui.LoadingGui;
using Store.Core.Entities.Employees;
using Store.Core.Interfaces;
using Store.Infrastructure.Data;

namespace Store.ApplicationUI.Gui.EmployeesGui.EmployeeBorrowsItemReport
{
    public partial class EmployeeBorrowItemReportUserControl : UserControl
    {




        private readonly MainForm _main;
        private readonly IEmployeeBorrowItemRepository _employeeBorrowItemRepository;
        private readonly ApplicationDbContext _context;

        public EmployeeBorrowItemReportUserControl(MainForm main, IEmployeeBorrowItemRepository employeeBorrowItemRepository, ApplicationDbContext context
            , IProductRepository productRepository)
        {
            InitializeComponent();
            _main = main;
            _employeeBorrowItemRepository = employeeBorrowItemRepository;
            _context = context;
        }


        public async void SetProductsToDgv(string t1, string barcode)
        {
            ////DgvSales.DataSource = await Task.Run(() => productsRepository.GetAll(p => p.Category));
            //var CustomerMoneyList = MainForm.Context.CustomersReports.
            //    Include(x => x.Customer).Include(x => x.Sale)
            //    .ToList();

            var data = _employeeBorrowItemRepository.GetAllEmpBorrowsItem(t1, barcode, dtpFrom.Value, dtpTo.Value);
            DgvSales.DataSource = data;

        }
        void RefreshDgv()
        {
            string t1 = string.Empty;

            if (rbStoresFrom.Checked) t1 = cmbEmployees.Text;

            SetColumns();
            SetProductsToDgv(t1, txtSearch.Text);
            lblEmptyData.Visible = dgvHelper.IsEmpty(DgvSales);
        }
        public async void LoadData()
        {
            dtpTo.Value = DateTime.Now;

            //ShowLoading
            LoadingForm.Instance(_main).Show();
            if (await _employeeBorrowItemRepository.IsConnectedAsync())
            {
                //Start Load Data
                cmbEmployees.DataSource = await _context.Employees.ToListAsync();
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

            DgvSales.DataSource = new List<EmployeeBorrowItem>();

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
        private async void button2_Click(object sender, EventArgs e)
        {
            try
            {
                if (MsgHelper.ShowDeleteDialog())
                {
                    for (int i = 0; i <= DgvSales.Rows.Count - 1; i++)
                    {
                        var deleteedRefund = await _context.EmployeesBorrowItems.Where(x => x.Id == Convert.ToInt32(DgvSales.Rows[i]
                            .Cells[8].Value.ToString())).FirstOrDefaultAsync();
                        if (deleteedRefund != null)
                        {
                            _context.Remove(deleteedRefund);
                            await _context.SaveChangesAsync();
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
            txtSearch.Text = txtSearch.Text.Replace("\r\n", "");
            RefreshDgv();
        }

        private void btnExportCustomer_Click(object sender, EventArgs e)
        {

        }
    }
}
