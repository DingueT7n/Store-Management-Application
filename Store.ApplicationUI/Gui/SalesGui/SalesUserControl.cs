using Store.ApplicationUI.Code.Helper;
using Store.ApplicationUI.Gui.LoadingGui;
using Store.ApplicationUI.Gui.PaymentGui;
using Store.Core.Entities.Customers;
using Store.Core.Entities.Products;
using Store.Core.Entities.Sales;
using Store.Infrastructure.Repositories;

namespace Store.ApplicationUI.Gui.SalesGui
{
    public partial class SalesUserControl : UserControl
    {
        private static SalesUserControl? _salesUserControl;
        private static MainForm? _main;
        public static SalesRepository? salesRepository;
        public static float PaidUp;
        public static float Remain;
        public SalesUserControl()
        {
            InitializeComponent();
        }
        public static SalesUserControl Instance(MainForm main)
        {
            _main = main;
            // If the instance is null, create a new one and assign it to the static field
            if (_salesUserControl == null)
            {
                salesRepository = new SalesRepository(MainForm.Context);
                _salesUserControl = new SalesUserControl();
            }
            // Return the singleton instance
            //_salesUserControl.LoadData();

            _salesUserControl.ResetForm();
            return _salesUserControl;
        }

        public static bool CheckInstance()
        {
            return (_salesUserControl == null);
        }
        private void setPrivateProductAndAdditTotable(Product product)
        {
            txtSearchBarCode.Text = product.CodeBar;
            SetProductsToTable();
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
                //Start Load Data
                txtFactureNumber.Text = salesRepository.GetFactureNumber();
                // if its an admin or Normal user 
                SetColumns();

                cmbCustomers.DataSource = MainForm.Context.Customers.ToList();
                cmbCustomers.DisplayMember = "CustomerName";
                cmbCustomers.ValueMember = "Id";
                cmbCustomers.Text = "اختر العميل";

                cmbStores.DataSource = MainForm.Context.Stores.ToList();
                cmbStores.DisplayMember = "StoreName";
                cmbStores.ValueMember = "Id";
                cmbStores.Text = "اختر مخزن";

                DtpDateFacture.Value = DateTime.Now;
                dtpReminderDate.Value = DateTime.Now.AddDays(30);


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

            ProductDiscount productDiscount = MainForm.Context.ProductDiscounts.
                Where(x => x.Id.ToString() == product.Id.ToString() && x.Quentity > 0

                && x.Store_Id == Convert.ToInt32(cmbStores.SelectedValue)
                && x.DateStart <= DateTime.Now && x.DateEnd > DateTime.Now
                ).FirstOrDefault();
            txtProductName.Text = product.ProductName;
            labelError1.Visible = product.Quentity <= 0;

            ProductsQuantitie productQty = MainForm.Context.ProductsQuantities.
                      Where(x => x.Pro_ID == product.Id && x.Qty > 0 && x.Store_ID.ToString() == cmbStores.SelectedValue).FirstOrDefault();

            lblError2.Visible = productQty is null;

            if (productDiscount is not null)
                txtSaleDiscount.Text = productDiscount.DiscountValue.ToString();
            else txtSaleDiscount.Text = 0.ToString();
            if (txtQty.Text != string.Empty)
            {
                if (product.Quentity < _main.ConvertToFloat(txtQty.Text))
                {
                    txtQty.Text = product.Quentity.ToString();
                }
            }
            else
            {
                txtQty.Text = "1";
            }


            txtTotalSaleProduct.Text = product.SalePriceTax.ToString();
            txtSalePrice.Text = product.SalePriceTax.ToString();
            txtWholeSalePrice.Text = product.WholesalePrice.ToString();


        }
        public static void InitializeData(string paidUp, string remain)
        {
            PaidUp = _main.ConvertToFloat(paidUp);
            Remain = _main.ConvertToFloat(remain);
        }
        public void ClearBoxes()
        {
            txtProductName.Text = string.Empty;
            txtSaleDiscount.Text = string.Empty;
            txtQty.Text = string.Empty;
            txtTotalSaleProduct.Text = string.Empty;
            txtSalePrice.Text = string.Empty;
            txtWholeSalePrice.Text = string.Empty;

        }

