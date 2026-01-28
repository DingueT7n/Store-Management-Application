using System.Data;
using DevExpress.XtraReports.UI;
using Microsoft.Data.SqlClient;
using Microsoft.EntityFrameworkCore;
using Microsoft.IdentityModel.Tokens;
using Store.ApplicationUI.Code.Helper;
using Store.ApplicationUI.Code.System;
using Store.ApplicationUI.Gui.PaymentGui;
using Store.Core.Entities.Caisses;
using Store.Core.Entities.Customers;
using Store.Core.Entities.Products;
using Store.Core.Entities.Returns;
using Store.Core.Entities.Sales;
using Store.Core.Interfaces;
using Store.Infrastructure.Data;

namespace Store.ApplicationUI.Gui.SalesGui.PosGui
{
    public partial class PosUserControl : UserControl
    {
        private readonly ApplicationDbContext _context;

        private readonly ISalesRepository _salesRepository;
        private readonly ControlManager _controlManager;
        public decimal PaidUp;
        public decimal Remain;

        public PosUserControl(ApplicationDbContext context, ISalesRepository salesRepository, ControlManager controlManager)
        {
            InitializeComponent();
            _context = context;

            _salesRepository = salesRepository;
            _controlManager = controlManager;
        }
        private void setPrivateProductAndAdditTotable(Product product)
        {
            txtSearchBarCode.Text = product.CodeBar;
            SetProductsToTable();
            AddNewRow();
        }
        public bool setProductFromSelector(Product product)
        {
            if (product is not null)
            {
                setPrivateProductAndAdditTotable(product);
                return true;
            }
            return false;
        }
        public void setCustomerFromSelector(string CustId, string CustName)
        {
            IdCustomer.Text = CustId;
            lblCustomerName.Text = CustName;

        }

        // methodes 
        public async void LoadData()
        {


            //ShowLoading
            //LoadingForm.Instance(_main).Show();

            if (await _salesRepository.IsConnectedAsync())
            {

                //Start Load Data
                //txtFactureNumber.Text = _salesRepository.GetFactureNumber();
                //// if its an admin or Normal user 
                //SetColumns();

                //cmbCustomers.DataSource = _context.Customers.ToList();
                //cmbCustomers.DisplayMember = "CustomerName";
                //cmbCustomers.ValueMember = "Id";
                //cmbCustomers.Text = "اختر العميل";

                //cmbStores.DataSource = _context.Stores.ToList();
                //cmbStores.DisplayMember = "StoreName";
                //cmbStores.ValueMember = "Id";
                //cmbStores.Text = "اختر مخزن";

                //DtpDateFacture.Value = DateTime.Now;
                //dtpReminderDate.Value = DateTime.Now.AddDays(30);


                //_data.Clear();
            }
            else
            {

                //LoadingForm.Instance(_main).Hide();
                //No Connection
                MsgHelper.ShowServerError();
            }
            //Hideloading
            //LoadingForm.Instance(_main).Hide();
            // Show EmptyDAta
            lblEmptyData.Visible = dgvHelper.IsEmpty(DgvِProducts);
        }
        private void SetColumns()
        {
            if (DgvِProducts.Columns.Count == 0) // Ensure columns are added only once
            {
                DgvِProducts.Columns.Add("اسم المنتج", "اسم المنتج");
                DgvِProducts.Columns.Add("سعر البيع", "سعر البيع");
                DgvِProducts.Columns.Add("الكمية", "الكمية");
                DgvِProducts.Columns.Add("التخفيض%", "التخفيض%");
                DgvِProducts.Columns.Add("اجمالي البيع", "اجمالي البيع");
                DgvِProducts.Columns.Add("معرف المنتوج", "معرف المنتوج");
                DgvِProducts.Columns.Add("باركود", "باركود");
            }
            // Visible of Columns
            //DgvProducts.Columns[0].Visible = false;
            ////DgvِProducts.Columns[6].Visible = false;
            DgvِProducts.Columns[6].Visible = false;
            DgvِProducts.Columns[5].Visible = false;
            ////DgvِProducts.Columns[11].Visible = false;
            ////DgvِProducts.Columns[12].Visible = false;
            ////DgvِProducts.Columns[15].Visible = false;
            ////DgvِProducts.Columns[13].Visible = false;
            //DgvProducts.Columns[13].Visible = false;
            //DgvProducts.Columns[14].Visible = false;
            //DgvProducts.Columns[13].Visible = false;
            //DgvProducts.Columns[15].Visible = false;
        }
        private void ChangeLabelColeurs(Color color)
        {
            lblQuentityValue.ForeColor = color;
            lblCurrancy.ForeColor = color;
            lblCustomerName.ForeColor = color;
            lblDatetime.ForeColor = color;
            lblFactureNumber.ForeColor = color;
            lblHour.ForeColor = color;

            lblQuentityValue.ForeColor = color;
            lblSupportNumber.ForeColor = color;
            lblProductIntable.ForeColor = color;

            lblValuePrice.ForeColor = color;
            lblUserName.ForeColor = color;


        }
        private void rbRefund_CheckedChanged(object sender, EventArgs e)
        {
            if (rbRefund.Checked)
            {
                ChangeLabelColeurs(Color.Red);
            }
            else
                ChangeLabelColeurs(Color.PaleGreen);
        }

        private void rbSale_CheckedChanged(object sender, EventArgs e)
        {
            if (rbRefund.Checked)
            {
                ChangeLabelColeurs(Color.Red);
            }
            else
                ChangeLabelColeurs(Color.PaleGreen);
        }

        private void timer_Tick(object sender, EventArgs e)
        {
            lblHour.Text = DateTime.Now.ToString("hh:mm:ss");
            lblDatetime.Text = DateTime.Now.ToShortDateString();
        }
        public async void BringTofront(bool b)
        {
            if (b)
            {
                ModifiertableLayoutPanel.BringToFront();
                EditFromTable(0);
            }
            else
            {

                ModifiertableLayoutPanel.SendToBack();
                //AddNewRow();
            }

        }
        private void PosUserControl_KeyDown(object sender, KeyEventArgs e)
        {
            GetTheEventAndSender(sender, e);
        }

        private void txtQty_KeyPress(object sender, KeyPressEventArgs e)
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

        private async void txtQty_KeyUp(object sender, KeyEventArgs e)
        {
            CalculateAmount();

        }

