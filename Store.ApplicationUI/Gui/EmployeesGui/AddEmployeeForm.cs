using Store.ApplicationUI.Code.Helper;
using Store.ApplicationUI.Gui.LoadingGui;
using Store.Core.Entities.Employees;
using Store.Infrastructure.Data;
using Store.Infrastructure.Repositories;

namespace Store.ApplicationUI.Gui.EmployeesGui
{
    public partial class AddEmployeeForm : Form
    {
        private static MainForm? _main;
        private EmployeesRepository? _employeesRepository;
        private static AddEmployeeForm? _addEmployeeForm;

        public AddEmployeeForm(MainForm main)
        {
            InitializeComponent();
            _main = main;
            this.Owner = _main;
            _employeesRepository = new EmployeesRepository(new ApplicationDbContext());

            LoadData();
        }
        public static AddEmployeeForm Instance(MainForm main)
        {
            // If the instance is null or has been disposed, create a new one.
            if (_addEmployeeForm == null || _addEmployeeForm.IsDisposed)
            {
                _addEmployeeForm = new AddEmployeeForm(main);
            }
            else
            {
                // Bring the form to the front if it exists.
                if (!_addEmployeeForm.Visible)
                {
                    _addEmployeeForm.Show();
                }
                _addEmployeeForm.BringToFront();
            }

            return _addEmployeeForm;
        }
        public async void LoadData()
        {


            //ShowLoading
            LoadingForm.Instance(_main).Show();
            if (await Task.Run(() => _employeesRepository.IsConnected()))
            {


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

        }
        void vider()
        {
            txtAddress.Text = "";
            txtNameEmployee.Text = "";
            txtPhoneNumber.Text = "";
            txtSalary.Text = $"0{Properties.Settings.Default.DecimalSEP}00";
            txtEmail.Text = "";
            txtNbrCartId.Text = "";


        }
        public void SetDataToEdit(string Name, string Address, string PhoneNumber
           , string Salary, string Email, string NbrCartId, string CustomerId, DateTime dateTime)
        {
            txtNameEmployee.Text = Name;
            txtAddress.Text = Address;

            txtPhoneNumber.Text = PhoneNumber;
            dtpJoined.Value = dateTime;
            txtSalary.Text = Salary;
            txtEmail.Text = Email;
            txtNbrCartId.Text = NbrCartId;
            lblِCustomerId.Text = CustomerId;
            btnAdd.Visible = false;
            btnEdit.Visible = true;
            lblِCustomerId.Visible = true;
            label13.Visible = true;
        }

        private void gbInfoEmployee_Enter(object sender, EventArgs e)
        {

        }

        private void btnExit_Click(object sender, EventArgs e)
        {
            Close();
        }

        private void txtSalary_KeyPress(object sender, KeyPressEventArgs e)
        {
            if (!char.IsDigit(e.KeyChar) && e.KeyChar != Properties.Settings.Default.DecimalSEP[0] && e.KeyChar != 8)
            {
                e.Handled = true;
            }
        }

        private void btnAdd_Click(object sender, EventArgs e)
        {
            Employee Employee = new Employee();
            Employee.EmployeeName = txtNameEmployee.Text;
            Employee.Address = txtAddress.Text;
            Employee.PhoneNumber = txtPhoneNumber.Text;
            Employee.Email = txtEmail.Text;
            Employee.Salary = _main.ConvertToFloat(txtSalary.Text);
            Employee.National_ID = txtNbrCartId.Text;
            Employee.DateJoined = dtpJoined.Value;
            var result = _employeesRepository.AddAsync(Employee);
            vider();
            if (!EmployeeUserControl.CheckInstance())
            {
                EmployeeUserControl.RefreshDgv();
            }
        }

        private void btnEdit_Click(object sender, EventArgs e)
        {
            Employee Employee = _employeesRepository.Find(lblِCustomerId.Text);
            Employee.EmployeeName = txtNameEmployee.Text;
            Employee.Address = txtAddress.Text;
            Employee.PhoneNumber = txtPhoneNumber.Text;
            Employee.Email = txtEmail.Text;
            Employee.Salary = _main.ConvertToFloat(txtSalary.Text);
            Employee.National_ID = txtNbrCartId.Text;
            Employee.DateJoined = dtpJoined.Value;
            var result = _employeesRepository.UpdateAsync(lblِCustomerId.Text, Employee);

            if (!EmployeeUserControl.CheckInstance())
            {
                EmployeeUserControl.RefreshDgv();
            }
            Employee = null;
        }
    }
}
