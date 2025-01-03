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
                if (!_addProductForm.Visible)
                {
                    _addProductForm.Show();
                }
                _addProductForm.BringToFront();
            }

            return _addProductForm;

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
            txtBuyPrice.Text = "0.00";
            txtDiscountAllowed.Text = "0.00";
            txtMinQty.Text = "0.00";
            txtSaleAfterTax.Text = "0.00";
            txtSalePrice.Text = "0.00";
            txtTaxValue.Text = "0.00";
            txtTotalQty.Text = "0.00";
            txtWholeSalePrice.Text = "0.00";
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

        private void txtTaxValue_KeyPress(object sender, KeyPressEventArgs e)
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

        private void txtBuyPrice_KeyPress(object sender, KeyPressEventArgs e)
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

        private void txtTotalQty_KeyPress(object sender, KeyPressEventArgs e)
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

        private void txtWholeSalePrice_KeyPress(object sender, KeyPressEventArgs e)
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

        private void txtSalePrice_KeyPress(object sender, KeyPressEventArgs e)
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

        private void txtDiscountAllowed_KeyPress(object sender, KeyPressEventArgs e)
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

        private void txtSaleAfterTax_KeyPress(object sender, KeyPressEventArgs e)
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

        public void SetDataToEdit(string NameProduct, string BarCode, string categoryId, string MinQty
            , bool IsTaxed, string TaxValue, string BuyPrice, string Quentity, string WholesalePrice
            , string SalePrice, DateTime DateExpiration, string MaxDiscount, string SaleAfterTax, string productId, byte[] image
            , string catName, string SalePrice2, string NbrProductInColis, string ColisageBareCode)
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
            txtSalePrice2.Text = SalePrice2;
            txtColisageBareCode.Text = ColisageBareCode;
            txtNbrIncolis.Text = NbrProductInColis;
            Fill_familyBareCode(productId);
            btnAddProduct.Visible = false;
            btnEditProduct.Visible = true;
            lblProductId.Visible = true;
            label13.Visible = true;
            txtNameProduct.Focus();
            txtNameProduct_TextChanged(null, null);
            //txtBarCode.ForeColor = Color.Red;

            cbFavorite.Checked = _context.ProductQuickAccess.FirstOrDefault(x => x.Pro_Id.ToString() == productId) == null ? false : true;

            var textBoxes = new[] { txtBarCode, textBox1, textBox2, textBox3, textBox4, textBox5, textBox6, textBox7, textBox8, textBox9, textBox10 };
            for (int i = 0; i < textBoxes.Length; i++)
            {
                if (!MsgHelper.ShowBareCodeDuplicatedWithoutMessagesForEdit(_context, textBoxes[i].Text, lblProductId.Text))
                {
                    textBoxes[i].ForeColor = Color.Red;
                }
                else
                {
                    textBoxes[i].ForeColor = Color.Black;
                }


            }



        }
        public void SetSimilaireDataToAdd(string NameProduct, string BarCode, string categoryId, string MinQty
           , bool IsTaxed, string TaxValue, string BuyPrice, string Quentity, string WholesalePrice
           , string SalePrice, DateTime DateExpiration, string MaxDiscount, string SaleAfterTax, string productId, byte[] image
           , string catName, string SalePrice2, string NbrProductInColis, string ColisageBareCode)
        {
            LoadData();
            txtNameProduct.Text = NameProduct;

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
            btnAddProduct.Visible = true;
            lblProductId.Visible = false;
            label13.Visible = false;
            txtBarCode.Focus();

            txtSalePrice2.Text = SalePrice2;
            txtColisageBareCode.Text = "";
            txtNbrIncolis.Text = NbrProductInColis;

            cbFavorite.Checked = _context.ProductQuickAccess.FirstOrDefault(x => x.Pro_Id.ToString() == productId) == null ? false : true;

        }
        void Fill_familyBareCode(string id)
        {
            var listFamily = _context.ProductFamilies
                       .Where(x => x.Pro_Id.ToString() == id)
                       .Select(x => x.CodeBar)
                       .ToList();

            var textBoxes = new[] { textBox1, textBox2, textBox3, textBox4, textBox5, textBox6, textBox7, textBox8, textBox9, textBox10 };
            checkBox1.Checked = listFamily.Count > 0;
            for (int i = 0; i < listFamily.Count && i < textBoxes.Length; i++)
            {
                textBoxes[i].Text = listFamily[i].ToString();
                textBoxes[i].Enabled = !string.IsNullOrEmpty(listFamily[i].ToString());
            }
        }
        bool ValidateUniqueProductBareCode()
        {
            var textBoxes = new[] { txtBarCode, textBox1, textBox2, textBox3, textBox4, textBox5, textBox6, textBox7, textBox8, textBox9, textBox10 };
            for (int i = 0; i < textBoxes.Length; i++)
            {
                if (textBoxes[i].Text != string.Empty)
                    if (textBoxes[i].ForeColor == Color.Red) return false;

            }
            return true;
        }
        private void btnAddProduct_Click(object sender, EventArgs e)
        {
            try
            {
                ToasterHelper.PlayNotificationSound();
                if (!ValidateUniqueProductBareCode()) { MsgHelper.BareCodeMesssageDuplicated(); return; }
                if (CMBCategory.Text != "اختر صنف"
                    && !string.IsNullOrEmpty(txtBuyPrice.Text)
                    && !string.IsNullOrEmpty(txtNameProduct.Text)
                    && !string.IsNullOrEmpty(txtSalePrice.Text)
                    && !string.IsNullOrEmpty(txtSaleAfterTax.Text)
                    && !string.IsNullOrEmpty(txtTotalQty.Text)
                    && !string.IsNullOrEmpty(txtWholeSalePrice.Text)
                    && !string.IsNullOrEmpty(txtDiscountAllowed.Text)
                    && !string.IsNullOrEmpty(txtBarCode.Text)
                    )
                {

                    var ResultProductName = _context.Products.FirstOrDefault(x => x.ProductName == txtNameProduct.Text);


                    if (ResultProductName is null)
                    {

                        Product product = new Product();
                        product.ProductName = txtNameProduct.Text;
                        product.CodeBar = txtBarCode.Text;
                        product.CategoryId = Convert.ToInt32(CMBCategory.SelectedValue);
                        product.MinQty = ConvertToFloat(txtMinQty.Text);
                        product.IsTaxed = CbIsTaxed.Checked;
                        product.TaxValue = CbIsTaxed.Checked ? ConvertToFloat(txtTaxValue.Text) : 0;
                        product.BuyPrice = ConvertToFloat(txtBuyPrice.Text);
                        product.Quentity = ConvertToFloat(txtTotalQty.Text);
                        product.WholesalePrice = ConvertToFloat(txtWholeSalePrice.Text);
                        product.SalePrice = ConvertToFloat(txtSalePrice.Text);
                        product.MaxDiscount = ConvertToFloat(txtDiscountAllowed.Text);
                        product.SalePriceTax = ConvertToFloat(txtSaleAfterTax.Text);
                        product.SalePriceSeconde = ConvertToFloat(txtSalePrice2.Text);
                        product.ColisageBareCode = txtColisageBareCode.Text;
                        product.NbrProductInColis = ConvertToFloat(txtNbrIncolis.Text);
                        product.DateExperation = DtpExperation.Value;
                        product.ProductImage = RetriveImage();
                        var result = _context.Add(product);
                        _context.SaveChanges();
                        if (checkBox1.Checked)
                        {
                            var textBoxes = new[]
                            {
                                    textBox1, textBox2, textBox3, textBox4, textBox5,
                                    textBox6, textBox7, textBox8, textBox9, textBox10
                                };

                            foreach (var textBox in textBoxes)
                            {
                                if (!string.IsNullOrEmpty(textBox.Text))
                                {
                                    var family = new ProductFamily
                                    {
                                        Pro_Id = product.Id,
                                        CodeBar = textBox.Text
                                    };
                                    _context.ProductFamilies.Add(family);
                                }
                            }

                            // Save all changes at once
                            _context.SaveChanges();

                        }


                        if (!ProductsUserControl.CheckInstance())
                        {
                            ProductsUserControl.RefreshDgv();
                        }
                        _context.SaveChanges();
                        if (cbFavorite.Checked)
                        {
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
                        Code.Helper.ToasterHelper.ShowAddToast();

                    }
                    else
                    {
                        if (MsgHelper.ShowProductNameIsSame())
                        {
                            Product product = new Product();
                            product.ProductName = txtNameProduct.Text;
                            product.CodeBar = txtBarCode.Text;
                            product.CategoryId = Convert.ToInt32(CMBCategory.SelectedValue);
                            product.MinQty = ConvertToFloat(txtMinQty.Text);
                            product.IsTaxed = CbIsTaxed.Checked;
                            product.TaxValue = CbIsTaxed.Checked ? ConvertToFloat(txtTaxValue.Text) : 0;
                            product.BuyPrice = ConvertToFloat(txtBuyPrice.Text);
                            product.Quentity = ConvertToFloat(txtTotalQty.Text);
                            product.WholesalePrice = ConvertToFloat(txtWholeSalePrice.Text);
                            product.SalePrice = ConvertToFloat(txtSalePrice.Text);
                            product.MaxDiscount = ConvertToFloat(txtDiscountAllowed.Text);
                            product.SalePriceTax = ConvertToFloat(txtSaleAfterTax.Text);
                            product.SalePriceSeconde = ConvertToFloat(txtSalePrice2.Text);
                            product.ColisageBareCode = txtColisageBareCode.Text;
                            product.NbrProductInColis = ConvertToFloat(txtNbrIncolis.Text);
                            product.DateExperation = DtpExperation.Value;
                            product.ProductImage = RetriveImage();
                            var result = _context.Add(product);
                            _context.SaveChanges();
                            //if (CMBCategory.SelectedValue != null && int.TryParse(CMBCategory.SelectedValue.ToString(), out int categoryId))
                            //{
                            //    product.CategoryId = categoryId;
                            //}


                            if (checkBox1.Checked)
                            {
                                var textBoxes = new[]
                                {
                                    textBox1, textBox2, textBox3, textBox4, textBox5,
                                    textBox6, textBox7, textBox8, textBox9, textBox10
                                };

                                foreach (var textBox in textBoxes)
                                {
                                    if (!string.IsNullOrEmpty(textBox.Text))
                                    {
                                        var family = new ProductFamily
                                        {
                                            Pro_Id = product.Id,
                                            CodeBar = textBox.Text
                                        };
                                        _context.ProductFamilies.Add(family);
                                    }
                                }

                                // Save all changes at once
                                _context.SaveChanges();
                            }

                            if (!ProductsUserControl.CheckInstance())
                            {
                                ProductsUserControl.RefreshDgv();
                            }
                            _context.SaveChanges();
                            if (cbFavorite.Checked)
                            {
                                ProductQuickAccess qucik = new ProductQuickAccess
                                {
                                    Pro_Id = product.Id,
                                    CodeBar = txtBarCode.Text,
                                    ProductImage = RetriveImage(),
                                    ProductName = txtNameProduct.Text,
                                };
                                //vider();
                                _context.Add(qucik);
                                _context.SaveChanges();
                            }
                            Code.Helper.ToasterHelper.ShowAddToast();

                        }

                    }

                }
                else
                    MsgHelper.ShowRequiredFields();
            }
            catch (Exception)
            {

                throw;
            }
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
            try
            {
                ToasterHelper.PlayNotificationSound();
                if (!ValidateUniqueProductBareCode()) { MsgHelper.BareCodeMesssageDuplicated(); return; }


                var ResultProductName = _context.Products.FirstOrDefault(x => x.ProductName == txtNameProduct.Text
                && x.Id.ToString() != lblProductId.Text);

                if (ResultProductName is null)
                {

                    Product product = productsRepository.Find(lblProductId.Text);
                    if (product is not null)
                    {
                        product.ProductName = txtNameProduct.Text;
                        product.CodeBar = txtBarCode.Text;
                        product.CategoryId = Convert.ToInt32(CMBCategory.SelectedValue);
                        product.MinQty = ConvertToFloat(txtMinQty.Text);
                        product.IsTaxed = CbIsTaxed.Checked;
                        product.TaxValue = CbIsTaxed.Checked ? ConvertToFloat(txtTaxValue.Text) : 0;
                        product.BuyPrice = ConvertToFloat(txtBuyPrice.Text);
                        product.Quentity = ConvertToFloat(txtTotalQty.Text);
                        product.WholesalePrice = ConvertToFloat(txtWholeSalePrice.Text);
                        product.SalePrice = ConvertToFloat(txtSalePrice.Text);
                        product.MaxDiscount = ConvertToFloat(txtDiscountAllowed.Text);
                        product.SalePriceTax = ConvertToFloat(txtSaleAfterTax.Text);
                        product.SalePriceSeconde = ConvertToFloat(txtSalePrice2.Text);
                        product.ColisageBareCode = txtColisageBareCode.Text;
                        product.NbrProductInColis = ConvertToFloat(txtNbrIncolis.Text);
                        product.DateExperation = DtpExperation.Value;
                        product.ProductImage = RetriveImage();

                        var result = productsRepository.UpdateAsync(lblProductId.Text, product);
                        var families = _context.ProductFamilies.Where(x => x.Pro_Id == product.Id).ToList();
                        _context.RemoveRange(families);
                        _context.SaveChanges();
                        if (checkBox1.Checked)
                        {
                            var textBoxes = new[]
                            {
                                    textBox1, textBox2, textBox3, textBox4, textBox5,
                                    textBox6, textBox7, textBox8, textBox9, textBox10
                                };

                            foreach (var textBox in textBoxes)
                            {
                                if (!string.IsNullOrEmpty(textBox.Text))
                                {
                                    var family = new ProductFamily
                                    {
                                        Pro_Id = product.Id,
                                        CodeBar = textBox.Text
                                    };
                                    _context.ProductFamilies.Add(family);
                                }
                            }

                            // Save all changes at once
                            _context.SaveChanges();
                        }
                        if (!ProductsUserControl.CheckInstance())
                        {
                            ProductsUserControl.RefreshDgv();
                        }
                        if (cbFavorite.Checked)
                        {
                            if (_context.ProductQuickAccess.FirstOrDefault(x => x.Pro_Id == product.Id) is null)
                            {
                                ProductQuickAccess qucik = new ProductQuickAccess
                                {
                                    Pro_Id = product.Id,
                                    CodeBar = txtBarCode.Text,
                                    ProductImage = RetriveImage(),
                                    ProductName = txtNameProduct.Text,
                                };
                                //vider();
                                _context.Add(qucik);
                                _context.SaveChanges();
                            }
                        }
                        else
                        {
                            var ProQuick = _context.ProductQuickAccess.FirstOrDefault(x => x.Pro_Id.ToString() == lblProductId.Text);
                            if (ProQuick != null)
                            {
                                _context.Remove(ProQuick);
                                _context.SaveChanges();

                            }
                        }
                        product = null;
                    }

                    Code.Helper.ToasterHelper.ShowEditToast();

                }
                else
                {
                    if (MsgHelper.ShowProductNameIsSame())
                    {
                        Product product = productsRepository.Find(lblProductId.Text);
                        product.ProductName = txtNameProduct.Text;
                        product.CodeBar = txtBarCode.Text;
                        product.CategoryId = Convert.ToInt32(CMBCategory.SelectedValue);
                        product.MinQty = ConvertToFloat(txtMinQty.Text);
                        product.IsTaxed = CbIsTaxed.Checked;
                        product.TaxValue = CbIsTaxed.Checked ? ConvertToFloat(txtTaxValue.Text) : 0;
                        product.BuyPrice = ConvertToFloat(txtBuyPrice.Text);
                        product.Quentity = ConvertToFloat(txtTotalQty.Text);
                        product.WholesalePrice = ConvertToFloat(txtWholeSalePrice.Text);
                        product.SalePrice = ConvertToFloat(txtSalePrice.Text);
                        product.MaxDiscount = ConvertToFloat(txtDiscountAllowed.Text);
                        product.SalePriceTax = ConvertToFloat(txtSaleAfterTax.Text);
                        product.SalePriceSeconde = ConvertToFloat(txtSalePrice2.Text);
                        product.ColisageBareCode = txtColisageBareCode.Text;
                        product.NbrProductInColis = ConvertToFloat(txtNbrIncolis.Text);
                        product.DateExperation = DtpExperation.Value;
                        product.ProductImage = RetriveImage();
                        var result = productsRepository.UpdateAsync(lblProductId.Text, product);
                        var families = _context.ProductFamilies.Where(x => x.Pro_Id == product.Id).ToList();
                        _context.RemoveRange(families);
                        _context.SaveChanges();
                        if (checkBox1.Checked)
                        {
                            var textBoxes = new[]
                            {
                                    textBox1, textBox2, textBox3, textBox4, textBox5,
                                    textBox6, textBox7, textBox8, textBox9, textBox10
                                };

                            foreach (var textBox in textBoxes)
                            {
                                if (!string.IsNullOrEmpty(textBox.Text))
                                {
                                    var family = new ProductFamily
                                    {
                                        Pro_Id = product.Id,
                                        CodeBar = textBox.Text
                                    };
                                    _context.ProductFamilies.Add(family);
                                }
                            }

                            // Save all changes at once
                            _context.SaveChanges();
                        }
                        if (!ProductsUserControl.CheckInstance())
                        {
                            ProductsUserControl.RefreshDgv();
                        }

                        if (cbFavorite.Checked)
                        {
                            if (_context.ProductQuickAccess.FirstOrDefault(x => x.Pro_Id == product.Id) is null)
                            {
                                ProductQuickAccess qucik = new ProductQuickAccess
                                {
                                    Pro_Id = product.Id,
                                    CodeBar = txtBarCode.Text,
                                    ProductImage = RetriveImage(),
                                    ProductName = txtNameProduct.Text,
                                };
                                //vider();
                                _context.Add(qucik);
                                _context.SaveChanges();
                            }
                            product = null;
                        }
                        else
                        {
                            var ProQuick = _context.ProductQuickAccess.FirstOrDefault(x => x.Pro_Id.ToString() == lblProductId.Text);
                            if (ProQuick != null)
                            {
                                _context.Remove(ProQuick);
                                _context.SaveChanges();

                            }
                        }
                        Code.Helper.ToasterHelper.ShowEditToast();

                    }
                }


            }
            catch (Exception)
            {

                throw;
            }
        }


        private void btnAddCategory_Click(object sender, EventArgs e)
        {

            ToasterHelper.PlayNotificationSound();
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
            ToasterHelper.PlayNotificationSound();
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
            BarcodeGui.BarCodeForm barCodeForm = BarcodeGui.BarCodeForm.Instance(_main);
            barCodeForm.txtBarCode.Text = txtBarCode.Text;
            barCodeForm.lblIdProduct.Text = lblProductId.Text;
            barCodeForm.txtPrice.Text = txtSaleAfterTax.Text;
            barCodeForm.txtProductName.Text = txtNameProduct.Text;
            barCodeForm.lblBarecode.Text = txtBarCode.Text;

            barCodeForm.Show();

        }

        private void CbIsTaxed_CheckedChanged(object sender, EventArgs e)
        {
            if (CbIsTaxed.Checked)
                txtTaxValue.Enabled = true;
            else
                txtTaxValue.Enabled = false;

        }

        private void txtNameProduct_KeyDown(object sender, KeyEventArgs e)
        {

            if (e.KeyCode == Keys.Enter)
            {

                e.Handled = true;
                //e.SuppressKeyPress = true; // Suppress the "ding" sound
                SelectNextControl((Control)sender, true, true, true, true);
            }

        }

        private void cbFavorite_CheckedChanged(object sender, EventArgs e)
        {

        }

        private void txtBarCode_TextChanged(object sender, EventArgs e)
        {
            try
            {
                if (sender is TextBox textBox)
                {
                    if (!MsgHelper.ShowBareCodeDuplicatedWithoutMessages(_context, textBox.Text))
                    {
                        textBox.ForeColor = Color.Red;
                    }
                    else
                    {
                        textBox.ForeColor = Color.Black;
                    }
                }
                if (btnEditProduct.Visible && sender is TextBox textBoX)
                {
                    if (!MsgHelper.ShowBareCodeDuplicatedWithoutMessagesForEdit(_context, textBoX.Text, lblProductId.Text))
                    {
                        textBoX.ForeColor = Color.Red;
                    }
                    else
                    {
                        textBoX.ForeColor = Color.Black;
                    }
                }
            }
            catch (Exception)
            {

                throw;
            }
        }

        private void txtNameProduct_TextChanged(object sender, EventArgs e)
        {
            try
            {
                if (!MsgHelper.ShowProductNameDuplicated(_context, txtNameProduct.Text, lblProductId.Text))
                {
                    txtNameProduct.ForeColor = Color.Red;

                }
                else
                {
                    txtNameProduct.ForeColor = Color.Black;

                }
            }
            catch (Exception)
            {

                throw;
            }
        }

        private void checkBox1_CheckedChanged(object sender, EventArgs e)
        {
            if (flowLayoutPanel1.Enabled)
            {
                flowLayoutPanel1.Enabled = false;
            }
            else
            {

                flowLayoutPanel1.Enabled = true;


            }
        }

        private void txtSalePrice_KeyUp(object sender, KeyEventArgs e)
        {
            txtSalePrice2.Text = txtSalePrice.Text;
            txtSaleAfterTax.Text = CalculatePriceWithTax(ConvertToFloat(txtSalePrice.Text), ConvertToFloat(txtTaxValue.Text)).ToString();
        }
        public static decimal CalculatePriceWithTax(decimal price, decimal taxRate)
        {
            if (price < 0 || taxRate < 0)
                return 0;

            decimal priceWithTax = price + (price * (taxRate / 100));
            return Math.Round(priceWithTax, 2); // Rounds to 2 decimal places
        }

        private void PbImageProduct_Click_1(object sender, EventArgs e)
        {

        }
    }
}