        private void txtQty_KeyDown(object sender, KeyEventArgs e)
        {
            if (e.KeyCode == Keys.Enter)
            {
                BringTofront(false);
                AddNewRow();
                txtQty.Text = string.Empty;
            }
        }
        async void OnLoad(int skip)
        {
            txtSearchBarCode.Focus();
            SetColumns();
            if (await _context.Database.CanConnectAsync())
                DgvQuickProducts.DataSource = await _context.ProductQuickAccess.Select(x => new { x.CodeBar, x.ProductName }).ToListAsync();
            lblFactureNumber.Text = _salesRepository.GetFactureNumber();
            lblUserName.Text = Properties.Settings.Default.UserName;

            lblCustomerName.Text = Properties.Settings.Default.DefaultCustomerSale;
            IdCustomer.Text = Properties.Settings.Default.IdCustomerSale;
            SetQuickColumns();
            CalculateStatistics();

            double value = await _context.ProductQuickAccess.AsNoTracking().CountAsync() / Convert.ToDouble(Properties.Settings.Default.NoOfDataInDgvs);
            int pageCount = Convert.ToInt32(Math.Ceiling(value));

            // Update pagination combo box
            cmbpagination.Items.Clear();
            for (int i = 0; i < pageCount; i++)
            {
                cmbpagination.Items.Add(i + 1);
            }

            if (cmbpagination.Items.Count > 0)
            {
                cmbpagination.SelectedIndex = skip / Properties.Settings.Default.NoOfDataInDgvs;
            }

            PaginationHide();
            lblEmptyData.Visible = dgvHelper.IsEmpty(DgvQuickProducts);
        }
        private void PosUserControl_Load(object sender, EventArgs e)
        {

            OnLoad(0);
            //Add Roles

        }
        public async void ParseScaleBarcode(string barcodeWeight)
        {
            if (string.IsNullOrWhiteSpace(barcodeWeight) || barcodeWeight.Length < 12)
                throw new ArgumentException("Invalid barcode length.");

            //// Extract the first two digits as the prefix
            //string prefix = barcode.Substring(0, 2);

            //if (!ValidPrefixes.Contains(prefix))
            //    throw new ArgumentException("Invalid barcode prefix for a weighing scale.");

            // Determine product code length dynamically (4-6 digits)
            int productCodeLength = barcodeWeight.Length - 7; // Ensure at least 5 digits for weight
            if (productCodeLength < 4 || productCodeLength > 6)
                throw new ArgumentException("Unexpected product code length.");

            // Extract weight (last 5 digits)
            string weightString = barcodeWeight.Substring(productCodeLength + 2, 5);

            // Convert weight (assuming last 3 digits are decimals, e.g., 12345 -> 12.345kg)
            if (!decimal.TryParse(weightString.Insert(weightString.Length - 3, "."), out decimal weight))
                throw new FormatException("Invalid weight format.");
            // Extract product code dynamically
            string productBarCode = barcodeWeight.Substring(2, productCodeLength);
            _product = _salesRepository.GetProductBarCode(productBarCode);
            if (_product != null)
            {
                InitializeTextBoxesAndLablesFromWeight(_product, weight);
                txtQty.Focus();
                txtQty.SelectAll();
                CalculateAmount();
                txtSearchBarCode.Clear();
                txtSearchBarCode.Focus();
            }
            else
            {
                MsgHelper.ShowEmptyResult();
                txtSearchBarCode.Focus();
                txtQty.Clear();
            }

        }
        public void InitializeTextBoxesAndLablesFromWeight(Product product, decimal weight)
        {
            try
            {
                var idstore = Properties.Settings.Default.FastSaleStore;

                var now = DateTime.Now;

                ProductDiscount productDiscount = _context?.ProductDiscounts.
                      Where(x => x.Pro_Id.ToString() == product.Id.ToString() && x.Quentity > weight
                      && x.Store_Id == idstore
                      && x.DateStart <= DateTime.Now && x.DateEnd > DateTime.Now
                      ).FirstOrDefault();
                if (productDiscount != null)
                {
                    txtSaleDiscount.Text = Code.Helper.FactureHelper.CalculateDiscountPercentage(product.SalePriceTax, productDiscount.DiscountValue).ToString();
                }
                else
                {
                    txtSaleDiscount.Text = "0";
                }
                txtQty.Text = weight.ToString();
                txtTotalSaleProduct.Text = (product.SalePriceTax * weight).ToString();
                txtSalePrice.Text = product.SalePriceTax.ToString();
                //

                txtProductName.Text = product.ProductName;



                if (productDiscount != null && btnPrices.Text == "سعر 1")
                {

                    txtSaleDiscount.Text = Code.Helper.FactureHelper.CalculateDiscountPercentage(product.SalePriceTax, productDiscount.DiscountValue).ToString();

                }
                else
                {
                    txtSaleDiscount.Text = "0";
                }
                if (btnPrices.Text == "سعر 1" || btnPrices.Text == "سعر 1 (F7)")
                {
                    txtSalePrice.Text = (product.SalePriceTax).ToString();
                    txtTotalSaleProduct.Text = (product.SalePriceTax * weight).ToString();
                }
                else if (btnPrices.Text == "سعر 2")
                {
                    txtSalePrice.Text = product.SalePriceSeconde.ToString();
                    txtTotalSaleProduct.Text = (product.SalePriceSeconde * weight).ToString();
                    txtSaleDiscount.Text = "0";


                }
                else
                {
                    txtSalePrice.Text = product.WholesalePrice.ToString();
                    txtTotalSaleProduct.Text = (product.WholesalePrice * weight).ToString();
                    txtSaleDiscount.Text = "0";


                }

            }
            catch (Exception ex)
            {
                ToasterHelper.ShowErrorHappened(ex.Message);
                throw;
            }
        }

