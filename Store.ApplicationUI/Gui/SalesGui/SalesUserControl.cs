using System.Data;
using DevExpress.XtraReports.UI;
using Microsoft.IdentityModel.Tokens;
using Store.ApplicationUI.Code.Helper;
using Store.ApplicationUI.Code.Models;
using Store.ApplicationUI.Gui.LoadingGui;
using Store.ApplicationUI.Gui.PaymentGui;
using Store.Core.Entities.Caisses;
using Store.Core.Entities.Customers;
using Store.Core.Entities.Helpers;
using Store.Core.Entities.Products;
using Store.Core.Entities.Sales;
using Store.Infrastructure.Data;
using Store.Infrastructure.Repositories;

namespace Store.ApplicationUI.Gui.SalesGui
{
    public partial class SalesUserControl : UserControl
    {
        private static SalesUserControl? _salesUserControl;
        private static MainForm? _main;
        public static SalesRepository? salesRepository;
        public static decimal PaidUp;
        public static decimal Remain;
        private static ApplicationDbContext _context;

        public SalesUserControl()
        {
            InitializeComponent();
        }
        public static SalesUserControl Instance(MainForm main)
        {
            _main = main;
            // If the instance is null, create a new one and assign it to the static field
            _context = new ApplicationDbContext();
            if (_salesUserControl == null)
            {
                salesRepository = new SalesRepository(_context);
                _salesUserControl = new SalesUserControl();
            }
            // Return the singleton instance
            _salesUserControl.LoadData();

            _salesUserControl.ResetFormBegin();
            return _salesUserControl;
        }

