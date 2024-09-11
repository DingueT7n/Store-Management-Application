using System.Data;
using Store.ApplicationUI.Code.Helper;
using Store.ApplicationUI.Gui.LoadingGui;
using Store.ApplicationUI.Gui.PaymentGui;
using Store.Core.Entities.Buys;
using Store.Core.Entities.Caisses;
using Store.Core.Entities.Products;
using Store.Core.Entities.Suppliers;
using Store.Infrastructure.Data;
using Store.Infrastructure.Repositories;

namespace Store.ApplicationUI.Gui.BuysGui
{
    public partial class BuysUserControl : UserControl
    {

        private static BuysUserControl? _buysUserControl;
        private static MainForm? _main;
        private static ApplicationDbContext _context;
        public static BuysRepository? buysRepository;
        public static decimal PaidUp;
        public static decimal Remain;


        public BuysUserControl()
        {
            InitializeComponent();

        }
        public static BuysUserControl Instance(MainForm main)
        {
            _main = main;
            // If the instance is null, create a new one and assign it to the static field
            if (_buysUserControl == null)
            {
                _context = new ApplicationDbContext();

                buysRepository = new BuysRepository(_context);
                _buysUserControl = new BuysUserControl();
            }
            // Return the singleton instance
            _buysUserControl.LoadData();
            return _buysUserControl;
        }
        public static void RefreshDgv()
        {
            //DgvِProducts.DataSource = await Task.Run(() => productsRepository.GetAllProducts());
            _buysUserControl.LoadData();
        }
        // methodes 
        public async void LoadData()
        {


            //ShowLoading
            LoadingForm.Instance(_main).Show();
            if (await Task.Run(() => buysRepository.IsConnected()))
            {
                //Start Load Data
                txtFactureNumber.Text = buysRepository.GetFactureNumber();
                // if its an admin or Normal user 
                SetColumns();
                SetProductsToDgv();
                cmbSuppliers.DataSource = _context.Suppliers.ToList();
                cmbSuppliers.DisplayMember = "SupplierName";
                cmbSuppliers.ValueMember = "Id";
                cmbSuppliers.Text = "اختر مورد";

                cmbStores.DataSource = _context.Stores.ToList();
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
                DgvِProducts.Columns.Add("اسم المنتج", "اسم المنتج"); // String column
                DgvِProducts.Columns.Add("سعر الشراء", "سعر الشراء"); // String or decimal column
                DgvِProducts.Columns.Add("الكمية", "الكمية"); // String or decimal column
                DgvِProducts.Columns.Add("اجمالي الشراء", "اجمالي الشراء"); // String or decimal column
                DgvِProducts.Columns.Add("سعر البيع", "سعر البيع"); // String or decimal column
                DgvِProducts.Columns.Add("سعر الجملة", "سعر الجملة"); // String or decimal column
                DgvِProducts.Columns.Add("سعر البيع باحتساب الضريبة", "سعر البيع باحتساب الضريبة"); // String or decimal column

                // DateTime column for expiration date
                DataGridViewColumn dateColumn = new DataGridViewTextBoxColumn();
                dateColumn.Name = "تاريخ انتهاء الصلاحية";
                dateColumn.HeaderText = "تاريخ انتهاء الصلاحية";
                DgvِProducts.Columns.Add(dateColumn);

                DgvِProducts.Columns.Add("معرف المنتوج", "معرف المنتوج"); // ID column
                DgvِProducts.Columns.Add("باركود", "باركود"); // String column for barcode
            }




            // Visible of Columns
            //DgvProducts.Columns[0].Visible = false;
            ////DgvِProducts.Columns[6].Visible = false;
            DgvِProducts.Columns[9].Visible = false;
            DgvِProducts.Columns[8].Visible = false;
            ////DgvِProducts.Columns[11].Visible = false;
            ////DgvِProducts.Columns[12].Visible = false;
            ////DgvِProducts.Columns[15].Visible = false;
            ////DgvِProducts.Columns[13].Visible = false;
            //DgvProducts.Columns[13].Visible = false;
            //DgvProducts.Columns[14].Visible = false;
            //DgvProducts.Columns[13].Visible = false;
            //DgvProducts.Columns[15].Visible = false;
        }
        public async void SetProductsToDgv()
        {
            //DgvProducts.DataSource = await Task.Run(() => productsRepository.GetAll(p => p.Category));
            //DgvِProducts.DataSource = _context.Products.
            //    Include(x => x.Category).ToList();
        }
        public void InitializeTextBoxesAndLables(Product product)
        {
            txtProductName.Text = product.ProductName;
            txtBuyPrice.Text = product.BuyPrice.ToString();
            txtQty.Text = "1";
            txtTotalBuyProduct.Text = product.BuyPrice.ToString();
            txtSalePrice.Text = product.SalePrice.ToString();
            txtWholeSalePrice.Text = product.WholesalePrice.ToString();
            txtPriceWithTax.Text = product.SalePriceTax.ToString();
            dtpDateExpiration.Value = product.DateExperation;

        }
        public static void InitializeData(string paidUp, string remain)
        {
            PaidUp = _main.ConvertToFloat(paidUp);
            Remain = _main.ConvertToFloat(remain);
        }
        public void ClearBoxes()
        {
            txtProductName.Text = string.Empty;
            txtBuyPrice.Text = string.Empty;
            txtQty.Text = string.Empty;
            txtTotalBuyProduct.Text = string.Empty;
            txtSalePrice.Text = string.Empty;
            txtWholeSalePrice.Text = string.Empty;
            txtPriceWithTax.Text = string.Empty;
        }