        private void txtSearchBarCode_KeyDown(object sender, KeyEventArgs e)
        {

            if (e.KeyCode == Keys.Enter)
            {
                txtSearchBarCode.Text = txtSearchBarCode.Text.Replace("\r\n", "").Trim();
                string input = txtSearchBarCode.Text.Trim().Replace("\r", "").Replace("\n", "").Trim();

                if (input.Replace("\r\n", "").Length > 2)
                {

                    string prefix = input.Substring(0, 2);

                    if (prefix == "21" && input.Length >= 5)
                    {
                        ParseScaleBarcode(txtSearchBarCode.Text);
                        AddNewRow();
                        CalculateAmount();
                        CalculateStatistics();
                        txtSearchBarCode.Clear();
                        txtSearchBarCode.Focus();
                    }
                    else
                    {
                        SetProductsToTable();
                        AddNewRow();
                        CalculateAmount();
                        CalculateStatistics();
                        txtSearchBarCode.Clear();
                        txtSearchBarCode.Focus();
                        return;
                    }
                }
                else
                {
                    SetProductsToTable();
                    AddNewRow();
                    CalculateAmount();
                    CalculateStatistics();
                    txtSearchBarCode.Clear();
                    txtSearchBarCode.Focus();
                    return;
                }

                txtSearchBarCode.Text = "";
                txtSearchBarCode.Clear();
                txtSearchBarCode.Focus();


            }

        }
        private Product _product;
        private ProductDiscount _productDiscount;
        private ProductsQuantitie _productQuantitie;
        public void SetProductsToTable()
        {
            //DgvProducts.DataSource = await Task.Run(() => productsRepository.GetAll(p => p.Category));
            _product = _salesRepository.GetProductBarCode(txtSearchBarCode.Text.Replace("\r\n", "").Trim());
            if (_product is not null)
            {

                InitializeTextBoxesAndLables(_product);

                txtQty.Focus();
                txtQty.SelectAll();
                CalculateAmount();
                CalculateStatistics();
                txtSearchBarCode.Clear();
            }
            else
            {
                //MsgHelper.ShowEmptyResult();
                txtSearchBarCode.Focus();
                txtSearchBarCode.Clear();
            }
            //txtSearchBarCode.Clear();

        }
        public decimal ConvertToFloat(string value)
        {
            //decimal quantity;
            //if (float.TryParse(value, out quantity))
            //{
            //    return quantity;
            //}
            return Convert.ToDecimal(value);
        }
        public async void InitializeTextBoxesAndLables(Product product)
        {
            txtQty.Text = "0";
            var idstore = Properties.Settings.Default.FastSaleStore;
            ProductDiscount productDiscount = _context.ProductDiscounts.
                Where(x => x.Pro_Id.ToString() == product.Id.ToString() && x.Quentity > 0

                && x.Store_Id == idstore
                && x.DateStart <= DateTime.Now && x.DateEnd > DateTime.Now
                ).FirstOrDefault();
            txtProductName.Text = product.ProductName;



            if (productDiscount != null && btnPrices.Text == "سعر 1")
            {

                txtSaleDiscount.Text = Code.Helper.FactureHelper.CalculateDiscountPercentage(product.SalePriceTax, productDiscount.DiscountValue).ToString();

            }
            else
            {
                txtSaleDiscount.Text = "0";
            }

            if (txtQty.Text != string.Empty)
            {
                bool isColisageMatch =
                 !string.IsNullOrEmpty(product.ColisageBareCode) &&
                 product.ColisageBareCode == txtSearchBarCode.Text;

                decimal qty = ConvertToFloat(txtQty.Text);

                txtQty.Text = isColisageMatch
                    ? (qty + product.NbrProductInColis).ToString()
                    : "1";
            }
            else
            {
                txtQty.Text = !product.ColisageBareCode.IsNullOrEmpty() && product.ColisageBareCode == txtSearchBarCode.Text ? product.NbrProductInColis.ToString() : "1";
            }
            if (btnPrices.Text == "سعر 1" || btnPrices.Text == "سعر 1 (F7)")
            {
                txtTotalSaleProduct.Text = product.SalePriceTax.ToString();
                txtSalePrice.Text = product.SalePriceTax.ToString();
            }
            else if (btnPrices.Text == "سعر 2")
            {
                txtTotalSaleProduct.Text = product.SalePriceSeconde.ToString();
                txtSalePrice.Text = product.SalePriceSeconde.ToString();
                txtSaleDiscount.Text = "0";


            }
            else
            {
                txtTotalSaleProduct.Text = product.WholesalePrice.ToString();
                txtSalePrice.Text = product.WholesalePrice.ToString();
                txtSaleDiscount.Text = "0";


            }
        }
        public void ClearBoxes()
        {
            txtProductName.Text = string.Empty;
            txtSaleDiscount.Text = string.Empty;
            txtQty.Text = string.Empty;
            txtTotalSaleProduct.Text = string.Empty;
            txtSalePrice.Text = string.Empty;
        }
        async void CalculateAmount()
        {
            try
            {
                if (txtSalePrice.Text != string.Empty && txtQty.Text != string.Empty
                     && txtSaleDiscount.Text != string.Empty)
                {
                    ProductDiscount productDiscount = _context.ProductDiscounts.
              Where(x => x.Pro_Id.ToString() == _product.Id.ToString() && x.Quentity >= ConvertToFloat(txtQty.Text)

              && x.Store_Id == Properties.Settings.Default.FastSaleStore
              && x.DateStart <= DateTime.Now && x.DateEnd > DateTime.Now
              ).FirstOrDefault();
                    if (productDiscount != null && btnPrices.Text == "سعر 1" && productDiscount.Quentity >= ConvertToFloat(txtQty.Text))
                    {

                        txtSaleDiscount.Text = Code.Helper.FactureHelper.CalculateDiscountPercentage(_product.SalePriceTax, productDiscount.DiscountValue).ToString();

                    }
                    else
                    {
                        txtSaleDiscount.Text = "0";
                    }

                    decimal Discount = Convert.ToDecimal(txtSaleDiscount.Text);
                    decimal Amount = Convert.ToDecimal(txtSalePrice.Text);
                    decimal TotalAmount = Amount - (Amount * (Discount / 100));
                    TotalAmount = Math.Round(TotalAmount, 2);
                    txtTotalSaleProduct.Text = ((ConvertToFloat(TotalAmount.ToString()) * Convert.ToDecimal(txtQty.Text))).ToString(("f2"));

                }
                if (txtQty.Text == string.Empty)
                {
                    txtQty.Text = "1";
                }
            }
            catch (Exception ex) { MessageBox.Show(ex.Message); }
        }
        int rowIndex;
        private decimal TotalFacture;
        void new_row()
        {
            try
            {
                int rowIndex = DgvِProducts.Rows.Add(); // Add a new row to the DataGridView
                DataGridViewRow newRow = DgvِProducts.Rows[rowIndex];

                // Set values in the new row
                newRow.Cells[0].Value = txtProductName.Text;
                newRow.Cells[1].Value = txtSalePrice.Text;
                newRow.Cells[2].Value = txtQty.Text;
                newRow.Cells[3].Value = txtSaleDiscount.Text;
                newRow.Cells[4].Value = txtTotalSaleProduct.Text;
                newRow.Cells[5].Value = _product.Id;
                newRow.Cells[6].Value = _product.CodeBar;
                DgvِProducts.CurrentCell = DgvِProducts[0, DgvِProducts.Rows.Count - 1];
                ClearBoxes();
                txtSearchBarCode.Clear();
                txtSearchBarCode.Focus();
            }
            catch (Exception ex) { MessageBox.Show(ex.Message); }

        }
        void AddNewRow()
        {

            if (txtProductName.Text != string.Empty && txtSalePrice.Text != string.Empty && txtQty.Text != string.Empty)
            {
                try
                {

                    for (int i = 0; i < DgvِProducts.Rows.Count; i++)
                    {
                        if (DgvِProducts.Rows[i].Cells[5].Value.ToString() == _product.Id.ToString())
                        {
                            ProductDiscount productDiscount = _context.ProductDiscounts.
                      Where(x => x.Pro_Id == _product.Id && x.Quentity >=
                      (ConvertToFloat(DgvِProducts.Rows[i].Cells[2].Value.ToString()) + ConvertToFloat(txtQty.Text))

                      && x.Store_Id == Properties.Settings.Default.FastSaleStore
                      && x.DateStart <= DateTime.Now && x.DateEnd > DateTime.Now
                      ).FirstOrDefault();


                            if (productDiscount != null && btnPrices.Text == "سعر 1")
                            {
                                DgvِProducts.Rows[i].Cells[3].Value = FactureHelper.CalculateDiscountPercentage(_product.SalePriceTax, productDiscount.DiscountValue).ToString();
                            }
                            else
                            {
                                DgvِProducts.Rows[i].Cells[3].Value = 0;
                            }
                            //MsgHelper.ShowDuplicatedItemsAndInformTeCaiser();  Toaster
                            DgvِProducts.Rows[i].Cells[2].Value = !_product.ColisageBareCode.IsNullOrEmpty() && _product.ColisageBareCode.ToString() == txtSearchBarCode.Text ?
                              (ConvertToFloat(DgvِProducts.Rows[i].Cells[2].Value.ToString()) + _product.NbrProductInColis).ToString() : (ConvertToFloat(DgvِProducts.Rows[i].Cells[2].Value.ToString()) + ConvertToFloat(txtQty.Text)).ToString();
                            DgvِProducts.Rows[i].Cells[4].Value = (ConvertToFloat(DgvِProducts.Rows[i].Cells[2].Value.ToString()) *
                                ConvertToFloat(DgvِProducts.Rows[i].Cells[1].Value.ToString())).ToString();
                            decimal Discount = Convert.ToDecimal(DgvِProducts.Rows[i].Cells[3].Value.ToString());
                            decimal Amount = Convert.ToDecimal(DgvِProducts.Rows[i].Cells[4].Value.ToString());
                            decimal TotalAmount = Amount - (Amount * (Discount / 100));
                            TotalAmount = Math.Round(TotalAmount, 2);

                            DgvِProducts.Rows[i].Cells[4].Value = TotalAmount;
                            txtSearchBarCode.Focus();
                            ClearBoxes();
                            CalculateStatistics();
                            CalculateAmount();
                            txtSearchBarCode.Clear();

                            return;
                            //EditFromTable(1);
                            //CalculateAmount();
                            ////AddNewRow();
                        }
                    }
                    new_row();
                    CalculateStatistics();
                }
                catch (Exception ex) { MessageBox.Show(ex.Message); }

            }
            else
            {
                //MsgHelper.ShowEmptyResult();
            }
            CalculateStatistics();
        }
        void CalculateStatistics()
        {
            try
            {


                if (DgvِProducts.Rows.Count >= 0)
                {
                    lblValuePrice.Text = (from DataGridViewRow row in DgvِProducts.Rows
                                          where row.Cells[4].FormattedValue.ToString() != string.Empty
                                          select Convert.ToDecimal(row.Cells[4].FormattedValue)).Sum()
                                          .ToString("f2");
                    var round = (Convert.ToDecimal(lblValuePrice.Text) % 10);
                    if (round > 5)
                        round = round - 5;
                    else if (round == 5)
                        round = 0;
                    lblValuePrice.Text = (Convert.ToDecimal(lblValuePrice.Text) - round).ToString("f2");
                    TotalFacture = ((from DataGridViewRow row in DgvِProducts.Rows
                                     where row.Cells[4].FormattedValue.ToString() != string.Empty
                                     select Convert.ToDecimal(row.Cells[4].FormattedValue)).Sum()) - round;
                    lblQuentityValue.Text =
                              (from DataGridViewRow row in DgvِProducts.Rows
                               where row.Cells[2].FormattedValue.ToString() != string.Empty
                               select Convert.ToDecimal(row.Cells[2].FormattedValue)).Sum()
                               .ToString("f2");
                    lblProductIntable.Text = $"{DgvِProducts.Rows.Count}";
                }

            }
            catch (Exception)
            {

                throw;
            }

        }
        public async void EditUsingPlusMinus(object sender, KeyEventArgs e)
        {

            if (e.KeyCode == Keys.Oemplus || e.KeyCode == Keys.Add)
            {
                EditFromTable(1);
                CalculateAmount();
                AddNewRow();
            }
            else if (e.KeyCode == Keys.OemMinus || e.KeyCode == Keys.Subtract)
            {
                EditFromTable(-1);
                CalculateAmount();
                AddNewRow();
            }
            int x = 10;
        }
        public void Arrows(object sender, KeyEventArgs e)
        {
            if (e.KeyCode == Keys.Up)
            {
                UpArrow();
            }
            else if (e.KeyCode == Keys.Down)
            {
                DownArrow();
            }
        }
        void DeleteSenderEvent(object sender, KeyEventArgs e)
        {
            if (e.Control && e.KeyCode == Keys.S)
            {
                DeleteItemFromDgv();
            }
        }
        async void PayNowEvent(object sender, KeyEventArgs e)
        {
            if (e.KeyCode == Keys.F12)
            {
                if (!dgvHelper.IsEmpty(DgvِProducts))
                    await PayNowAsync(false);
            }
            else if (e.KeyCode == Keys.F11)
            {
                if (!dgvHelper.IsEmpty(DgvِProducts))
                    await PayNowAsync(true);
            }
        }
        public void GetTheEventAndSender(object sender, KeyEventArgs e)
        {
            EditUsingPlusMinus(sender, e);
            this.DeleteSenderEvent(sender, e);
            this.Arrows(sender, e);
            this.PayNowEvent(sender, e);
            if (e.KeyCode == Keys.F7)
            {
                btnPrices_Click(sender, e);
            }
            else if ((e.KeyCode == Keys.F9))
            {
                btnSearchImage_Click(sender, e);
            }
            else if ((e.KeyCode == Keys.Escape))
            {
                txtSearchBarCode.Clear();
                txtSearchBarCode.Focus();
            }

        }
        private void SetQuickColumns()
        {
            //E DgvQuickProducts.DataSource = new List<()new {  >

            //DgvQuickProducts.Columns[0].HeaderCell.Value = "معرف المنتوج";
            DgvQuickProducts.Columns[0].HeaderCell.Value = "باركود";
            DgvQuickProducts.Columns[1].HeaderCell.Value = "اسم المنتج";
            //DgvQuickProducts.Columns[3].HeaderCell.Value = "صورة المنتج";
            //DgvQuickProducts.Columns[4].HeaderCell.Value = "المنتج";
            //DgvQuickProducts.Columns[5].HeaderCell.Value = "معرف السرعة";
            DgvQuickProducts.Columns[0].Width = 50;
            //DgvQuickProducts.Columns[3].Visible = false;
            //DgvQuickProducts.Columns[4].Visible = false;
            //DgvQuickProducts.Columns[5].Visible = false;
            //DgvQuickProducts.Columns[0].Visible = false;


        }
        public void CleanForm()
        {

            Process = false;

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
            DgvِProducts.Rows.Clear();
            OnLoad(0);




            // Optionally reset focus to the first control
            // Set focus to the first control
        }
        public void ResetForm()
        {
            if (Process)
            {
                Process = false;

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
                DgvِProducts.Rows.Clear();
                OnLoad(0);


            }

            // Optionally reset focus to the first control
            // Set focus to the first control
        }
        public async void PrintLastFacture(bool A4)
        {
            try
            {


                var facture = await _context.Sales.OrderByDescending(s => s.Id).FirstOrDefaultAsync();
                int LastFactureId = 0;
                if (facture is not null)
                {
                    LastFactureId = facture.Id;
                    if (!A4 && Properties.Settings.Default.PrintSaleOnOrOff)
                    {
                        try
                        {
                            DataTable saleDetailsTable = await GetSellDetailsDataTableAsync(LastFactureId);
                            Reports.sale8cm sale8Cm = _controlManager.GetR<Reports.sale8cm>();
                            sale8Cm.DataSource = saleDetailsTable;



                            Reports.ReportPerviwGui.PerviweForm xtraForm1 = _controlManager.GetF<Reports.ReportPerviwGui.PerviweForm>();
                            xtraForm1.LoadReport(sale8Cm);
                            xtraForm1.ShowDialog();
                        }
                        catch (Exception)
                        {
                            throw;
                        }
                    }
                    else if (Properties.Settings.Default.PrintSaleOnOrOff)
                    {
                        try
                        {

                            DataTable ProfitDetailsTable = await FactureHelper.GetSellDetailsDataTableAsync(LastFactureId);
                            Reports.SalesReports.salesA4 salesA4 = _controlManager.GetR<Reports.SalesReports.salesA4>();
                            salesA4.DataSource = ProfitDetailsTable;


                            Reports.ReportPerviwGui.PerviweForm xtraForm1 = _controlManager.GetF<Reports.ReportPerviwGui.PerviweForm>();
                            xtraForm1.LoadReport(salesA4);
                            xtraForm1.ShowDialog();

                        }
                        catch (Exception ex)
                        {
                            ToasterHelper.ShowErrorHappened(ex.Message);
                            throw;
                        }
                    }
                }
            }
            catch (Exception ex)
            {
                ToasterHelper.ShowErrorHappened(ex.Message);
                throw;
            }
        }
        void EditFromTable(int q)
        {
            try
            {
                if (dgvHelper.IsEmpty(DgvِProducts))
                {
                    //MsgHelper.ShowEmptyDataGridView();
                    BringTofront(false);
                    return;
                }
                _product = _salesRepository.GetProductBarCode(DgvِProducts.CurrentRow.Cells[6].Value.ToString());
                txtProductName.Text = this.DgvِProducts.CurrentRow.Cells[0].Value.ToString();
                if (ConvertToFloat(DgvِProducts.CurrentRow.Cells[2].Value.ToString()) + q > 1)
                    txtQty.Text = (ConvertToFloat(DgvِProducts.CurrentRow.Cells[2].Value.ToString()) + q).ToString();
                else txtQty.Text = "1";
                txtTotalSaleProduct.Text = this.DgvِProducts.CurrentRow.Cells[4].Value.ToString();
                txtSalePrice.Text = this.DgvِProducts.CurrentRow.Cells[1].Value.ToString();

                ProductDiscount productDiscount = _context.ProductDiscounts.
               Where(x => x.Pro_Id == _product.Id && x.Quentity > 0

               && x.Store_Id == Properties.Settings.Default.FastSaleStore
               && x.DateStart <= DateTime.Now && x.DateEnd > DateTime.Now
               ).FirstOrDefault();


                if (productDiscount != null && btnPrices.Text == "سعر 1" && ConvertToFloat(txtQty.Text) <= productDiscount.Quentity)
                {
                    txtSaleDiscount.Text = Code.Helper.FactureHelper.CalculateDiscountPercentage(_product.SalePriceTax, productDiscount.DiscountValue).ToString();
                }
                else
                {
                    txtSaleDiscount.Text = "0";
                }


                DgvِProducts.Rows.RemoveAt(DgvِProducts.CurrentRow.Index);
                txtQty.Focus();
                CalculateAmount();
                CalculateStatistics();

                //ProductsQuantitie productQty = _context.ProductsQuantities.
                //          Where(x => x.Pro_ID == _product.Id && x.Qty >= ConvertToFloat(txtQty.Text)
                //          && x.Store_ID == Properties.Settings.Default.FastSaleStore).FirstOrDefault();
            }
            catch (Exception ex)
            {
                ToasterHelper.ShowErrorHappened(ex.Message);
                throw;
            }

        }