        public static bool CheckInstance()
        {
            return (_salesUserControl == null);
        }
        public static bool CheckIfitsOnFront()
        {
            return (_salesUserControl == null);
        }
        private void setPrivateProductAndAdditTotable(Product product)
        {
            txtSearchBarCode.Text = product.CodeBar;
            SetProductsToTable(product.CodeBar);
            AddNewRow();
        }
        public static bool setProductFromSelector(Product product)
        {
            if (product is not null)
            {
                _salesUserControl.setPrivateProductAndAdditTotable(product);
                return true;
            }
            return false;
        }
        public static void RefreshDgv()
        {
            //DgvِProducts.DataSource = await Task.Run(() => productsRepository.GetAllProducts());
            _salesUserControl.LoadData();
        }
        // methodes 
        public async void LoadData()
        {


            //ShowLoading
            LoadingForm.Instance(_main).Show();
            if (await Task.Run(() => salesRepository.IsConnected()))
            {
                ResetFormBegin();
                //Start Load Data
                txtFactureNumber.Text = salesRepository.GetFactureNumber();
                // if its an admin or Normal user 
                SetColumns();

                cmbCustomers.DataSource = _context.Customers.ToList();
                cmbCustomers.DisplayMember = "CustomerName";
                cmbCustomers.ValueMember = "Id";
                cmbCustomers.Text = "اختر العميل";

                cmbStores.DataSource = _context.Stores.ToList();
                cmbStores.DisplayMember = "StoreName";
                cmbStores.ValueMember = "Id";
                cmbStores.Text = "اختر مخزن";

                DtpDateFacture.Value = DateTime.Now;
                dtpReminderDate.Value = DateTime.Now.AddDays(Properties.Settings.Default.DaysAddDebt);

                cmbStores.SelectedValue = Properties.Settings.Default.StoreIdDefault;
                cmbStores.Text = _context.Stores.FirstOrDefault(x => x.Id == Properties.Settings.Default.StoreIdDefault).StoreName;



                //_data.Clear();
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
                DgvِProducts.Columns.Add("سعر البيع الجملة", "سعر البيع الجملة");
                DgvِProducts.Columns.Add("اجمالي البيع", "اجمالي البيع");
                DgvِProducts.Columns.Add("معرف المنتوج", "معرف المنتوج");
                DgvِProducts.Columns.Add("باركود", "باركود");
            }
            // Visible of Columns
            //DgvProducts.Columns[0].Visible = false;
            ////DgvِProducts.Columns[6].Visible = false;
            DgvِProducts.Columns[6].Visible = false;
            DgvِProducts.Columns[7].Visible = false;
            ////DgvِProducts.Columns[11].Visible = false;
            ////DgvِProducts.Columns[12].Visible = false;
            ////DgvِProducts.Columns[15].Visible = false;
            ////DgvِProducts.Columns[13].Visible = false;
            //DgvProducts.Columns[13].Visible = false;
            //DgvProducts.Columns[14].Visible = false;
            //DgvProducts.Columns[13].Visible = false;
            //DgvProducts.Columns[15].Visible = false;
        }
        public void InitializeTextBoxesAndLables(Product product)
        {
            try
            {
                var storeId = Convert.ToInt32(cmbStores.SelectedValue);
                var now = DateTime.Now;

                if (txtQty.Text.Contains("\r\n"))
                    txtQty.Text = "1";
                txtProductName.Text = product.ProductName;
                labelError1.Visible = product.Quentity <= 0;

                ProductsQuantitie productQty = _context.ProductsQuantities
                    .FirstOrDefault(x => x.Pro_ID == product.Id && x.Qty > 0 && x.Store_ID == storeId);

                lblError2.Visible = productQty is null;



                if (!string.IsNullOrEmpty(product.ColisageBareCode) && string.IsNullOrEmpty(txtQty.Text))
                {
                    txtQty.Text = product.ColisageBareCode == txtSearchBarCode.Text ?
                        product.NbrProductInColis.ToString() : "1";
                }
                else if (string.IsNullOrEmpty(txtQty.Text))
                {
                    txtQty.Text = "1";
                }
                decimal qty = !txtQty.Text.IsNullOrEmpty() ? Convert.ToDecimal(txtQty.Text) : 0;
                ProductDiscount productDiscount = _context.ProductDiscounts
                                 .FirstOrDefault(x => x.Pro_Id == product.Id && x.Quentity >= qty && x.Store_Id == storeId
                                     && x.DateStart <= now && x.DateEnd > now);
                if (productDiscount != null)
                {

                    txtSaleDiscount.Text = Code.Helper.FactureHelper.CalculateDiscountPercentage(product.SalePriceTax, productDiscount.DiscountValue).ToString();
                }
                else
                {
                    txtSaleDiscount.Text = "0";
                }
                txtTotalSaleProduct.Text = product.SalePriceTax.ToString();
                txtSalePrice.Text = product.SalePriceTax.ToString();
                txtWholeSalePrice.Text = product.WholesalePrice.ToString();
            }
            catch (Exception)
            {
                throw;
            }
        }
        public void InitializeTextBoxesAndLablesFromWeight(Product product, decimal weight)
        {
            try
            {
                var storeId = Convert.ToInt32(cmbStores.SelectedValue);
                var now = DateTime.Now;

                txtProductName.Text = product.ProductName;
                labelError1.Visible = product.Quentity <= 0;

                ProductsQuantitie productQty = _context.ProductsQuantities
                    .FirstOrDefault(x => x.Pro_ID == product.Id && weight > 0 && x.Store_ID == storeId);

                lblError2.Visible = productQty is null;





                ProductDiscount productDiscount = _context.ProductDiscounts
                                 .FirstOrDefault(x => x.Pro_Id == product.Id && x.Quentity >= weight && x.Store_Id == storeId
                                     && x.DateStart <= now && x.DateEnd > now);
                if (productDiscount != null)
                {
                    txtSaleDiscount.Text = Code.Helper.FactureHelper.CalculateDiscountPercentage(product.SalePriceTax, productDiscount.DiscountValue).ToString();
                }
                else
                {
                    txtSaleDiscount.Text = "0";
                }
                txtQty.Text = weight.ToString();
                txtTotalSaleProduct.Text = product.SalePriceTax.ToString();
                txtSalePrice.Text = product.SalePriceTax.ToString();
                txtWholeSalePrice.Text = product.WholesalePrice.ToString();
            }
            catch (Exception)
            {
                throw;
            }
        }

        public static void InitializeData(string paidUp, string remain)
        {
            PaidUp = _main.ConvertToFloat(paidUp);
            Remain = _main.ConvertToFloat(remain);
        }
        public void ClearBoxes()
        {
            txtProductName.Clear();
            txtSaleDiscount.Clear();
            txtQty.Clear();
            txtTotalSaleProduct.Clear();
            txtSalePrice.Clear();
            txtWholeSalePrice.Clear();

        }