        void CalculateAmount()
        {
            try
            {
                if (txtSalePrice.Text != string.Empty && txtQty.Text != string.Empty && txtWholeSalePrice.Text
                    != string.Empty && txtSaleDiscount.Text != string.Empty)
                {
                    if (cbWholsale.Checked)
                    {
                        double Discount = Convert.ToDouble(txtSaleDiscount.Text);
                        double Amount = Convert.ToDouble(txtWholeSalePrice.Text);
                        double TotalAmount = Amount - (Amount * (Discount / 100));

                        txtTotalSaleProduct.Text = (_main.ConvertToFloat(TotalAmount.ToString()) * Convert.ToInt32(txtQty.Text)).ToString();
                    }
                    else
                    {
                        double Discount = Convert.ToDouble(txtSaleDiscount.Text);
                        double Amount = Convert.ToDouble(txtSalePrice.Text);
                        double TotalAmount = Amount - (Amount * (Discount / 100));
                        txtTotalSaleProduct.Text = (_main.ConvertToFloat(TotalAmount.ToString()) * Convert.ToInt32(txtQty.Text)).ToString();
                    }
                }
                if (txtSalePrice.Text != string.Empty && _product is not null)
                {


                }
            }
            catch (Exception ex) { MessageBox.Show(ex.Message); }
        }
        private Product _product;
        private ProductDiscount _productDiscount;
        private ProductsQuantitie _productQuantitie;
        public async void SetProductsToTable()
        {
            //DgvProducts.DataSource = await Task.Run(() => productsRepository.GetAll(p => p.Category));
            _product = salesRepository.GetProductBarCode(txtSearchBarCode.Text);
            if (_product is not null)
            {
                InitializeTextBoxesAndLables(_product);

                txtQty.Focus();
                txtQty.SelectAll();
                CalculateAmount();
                CalculateStatistics();
            }
            else
            {
                MsgHelper.ShowEmptyResult();
                txtSearchBarCode.Focus();

            }
            txtSearchBarCode.Clear();

        }

        private void btnRefresh_Click(object sender, EventArgs e)
        {
            DgvِProducts.Rows.Clear();
            lblEmptyData.Visible = dgvHelper.IsEmpty(DgvِProducts);
        }

        private void txtSearchBarCode_KeyDown(object sender, KeyEventArgs e)
        {
            if (e.KeyCode == Keys.Enter)
            {
                SetProductsToTable();
            }
            EditUsingPlusMinus(sender, e);
        }

        private void txtSearchBarCode_KeyPress(object sender, KeyPressEventArgs e)
        {
            if (!char.IsDigit(e.KeyChar) && e.KeyChar != 8)
            {
                e.Handled = true;
            }
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
        }

        private void txtQty_KeyDown(object sender, KeyEventArgs e)
        {
            if (e.KeyCode == Keys.Enter)
            {
                AddNewRow();
            }
            EditUsingPlusMinus(sender, e);
        }

        private void txtQty_KeyPress(object sender, KeyPressEventArgs e)
        {
            if (!char.IsDigit(e.KeyChar) && e.KeyChar != Properties.Settings.Default.DecimalSEP[0] && e.KeyChar != 8)
            {
                e.Handled = true;
            }
        }

        private void txtQty_KeyUp(object sender, KeyEventArgs e)
        {
            try
            {
                if (cmbStores.Text == "اختر مخزن") { MessageBox.Show("يرجى اختيار مخزن , راجع البيانات من فضلك", "بيانات غير كاملة"); cmbStores.Focus(); return; }
                CalculateAmount();
                InitializeTextBoxesAndLables(_product);

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
        private double TotalFacture;

        private void btnUp_Click(object sender, EventArgs e)
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
                    MsgHelper.ShowEmptyDataGridView();
                txtSearchBarCode.Focus();
            }
            catch (Exception ex) { MessageBox.Show(ex.Message); }
        }

