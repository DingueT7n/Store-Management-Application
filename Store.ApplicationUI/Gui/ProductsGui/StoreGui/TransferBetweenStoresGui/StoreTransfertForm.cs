using Microsoft.EntityFrameworkCore;
using Store.ApplicationUI.Code.Helper;
using Store.ApplicationUI.Code.Models;
using Store.ApplicationUI.Gui.LoadingGui;
using Store.Core.Entities.Products;
using Store.Core.Interfaces;
using Store.Infrastructure.Data;

namespace Store.ApplicationUI.Gui.ProductsGui.StoreGui.TransferBetweenStoresGui
{
    public partial class StoreTransfertForm : Form
    {
        private readonly MainForm _main;
        private readonly ApplicationDbContext _context;
        private readonly IProductRepository productsRepository;
        private Product _product = null;
        public StoreTransfertForm(MainForm main, ApplicationDbContext context, IProductRepository productsRepository)
        {
            InitializeComponent();
            _main = main;
            this.Owner = _main;
            _context = context;

            this.productsRepository = productsRepository;


            dateTimePicker1.Value = DateTime.Now;
        }


        public async Task LoadData()
        {

            dgvHelper.ResetForm(this);
            //ShowLoading

            vider();
            LoadingForm.Instance(_main).Show();
            if (/*await Task.Run(() =>*/await _context.Database.CanConnectAsync())/*)*/
            {
                //Start Load Data

                // if its an admin or Normal user 

                cmbStoresFrom.DataSource = await _context.Stores.ToListAsync();
                cmbStoresFrom.DisplayMember = "StoreName"; // Set the property to display
                cmbStoresFrom.ValueMember = "Id"; // Set the property to use as the value

                cmbStoreTo.DataSource = await _context.Stores.ToListAsync();
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
            if (LocalUser.User is not null)

                txtMaker.Text = Code.Models.LocalUser.User.UserName;

            LoadingForm.Instance(_main).Hide();
            // Show EmptyDAta

        }
        void vider()
        {
            txtBareCode.Text = "";
            txtMaker.Text = "";
            txtQtyInFrom.Text = "0.00";
            txtQtyTransfert.Text = "0.00";
            txtTotalQty.Text = "0.00";
            txtReason.Text = "";
            txtProductName.Text = "";



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
        public void SetProductsToTable()
        {
            //DgvProducts.DataSource = await Task.Run(() => productsRepository.GetAll(p => p.Category));
            _product = productsRepository.GetProductBarCode(txtBareCode.Text);
            if (_product is not null)
            {
                txtProductName.Text = _product.ProductName;
                txtTotalQty.Text = _product.Quentity.ToString();
                cmbStoresFrom_SelectionChangeCommitted(null, null);
            }
            else
            {
                MsgHelper.ShowEmptyResult();
                txtBareCode.Focus();
            }
            txtBareCode.Clear();
        }
        async Task<bool> SetProductQuentity(decimal quentity)
        {
            var proId = _product.Id;

            while (quentity > 0)
            {
                var productQty = await _context.ProductsQuantities
                                 .FirstOrDefaultAsync(x => x.Qty > 0 && x.Pro_ID == proId && x.Store_ID == Convert.ToInt32(cmbStoresFrom.SelectedValue));
                if (productQty != null)
                {
                    if (productQty.Qty >= quentity)
                    {
                        productQty.Qty -= quentity;
                        _context.ProductsQuantities.Update(productQty);
                        await _context.SaveChangesAsync();

                        ProductsQuantitie prdQty = new ProductsQuantitie();
                        prdQty.Pro_ID = proId;
                        prdQty.Buy_Price = productQty.Buy_Price;
                        prdQty.Qty = quentity;
                        prdQty.Sale_PriceTax = productQty.Sale_PriceTax;
                        prdQty.DateExpiration = productQty.DateExpiration;
                        prdQty.Store_ID = Convert.ToInt32(cmbStoreTo.SelectedValue);
                        prdQty.StoreName = cmbStoreTo.Text;

                        await _context.ProductsQuantities.AddAsync(prdQty);
                        await _context.SaveChangesAsync();

                        ProductTransfer transfer = new ProductTransfer();
                        transfer.Quentity = quentity;
                        transfer.Pro_ID = proId;
                        transfer.Pro_Name = txtProductName.Text;
                        transfer.StoreFrom = cmbStoresFrom.Text;
                        transfer.StoreTo = cmbStoreTo.Text;
                        transfer.BuyPrice = productQty.Buy_Price;
                        transfer.SalePrice = productQty.Sale_PriceTax;
                        transfer.Date = dateTimePicker1.Value.ToString("yyyy-MM-dd/HH:mm");
                        transfer.Name = txtMaker.Text + " Using (" + Properties.Settings.Default.UserName + ")";
                        transfer.Reason = txtReason.Text;
                        await _context.ProductsTransfers.AddAsync(transfer);
                        await _context.SaveChangesAsync();
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

                        await _context.ProductsQuantities.AddAsync(prdQty);
                        await _context.SaveChangesAsync();

                        ProductTransfer transfer = new ProductTransfer();
                        transfer.Quentity = quentity;
                        transfer.Pro_ID = proId;
                        transfer.Pro_Name = txtProductName.Text;
                        transfer.StoreFrom = cmbStoresFrom.Text;
                        transfer.StoreTo = cmbStoreTo.Text;
                        transfer.BuyPrice = productQty.Buy_Price;
                        transfer.SalePrice = productQty.Sale_PriceTax;
                        transfer.Date = dateTimePicker1.Value.ToString("yyyy-MM-dd/HH:mm");
                        transfer.Name = txtMaker.Text + " Using (" + Properties.Settings.Default.UserName + ")";
                        transfer.Reason = txtReason.Text;
                        await _context.ProductsTransfers.AddAsync(transfer);
                        await _context.SaveChangesAsync();

                        productQty.Qty = 0;
                        _context.ProductsQuantities.Update(productQty);
                        await _context.SaveChangesAsync();
                    }
                }
                else
                {

                    return false;
                }
            }

            return true;
        }

        private async void btnExportCustomer_Click(object sender, EventArgs e)
        {
            try
            {
                ToasterHelper.PlayNotificationSound();
                if (txtQtyTransfert.Text == string.Empty || txtProductName.Text == string.Empty)
                    return;
                if (cmbStoresFrom.SelectedValue?.ToString() == cmbStoreTo.SelectedValue?.ToString())
                { MsgHelper.ShowSameDirectionTransfert(); return; }

                if (Convert.ToDecimal(txtQtyTransfert.Text) <= 0 || Convert.ToDecimal(txtQtyTransfert.Text) > Convert.ToDecimal(txtTotalQty.Text))
                { MsgHelper.ShowInvalidQuentityTotransfert(); return; }

                using (var transaction = await _context.Database.BeginTransactionAsync())
                {
                    try
                    {
                        await SetProductQuentity(Convert.ToInt32(txtQtyTransfert.Text));
                        await _context.ProductsQuantities.Where(x => x.Qty <= 0).ExecuteDeleteAsync();
                        await _context.SaveChangesAsync();
                        await transaction.CommitAsync();
                        Code.Helper.ToasterHelper.ShowTransfertProduct();


                    }
                    catch (Exception)
                    {
                        await transaction.RollbackAsync();
                        throw;
                    }


                }

            }
            catch (Exception)
            {

                throw;
            }




        }

        private void StoreTransfertForm_Load(object sender, EventArgs e)
        {


        }

        private void cmbStoresFrom_SelectionChangeCommitted(object sender, EventArgs e)
        {
            if (_product is not null)
            {
                string selectedStoreName = cmbStoresFrom.SelectedValue?.ToString(); // safer
                if (!string.IsNullOrWhiteSpace(selectedStoreName))
                {
                    var productQty = _context.ProductsQuantities
                        .Where(x => x.Store_ID.ToString() == selectedStoreName && x.Pro_ID == _product.Id)
                        .Sum(x => x.Qty);

                    txtQtyInFrom.Text = productQty.ToString();
                }
            }
        }
    }
}
