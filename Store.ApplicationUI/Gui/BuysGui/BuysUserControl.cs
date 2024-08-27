using Microsoft.EntityFrameworkCore;
using Store.ApplicationUI.Code.Helper;
using Store.ApplicationUI.Gui.LoadingGui;
using Store.Core.Entities.Products;
using Store.Infrastructure.Repositories;

namespace Store.ApplicationUI.Gui.BuysGui
{
    public partial class BuysUserControl : UserControl
    {

        private static BuysUserControl? _buysUserControl;
        private static MainForm? _main;
        public static BuysRepository? buysRepository;
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
                buysRepository = new BuysRepository(MainForm.Context);
                _buysUserControl = new BuysUserControl();
            }
            // Return the singleton instance
            _buysUserControl.LoadData();
            return _buysUserControl;
        }

        public static void RefreshDgv()
        {
            //DgvProducts.DataSource = await Task.Run(() => productsRepository.GetAllProducts());
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
                cmbSuppliers.DataSource = MainForm.Context.Suppliers.ToList();
                cmbSuppliers.DisplayMember = "SupplierName";
                cmbSuppliers.ValueMember = "Id";
                cmbSuppliers.Text = "اختر مورد";

                cmbSuppliers.DataSource = MainForm.Context.Stores.ToList();
                cmbSuppliers.DisplayMember = "StoreName";
                cmbSuppliers.ValueMember = "Id";
                cmbSuppliers.Text = "اختر مخزن";

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
            //DgvProducts.Columns[0].HeaderCell.Value = "الماسم المنتجعرف";
            DgvِProducts.Columns[0].HeaderCell.Value = "اسم المنتج";
            DgvِProducts.Columns[1].HeaderCell.Value = " سعر الشراء";
            DgvِProducts.Columns[2].HeaderCell.Value = "الكمية";
            DgvِProducts.Columns[3].HeaderCell.Value = "اجمالي الشراء";
            DgvِProducts.Columns[4].HeaderCell.Value = "سعر البيع";
            DgvِProducts.Columns[5].HeaderCell.Value = "سعر الجملة";
            DgvِProducts.Columns[6].HeaderCell.Value = "سعر البيع باحتساب الضريبة";
            DgvِProducts.Columns[7].HeaderCell.Value = "تاريخ انتهاء الصلاحية";








            // Visible of Columns
            //DgvProducts.Columns[0].Visible = false;
            ////DgvِProducts.Columns[6].Visible = false;
            ////DgvِProducts.Columns[9].Visible = false;
            ////DgvِProducts.Columns[8].Visible = false;
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
            DgvِProducts.DataSource = MainForm.Context.Products.
                Include(x => x.Category).ToList();
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
            }
            catch (Exception ex) { MessageBox.Show(ex.Message); }
        }

        public async void SetProductsToTable()
        {
            //DgvProducts.DataSource = await Task.Run(() => productsRepository.GetAll(p => p.Category));
            Product product = buysRepository.GetProductBarCode(txtSearchBarCode.Text);
            if (product is not null)
            {
                InitializeTextBoxesAndLables(product);
                txtSearchBarCode.Clear();
                txtQty.Focus();
                txtQty.SelectAll();
                CalculateAmount();
            }
            else
            {
                MsgHelper.ShowEmptyResult();
            }
        }
        private void tableLayoutPanel_Paint(object sender, PaintEventArgs e)
        {

        }

        private void btnRefresh_Click(object sender, EventArgs e)
        {
            DgvِProducts.DataSource = new List<Product>();
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

        private void txtQty_KeyDown(object sender, KeyEventArgs e)
        {
            if (e.KeyCode == Keys.Enter)
            {

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

            }
            catch (Exception ex) { MessageBox.Show(ex.Message); }
        }

        private void txtBuyPrice_KeyDown(object sender, KeyEventArgs e)
        {
            if (e.KeyCode == Keys.Enter)
            {

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
                if (DgvِProducts.Rows.Count > 0)
                {
                    lblTotalPriceinFacture.Text =
                                         (from DataGridViewRow row in DgvِProducts.Rows
                                          where row.Cells[7].FormattedValue.ToString() != string.Empty
                                          select Convert.ToDouble(row.Cells[7].FormattedValue)).Sum()
                                          .ToString("f2") + "المبلغ الاجمالي في الفاتورة:";
                    lblTotalQuentity.Text =
                              (from DataGridViewRow row in DgvِProducts.Rows
                               where row.Cells[2].FormattedValue.ToString() != string.Empty
                               select Convert.ToDouble(row.Cells[2].FormattedValue)).Sum()
                               .ToString("f2") + "المبلغ الاجمالي في الفاتورة:";
                    lblTotalProductsInTable.Text = $"اجمالي الكميات في الجدول: {DgvِProducts.Rows.Count}";
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
    }
}
