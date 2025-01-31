using Microsoft.EntityFrameworkCore;
using Store.ApplicationUI.Code.Helper;
using Store.ApplicationUI.Gui.LoadingGui;
using Store.Core.Entities.Buys;
using Store.Core.Entities.Caisses;
using Store.Core.Entities.Customers;
using Store.Core.Entities.Products;
using Store.Core.Entities.Returns;
using Store.Core.Entities.Suppliers;
using Store.Infrastructure.Data;
using Store.Infrastructure.Repositories;

namespace Store.ApplicationUI.Gui.ReturnsGui
{
    public partial class ReturnUserControl : UserControl
    {
        public static BuysRepository? buysRepository;


        private static ReturnUserControl? _ReturnUserControl;
        private static MainForm? _main;
        private static ApplicationDbContext _context;
        public static ReturnsRepository? ReturnsRepository;

        public ReturnUserControl()
        {
            InitializeComponent();
        }

        private void lblCustomer_Click(object sender, EventArgs e)
        {

        }
        int idfacture;
        private void btnSearchFactureNumber_Click(object sender, EventArgs e)
        {
            DgvِProducts.Rows.Clear();
            cmbStores.SelectedValue = Properties.Settings.Default.StoreIdDefault;

            if (txtFactureNumber.Text == string.Empty)
            {
                MsgHelper.ShowRequiredFields();
                return;

            }
            else if (rbSale.Checked)
            {

                var result = ReturnsRepository.getSaleDetailById(txtFactureNumber.Text);

                foreach (var item in result)
                {
                    try
                    {
                        int rowIndex = DgvِProducts.Rows.Add(); // Add a new row to the DataGridView
                        DataGridViewRow newRow = DgvِProducts.Rows[rowIndex];

                        // Set values in the new row
                        newRow.Cells[0].Value = item.Product.ProductName;
                        newRow.Cells[1].Value = item.Price;
                        newRow.Cells[2].Value = item.Quentity;
                        newRow.Cells[3].Value = item.Discount;
                        newRow.Cells[4].Value = item.Total;
                        DtpDateFacture.Value = item.Sale.Date;
                        newRow.Cells[5].Value = item.Pro_ID;
                        newRow.Cells[6].Value = item.Product.CodeBar;
                        DgvِProducts.CurrentCell = DgvِProducts[0, DgvِProducts.Rows.Count - 1];

                        cmbCustomers.SelectedValue = item.Cust_ID;



                    }
                    catch (Exception ex) { MessageBox.Show(ex.Message); }

                }
                if (result.Count > 0)
                {
                    totalFacture = result.First().Sale.TotalOrder;
                    paidUp = result.First().Sale.PaidUP;
                    remain = result.First().Sale.Remain;
                    lblFactureTime.Text = $" وقت الفاتورة {result.First().Sale.Time}";
                    lblOperationMaker.Text = $" المسؤول عن العميلة {result.First().Sale.User_Name}";
                    lblTotalFacture.Text = $" اجمالي الفاتورة {totalFacture}";
                    lblPaidUp.Text = $" المدفوع {paidUp}";
                    lblRemain.Text = $" الباقي {remain}";
                }

            }
            else
            {
                var result = ReturnsRepository.getBuyDetailById(txtFactureNumber.Text);

                foreach (var item in result)
                {
                    try
                    {
                        int rowIndex = DgvِProducts.Rows.Add(); // Add a new row to the DataGridView
                        DataGridViewRow newRow = DgvِProducts.Rows[rowIndex];

                        // Set values in the new row
                        newRow.Cells[0].Value = item.Product.ProductName;
                        newRow.Cells[1].Value = item.Price;
                        newRow.Cells[2].Value = item.Quentity;
                        newRow.Cells[3].Value = item.Discount;
                        newRow.Cells[4].Value = item.Total;
                        newRow.Cells[5].Value = item.Product.WholesalePrice;
                        newRow.Cells[6].Value = item.Product.SalePriceTax;
                        DtpDateFacture.Value = item.Buy.Date;
                        newRow.Cells[7].Value = item.Pro_ID;
                        newRow.Cells[8].Value = item.Product.CodeBar;
                        DgvِProducts.CurrentCell = DgvِProducts[0, DgvِProducts.Rows.Count - 1];

                        cmbSuppliers.SelectedValue = item.Sup_ID;


                    }
                    catch (Exception ex) { MessageBox.Show(ex.Message); }

                }
                if (result.Count > 0)
                {
                    totalFacture = result.First().Buy.Total;
                    paidUp = result.First().Buy.PaidUP;
                    remain = result.First().Buy.Remain;
                    lblFactureTime.Text = $" وقت الفاتورة {result.First().Buy.Time}";
                    lblOperationMaker.Text = $" المسؤول عن العميلة {result.First().Buy.User_Name}";
                    lblTotalFacture.Text = $" اجمالي الفاتورة {totalFacture}";
                    lblPaidUp.Text = $" المدفوع {paidUp}";
                    lblRemain.Text = $" الباقي {remain}";
                }
            }
            idfacture = Convert.ToInt32(txtFactureNumber.Text);
            lblEmptyData.Visible = dgvHelper.IsEmpty(DgvِProducts);
        }
        decimal totalFacture = 0m;
        decimal paidUp = 0m;
        decimal remain = 0m;

