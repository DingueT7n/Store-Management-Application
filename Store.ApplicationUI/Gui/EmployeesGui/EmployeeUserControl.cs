using Store.ApplicationUI.Code.Helper;
using Store.ApplicationUI.Code.System;
using Store.ApplicationUI.Gui.LoadingGui;
using Store.Core.Entities.Employees;
using Store.Core.Interfaces;
using Store.Infrastructure.Data;

namespace Store.ApplicationUI.Gui.EmployeesGui
{
    public partial class EmployeeUserControl : UserControl
    {
        private readonly MainForm _main;
        private readonly IEmployeesRepository employeesRepository;
        private readonly ControlManager _controlManager;
        private readonly ApplicationDbContext _context;

        public EmployeeUserControl(MainForm main, IEmployeesRepository employeesRepository, ControlManager controlManager, ApplicationDbContext context)
        {
            InitializeComponent();
            _main = main;
            this.employeesRepository = employeesRepository;
            _controlManager = controlManager;
            _context = context;
        }
        public void SetProductsToDgv()
        {
            //DgvِCustomer.DataSource = await Task.Run(() => productsRepository.GetAll(p => p.Category));
            DgvِCustomer.DataSource = employeesRepository.GetAllData();
        }


        // methodes 
        public async Task LoadData()
        {


            //ShowLoading
            LoadingForm.Instance(_main).Show();
            if (await employeesRepository.IsConnectedAsync())
            {
                //Start Load Data

                // if its an admin or Normal user 

                SetColumns();
                SetProductsToDgv();
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
            DgvِCustomer.DataSource = new List<Employee>();
            //DgvِCustomer.Columns[0].HeaderCell.Value = "المعرف";
            DgvِCustomer.Columns[0].HeaderCell.Value = "اسم الموظف";
            DgvِCustomer.Columns[1].HeaderCell.Value = "راتب الموظف";
            DgvِCustomer.Columns[2].HeaderCell.Value = "تاريخ انضمام الموظف";
            DgvِCustomer.Columns[3].HeaderCell.Value = "رقم بطاقة التعريف الوطني";
            DgvِCustomer.Columns[4].HeaderCell.Value = "البريد الالكتروني";
            DgvِCustomer.Columns[5].HeaderCell.Value = "العنوان";
            DgvِCustomer.Columns[6].HeaderCell.Value = "رقم الهاتف";
            DgvِCustomer.Columns[7].HeaderCell.Value = "معرف الموظف";
        }

        private async void btnRefresh_Click(object sender, EventArgs e)
        {
            await LoadData();
        }

        private async void btnAdd_Click(object sender, EventArgs e)
        {
            ToasterHelper.PlayNotificationSound();

            var addEmployeeForm = await _controlManager.GetFAsync<AddEmployeeForm>();
            addEmployeeForm.ShowDialog();


        }

        private async void btnEdit_Click(object sender, EventArgs e)
        {
            ToasterHelper.PlayNotificationSound();
            if (DgvِCustomer.Rows.Count > 0)
            {
                var addEmployeeForm = await _controlManager.GetFAsync<AddEmployeeForm>();

                addEmployeeForm.SetDataToEdit(
                        DgvِCustomer.CurrentRow.Cells[0].Value.ToString(),
                        DgvِCustomer.CurrentRow.Cells[5].Value.ToString(),
                        DgvِCustomer.CurrentRow.Cells[6].Value.ToString(),
                        DgvِCustomer.CurrentRow.Cells[1].Value.ToString(),
                        DgvِCustomer.CurrentRow.Cells[4].Value.ToString(),
                        DgvِCustomer.CurrentRow.Cells[3].Value.ToString(),
                        DgvِCustomer.CurrentRow.Cells[7].Value.ToString(),
                        Convert.ToDateTime(DgvِCustomer.CurrentRow.Cells[2].Value.ToString())
                        );

                addEmployeeForm.ShowDialog();


            }
        }

        private async void btnDelete_Click(object sender, EventArgs e)
        {
            try
            {
                ToasterHelper.PlayNotificationSound();
                if (MsgHelper.ShowDeleteDialog())
                {
                    await employeesRepository.DeleteAsync(DgvِCustomer.CurrentRow.Cells[7].Value.ToString());
                    Code.Helper.ToasterHelper.ShowDeletedToast();


                }
                await LoadData();
            }
            catch (Exception ex)
            {

                MessageBox.Show(ex.Message);
            }

        }

        private void btnSearch_Click(object sender, EventArgs e)
        {
            ToasterHelper.PlayNotificationSound();
            txtSearch.Text = txtSearch.Text.Replace("\r\n", "");
            DgvِCustomer.DataSource = employeesRepository.SearchAll(txtSearch.Text);
            lblEmptyData.Visible = dgvHelper.IsEmpty(DgvِCustomer);
            txtSearch.Text = string.Empty;
        }

        private void txtSearch_KeyDown(object sender, KeyEventArgs e)
        {
            if (e.KeyCode == Keys.Enter)
            {
                btnSearch_Click(sender, e);
            }
        }
    }
}