        void CalculateAmount()
        {
            try
            {
                if (txtBuyPrice.Text != string.Empty && txtQty.Text != string.Empty)

                    txtTotalBuyProduct.Text = (_main.ConvertToFloat(txtBuyPrice.Text) * Convert.ToInt32(txtQty.Text)).ToString();

                if (txtSalePrice.Text != string.Empty && _product is not null)
                {
                    if (_product.IsTaxed)
                        txtPriceWithTax.Text = (((_main.ConvertToFloat(txtSalePrice.Text) / 100) * _product.TaxValue) + _main.ConvertToFloat
                            (txtSalePrice.Text)).ToString();
                    else txtPriceWithTax.Text = txtSalePrice.Text;

                }
            }
            catch (Exception ex) { MessageBox.Show(ex.Message); }
        }
        private Product _product;
        public async void SetProductsToTable()
        {
            //DgvProducts.DataSource = await Task.Run(() => productsRepository.GetAll(p => p.Category));
            _product = buysRepository.GetProductBarCode(txtSearchBarCode.Text);
            if (_product is not null)
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

            }
            txtSearchBarCode.Clear();

        }
        private void tableLayoutPanel_Paint(object sender, PaintEventArgs e)
        {

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
                newRow.Cells[1].Value = txtBuyPrice.Text;
                newRow.Cells[2].Value = txtQty.Text;
                newRow.Cells[3].Value = txtTotalBuyProduct.Text;
                newRow.Cells[4].Value = txtSalePrice.Text;
                newRow.Cells[5].Value = txtWholeSalePrice.Text;
                newRow.Cells[6].Value = txtPriceWithTax.Text;
                newRow.Cells[7].Value = dtpDateExpiration.Value.ToString("MM/dd/yyyy");
                newRow.Cells[8].Value = _product.Id;
                newRow.Cells[9].Value = _product.CodeBar;
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
                        if (DgvِProducts.Rows[i].Cells[8].Value.ToString() == _product.Id.ToString())
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
            else { MsgHelper.ShowEmptyResult(); }
            CalculateStatistics();
        }
        private void txtQty_KeyDown(object sender, KeyEventArgs e)
        {
            if (e.KeyCode == Keys.Enter)
            {
                if (txtQty.Text == string.Empty) { return; }
                AddNewRow();
            }
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
                CalculateAmount();
                CalculateStatistics();

            }
            catch (Exception ex) { MessageBox.Show(ex.Message); }
        }
        public bool ValidatePay()
        {
            if (cmbSuppliers.Text == "اختر مورد") { MessageBox.Show("يرجى اختيار مورد , راجع البيانات من فضلك", "بيانات غير كاملة"); cmbSuppliers.Focus(); return false; }
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
                                          where row.Cells[3].FormattedValue.ToString() != string.Empty
                                          select Convert.ToDecimal(row.Cells[3].FormattedValue)).Sum()
                                          .ToString("f2");
                    TotalFacture = (from DataGridViewRow row in DgvِProducts.Rows
                                    where row.Cells[3].FormattedValue.ToString() != string.Empty
                                    select Convert.ToDecimal(row.Cells[3].FormattedValue)).Sum();
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
        Buy SetBuy()
        {

            Buy buy = new Buy();

            buy.Total = _main.ConvertToFloat(TotalFacture.ToString());
            buy.SupplierId = Convert.ToInt32(cmbSuppliers.SelectedValue);
            buy.Date = DtpDateFacture.Value;
            buy.PaidUP = _main.ConvertToFloat(PaidUp.ToString());
            buy.Remain = _main.ConvertToFloat(Remain.ToString());
            buy.Time = DateTime.Now.ToString("HH:mm");
            buy.User_Name = "Alaa";
            return buy;
        }
        SupplierReport SetSupReport()
        {

            SupplierReport suppReport = new SupplierReport();
            suppReport.Order_ID = Convert.ToInt32(txtFactureNumber.Text);
            suppReport.Sup_ID = Convert.ToInt32(cmbSuppliers.SelectedValue);
            suppReport.SupplierName = cmbSuppliers.Text;
            suppReport.Date = DtpDateFacture.Value;
            suppReport.Price = _main.ConvertToFloat(PaidUp.ToString());
            suppReport.Time = DateTime.Now.ToString("HH:mm");
            return suppReport;
        }
        SupplierMoney SetSupMoney()
        {

            SupplierMoney supplierMoney = new SupplierMoney();
            supplierMoney.Order_ID = Convert.ToInt32(txtFactureNumber.Text);
            supplierMoney.Sup_ID = Convert.ToInt32(cmbSuppliers.SelectedValue);
            supplierMoney.SupplierName = cmbSuppliers.Text;
            supplierMoney.Order_Date = DtpDateFacture.Value;
            supplierMoney.Price = _main.ConvertToFloat(Remain.ToString());
            supplierMoney.Time = DateTime.Now.ToString("HH:mm");
            supplierMoney.Reminder_Date = dtpReminderDate.Value;
            return supplierMoney;
        }
        BuyDetail SetBuyDetail(int i)
        {
            //dgvProducts.Rows[i].Cells[0].Value.ToString()
            BuyDetail buyDetail = new BuyDetail();
            buyDetail.Order_ID = Convert.ToInt32(txtFactureNumber.Text);
            buyDetail.Sup_ID = Convert.ToInt32(cmbSuppliers.SelectedValue);
            buyDetail.Pro_ID = Convert.ToInt32(DgvِProducts.Rows[i].Cells[8].Value.ToString());
            buyDetail.Quentity = _main.ConvertToFloat(DgvِProducts.Rows[i].Cells[2].Value.ToString());
            buyDetail.Price = _main.ConvertToFloat(DgvِProducts.Rows[i].Cells[1].Value.ToString());
            buyDetail.Total = _main.ConvertToFloat(DgvِProducts.Rows[i].Cells[3].Value.ToString());
            buyDetail.TaxValue = Properties.Settings.Default.TaxValue;
            buyDetail.PriceWithTax = _main.ConvertToFloat(DgvِProducts.Rows[i].Cells[6].Value.ToString());
            return buyDetail;
        }
        Product SetProduct(int i)
        {
            //dgvProducts.Rows[i].Cells[0].Value.ToString()
            var proId = DgvِProducts.Rows[i].Cells[8].Value.ToString();
            Product product = _context.Products.Where(x => x.Id.ToString() == proId).FirstOrDefault();
            if (product is not null)
            {
                product.Quentity = product.Quentity + _main.ConvertToFloat(DgvِProducts.Rows[i].Cells[2].Value.ToString());

            }
            return product;
        }
        Supplier SetSupplier()
        {
            //dgvProducts.Rows[i].Cells[0].Value.ToString()
            var supId = Convert.ToInt32(cmbSuppliers.SelectedValue);
            Supplier supplier = _context.Suppliers.Where(x => x.Id == supId).FirstOrDefault();
            if (supplier is not null)
            {
                supplier.TotalDebts = supplier.TotalDebts + Remain;

            }
            return supplier;
        }
        ProductsQuantitie SetProductQuentity(int i)
        {
            //dgvProducts.Rows[i].Cells[0].Value.ToString()
            ProductsQuantitie productQty = new();
            if (productQty is not null)
            {
                productQty.Pro_ID = Convert.ToInt32(DgvِProducts.Rows[i].Cells[8].Value.ToString());
                productQty.Store_ID = Convert.ToInt32(cmbStores.SelectedValue);
                productQty.StoreName = cmbStores.Text;
                productQty.Qty = _main.ConvertToFloat(DgvِProducts.Rows[i].Cells[2].Value.ToString());
                productQty.Buy_Price = _main.ConvertToFloat(DgvِProducts.Rows[i].Cells[1].Value.ToString());
                productQty.Sale_PriceTax = _main.ConvertToFloat(DgvِProducts.Rows[i].Cells[6].Value.ToString());
                productQty.DateExpiration = Convert.ToDateTime(DgvِProducts.Rows[i].Cells[7].Value);
            }
            return productQty;
        }
        Caisse SetCaisse(decimal value)
        {
            //dgvProducts.Rows[i].Cells[0].Value.ToString()

            Caisse caisse = _context.Caisses.Where(x => x.Id == Properties.Settings.Default.DefaultCaisseId).FirstOrDefault();
            if (caisse is not null)
            {
                caisse.MoneyinCaisse -= value;
            }
            return caisse;

        }
        CaisseWithdraw SetCaisseWithdraw(decimal value)
        {
            //dgvProducts.Rows[i].Cells[0].Value.ToString()


            var caisseWithdraw = new CaisseWithdraw
            {
                Caisse_ID = Properties.Settings.Default.DefaultCaisseId,
                Time = DateTime.Now.ToString("HH:mm:ss"),
                Date = DateTime.Now,
                Name = $"  {Properties.Settings.Default.UserName}  المورد {cmbSuppliers.Text} بحساب ",
                Money = value,
                Reason = "شراء بالفاتورة لعميل",
                Type = "سحب عن طريق شراء منتجات (مال مستثمر )"
            };

            return caisseWithdraw;

        }
        private async Task ProcessPaymentAsync(bool isDebt)
        {
            using (var transaction = _context.Database.BeginTransaction())
            {
                try
                {
                    var buy = SetBuy();
                    _context.Add(buy);
                    await _context.SaveChangesAsync();

                    for (int i = 0; i < DgvِProducts.Rows.Count; i++)
                    {
                        var buyDetail = SetBuyDetail(i);
                        buyDetail.Order_ID = buy.Id;

                        _context.BuyDetails.Add(buyDetail);

                        // Update product and add quantity
                        _context.Update(SetProduct(i));
                        _context.Add(SetProductQuentity(i));
                    }

                    await HandleCaisseAndSupplierAsync(buy);

                    await transaction.CommitAsync();
                }
                catch (Exception ex)
                {
                    await transaction.RollbackAsync();
                    MessageBox.Show(ex.Message);
                }
            }
        }
        private async Task HandleCaisseAndSupplierAsync(Buy buy)
        {
            if (PaidUp <= TotalFacture)
            {
                _context.Update(SetCaisse(_main.ConvertToFloat(PaidUp.ToString())));
                _context.Add(SetCaisseWithdraw(_main.ConvertToFloat(PaidUp.ToString())));
            }
            else
            {
                _context.Update(SetCaisse(_main.ConvertToFloat(TotalFacture.ToString())));
                _context.Add(SetCaisseWithdraw(_main.ConvertToFloat(TotalFacture.ToString())));
            }
            if (PaidUp > 0)
            {
                var supplierReport = SetSupReport();
                supplierReport.Order_ID = buy.Id;
                _context.Add(supplierReport);
            }
            if (Remain > 0)
            {
                var supplierMoney = SetSupMoney();
                supplierMoney.Order_ID = buy.Id;
                _context.Add(supplierMoney);

                _context.Update(SetSupplier());
            }
            await _context.SaveChangesAsync();
        }
        private async void btnPay_Click(object sender, EventArgs e)
        {

            if (ValidatePay())
            {
                AddPaymentForm addPaymentForm = new(_main, 0);

                // Determine payment type and show the payment form
                if (rBPayCash.Checked || rBPayPartial.Checked)
                {
                    addPaymentForm.LoadData(TotalFacture.ToString(), TotalFacture.ToString(), "0");
                    addPaymentForm.ShowDialog();
                }
                else if (rBPayDebt.Checked)
                {
                    addPaymentForm.LoadData(TotalFacture.ToString(), "0", TotalFacture.ToString());
                    addPaymentForm.ShowDialog();
                }

                // Proceed if payment is valid
                if (PaidUp >= TotalFacture)
                {
                    await ProcessPaymentAsync(false);
                }
                else if (PaidUp < TotalFacture)
                {
                    await ProcessPaymentAsync(true);
                }

                ResetForm();
            }
            //if (ValidatePay())
            //{
            //    AddPaymentForm addPaymentForm = new(_main, 0);

            //    if (rBPayCash.Checked)
            //    {
            //        addPaymentForm.LoadData(TotalFacture.ToString(), TotalFacture.ToString(), "0");
            //        addPaymentForm.ShowDialog();
            //        if (PaidUp >= TotalFacture)
            //        {
            //            using (var transaction = _context.Database.BeginTransaction())
            //            {
            //                try
            //                {
            //                    var buy = SetBuy();
            //                    _context.Add(buy);
            //                    await _context.SaveChangesAsync();

            //                    for (int i = 0; i <= DgvِProducts.Rows.Count - 1; i++)
            //                    {
            //                        var buyDetail = SetBuyDetail(i);
            //                        buyDetail.Order_ID = buy.Id; // Set foreign key reference to Buy

            //                        _context.BuyDetails.Add(buyDetail);

            //                        // Update product and add quantity
            //                        _context.Update(SetProduct(i));
            //                        _context.Add(SetProductQuentity(i));


            //                    }

            //                    await _context.SaveChangesAsync();
            //                    if (PaidUp <= TotalFacture)
            //                    {
            //                        _context.Update(SetCaisse(_main.ConvertToFloat((PaidUp).ToString())));
            //                        _context.Add(SetCaisseWithdraw(_main.ConvertToFloat((PaidUp).ToString())));

            //                    }
            //                    else
            //                    {
            //                        _context.Update(SetCaisse(_main.ConvertToFloat((TotalFacture).ToString())));
            //                        _context.Add(SetCaisseWithdraw(_main.ConvertToFloat((TotalFacture).ToString())));
            //                    }
            //                    if (PaidUp > 0)
            //                    {
            //                        var supplierReport = SetSupReport();
            //                        supplierReport.Order_ID = buy.Id; // Set foreign key reference to Buy
            //                        _context.Add(supplierReport);
            //                    }
            //                    if (Remain > 0)
            //                    {
            //                        var supplierMoney = SetSupMoney();
            //                        supplierMoney.Order_ID = buy.Id; // Set foreign key reference to Buy
            //                        _context.Add(supplierMoney);

            //                        // Update supplier details
            //                        _context.Update(SetSupplier());
            //                    }
            //                    await _context.SaveChangesAsync();
            //                    await transaction.CommitAsync();

            //                }
            //                catch (Exception ex)
            //                {
            //                    await transaction.RollbackAsync();
            //                    MessageBox.Show(ex.Message);
            //                }
            //            }
            //        }
            //        else
            //        {

            //        }
            //    }
            //    else if (rBPayDebt.Checked)
            //    {
            //        addPaymentForm.LoadData(TotalFacture.ToString(), "0", TotalFacture.ToString());
            //        addPaymentForm.ShowDialog();
            //        if (PaidUp < TotalFacture)
            //        {
            //            using (var transaction = _context.Database.BeginTransaction())
            //            {
            //                try
            //                {
            //                    var buy = SetBuy();
            //                    _context.Add(buy);
            //                    await _context.SaveChangesAsync();

            //                    BuyDetailRepository buyDetailRepository = new(_context);

            //                    for (int i = 0; i <= DgvِProducts.Rows.Count - 1; i++)
            //                    {
            //                        var buyDetail = SetBuyDetail(i);
            //                        buyDetail.Order_ID = buy.Id; // Set foreign key reference to Buy

            //                        _context.BuyDetails.Add(buyDetail);

            //                        // Update product and add quantity
            //                        _context.Update(SetProduct(i));
            //                        _context.Add(SetProductQuentity(i));


            //                    }
            //                    await _context.SaveChangesAsync();
            //                    if (PaidUp <= TotalFacture)
            //                    {
            //                        _context.Update(SetCaisse(_main.ConvertToFloat((PaidUp).ToString())));
            //                        _context.Add(SetCaisseWithdraw(_main.ConvertToFloat((PaidUp).ToString())));

            //                    }
            //                    else
            //                    {
            //                        _context.Update(SetCaisse(_main.ConvertToFloat((TotalFacture).ToString())));
            //                        _context.Add(SetCaisseWithdraw(_main.ConvertToFloat((TotalFacture).ToString())));
            //                    }
            //                    if (PaidUp > 0)
            //                    {
            //                        var supplierReport = SetSupReport();
            //                        supplierReport.Order_ID = buy.Id; // Set foreign key reference to Buy
            //                        _context.Add(supplierReport);
            //                    }
            //                    if (Remain > 0)
            //                    {
            //                        var supplierMoney = SetSupMoney();
            //                        supplierMoney.Order_ID = buy.Id; // Set foreign key reference to Buy
            //                        _context.Add(supplierMoney);

            //                        // Update supplier details
            //                        _context.Update(SetSupplier());
            //                    }
            //                    await _context.SaveChangesAsync();
            //                    await transaction.CommitAsync();

            //                }
            //                catch (Exception ex)
            //                {
            //                    await transaction.RollbackAsync();
            //                    MessageBox.Show(ex.Message);
            //                }
            //            }
            //        }
            //        else
            //        {

            //        }
            //    }
            //    else
            //    {
            //        addPaymentForm.LoadData(TotalFacture.ToString(), TotalFacture.ToString(), "0");
            //        addPaymentForm.ShowDialog();
            //        if (PaidUp <= TotalFacture)
            //        {
            //            using (var transaction = _context.Database.BeginTransaction())
            //            {
            //                try
            //                {
            //                    var buy = SetBuy();
            //                    _context.Add(buy);
            //                    await _context.SaveChangesAsync();



            //                    for (int i = 0; i <= DgvِProducts.Rows.Count - 1; i++)
            //                    {
            //                        var buyDetail = SetBuyDetail(i);
            //                        buyDetail.Order_ID = buy.Id; // Set foreign key reference to Buy

            //                        _context.BuyDetails.Add(buyDetail);

            //                        // Update product and add quantity
            //                        _context.Update(SetProduct(i));
            //                        _context.Add(SetProductQuentity(i));


            //                    }
            //                    await _context.SaveChangesAsync();
            //                    if (PaidUp <= TotalFacture)
            //                    {
            //                        _context.Update(SetCaisse(_main.ConvertToFloat((PaidUp).ToString())));
            //                        _context.Add(SetCaisseWithdraw(_main.ConvertToFloat((PaidUp).ToString())));

            //                    }
            //                    else
            //                    {
            //                        _context.Update(SetCaisse(_main.ConvertToFloat((TotalFacture).ToString())));
            //                        _context.Add(SetCaisseWithdraw(_main.ConvertToFloat((TotalFacture).ToString())));
            //                    }
            //                    if (PaidUp > 0)
            //                    {
            //                        var supplierReport = SetSupReport();
            //                        supplierReport.Order_ID = buy.Id; // Set foreign key reference to Buy
            //                        _context.Add(supplierReport);
            //                    }
            //                    if (Remain > 0)
            //                    {
            //                        var supplierMoney = SetSupMoney();
            //                        supplierMoney.Order_ID = buy.Id; // Set foreign key reference to Buy
            //                        _context.Add(supplierMoney);

            //                        // Update supplier details
            //                        _context.Update(SetSupplier());
            //                    }
            //                    await _context.SaveChangesAsync();
            //                    await transaction.CommitAsync();


            //                }
            //                catch (Exception ex)
            //                {
            //                    await transaction.RollbackAsync();
            //                    MessageBox.Show(ex.Message);
            //                }
            //            }
            //        }
            //        else
            //        {

            //        }

            //    }
            //    ResetForm();
            //}
        }

        private void txtSalePrice_KeyPress(object sender, KeyPressEventArgs e)
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

        private void txtWholeSalePrice_KeyPress(object sender, KeyPressEventArgs e)
        {
            if (!char.IsDigit(e.KeyChar) && e.KeyChar != Properties.Settings.Default.DecimalSEP[0] && e.KeyChar != 8)
            {
                e.Handled = true;
            }
        }

        private void txtSalePrice_KeyUp(object sender, KeyEventArgs e)
        {
            ErrorDetection();
            CalculateAmount();
            CalculateStatistics();

        }

        private void txtWholeSalePrice_TextChanged(object sender, EventArgs e)
        {
            ErrorDetection();
        }
        void ErrorDetection()
        {
            if (txtWholeSalePrice.Text == string.Empty || txtPriceWithTax.Text == string.Empty)
            {
                labelError1.Visible = false;
                return;
            }
            try
            {
                if (Convert.ToDouble(txtWholeSalePrice.Text) > Convert.ToDouble(txtPriceWithTax.Text))
                {
                    labelError1.Visible = true;
                }
                else labelError1.Visible = false;
            }
            catch (Exception)
            {

                throw;
            }
        }
        private void txtSalePrice_TextChanged(object sender, EventArgs e)
        {
            ErrorDetection();
        }
        void EditFromTable()
        {
            try
            {
                txtProductName.Text = this.DgvِProducts.CurrentRow.Cells[0].Value.ToString();
                txtBuyPrice.Text = this.DgvِProducts.CurrentRow.Cells[1].Value.ToString();
                txtQty.Text = this.DgvِProducts.CurrentRow.Cells[2].Value.ToString();
                txtTotalBuyProduct.Text = this.DgvِProducts.CurrentRow.Cells[3].Value.ToString();
                txtSalePrice.Text = this.DgvِProducts.CurrentRow.Cells[4].Value.ToString();
                txtWholeSalePrice.Text = this.DgvِProducts.CurrentRow.Cells[5].Value.ToString();
                txtPriceWithTax.Text = this.DgvِProducts.CurrentRow.Cells[6].Value.ToString();
                dtpDateExpiration.Value = Convert.ToDateTime(this.DgvِProducts.CurrentRow.Cells[7].Value.ToString());
                DgvِProducts.Rows.RemoveAt(DgvِProducts.CurrentRow.Index);
                txtQty.Focus();
                CalculateAmount();
                CalculateStatistics();



            }
            catch (Exception ex) { MessageBox.Show(ex.Message); }

        }
        private void DgvِProducts_CellContentDoubleClick(object sender, DataGridViewCellEventArgs e)
        {
            EditFromTable();
        }

        private void txtWholeSalePrice_KeyUp(object sender, KeyEventArgs e)
        {
            ErrorDetection();

        }

        private void btnEditSelected_Click(object sender, EventArgs e)
        {
            EditFromTable();
        }
    }
}
