using System.Data;
using Microsoft.Data.SqlClient;
using Microsoft.EntityFrameworkCore;
using Store.ApplicationUI.Code.Helper;
using Store.ApplicationUI.Gui.PaymentGui;
using Store.ApplicationUI.Reports.ReportPerviwGui;
using Store.Core.Entities.Caisses;
using Store.Core.Entities.Customers;
using Store.Core.Entities.Products;
using Store.Core.Entities.Sales;
using Store.Infrastructure.Data;
using Store.Infrastructure.Repositories;

namespace Store.ApplicationUI.Gui.SalesGui.PosGui
{
    public partial class PosUserControl : UserControl
    {
        private static PosUserControl? _PosUserControl;
        private static PosForm? _posForm;
        public static SalesRepository? salesRepository;
        public static decimal PaidUp;
        public static decimal Remain;
        private ApplicationDbContext _context;
        public PosUserControl(PosForm main)
        {
            InitializeComponent();
            _posForm = main;
            _context = new ApplicationDbContext();


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
            salesRepository = new SalesRepository(_context);
            _PosUserControl = this;
            SetColumns();
            if (await Task.Run(() => _context.Database.CanConnect()))
                DgvQuickProducts.DataSource = _context.ProductQuickAccess.ToList();
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
        public decimal ConvertToFloat(string value)
        {
            //decimal quantity;
            //if (float.TryParse(value, out quantity))
            //{
            //    return quantity;
            //}
            return Convert.ToDecimal(value);
        }
        public void InitializeTextBoxesAndLables(Product product)
        {

            ProductDiscount productDiscount = _context.ProductDiscounts.
                Where(x => x.Id.ToString() == product.Id.ToString() && x.Quentity > 0

                && x.Store_Id == Properties.Settings.Default.FastSaleStore
                && x.DateStart <= DateTime.Now && x.DateEnd > DateTime.Now
                ).FirstOrDefault();
            txtProductName.Text = product.ProductName;

            ProductsQuantitie productQty = _context.ProductsQuantities.
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
                    decimal Discount = Convert.ToDecimal(txtSaleDiscount.Text);
                    decimal Amount = Convert.ToDecimal(txtSalePrice.Text);
                    decimal TotalAmount = Amount - (Amount * (Discount / 100));
                    txtTotalSaleProduct.Text = (ConvertToFloat(TotalAmount.ToString()) * Convert.ToInt32(txtQty.Text)).ToString();

                }
                if (txtSalePrice.Text != string.Empty && _product is not null)
                {

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
                                          select Convert.ToDecimal(row.Cells[4].FormattedValue)).Sum()
                                          .ToString("f2");
                    TotalFacture = (from DataGridViewRow row in DgvِProducts.Rows
                                    where row.Cells[4].FormattedValue.ToString() != string.Empty
                                    select Convert.ToDecimal(row.Cells[4].FormattedValue)).Sum();
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
        async void PayNowEvent(object sender, KeyEventArgs e)
        {
            if (e.KeyCode == Keys.F12)
            {
                await PayNowAsync();
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

                ProductsQuantitie productQty = _context.ProductsQuantities.
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
        SaleProfit SetSaleProfit(int i, decimal buyPrice)
        {
            var row = DgvِProducts.Rows[i];
            return new SaleProfit
            {
                Order_ID = Convert.ToInt32(lblFactureNumber.Text),
                Cust_Name = lblCustomerName.Text,
                Pro_ID = Convert.ToInt32(row.Cells[5].Value.ToString()),
                Quentity = ConvertToFloat(row.Cells[2].Value.ToString()),
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
                product.Quentity = Math.Max(0, product.Quentity - ConvertToFloat(DgvِProducts.Rows[i].Cells[2].Value.ToString()));
            }

            return product;
        }

        decimal SetProductQuentity(decimal quentity, int i)
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
                        productQty.Qty -= quentity;
                        quentity = 0;
                        _context.ProductsQuantities.Update(productQty);
                        _context.SaveChanges();

                    }
                    else
                    {
                        quentity -= productQty.Qty;
                        productQty.Qty = 0;
                        _context.ProductsQuantities.Update(productQty);
                        _context.SaveChanges();

                    }

                }
                else
                {
                    totalBuyPrice += _context.Products.FirstOrDefault(x => x.Id.ToString() == proId)?.BuyPrice ?? 0;
                    return count > 0 ? totalBuyPrice / count : totalBuyPrice;
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
        private async void btnPay_Click(object sender, EventArgs e)
        {
            await PayNowAsync();


        }
        public void InitializeData(string paidUp, string remain)
        {
            PaidUp = ConvertToFloat(paidUp);
            Remain = ConvertToFloat(remain);
        }
        async void HandleCaisseAndDeposits(decimal paidAmount, decimal totalAmount)
        {
            var amountToDeposit = Math.Min(paidAmount, totalAmount);
            _context.Update(SetCaisse(amountToDeposit));
            await _context.AddAsync(SetCaisseDeposit(amountToDeposit));
        }
        private int saleID;
        async Task PayNowAsync()
        {
            if (DgvِProducts.Rows.Count > 0 && rbSale.Checked)
            {
                if (IdCustomer.Text != Properties.Settings.Default.IdCustomerSale)
                {
                    AddPaymentForm addPaymentForm = new(_posForm, 3);
                    addPaymentForm.LoadData(TotalFacture.ToString(), TotalFacture.ToString(), "0");
                    addPaymentForm.ShowDialog();
                }
                else
                {
                    PaidUp = ConvertToFloat(TotalFacture.ToString());
                    Remain = 0;
                }

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
                            var buyPrice = SetProductQuentity(Convert.ToDecimal(DgvِProducts.Rows[i].Cells[2].Value.ToString()), i);
                            var profit = SetSaleProfit(i, buyPrice);
                            profit.Order_ID = sale.Id;
                            await _context.AddAsync(profit);
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
                        ResetForm();
                        DataTable saleDetailsTable = await GetSellDetailsDataTableAsync(saleID);
                        Reports.sale8cm sale8Cm = new();
                        sale8Cm.DataSource = saleDetailsTable;
                        XtraForm1 xtraForm1 = new(sale8Cm);
                        xtraForm1.ShowDialog();
                    }
                    catch (Exception ex)
                    {
                        await transaction.RollbackAsync();
                        MessageBox.Show(ex.Message);
                    }
                }
            }
        }
        private async Task<DataTable> GetSellDetailsDataTableAsync(int orderId)
        {

            using (var context = new ApplicationDbContext())
            {
                var orderIdParam = new SqlParameter("@orderID", orderId);
                var connection = context.Database.GetDbConnection();

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
                            return sellDetailsTable;
                        }
                    }
                }
                finally
                {
                    await connection.CloseAsync();
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
