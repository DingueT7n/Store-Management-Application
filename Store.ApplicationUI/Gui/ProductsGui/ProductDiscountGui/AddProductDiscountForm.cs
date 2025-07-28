
using Microsoft.EntityFrameworkCore;
using Microsoft.IdentityModel.Tokens;
using Store.ApplicationUI.Code.Helper;
using Store.ApplicationUI.Code.System;
using Store.ApplicationUI.Gui.LoadingGui;
using Store.Core.Entities.Products;
using Store.Core.Interfaces;
using Store.Infrastructure.Data;

namespace Store.ApplicationUI.Gui.ProductsGui.ProductDiscountGui
{
    public partial class AddProductDiscountForm : Form
    {



        private Product _product;
        private readonly MainForm _main;
        private readonly IProductRepository _productRepository;
        private readonly ControlManager _controlManager;
        private readonly ApplicationDbContext _context;

        public AddProductDiscountForm(MainForm main, IProductRepository productRepository, ControlManager controlManager, ApplicationDbContext context)
        {
            InitializeComponent();

            dtpFrom.Value = DateTime.Now;
            dtpTo.Value = DateTime.Now.AddDays(10);
            _main = main;
            _productRepository = productRepository;
            _controlManager = controlManager;
            _context = context;

        }

        public async Task LoadData()
        {


            //ShowLoading


            LoadingForm.Instance(_main).Show();
            if (/*await Task.Run(() =>*/await _context.Database.CanConnectAsync())/*)*/
            {
                //Start Load Data

                // if its an admin or Normal user 
                ResetForm();

                cmbStoresFrom.DataSource = await _context.Stores.ToListAsync();
                cmbStoresFrom.DisplayMember = "StoreName"; // Set the property to display
                cmbStoresFrom.ValueMember = "Id"; // Set the property to use as the value


                // Optionally select the first item if needed
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

        private void txtBareCode_KeyPress(object sender, KeyPressEventArgs e)
        {
            if (!char.IsDigit(e.KeyChar) && e.KeyChar != Properties.Settings.Default.DecimalSEP[0] && e.KeyChar != 8)
            {
                e.Handled = true;
            }
        }

        private void txtTotalQty_KeyPress(object sender, KeyPressEventArgs e)
        {
            if (txtTotalQty.Text.IsNullOrEmpty()) { return; }

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


        private void txtBareCode_KeyDown(object sender, KeyEventArgs e)
        {
            if (e.KeyCode == Keys.Enter)
            {
                SetProductsToTable();
            }
        }
        public void SetProductsToTable()
        {
            //DgvProducts.DataSource = await Task.Run(() => productsRepository.GetAll(p => p.Category));
            _product = _productRepository.GetProductBarCode(txtBareCode.Text);
            if (_product is not null)
            {
                txtProductName.Text = _product.ProductName;
                txtTotalQty.Text = _product.Quentity.ToString();
                txtSalePrice.Text = _product.SalePriceTax.ToString();
            }
            else
            {
                MsgHelper.ShowEmptyResult();
                txtBareCode.Focus();
            }
            txtBareCode.Clear();
        }

        private void cmbStoresFrom_SelectionChangeCommitted(object sender, EventArgs e)
        {
            if (_product is not null)
            {
                string selectedStoreName = cmbStoresFrom.SelectedValue?.ToString(); // safer
                if (!string.IsNullOrWhiteSpace(selectedStoreName))
                {
                    var productQty = _context.ProductsQuantities
                        .Where(x => x.Store_ID.ToString() == selectedStoreName && x.Pro_ID == _product.Id)
                        .Sum(x => x.Qty);

                    txtQtyInFrom.Text = productQty.ToString();
                }
            }
        }

        private async void btnTransfert_Click(object sender, EventArgs e)
        {
            try
            {
                if (_product is not null)
                {
                    ProductDiscount productDiscount = new ProductDiscount();
                    productDiscount.Pro_Id = _product.Id;
                    productDiscount.Store_Id = Convert.ToInt32(cmbStoresFrom.SelectedValue);
                    productDiscount.Quentity = Convert.ToDecimal(txtQtyTransfert.Text);
                    productDiscount.DateStart = dtpFrom.Value;
                    productDiscount.TimeStart = DateTime.Now.ToString("HH:mm");
                    productDiscount.DateEnd = dtpTo.Value;
                    productDiscount.TimeEnd = DateTime.Now.ToString("HH:mm");
                    productDiscount.DiscountValue = Convert.ToDecimal(txtDiscountValue.Text);
                    await _context.AddAsync(productDiscount);
                    await _context.SaveChangesAsync();
                    Code.Helper.ToasterHelper.ShowProductDiscountAdded();

                    ResetForm();

                    if (_controlManager.TryGet<ProductDiscountUserControl>(out var UC))
                    {
                        UC.LoadData();
                    }

                }
            }
            catch (Exception)
            {

                throw;
            }
        }
        private void ResetForm()
        {
            _product = null;
            txtDiscountValue.Text = 0.ToString();
            txtQtyTransfert.Text = 0.ToString();
            txtBareCode.Clear();
            txtProductName.Clear();
            txtQtyInFrom.Text = 0.ToString();
            txtTotalQty.Text = 0.ToString();
            txtSalePrice.Text = 0.ToString();
            // Clear all textboxes
            foreach (Control ctrl in this.Controls)
            {
                if (ctrl is TextBox)
                {
                    ((TextBox)ctrl).Clear();
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


            // Optionally reset focus to the first control
            // Set focus to the first control
        }
        private void xtTotalQty_KeyPress(object sender, KeyPressEventArgs e)
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
    }
}
