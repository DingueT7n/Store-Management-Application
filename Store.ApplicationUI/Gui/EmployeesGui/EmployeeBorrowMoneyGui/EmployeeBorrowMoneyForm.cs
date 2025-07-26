using Microsoft.EntityFrameworkCore;
using Store.ApplicationUI.Code.Helper;
using Store.ApplicationUI.Code.System;
using Store.ApplicationUI.Gui.LoadingGui;
using Store.Core.Entities.Caisses;
using Store.Core.Entities.Employees;
using Store.Core.Interfaces;
using Store.Infrastructure.Data;

namespace Store.ApplicationUI.Gui.EmployeesGui.EmployeeBorrowMoneyGui
{
    public partial class EmployeeBorrowMoneyForm : Form
    {

        private readonly IEmployeeBorrowMoneyRepository _employeeBorrowMoneyRepository;
        private readonly MainForm _main;

        private readonly ApplicationDbContext _context;
        private readonly ControlManager _controlManager;

        public EmployeeBorrowMoneyForm(MainForm main, IEmployeeBorrowMoneyRepository employeeBorrowMoneyRepository, ApplicationDbContext context
          , ControlManager controlManager)
        {
            InitializeComponent();
            _main = main;
            _employeeBorrowMoneyRepository = employeeBorrowMoneyRepository;
            _context = context;
            _controlManager = controlManager;
            this.Owner = _main;
            LoadData();
        }

        public async void LoadData()
        {
            dtpJoined.Value = DateTime.Now;
            dtpReminderDate.Value = DateTime.Now.AddDays(30);

            //ShowLoading
            LoadingForm.Instance(_main).Show();
            if (await _employeeBorrowMoneyRepository.IsConnectedAsync())
            {

                cmbEmployees.DataSource = await _context.Employees.ToListAsync();
                cmbEmployees.DisplayMember = "EmployeeName"; // Set the property to display
                cmbEmployees.ValueMember = "Id"; // Set the property to use as the value


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
            txtPrice.Text = "0";
            txtPersonName.Text = string.Empty;
            txtNotes.Text = string.Empty;
            txtNameDebtGiver.Text = string.Empty;


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

            Vider();

            // Reinitialize form data (e.g., reload initial data)
            LoadData(); // This is a method where you load initial data

            // Optionally reset focus to the first control
            // Set focus to the first control
        }

        private void rbEmployee_CheckedChanged(object sender, EventArgs e)
        {
            cmbEmployees.Enabled = true;
            txtPersonName.Enabled = false;

        }

        private void rbNormalPerson_CheckedChanged(object sender, EventArgs e)
        {
            cmbEmployees.Enabled = false;
            txtPersonName.Enabled = true;

        }

        private void txtPrice_KeyPress(object sender, KeyPressEventArgs e)
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

            ToasterHelper.PlayNotificationSound();
            if (txtPrice.Text == string.Empty) return;
            if (_main.ConvertToFloat(txtPrice.Text) > 0)
                using (var transaction = await _context.Database.BeginTransactionAsync())
                {
                    try
                    {
                        var caisse = await _context.Caisses.FirstOrDefaultAsync(x => x.Id == Properties.Settings.Default.DefaultCaisseId);
                        if (caisse is not null && caisse.MoneyinCaisse < _main.ConvertToFloat(txtPrice.Text))
                        {
                            MsgHelper.ShowInvalidMoneyTrasfert();
                            return;
                        }
                        EmployeeBorrowMoney employeeBorrowMoney = new EmployeeBorrowMoney();

                        employeeBorrowMoney.Emp_Id = rbEmployee.Checked ? Convert.ToInt32(cmbEmployees.SelectedValue) : null;
                        employeeBorrowMoney.BorrowFrom = txtNameDebtGiver.Text;
                        employeeBorrowMoney.BorrowTo = rbEmployee.Checked ? cmbEmployees.Text : txtPersonName.Text;
                        employeeBorrowMoney.OrderDate = dtpJoined.Value;
                        employeeBorrowMoney.Time = DateTime.Now.ToString("HH:mm");
                        employeeBorrowMoney.DateReminder = dtpReminderDate.Value;
                        employeeBorrowMoney.Value = _main.ConvertToFloat(txtPrice.Text);
                        employeeBorrowMoney.Notes = txtNotes.Text;

                        await _employeeBorrowMoneyRepository.AddAsync(employeeBorrowMoney);

                        if (caisse is not null)
                        {

                            caisse.MoneyinCaisse -= _main.ConvertToFloat(txtPrice.Text);

                            var CaisseWithdraw = new CaisseWithdraw
                            {
                                Caisse_ID = Properties.Settings.Default.DefaultCaisseId,
                                Time = DateTime.Now.ToString("HH:mm"),
                                Date = dtpJoined.Value,
                                Name = $"  {Properties.Settings.Default.UserName}  {txtNameDebtGiver.Text} بحساب ",
                                Money = _main.ConvertToFloat(txtPrice.Text),
                                Reason = txtNotes.Text,
                                Type = "سلفيات"
                            };

                            _context.Caisses.Update(caisse);
                            await _context.SaveChangesAsync();
                            await _context.CaissesWithdraws.AddAsync(CaisseWithdraw);
                            await _context.SaveChangesAsync();

                        }
                        if (rbEmployee.Checked)
                        {
                            EmployeeSalaryMinus employeeSalaryMinus = new EmployeeSalaryMinus();
                            employeeSalaryMinus.Pay = "No";
                            employeeSalaryMinus.Date = dtpJoined.Value;
                            employeeSalaryMinus.Emp_ID = Convert.ToInt32(cmbEmployees.SelectedValue);
                            employeeSalaryMinus.EmployeeName = cmbEmployees.Text;
                            employeeSalaryMinus.Time = DateTime.Now.ToString("HH:mm");
                            employeeSalaryMinus.Price = _main.ConvertToFloat(txtPrice.Text);

                            await _context.AddAsync(employeeSalaryMinus);
                            await _context.SaveChangesAsync();
                        }


                        await transaction.CommitAsync();
                        Code.Helper.ToasterHelper.ShowBorrowMoney();

                        ResetForm();
                    }
                    catch (Exception)
                    {
                        await transaction.RollbackAsync();
                        throw;
                    }

                }
        }
    }
}