        public static ReturnUserControl Instance(MainForm main)
        {
            _main = main;
            // If the instance is null, create a new one and assign it to the static field
            _context = new ApplicationDbContext();
            if (_ReturnUserControl == null)
            {

                buysRepository = new BuysRepository(_context);
                ReturnsRepository = new ReturnsRepository(_context);
                _ReturnUserControl = new ReturnUserControl();
            }
            // Return the singleton instance
            _ReturnUserControl.LoadData();
            return _ReturnUserControl;
        }
        public static void RefreshDgv()
        {
            //DgvِProducts.DataSource = await Task.Run(() => productsRepository.GetAllProducts());
            _ReturnUserControl.LoadData();
        }
        // methodes 
        public async void LoadData()
        {

            DgvِProducts.Columns.Clear();

            //ShowLoading
            LoadingForm.Instance(_main).Show();
            if (await Task.Run(() => ReturnsRepository.IsConnected()))
            {
                cmbSuppliers.DataSource = null;

                //Start Load Data
                if (rbSale.Checked)
                {
                    SetColumnsSales();
                    if (cmbCustomers.Text != string.Empty)
                        cmbCustomers.Text = "اختر العميل";
                    cmbCustomers.DataSource = _context.Customers.ToList();
                    cmbCustomers.DisplayMember = "CustomerName";
                    cmbCustomers.ValueMember = "Id";

                    cmbCustomers.BringToFront();
                }
                else
                {
                    SetColumnsbuys();

                    cmbSuppliers.Text = "اختر مورد";
                    cmbSuppliers.DataSource = _context.Suppliers.ToList();
                    cmbSuppliers.DisplayMember = "SupplierName";
                    cmbSuppliers.ValueMember = "Id";

                    cmbSuppliers.BringToFront();

                }
                if (cmbStores.Text != string.Empty)
                    cmbStores.Text = "اختر مخزن";
                cmbStores.DataSource = _context.Stores.ToList();
                cmbStores.DisplayMember = "StoreName";
                cmbStores.ValueMember = "Id";


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
        private void SetColumnsSales()
        {

            if (DgvِProducts.Columns.Count == 0) // Ensure columns are added only once
            {
                DgvِProducts.Columns.Add("اسم المنتج", "اسم المنتج");
                DgvِProducts.Columns.Add("سعر المنتج", "سعر المنتج");
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
            //DgvِProducts.Columns[7].Visible = false;
            ////DgvِProducts.Columns[11].Visible = false;
            ////DgvِProducts.Columns[12].Visible = false;
            ////DgvِProducts.Columns[15].Visible = false;
            ////DgvِProducts.Columns[13].Visible = false;
            //DgvProducts.Columns[13].Visible = false;
            //DgvProducts.Columns[14].Visible = false;
            //DgvProducts.Columns[13].Visible = false;
            //DgvProducts.Columns[15].Visible = false;
        }

        private void SetColumnsbuys()
        {
            if (DgvِProducts.Columns.Count == 0)
            {
                DgvِProducts.Columns.Add("اسم المنتج", "اسم المنتج"); // String column
                DgvِProducts.Columns.Add("سعر الشراء", "سعر الشراء"); // String or decimal column
                DgvِProducts.Columns.Add("الكمية", "الكمية"); // String or decimal column
                DgvِProducts.Columns.Add("اجمالي الشراء", "اجمالي الشراء"); // String or decimal column
                DgvِProducts.Columns.Add("سعر البيع", "سعر البيع"); // String or decimal column
                DgvِProducts.Columns.Add("سعر الجملة", "سعر الجملة"); // String or decimal column
                DgvِProducts.Columns.Add("سعر البيع باحتساب الضريبة", "سعر البيع باحتساب الضريبة"); // String or decimal column




                DgvِProducts.Columns.Add("معرف المنتوج", "معرف المنتوج"); // ID column
                DgvِProducts.Columns.Add("باركود", "باركود"); // String column for barcode
            }


            //DgvِProducts.Columns[8].Visible = false;
            //DgvِProducts.Columns[7].Visible = false;

            // Visible of Columns
            //DgvProducts.Columns[0].Visible = false;
            ////DgvِProducts.Columns[6].Visible = false;

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





        private Product _product;


        private decimal TotalFacture;


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
        void CalculateStatistics()
        {
            try
            {


                lblEmptyData.Visible = dgvHelper.IsEmpty(DgvِProducts);
                if (DgvِProducts.Rows.Count >= 0)
                {
                    //lblTotalPriceinFacture.Text = "المبلغ الاجمالي في الفاتورة :" +
                    //                     (from DataGridViewRow row in DgvِProducts.Rows
                    //                      where row.Cells[3].FormattedValue.ToString() != string.Empty
                    //                      select Convert.ToDecimal(row.Cells[3].FormattedValue)).Sum()
                    //                      .ToString("f2");
                    //TotalFacture = (from DataGridViewRow row in DgvِProducts.Rows
                    //                where row.Cells[3].FormattedValue.ToString() != string.Empty
                    //                select Convert.ToDecimal(row.Cells[3].FormattedValue)).Sum();
                    //lblTotalQuentity.Text = "اجمالي الكميات في الجدول :" +
                    //          (from DataGridViewRow row in DgvِProducts.Rows
                    //           where row.Cells[2].FormattedValue.ToString() != string.Empty
                    //           select Convert.ToDecimal(row.Cells[2].FormattedValue)).Sum()
                    //           .ToString("f2");
                    //lblTotalProductsInTable.Text = $"مجموع المنتجات في الجدول: {DgvِProducts.Rows.Count}";
                }

            }
            catch (Exception)
            {

                throw;
            }

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

        private void txtFactureNumber_KeyDown(object sender, KeyEventArgs e)
        {
            if (e.KeyCode == Keys.Enter)
            {
                btnSearchFactureNumber_Click(sender, e);
            }
        }

        private void rbBuy_CheckedChanged(object sender, EventArgs e)
        {
            LoadData();

        }
        Return SetRefundBuy()
        {

            Return buy = new Return();

            buy.TotalOrder = _main.ConvertToFloat(TotalFacture.ToString());
            //buy.SupplierId = Convert.ToInt32(cmbSuppliers.SelectedValue);
            buy.OrderDate = DateTime.Now;
            buy.PaidUP = _main.ConvertToFloat(paidUp.ToString());
            buy.Remain = _main.ConvertToFloat(remain.ToString());
            buy.Time = DateTime.Now.ToString("yyyy:MM:dd:HH:mm");
            buy.User_Name = Properties.Settings.Default.UserName;
            buy.OrderType = "Refund Buy";
            return buy;
        }
        ReturnDetail SetRefundBuyDetail(int i)
        {
            //dgvProducts.Rows[i].Cells[0].Value.ToString()
            ReturnDetail buyDetail = new ReturnDetail();
            buyDetail.Order_ID = idfacture;
            buyDetail.Sup_Name = cmbSuppliers.Text;
            buyDetail.Date = DtpDateFacture.Text;
            buyDetail.Pro_ID = Convert.ToInt32(DgvِProducts.Rows[i].Cells[7].Value.ToString());
            buyDetail.Qty = _main.ConvertToFloat(DgvِProducts.Rows[i].Cells[2].Value.ToString());
            buyDetail.Price = _main.ConvertToFloat(DgvِProducts.Rows[i].Cells[1].Value.ToString());
            buyDetail.Total = _main.ConvertToFloat(DgvِProducts.Rows[i].Cells[3].Value.ToString());
            buyDetail.TaxValue = Properties.Settings.Default.TaxValue;
            buyDetail.PriceWithTax = _main.ConvertToFloat(DgvِProducts.Rows[i].Cells[6].Value.ToString());
            return buyDetail;
        }
        Return SetRefundSale()
        {

            Return buy = new Return();

            buy.TotalOrder = totalFacture;
            //buy.SupplierId = Convert.ToInt32(cmbSuppliers.SelectedValue);
            buy.OrderDate = DateTime.Now;
            buy.PaidUP = paidUp;
            buy.Remain = remain;
            buy.Time = DateTime.Now.ToString("yyyy:MM:dd:HH:mm");
            buy.User_Name = Properties.Settings.Default.UserName;
            buy.OrderType = "Refund Sale";

            return buy;
        }
        ReturnDetail SetRefundSaleDetail(int i)
        {
            //dgvProducts.Rows[i].Cells[0].Value.ToString()
            ReturnDetail buyDetail = new ReturnDetail();
            buyDetail.Order_ID = idfacture;
            buyDetail.Cust_Name = cmbCustomers.Text;
            buyDetail.Date = DtpDateFacture.Text;
            buyDetail.Pro_ID = Convert.ToInt32(DgvِProducts.Rows[i].Cells[5].Value.ToString());
            buyDetail.Qty = _main.ConvertToFloat(DgvِProducts.Rows[i].Cells[2].Value.ToString());
            buyDetail.Price = _main.ConvertToFloat(DgvِProducts.Rows[i].Cells[1].Value.ToString());
            buyDetail.Total = _main.ConvertToFloat(DgvِProducts.Rows[i].Cells[4].Value.ToString());
            buyDetail.TaxValue = Properties.Settings.Default.TaxValue;
            buyDetail.PriceWithTax = totalFacture;
            return buyDetail;
        }
        SupplierMoney RemoveSupMoney()
        {

            SupplierMoney supplierMoney = new SupplierMoney();
            supplierMoney.Order_ID = Convert.ToInt32(txtFactureNumber.Text);
            supplierMoney.Sup_ID = Convert.ToInt32(cmbSuppliers.SelectedValue);
            supplierMoney.SupplierName = cmbSuppliers.Text;
            supplierMoney.Order_Date = DtpDateFacture.Value;
            supplierMoney.Price = _main.ConvertToFloat(remain.ToString());
            supplierMoney.Time = DateTime.Now.ToString("HH:mm");

            return supplierMoney;
        }
        BuyDetail SetReturnDetails(int i)
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
        //Product SetProduct(int i, bool tru, string idprod, ApplicationDbContext context)
        //{
        //    //dgvProducts.Rows[i].Cells[0].Value.ToString()

        //    Product product = context.Products.Where(x => x.Id.ToString() == idprod).FirstOrDefault();
        //    var qty = _main.ConvertToFloat(DgvِProducts.Rows[i].Cells[2].Value.ToString());
        //    if (product is not null)
        //    {
        //        if (tru)
        //            product.Quentity = product.Quentity > 0 ? product.Quentity - qty : 0;
        //        else
        //            product.Quentity = product.Quentity + qty;
        //    }
        //    return product;
        //}
        Supplier SetSupplier()
        {
            //dgvProducts.Rows[i].Cells[0].Value.ToString()
            var supId = Convert.ToInt32(cmbSuppliers.SelectedValue);
            Supplier supplier = _context.Suppliers.Where(x => x.Id == supId).FirstOrDefault();
            if (supplier is not null)
            {
                supplier.TotalDebts -= remain;

            }
            return supplier;
        }
        Customer setCustomer()
        {
            //dgvProducts.Rows[i].Cells[0].Value.ToString()
            var custID = Convert.ToInt32(cmbCustomers.SelectedValue);
            Customer customer = _context.Customers.Where(x => x.Id == custID).FirstOrDefault();
            if (customer is not null)
            {
                customer.TotalDebts -= remain;
            }
            return customer;
        }
        //public ProductsQuantitie SetProductQuantity(int rowIndex, ApplicationDbContext context)
        //{
        //    if (context == null)
        //        throw new ArgumentNullException(nameof(context));

        //    if (rowIndex < 0 || rowIndex >= DgvِProducts.Rows.Count)
        //        throw new ArgumentOutOfRangeException(nameof(rowIndex));

        //    ProductsQuantitie productQty = null;
        //    int productId;

        //    try
        //    {
        //        // Determine the product ID based on the selected radio button
        //        productId = rbBuy.Checked
        //            ? Convert.ToInt32(DgvِProducts.Rows[rowIndex].Cells[7].Value?.ToString())
        //            : Convert.ToInt32(DgvِProducts.Rows[rowIndex].Cells[5].Value?.ToString());

        //        if (productId <= 0)
        //            throw new InvalidOperationException("Invalid product ID.");

        //        // Get the latest product quantity entry
        //        productQty = context.ProductsQuantities
        //                            .Where(x => x.Id == productId)
        //                            .OrderByDescending(x => x.Id)
        //                            .FirstOrDefault();

        //        if (productQty == null)
        //            throw new InvalidOperationException("Product quantity not found.");

        //        // Parse the quantity to be removed/added
        //        if (!decimal.TryParse(DgvِProducts.Rows[rowIndex].Cells[2].Value?.ToString(), out decimal removeQty))
        //            throw new InvalidOperationException("Invalid quantity value.");

        //        // Update the product quantity based on the operation
        //        if (rbBuy.Checked)
        //        {
        //            UpdateProductQuantityOnBuy(context, productQty, removeQty, productId);
        //        }
        //        else
        //        {
        //            UpdateProductQuantityOnSell(context, productQty, removeQty);
        //        }
        //    }
        //    catch (Exception ex)
        //    {
        //        // Log the exception (consider using a logging framework like NLog or Serilog)
        //        Console.WriteLine($"An error occurred: {ex.Message}");
        //        throw; // Re-throw the exception to propagate it up the call stack
        //    }

        //    return productQty;
        //}

        //private void UpdateProductQuantityOnBuy(ApplicationDbContext context, ProductsQuantitie productQty, decimal removeQty, int productId)
        //{
        //    using (var transaction = context.Database.BeginTransaction())
        //    {
        //        try
        //        {
        //            while (removeQty > 0)
        //            {
        //                if (productQty.Qty >= removeQty)
        //                {
        //                    productQty.Qty -= removeQty;
        //                    removeQty = 0;
        //                }
        //                else
        //                {
        //                    removeQty -= productQty.Qty;
        //                    productQty.Qty = 0;
        //                }

        //                context.Update(productQty);
        //                context.SaveChanges();

        //                if (removeQty > 0)
        //                {
        //                    productQty = context.ProductsQuantities
        //                                        .Where(x => x.Id == productId)
        //                                        .OrderByDescending(x => x.Id)
        //                                        .FirstOrDefault();

        //                    if (productQty == null || productQty.Qty == 0)
        //                        break;
        //                }
        //            }

        //            transaction.Commit();
        //        }
        //        catch
        //        {
        //            transaction.Rollback();
        //            throw;
        //        }
        //    }
        //}

        //private void UpdateProductQuantityOnSell(ApplicationDbContext context, ProductsQuantitie productQty, decimal addQty)
        //{
        //    productQty.Qty += addQty;
        //    context.Update(productQty);
        //    context.SaveChanges();
        //}
        Caisse SetCaisseBuyRefund(decimal value, ApplicationDbContext context)
        {
            //dgvProducts.Rows[i].Cells[0].Value.ToString()

            Caisse caisse = context.Caisses.Where(x => x.Id == Properties.Settings.Default.DefaultCaisseId).FirstOrDefault();
            if (caisse is not null)
            {
                caisse.MoneyinCaisse += value;
            }
            context.Caisses.Update(caisse);
            context.SaveChanges();
            return caisse;

        }
        Caisse SetCaisseSaleRefund(decimal value, ApplicationDbContext context)
        {
            //dgvProducts.Rows[i].Cells[0].Value.ToString()

            Caisse caisse = context.Caisses.Where(x => x.Id == Properties.Settings.Default.DefaultCaisseId).FirstOrDefault();
            if (caisse is not null)
            {
                caisse.MoneyinCaisse -= value;
            }
            context.Caisses.Update(caisse);
            context.SaveChanges();
            return caisse;

        }
        CaisseDeposit SetCaisseDeposit(decimal value)
        {
            //dgvProducts.Rows[i].Cells[0].Value.ToString()

            return new CaisseDeposit
            {
                Caisse_ID = Properties.Settings.Default.DefaultCaisseId,
                Time = DateTime.Now.ToString("yyyy:MM:dd:HH:mm"),
                Date = DateTime.Now,
                Name = $"  ({Properties.Settings.Default.UserName})  المورد ({cmbSuppliers.Text}) بحساب ",
                Money = value,
                Reason = $"ارجاع المنتوجات للمورد من المخزن ({cmbStores.Text}) استرجاع الاموال من المورد",
                Type = "ايداع عن طريق ارجاع المنتوجات لصاحبها"
            };


        }
        CaisseWithdraw SetCaisseWithdraw(decimal value)
        {
            //dgvProducts.Rows[i].Cells[0].Value.ToString()


            var caisseWithdraw = new CaisseWithdraw
            {
                Caisse_ID = Properties.Settings.Default.DefaultCaisseId,
                Time = DateTime.Now.ToString("yyyy:MM:dd:HH:mm"),
                Date = DateTime.Now,
                Name = $" ({Properties.Settings.Default.UserName})  العميل ({cmbCustomers.Text}) بحساب ",
                Money = value,
                Reason = $"ارجاع المنتوجات للمخزن ({cmbStores.Text}) واعادة الاموال للعميل",
                Type = "سحب عن طريق ارجاع المنتوجات للمخزن وارجاع الاموال لصاحبها"
            };

            return caisseWithdraw;

        }

        //private void btnPay_Click(object sender, EventArgs e)
        //{
        //    ToasterHelper.PlayNotificationSound();
        //    if (!(DgvِProducts.Rows.Count > 0))
        //        return;
        //    if (!MsgHelper.ShowRefundDialog())
        //        return;
        //    using (var _context = new ApplicationDbContext())
        //    {
        //        if (rbBuy.Checked)
        //        {
        //            using (var transaction = _context.Database.BeginTransaction())
        //            {
        //                try
        //                {
        //                    _context.Buys.Remove(_context.Buys.FirstOrDefault(x => x.Id == idfacture));
        //                    _context.SaveChanges();
        //                    var bd = _context.BuyDetails.FirstOrDefault(x => x.Order_ID == idfacture);
        //                    _context.BuyDetails.Where(x => x.Order_ID == idfacture).ExecuteDelete();
        //                    _context.SaveChanges();
        //                    var refund = SetRefundBuy();
        //                    _context.Add(refund);
        //                    _context.SaveChanges();

        //                    for (int i = 0; i < DgvِProducts.Rows.Count; i++)
        //                    {
        //                        var refundBuyDetail = SetRefundBuyDetail(i);
        //                        refundBuyDetail.Order_ID = refund.Id;
        //                        _context.ReturnsDetails.Add(refundBuyDetail);

        //                        // Update product and add quantity
        //                        _context.Update(SetProduct(i, true, DgvِProducts.Rows[i].Cells[7].Value.ToString(), _context));
        //                        SetProductQuantity(i, _context);
        //                    }
        //                    if (paidUp >= totalFacture)
        //                    {
        //                        var sm = _context.SuppliersMoneys.FirstOrDefault(x => x.Id == idfacture);
        //                        if (sm != null)
        //                        {
        //                            _context.SuppliersMoneys.Remove(sm);
        //                            _context.SaveChanges();
        //                        }

        //                        SetCaisseBuyRefund(totalFacture, _context);
        //                        _context.CaissesDeposits.Add(SetCaisseDeposit(totalFacture));
        //                        _context.SaveChanges();
        //                    }
        //                    else if (remain > 0)
        //                    {
        //                        var sm = _context.SuppliersMoneys.FirstOrDefault(x => x.Id == idfacture);
        //                        if (sm != null)
        //                        {
        //                            _context.SuppliersMoneys.Remove(sm);
        //                            _context.SaveChanges();
        //                        }
        //                        _context.Update(SetSupplier());
        //                        SetCaisseBuyRefund(paidUp, _context);
        //                        _context.Add(SetCaisseDeposit(paidUp));

        //                        _context.SaveChanges();

        //                    }
        //                    transaction.CommitAsync();
        //                    Code.Helper.ToasterHelper.ShowAddedRefund();

        //                }
        //                catch (Exception ex)
        //                {
        //                    transaction.RollbackAsync();
        //                    MessageBox.Show(ex.Message);
        //                }
        //            }

        //        }
        //        else
        //        {
        //            using (var transaction = _context.Database.BeginTransaction())
        //            {
        //                try
        //                {
        //                    _context.SalesProfits.Where(x => x.Order_ID == idfacture).ExecuteDelete();
        //                    _context.SaveChanges();
        //                    var saleDetails = _context.SalesDetails.Where(x => x.Order_ID == idfacture);
        //                    _context.SalesDetails.RemoveRange(saleDetails);
        //                    _context.SaveChanges();
        //                    _context.Sales.Remove(_context.Sales.FirstOrDefault(x => x.Id == idfacture));
        //                    _context.SaveChanges();

        //                    var refund = SetRefundSale();
        //                    _context.Add(refund);
        //                    _context.SaveChanges();

        //                    for (int i = 0; i < DgvِProducts.Rows.Count; i++)
        //                    {
        //                        var refundSaleDetail = SetRefundSaleDetail(i);
        //                        refundSaleDetail.Order_ID = refund.Id;
        //                        _context.ReturnsDetails.Add(refundSaleDetail);

        //                        // Update product and add quantity
        //                        _context.Update(SetProduct(i, false, DgvِProducts.Rows[i].Cells[5].Value.ToString(), _context));
        //                        SetProductQuantity(i, _context);
        //                    }
        //                    if (paidUp >= totalFacture)
        //                    {
        //                        var cm = _context.CustomersMoneys.FirstOrDefault(x => x.Order_ID == idfacture);
        //                        if (cm != null)
        //                        {
        //                            _context.CustomersMoneys.Remove(cm);
        //                            _context.SaveChanges();
        //                        }

        //                        SetCaisseSaleRefund(totalFacture, _context);
        //                        _context.CaissesWithdraws.Add(SetCaisseWithdraw(totalFacture));
        //                        _context.SaveChanges();
        //                    }
        //                    else if (remain > 0)
        //                    {
        //                        var sm = _context.CustomersMoneys.FirstOrDefault(x => x.Order_ID == idfacture);
        //                        if (sm != null)
        //                        {
        //                            _context.CustomersMoneys.Remove(sm);
        //                            _context.SaveChanges();
        //                        }
        //                        _context.Update(setCustomer());
        //                        SetCaisseSaleRefund(paidUp, _context);
        //                        _context.Add(SetCaisseWithdraw(paidUp));
        //                        _context.SaveChanges();
        //                    }
        //                    transaction.Commit();
        //                }
        //                catch (Exception ex)
        //                {
        //                    transaction.Rollback();
        //                    MessageBox.Show(ex.Message);
        //                }
        //            }
        //        }

        //        ResetForm();
        //    }
        //}











        //--------------------------------------------------------------------------------------------------------------
        private async void btnPay_Click(object sender, EventArgs e)
        {
            try
            {
                ToasterHelper.PlayNotificationSound();

                if (DgvِProducts.Rows.Count <= 0 || !MsgHelper.ShowRefundDialog())
                    return;

                using (var context = new ApplicationDbContext())
                {
                    if (rbBuy.Checked)
                    {
                        await ProcessBuyRefundAsync(context);
                    }
                    else
                    {
                        await ProcessSaleRefundAsync(context);
                    }

                    ResetForm();
                    ToasterHelper.ShowAddedRefund();
                }
            }
            catch (Exception ex)
            {
                MessageBox.Show($"An error occurred: {ex.Message}", "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
        }

        private async Task ProcessBuyRefundAsync(ApplicationDbContext context)
        {
            using (var transaction = await context.Database.BeginTransactionAsync())
            {
                try
                {
                    // Remove Buy and BuyDetails
                    var buy = await context.Buys.FirstOrDefaultAsync(x => x.Id == idfacture);
                    if (buy != null)
                    {
                        context.Buys.Remove(buy);
                        await context.SaveChangesAsync();
                    }

                    await context.BuyDetails.Where(x => x.Order_ID == idfacture).ExecuteDeleteAsync();
                    await context.SaveChangesAsync();

                    // Add Refund and RefundDetails
                    var refund = SetRefundBuy();
                    context.Add(refund);
                    await context.SaveChangesAsync();

                    await ProcessRefundDetailsAsync(context, refund.Id, true);

                    // Handle Supplier and Caisse
                    await HandleSupplierAndCaisseAsync(context, refund.TotalOrder, refund.PaidUP, refund.Remain);

                    await transaction.CommitAsync();
                }
                catch (Exception ex)
                {
                    ToasterHelper.ShowErrorHappened(ex.Message);
                    await transaction.RollbackAsync();
                    throw;
                }
            }
        }

        private async Task ProcessSaleRefundAsync(ApplicationDbContext context)
        {
            using (var transaction = await context.Database.BeginTransactionAsync())
            {
                try
                {
                    // Remove SalesProfit, SalesDetails, and Sales
                    await context.SalesProfits.Where(x => x.Order_ID == idfacture).ExecuteDeleteAsync();
                    await context.SaveChangesAsync();

                    var saleDetails = await context.SalesDetails.Where(x => x.Order_ID == idfacture).ToListAsync();
                    context.SalesDetails.RemoveRange(saleDetails);
                    await context.SaveChangesAsync();

                    var sale = await context.Sales.FirstOrDefaultAsync(x => x.Id == idfacture);
                    if (sale != null)
                    {
                        context.Sales.Remove(sale);
                        await context.SaveChangesAsync();
                    }

                    // Add Refund and RefundDetails
                    var refund = SetRefundSale();

                    context.Add(refund);
                    await context.SaveChangesAsync();

                    await ProcessRefundDetailsAsync(context, refund.Id, false);

                    // Handle Customer and Caisse
                    await HandleCustomerAndCaisseAsync(context, refund.TotalOrder, refund.PaidUP, refund.Remain);

                    await transaction.CommitAsync();
                }
                catch
                {
                    await transaction.RollbackAsync();
                    throw;
                }
            }
        }

        private async Task ProcessRefundDetailsAsync(ApplicationDbContext context, int refundId, bool isBuy)
        {
            for (int i = 0; i < DgvِProducts.Rows.Count; i++)
            {
                var refundDetail = isBuy ? SetRefundBuyDetail(i) : SetRefundSaleDetail(i);
                refundDetail.Order_ID = refundId;
                context.ReturnsDetails.Add(refundDetail);

                // Update product quantity
                var productId = isBuy ? DgvِProducts.Rows[i].Cells[7].Value?.ToString() : DgvِProducts.Rows[i].Cells[5].Value?.ToString();
                if (productId != null)
                {
                    var product = await SetProductAsync(i, isBuy, productId, context);
                    context.Update(product);
                    await SetProductQuantityAsync(i, context);
                }
            }
            await context.SaveChangesAsync();
        }

        private async Task HandleSupplierAndCaisseAsync(ApplicationDbContext context, decimal totalOrder, decimal paidUp, decimal remain)
        {
            if (paidUp >= totalOrder)
            {
                var supplierMoney = await context.SuppliersMoneys.FirstOrDefaultAsync(x => x.Id == idfacture);
                if (supplierMoney != null)
                {
                    context.SuppliersMoneys.Remove(supplierMoney);
                    await context.SaveChangesAsync();
                }

                SetCaisseBuyRefund(totalOrder, context);
                context.CaissesDeposits.Add(SetCaisseDeposit(totalOrder));
                await context.SaveChangesAsync();
            }
            else if (remain > 0)
            {
                var supplierMoney = await context.SuppliersMoneys.FirstOrDefaultAsync(x => x.Id == idfacture);
                if (supplierMoney != null)
                {
                    context.SuppliersMoneys.Remove(supplierMoney);
                    await context.SaveChangesAsync();
                }

                var supplier = SetSupplier();
                if (supplier != null)
                    context.Update(supplier);
                SetCaisseBuyRefund(paidUp, context);
                context.CaissesDeposits.Add(SetCaisseDeposit(paidUp));
                await context.SaveChangesAsync();
            }
        }

        private async Task HandleCustomerAndCaisseAsync(ApplicationDbContext context, decimal totalOrder, decimal paidUp, decimal remain)
        {
            if (paidUp >= totalOrder)
            {
                var customerMoney = await context.CustomersMoneys.FirstOrDefaultAsync(x => x.Order_ID == idfacture);
                if (customerMoney != null)
                {
                    context.CustomersMoneys.Remove(customerMoney);
                    await context.SaveChangesAsync();
                }

                SetCaisseSaleRefund(totalOrder, context);
                context.CaissesWithdraws.Add(SetCaisseWithdraw(totalOrder));
                await context.SaveChangesAsync();
            }
            else if (remain > 0)
            {
                var customerMoney = await context.CustomersMoneys.FirstOrDefaultAsync(x => x.Order_ID == idfacture);
                if (customerMoney != null)
                {
                    context.CustomersMoneys.Remove(customerMoney);
                    await context.SaveChangesAsync();
                }

                var customer = setCustomer();
                if (customer != null)
                    context.Update(customer);
                SetCaisseSaleRefund(paidUp, context);
                context.CaissesWithdraws.Add(SetCaisseWithdraw(paidUp));
                await context.SaveChangesAsync();
            }
        }

        private async Task<Product> SetProductAsync(int i, bool isBuy, string productId, ApplicationDbContext context)
        {
            var product = await context.Products.FirstOrDefaultAsync(x => x.Id.ToString() == productId);
            if (product != null)
            {
                var qty = _main.ConvertToFloat(DgvِProducts.Rows[i].Cells[2].Value?.ToString());
                product.Quentity = isBuy ? Math.Max(product.Quentity - qty, 0) : product.Quentity + qty;
            }
            return product;
        }
        ProductsQuantitie SetProductQuentity(int i, ApplicationDbContext context)
        {
            //dgvProducts.Rows[i].Cells[0].Value.ToString()
            ProductsQuantitie productQty = new();
            if (rbBuy.Checked)
            {
                var lis = context.ProductsQuantities.Where(x => x.Id == Convert.ToInt32(DgvِProducts.Rows[i].Cells[7].Value.ToString())).ToList();
                productQty = lis.Last();
            }
            else
            {
                var lis = context.ProductsQuantities.Where(x => x.Id == Convert.ToInt32(DgvِProducts.Rows[i].Cells[5].Value.ToString())).ToList();
                productQty = lis.Last();
            }
            decimal removeQty = _main.ConvertToFloat(DgvِProducts.Rows[i].Cells[2].Value.ToString());
            if (productQty is not null)
            {
                if (rbBuy.Checked)
                {
                    while (removeQty > 0)
                    {
                        if (productQty.Qty >= removeQty)
                        {
                            productQty.Qty -= removeQty;
                            removeQty = 0;
                            context.Update(productQty);
                            context.SaveChanges();
                        }
                        else
                        {
                            removeQty -= productQty.Qty;
                            productQty.Qty = 0;
                            context.Update(productQty);
                            context.SaveChanges();
                            productQty = context.ProductsQuantities.FirstOrDefault(x => x.Id == Convert.ToInt32(DgvِProducts.Rows[i].Cells[7].Value.ToString()));
                            removeQty = (productQty == null || productQty.Qty == 0) ? 0 : removeQty;

                        }
                    }

                }
                else
                {
                    productQty.Qty += removeQty;
                    context.Update(productQty);
                    context.SaveChanges();

                }
            }
            return productQty;
        }
        private async Task SetProductQuantityAsync(int rowIndex, ApplicationDbContext context)
        {
            if (context == null)
                throw new ArgumentNullException(nameof(context));

            if (rowIndex < 0 || rowIndex >= DgvِProducts.Rows.Count)
                throw new ArgumentOutOfRangeException(nameof(rowIndex));

            try
            {
                // Determine the product ID based on the selected radio button
                var productId = rbBuy.Checked
                    ? DgvِProducts.Rows[rowIndex].Cells[7].Value?.ToString()
                    : DgvِProducts.Rows[rowIndex].Cells[5].Value?.ToString();

                if (string.IsNullOrEmpty(productId))
                    throw new InvalidOperationException("Product ID is missing or invalid.");

                // Parse the quantity to be updated
                if (!decimal.TryParse(DgvِProducts.Rows[rowIndex].Cells[2].Value?.ToString(), out decimal quantity))
                    throw new InvalidOperationException("Invalid quantity value.");
                ProductsQuantitie productQuantity = new();

                var productQty = rbBuy.Checked ? await context.ProductsQuantities.Where(x => x.Pro_ID == Convert.ToInt32(productId)).OrderByDescending(x => x.Id)
                    .FirstOrDefaultAsync() : await
                     context.ProductsQuantities.Where(x => x.Pro_ID == Convert.ToInt32(productId)).OrderBy(x => x.Id)
                    .FirstOrDefaultAsync();
                if (productQty is not null)
                {
                    if (rbBuy.Checked)
                    {
                        while (quantity > 0)
                        {
                            if (productQty is not null && productQty.Qty >= quantity)
                            {
                                productQty.Qty -= quantity;
                                quantity = 0;
                                context.Update(productQty);
                                await context.SaveChangesAsync();
                            }
                            else if (productQty is not null)
                            {
                                quantity -= productQty.Qty;
                                productQty.Qty = 0;
                                context.Update(productQty);
                                await context.SaveChangesAsync();
                                productQty = context.ProductsQuantities.FirstOrDefault(x => x.Pro_ID == Convert.ToInt32(productId));
                                quantity = (productQty == null || productQty.Qty == 0) ? 0 : quantity;

                            }
                            else
                            {
                                quantity = 0;
                            }
                        }

                    }
                    else
                    {
                        productQty.Qty += quantity;
                        context.Update(productQty);
                        await context.SaveChangesAsync();

                    }
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
    }
}