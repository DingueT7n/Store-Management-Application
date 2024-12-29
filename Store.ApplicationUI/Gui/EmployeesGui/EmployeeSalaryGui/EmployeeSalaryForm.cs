using Microsoft.EntityFrameworkCore;
using Store.ApplicationUI.Code.Helper;
using Store.ApplicationUI.Gui.LoadingGui;
using Store.Core.Entities.Caisses;
using Store.Core.Entities.Employees;
using Store.Infrastructure.Data;
using Store.Infrastructure.Repositories;

namespace Store.ApplicationUI.Gui.EmployeesGui.EmployeeSalaryGui
{
    public partial class EmployeeSalaryForm : Form
    {
        private static MainForm? _main;
        private EmployeeSalaryRepository? _employeesRepository;
        private static EmployeeSalaryForm? _addEmployeeForm;
        private ApplicationDbContext _context;

        public EmployeeSalaryForm(MainForm main)
        {
            InitializeComponent();
            _main = main;
            this.Owner = _main;
            _context = new ApplicationDbContext();
            _employeesRepository = new EmployeeSalaryRepository(_context);


            LoadData();
        }
        public static EmployeeSalaryForm Instance(MainForm main)
        {
            // If the instance is null or has been disposed, create a new one.
            if (_addEmployeeForm == null || _addEmployeeForm.IsDisposed)
            {
                _addEmployeeForm = new EmployeeSalaryForm(main);
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
            dtpJoined.Value = DateTime.Now;
            dtpReminderDate.Value = DateTime.Now.AddDays(30);

            //ShowLoading
            LoadingForm.Instance(_main).Show();
            if (await Task.Run(() => _employeesRepository.IsConnected()))
            {

                cmbEmployees.DataSource = _context.Employees.ToList();
                cmbEmployees.DisplayMember = "EmployeeName"; // Set the property to display
                cmbEmployees.ValueMember = "Id"; // Set the property to use as the value
                cmbEmployees.Text = "اختر موظف";

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
        void Vider()
        {
            txtAllSalary.Text = "0";
            txtBorrows.Text = "0";
            txtNotes.Text = string.Empty;
            txtNetSalary.Text = "0";


        }
        private void ResetForm()
        {
            // Clear all textboxes
            foreach (Control ctrl in _addEmployeeForm.Controls)
            {
                if (ctrl is TextBox)
                {
                    ((TextBox)ctrl).Clear();
                    ((TextBox)ctrl).Text = string.Empty;
                }
                else if (ctrl is ComboBox)
                {
                    ((ComboBox)ctrl).SelectedIndex = -1; // Deselect ComboBox
                }
                else if (ctrl is CheckBox)
                {
                    ((CheckBox)ctrl).Checked = false; // Uncheck CheckBox
                }
                // Add more control types if needed
            }

            // Reset any DataGridView

            Vider();

            // Reinitialize form data (e.g., reload initial data)
            LoadData(); // This is a method where you load initial data

            // Optionally reset focus to the first control
            // Set focus to the first control
        }

        private void txtAllSalary_KeyPress(object sender, KeyPressEventArgs e)
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

        private void cmbEmployees_SelectionChangeCommitted(object sender, EventArgs e)
        {
            try
            {
                var emp = _context.Employees.FirstOrDefault(
                    x => x.Id == Convert.ToInt32(cmbEmployees.SelectedValue));
                if (emp != null)
                {
                    txtAllSalary.Text = emp.Salary.ToString();

                }
                var empMinusBorrows = _context.EmployeesSalaryMinus.Where(x =>
                x.Emp_ID == Convert.ToInt32(cmbEmployees.SelectedValue) && x.Pay == "No").Sum(x => x.Price);
                txtBorrows.Text = empMinusBorrows.ToString();

                txtNetSalary.Text = (emp?.Salary - empMinusBorrows).ToString();

            }
            catch (Exception)
            {

                throw;
            }
        }

        private void btnAdd_Click(object sender, EventArgs e)
        {

            if (txtNetSalary.Text == string.Empty) return;
            if (Convert.ToDouble(txtNetSalary.Text) < 0)
            {
                if (!MsgHelper.ShowSalaryMinusIsNegative(cmbEmployees.Text, txtNetSalary.Text)) return;
            }
            using (var transaction = _context.Database.BeginTransaction())
            {
                try
                {
                    var caisse = _context.Caisses
                        .FirstOrDefault(x => x.Id == Properties.Settings.Default.DefaultCaisseId);

                    if (caisse is not null && caisse.MoneyinCaisse < _main.ConvertToFloat(txtNetSalary.Text))
                    {
                        MsgHelper.ShowInvalidMoneyTrasfert();
                        return;
                    }
                    EmployeeSalary employeeSalary = new EmployeeSalary();

                    employeeSalary.Emp_ID = Convert.ToInt32(cmbEmployees.SelectedValue);
                    employeeSalary.TotalSalary = _main.ConvertToFloat(txtAllSalary.Text);
                    employeeSalary.TotalBorrow = _main.ConvertToFloat(txtBorrows.Text);
                    employeeSalary.NetSalary = _main.ConvertToFloat(txtNetSalary.Text);
                    employeeSalary.OrderDate = dtpJoined.Value;
                    employeeSalary.Time = DateTime.Now.ToString("HH:mm");
                    employeeSalary.DateReminder = dtpReminderDate.Value;
                    employeeSalary.Notes = txtNotes.Text;
                    _context.Add(employeeSalary);
                    _context.SaveChanges();

                    if (caisse is not null)
                    {
                        if (0 > _main.ConvertToFloat(txtNetSalary.Text))
                            caisse.MoneyinCaisse += _main.ConvertToFloat(txtNetSalary.Text);
                        else
                            caisse.MoneyinCaisse -= _main.ConvertToFloat(txtNetSalary.Text);
                        var CaisseWithdraw = new CaisseWithdraw
                        {
                            Caisse_ID = Properties.Settings.Default.DefaultCaisseId,
                            Time = DateTime.Now.ToString("HH:mm"),
                            Date = dtpJoined.Value,
                            Name = $"{Properties.Settings.Default.UserName}",
                            Money = _main.ConvertToFloat(txtNetSalary.Text),
                            Reason = txtNotes.Text,
                            Type = "تصريف مرتب"
                        };

                        _context.Caisses.Update(caisse);
                        _context.SaveChanges();
                        _context.CaissesWithdraws.Add(CaisseWithdraw);
                        _context.SaveChanges();

                    }
                    _context.Database.ExecuteSqlRaw($"UPDATE EmployeesSalaryMinus SET Pay = 'Yes' where Emp_ID ={Convert.ToInt32(cmbEmployees.SelectedValue)}");





                    transaction.Commit();
                    ResetForm();
                }
                catch (Exception)
                {
                    transaction.Rollback();
                    throw;
                }

            }
        }
    }
}
