using Store.ApplicationUI.Code.Helper;
using Store.ApplicationUI.Code.System;
using Store.ApplicationUI.Gui.LoadingGui;
using Store.Core.Entities.Employees;
using Store.Core.Interfaces;

namespace Store.ApplicationUI.Gui.EmployeesGui
{
    public partial class AddEmployeeForm : Form
    {
        private readonly MainForm _main;

        private IEmployeesRepository _employeesRepository;
        private readonly ControlManager _controlManager;

        public AddEmployeeForm(MainForm main, IEmployeesRepository employeesRepository, ControlManager controlManager)
        {

            InitializeComponent();
            _main = main;
            _employeesRepository = employeesRepository;
            _controlManager = controlManager;
            this.Owner = _main;

        }

        public async Task LoadData()
        {
            dgvHelper.ResetForm(this);
            vider();
            //ShowLoading
            LoadingForm.Instance(_main).Show();
            if (await _employeesRepository.IsConnectedAsync())
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
            btnAdd.Visible = true;
            btnEdit.Visible = false;
            lblِCustomerId.Visible = false;
            label13.Visible = false;


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
            ToasterHelper.PlayNotificationSound();
            Close();
        }

        private void txtSalary_KeyPress(object sender, KeyPressEventArgs e)
        {
            string currentText = (sender as TextBox)?.Text ?? string.Empty;


            char decimalSeparator = Properties.Settings.Default.DecimalSEP[0];


            if (!char.IsDigit(e.KeyChar) && e.KeyChar != decimalSeparator && e.KeyChar != (char)8)
            {
                e.Handled = true;
            }

            else if (e.KeyChar == decimalSeparator && currentText.Contains(decimalSeparator))
            {
                e.Handled = true;
            }
        }

        private async void btnAdd_Click(object sender, EventArgs e)
        {
            try
            {


                ToasterHelper.PlayNotificationSound();
                Employee Employee = new Employee();
                Employee.EmployeeName = txtNameEmployee.Text;
                Employee.Address = txtAddress.Text;
                Employee.PhoneNumber = txtPhoneNumber.Text;
                Employee.Email = txtEmail.Text;
                Employee.Salary = _main.ConvertToFloat(txtSalary.Text);
                Employee.National_ID = txtNbrCartId.Text;
                Employee.DateJoined = dtpJoined.Value;
                var result = await _employeesRepository.AddAsync(Employee);
                Code.Helper.ToasterHelper.ShowAddToast();

                await LoadData();

                if (_controlManager.TryGet<EmployeeUserControl>(out var UD))
                {
                    await UD.LoadData();
                }
            }
            catch (Exception)
            {

                throw;
            }
        }

        private async void btnEdit_Click(object sender, EventArgs e)
        {
            try
            {


                ToasterHelper.PlayNotificationSound();
                Employee Employee = _employeesRepository.Find(lblِCustomerId.Text);
                if (Employee is not null)
                {
                    Employee.EmployeeName = txtNameEmployee.Text;
                    Employee.Address = txtAddress.Text;
                    Employee.PhoneNumber = txtPhoneNumber.Text;
                    Employee.Email = txtEmail.Text;
                    Employee.Salary = _main.ConvertToFloat(txtSalary.Text);
                    Employee.National_ID = txtNbrCartId.Text;
                    Employee.DateJoined = dtpJoined.Value;
                    var result = await _employeesRepository.UpdateAsync(lblِCustomerId.Text, Employee);
                    Code.Helper.ToasterHelper.ShowEditToast();

                    await LoadData();

                    if (_controlManager.TryGet<EmployeeUserControl>(out var UD))
                    {
                        await UD.LoadData();
                    }
                    Employee = null;
                }
            }
            catch (Exception)
            {

                throw;
            }
        }
    }
}
