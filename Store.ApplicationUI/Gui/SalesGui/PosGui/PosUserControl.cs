using Store.ApplicationUI.Code.Helper;
using Store.ApplicationUI.Gui.PaymentGui;
using Store.Core.Entities.Caisses;
using Store.Core.Entities.Customers;
using Store.Core.Entities.Products;
using Store.Core.Entities.Sales;
using Store.Infrastructure.Repositories;

namespace Store.ApplicationUI.Gui.SalesGui.PosGui
{
    public partial class PosUserControl : UserControl
    {
        private static PosUserControl? _PosUserControl;
        private static PosForm? _posForm;
        public static SalesRepository? salesRepository;
        public static float PaidUp;
        public static float Remain;
        public PosUserControl(PosForm main)
        {
            InitializeComponent();
            _posForm = main;


        }
        public static bool CheckInstance()
        {
            return (_PosUserControl == null);
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
            if (await Task.Run(() => salesRepository.IsConnected()))
            {
                //Start Load Data
                //txtFactureNumber.Text = salesRepository.GetFactureNumber();
                //// if its an admin or Normal user 
                //SetColumns();

                //cmbCustomers.DataSource = MainForm.Context.Customers.ToList();
                //cmbCustomers.DisplayMember = "CustomerName";
                //cmbCustomers.ValueMember = "Id";
                //cmbCustomers.Text = "اختر العميل";

                //cmbStores.DataSource = MainForm.Context.Stores.ToList();
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
        public void BringTofront(bool b)
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
            if (!char.IsDigit(e.KeyChar) && e.KeyChar != Properties.Settings.Default.DecimalSEP[0] && e.KeyChar != 8)
            {
                e.Handled = true;
            }
        }

        private void txtQty_KeyUp(object sender, KeyEventArgs e)
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
        async void OnLoad()
        {
            txtSearchBarCode.Focus();
            salesRepository = new SalesRepository(MainForm.Context);
            _PosUserControl = this;
            SetColumns();
            if (await Task.Run(() => MainForm.Context.Database.CanConnect()))
                DgvQuickProducts.DataSource = MainForm.Context.ProductQuickAccess.ToList();
            SetQuickColumns();
            lblFactureNumber.Text = salesRepository.GetFactureNumber();
            lblUserName.Text = Properties.Settings.Default.UserName;

            lblCustomerName.Text = Properties.Settings.Default.DefaultCustomerSale;
            IdCustomer.Text = Properties.Settings.Default.IdCustomerSale;
            CalculateStatistics();
        }
        private async void PosUserControl_Load(object sender, EventArgs e)
        {

            OnLoad();
            //Add Roles

        }

        private void txtSearchBarCode_KeyDown(object sender, KeyEventArgs e)
        {

            if (e.KeyCode == Keys.Enter)
            {
                SetProductsToTable();
                AddNewRow();
                return;
            }

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
                //MsgHelper.ShowEmptyResult();
                txtSearchBarCode.Focus();

            }
            txtSearchBarCode.Clear();

        }
        public float ConvertToFloat(string value)
        {
            float quantity;
            if (float.TryParse(value, out quantity))
            {
                return quantity;
            }
            return quantity;
        }
        public void InitializeTextBoxesAndLables(Product product)
        {

            ProductDiscount productDiscount = MainForm.Context.ProductDiscounts.
                Where(x => x.Id.ToString() == product.Id.ToString() && x.Quentity > 0

                && x.Store_Id == Properties.Settings.Default.FastSaleStore
                && x.DateStart <= DateTime.Now && x.DateEnd > DateTime.Now
                ).FirstOrDefault();
            txtProductName.Text = product.ProductName;

            ProductsQuantitie productQty = MainForm.Context.ProductsQuantities.
                      Where(x => x.Pro_ID == product.Id && x.Qty > 0 && x.Store_ID == Properties.Settings.Default.FastSaleStore).FirstOrDefault();


            if (productDiscount is not null)
                txtSaleDiscount.Text = productDiscount.DiscountValue.ToString();
            else txtSaleDiscount.Text = "0";
            if (txtQty.Text != string.Empty)
            {
                if (product.Quentity < ConvertToFloat(txtQty.Text))
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
        }
        public void ClearBoxes()
        {
            txtProductName.Text = string.Empty;
            txtSaleDiscount.Text = string.Empty;
            txtQty.Text = string.Empty;
            txtTotalSaleProduct.Text = string.Empty;
            txtSalePrice.Text = string.Empty;
        }

        void CalculateAmount()
        {
            try
            {
                if (txtSalePrice.Text != string.Empty && txtQty.Text != string.Empty
                     && txtSaleDiscount.Text != string.Empty)
                {
                    double Discount = Convert.ToDouble(txtSaleDiscount.Text);
                    double Amount = Convert.ToDouble(txtSalePrice.Text);
                    double TotalAmount = Amount - (Amount * (Discount / 100));
                    txtTotalSaleProduct.Text = (ConvertToFloat(TotalAmount.ToString()) * Convert.ToInt32(txtQty.Text)).ToString();

                }
                if (txtSalePrice.Text != string.Empty && _product is not null)
                {

                }
            }
            catch (Exception ex) { MessageBox.Show(ex.Message); }
        }
        int rowIndex;
        private double TotalFacture;
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
                txtSearchBarCode.Focus();
            }
            catch (Exception ex) { MessageBox.Show(ex.Message); }

        }
        void AddNewRow()
        {

            if (txtProductName.Text != string.Empty && txtSalePrice.Text != string.Empty)
            {
                try
                {

                    for (int i = 0; i < DgvِProducts.Rows.Count; i++)
                    {
                        if (DgvِProducts.Rows[i].Cells[5].Value.ToString() == _product.Id.ToString())
                        {
                            //MsgHelper.ShowDuplicatedItemsAndInformTeCaiser();  Toaster
                            DgvِProducts.Rows[i].Cells[2].Value = (ConvertToFloat(DgvِProducts.Rows[i].Cells[2].Value.ToString()) + 1).ToString();
                            DgvِProducts.Rows[i].Cells[4].Value = (ConvertToFloat(DgvِProducts.Rows[i].Cells[2].Value.ToString()) *
                                ConvertToFloat(DgvِProducts.Rows[i].Cells[1].Value.ToString())).ToString();

                            txtSearchBarCode.Focus();
                            ClearBoxes();
                            CalculateStatistics();
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
                                          select Convert.ToDouble(row.Cells[4].FormattedValue)).Sum()
                                          .ToString("f2");
                    TotalFacture = (from DataGridViewRow row in DgvِProducts.Rows
                                    where row.Cells[4].FormattedValue.ToString() != string.Empty
                                    select Convert.ToDouble(row.Cells[4].FormattedValue)).Sum();
                    lblQuentityValue.Text =
                              (from DataGridViewRow row in DgvِProducts.Rows
                               where row.Cells[2].FormattedValue.ToString() != string.Empty
                               select Convert.ToDouble(row.Cells[2].FormattedValue)).Sum()
                               .ToString("f2");
                    lblProductIntable.Text = $"{DgvِProducts.Rows.Count}";
                }

            }
            catch (Exception)
            {

                throw;
            }

        }
        public void EditUsingPlusMinus(object sender, KeyEventArgs e)
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
        void PayNowEvent(object sender, KeyEventArgs e)
        {
            if (e.KeyCode == Keys.F12)
            {
                PayNow();
            }
        }
        public void GetTheEventAndSender(object sender, KeyEventArgs e)
        {
            this.EditUsingPlusMinus(sender, e);
            this.DeleteSenderEvent(sender, e);
            this.Arrows(sender, e);
            this.PayNowEvent(sender, e);

        }
        private void SetQuickColumns()
        {

            DgvQuickProducts.Columns[0].HeaderCell.Value = "معرف المنتوج";
            DgvQuickProducts.Columns[1].HeaderCell.Value = "باركود";
            DgvQuickProducts.Columns[2].HeaderCell.Value = "اسم المنتج";
            DgvQuickProducts.Columns[3].HeaderCell.Value = "صورة المنتج";
            DgvQuickProducts.Columns[4].HeaderCell.Value = "المنتج";
            DgvQuickProducts.Columns[5].HeaderCell.Value = "معرف السرعة";

            DgvQuickProducts.Columns[3].Visible = false;
            DgvQuickProducts.Columns[4].Visible = false;
            DgvQuickProducts.Columns[5].Visible = false;
            DgvQuickProducts.Columns[0].Visible = false;


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
            OnLoad();




            // Optionally reset focus to the first control
            // Set focus to the first control
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
                _product = salesRepository.GetProductBarCode(DgvِProducts.CurrentRow.Cells[6].Value.ToString());
                txtProductName.Text = this.DgvِProducts.CurrentRow.Cells[0].Value.ToString();
                txtSaleDiscount.Text = this.DgvِProducts.CurrentRow.Cells[3].Value.ToString();
                if (ConvertToFloat(DgvِProducts.CurrentRow.Cells[2].Value.ToString()) + q > 1)
                    txtQty.Text = (ConvertToFloat(DgvِProducts.CurrentRow.Cells[2].Value.ToString()) + q).ToString();
                else txtQty.Text = "1";
                txtTotalSaleProduct.Text = this.DgvِProducts.CurrentRow.Cells[4].Value.ToString();
                txtSalePrice.Text = this.DgvِProducts.CurrentRow.Cells[1].Value.ToString();


                DgvِProducts.Rows.RemoveAt(DgvِProducts.CurrentRow.Index);
                txtQty.Focus();
                CalculateAmount();
                CalculateStatistics();

                ProductsQuantitie productQty = MainForm.Context.ProductsQuantities.
                          Where(x => x.Pro_ID == _product.Id && x.Qty >= ConvertToFloat(txtQty.Text)
                          && x.Store_ID == Properties.Settings.Default.FastSaleStore).FirstOrDefault();
            }
            catch (Exception ex) { MessageBox.Show(ex.Message); }

        }