        private void btnDown_Click(object sender, EventArgs e)
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
                if (DgvِProducts.Rows.Count >= 0)
                {
                    lblTotalPriceinFacture.Text = "المبلغ الاجمالي في الفاتورة :" +
                                         (from DataGridViewRow row in DgvِProducts.Rows
                                          where row.Cells[5].FormattedValue.ToString() != string.Empty
                                          select Convert.ToDouble(row.Cells[5].FormattedValue)).Sum()
                                          .ToString("f2");
                    TotalFacture = (from DataGridViewRow row in DgvِProducts.Rows
                                    where row.Cells[5].FormattedValue.ToString() != string.Empty
                                    select Convert.ToDouble(row.Cells[5].FormattedValue)).Sum();
                    lblTotalQuentity.Text = "اجمالي الكميات في الجدول :" +
                              (from DataGridViewRow row in DgvِProducts.Rows
                               where row.Cells[2].FormattedValue.ToString() != string.Empty
                               select Convert.ToDouble(row.Cells[2].FormattedValue)).Sum()
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

        private void btnDeleteSelected_Click(object sender, EventArgs e)
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

            Sale sale = new Sale();

            sale.TotalOrder = _main.ConvertToFloat(TotalFacture.ToString());
            sale.CustomerId = Convert.ToInt32(cmbCustomers.SelectedValue);
            sale.Date = DtpDateFacture.Value;
            sale.PaidUP = _main.ConvertToFloat(PaidUp.ToString());
            sale.Remain = _main.ConvertToFloat(Remain.ToString());
            sale.Time = DateTime.Now.ToString("HH:mm");
            sale.User_Name = "Alaa";
            return sale;
        }
        CustomerReport SetCustReport()
        {
            CustomerReport custReport = new CustomerReport();
            custReport.Order_ID = Convert.ToInt32(txtFactureNumber.Text);
            custReport.Cust_ID = Convert.ToInt32(cmbCustomers.SelectedValue);
            custReport.Cust_Name = cmbCustomers.Text;
            custReport.Date = DtpDateFacture.Value;
            custReport.Price = _main.ConvertToFloat(PaidUp.ToString());
            custReport.Time = DateTime.Now.ToString("HH:mm");
            return custReport;
        }
        CustomerMoney SetCustMoney()
        {

            CustomerMoney customerMoney = new CustomerMoney();
            customerMoney.Order_ID = Convert.ToInt32(txtFactureNumber.Text);
            customerMoney.Cust_ID = Convert.ToInt32(cmbCustomers.SelectedValue);
            customerMoney.Cust_Name = cmbCustomers.Text;
            customerMoney.Order_Date = DtpDateFacture.Value;
            customerMoney.Price = _main.ConvertToFloat(Remain.ToString());
            customerMoney.Time = DateTime.Now.ToString("HH:mm");
            customerMoney.Reminder_Date = dtpReminderDate.Value;
            return customerMoney;
        }
        SaleDetail SetSaleDetail(int i)
        {
            //dgvProducts.Rows[i].Cells[0].Value.ToString()
            SaleDetail saleDetail = new SaleDetail();
            saleDetail.Order_ID = Convert.ToInt32(txtFactureNumber.Text);
            saleDetail.Cust_ID = Convert.ToInt32(cmbCustomers.SelectedValue);
            saleDetail.Pro_ID = Convert.ToInt32(DgvِProducts.Rows[i].Cells[6].Value.ToString());
            saleDetail.Quentity = _main.ConvertToFloat(DgvِProducts.Rows[i].Cells[2].Value.ToString());
            saleDetail.Price = _main.ConvertToFloat(DgvِProducts.Rows[i].Cells[1].Value.ToString());
            saleDetail.Total = _main.ConvertToFloat(DgvِProducts.Rows[i].Cells[5].Value.ToString());
            saleDetail.TaxValue = Properties.Settings.Default.TaxValue;
            saleDetail.PriceWithTax = _main.ConvertToFloat(DgvِProducts.Rows[i].Cells[1].Value.ToString());
            return saleDetail;
        }
        SaleProfit SetSaleProfit(int i)
        {
            //dgvProducts.Rows[i].Cells[0].Value.ToString()
            SaleProfit SaleProfit = new SaleProfit();
            SaleProfit.Order_ID = Convert.ToInt32(txtFactureNumber.Text);
            SaleProfit.Cust_Name = cmbCustomers.Text;
            SaleProfit.Pro_ID = Convert.ToInt32(DgvِProducts.Rows[i].Cells[6].Value.ToString());
            SaleProfit.Quentity = _main.ConvertToFloat(DgvِProducts.Rows[i].Cells[2].Value.ToString());
            SaleProfit.Price = _main.ConvertToFloat(DgvِProducts.Rows[i].Cells[1].Value.ToString());
            SaleProfit.Total = _main.ConvertToFloat(DgvِProducts.Rows[i].Cells[5].Value.ToString());
            //SaleProfit.TaxValue = Properties.Settings.Default.TaxValue;
            //SaleProfit.PriceWithTax = _main.ConvertToFloat(DgvِProducts.Rows[i].Cells[1].Value.ToString());
            return SaleProfit;
        }
        Product SetProduct(int i)
        {
            //dgvProducts.Rows[i].Cells[0].Value.ToString()
            var proId = DgvِProducts.Rows[i].Cells[6].Value.ToString();
            Product product = MainForm.Context.Products.Where(x => x.Id.ToString() == proId
           /* && x.CodeBar == DgvِProducts.Rows[i].Cells[6].Value.ToString()*/).FirstOrDefault();
            if (product is not null)
            {
                if (product.Quentity - _main.ConvertToFloat(DgvِProducts.Rows[i].Cells[2].Value.ToString()) > 0)
                    product.Quentity = product.Quentity - _main.ConvertToFloat(DgvِProducts.Rows[i].Cells[2].Value.ToString());
                else product.Quentity = 0;

            }
            return product;
        }
        void SetProductQuentity(double Quentity, int i)
        {
            //dgvProducts.Rows[i].Cells[0].Value.ToString()
            var proId = DgvِProducts.Rows[i].Cells[6].Value.ToString();
            while (Quentity > 0)
            {

                ProductsQuantitie productQty = MainForm.Context.ProductsQuantities.
                        Where(x => x.Pro_ID.ToString() == proId && x.Qty > _main.ConvertToFloat(0.ToString())).FirstOrDefault();
                if (productQty is not null)
                {
                    if (productQty.Qty >= _main.ConvertToFloat(Quentity.ToString()))
                    {
                        productQty.Qty = productQty.Qty - _main.ConvertToFloat(Quentity.ToString());
                        MainForm.Context.ProductsQuantities.Update(productQty);
                        Quentity = 0;

                    }
                    else
                    {
                        Quentity = Quentity - productQty.Qty;
                        productQty.Qty = 0;
                        MainForm.Context.ProductsQuantities.Update(productQty);
                    }
                    if (productQty.Qty == 0) return;
                }
                else
                {

                    return;
                }
            }
            //return product;

        }
        Customer SetCustomer()
        {
            //dgvProducts.Rows[i].Cells[0].Value.ToString()
            var custId = Convert.ToInt32(cmbCustomers.SelectedValue);
            Customer customer = MainForm.Context.Customers.Where(x => x.Id == custId).FirstOrDefault();
            if (customer is not null)
            {
                customer.TotalDebts = customer.TotalDebts + Remain;
            }
            return customer;
        }


