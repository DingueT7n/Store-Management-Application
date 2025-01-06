using Store.ApplicationUI.Code.Helper;
using Store.ApplicationUI.Gui.LoadingGui;
using Store.Infrastructure.Data;
using Store.Infrastructure.Repositories;

namespace Store.ApplicationUI.Gui.EmployeesGui
{
    public partial class EmployeeUserControl : UserControl
    {
        private static EmployeeUserControl? _employeeUserControl;
        private static MainForm? _main;
        private AddEmployeeForm addEmployeeForm;
        public static EmployeesRepository? employeesRepository;
        private static ApplicationDbContext _context;
        public EmployeeUserControl()
        {
            InitializeComponent();
        }
        public static bool CheckInstance()
        {
            return (_employeeUserControl == null);

        }

        public static EmployeeUserControl Instance(MainForm main)
        {
            _main = main;
            // If the instance is null, create a new one and assign it to the static field
            _context = new ApplicationDbContext();
            if (CheckInstance())
            {
                employeesRepository = new EmployeesRepository(_context);

                _employeeUserControl = new EmployeeUserControl();

            }

            // Return the singleton instance
            _employeeUserControl.LoadData();
            return _employeeUserControl;
        }
        public async void SetProductsToDgv()
        {
            //DgvِCustomer.DataSource = await Task.Run(() => productsRepository.GetAll(p => p.Category));
            DgvِCustomer.DataSource = employeesRepository.GetAllData();
        }

        public static void RefreshDgv()
        {
            //DgvِCustomer.DataSource = await Task.Run(() => productsRepository.GetAllProducts());
            _employeeUserControl.LoadData();
        }
        // methodes 
        public async void LoadData()
        {


            //ShowLoading
            LoadingForm.Instance(_main).Show();
            if (await Task.Run(() => employeesRepository.IsConnected()))
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
            DgvِCustomer.Columns[0].HeaderCell.Value = "اسم الموظف";
            DgvِCustomer.Columns[1].HeaderCell.Value = "راتب الموظف";
            DgvِCustomer.Columns[2].HeaderCell.Value = "تاريخ انضمام الموظف";
            DgvِCustomer.Columns[3].HeaderCell.Value = "رقم بطاقة التعريف الوطني";
            DgvِCustomer.Columns[4].HeaderCell.Value = "البريد الالكتروني";
            DgvِCustomer.Columns[5].HeaderCell.Value = "العنوان";
            DgvِCustomer.Columns[6].HeaderCell.Value = "رقم الهاتف";
            DgvِCustomer.Columns[7].HeaderCell.Value = "معرف الموظف";
        }

        private void btnRefresh_Click(object sender, EventArgs e)
        {
            LoadData();
        }

        private void btnAdd_Click(object sender, EventArgs e)
        {
            ToasterHelper.PlayNotificationSound();
            if (addEmployeeForm == null || addEmployeeForm.IsDisposed)
            {
                addEmployeeForm = AddEmployeeForm.Instance(_main);
                addEmployeeForm.Show();
            }
            else
            {
                addEmployeeForm.Focus();
            }
        }

        private void btnEdit_Click(object sender, EventArgs e)
        {
            ToasterHelper.PlayNotificationSound();
            if (DgvِCustomer.Rows.Count > 0)
            {
                if (addEmployeeForm == null || addEmployeeForm.IsDisposed)
                {
                    addEmployeeForm = AddEmployeeForm.Instance(_main);


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

                    addEmployeeForm.Show();
                }
                else
                {
                    addEmployeeForm.Focus();
                }
            }
        }

        private void btnDelete_Click(object sender, EventArgs e)
        {
            try
            {
                ToasterHelper.PlayNotificationSound();
                if (MsgHelper.ShowDeleteDialog())
                {
                    var customer = employeesRepository.DeleteAsync(DgvِCustomer.CurrentRow.Cells[7].Value.ToString());
                    Code.Helper.ToasterHelper.ShowDeletedToast();


                }
                RefreshDgv();
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