        private void txtSearchBarCode_KeyPress(object sender, KeyPressEventArgs e)
        {



        }

        private void btnEditSelected_Click(object sender, EventArgs e)
        {
            ToasterHelper.PlayNotificationSound();
            if (DgvِProducts.Rows.Count > 0)
            {
                BringTofront(true);
            }
        }
        void DownArrow()
        {
            try
            {
                if (DgvِProducts.Rows.Count > 0)
                {
                    //rowIndex = dgvProducts.Rows.GetRowCount(DataGridViewElementStates.Selected);
                    rowIndex = DgvِProducts.CurrentCell.RowIndex;
                    //dgvProducts.Rows[rowIndex].Selected = false;
                    //dgvProducts.ClearSelection();
                    if (rowIndex + 1 < DgvِProducts.Rows.Count)
                    {
                        DgvِProducts.CurrentCell = DgvِProducts[0, rowIndex + 1];
                        // dgvProducts.Rows[rowIndex + 1].Selected = true;
                    }
                }
                else
                    txtSearchBarCode.Focus();
            }
            catch (Exception ex)
            {
                ToasterHelper.ShowErrorHappened(ex.Message);
                throw;
            }
        }
        private void btnDown_Click(object sender, EventArgs e)
        {
            DownArrow();
        }
        void DeleteItemFromDgv()
        {
            try
            {
                //(Keys.Delete);
                if (DgvِProducts.Rows.Count > 0)
                {
                    // rowIndex = dgvProducts.CurrentCell.RowIndex;
                    DgvِProducts.Rows.RemoveAt(DgvِProducts.CurrentRow.Index);
                    CalculateStatistics();

                    // dgvProducts.CurrentCell.Selected = true;
                }
                else txtSearchBarCode.Focus();
            }
            catch (Exception ex)
            {
                ToasterHelper.ShowErrorHappened(ex.Message);
                throw;
            }
        }
        private void btnDeleteSelected_Click(object sender, EventArgs e)
        {
            ToasterHelper.PlayNotificationSound();
            DeleteItemFromDgv();
        }

