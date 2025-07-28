using Microsoft.EntityFrameworkCore;
using Store.ApplicationUI.Code.Helper;
using Store.ApplicationUI.Code.System;
using Store.ApplicationUI.Gui.LoadingGui;
using Store.Core.Entities.Caisses;
using Store.Core.Entities.Employees;
using Store.Core.Interfaces;
using Store.Infrastructure.Data;

namespace Store.ApplicationUI.Gui.EmployeesGui.EmployeeSalaryGui
{
    public partial class EmployeeSalaryForm : Form
    {
        private readonly MainForm _main;
        private readonly IEmployeeSalaryRepository _employeeSalaryRepository;
        private readonly ApplicationDbContext _context;
        private readonly ControlManager _controlManager;

        public EmployeeSalaryForm(MainForm main, IEmployeeSalaryRepository employeeSalaryRepository, ApplicationDbContext context
           , ControlManager controlManager)
        {
            InitializeComponent();
            _main = main;
            _employeeSalaryRepository = employeeSalaryRepository;
            _context = context;
            _controlManager = controlManager;
            this.Owner = _main;

        }

        public async Task LoadData()
        {
            dgvHelper.ResetForm(this);
            Vider();
            dtpJoined.Value = DateTime.Now;
            dtpReminderDate.Value = DateTime.Now.AddDays(30);

            //ShowLoading
            LoadingForm.Instance(_main).Show();
            if (await _employeeSalaryRepository.IsConnectedAsync())
            {

                cmbEmployees.DataSource = await _context.Employees.ToListAsync();
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
            foreach (Control ctrl in _controlManager.GetF<AddEmployeeForm>().Controls)
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

        private async void cmbEmployees_SelectionChangeCommitted(object sender, EventArgs e)
        {
            try
            {
                var emp = await _context.Employees.FirstOrDefaultAsync(
                    x => x.Id == Convert.ToInt32(cmbEmployees.SelectedValue));
                if (emp != null)
                {
                    txtAllSalary.Text = emp.Salary.ToString();

                }
                var empMinusBorrows = await _context.EmployeesSalaryMinus.Where(x =>
                x.Emp_ID == Convert.ToInt32(cmbEmployees.SelectedValue) && x.Pay == "No").SumAsync(x => x.Price);
                txtBorrows.Text = empMinusBorrows.ToString();

                txtNetSalary.Text = (emp?.Salary - empMinusBorrows).ToString();

            }
            catch (Exception)
            {

                throw;
            }
        }

        private async void btnAdd_Click(object sender, EventArgs e)
        {

            ToasterHelper.PlayNotificationSound();
            if (txtNetSalary.Text == string.Empty) return;
            if (Convert.ToDouble(txtNetSalary.Text) < 0)
            {
                if (!MsgHelper.ShowSalaryMinusIsNegative(cmbEmployees.Text, txtNetSalary.Text)) return;
            }
            using (var transaction = await _context.Database.BeginTransactionAsync())
            {
                try
                {
                    var caisse = await _context.Caisses
                        .FirstOrDefaultAsync(x => x.Id == Properties.Settings.Default.DefaultCaisseId);

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
                    await _context.AddAsync(employeeSalary);
                    await _context.SaveChangesAsync();

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
                        await _context.SaveChangesAsync();
                        await _context.CaissesWithdraws.AddAsync(CaisseWithdraw);
                        await _context.SaveChangesAsync();

                    }
                    await _context.Database.ExecuteSqlRawAsync($"UPDATE EmployeesSalaryMinus SET Pay = 'Yes' where Emp_ID ={Convert.ToInt32(cmbEmployees.SelectedValue)}");





                    await transaction.CommitAsync();
                    Code.Helper.ToasterHelper.ShowSalarie();

                    await LoadData();
                }
                catch (Exception)
                {
                    await transaction.RollbackAsync();
                    throw;
                }

            }
        }

        private void gbInfo_Enter(object sender, EventArgs e)
        {

        }
    }
}
