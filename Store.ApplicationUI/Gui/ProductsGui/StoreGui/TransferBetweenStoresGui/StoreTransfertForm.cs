using Microsoft.EntityFrameworkCore;
using Store.ApplicationUI.Code.Helper;
using Store.ApplicationUI.Gui.LoadingGui;
using Store.Core.Entities.Products;
using Store.Infrastructure.Data;
using Store.Infrastructure.Repositories;

namespace Store.ApplicationUI.Gui.ProductsGui.StoreGui.TransferBetweenStoresGui
{
    public partial class StoreTransfertForm : Form
    {
        private static MainForm _main;
        private ApplicationDbContext _context;
        private ProductsRepository? productsRepository;
        private static StoreTransfertForm _storeTransfertForm;
        private Product _product;
        public StoreTransfertForm(MainForm main)
        {
            InitializeComponent();
            _main = main;
            this.Owner = _main;
            _context = new ApplicationDbContext();

            productsRepository = new ProductsRepository(_context);

            LoadData();
            dateTimePicker1.Value = DateTime.Now;
        }
        public static bool CheckInstance()
        {
            return (_storeTransfertForm == null);
        }
        public static StoreTransfertForm Instance(MainForm main)
        {
            _main = main;
            // If the instance is null, create a new one and assign it to the static field


            _storeTransfertForm = new StoreTransfertForm(_main);



            // Return the singleton instance

            return _storeTransfertForm;
        }
        public void LoadData()
        {


            //ShowLoading


            LoadingForm.Instance(_main).Show();
            if (/*await Task.Run(() =>*/ _context.Database.CanConnect())/*)*/
            {
                //Start Load Data

                // if its an admin or Normal user 

                cmbStoresFrom.DataSource = _context.Stores.ToList();
                cmbStoresFrom.DisplayMember = "StoreName"; // Set the property to display
                cmbStoresFrom.ValueMember = "Id"; // Set the property to use as the value

                cmbStoreTo.DataSource = _context.Stores.ToList();
                cmbStoreTo.DisplayMember = "StoreName"; // Set the property to display
                cmbStoreTo.ValueMember = "Id";

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

        private void textBox1_KeyPress(object sender, KeyPressEventArgs e)
        {
            if (!char.IsDigit(e.KeyChar) && e.KeyChar != Properties.Settings.Default.DecimalSEP[0] && e.KeyChar != 8)
            {
                e.Handled = true;
            }
        }

        private void textBox3_KeyPress(object sender, KeyPressEventArgs e)
        {
            if (!char.IsDigit(e.KeyChar) && e.KeyChar != Properties.Settings.Default.DecimalSEP[0] && e.KeyChar != 8)
            {
                e.Handled = true;
            }
        }

        private void textBox4_KeyPress(object sender, KeyPressEventArgs e)
        {
            if (!char.IsDigit(e.KeyChar) && e.KeyChar != Properties.Settings.Default.DecimalSEP[0] && e.KeyChar != 8)
            {
                e.Handled = true;
            }
        }
        private void txtBareCode_KeyDown(object sender, KeyEventArgs e)
        {
            if (e.KeyCode == Keys.Enter)
            {
                SetProductsToTable();
            }
        }
        public async void SetProductsToTable()
        {
            //DgvProducts.DataSource = await Task.Run(() => productsRepository.GetAll(p => p.Category));
            _product = productsRepository.GetProductBarCode(txtBareCode.Text);
            if (_product is not null)
            {
                txtProductName.Text = _product.ProductName;
                txtTotalQty.Text = _product.Quentity.ToString();
            }
            else
            {
                MsgHelper.ShowEmptyResult();
                txtBareCode.Focus();
            }
            txtBareCode.Clear();
        }
        bool SetProductQuentity(decimal quentity)
        {
            var proId = _product.Id;
            decimal totalBuyPrice = 0;
            int count = 0;

            while (quentity > 0)
            {
                var productQty = _context.ProductsQuantities
                                 .FirstOrDefault(x => x.Qty > 0 && x.Pro_ID == proId && x.Store_ID == Convert.ToInt32(cmbStoresFrom.SelectedValue));
                if (productQty != null)
                {
                    if (productQty.Qty >= quentity)
                    {
                        productQty.Qty -= quentity;
                        _context.ProductsQuantities.Update(productQty);
                        _context.SaveChanges();

                        ProductsQuantitie prdQty = new ProductsQuantitie();
                        prdQty.Pro_ID = proId;
                        prdQty.Buy_Price = productQty.Buy_Price;
                        prdQty.Qty = quentity;
                        prdQty.Sale_PriceTax = productQty.Sale_PriceTax;
                        prdQty.DateExpiration = productQty.DateExpiration;
                        prdQty.Store_ID = Convert.ToInt32(cmbStoreTo.SelectedValue);
                        prdQty.StoreName = cmbStoreTo.Text;

                        _context.ProductsQuantities.Add(prdQty);
                        _context.SaveChanges();

                        ProductTransfer transfer = new ProductTransfer();
                        transfer.Quentity = quentity;
                        transfer.Pro_ID = proId;
                        transfer.Pro_Name = txtProductName.Text;
                        transfer.StoreFrom = cmbStoresFrom.Text;
                        transfer.StoreTo = cmbStoreTo.Text;
                        transfer.BuyPrice = productQty.Buy_Price;
                        transfer.SalePrice = productQty.Sale_PriceTax;
                        transfer.Date = dateTimePicker1.Value.ToString("yyyy-MM-dd-HH:mm");
                        transfer.Name = txtMaker.Text + " Using (" + Properties.Settings.Default.UserName + ")";
                        transfer.Reason = txtReason.Text;
                        _context.ProductsTransfers.Add(transfer);
                        _context.SaveChanges();
                        quentity = 0;


                    }
                    else if (productQty.Qty < quentity)
                    {
                        quentity -= productQty.Qty;

                        ProductsQuantitie prdQty = new ProductsQuantitie();
                        prdQty.Pro_ID = proId;
                        prdQty.Buy_Price = productQty.Buy_Price;
                        prdQty.Qty = quentity;
                        prdQty.Sale_PriceTax = productQty.Sale_PriceTax;
                        prdQty.DateExpiration = productQty.DateExpiration;
                        prdQty.Store_ID = Convert.ToInt32(cmbStoreTo.SelectedValue);
                        prdQty.StoreName = cmbStoreTo.Text;

                        _context.ProductsQuantities.Add(prdQty);
                        _context.SaveChanges();

                        ProductTransfer transfer = new ProductTransfer();
                        transfer.Quentity = quentity;
                        transfer.Pro_ID = proId;
                        transfer.Pro_Name = txtProductName.Text;
                        transfer.StoreFrom = cmbStoresFrom.Text;
                        transfer.StoreTo = cmbStoreTo.Text;
                        transfer.BuyPrice = productQty.Buy_Price;
                        transfer.SalePrice = productQty.Sale_PriceTax;
                        transfer.Date = dateTimePicker1.Value.ToString("yyyy-MM-dd-HH:mm");
                        transfer.Name = txtMaker.Text + " Using (" + Properties.Settings.Default.UserName + ")";
                        transfer.Reason = txtReason.Text;
                        _context.ProductsTransfers.Add(transfer);
                        _context.SaveChanges();

                        productQty.Qty = 0;
                        _context.ProductsQuantities.Update(productQty);
                        _context.SaveChanges();
                    }
                }
                else
                {

                    return false;
                }
            }

            return true;
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



            // Reinitialize form data (e.g., reload initial data)
            LoadData(); // This is a method where you load initial data

            // Optionally reset focus to the first control
            // Set focus to the first control
        }
        private void btnExportCustomer_Click(object sender, EventArgs e)
        {
            try
            {
                if (txtQtyTransfert.Text == string.Empty || txtProductName.Text == string.Empty)
                    return;
                if (cmbStoresFrom.SelectedValue.ToString() == cmbStoreTo.SelectedValue.ToString())
                { MsgHelper.ShowSameDirectionTransfert(); return; }
                _context = new ApplicationDbContext();
                if (Convert.ToDecimal(txtQtyTransfert.Text) <= 0 || Convert.ToDecimal(txtQtyTransfert.Text) > Convert.ToDecimal(txtTotalQty.Text))
                { MsgHelper.ShowInvalidQuentityTotransfert(); return; }

                using (var transaction = _context.Database.BeginTransaction())
                {
                    try
                    {
                        SetProductQuentity(Convert.ToInt32(txtQtyTransfert.Text));
                        _context.ProductsQuantities.Where(x => x.Qty <= 0).ExecuteDelete();
                        _context.SaveChanges();
                        transaction.Commit();
                        ResetForm();
                    }
                    catch (Exception)
                    {
                        transaction.Rollback();
                        throw;
                    }


                }

            }
            catch (Exception)
            {

                throw;
            }




        }
    }
}