        private void DgvِProducts_RowsAdded(object sender, DataGridViewRowsAddedEventArgs e)
        {
            CalculateStatistics();

        }

        private void DgvِProducts_RowsRemoved(object sender, DataGridViewRowsRemovedEventArgs e)
        {
            CalculateStatistics();

        }
        void UpArrow()
        {
            try
            {
                if (DgvِProducts.Rows.Count > 0)
                {
                    rowIndex = DgvِProducts.CurrentCell.RowIndex;
                    if (rowIndex > 0)
                    {
                        DgvِProducts.CurrentCell = DgvِProducts[0, rowIndex - 1];
                        // dgvProducts.Rows[rowIndex - 1].Selected = true;
                    }
                }
                else
                    txtSearchBarCode.Focus();
            }
            catch (Exception ex)
            {
                ToasterHelper.ShowErrorHappened(ex.Message);
                throw;
            }
        }
        private void btnUp_Click(object sender, EventArgs e)
        {
            UpArrow();
        }

        private async void btnSearchImage_Click(object sender, EventArgs e)
        {
            ToasterHelper.PlayNotificationSound();

            SelectProductsForm selectProductsForm = await _controlManager.GetFAsync<SelectProductsForm>();
            selectProductsForm.SetPos();
            selectProductsForm.ShowDialog();
        }
        Sale SetSale()
        {

            return new Sale
            {
                TotalOrder = ConvertToFloat(TotalFacture.ToString()),
                CustomerId = Convert.ToInt32(IdCustomer.Text),
                Date = DateTime.Now,
                PaidUP = ConvertToFloat(PaidUp.ToString()),
                Remain = ConvertToFloat(Remain.ToString()),
                Time = DateTime.Now.ToString("HH:mm"),
                User_Name = Properties.Settings.Default.UserName
            };
        }
        CustomerReport SetCustReport()
        {
            return new CustomerReport
            {
                Order_ID = Convert.ToInt32(lblFactureNumber.Text),
                Cust_ID = Convert.ToInt32(IdCustomer.Text),
                Cust_Name = lblCustomerName.Text,
                Date = DateTime.Now,
                Price = ConvertToFloat(PaidUp.ToString()),
                Time = DateTime.Now.ToString("HH:mm")
            };
        }
        CustomerMoney SetCustMoney()
        {

            return new CustomerMoney
            {
                Order_ID = Convert.ToInt32(lblFactureNumber.Text),
                Cust_ID = Convert.ToInt32(IdCustomer.Text),
                Cust_Name = lblCustomerName.Text,
                Order_Date = DateTime.Now,
                Price = ConvertToFloat(Remain.ToString()),
                Time = DateTime.Now.ToString("HH:mm"),
                Reminder_Date = DateTime.Now.AddDays(Properties.Settings.Default.DaysAddDebt)
            };
        }
        SaleDetail SetSaleDetail(int i)
        {
            var row = DgvِProducts.Rows[i];
            return new SaleDetail
            {
                Order_ID = Convert.ToInt32(lblFactureNumber.Text),
                Cust_ID = Convert.ToInt32(IdCustomer.Text),
                Pro_ID = Convert.ToInt32(row.Cells[5].Value.ToString()),
                Quentity = ConvertToFloat(row.Cells[2].Value.ToString()),
                Price = ConvertToFloat(row.Cells[1].Value.ToString()),
                Total = ConvertToFloat(row.Cells[4].Value.ToString()),
                TaxValue = Properties.Settings.Default.TaxValue,
                PriceWithTax = ConvertToFloat(row.Cells[1].Value.ToString()),
                Discount = ConvertToFloat(row.Cells[3].Value.ToString())
            };
        }
        SaleProfit SetSaleProfit(int i, decimal buyPrice, decimal qty)
        {
            var row = DgvِProducts.Rows[i];
            return new SaleProfit
            {
                Order_ID = Convert.ToInt32(lblFactureNumber.Text),
                Cust_Name = lblCustomerName.Text,
                Pro_ID = Convert.ToInt32(row.Cells[5].Value.ToString()),
                Quentity = qty,
                Price = ConvertToFloat(row.Cells[1].Value.ToString()),
                Total = ConvertToFloat(row.Cells[4].Value.ToString()),
                Buy_Price = buyPrice,
                Tax_Value = Properties.Settings.Default.TaxValue,
                Discount = ConvertToFloat(row.Cells[3].Value.ToString()),
                Time = DateTime.Now.ToString("HH:mm"),
                Price_Tax = ConvertToFloat(row.Cells[1].Value.ToString())
            };
        }
        Product SetProduct(int i)
        {
            var proId = DgvِProducts.Rows[i].Cells[5].Value.ToString();
            var product = _context.Products.FirstOrDefault(x => x.Id.ToString() == proId);

            if (product != null)
            {
                product.Quentity -= ConvertToFloat(DgvِProducts.Rows[i].Cells[2].Value.ToString());

                if (product.Quentity < 0 && !Properties.Settings.Default.StockNeg)
                    product.Quentity = 0;

                //product.Quentity = Math.Max(0, product.Quentity - ConvertToFloat(DgvِProducts.Rows[i].Cells[2].Value.ToString()));
            }

            ProductDiscount productDiscount = _context.ProductDiscounts.
                Where(x => x.Pro_Id.ToString() == product.Id.ToString() && x.Quentity > 0

                && x.Store_Id == Properties.Settings.Default.FastSaleStore
                && x.DateStart <= DateTime.Now && x.DateEnd > DateTime.Now
                ).FirstOrDefault();
            if (productDiscount != null)
            {

                productDiscount.Quentity -= ConvertToFloat(DgvِProducts.Rows[i].Cells[2].Value.ToString());
                if (productDiscount.Quentity < 0)
                { productDiscount.Quentity = 0; }
                _context.Update(productDiscount);
                _context.SaveChanges();
            }
            return product;
        }

