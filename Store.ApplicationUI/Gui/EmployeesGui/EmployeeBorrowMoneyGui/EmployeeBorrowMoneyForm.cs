using Store.ApplicationUI.Code.Helper;
using Store.ApplicationUI.Gui.LoadingGui;
using Store.Core.Entities.Caisses;
using Store.Core.Entities.Employees;
using Store.Infrastructure.Data;
using Store.Infrastructure.Repositories;

namespace Store.ApplicationUI.Gui.EmployeesGui.EmployeeBorrowMoneyGui
{
    public partial class EmployeeBorrowMoneyForm : Form
    {
        private static MainForm? _main;
        private EmployeeBorrowMoneyRepository? _employeesRepository;
        private static EmployeeBorrowMoneyForm? _addEmployeeForm;
        private ApplicationDbContext _context;


        public EmployeeBorrowMoneyForm(MainForm main)
        {
            InitializeComponent();
            _main = main;
            this.Owner = _main;
            _context = new ApplicationDbContext();
            _employeesRepository = new EmployeeBorrowMoneyRepository(_context);


            LoadData();
        }
        public static EmployeeBorrowMoneyForm Instance(MainForm main)
        {
            // If the instance is null or has been disposed, create a new one.
            if (_addEmployeeForm == null || _addEmployeeForm.IsDisposed)
            {
                _addEmployeeForm = new EmployeeBorrowMoneyForm(main);
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
            if (!char.IsDigit(e.KeyChar) && e.KeyChar != Properties.Settings.Default.DecimalSEP[0] && e.KeyChar != 8)
            {
                e.Handled = true;
            }
        }

        private async void btnAdd_Click(object sender, EventArgs e)
        {

            if (txtPrice.Text == string.Empty) return;
            if (_main.ConvertToFloat(txtPrice.Text) > 0)
                using (var transaction = _context.Database.BeginTransaction())
                {
                    try
                    {
                        var caisse = _context.Caisses.FirstOrDefault(x => x.Id == Properties.Settings.Default.DefaultCaisseId);
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
                        _context.Add(employeeBorrowMoney);
                        _context.SaveChanges();

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
                            _context.SaveChanges();
                            _context.CaissesWithdraws.Add(CaisseWithdraw);
                            _context.SaveChanges();

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

                            _context.Add(employeeSalaryMinus);
                            _context.SaveChanges();
                        }


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