        private void txtSearchBarCode_KeyPress(object sender, KeyPressEventArgs e)
        {
            if (!char.IsDigit(e.KeyChar) && e.KeyChar != Properties.Settings.Default.DecimalSEP[0] && e.KeyChar != 8)
            {
                e.Handled = true;
            }

        }

        private void btnEditSelected_Click(object sender, EventArgs e)
        {
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
            catch (Exception ex) { MessageBox.Show(ex.Message); }
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
            catch (Exception ex) { MessageBox.Show(ex.Message); }
        }
        private void btnDeleteSelected_Click(object sender, EventArgs e)
        {
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
            catch (Exception ex) { MessageBox.Show(ex.Message); }
        }
        private void btnUp_Click(object sender, EventArgs e)
        {
            UpArrow();
        }

        private void btnSearchImage_Click(object sender, EventArgs e)
        {
            SelectProductsForm selectProductsForm = SelectProductsForm.Instance(_posForm);
            selectProductsForm.Show();
        }
        Sale SetSale()
        {

            Sale sale = new Sale();

            sale.TotalOrder = ConvertToFloat(TotalFacture.ToString());
            sale.CustomerId = Convert.ToInt32(IdCustomer.Text);
            sale.Date = DateTime.Now;
            sale.PaidUP = ConvertToFloat(PaidUp.ToString());
            sale.Remain = ConvertToFloat(Remain.ToString());
            sale.Time = DateTime.Now.ToString("HH:mm");
            sale.User_Name = Properties.Settings.Default.UserName;

            return sale;
        }
        CustomerReport SetCustReport()
        {
            CustomerReport custReport = new CustomerReport();
            custReport.Order_ID = Convert.ToInt32(lblFactureNumber.Text);
            custReport.Cust_ID = Convert.ToInt32(IdCustomer.Text);
            custReport.Cust_Name = lblCustomerName.Text;
            custReport.Date = DateTime.Now;
            custReport.Price = ConvertToFloat(PaidUp.ToString());
            custReport.Time = DateTime.Now.ToString("HH:mm");
            return custReport;
        }
        CustomerMoney SetCustMoney()
        {

            CustomerMoney customerMoney = new CustomerMoney();
            customerMoney.Order_ID = Convert.ToInt32(lblFactureNumber.Text);
            customerMoney.Cust_ID = Convert.ToInt32(IdCustomer.Text);
            customerMoney.Cust_Name = lblCustomerName.Text;
            customerMoney.Order_Date = DateTime.Now;
            customerMoney.Price = ConvertToFloat(Remain.ToString());
            customerMoney.Time = DateTime.Now.ToString("HH:mm");
            customerMoney.Reminder_Date = DateTime.Now.AddDays(Properties.Settings.Default.DaysAddDebt);
            return customerMoney;
        }
        SaleDetail SetSaleDetail(int i)
        {
            //dgvProducts.Rows[i].Cells[0].Value.ToString()
            SaleDetail saleDetail = new SaleDetail();
            saleDetail.Order_ID = Convert.ToInt32(lblFactureNumber.Text);
            saleDetail.Cust_ID = Convert.ToInt32(IdCustomer.Text);
            saleDetail.Pro_ID = Convert.ToInt32(DgvِProducts.Rows[i].Cells[5].Value.ToString());
            saleDetail.Quentity = ConvertToFloat(DgvِProducts.Rows[i].Cells[2].Value.ToString());
            saleDetail.Price = ConvertToFloat(DgvِProducts.Rows[i].Cells[1].Value.ToString());
            saleDetail.Total = ConvertToFloat(DgvِProducts.Rows[i].Cells[4].Value.ToString());
            saleDetail.TaxValue = Properties.Settings.Default.TaxValue;
            saleDetail.PriceWithTax = ConvertToFloat(DgvِProducts.Rows[i].Cells[1].Value.ToString());
            return saleDetail;
        }
        SaleProfit SetSaleProfit(int i)
        {
            //dgvProducts.Rows[i].Cells[0].Value.ToString()
            SaleProfit SaleProfit = new SaleProfit();
            SaleProfit.Order_ID = Convert.ToInt32(lblFactureNumber.Text);
            SaleProfit.Cust_Name = IdCustomer.Text;
            SaleProfit.Pro_ID = Convert.ToInt32(DgvِProducts.Rows[i].Cells[5].Value.ToString());
            SaleProfit.Quentity = ConvertToFloat(DgvِProducts.Rows[i].Cells[2].Value.ToString());
            SaleProfit.Price = ConvertToFloat(DgvِProducts.Rows[i].Cells[1].Value.ToString());
            SaleProfit.Total = ConvertToFloat(DgvِProducts.Rows[i].Cells[4].Value.ToString());
            //SaleProfit.TaxValue = Properties.Settings.Default.TaxValue;
            //SaleProfit.PriceWithTax = ConvertToFloat(DgvِProducts.Rows[i].Cells[1].Value.ToString());
            return SaleProfit;
        }
        Product SetProduct(int i)
        {
            //dgvProducts.Rows[i].Cells[0].Value.ToString()
            var proId = DgvِProducts.Rows[i].Cells[5].Value.ToString();
            Product product = MainForm.Context.Products.Where(x => x.Id.ToString() == proId
            /* && x.CodeBar == DgvِProducts.Rows[i].Cells[6].Value.ToString()*/).FirstOrDefault();
            if (product is not null)
            {
                if (product.Quentity - ConvertToFloat(DgvِProducts.Rows[i].Cells[2].Value.ToString()) > 0)
                    product.Quentity = product.Quentity - ConvertToFloat(DgvِProducts.Rows[i].Cells[2].Value.ToString());
                else product.Quentity = 0;

            }
            return product;
        }
        void SetProductQuentity(double Quentity, int i)
        {
            //dgvProducts.Rows[i].Cells[0].Value.ToString()
            var proId = DgvِProducts.Rows[i].Cells[5].Value.ToString();
            while (Quentity > 0)
            {
                ProductsQuantitie productQty = MainForm.Context.ProductsQuantities.
                        Where(x => x.Pro_ID.ToString() == proId && x.Qty > ConvertToFloat(0.ToString())).FirstOrDefault();
                if (productQty is not null)
                {
                    if (productQty.Qty >= ConvertToFloat(Quentity.ToString()))
                    {
                        productQty.Qty = productQty.Qty - ConvertToFloat(Quentity.ToString());
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
            var custId = Convert.ToInt32(IdCustomer.Text);
            Customer customer = MainForm.Context.Customers.Where(x => x.Id == custId).FirstOrDefault();
            if (customer is not null)
            {
                customer.TotalDebts = customer.TotalDebts + Remain;
            }
            return customer;
        }
        Caisse SetCaisse(float value)
        {
            //dgvProducts.Rows[i].Cells[0].Value.ToString()

            Caisse caisse = MainForm.Context.Caisses.FirstOrDefault((x => x.Id == Properties.Settings.Default.DefaultCaisseId));
            if (caisse is not null)
            {
                caisse.MoneyinCaisse += ConvertToFloat(value.ToString());
            }
            return caisse;

        }
        CaisseDeposit SetCaisseDeposit(float value)
        {
            //dgvProducts.Rows[i].Cells[0].Value.ToString()


            var caisseDeposit = new CaisseDeposit
            {
                Caisse_ID = Properties.Settings.Default.DefaultCaisseId,
                Time = DateTime.Now.ToString("HH:mm:ss"),
                Date = DateTime.Now,
                Name = $"  {Properties.Settings.Default.UserName}  مشتري عادي  بحساب ",
                Money = ConvertToFloat(value.ToString()),
                Reason = "مبيعة سريعة",
                Type = "ايداع عن طريق بيع منتجات (مال ربحي )"
            };

            return caisseDeposit;

        }
        private async void btnPay_Click(object sender, EventArgs e)
        {
            PayNow();
        }
        public void InitializeData(string paidUp, string remain)
        {
            PaidUp = ConvertToFloat(paidUp);
            Remain = ConvertToFloat(remain);
        }
        async void PayNow()
        {
            if (DgvِProducts.Rows.Count > 0)
            {

                if (rbSale.Checked)
                {
                    if (IdCustomer.Text != "4")
                    {
                        AddPaymentForm addPaymentForm = new(_posForm, 3);
                        addPaymentForm.LoadData(TotalFacture.ToString(), TotalFacture.ToString(), "0");
                        addPaymentForm.ShowDialog();
                    }
                    else
                    {
                        PaidUp = ConvertToFloat(TotalFacture.ToString());
                        Remain = ConvertToFloat(0.ToString());
                    }

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
                            if (PaidUp <= TotalFacture)
                            {
                                MainForm.Context.Update(SetCaisse(ConvertToFloat((PaidUp).ToString())));
                                MainForm.Context.Add(SetCaisseDeposit(ConvertToFloat((PaidUp).ToString())));

                            }
                            else
                            {
                                MainForm.Context.Update(SetCaisse(ConvertToFloat((TotalFacture).ToString())));
                                MainForm.Context.Add(SetCaisseDeposit(ConvertToFloat((TotalFacture).ToString())));
                            }
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
                            ResetForm();

                        }
                        catch (Exception ex)
                        {
                            await transaction.RollbackAsync();
                            MessageBox.Show(ex.Message);
                        }
                    }

                }
            }
        }
        private void btnChoseCustomer_Click(object sender, EventArgs e)
        {
            SelectCustomerForm SelectCustomerForm = SelectCustomerForm.Instance(_posForm);
            SelectCustomerForm.Show();
        }
    }
}