        decimal SetProductQuentity(decimal quentity, int i, int sale_Id)
        {
            var proId = DgvِProducts.Rows[i].Cells[5].Value.ToString();
            decimal totalBuyPrice = 0;
            int count = 0;

            while (quentity > 0)
            {
                var productQty = _context.ProductsQuantities
                                 .FirstOrDefault(x => x.Qty > 0 && x.Pro_ID.ToString() == proId && x.Store_ID ==
                                 Properties.Settings.Default.FastSaleStore);

                if (productQty != null)
                {
                    totalBuyPrice += productQty.Buy_Price;
                    count++;

                    if (productQty.Qty >= quentity)
                    {
                        var profit = SetSaleProfit(i, productQty.Buy_Price, quentity);
                        profit.Order_ID = sale_Id;
                        _context.SalesProfits.Add(profit);
                        _context.SaveChanges();

                        productQty.Qty -= quentity;
                        quentity = 0;
                        _context.ProductsQuantities.Update(productQty);
                        _context.SaveChanges();

                    }
                    else
                    {
                        var profit = SetSaleProfit(i, productQty.Buy_Price, productQty.Qty);
                        profit.Order_ID = sale_Id;
                        _context.SalesProfits.Add(profit);
                        _context.SaveChanges();

                        quentity -= productQty.Qty;
                        productQty.Qty = 0;
                        _context.ProductsQuantities.Update(productQty);
                        _context.SaveChanges();

                    }

                }
                else
                {
                    var product = _context.Products.FirstOrDefault(x => x.Id.ToString() == proId);
                    if (product != null)
                    {
                        totalBuyPrice = product.BuyPrice;
                        var profit = SetSaleProfit(i, totalBuyPrice, quentity);
                        profit.Order_ID = sale_Id;
                        _context.SalesProfits.Add(profit);
                        _context.SaveChanges();

                        quentity = 0;
                        return count > 0 ? totalBuyPrice / count : totalBuyPrice;
                    }
                }
            }

            return count > 0 ? totalBuyPrice / count : totalBuyPrice;
        }
        Customer SetCustomer()
        {
            var custId = Convert.ToInt32(IdCustomer.Text);
            var customer = _context.Customers.FirstOrDefault(x => x.Id == custId);

            if (customer != null)
            {
                customer.TotalDebts += Remain;
            }

            return customer;
        }
        Caisse SetCaisse(decimal value)
        {
            var caisse = _context.Caisses.FirstOrDefault(x => x.Id == Properties.Settings.Default.DefaultCaisseId);
            if (caisse != null)
            {
                caisse.MoneyinCaisse += value;
            }
            return caisse;

        }
        CaisseDeposit SetCaisseDeposit(decimal value)
        {
            return new CaisseDeposit
            {
                Caisse_ID = Properties.Settings.Default.DefaultCaisseId,
                Time = DateTime.Now.ToString("HH:mm:ss"),
                Date = DateTime.Now,
                Name = $"  {Properties.Settings.Default.UserName}  مشتري عادي  بحساب ",
                Money = value,
                Reason = "مبيعة سريعة",
                Type = "ايداع عن طريق بيع منتجات (مال ربحي )"
            };

        }
        public static bool Process = false;

        private async void btnPay_Click(object sender, EventArgs e)
        {
            ToasterHelper.PlayNotificationSound();
            if (!dgvHelper.IsEmpty(DgvِProducts))
                await PayNowAsync(false);


        }
        public void InitializeData(string paidUp, string remain)
        {
            Process = true;
            PaidUp = ConvertToFloat(paidUp);
            Remain = ConvertToFloat(remain);
        }
        async void HandleCaisseAndDeposits(decimal paidAmount, decimal totalAmount)
        {
            var amountToDeposit = Math.Min(paidAmount, totalAmount);
            _context.Update(SetCaisse(amountToDeposit));
            if (amountToDeposit > 0)
                _context.Add(SetCaisseDeposit(amountToDeposit));
        }
        private int saleID;
        async Task PayNowAsync(bool facture)
        {

            if (DgvِProducts.Rows.Count > 0 && rbSale.Checked)
            {
                if (IdCustomer.Text != Properties.Settings.Default.IdCustomerSale)
                {
                    AddPaymentForm addPaymentForm = _controlManager.GetF<AddPaymentForm>();
                    addPaymentForm.LoadData(TotalFacture.ToString(), TotalFacture.ToString(), "0", 3);
                    addPaymentForm.ShowDialog();
                    var customer = _context.Customers.FirstOrDefault(x => x.Id.ToString() == IdCustomer.Text);
                    if (customer.MaxDebtAllowed <= customer.TotalDebts + Remain && Remain > 0)
                    {
                        MsgHelper.ShowMaxDebtAllowedExceeded();
                        return;
                    }
                }
                else
                {
                    Process = true;
                    PaidUp = ConvertToFloat(TotalFacture.ToString());
                    Remain = 0;
                }
                if (Process)
                {
                    using (var transaction = await _context.Database.BeginTransactionAsync())
                    {
                        try
                        {

                            var sale = SetSale();
                            await _context.AddAsync(sale);
                            await _context.SaveChangesAsync();
                            saleID = sale.Id;

                            for (int i = 0; i < DgvِProducts.Rows.Count; i++)
                            {
                                var saleDetail = SetSaleDetail(i);
                                saleDetail.Order_ID = sale.Id;
                                await _context.SalesDetails.AddAsync(saleDetail);

                                _context.Update(SetProduct(i));


                                var buyPrice = SetProductQuentity(Convert.ToDecimal(DgvِProducts.Rows[i].Cells[2].Value.ToString()), i, sale.Id);
                                //var profit = SetSaleProfit(i, buyPrice);
                                //profit.Order_ID = sale.Id;
                                //await _context.AddAsync(profit);
                            }
                            HandleCaisseAndDeposits(PaidUp, TotalFacture);

                            if (PaidUp > 0)
                            {
                                var custReport = SetCustReport();
                                custReport.Order_ID = sale.Id;
                                await _context.AddAsync(custReport);
                            }
                            if (Remain > 0)
                            {
                                var custMoney = SetCustMoney();
                                custMoney.Order_ID = sale.Id;
                                await _context.AddAsync(custMoney);
                                _context.Update(SetCustomer());
                            }
                            await _context.SaveChangesAsync();
                            await transaction.CommitAsync();
                            Code.Helper.ToasterHelper.ShowNewSaleAdd();

                            ResetForm();
                        }
                        catch (Exception ex)
                        {
                            await transaction.RollbackAsync();

                            ToasterHelper.ShowErrorHappened(ex.Message);
                            throw;

                        }
                        if (facture && Properties.Settings.Default.PrintSaleOnOrOff)
                        {
                            //if (Properties.Settings.Default.PrintSaleOnOrOff)
                            //{

                            DataTable saleDetailsTable = await GetSellDetailsDataTableAsync(saleID);
                            string printername = Properties.Settings.Default.Printer8cm;
                            if (!printername.IsNullOrEmpty())
                                for (int i = 0; i < Properties.Settings.Default.NbrCopyOfSaleFacture; i++)
                                {
                                    if (Properties.Settings.Default.PrintSaleFactureType8cm)
                                    {
                                        Reports.sale8cm sale8Cm = _controlManager.GetR<Reports.sale8cm>();
                                        sale8Cm.DataSource = saleDetailsTable;

                                        // Force print to the specified printer
                                        var printTool = new DevExpress.XtraReports.UI.ReportPrintTool(sale8Cm);
                                        printTool.PrinterSettings.PrinterName = printername;
                                        await printTool.PrintAsync(printername);
                                    }
                                    else
                                    {
                                        Reports.SalesReports.salesA4 salesA4 = _controlManager.GetR<Reports.SalesReports.salesA4>();
                                        salesA4.DataSource = saleDetailsTable;
                                        printername = Properties.Settings.Default.PrinterA4;

                                        // Force print to the specified printer
                                        var printTool = new DevExpress.XtraReports.UI.ReportPrintTool(salesA4);
                                        printTool.PrinterSettings.PrinterName = printername;
                                        await printTool.PrintAsync(printername);
                                    }
                                }
                            //XtraForm1 xtraForm11 = new(sale8Cm);
                            //xtraForm11.ShowDialog();
                            //}
                            //else
                            //{
                            //}
                        }





                    }
                }
            }
            else if (DgvِProducts.Rows.Count > 0 && rbRefund.Checked)
            {
                using (var transaction = await _context.Database.BeginTransactionAsync())
                {
                    try
                    {
                        var refund = SetRefundSale();
                        _context.Add(refund);
                        _context.SaveChanges();

                        for (int i = 0; i < DgvِProducts.Rows.Count; i++)
                        {
                            var refundSaleDetail = SetRefundSaleDetail(i);
                            refundSaleDetail.Order_ID = refund.Id;
                            await _context.ReturnsDetails.AddAsync(refundSaleDetail);

                            var product = SetProductRefund(i, DgvِProducts.Rows[i].Cells[5].Value.ToString(), _context);
                            _context.Update(product);

                            //_context.Update(SetProductRefund(i, DgvِProducts.Rows[i].Cells[5].Value.ToString()));
                            SetProductQuantityAsync(i, _context);
                        }
                        await _context.SaveChangesAsync();


                        SetCaisseSaleRefund(TotalFacture, _context);
                        _context.CaissesWithdraws.Add(SetCaisseWithdraw(TotalFacture, _context));
                        await _context.SaveChangesAsync();


                        await transaction.CommitAsync();
                        Code.Helper.ToasterHelper.ShowAddedRefund();

                        CleanForm();

                    }
                    catch (Exception ex)
                    {
                        await transaction.RollbackAsync();
                        MessageBox.Show(ex.Message);
                    }
                }
            }
        }
        //private async Task ProcessRefundDetailsAsync(ApplicationDbContext context, int refundId)
        //{
        //    for (int i = 0; i < DgvِProducts.Rows.Count; i++)
        //    {
        //        var refundDetail = SetRefundSaleDetail(i);
        //        refundDetail.Order_ID = refundId;
        //        context.ReturnsDetails.Add(refundDetail);

