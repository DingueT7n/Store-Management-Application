using Store.ApplicationUI.Code.Helper;
using Store.ApplicationUI.Gui.LoadingGui;
using Store.Core.Entities.Employees;
using Store.Core.Entities.Products;
using Store.Infrastructure.Data;
using Store.Infrastructure.Repositories;

namespace Store.ApplicationUI.Gui.EmployeesGui.EmployeeBorrowItemsGui
{
    public partial class EmployeeBorrowItemForm : Form
    {
        private static MainForm? _main;
        private EmployeeBorrowItemRepository? _employeesRepository;
        private static EmployeeBorrowItemForm? _addEmployeeForm;
        private ApplicationDbContext _context;
        private ProductsRepository productsRepository;
        private Product _product;

        public EmployeeBorrowItemForm(MainForm main)
        {
            InitializeComponent();
            _main = main;
            this.Owner = _main;
            _context = new ApplicationDbContext();
            _employeesRepository = new EmployeeBorrowItemRepository(_context);
            productsRepository = new ProductsRepository(_context);

            LoadData();
        }
        public static EmployeeBorrowItemForm Instance(MainForm main)
        {
            // If the instance is null or has been disposed, create a new one.
            if (_addEmployeeForm == null || _addEmployeeForm.IsDisposed)
            {
                _addEmployeeForm = new EmployeeBorrowItemForm(main);
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

        private void ResetForm()
        {
            // Clear all textboxes
            foreach (Control ctrl in this.Controls)
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



            // Reinitialize form data (e.g., reload initial data)
            LoadData(); // This is a method where you load initial data

            // Optionally reset focus to the first control
            // Set focus to the first control
        }

        private void txtBareCode_KeyPress(object sender, KeyPressEventArgs e)
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
        public async void SetProductsToTable()
        {
            //DgvProducts.DataSource = await Task.Run(() => productsRepository.GetAll(p => p.Category));
            _product = productsRepository.GetProductBarCode(txtBareCode.Text);
            if (_product is not null)
            {
                txtProductName.Text = _product.ProductName;

            }
            else
            {
                MsgHelper.ShowEmptyResult();
                txtBareCode.Focus();
            }
            txtBareCode.Clear();
        }
        private void txtBareCode_KeyDown(object sender, KeyEventArgs e)
        {
            if (e.KeyCode == Keys.Enter)
            {
                SetProductsToTable();
            }
        }

        private void btnAdd_Click(object sender, EventArgs e)
        {
            if (_product is null) return;
            if (txtQty.Text == string.Empty) return;
            using (var transaction = _context.Database.BeginTransaction())
            {
                try
                {
                    _product.Quentity -= _main.ConvertToFloat(txtQty.Text);
                    _context.Update(_product);
                    _context.SaveChanges();

                    EmployeeBorrowItem employeeBorrowItem = new EmployeeBorrowItem();
                    employeeBorrowItem.Quentity = _main.ConvertToFloat(txtQty.Text);
                    employeeBorrowItem.Date = dtpJoined.Value;
                    employeeBorrowItem.Emp_Id = Convert.ToInt32(cmbEmployees.SelectedValue);
                    employeeBorrowItem.Item_Id = _product.Id;
                    employeeBorrowItem.Time = dtpJoined.Value.ToString("HH:mm");
                    employeeBorrowItem.ProductName = _product.ProductName;
                    _context.Add(employeeBorrowItem);
                    _context.SaveChanges();

                    EmployeeSalaryMinus employeeSalaryMinus = new EmployeeSalaryMinus();
                    employeeSalaryMinus.Pay = "No";
                    employeeSalaryMinus.Date = dtpJoined.Value;
                    employeeSalaryMinus.Emp_ID = Convert.ToInt32(cmbEmployees.SelectedValue);
                    employeeSalaryMinus.EmployeeName = cmbEmployees.Text;
                    employeeSalaryMinus.Time = dtpJoined.Value.ToString("HH:mm");
                    employeeSalaryMinus.Price = _main.ConvertToFloat(txtQty.Text) * _product.SalePriceTax;
                    _context.Add(employeeSalaryMinus);
                    _context.SaveChanges();
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
