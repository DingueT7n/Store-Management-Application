using Store.ApplicationUI.Code.Helper;
using Store.ApplicationUI.Gui.LoadingGui;
using Store.Core.Entities.Products;

namespace Store.ApplicationUI.Gui.ProductsGui
{
    public partial class AddProductForm : Form
    {
        private readonly MainForm _main;
        private List<Category> _data;

        public AddProductForm(MainForm main)
        {
            InitializeComponent();
            _main = main;
            this.Owner = _main;

            LoadData();
            ConfigDate();

        }

        private void ConfigDate()
        {
            DtpExperation.Value = DateTime.Now;

            DtpExperation.CustomFormat = DtpExperation.CustomFormat = "yyyy-MM-dd";
        }
        public async void LoadData()
        {


            //ShowLoading
            LoadingForm.Instance(_main).Show();
            if (await Task.Run(() => ProductsUserControl.categoryRepository.IsConnected()))
            {
                //Start Load Data

                // if its an admin or Normal user 

                CMBCategory.DataSource = MainForm.Context.Categories.ToList();



                CMBCategory.DisplayMember = "CategoryName"; // Set the property to display
                CMBCategory.ValueMember = "Id"; // Set the property to use as the value

                // Optionally select the first item if needed



                if (CMBCategory.Items.Count > 0)
                {
                    CMBCategory.SelectedIndex = 0;  // Select the first item
                }

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
            txtBarCode.Text = "";
            txtNameProduct.Text = "";
            txtBuyPrice.Text = "0";
            txtDiscountAllowed.Text = "0";
            txtMinQty.Text = "";
            txtSaleAfterTax.Text = "0";
            txtSalePrice.Text = "0";
            txtTaxValue.Text = "0";
            txtTotalQty.Text = "0";
            txtWholeSalePrice.Text = "0";
        }

        private void txtBarCode_KeyPress(object sender, KeyPressEventArgs e)
        {
            if (!char.IsDigit(e.KeyChar) && e.KeyChar != Properties.Settings.Default.DecimalSEP[0] && e.KeyChar != 8)
            {
                e.Handled = true;
            }
        }

        private void txtMinQty_KeyPress(object sender, KeyPressEventArgs e)
        {
            if (!char.IsDigit(e.KeyChar) && e.KeyChar != Properties.Settings.Default.DecimalSEP[0] && e.KeyChar != 8)
            {
                e.Handled = true;
            }
        }

        private void txtTaxValue_KeyPress(object sender, KeyPressEventArgs e)
        {
            if (!char.IsDigit(e.KeyChar) && e.KeyChar != Properties.Settings.Default.DecimalSEP[0] && e.KeyChar != 8)
            {
                e.Handled = true;
            }
        }

        private void txtBuyPrice_KeyPress(object sender, KeyPressEventArgs e)
        {
            if (!char.IsDigit(e.KeyChar) && e.KeyChar != Properties.Settings.Default.DecimalSEP[0] && e.KeyChar != 8)
            {
                e.Handled = true;
            }
        }

        private void txtTotalQty_KeyPress(object sender, KeyPressEventArgs e)
        {
            if (!char.IsDigit(e.KeyChar) && e.KeyChar != Properties.Settings.Default.DecimalSEP[0] && e.KeyChar != 8)
            {
                e.Handled = true;
            }
        }

        private void txtWholeSalePrice_KeyPress(object sender, KeyPressEventArgs e)
        {
            if (!char.IsDigit(e.KeyChar) && e.KeyChar != Properties.Settings.Default.DecimalSEP[0] && e.KeyChar != 8)
            {
                e.Handled = true;
            }
        }

        private void txtSalePrice_KeyPress(object sender, KeyPressEventArgs e)
        {
            if (!char.IsDigit(e.KeyChar) && e.KeyChar != Properties.Settings.Default.DecimalSEP[0] && e.KeyChar != 8)
            {
                e.Handled = true;
            }
        }

        private void txtDiscountAllowed_KeyPress(object sender, KeyPressEventArgs e)
        {
            if (!char.IsDigit(e.KeyChar) && e.KeyChar != Properties.Settings.Default.DecimalSEP[0] && e.KeyChar != 8)
            {
                e.Handled = true;
            }
        }

        private void txtSaleAfterTax_KeyPress(object sender, KeyPressEventArgs e)
        {
            if (!char.IsDigit(e.KeyChar) && e.KeyChar != Properties.Settings.Default.DecimalSEP[0] && e.KeyChar != 8)
            {
                e.Handled = true;
            }
        }

        public void SetDataToEdit(string NameProduct, string BarCode, string categoryId, string MinQty
            , bool IsTaxed, string TaxValue, string BuyPrice, string Quentity, string WholesalePrice
            , string SalePrice, DateTime DateExpiration, string MaxDiscount, string SaleAfterTax, string productId)
        {
            txtNameProduct.Text = NameProduct;
            txtBarCode.Text = BarCode;
            CMBCategory.SelectedValue = categoryId;
            txtMinQty.Text = MinQty;
            CbIsTaxed.Checked = IsTaxed;
            txtTaxValue.Text = TaxValue;
            txtBuyPrice.Text = BuyPrice;
            txtTotalQty.Text = Quentity;
            txtWholeSalePrice.Text = WholesalePrice;
            txtSalePrice.Text = SalePrice;
            txtDiscountAllowed.Text = MaxDiscount;
            txtSaleAfterTax.Text = SaleAfterTax;
            DtpExperation.Value = DateExpiration;
            txtDiscountAllowed.Text = MaxDiscount;
            txtSaleAfterTax.Text = SaleAfterTax;
            lblProductId.Text = productId;
            btnAddProduct.Visible = false;
            btnEditProduct.Visible = true;
        }
        private void btnAddProduct_Click(object sender, EventArgs e)
        {

            Product product = new Product();
            product.ProductName = txtNameProduct.Text;
            product.CodeBar = txtBarCode.Text;
            product.CategoryId = Convert.ToInt32(CMBCategory.SelectedValue);
            product.MinQty = ConvertToFloat(txtMinQty.Text);
            product.IsTaxed = CbIsTaxed.Checked;
            product.TaxValue = ConvertToFloat(txtTaxValue.Text);
            product.BuyPrice = ConvertToFloat(txtBuyPrice.Text);
            product.Quentity = ConvertToFloat(txtTotalQty.Text);
            product.WholesalePrice = ConvertToFloat(txtWholeSalePrice.Text);
            product.SalePrice = ConvertToFloat(txtSalePrice.Text);
            product.MaxDiscount = ConvertToFloat(txtDiscountAllowed.Text);
            product.SalePriceTax = ConvertToFloat(txtSaleAfterTax.Text);
            product.DateExperation = DtpExperation.Value;
            //if (CMBCategory.SelectedValue != null && int.TryParse(CMBCategory.SelectedValue.ToString(), out int categoryId))
            //{
            //    product.CategoryId = categoryId;
            //}
            var result = ProductsUserControl.productsRepository.AddAsync(product);
            vider();
            ProductsUserControl.RefreshDgv();

        }

        float ConvertToFloat(string value)
        {
            float quantity;
            if (float.TryParse(value, out quantity))
            {
                return quantity;
            }
            return quantity;
        }

        private void btnEditProduct_Click(object sender, EventArgs e)
        {

            Product product = ProductsUserControl.productsRepository.Find(lblProductId.Text);
            product.ProductName = txtNameProduct.Text;
            product.CodeBar = txtBarCode.Text;
            product.CategoryId = Convert.ToInt32(CMBCategory.SelectedValue);
            product.MinQty = ConvertToFloat(txtMinQty.Text);
            product.IsTaxed = CbIsTaxed.Checked;
            product.TaxValue = ConvertToFloat(txtTaxValue.Text);
            product.BuyPrice = ConvertToFloat(txtBuyPrice.Text);
            product.Quentity = ConvertToFloat(txtTotalQty.Text);
            product.WholesalePrice = ConvertToFloat(txtWholeSalePrice.Text);
            product.SalePrice = ConvertToFloat(txtSalePrice.Text);
            product.MaxDiscount = ConvertToFloat(txtDiscountAllowed.Text);
            product.SalePriceTax = ConvertToFloat(txtSaleAfterTax.Text);
            product.DateExperation = DtpExperation.Value;
            var result = ProductsUserControl.productsRepository.UpdateAsync(lblProductId.Text, product);
            ProductsUserControl.RefreshDgv();
            product = null;
        }
    }
}