        //        // Update product quantity
        //        var productId = DgvِProducts.Rows[i].Cells[5].Value?.ToString();
        //        if (productId != null)
        //        {
        //            var product = SetProductRefund(i, productId);
        //            context.Update(product);
        //            await SetProductQuantityAsync(i, context);
        //        }
        //    }
        //    await context.SaveChangesAsync();
        //}
        Caisse SetCaisseSaleRefund(decimal value, ApplicationDbContext context)
        {
            //dgvProducts.Rows[i].Cells[0].Value.ToString()

            Caisse caisse = context.Caisses.Where(x => x.Id == Properties.Settings.Default.DefaultCaisseId).FirstOrDefault();
            if (caisse is not null)
            {
                caisse.MoneyinCaisse -= value;
                context.Caisses.Update(caisse);
                context.SaveChanges();
            }
            return caisse;

        }
        CaisseWithdraw SetCaisseWithdraw(decimal value, ApplicationDbContext context)
        {
            //dgvProducts.Rows[i].Cells[0].Value.ToString()


            var caisseWithdraw = new CaisseWithdraw
            {
                Caisse_ID = Properties.Settings.Default.DefaultCaisseId,
                Time = DateTime.Now.ToString("yyyy:MM:dd:HH:mm"),
                Date = DateTime.Now,
                Name = $" ({Properties.Settings.Default.UserName})  العميل ({lblCustomerName.Text}) بحساب ",
                Money = value,
                Reason = $"ارجاع المنتوجات للمخزن ({(context.Stores.FirstOrDefault(x => x.Id == Properties.Settings.Default.FastSaleStore)).StoreName}) واعادة الاموال للعميل",
                Type = "سحب عن طريق ارجاع المنتوجات للمخزن وارجاع الاموال لصاحبها"
            };

            return caisseWithdraw;

        }
        private void SetProductQuantityAsync(int rowIndex, ApplicationDbContext context)
        {
            if (context == null)
                throw new ArgumentNullException(nameof(context));

            if (rowIndex < 0 || rowIndex >= DgvِProducts.Rows.Count)
                throw new ArgumentOutOfRangeException(nameof(rowIndex));

            try
            {
                // Determine the product ID based on the selected radio button
                var productId = DgvِProducts.Rows[rowIndex].Cells[5].Value?.ToString();

                if (string.IsNullOrEmpty(productId))
                    throw new InvalidOperationException("Product ID is missing or invalid.");

                // Parse the quantity to be updated
                if (!decimal.TryParse(DgvِProducts.Rows[rowIndex].Cells[2].Value?.ToString(), out decimal quantity))
                    throw new InvalidOperationException("Invalid quantity value.");
                ProductsQuantitie productQuantity = new();

                var productQty =
                     context.ProductsQuantities.Where(x => x.Pro_ID == Convert.ToInt32(productId)).OrderBy(x => x.Id)
                    .FirstOrDefault();
                if (productQty is not null)
                {

                    productQty.Qty += quantity;
                    context.Update(productQty);
                    context.SaveChanges();


                }


                //if (productQuantity is null)
                //    productQuantity = new ProductsQuantitie
                //    {
                //        Id = Convert.ToInt32(productId),
                //        Qty = 0,
                //        Store_ID = Properties.Settings.Default.FastSaleStore,
                //        Pro_ID = Convert.ToInt32(productId),
                //        StoreName = context.Stores.FirstOrDefault(x => x.Id == Properties.Settings.Default.FastSaleStore).StoreName,
                //        Buy_Price = context.Products.FirstOrDefault(x => x.Id.ToString() == productId).BuyPrice,
                //        Sale_PriceTax = _main.ConvertToFloat(DgvِProducts.Rows[rowIndex].Cells[1].Value.ToString()),
                //        DateExpiration = context.Products.FirstOrDefault(x => x.Id.ToString() == productId).DateExperation
                //    };

                //// Add the new product quantity record to the database
                //context.ProductsQuantities.Add(productQuantity);
                //await context.SaveChangesAsync();



                // Update the product quantity based on the operation
                //if (rbSale.Checked)
                //{
                //    // For buy refunds, add the quantity back to the product
                //    productQuantity.Qty = quantity;
                //}
                //else
                //{
                //    // For sale refunds, subtract the quantity from the product
                //    productQuantity.Qty = quantity;
                //}

                //// Save changes to the database
                //context.Update(productQuantity);
                //await context.SaveChangesAsync();
            }
            catch (Exception ex)
            {
                // Log the exception (consider using a logging framework like NLog or Serilog)
                ToasterHelper.ShowErrorHappened(ex.Message);
                throw; // Re-throw the exception to propagate it up the call stack
            }
        }