        void CalculateAmount()
        {

            try
            {
                if (string.IsNullOrEmpty(txtSalePrice.Text) || string.IsNullOrEmpty(txtQty.Text) ||
                    string.IsNullOrEmpty(txtWholeSalePrice.Text) || string.IsNullOrEmpty(txtSaleDiscount.Text))
                    return;

                decimal discount = Convert.ToDecimal(txtSaleDiscount.Text);
                decimal amount = cbWholsale.Checked && discount == 0 ? Convert.ToDecimal(txtWholeSalePrice.Text) : Convert.ToDecimal(txtSalePrice.Text);
                decimal totalAmount = Math.Round(amount - (amount * (discount / 100)), 2);

                txtTotalSaleProduct.Text = (_main.ConvertToFloat(totalAmount.ToString()) * Convert.ToDecimal(txtQty.Text)).ToString();
            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.Message);
            }
        }
        private Product _product;
        private ProductDiscount _productDiscount;
        private ProductsQuantitie _productQuantitie;
        public async void SetProductsToTable(string barcode)
        {
            _product = salesRepository.GetProductBarCode(barcode);

            if (_product != null)
            {
                InitializeTextBoxesAndLables(_product);
                txtQty.Focus();
                txtQty.SelectAll();
                CalculateAmount();
            }
            else
            {
                MsgHelper.ShowEmptyResult();
                txtSearchBarCode.Focus();
                txtQty.Clear();
            }

            txtSearchBarCode.Clear();

        }

        private void btnRefresh_Click(object sender, EventArgs e)
        {
            ToasterHelper.PlayNotificationSound();
            DgvِProducts.Rows.Clear();
            lblEmptyData.Visible = dgvHelper.IsEmpty(DgvِProducts);
        }
        public void ParseScaleBarcode(string barcodeWeight)
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
            _product = salesRepository.GetProductBarCode(productBarCode);
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
        private void txtSearchBarCode_KeyDown(object sender, KeyEventArgs e)
        {
            if (e.KeyCode == Keys.Enter)
            {
                string input = txtSearchBarCode.Text.Trim().Replace("\r", "").Replace("\n", "");

                if (input.Length >= 2)
                {
                    string prefix = input.Substring(0, 2);
                    if (prefix == "21")
                    {
                        ParseScaleBarcode(input);
                    }
                    else
                    {
                        SetProductsToTable(input);
                    }
                }
                else if (input.Length > 0)
                {
                    SetProductsToTable(input); // fallback if it's short but not empty
                }

                txtSearchBarCode.Clear();
            }

            EditUsingPlusMinus(sender, e);
        }

        private void txtSearchBarCode_KeyPress(object sender, KeyPressEventArgs e)
        {
            //if (!char.IsDigit(e.KeyChar) && e.KeyChar != 8)
            //{
            //    e.Handled = true;
            //}
        }

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
                newRow.Cells[4].Value = txtWholeSalePrice.Text;
                newRow.Cells[5].Value = txtTotalSaleProduct.Text;

                newRow.Cells[6].Value = _product.Id;
                newRow.Cells[7].Value = _product.CodeBar;
                DgvِProducts.CurrentCell = DgvِProducts[0, DgvِProducts.Rows.Count - 1];