        private async void btnPay_Click(object sender, EventArgs e)
        {
            if (ValidatePay())
            {
                AddPaymentForm addPaymentForm = new(_main, 1);

                if (rBPayCash.Checked)
                {
                    addPaymentForm.LoadData(TotalFacture.ToString(), TotalFacture.ToString(), "0");
                    addPaymentForm.ShowDialog();
                    if (PaidUp >= TotalFacture)
                    {
                        using (var transaction = MainForm.Context.Database.BeginTransaction())
                        {
                            try
                            {
                                var sale = SetSale();
                                MainForm.Context.Add(sale);
                                await MainForm.Context.SaveChangesAsync();

                                for (int i = 0; i <= DgvِProducts.Rows.Count - 1; i++)
                                {
                                    var saleDetail = SetSaleDetail(i);
                                    saleDetail.Order_ID = sale.Id; // Set foreign key reference to Buy

                                    MainForm.Context.SalesDetails.Add(saleDetail);

                                    // Update product and add quantity
                                    MainForm.Context.Update(SetProduct(i));
                                    SetProductQuentity(Convert.ToDouble(DgvِProducts.Rows[i].Cells[2].Value.ToString()), i);


                                }
                                await MainForm.Context.SaveChangesAsync();
                                if (PaidUp > 0)
                                {
                                    var CustReport = SetCustReport();
                                    CustReport.Order_ID = sale.Id; // Set foreign key reference to Buy
                                    MainForm.Context.Add(CustReport);
                                }
                                if (Remain > 0)
                                {
                                    var CustMoney = SetCustMoney();
                                    CustMoney.Order_ID = sale.Id; // Set foreign key reference to Buy
                                    MainForm.Context.Add(CustMoney);

                                    // Update supplier details
                                    MainForm.Context.Update(SetCustomer());
                                }
                                await MainForm.Context.SaveChangesAsync();
                                await transaction.CommitAsync();

                            }
                            catch (Exception ex)
                            {
                                await transaction.RollbackAsync();
                                MessageBox.Show(ex.Message);
                            }
                        }
                    }
                    else
                    {

                    }
                }
                else if (rBPayDebt.Checked)
                {
                    addPaymentForm.LoadData(TotalFacture.ToString(), "0", TotalFacture.ToString());
                    addPaymentForm.ShowDialog();
                    if (PaidUp < TotalFacture)
                    {
                        using (var transaction = MainForm.Context.Database.BeginTransaction())
                        {
                            try
                            {
                                var sale = SetSale();
                                MainForm.Context.Add(sale);
                                await MainForm.Context.SaveChangesAsync();

                                for (int i = 0; i <= DgvِProducts.Rows.Count - 1; i++)
                                {
                                    var saleDetail = SetSaleDetail(i);
                                    saleDetail.Order_ID = sale.Id; // Set foreign key reference to Buy

                                    MainForm.Context.SalesDetails.Add(saleDetail);

                                    // Update product and add quantity
                                    MainForm.Context.Update(SetProduct(i));
                                    SetProductQuentity(Convert.ToDouble(DgvِProducts.Rows[i].Cells[2].Value.ToString()), i);


                                }
                                await MainForm.Context.SaveChangesAsync();
                                if (PaidUp > 0)
                                {
                                    var CustReport = SetCustReport();
                                    CustReport.Order_ID = sale.Id; // Set foreign key reference to Buy
                                    MainForm.Context.Add(CustReport);
                                }
                                if (Remain > 0)
                                {
                                    var CustMoney = SetCustMoney();
                                    CustMoney.Order_ID = sale.Id; // Set foreign key reference to Buy
                                    MainForm.Context.Add(CustMoney);

                                    // Update supplier details
                                    MainForm.Context.Update(SetCustomer());
                                }
                                await MainForm.Context.SaveChangesAsync();
                                await transaction.CommitAsync();


                            }
                            catch (Exception ex)
                            {
                                await transaction.RollbackAsync();
                                MessageBox.Show(ex.Message);
                            }
                        }
                    }
                    else
                    {

                    }
                }
                else
                {
                    addPaymentForm.LoadData(TotalFacture.ToString(), TotalFacture.ToString(), "0");
                    addPaymentForm.ShowDialog();
                    if (PaidUp <= TotalFacture)
                    {
                        using (var transaction = MainForm.Context.Database.BeginTransaction())
                        {
                            try
                            {
                                var sale = SetSale();
                                MainForm.Context.Add(sale);
                                await MainForm.Context.SaveChangesAsync();

                                for (int i = 0; i <= DgvِProducts.Rows.Count - 1; i++)
                                {
                                    var saleDetail = SetSaleDetail(i);
                                    saleDetail.Order_ID = sale.Id; // Set foreign key reference to Buy

                                    MainForm.Context.SalesDetails.Add(saleDetail);

                                    // Update product and add quantity
                                    MainForm.Context.Update(SetProduct(i));
                                    SetProductQuentity(Convert.ToDouble(DgvِProducts.Rows[i].Cells[2].Value.ToString()), i);


                                }
                                await MainForm.Context.SaveChangesAsync();
                                if (PaidUp > 0)
                                {
                                    var CustReport = SetCustReport();
                                    CustReport.Order_ID = sale.Id; // Set foreign key reference to Buy
                                    MainForm.Context.Add(CustReport);
                                }
                                if (Remain > 0)
                                {
                                    var CustMoney = SetCustMoney();
                                    CustMoney.Order_ID = sale.Id; // Set foreign key reference to Buy
                                    MainForm.Context.Add(CustMoney);

                                    // Update supplier details
                                    MainForm.Context.Update(SetCustomer());
                                }
                                await MainForm.Context.SaveChangesAsync();
                                await transaction.CommitAsync();

                            }
                            catch (Exception ex)
                            {
                                await transaction.RollbackAsync();
                                MessageBox.Show(ex.Message);
                            }
                        }
                    }
                    else
                    {

                    }

                }
                ResetForm();
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
                _product = salesRepository.GetProductBarCode(DgvِProducts.CurrentRow.Cells[7].Value.ToString());
                txtProductName.Text = this.DgvِProducts.CurrentRow.Cells[0].Value.ToString();
                txtSaleDiscount.Text = this.DgvِProducts.CurrentRow.Cells[3].Value.ToString();
                txtQty.Text = (_main.ConvertToFloat(DgvِProducts.CurrentRow.Cells[2].Value.ToString()) + q).ToString();
                txtTotalSaleProduct.Text = this.DgvِProducts.CurrentRow.Cells[5].Value.ToString();
                txtSalePrice.Text = this.DgvِProducts.CurrentRow.Cells[1].Value.ToString();
                txtWholeSalePrice.Text = this.DgvِProducts.CurrentRow.Cells[4].Value.ToString();

                DgvِProducts.Rows.RemoveAt(DgvِProducts.CurrentRow.Index);
                txtQty.Focus();
                CalculateAmount();
                CalculateStatistics();

                labelError1.Visible = _product.Quentity <= _main.ConvertToFloat(txtQty.Text);

                ProductsQuantitie productQty = MainForm.Context.ProductsQuantities.
                          Where(x => x.Pro_ID == _product.Id && x.Qty >= _main.ConvertToFloat(txtQty.Text) && x.Store_ID.ToString() == cmbStores.SelectedValue).FirstOrDefault();

                lblError2.Visible = productQty is null;



            }
            catch (Exception ex) { MessageBox.Show(ex.Message); }

        }

        private void btnEditSelected_Click(object sender, EventArgs e)
        {
            EditFromTable(0);
        }

        private void DgvِProducts_CellContentDoubleClick(object sender, DataGridViewCellEventArgs e)
        {
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
            SelectProductsForm selectProductsForm = SelectProductsForm.Instance(_main);
            selectProductsForm.Show();
        }
    }
}
