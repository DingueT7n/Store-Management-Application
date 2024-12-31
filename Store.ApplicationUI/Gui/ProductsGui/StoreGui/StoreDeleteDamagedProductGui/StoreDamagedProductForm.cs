using Microsoft.EntityFrameworkCore;
using Store.ApplicationUI.Code.Helper;
using Store.ApplicationUI.Gui.LoadingGui;
using Store.Core.Entities.Products;
using Store.Infrastructure.Data;
using Store.Infrastructure.Repositories;

namespace Store.ApplicationUI.Gui.ProductsGui.StoreGui.StoreDeleteDamagedProductGui
{
    public partial class StoreDamagedProductForm : Form
    {
        private static MainForm _main;
        private ApplicationDbContext _context;
        private ProductsRepository? productsRepository;
        private static StoreDamagedProductForm _storeDamagedProductForm;
        private Product _product;
        public StoreDamagedProductForm(MainForm main)
        {
            InitializeComponent();
            _main = main;
            this.Owner = _main;
            _context = new ApplicationDbContext();

            productsRepository = new ProductsRepository(_context);

            LoadData();
            dateTimePicker1.Value = DateTime.Now;
        }
        public static StoreDamagedProductForm Instance(MainForm main)
        {
            _main = main;
            // If the instance is null, create a new one and assign it to the static field


            _storeDamagedProductForm = new StoreDamagedProductForm(_main);



            // Return the singleton instance

            return _storeDamagedProductForm;
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

        private void txtBareCode_KeyDown(object sender, KeyEventArgs e)
        {
            if (e.KeyCode == Keys.Enter)
            {
                SetProductsToTable();
            }
        }

        private void txtBareCode_KeyPress(object sender, KeyPressEventArgs e)
        {
            if (!char.IsDigit(e.KeyChar) && e.KeyChar != Properties.Settings.Default.DecimalSEP[0] && e.KeyChar != 8)
            {
                e.Handled = true;
            }
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

                        ProductOutStore transfer = new ProductOutStore();
                        transfer.Quentity = quentity;
                        transfer.Pro_ID = proId;
                        transfer.ProductName = txtProductName.Text;
                        transfer.StoreName = cmbStoresFrom.Text;
                        transfer.Date = dateTimePicker1.Value;
                        transfer.Time = DateTime.Now.ToString("HH-mm");
                        transfer.Name = txtMaker.Text + " Using (" + Properties.Settings.Default.UserName + ")";
                        transfer.Reason = txtReason.Text;
                        _context.ProductsOutStore.Add(transfer);
                        _context.SaveChanges();
                        quentity = 0;
                    }
                    else if (productQty.Qty < quentity)
                    {
                        quentity -= productQty.Qty;



                        ProductOutStore transfer = new ProductOutStore();
                        transfer.Quentity = quentity;
                        transfer.Pro_ID = proId;
                        transfer.ProductName = txtProductName.Text;
                        transfer.StoreName = cmbStoresFrom.Text;
                        transfer.Date = dateTimePicker1.Value;
                        transfer.Time = DateTime.Now.ToString("HH-mm");
                        transfer.Name = txtMaker.Text + " Using (" + Properties.Settings.Default.UserName + ")";
                        transfer.Reason = txtReason.Text;
                        _context.ProductsOutStore.Add(transfer);
                        _context.SaveChanges();

                        productQty.Qty = 0;
                        _context.ProductsQuantities.Update(productQty);
                        _context.SaveChanges();
                        _context.Remove(productQty);
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
        private void btnTransfert_Click(object sender, EventArgs e)
        {
            try
            {
                if (txtQtyTransfert.Text == string.Empty || txtProductName.Text == string.Empty)
                    return;

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
                        _product.Quentity -= Convert.ToInt32(txtQtyTransfert.Text);
                        _context.Update(_product);
                        _context.SaveChanges();
                        transaction.Commit();
                        Code.Helper.ToasterHelper.ShowOutStockProduct();

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
