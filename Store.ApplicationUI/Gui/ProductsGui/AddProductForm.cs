using System.IO;
using Microsoft.EntityFrameworkCore;
using Microsoft.IdentityModel.Tokens;
using Store.ApplicationUI.Code.Helper;
using Store.ApplicationUI.Gui.LoadingGui;
using Store.ApplicationUI.Gui.ProductsGui.Category;
using Store.Core.Entities.Products;
using Store.Infrastructure.Data;
using Store.Infrastructure.Repositories;

namespace Store.ApplicationUI.Gui.ProductsGui
{
    public partial class AddProductForm : Form
    {
        private static MainForm? _main;
        private ApplicationDbContext _context;
        private ProductsRepository? productsRepository;
        private static AddProductForm? _addProductForm;
        private CategorysRepository? categoryRepository;
        public AddProductForm(MainForm main)
        {
            InitializeComponent();
            _main = main;
            this.Owner = _main;
            _context = new ApplicationDbContext();

            productsRepository = new ProductsRepository(_context);
            categoryRepository = new CategorysRepository(_context);
            LoadData();
            ConfigDate();
        }
        public static bool CheckInstance()
        {
            return (_addProductForm == null);
        }
        public static void LoadCategory()
        {
            var s = _addProductForm.CMBCategory.SelectedValue;
            _addProductForm.LoadData();
            _addProductForm.CMBCategory.SelectedValue = s;
        }

        public static AddProductForm Instance(MainForm main)
        {
            if (_addProductForm == null || _addProductForm.IsDisposed)
            {
                _addProductForm = new AddProductForm(main);
            }
            else
            {
                // Bring the form to the front if it exists.
                if (!_addProductForm.Visible)
                {
                    _addProductForm.Show();
                }
                _addProductForm.BringToFront();
            }

            return _addProductForm;
            _main = main;
            // If the instance is null, create a new one and assign it to the static field


            _addProductForm = new AddProductForm(_main);



            // Return the singleton instance

            return _addProductForm;
        }
        private void ConfigDate()
        {
            DtpExperation.Value = DateTime.Now;

            DtpExperation.CustomFormat = DtpExperation.CustomFormat = "yyyy-MM-dd";
        }
        public void LoadData()
        {


            //ShowLoading


            LoadingForm.Instance(_main).Show();
            if (/*await Task.Run(() =>*/ _context.Database.CanConnect())/*)*/
            {
                //Start Load Data

                // if its an admin or Normal user 

                CMBCategory.DataSource = _context.Categories.ToList();



                CMBCategory.DisplayMember = "CategoryName"; // Set the property to display
                CMBCategory.ValueMember = "Id"; // Set the property to use as the value
                CMBCategory.Text = "اختر صنف";

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
            , string SalePrice, DateTime DateExpiration, string MaxDiscount, string SaleAfterTax, string productId, byte[] image
            , string catName)
        {
            LoadData();
            txtNameProduct.Text = NameProduct;
            txtBarCode.Text = BarCode;
            CMBCategory.SelectedValue = Convert.ToInt32(categoryId);
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
            if (image is not null)
            {
                SetImage(image);
            }
            btnAddProduct.Visible = false;
            btnEditProduct.Visible = true;
            lblProductId.Visible = true;
            label13.Visible = true;
        }
        private void btnAddProduct_Click(object sender, EventArgs e)
        {
            if (CMBCategory.Text != "اختر صنف")
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
                product.ProductImage = RetriveImage();
                //if (CMBCategory.SelectedValue != null && int.TryParse(CMBCategory.SelectedValue.ToString(), out int categoryId))
                //{
                //    product.CategoryId = categoryId;
                //}
                var result = _context.Add(product);

                if (!ProductsUserControl.CheckInstance())
                {
                    ProductsUserControl.RefreshDgv();
                }
                _context.SaveChanges();
                ProductQuickAccess qucik = new ProductQuickAccess
                {
                    Pro_Id = product.Id,
                    CodeBar = txtBarCode.Text,
                    ProductImage = RetriveImage(),
                    ProductName = txtNameProduct.Text,
                };
                vider();
                _context.Add(qucik);
                _context.SaveChanges();

            }
            else
                MsgHelper.ShowRequiredFields();
        }

        decimal ConvertToFloat(string value)
        {
            //float quantity;
            //if (float.TryParse(value, out quantity))
            //{
            //    return quantity;
            //}
            return Convert.ToDecimal(value);
        }

        private void btnEditProduct_Click(object sender, EventArgs e)
        {
            Product product = productsRepository.Find(lblProductId.Text);
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
            product.ProductImage = RetriveImage();
            var result = productsRepository.UpdateAsync(lblProductId.Text, product);

            if (!ProductsUserControl.CheckInstance())
            {
                ProductsUserControl.RefreshDgv();
            }
            product = null;

        }


        private void btnAddCategory_Click(object sender, EventArgs e)
        {

            AddCategoryForm addCategoryForm = AddCategoryForm.Instance(_main);
            this.Hide();
            addCategoryForm.ShowDialog();
            this.Show();


        }

        public byte[] RetriveImage()
        {
            try
            {
                MemoryStream ms = new MemoryStream();
                PbImageProduct.Image.Save(ms, PbImageProduct.Image.RawFormat);
                byte[] byteImage = ms.ToArray();
                return byteImage;
            }
            catch (Exception)
            {

                throw;
            }

        }
        public void SetImage(byte[] retrivedData)
        {
            try
            {
                byte[] Picture = retrivedData;
                MemoryStream ms = new MemoryStream(Picture);
                PbImageProduct.Image = Image.FromStream(ms);
            }
            catch (Exception)
            {

                throw;
            }
        }
        private void PbImageProduct_Click(object sender, EventArgs e)
        {
            using (OpenFileDialog openFileDialog = new OpenFileDialog())
            {
                openFileDialog.Filter = "ملفات الصور |*.JPG; *.PNG; *.GIF; *.BMP";
                if (openFileDialog.ShowDialog() == DialogResult.OK)
                {
                    PbImageProduct.Image = Image.FromFile(openFileDialog.FileName);
                }
            }
        }
        private void btnPrintBarCode_Click(object sender, EventArgs e)
        {
            if (txtBarCode.Text.IsNullOrEmpty())
            {
                var bc = _context.RandomBarcode
                    .AsNoTracking()
                    .OrderBy(x => x.Barcode) // Ensure correct ordering
                    .LastOrDefault();
                if (bc != null)
                {
                    txtBarCode.Text = (bc.Barcode + 1).ToString(); // Assuming Barcode is a string
                    string sql = $"INSERT INTO RandomBarcode (Barcode) VALUES ('{txtBarCode.Text}')";
                    _context.Database.ExecuteSqlRaw(sql);
                }
                else
                {
                    txtBarCode.Text = "10000000";
                    string sql = "INSERT INTO RandomBarcode (Barcode) VALUES ('10000000')";
                    _context.Database.ExecuteSqlRaw(sql);
                }
            }
            BarcodeGui.BarCodeForm barCodeForm = new BarcodeGui.BarCodeForm();
            barCodeForm.txtBarCode.Text = txtBarCode.Text;
            barCodeForm.txtPrice.Text = txtSaleAfterTax.Text;
            barCodeForm.txtProductName.Text = txtNameProduct.Text;
            barCodeForm.lblBarecode.Text = txtBarCode.Text;
            this.Hide();
            barCodeForm.ShowDialog();
            this.Show();
        }

    }
}