        Product SetProductRefund(int i, string idprod, ApplicationDbContext context)
        {
            //dgvProducts.Rows[i].Cells[0].Value.ToString()

            Product product = context.Products.FirstOrDefault(x => x.Id.ToString() == idprod);
            if (product is not null)
            {
                var qty = ConvertToFloat(DgvِProducts.Rows[i].Cells[2].Value.ToString());
                product.Quentity += qty;
            }
            return product;
        }
        private async Task<DataTable> GetSellDetailsDataTableAsync(int orderId)
        {


            var orderIdParam = new SqlParameter("@orderID", orderId);
            var connection = _context.Database.GetDbConnection();

            try
            {
                await connection.OpenAsync();


                using (var command = connection.CreateCommand())
                {
                    command.CommandText = "EXEC [dbo].[get_all_sell_details] @orderID";
                    command.CommandType = CommandType.Text;
                    command.Parameters.Add(orderIdParam);


                    using (var reader = await command.ExecuteReaderAsync())
                    {
                        DataTable sellDetailsTable = new DataTable();
                        sellDetailsTable.Load(reader);
                        await connection.CloseAsync();

                        return sellDetailsTable;
                    }
                }
            }
            finally
            {
                await connection.CloseAsync();
            }

        }
        Return SetRefundSale()
        {

            Return buy = new Return();

            buy.TotalOrder = TotalFacture;
            //buy.SupplierId = Convert.ToInt32(cmbSuppliers.SelectedValue);
            buy.OrderDate = DateTime.Now;
            buy.PaidUP = TotalFacture;
            buy.Remain = 0.00m;
            buy.Time = DateTime.Now.ToString("yyyy:MM:dd:HH:mm");
            buy.User_Name = Properties.Settings.Default.UserName;
            buy.OrderType = "Refund Sale";

            return buy;
        }
        ReturnDetail SetRefundSaleDetail(int i)
        {
            //dgvProducts.Rows[i].Cells[0].Value.ToString()
            ReturnDetail buyDetail = new ReturnDetail();

            buyDetail.Cust_Name = lblCustomerName.Text;
            buyDetail.Date = DateTime.Now.ToString("yyyy-MM-dd");
            buyDetail.Pro_ID = Convert.ToInt32(DgvِProducts.Rows[i].Cells[5].Value.ToString());
            buyDetail.Qty = ConvertToFloat(DgvِProducts.Rows[i].Cells[2].Value.ToString());
            buyDetail.Price = ConvertToFloat(DgvِProducts.Rows[i].Cells[1].Value.ToString());
            buyDetail.Total = ConvertToFloat(DgvِProducts.Rows[i].Cells[4].Value.ToString());
            buyDetail.TaxValue = Properties.Settings.Default.TaxValue;
            buyDetail.PriceWithTax = TotalFacture;
            return buyDetail;
        }
        private void btnChoseCustomer_Click(object sender, EventArgs e)
        {
            ToasterHelper.PlayNotificationSound();
            SelectCustomerForm SelectCustomerForm = _controlManager.GetF<SelectCustomerForm>();
            SelectCustomerForm.ShowDialog();
        }

        private async void button1_Click(object sender, EventArgs e)
        {
            ToasterHelper.PlayNotificationSound();
            if (!dgvHelper.IsEmpty(DgvِProducts))
                await PayNowAsync(true);

        }

        private void btnPrices_Click(object sender, EventArgs e)
        {
            ToasterHelper.PlayNotificationSound();
            if (btnPrices.Text == "سعر 1" || btnPrices.Text == "سعر 1 (F7)")
            {
                btnPrices.BackColor = Color.Yellow;
                btnPrices.Text = "سعر 2";
            }
            else if (btnPrices.Text == "سعر 2")
            {
                btnPrices.Text = "سعر 3";
                btnPrices.BackColor = Color.PaleVioletRed;

            }
            else
            {
                btnPrices.Text = "سعر 1";
                btnPrices.BackColor = Color.SeaGreen;

            }
        }

        private void rbSale_CheckedChanged_1(object sender, EventArgs e)
        {
            if (rbRefund.Checked)
            {
                ChangeLabelColeurs(Color.Red);
            }
            else
                ChangeLabelColeurs(Color.SeaGreen);
        }

        private void rbRefund_CheckedChanged_1(object sender, EventArgs e)
        {
            if (rbRefund.Checked)
            {
                ChangeLabelColeurs(Color.Red);
                btnPrices.Text = "سعر 3";
                btnPrices.BackColor = Color.PaleVioletRed;
            }
            else
            {
                ChangeLabelColeurs(Color.SeaGreen);
                btnPrices.Text = "سعر 1";
                btnPrices.BackColor = Color.SeaGreen;
            }
        }

        private void txtTotalSaleProduct_KeyDown(object sender, KeyEventArgs e)
        {
            if (e.KeyCode == Keys.Enter)
            {
                if (txtQty.Text != string.Empty && txtTotalSaleProduct.Text != string.Empty)
                    if (!(Convert.ToDecimal(txtQty.Text) > 0 && Convert.ToDecimal(txtTotalSaleProduct.Text) > 0))
                    {
                        txtQty.Text = "1";
                        txtTotalSaleProduct.Text = _product.SalePrice.ToString("f2");
                    }
                    else
                    {
                        BringTofront(false);
                        AddNewRow();
                        txtQty.Text = string.Empty;
                    }
            }
        }

        private void txtTotalSaleProduct_KeyPress(object sender, KeyPressEventArgs e)
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

        private void txtTotalSaleProduct_KeyUp(object sender, KeyEventArgs e)
        {

            if (txtTotalSaleProduct.Text != string.Empty)
            {
                try
                {
                    if (Convert.ToDecimal(txtSalePrice.Text) > 0)
                    {
                        txtQty.Text = (Convert.ToDecimal(txtTotalSaleProduct.Text)
                            / Convert.ToDecimal(txtSalePrice.Text)).ToString("f2");
                    }
                    if (txtSalePrice.Text != string.Empty && txtQty.Text != string.Empty
                         && txtSaleDiscount.Text != string.Empty)
                    {

                        txtSaleDiscount.Text = "0";

                    }

                }
                catch (Exception ex) { MessageBox.Show(ex.Message); }
            }

        }

        private void btnNext_Click(object sender, EventArgs e)
        {
            ToasterHelper.PlayNotificationSound();
            if (cmbpagination.SelectedIndex < cmbpagination.Items.Count - 1)
            {
                cmbpagination.SelectedIndex++;
                int skip = cmbpagination.SelectedIndex * Properties.Settings.Default.NoOfDataInDgvs;
                OnLoad(skip);

            }
        }
        void PaginationHide()
        {
            btnNext.Enabled = cmbpagination.SelectedIndex < cmbpagination.Items.Count - 1 && !dgvHelper.IsEmpty(DgvQuickProducts);
            btnPrev.Enabled = cmbpagination.SelectedIndex > 0 && !dgvHelper.IsEmpty(DgvQuickProducts);
            cmbpagination.Enabled = !dgvHelper.IsEmpty(DgvQuickProducts);
        }
        private void btnPrev_Click(object sender, EventArgs e)
        {
            ToasterHelper.PlayNotificationSound();
            if (cmbpagination.SelectedIndex > 0)
            {
                cmbpagination.SelectedIndex--;
                int skip = cmbpagination.SelectedIndex * Properties.Settings.Default.NoOfDataInDgvs;

                OnLoad(skip);
            }
        }

        private void cmbpagination_SelectionChangeCommitted(object sender, EventArgs e)
        {
            ToasterHelper.PlayNotificationSound();
            if (cmbpagination.SelectedIndex != -1)
            {
                int skip = cmbpagination.SelectedIndex * Properties.Settings.Default.NoOfDataInDgvs;
                OnLoad(skip);
            }
        }

        private void txtSearchBarCode_TextChanged(object sender, EventArgs e)
        {
            if (txtSearchBarCode.Text.Contains("-") || txtSearchBarCode.Text.Contains("+")
                || txtSearchBarCode.Text.Contains("="))
            {
                txtSearchBarCode.Text = txtSearchBarCode.Text.Replace("-", "").Replace("+", "").Replace("=", "").Trim();

            }
            txtSearchBarCode.Text.Replace("-", "").Replace("+", "").Replace("/", "");
            string cleaned = System.Text.RegularExpressions.Regex.Replace(txtSearchBarCode.Text, @"[\r\n\t]", "").Trim();

            if (txtSearchBarCode.Text != cleaned)
            {
                int cursorPos = txtSearchBarCode.SelectionStart;
                txtSearchBarCode.Text = cleaned;
                txtSearchBarCode.SelectionStart = Math.Min(cursorPos, txtSearchBarCode.Text.Length);
            }
        }
    }
}