                ClearBoxes();
                txtSearchBarCode.Focus();
                txtQty.Clear();

            }
            catch (Exception ex) { MessageBox.Show(ex.Message); }

        }
        void AddNewRow()
        {


            if (labelError1.Visible)
                if (!MsgHelper.ShowErrorValidating()) return;
            if (txtProductName.Text != string.Empty && txtProductName.Text != "" && txtSalePrice.Text != string.Empty
                && txtWholeSalePrice.Text != string.Empty
                )
            {
                try
                {

                    for (int i = 0; i < DgvِProducts.Rows.Count; i++)
                    {
                        if (DgvِProducts.Rows[i].Cells[6].Value.ToString() == _product.Id.ToString())
                        {
                            MsgHelper.ShowDuplicatedItems();
                            txtSearchBarCode.Focus();
                            ClearBoxes();
                            return;
                        }
                    }
                    new_row();
                    CalculateStatistics();
                }
                catch (Exception ex) { MessageBox.Show(ex.Message); }

            }
            else
            {
                MsgHelper.ShowEmptyResult();
            }
            CalculateStatistics();
            txtQty.Clear();

        }

        private void txtQty_KeyDown(object sender, KeyEventArgs e)
        {
            if (e.KeyCode == Keys.Enter)
            {
                if (txtQty.Text.IsNullOrEmpty())
                {

                    return;
                }
                else
                    AddNewRow();
            }
            EditUsingPlusMinus(sender, e);
        }

        private void txtQty_KeyPress(object sender, KeyPressEventArgs e)
        {
            if (txtQty.Text.IsNullOrEmpty()) { return; }

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

        private void txtQty_KeyUp(object sender, KeyEventArgs e)
        {
            try
            {
                if (txtQty.Text.IsNullOrEmpty()) { return; }
                if (cmbStores.Text == "اختر مخزن") { MessageBox.Show("يرجى اختيار مخزن , راجع البيانات من فضلك", "بيانات غير كاملة"); cmbStores.Focus(); return; }
                InitializeTextBoxesAndLables(_product);
                CalculateAmount();

            }
            catch (Exception ex) { MessageBox.Show(ex.Message); }
        }

        public bool ValidatePay()
        {
            if (cmbCustomers.Text == "اختر العميل") { MessageBox.Show("يرجى اختيار عميل , راجع البيانات من فضلك", "بيانات غير كاملة"); cmbCustomers.Focus(); return false; }
            if (cmbStores.Text == "اختر مخزن") { MessageBox.Show("يرجى اختيار مخزن , راجع البيانات من فضلك", "بيانات غير كاملة"); cmbStores.Focus(); return false; }
            if (txtProductName.Text != string.Empty)
            { MessageBox.Show("لديك منتج قيد الاضافة , راجع البيانات من فضلك", "بيانات غير كاملة"); return false; }
            return true;
        }

        private void txtBuyPrice_KeyDown(object sender, KeyEventArgs e)
        {
            if (e.KeyCode == Keys.Enter)
            {
                AddNewRow();
            }
        }

        private void txtBuyPrice_KeyPress(object sender, KeyPressEventArgs e)
        {
            if (!char.IsDigit(e.KeyChar) && e.KeyChar != Properties.Settings.Default.DecimalSEP[0] && e.KeyChar != 8)
            {
                e.Handled = true;
            }
        }

        private void txtBuyPrice_KeyUp(object sender, KeyEventArgs e)
        {
            CalculateAmount();
        }
        int rowIndex;
        private decimal TotalFacture;

        private void btnUp_Click(object sender, EventArgs e)
        {
            try
            {
                ToasterHelper.PlayNotificationSound();
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
                    MsgHelper.ShowEmptyDataGridView();
                txtSearchBarCode.Focus();
            }
            catch (Exception ex) { MessageBox.Show(ex.Message); }
        }

        private void btnDown_Click(object sender, EventArgs e)
        {
            try
            {
                ToasterHelper.PlayNotificationSound();
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
                    MsgHelper.ShowEmptyDataGridView();
                txtSearchBarCode.Focus();
            }
            catch (Exception ex) { MessageBox.Show(ex.Message); }
        }
        void CalculateStatistics()
        {
            try
            {
                ErrorDetection();
                lblEmptyData.Visible = dgvHelper.IsEmpty(DgvِProducts);
                if (DgvِProducts.Rows.Count > 0)
                {
                    lblTotalPriceinFacture.Text = "المبلغ الاجمالي في الفاتورة :" +
                                         (from DataGridViewRow row in DgvِProducts.Rows
                                          where row.Cells[5].FormattedValue.ToString() != string.Empty
                                          select Convert.ToDecimal(row.Cells[5].FormattedValue)).Sum()
                                          .ToString("f2");
                    TotalFacture = (from DataGridViewRow row in DgvِProducts.Rows
                                    where row.Cells[5].FormattedValue.ToString() != string.Empty
                                    select Convert.ToDecimal(row.Cells[5].FormattedValue)).Sum();
                    lblTotalQuentity.Text = "اجمالي الكميات في الجدول :" +
                              (from DataGridViewRow row in DgvِProducts.Rows
                               where row.Cells[2].FormattedValue.ToString() != string.Empty
                               select Convert.ToDecimal(row.Cells[2].FormattedValue)).Sum()
                               .ToString("f2");
                    lblTotalProductsInTable.Text = $"مجموع المنتجات في الجدول: {DgvِProducts.Rows.Count}";
                }

            }
            catch (Exception)
            {

                throw;
            }

        }
        private void ResetForm()
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
                CalculateStatistics();

                // Reinitialize form data (e.g., reload initial data)
                LoadData(); // This is a method where you load initial data

                // Optionally reset focus to the first control
                // Set focus to the first control
            }
        }
        private void ResetFormBegin()
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
            CalculateStatistics();

            // Reinitialize form data (e.g., reload initial data)
            //LoadData(); // This is a method where you load initial data

            // Optionally reset focus to the first control
            // Set focus to the first control

        }
        private void btnDeleteSelected_Click(object sender, EventArgs e)
        {
            try
            {
                //(Keys.Delete);
                ToasterHelper.PlayNotificationSound();
                if (DgvِProducts.Rows.Count > 0)
                {
                    // rowIndex = dgvProducts.CurrentCell.RowIndex;
                    DgvِProducts.Rows.RemoveAt(DgvِProducts.CurrentRow.Index);
                    CalculateStatistics();

                    // dgvProducts.CurrentCell.Selected = true;
                }
                else return;
                DgvِProducts.Focus();
            }
            catch (Exception ex) { MessageBox.Show(ex.Message); }
        }

        private void DgvِProducts_RowsAdded(object sender, DataGridViewRowsAddedEventArgs e)
        {
            CalculateStatistics();
        }

        private void DgvِProducts_RowsRemoved(object sender, DataGridViewRowsRemovedEventArgs e)
        {
            CalculateStatistics();
        }
        Sale SetSale()
        {

            return new Sale
            {

                TotalOrder = _main.ConvertToFloat(TotalFacture.ToString()),
                CustomerId = Convert.ToInt32(cmbCustomers.SelectedValue),
                Date = DtpDateFacture.Value,
                PaidUP = _main.ConvertToFloat(PaidUp.ToString()),
                Remain = _main.ConvertToFloat(Remain.ToString()),
                Time = DateTime.Now.ToString("HH:mm"),
                User_Name = Properties.Settings.Default.UserName,
            };
        }
        CustomerReport SetCustReport()
        {
            return new CustomerReport
            {
                Order_ID = Convert.ToInt32(txtFactureNumber.Text),
                Cust_ID = Convert.ToInt32(cmbCustomers.SelectedValue),
                Cust_Name = cmbCustomers.Text,
                Date = DtpDateFacture.Value,
                Price = _main.ConvertToFloat(PaidUp.ToString()),
                Time = DateTime.Now.ToString("yyyy:MM:dd/HH:mm"),
            };
        }
        CustomerMoney SetCustMoney()
        {
            return new CustomerMoney
            {
                Order_ID = Convert.ToInt32(txtFactureNumber.Text),
                Cust_ID = Convert.ToInt32(cmbCustomers.SelectedValue),
                Cust_Name = cmbCustomers.Text,
                Order_Date = DtpDateFacture.Value,
                Price = _main.ConvertToFloat(Remain.ToString()),
                Time = DateTime.Now.ToString("yyyy:MM:dd/HH:mm"),
                Reminder_Date = dtpReminderDate.Value
            };
        }
        SaleDetail SetSaleDetail(int i)
        {
            var row = DgvِProducts.Rows[i];
            return new SaleDetail
            {
                Order_ID = Convert.ToInt32(txtFactureNumber.Text),
                Cust_ID = Convert.ToInt32(cmbCustomers.SelectedValue),
                Pro_ID = Convert.ToInt32(row.Cells[6].Value.ToString()),
                Quentity = _main.ConvertToFloat(row.Cells[2].Value.ToString()),
                Price = _main.ConvertToFloat(row.Cells[1].Value.ToString()),
                Total = _main.ConvertToFloat(row.Cells[5].Value.ToString()),
                TaxValue = Properties.Settings.Default.TaxValue,
                PriceWithTax = _main.ConvertToFloat(row.Cells[1].Value.ToString()),
                Discount = _main.ConvertToFloat(row.Cells[3].Value.ToString())
            };
        }
        SaleProfit SetSaleProfit(int i, decimal buyPrice, decimal qty)
        {

            var row = DgvِProducts.Rows[i];
            return new SaleProfit
            {
                Order_ID = Convert.ToInt32(txtFactureNumber.Text),
                Cust_Name = cmbCustomers.Text,
                Pro_ID = Convert.ToInt32(row.Cells[6].Value.ToString()),
                Quentity = qty,
                Price = _main.ConvertToFloat(row.Cells[1].Value.ToString()),
                Total = _main.ConvertToFloat(row.Cells[5].Value.ToString()),
                Buy_Price = buyPrice,
                Tax_Value = Properties.Settings.Default.TaxValue,
                Discount = _main.ConvertToFloat(row.Cells[3].Value.ToString()),
                Time = DateTime.Now.ToString("yyyy:MM:dd/HH:mm"),
                Price_Tax = _main.ConvertToFloat(row.Cells[1].Value.ToString())
            };


        }
        Product SetProduct(int i)
        {

            var proId = DgvِProducts.Rows[i].Cells[6].Value.ToString();
            var product = _context.Products.FirstOrDefault(x => x.Id.ToString() == proId);

            if (product != null)
            {
                product.Quentity -= _main.ConvertToFloat(DgvِProducts.Rows[i].Cells[2].Value.ToString());
                if (product.Quentity < 0)
                    product.Quentity = 0;

                ProductDiscount productDiscount = _context.ProductDiscounts.
                 Where(x => x.Pro_Id.ToString() == product.Id.ToString() && x.Quentity > 0

                 && x.Store_Id == Properties.Settings.Default.FastSaleStore
                 && x.DateStart <= DateTime.Now && x.DateEnd > DateTime.Now
                 ).FirstOrDefault();
                if (productDiscount != null)
                {

                    productDiscount.Quentity -= _main.ConvertToFloat(DgvِProducts.Rows[i].Cells[2].Value.ToString());
                    if (productDiscount.Quentity < 0)
                    {
                        productDiscount.Quentity = 0;

                        string alerttype = "انتهاء التخفيض";
                        string Message = $"انتهاء التخفيض الخاص بالمنتج {product.ProductName} الذي كان بسعر {productDiscount.DiscountValue}";
                        var alert = _context.AlertsTable.FirstOrDefault(x => x.AlertType == alerttype && x.Message == Message && !x.IsResolved);
                        if (alert == null)
                        {
                            AlertTable alertTable = new AlertTable();
                            alertTable.AlertType = alerttype;
                            alertTable.Message = Message;
                            alertTable.Priority = PriorityAlert.Low;
                            alertTable.CreatedDate = DateTime.Now;
                            alertTable.IsResolved = false;
                            alertTable.Category = LocalUser.User.UserName;
                            _context.Add(alertTable);
                            _context.SaveChanges();
                        }
                    }
                    _context.Update(productDiscount);
                    _context.SaveChanges();
                }
            }
            return product;
        }
        decimal SetProductQuentity(decimal quentity, int i, int sale_Id)
        {
            var proId = DgvِProducts.Rows[i].Cells[6].Value.ToString();
            decimal totalBuyPrice = 0;
            int count = 0;

            while (quentity > 0)
            {
                var productQty = _context.ProductsQuantities
                                 .FirstOrDefault(x => x.Qty > 0 && x.Pro_ID.ToString() == proId);

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
            var custId = Convert.ToInt32(cmbCustomers.SelectedValue);
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
            //dgvProducts.Rows[i].Cells[0].Value.ToString()

            return new CaisseDeposit
            {
                Caisse_ID = Properties.Settings.Default.DefaultCaisseId,
                Time = DateTime.Now.ToString("HH:mm:ss"),
                Date = DateTime.Now,
                Name = $"  {Properties.Settings.Default.UserName}  العميل {cmbCustomers.Text} بحساب ",
                Money = value,
                Reason = "مبيعة بالفاتورة لعميل",
                Type = "ايداع عن طريق بيع منتجات (مال ربحي )"
            };


        }

        private async void ProcessTransaction(decimal paymentAmount, bool isDebt)
        {
            _context = new ApplicationDbContext();
            int id = 0;
            using (var transaction = _context.Database.BeginTransaction())
            {
                try
                {
                    var sale = SetSale();
                    _context.Add(sale);
                    _context.SaveChanges();

                    for (int i = 0; i <= DgvِProducts.Rows.Count - 1; i++)
                    {
                        var saleDetail = SetSaleDetail(i);
                        saleDetail.Order_ID = sale.Id; // Set foreign key reference to Sale
                        _context.SalesDetails.Add(saleDetail);

                        _context.Update(SetProduct(i));
                        var buyPrice = SetProductQuentity(Convert.ToDecimal(DgvِProducts.Rows[i].Cells[2].Value.ToString()), i, sale.Id);

                    }
                    _context.SaveChanges();

                    // Handle Caisse and Customer updates
                    HandleFinancialUpdates(paymentAmount, isDebt, sale.Id);
                    transaction.Commit();
                    id = sale.Id;
                    Code.Helper.ToasterHelper.ShowNewSaleAdd();
                    ResetForm();
                }
                catch (Exception ex)
                {
                    transaction.Rollback();
                    MessageBox.Show(ex.Message);
                }
            }
            try
            {


                DataTable saleDetailsTable = await Code.Helper.FactureHelper.GetSellDetailsDataTableAsync(id);
                string printername = Properties.Settings.Default.Printer8cm;

                if (Properties.Settings.Default.PrintSaleFactureType8cm)
                {
                    Reports.sale8cm sale8Cm = new();
                    sale8Cm.DataSource = saleDetailsTable;

                    if (rbPrinterDirectly.Checked && !printername.IsNullOrEmpty())
                    {
                        for (int i = 0; i < Properties.Settings.Default.NbrCopyOfSaleFacture; i++)
                        {
                            var printTool = new DevExpress.XtraReports.UI.ReportPrintTool(sale8Cm);
                            printTool.PrinterSettings.PrinterName = printername;
                            printTool.Print(printername);
                        }
                    }
                    else if (rbAnalysis.Checked)
                    {
                        var xtraForm1 = Reports.ReportPerviwGui.PerviweForm.Instance(sale8Cm);
                        xtraForm1.Show();
                    }
                }
                else
                {
                    Reports.SalesReports.salesA4 salesA4 = new();
                    salesA4.DataSource = saleDetailsTable;
                    printername = Properties.Settings.Default.PrinterA4;

                    if (rbPrinterDirectly.Checked && !printername.IsNullOrEmpty())
                    {
                        for (int i = 0; i < Properties.Settings.Default.NbrCopyOfSaleFacture; i++)
                        {
                            var printTool = new DevExpress.XtraReports.UI.ReportPrintTool(salesA4);
                            printTool.PrinterSettings.PrinterName = printername;
                            printTool.Print(printername);
                        }

                    }
                    else if (rbAnalysis.Checked)
                    {
                        var xtraForm1 = Reports.ReportPerviwGui.PerviweForm.Instance(salesA4);
                        xtraForm1.Show();
                    }

                }

            }
            catch (Exception ex)
            {

                MessageBox.Show(ex.Message);
                throw;
            }

        }

        private void HandleFinancialUpdates(decimal paymentAmount, bool isDebt, int saleId)
        {
            if (paymentAmount <= TotalFacture)
            {
                _context.Update(SetCaisse(paymentAmount));
                _context.SaveChanges();
                if (paymentAmount > 0)
                {
                    _context.Add(SetCaisseDeposit(paymentAmount));
                    _context.SaveChanges();
                }
            }
            else
            {
                _context.Update(SetCaisse(TotalFacture));
                _context.SaveChanges();
                if (TotalFacture > 0)
                {

                    _context.Add(SetCaisseDeposit(TotalFacture));
                    _context.SaveChanges();
                }

            }

            if (PaidUp > 0)
            {
                var custReport = SetCustReport();
                custReport.Order_ID = saleId;
                _context.Add(custReport);
                _context.SaveChanges();
            }

            if (Remain > 0)
            {
                var custMoney = SetCustMoney();
                custMoney.Order_ID = saleId;
                _context.Add(custMoney);
                _context.SaveChanges();

                _context.Update(SetCustomer());
                _context.SaveChanges();
            }

            _context.SaveChanges();
        }
        public static bool Process = false;

        private void btnPay_Click(object sender, EventArgs e)
        {
            ToasterHelper.PlayNotificationSound();
            if (!(DgvِProducts.Rows.Count > 0))
                return;
            if (ValidatePay())
            {
                AddPaymentForm addPaymentForm = new(_main, 1);
                if (rBPayPartial.Checked || rBPayDebt.Checked)
                {

                    addPaymentForm.LoadData(TotalFacture.ToString(), "0", TotalFacture.ToString());
                    addPaymentForm.ShowDialog();
                    if (Process)
                    {
                        if (cmbCustomers.SelectedValue.ToString() != Properties.Settings.Default.IdCustomerSale)
                        {
                            var customer = _context.Customers.FirstOrDefault(x => x.Id.ToString() == cmbCustomers.SelectedValue.ToString());
                            if (customer.MaxDebtAllowed <= customer.TotalDebts + Remain && Remain > 0)
                            {
                                MsgHelper.ShowMaxDebtAllowedExceeded();
                                return;
                            }
                        }
                        ProcessTransaction(PaidUp, rBPayPartial.Checked || rBPayDebt.Checked || Remain > 0);
                    }
                }
                else if (rBPayCash.Checked)
                {
                    addPaymentForm.LoadData(TotalFacture.ToString(), TotalFacture.ToString(), "0");
                    addPaymentForm.ShowDialog();
                    if (Process)
                    {
                        if (cmbCustomers.SelectedValue.ToString() != Properties.Settings.Default.IdCustomerSale)
                        {
                            var customer = _context.Customers.FirstOrDefault(x => x.Id.ToString() == cmbCustomers.SelectedValue.ToString());
                            if (customer.MaxDebtAllowed <= customer.TotalDebts + Remain && Remain > 0)
                            {
                                MsgHelper.ShowMaxDebtAllowedExceeded();
                                return;
                            }
                        }
                        ProcessTransaction(PaidUp, false || Remain > 0);
                    }
                }

            }
        }

        private void txtTotalBuyProduct_KeyPress(object sender, KeyPressEventArgs e)
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

        private void txtWholeSalePrice_KeyPress(object sender, KeyPressEventArgs e)
        {
            if (!char.IsDigit(e.KeyChar) && e.KeyChar != Properties.Settings.Default.DecimalSEP[0] && e.KeyChar != 8)
            {
                e.Handled = true;
            }
        }

        private void txtSalePrice_KeyDown(object sender, KeyEventArgs e)
        {
            if (e.KeyCode == Keys.Enter)
            {
                AddNewRow();
            }
        }

        private void txtSalePrice_KeyUp(object sender, KeyEventArgs e)
        {
            ErrorDetection();
            CalculateAmount();
        }

        void ErrorDetection()
        {
            //if (txtWholeSalePrice.Text == string.Empty || txtPriceWithTax.Text == string.Empty)
            //{
            //    labelError1.Visible = false;
            //    return;
            //}
            //try
            //{
            //    if (Convert.ToDouble(txtWholeSalePrice.Text) > Convert.ToDouble(txtPriceWithTax.Text))
            //    {
            //        labelError1.Visible = true;
            //    }
            //    else labelError1.Visible = false;
            //}
            //catch (Exception)
            //{

            //    throw;
            //}
        }
        void EditFromTable(int q)
        {
            try
            {
                if (dgvHelper.IsEmpty(DgvِProducts)) { MsgHelper.ShowEmptyDataGridView(); }
                if (!dgvHelper.IsEmpty(DgvِProducts))
                {
                    _product = salesRepository.GetProductBarCode(DgvِProducts.CurrentRow.Cells[7].Value.ToString());
                    txtProductName.Text = this.DgvِProducts.CurrentRow.Cells[0].Value.ToString();
                    txtSaleDiscount.Text = this.DgvِProducts.CurrentRow.Cells[3].Value.ToString();
                    txtQty.Text = (_main.ConvertToFloat(DgvِProducts.CurrentRow.Cells[2].Value.ToString()) + q).ToString();
                    txtTotalSaleProduct.Text = this.DgvِProducts.CurrentRow.Cells[5].Value.ToString();
                    txtSalePrice.Text = this.DgvِProducts.CurrentRow.Cells[1].Value.ToString();
                    txtWholeSalePrice.Text = this.DgvِProducts.CurrentRow.Cells[4].Value.ToString();

                    ProductDiscount productDiscount = _context.ProductDiscounts.
                   Where(x => x.Pro_Id == _product.Id && x.Quentity > 0

                   && x.Store_Id == Properties.Settings.Default.FastSaleStore
                   && x.DateStart <= DateTime.Now && x.DateEnd > DateTime.Now
                   ).FirstOrDefault();

                    if (productDiscount != null && !cbWholsale.Checked && _main.ConvertToFloat(txtQty.Text) <= productDiscount.Quentity)
                    {
                        txtSaleDiscount.Text = Code.Helper.FactureHelper.CalculateDiscountPercentage(_product.SalePriceTax, productDiscount.DiscountValue).ToString();
                    }
                    else
                    {
                        txtSaleDiscount.Text = "0";
                    }

                    txtQty.Focus();
                    CalculateAmount();
                    CalculateStatistics();
                    labelError1.Visible = _product.Quentity <= _main.ConvertToFloat(txtQty.Text);
                    ProductsQuantitie productQty = _context.ProductsQuantities.
                              Where(x => x.Pro_ID == _product.Id && x.Qty >= _main.ConvertToFloat(txtQty.Text)
                              && x.Store_ID.ToString() == cmbStores.SelectedValue).FirstOrDefault();

                    lblError2.Visible = productQty is null;

                    DgvِProducts.Rows.RemoveAt(DgvِProducts.CurrentRow.Index);
                }

            }
            catch (Exception ex) { MessageBox.Show(ex.Message); }

        }

        private void btnEditSelected_Click(object sender, EventArgs e)
        {
            ToasterHelper.PlayNotificationSound();
            EditFromTable(0);
        }


        void EditUsingPlusMinus(object sender, KeyEventArgs e)
        {
            if (e.KeyCode == Keys.Oemplus)
            {
                EditFromTable(1);
                CalculateAmount();
                AddNewRow();
            }
            else if (e.KeyCode == Keys.OemMinus)
            {
                EditFromTable(-1);
                CalculateAmount();
                AddNewRow();
            }
        }
        private void DgvِProducts_KeyDown(object sender, KeyEventArgs e)
        {

            EditUsingPlusMinus(sender, e);
        }

        private void SalesUserControl_KeyDown(object sender, KeyEventArgs e)
        {

            EditUsingPlusMinus(sender, e);
        }

        private void btnSearchImage_Click(object sender, EventArgs e)
        {
            ToasterHelper.PlayNotificationSound();
            SelectProductsForm selectProductsForm = SelectProductsForm.Instance(_main, false);
            selectProductsForm.ShowDialog();
        }

        private void DgvِProducts_CellDoubleClick(object sender, DataGridViewCellEventArgs e)
        {
            EditFromTable(0);

        }

        private void lblQuentity_Click(object sender, EventArgs e)
        {

        }
    }
}
