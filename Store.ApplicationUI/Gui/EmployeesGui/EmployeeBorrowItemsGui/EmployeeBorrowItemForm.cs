using Microsoft.EntityFrameworkCore;
using Store.ApplicationUI.Code.Helper;
using Store.ApplicationUI.Gui.LoadingGui;
using Store.Core.Entities.Employees;
using Store.Core.Entities.Products;
using Store.Core.Interfaces;
using Store.Infrastructure.Data;

namespace Store.ApplicationUI.Gui.EmployeesGui.EmployeeBorrowItemsGui
{
    public partial class EmployeeBorrowItemForm : Form
    {
        private readonly MainForm _main;
        private readonly IEmployeeBorrowItemRepository _employeeBorrowItemRepository;
        private readonly ApplicationDbContext _context;
        private readonly IProductRepository _productRepository;

        private Product _product;

        public EmployeeBorrowItemForm(MainForm main, IEmployeeBorrowItemRepository employeeBorrowItemRepository, ApplicationDbContext context
            , IProductRepository productRepository)
        {
            InitializeComponent();
            _main = main;
            _employeeBorrowItemRepository = employeeBorrowItemRepository;
            _context = context;
            _productRepository = productRepository;
            this.Owner = _main;

        }

        public async Task LoadData()
        {
            dgvHelper.ResetForm(this);

            dtpJoined.Value = DateTime.Now;

            //ShowLoading
            LoadingForm.Instance(_main).Show();
            if (await _employeeBorrowItemRepository.IsConnectedAsync())
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




            // Optionally reset focus to the first control
            // Set focus to the first control
        }

        private void txtBareCode_KeyPress(object sender, KeyPressEventArgs e)
        {
            //string currentText = (sender as TextBox)?.Text ?? string.Empty;


            //char decimalSeparator = Properties.Settings.Default.DecimalSEP[0];


            //if (!char.IsDigit(e.KeyChar) && e.KeyChar != decimalSeparator && e.KeyChar != (char)8)
            //{
            //    e.Handled = true;
            //}

            //else if (e.KeyChar == decimalSeparator && currentText.Contains(decimalSeparator))
            //{
            //    e.Handled = true;
            //}
        }
        public async void SetProductsToTable()
        {
            //DgvProducts.DataSource = await Task.Run(() => productsRepository.GetAll(p => p.Category));
            _product = _productRepository.GetProductBarCode(txtBareCode.Text);
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

        private async void btnAdd_Click(object sender, EventArgs e)
        {
            ToasterHelper.PlayNotificationSound();
            if (_product is null) return;
            if (txtQty.Text == string.Empty) return;
            using (var transaction = await _context.Database.BeginTransactionAsync())
            {
                try
                {
                    _product.Quentity -= _main.ConvertToFloat(txtQty.Text);
                    _context.Update(_product);
                    await _context.SaveChangesAsync();

                    EmployeeBorrowItem employeeBorrowItem = new EmployeeBorrowItem();
                    employeeBorrowItem.Quentity = _main.ConvertToFloat(txtQty.Text);
                    employeeBorrowItem.Date = dtpJoined.Value;
                    employeeBorrowItem.Emp_Id = Convert.ToInt32(cmbEmployees.SelectedValue);
                    employeeBorrowItem.Item_Id = _product.Id;
                    employeeBorrowItem.Time = dtpJoined.Value.ToString("HH:mm");
                    employeeBorrowItem.ProductName = _product.ProductName;

                    await _employeeBorrowItemRepository.AddAsync(employeeBorrowItem);

                    EmployeeSalaryMinus employeeSalaryMinus = new EmployeeSalaryMinus();
                    employeeSalaryMinus.Pay = "No";
                    employeeSalaryMinus.Date = dtpJoined.Value;
                    employeeSalaryMinus.Emp_ID = Convert.ToInt32(cmbEmployees.SelectedValue);
                    employeeSalaryMinus.EmployeeName = cmbEmployees.Text;
                    employeeSalaryMinus.Time = dtpJoined.Value.ToString("HH:mm");
                    employeeSalaryMinus.Price = _main.ConvertToFloat(txtQty.Text) * _product.SalePriceTax;
                    await _context.AddAsync(employeeSalaryMinus);
                    await _context.SaveChangesAsync();
                    await transaction.CommitAsync();
                    Code.Helper.ToasterHelper.ShowBorrowItem();

                    await LoadData();
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
