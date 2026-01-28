using Microsoft.EntityFrameworkCore;
using Store.ApplicationUI.Code.Helper;
using Store.ApplicationUI.Code.System;
using Store.ApplicationUI.Gui.LoadingGui;
using Store.Core.Entities.Employees;
using Store.Core.Interfaces;
using Store.Infrastructure.Data;

namespace Store.ApplicationUI.Gui.EmployeesGui.EmployeeBorrowMoneyReport
{
    public partial class EmployeeBorrowMoneyReportUserControl : UserControl
    {
        private readonly IEmployeeBorrowMoneyRepository _employeeBorrowMoneyRepository;
        private readonly MainForm _main;
        private readonly ApplicationDbContext _context;
        private readonly ControlManager _controlManager;
        public EmployeeBorrowMoneyReportUserControl(IEmployeeBorrowMoneyRepository employeeBorrowMoneyRepository, MainForm main, ApplicationDbContext context, ControlManager controlManager)
        {
            InitializeComponent();
            _employeeBorrowMoneyRepository = employeeBorrowMoneyRepository;
            _main = main;
            _context = context;
            _controlManager = controlManager;
        }

        public async void SetProductsToDgv(string t1, string barcode)
        {
            ////DgvSales.DataSource = await Task.Run(() => productsRepository.GetAll(p => p.Category));
            //var CustomerMoneyList = MainForm.Context.CustomersReports.
            //    Include(x => x.Customer).Include(x => x.Sale)
            //    .ToList();

            var data = _employeeBorrowMoneyRepository.GetAllEmpBorrowsItem(t1, barcode, dtpFrom.Value, dtpTo.Value);
            DgvSales.DataSource = data;

        }
        void RefreshDgv()
        {
            txtSearch.Text = txtSearch.Text.Replace("\r\n", "").Trim();
            string t1 = string.Empty;

            if (rbStoresFrom.Checked) t1 = cmbEmployees.Text;

            SetColumns();
            SetProductsToDgv(t1, txtSearch.Text);
            lblEmptyData.Visible = dgvHelper.IsEmpty(DgvSales);
        }
        public async Task LoadData()
        {
            dtpTo.Value = DateTime.Now;

            //ShowLoading
            LoadingForm.Instance(_main).Show();
            if (await _employeeBorrowMoneyRepository.IsConnectedAsync())
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

            DgvSales.DataSource = new List<EmployeeBorrowMoney>();

            DgvSales.Columns[0].HeaderCell.Value = "معرف الموظف";
            DgvSales.Columns[1].HeaderCell.Value = "المقدم للسلفية";
            DgvSales.Columns[2].HeaderCell.Value = "مستلم السلفية";
            DgvSales.Columns[3].HeaderCell.Value = "تاريخ السلفية";
            DgvSales.Columns[4].HeaderCell.Value = "وقت السلفية";
            DgvSales.Columns[5].HeaderCell.Value = "تاريخ الاستحقاق";
            DgvSales.Columns[6].HeaderCell.Value = "المبلغ";
            DgvSales.Columns[7].HeaderCell.Value = "الملاحظة";
            DgvSales.Columns[8].HeaderCell.Value = "الموظف";

            DgvSales.Columns[9].HeaderCell.Value = "معرف العملية";

            //DgvSales.Columns[8].Visible = false;
            DgvSales.Columns[8].Visible = false;
            //DgvSales.Columns[4].Visible = false;

        }
        private async void button2_Click(object sender, EventArgs e)
        {
            try
            {
                ToasterHelper.PlayNotificationSound();
                if (MsgHelper.ShowDeleteDialog())
                {
                    for (int i = 0; i <= DgvSales.Rows.Count - 1; i++)
                    {
                        var deleteedRefund = await _context.EmployeesBorrowMonies.Where(x => x.Id == Convert.ToInt32(DgvSales.Rows[i].Cells[9].Value.ToString()))
                            .FirstOrDefaultAsync();
                        if (deleteedRefund != null)
                        {
                            _context.Remove(deleteedRefund);
                            _context.SaveChanges();
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

        private void btnSearch_Click(object sender, EventArgs e)
        {
            txtSearch.Text = txtSearch.Text.Replace("\r\n", "").Trim();
            RefreshDgv();
        }

        private void cmbEmployees_SelectionChangeCommitted(object sender, EventArgs e)
        {
            txtSearch.Text = txtSearch.Text.Replace("\r\n", "").Trim();
            RefreshDgv();
        }

        private void txtSearch_KeyDown(object sender, KeyEventArgs e)
        {
            if (e.KeyCode == Keys.Enter)
            {
                txtSearch.Text = txtSearch.Text.Replace("\r\n", "").Trim();
                btnSearch_Click(sender, e);
            }
        }
    }
}
