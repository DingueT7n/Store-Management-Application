using System.Data;
using Microsoft.EntityFrameworkCore;
using Microsoft.IdentityModel.Tokens;
using Store.ApplicationUI.Code.Helper;
using Store.ApplicationUI.Code.System;
using Store.ApplicationUI.Gui.LoadingGui;
using Store.ApplicationUI.Gui.PaymentGui;
using Store.Core.Entities.Products;
using Store.Core.Entities.Sales;
using Store.Core.Interfaces;
using Store.Infrastructure.Data;

namespace Store.ApplicationUI.Gui.SalesGui.ProformaGui
{
    public partial class ProformaUserControl : UserControl
    {
        private readonly MainForm _main;
        private readonly ApplicationDbContext _context;
        private readonly IProformaInvoiceRepository _repository;
        private readonly ISalesRepository _salesRepository;
        private readonly ControlManager _controlManager;
        public decimal PaidUp;
        public decimal Remain;
        public ProformaUserControl(MainForm main, ApplicationDbContext context, IProformaInvoiceRepository proformaInvoiceRepository, ControlManager controlManager
            , ISalesRepository salesRepository)
        {
            InitializeComponent();

            _main = main;
            _context = context;
            _repository = proformaInvoiceRepository;
            _controlManager = controlManager;
            _salesRepository = salesRepository;
        }
        public async Task setPrivateProductAndAdditTotable(Product product)
        {
            txtSearchBarCode.Text = product.CodeBar;
            await SetProductsToTable(product.CodeBar);
            AddNewRow();
        }
        public async Task SetProductsToDgvAsync1(string status, int skip)
        {
            try
            {
                var data = await _repository
                    .GetProformaInvoices(dtpFrom.Value, dtpTo.Value, status, Properties.Settings.Default.NoOfDataInDgvs, skip);

                // Set data source
                Dgv1.DataSource = data.Data;

                // Calculate total pages
                double value = data.Count / Convert.ToDouble(Properties.Settings.Default.NoOfDataInDgvs);
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

                PaginationHide1();
            }
            catch (Exception)
            {

            }
        }
        void PaginationHide1()
        {
            btnNext.Enabled = cmbpagination.SelectedIndex < cmbpagination.Items.Count - 1 && !dgvHelper.IsEmpty(Dgv1);
            btnPrev.Enabled = cmbpagination.SelectedIndex > 0 && !dgvHelper.IsEmpty(Dgv1);
            cmbpagination.Enabled = !dgvHelper.IsEmpty(Dgv1);
        }
        private async Task RefreshDgvAsync1(int skip)
        {
            try
            {


                await SetProductsToDgvAsync1(txtSearch.Text, skip);
                SetColumns2();
                lblEmptyData.Visible = dgvHelper.IsEmpty(Dgv1);
            }
            catch (Exception ex)
            {
                // Log to file or show error
                ToasterHelper.ShowErrorHappened(ex.Message);
            }
        }
        private void SetColumns2()
        {
            //Dgv1.DataSource = new List<CaisseStatusDetail>();
            string[] headers = { "معرف النموذج", "المسؤول عن النموذج", "اسم العميل", "تاريخ النمودج", "قيمة النموذج",
                "عدد المنتجات" };


            for (int i = 0; i < headers.Length; i++)
            {
                Dgv1.Columns[i].HeaderCell.Value = headers[i];

            }

            //Dgv1.Columns[13].Visible = false;
            //Dgv1.Columns[0].Visible = false;
            //Dgv1.Columns[4].Visible = false;
            //Dgv1.Columns[4].Visible = false;

        }
        public async Task LoadData()
        {
            //dgvHelper.ResetForm(this);
            //await ResetForm();
            dtpTo.Value = DateTime.Now;
            DtpDateFacture.Value = DateTime.Now;
            //ShowLoading
            LoadingForm.Instance(_main).Show();
            if (await _repository.IsConnectedAsync())
            {
                ResetFormBegin();
                //Start Load Data

                // if its an admin or Normal user 

                SetColumns();

                cmbCustomers.DataSource = await _context.Customers.ToListAsync();
                cmbCustomers.DisplayMember = "CustomerName";
                cmbCustomers.ValueMember = "Id";
                cmbCustomers.Text = "اختر العميل";
                await RefreshDgvAsync1(0);


                DtpDateFacture.Value = DateTime.Now;
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

            DgvِProducts.Columns[6].Visible = false;
            DgvِProducts.Columns[7].Visible = false;

        }
        public async Task InitializeTextBoxesAndLables(Product product)
        {
            try
            {

                var now = DateTime.Now;

                if (txtQty.Text.Contains("\r\n"))
                    txtQty.Text = "1";
                txtProductName.Text = product.ProductName;

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


                txtSaleDiscount.Text = "0";

                txtTotalSaleProduct.Text = product.SalePriceTax.ToString();
                txtSalePrice.Text = product.SalePriceTax.ToString();
                txtWholeSalePrice.Text = product.WholesalePrice.ToString();
            }
            catch (Exception)
            {
                throw;
            }
        }
        public async Task InitializeTextBoxesAndLablesFromWeight(Product product, decimal weight)
        {
            try
            {

                var now = DateTime.Now;

                txtProductName.Text = product.ProductName;

                txtSaleDiscount.Text = "0";

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

        public void InitializeData(string paidUp, string remain)
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
        public async Task SetProductsToTable(string barcode)
        {
            _product = _salesRepository.GetProductBarCode(barcode);

            if (_product != null)
            {
                await InitializeTextBoxesAndLables(_product);
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
        public async Task ParseScaleBarcode(string barcodeWeight)
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
                await InitializeTextBoxesAndLablesFromWeight(_product, weight);
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

        private async void txtSearchBarCode_KeyDown(object sender, KeyEventArgs e)
        {
            if (e.KeyCode == Keys.Enter)
            {
                string input = txtSearchBarCode.Text.Trim().Replace("\r", "").Replace("\n", "");

                if (input.Length >= 2)
                {
                    string prefix = input.Substring(0, 2);
                    if (prefix == "21" && input.Length >= 4)
                    {
                        await ParseScaleBarcode(input);
                    }
                    else
                    {
                        await SetProductsToTable(input);
                    }
                }
                else if (input.Length > 0)
                {
                    await SetProductsToTable(input); // fallback if it's short but not empty
                }

                txtSearchBarCode.Clear();
            }

            EditUsingPlusMinus(sender, e);
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

        private async void txtQty_KeyUp(object sender, KeyEventArgs e)
        {
            try
            {
                if (txtQty.Text.IsNullOrEmpty()) { return; }
                await InitializeTextBoxesAndLables(_product);
                CalculateAmount();

            }
            catch (Exception ex) { MessageBox.Show(ex.Message); }
        }
        public bool ValidatePay()
        {
            if (cmbCustomers.Text == "اختر العميل") { MessageBox.Show("يرجى اختيار عميل , راجع البيانات من فضلك", "بيانات غير كاملة"); cmbCustomers.Focus(); return false; }
            if (txtProductName.Text != string.Empty)
            { MessageBox.Show("لديك منتج قيد الاضافة , راجع البيانات من فضلك", "بيانات غير كاملة"); return false; }
            return true;
        }

        private void txtSalePrice_KeyDown(object sender, KeyEventArgs e)
        {
            if (e.KeyCode == Keys.Enter)
            {
                AddNewRow();
            }
        }
        int rowIndex;
        private decimal TotalFacture;

        private void txtSalePrice_KeyUp(object sender, KeyEventArgs e)
        {
            CalculateAmount();

        }

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

                //lblEmptyData.Visible = dgvHelper.IsEmpty(DgvِProducts);
                if (DgvِProducts.Rows.Count > 0)
                {

                    TotalFacture = (from DataGridViewRow row in DgvِProducts.Rows
                                    where row.Cells[5].FormattedValue.ToString() != string.Empty
                                    select Convert.ToDecimal(row.Cells[5].FormattedValue)).Sum();
                }

            }
            catch (Exception)
            {

                throw;
            }

        }
        private async Task ResetForm()
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
            await LoadData(); // This is a method where you load initial data

            // Optionally reset focus to the first control
            // Set focus to the first control

        }
        private void ResetFormBegin()
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
        ProformaInvoice SetProforma()
        {

            return new ProformaInvoice
            {
                InvoiceNumber = txtFactureNumber.Text,
                UserName = Properties.Settings.Default.UserName,
                CustomerName = cmbCustomers.Text,
                TotalFaacture = _main.ConvertToFloat(TotalFacture.ToString()),
                CustomerId = Convert.ToInt32(cmbCustomers.SelectedValue),
                Date = DtpDateFacture.Value
            };
        }
        ProformaInvoiceDetails SetProformaDetails(int proformaId, int i)
        {
            var row = DgvِProducts.Rows[i];

            return new ProformaInvoiceDetails
            {
                ProformaId = proformaId,
                ProductId = Convert.ToInt32(row.Cells[6].Value.ToString()),
                ProductName = row.Cells[0].Value.ToString(),
                Quentity = _main.ConvertToFloat(row.Cells[2].Value.ToString()),
                UnitPrice = _main.ConvertToFloat(row.Cells[1].Value.ToString()),
                Total = _main.ConvertToFloat(row.Cells[5].Value.ToString()),
                Discount = _main.ConvertToFloat(row.Cells[3].Value.ToString()),

            };
        }
        private async Task ProcessTransaction()
        {

            int id = 0;
            using (var transaction = await _context.Database.BeginTransactionAsync())
            {
                try
                {
                    var proforma = SetProforma();
                    await _context.AddAsync(proforma);
                    await _context.SaveChangesAsync();

                    for (int i = 0; i <= DgvِProducts.Rows.Count - 1; i++)
                    {
                        var proformaDetail = SetProformaDetails(proforma.Id, i);

                        await _context.AddAsync(proformaDetail);
                    }
                    await _context.SaveChangesAsync();


                    await transaction.CommitAsync();

                    Code.Helper.ToasterHelper.ShowNewSaleAdd();
                    await ResetForm();
                }
                catch (Exception ex)
                {
                    await transaction.RollbackAsync();
                    MessageBox.Show(ex.Message);
                }
            }
            //try
            //{


            //    DataTable saleDetailsTable = await Code.Helper.FactureHelper.GetSellDetailsDataTableAsync(id);
            //    string printername = Properties.Settings.Default.Printer8cm;

            //    if (Properties.Settings.Default.PrintSaleFactureType8cm)
            //    {
            //        Reports.sale8cm sale8Cm = _controlManager.GetR<Reports.sale8cm>();
            //        sale8Cm.DataSource = saleDetailsTable;

            //        if (rbPrinterDirectly.Checked && !printername.IsNullOrEmpty())
            //        {
            //            for (int i = 0; i < Properties.Settings.Default.NbrCopyOfSaleFacture; i++)
            //            {
            //                var printTool = new DevExpress.XtraReports.UI.ReportPrintTool(sale8Cm);
            //                printTool.PrinterSettings.PrinterName = printername;
            //                await printTool.PrintAsync(printername);
            //            }
            //        }
            //        else if (rbAnalysis.Checked)
            //        {


            //            Reports.ReportPerviwGui.PerviweForm xtraForm1 = await _controlManager.GetFAsync<Reports.ReportPerviwGui.PerviweForm>();
            //            xtraForm1.LoadReport(sale8Cm);
            //            xtraForm1.ShowDialog();
            //        }
            //    }
            //    else
            //    {
            //        Reports.SalesReports.salesA4 salesA4 = _controlManager.GetR<Reports.SalesReports.salesA4>();
            //        salesA4.DataSource = saleDetailsTable;
            //        printername = Properties.Settings.Default.PrinterA4;

            //        if (rbPrinterDirectly.Checked && !printername.IsNullOrEmpty())
            //        {
            //            for (int i = 0; i < Properties.Settings.Default.NbrCopyOfSaleFacture; i++)
            //            {
            //                var printTool = new DevExpress.XtraReports.UI.ReportPrintTool(salesA4);
            //                printTool.PrinterSettings.PrinterName = printername;
            //                await printTool.PrintAsync(printername);
            //            }

            //        }
            //        else if (rbAnalysis.Checked)
            //        {


            //            Reports.ReportPerviwGui.PerviweForm xtraForm1 = await _controlManager.GetFAsync<Reports.ReportPerviwGui.PerviweForm>();
            //            xtraForm1.LoadReport(salesA4);
            //            xtraForm1.ShowDialog();
            //        }

            //    }

            //}
            //catch (Exception ex)
            //{

            //    MessageBox.Show(ex.Message);
            //    throw;
            //}

        }

        private async void btnPay_Click(object sender, EventArgs e)
        {
            ToasterHelper.PlayNotificationSound();
            if (!(DgvِProducts.Rows.Count > 0))
                return;
            if (ValidatePay())
            {
                await ProcessTransaction();


            }
        }
        void EditFromTable(int q)
        {
            try
            {
                if (dgvHelper.IsEmpty(DgvِProducts)) { MsgHelper.ShowEmptyDataGridView(); }
                if (!dgvHelper.IsEmpty(DgvِProducts))
                {
                    _product = _salesRepository.GetProductBarCode(DgvِProducts.CurrentRow.Cells[7].Value.ToString());
                    txtProductName.Text = this.DgvِProducts.CurrentRow.Cells[0].Value.ToString();
                    txtSaleDiscount.Text = this.DgvِProducts.CurrentRow.Cells[3].Value.ToString();
                    txtQty.Text = (_main.ConvertToFloat(DgvِProducts.CurrentRow.Cells[2].Value.ToString()) + q).ToString();
                    txtTotalSaleProduct.Text = this.DgvِProducts.CurrentRow.Cells[5].Value.ToString();
                    txtSalePrice.Text = this.DgvِProducts.CurrentRow.Cells[1].Value.ToString();
                    txtWholeSalePrice.Text = this.DgvِProducts.CurrentRow.Cells[4].Value.ToString();
                    txtSaleDiscount.Text = "0";
                    txtQty.Focus();
                    CalculateAmount();
                    CalculateStatistics();
                    DgvِProducts.Rows.RemoveAt(DgvِProducts.CurrentRow.Index);
                }
            }
            catch (Exception ex) { MessageBox.Show(ex.Message); }

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

        private void btnEditSelected_Click(object sender, EventArgs e)
        {
            ToasterHelper.PlayNotificationSound();
            EditFromTable(0);
        }

        private void DgvِProducts_KeyDown(object sender, KeyEventArgs e)
        {
            EditUsingPlusMinus(sender, e);

        }

        private void ProformaUserControl_KeyDown(object sender, KeyEventArgs e)
        {
            EditUsingPlusMinus(sender, e);

        }

        private async void btnSearchImage_Click(object sender, EventArgs e)
        {
            ToasterHelper.PlayNotificationSound();
            SelectProductsForm selectProductsForm = await _controlManager.GetFAsync<SelectProductsForm>();
            selectProductsForm.SetSale();
            selectProductsForm.ShowDialog();
        }

        private void DgvِProducts_CellDoubleClick(object sender, DataGridViewCellEventArgs e)
        {
            EditFromTable(0);

        }

        private async void btnNext_Click(object sender, EventArgs e)
        {
            ToasterHelper.PlayNotificationSound();
            if (cmbpagination.SelectedIndex < cmbpagination.Items.Count - 1)
            {
                cmbpagination.SelectedIndex++;
                int skip = cmbpagination.SelectedIndex * Properties.Settings.Default.NoOfDataInDgvs;
                await RefreshDgvAsync1(skip);

            }
        }

        private async void btnPrev_Click(object sender, EventArgs e)
        {
            ToasterHelper.PlayNotificationSound();
            if (cmbpagination.SelectedIndex > 0)
            {
                cmbpagination.SelectedIndex--;
                int skip = cmbpagination.SelectedIndex * Properties.Settings.Default.NoOfDataInDgvs;

                await RefreshDgvAsync1(skip);
            }
        }

        private async void cmbpagination_SelectionChangeCommitted(object sender, EventArgs e)
        {
            ToasterHelper.PlayNotificationSound();
            if (cmbpagination.SelectedIndex != -1)
            {
                int skip = cmbpagination.SelectedIndex * Properties.Settings.Default.NoOfDataInDgvs;
                await RefreshDgvAsync1(skip);
            }
        }

        private async void btnSearch_Click(object sender, EventArgs e)
        {
            await RefreshDgvAsync1(0);
        }

        private void button2_Click(object sender, EventArgs e)
        {

        }

        private async void button1_Click(object sender, EventArgs e)
        {
            try
            {
                ToasterHelper.PlayNotificationSound();
                if (Dgv1.SelectedRows.Count > 0)
                {
                    DataTable dataTable = await FactureHelper.GetProformaFactureDataTableAsync(Convert.ToInt32(Dgv1.
                        CurrentRow.Cells[0].Value.ToString()));
                    Reports.ProformaReports.ProformaReports fact = _controlManager.GetR<Reports.ProformaReports.ProformaReports>();
                    fact.DataSource = dataTable;
                    Reports.ReportPerviwGui.PerviweForm perv = _controlManager.GetF<Reports.ReportPerviwGui.PerviweForm>();
                    perv.LoadReport(fact);
                    perv.ShowDialog();
                }
            }
            catch (Exception)
            {

                throw;
            }
        }
    }
}
