using Microsoft.IdentityModel.Tokens;
using Store.ApplicationUI.Code.Helper;
using Store.ApplicationUI.Gui.LoadingGui;
using Store.Core.Entities.Products;
using Store.Infrastructure.Data;
using Store.Infrastructure.Repositories;

namespace Store.ApplicationUI.Gui.ProductsGui.ProductDiscountGui
{
    public partial class AddProductDiscountForm : Form
    {
        private static MainForm _main;
        private ApplicationDbContext _context;
        private ProductsRepository? productsRepository;

        private static AddProductDiscountForm _Form;

        public AddProductDiscountForm(MainForm main)
        {
            InitializeComponent();
            _main = main;
            this.Owner = _main;
            _context = new ApplicationDbContext();
            productsRepository = new ProductsRepository(_context);

            LoadData();
            dtpFrom.Value = DateTime.Now;
            dtpTo.Value = DateTime.Now.AddDays(10);
        }
        public static AddProductDiscountForm Instance(MainForm main)
        {
            _main = main;
            // If the instance is null, create a new one and assign it to the static field


            _Form = new AddProductDiscountForm(_main);



            // Return the singleton instance

            return _Form;
        }
        public void LoadData()
        {


            //ShowLoading


            LoadingForm.Instance(_main).Show();
            if (/*await Task.Run(() =>*/ _context.Database.CanConnect())/*)*/
            {
                //Start Load Data

                // if its an admin or Normal user 

                cmbStoresFrom.DataSource = _context.Stores.ToList();
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
        private Product _product;

        private void txtBareCode_KeyDown(object sender, KeyEventArgs e)
        {
            if (e.KeyCode == Keys.Enter)
            {
                SetProductsToTable();
            }
        }
        public async void SetProductsToTable()
        {
            //DgvProducts.DataSource = await Task.Run(() => productsRepository.GetAll(p => p.Category));
            _product = productsRepository.GetProductBarCode(txtBareCode.Text);
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
                var productQty = _context.ProductsQuantities.Where(x => x.StoreName == cmbStoresFrom.SelectedText.ToString()
                && x.Pro_ID == _product.Id).Sum(x => x.Qty);
                txtQtyInFrom.Text = productQty.ToString();
            }
        }

        private void btnTransfert_Click(object sender, EventArgs e)
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
                    _context.Add(productDiscount);
                    _context.SaveChanges();
                    Code.Helper.ToasterHelper.ShowProductDiscountAdded();

                    ResetForm();
                    if (!ProductDiscountUserControl.CheckInstance())
                        ProductDiscountUserControl.RefreshInstance();


                }
            }
            catch (Exception)
            {

                throw;
            }
        }
        private void ResetForm()
        {
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

            _product = null;
            txtDiscountValue.Text = 0.ToString();
            txtQtyTransfert.Text = 0.ToString();
            txtBareCode.Clear();
            txtQtyInFrom.Text = 0.ToString();
            txtTotalQty.Text = 0.ToString();
            txtSalePrice.Text = 0.ToString();
            // Reinitialize form data (e.g., reload initial data)
            LoadData(); // This is a method where you load initial data

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
