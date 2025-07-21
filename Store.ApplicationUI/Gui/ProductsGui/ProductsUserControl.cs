using System.Data;
using Microsoft.EntityFrameworkCore;
using Store.ApplicationUI.Code.GUIHelper;
using Store.ApplicationUI.Code.Helper;
using Store.ApplicationUI.Gui.LoadingGui;
using Store.ApplicationUI.Gui.ProductsGui.Category;
using Store.ApplicationUI.Gui.ProductsGui.StoreGui;
using Store.Infrastructure.Data;
using Store.Infrastructure.Repositories;

namespace Store.ApplicationUI.Gui.ProductsGui
{
    public partial class ProductsUserControl : UserControl, IKeyAwareControl
    {
        private static ProductsGui.ProductsUserControl? _productsUserControl;
        private static MainForm? _main;
        private AddProductForm addProductForm;
        public AddCategoryForm addCategoryForm;
        public AddStoreForm addStoreForm;
        private static ApplicationDbContext? _context;
        public static ProductsRepository? productsRepository;
        public static CategorysRepository? categoryRepository;
        public ProductsUserControl()
        {
            InitializeComponent();
        }

        public static ProductsUserControl Instance(MainForm main)
        {
            _main = main;
            // If the instance is null, create a new one and assign it to the static field
            _context = new ApplicationDbContext();
            if (_productsUserControl == null)
            {

                productsRepository = new ProductsRepository(_context);
                categoryRepository = new CategorysRepository(_context);
                _productsUserControl = new ProductsUserControl();

            }

            // Return the singleton instance
            _productsUserControl.LoadData();
            return _productsUserControl;
        }
        public static bool CheckInstance()
        {


            return (_productsUserControl == null);


        }

        private void btnAddProduct_Click(object sender, EventArgs e)
        {
            ToasterHelper.PlayNotificationSound();
            if (addProductForm == null || addProductForm.IsDisposed)
            {
                addProductForm = AddProductForm.Instance(_main);
                addProductForm.Show();
            }
            else
            {
                addProductForm.Focus();
            }


        }
        void CalcStats()
        {
            txtAllProducts.Text = _context.Products.AsNoTracking().Where(x => x.Quentity > 0).Count().ToString();
            txtProductSum.Text = _context.Products.AsNoTracking().Count().ToString("f2");
            txtAllQty.Text = _context.Products.AsNoTracking().Sum(x => x.Quentity).ToString("f2");
            txtAllCategories.Text = _context.Products.AsNoTracking().Where(x => x.Quentity > 0)
                .Select(x => x.CategoryId)
                .Distinct()
                .Count().ToString("f2");
            txttotalBuy.Text = _context.Products.AsNoTracking().Sum(x => x.BuyPrice * x.Quentity).ToString("f2");
            txttotalSell.Text = _context.Products.AsNoTracking().Sum(x => x.SalePriceTax * x.Quentity).ToString("f2");
            txtTotalProfitExpected.Text = _context.Products.AsNoTracking().Sum(x => (x.SalePriceTax - x.BuyPrice) * x.Quentity)
                .ToString("f2");
        }
        public async void SetProductsToDgv(int skip)
        {
            //DgvProducts.DataSource = await Task.Run(() => productsRepository.GetAll(p => p.Category));
            DgvProducts.DataSource = _context.Products.
                Include(x => x.Category).Skip(skip).Take(Properties.Settings.Default.NoOfDataInDgvs).AsNoTracking().ToList();
            // Set data source


            // Calculate total pages
            double value = _context.Products.AsNoTracking().Count() / Convert.ToDouble(Properties.Settings.Default.NoOfDataInDgvs);
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
            CalcStats();
            PaginationHide();
            lblEmptyData.Visible = dgvHelper.IsEmpty(DgvProducts);

        }

        public static void RefreshDgv()
        {
            //DgvProducts.DataSource = await Task.Run(() => productsRepository.GetAllProducts());
            _productsUserControl.LoadData();
        }
        // methodes 
        public async void LoadData()
        {


            //ShowLoading
            LoadingForm.Instance(_main).Show();
            if (await Task.Run(() => productsRepository.IsConnected()))
            {
                //Start Load Data

                // if its an admin or Normal user 

                SetProductsToDgv(0);
                SetColumns();
                //_data.Clear();
                // Create ContextMenuStrip
                ContextMenuStrip contextMenu = new ContextMenuStrip();

                // Add menu items
                ToolStripMenuItem editItem = new ToolStripMenuItem("التعديل");
                ToolStripMenuItem deleteItem = new ToolStripMenuItem("الحذف");


                // Add click events
                editItem.Click += EditItem_Click;
                deleteItem.Click += DeleteItem_Click;


                // Add items to the menu
                contextMenu.Items.AddRange(new ToolStripItem[] { editItem, deleteItem });

                // Assign context menu to DataGridView
                DgvProducts.ContextMenuStrip = contextMenu;
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
            lblEmptyData.Visible = dgvHelper.IsEmpty(DgvProducts);
        }
        // Sample event handlers for menu items
        private void EditItem_Click(object sender, EventArgs e)
        {
            //MessageBox.Show("Edit option clicked");
        }

        private void DeleteItem_Click(object sender, EventArgs e)
        {
            //MessageBox.Show("Delete option clicked");
        }


        private void SetColumns()
        {
            //DgvProducts.Columns[0].HeaderCell.Value = "المعرف";
            DgvProducts.Columns[0].HeaderCell.Value = "باركود";
            DgvProducts.Columns[1].HeaderCell.Value = "اسم المنتج";
            DgvProducts.Columns[2].HeaderCell.Value = "الكمية";
            DgvProducts.Columns[3].HeaderCell.Value = "سعر الشراء";
            DgvProducts.Columns[4].HeaderCell.Value = "سعر البيع";
            DgvProducts.Columns[5].HeaderCell.Value = "سعر البيع 2";
            DgvProducts.Columns[6].HeaderCell.Value = "سعر الجملة";
            DgvProducts.Columns[7].HeaderCell.Value = "قيمة الضريبة";
            DgvProducts.Columns[8].HeaderCell.Value = "سعر البيع باحتساب الضريبة";
            DgvProducts.Columns[9].HeaderCell.Value = "خاضع للضريبة؟";
            DgvProducts.Columns[10].HeaderCell.Value = "تاريخ انتهاء الصلاحية";
            DgvProducts.Columns[11].HeaderCell.Value = "كمية التنبيه";
            DgvProducts.Columns[12].HeaderCell.Value = "اقصى تخفيض";
            DgvProducts.Columns[13].HeaderCell.Value = "كمية الوحدات في الكرتونة";
            DgvProducts.Columns[14].HeaderCell.Value = "باركود الكرتونة";
            DgvProducts.Columns[15].HeaderCell.Value = "صورة المنتج";
            DgvProducts.Columns[16].HeaderCell.Value = "معرف الصنف";
            DgvProducts.Columns[17].HeaderCell.Value = "اسم الصنف";
            DgvProducts.Columns[18].HeaderCell.Value = "معرف المنتج";
            DgvProducts.Columns[19].HeaderCell.Value = "وزن المنتج";
            DgvProducts.Columns[20].HeaderCell.Value = "معرف المنتج";





            // Visible of Columns
            //DgvProducts.Columns[0].Visible = false;
            DgvProducts.Columns[7].Visible = false;
            DgvProducts.Columns[10].Visible = false;
            DgvProducts.Columns[9].Visible = false;
            DgvProducts.Columns[12].Visible = false;
            DgvProducts.Columns[13].Visible = false;
            DgvProducts.Columns[14].Visible = false;
            DgvProducts.Columns[16].Visible = false;
            DgvProducts.Columns[18].Visible = false;
            DgvProducts.Columns[20].Visible = false;
            DgvProducts.Columns[15].Visible = false;
            DgvProducts.Columns[13].Visible = false;
            //DgvProducts.Columns[13].Visible = false;
            //DgvProducts.Columns[14].Visible = false;
            //DgvProducts.Columns[13].Visible = false;
            //DgvProducts.Columns[15].Visible = false;
        }

        private void btnRefresh_Click(object sender, EventArgs e)
        {
            ToasterHelper.PlayNotificationSound();
            LoadData();

        }

        private void btnEditProduct_Click(object sender, EventArgs e)
        {
            ToasterHelper.PlayNotificationSound();
            if (DgvProducts.Rows.Count > 0)
            {
                if (addProductForm == null || addProductForm.IsDisposed)
                {
                    addProductForm = AddProductForm.Instance(_main);


                    addProductForm.SetDataToEdit(
                        DgvProducts.CurrentRow.Cells[1].Value.ToString(),
                        DgvProducts.CurrentRow.Cells[0]?.Value.ToString(),
                        DgvProducts.CurrentRow.Cells[16].Value.ToString(),
                        DgvProducts.CurrentRow.Cells[11].Value.ToString(),
                        Convert.ToBoolean(DgvProducts.CurrentRow.Cells[9].Value),
                        DgvProducts.CurrentRow.Cells[7].Value.ToString(),
                        DgvProducts.CurrentRow.Cells[3].Value.ToString(),
                        DgvProducts.CurrentRow.Cells[2].Value.ToString(),
                        DgvProducts.CurrentRow.Cells[6].Value.ToString(),
                        DgvProducts.CurrentRow.Cells[4].Value.ToString(),
                       Convert.ToDateTime(DgvProducts.CurrentRow.Cells[10].Value),
                        DgvProducts.CurrentRow.Cells[12].Value?.ToString(),
                        DgvProducts.CurrentRow.Cells[8].Value.ToString(),
                        DgvProducts.CurrentRow.Cells[20].Value.ToString(),
                        (byte[])DgvProducts.CurrentRow.Cells[15].Value,
                          DgvProducts.CurrentRow.Cells[16].Value.ToString()
                          , DgvProducts.CurrentRow.Cells[5].Value.ToString()
                          , DgvProducts.CurrentRow.Cells[13].Value.ToString()
                          , DgvProducts.CurrentRow.Cells[14].Value.ToString()
                          , DgvProducts.CurrentRow.Cells[19].Value.ToString()
                        );

                    addProductForm.Show();
                }
                else
                {
                    addProductForm.Focus();
                }
            }
        }

        private void btnDeleteProduct_Click(object sender, EventArgs e)
        {
            ToasterHelper.PlayNotificationSound();
            if (MsgHelper.ShowDeleteDialog())
            {
                productsRepository.DeleteAsync(DgvProducts.CurrentRow.Cells[20].Value.ToString());
                Code.Helper.ToasterHelper.ShowDeletedToast();

            }
            RefreshDgv();
        }

        private void btnSearch_Click(object sender, EventArgs e)
        {
            try
            {


                txtSearch.Text = txtSearch.Text.Replace("\r\n", "");


                DgvProducts.DataSource = productsRepository?.SearchAll(txtSearch.Text, Properties.Settings.Default.NoOfDataInDgvs,
                    cmbpagination.SelectedIndex * Properties.Settings.Default.NoOfDataInDgvs);
                lblEmptyData.Visible = dgvHelper.IsEmpty(DgvProducts);

                txtSearch.Text = string.Empty;

            }
            catch (Exception)
            {

                throw;
            }
        }

        private void btnAddCategory_Click(object sender, EventArgs e)
        {
            ToasterHelper.PlayNotificationSound();
            if (addCategoryForm == null || addCategoryForm.IsDisposed)
            {
                addCategoryForm = new AddCategoryForm(_main);
                addCategoryForm.Show();
            }
            else
            {
                addCategoryForm.Focus();
            }
        }

        private void btnAddStore_Click(object sender, EventArgs e)
        {
            ToasterHelper.PlayNotificationSound();
            if (addStoreForm == null || addStoreForm.IsDisposed)
            {
                addStoreForm = new(_main);
                addStoreForm.Show();
            }
            else
            {
                addStoreForm.Focus();
            }
        }

        private void btnAddSimilareProduct_Click(object sender, EventArgs e)
        {
            ToasterHelper.PlayNotificationSound();
            if (DgvProducts.Rows.Count > 0)
            {
                if (addProductForm == null || addProductForm.IsDisposed)
                {
                    addProductForm = AddProductForm.Instance(_main);


                    addProductForm.SetSimilaireDataToAdd(
                          DgvProducts.CurrentRow.Cells[1].Value.ToString(),
                        DgvProducts.CurrentRow.Cells[0].Value.ToString(),
                        DgvProducts.CurrentRow.Cells[16].Value.ToString(),
                        DgvProducts.CurrentRow.Cells[11].Value.ToString(),
                        Convert.ToBoolean(DgvProducts.CurrentRow.Cells[9].Value),
                        DgvProducts.CurrentRow.Cells[7].Value.ToString(),
                        DgvProducts.CurrentRow.Cells[3].Value.ToString(),
                        DgvProducts.CurrentRow.Cells[2].Value.ToString(),
                        DgvProducts.CurrentRow.Cells[6].Value.ToString(),
                        DgvProducts.CurrentRow.Cells[4].Value.ToString(),
                       Convert.ToDateTime(DgvProducts.CurrentRow.Cells[10].Value),
                        DgvProducts.CurrentRow.Cells[12].Value?.ToString(),
                        DgvProducts.CurrentRow.Cells[8].Value.ToString(),
                        DgvProducts.CurrentRow.Cells[20].Value.ToString(),
                        (byte[])DgvProducts.CurrentRow.Cells[15].Value,
                          DgvProducts.CurrentRow.Cells[16].Value.ToString()
                          , DgvProducts.CurrentRow.Cells[5].Value.ToString()
                          , DgvProducts.CurrentRow.Cells[13].Value.ToString()
                          , DgvProducts.CurrentRow.Cells[14].Value.ToString()
                          , DgvProducts.CurrentRow.Cells[19].Value.ToString()
                        );

                    addProductForm.Show();
                }
                else
                {
                    addProductForm.Focus();
                }
            }
        }
        void PaginationHide()
        {
            btnNext.Enabled = cmbpagination.SelectedIndex < cmbpagination.Items.Count - 1 && !dgvHelper.IsEmpty(DgvProducts);
            btnPrev.Enabled = cmbpagination.SelectedIndex > 0 && !dgvHelper.IsEmpty(DgvProducts);
            cmbpagination.Enabled = !dgvHelper.IsEmpty(DgvProducts);
        }
        private void btnNext_Click(object sender, EventArgs e)
        {
            ToasterHelper.PlayNotificationSound();
            if (cmbpagination.SelectedIndex < cmbpagination.Items.Count - 1)
            {
                cmbpagination.SelectedIndex++;
                int skip = cmbpagination.SelectedIndex * Properties.Settings.Default.NoOfDataInDgvs;
                SetProductsToDgv(skip);

            }
        }

        private void btnPrev_Click(object sender, EventArgs e)
        {
            ToasterHelper.PlayNotificationSound();
            if (cmbpagination.SelectedIndex > 0)
            {
                cmbpagination.SelectedIndex--;
                int skip = cmbpagination.SelectedIndex * Properties.Settings.Default.NoOfDataInDgvs;

                SetProductsToDgv(skip);
            }
        }

        private void cmbpagination_SelectionChangeCommitted(object sender, EventArgs e)
        {
            ToasterHelper.PlayNotificationSound();
            if (cmbpagination.SelectedIndex != -1)
            {
                int skip = cmbpagination.SelectedIndex * Properties.Settings.Default.NoOfDataInDgvs;
                SetProductsToDgv(skip);
            }
        }

        private void button1_Click(object sender, EventArgs e)
        {

        }
        private List<Core.Entities.Products.Product> data;
        private async void btnExportProduct_Click(object sender, EventArgs e)
        {

            data = await _context.Products.Include(x => x.Category).ToListAsync();


            LoadingForm.Instance(_main).Hide();

            ExportExcel(data);


        }
        private void ExportExcel(List<Core.Entities.Products.Product> data)
        {

            DataTable dataTable = new DataTable();


            using (var reader = FastMember.ObjectReader.Create(data))
            {
                dataTable.Load(reader);
            }


            dataTable = arrangedDataTable(dataTable);


            ExcelHelper.Export(dataTable, "Products");
        }
        private DataTable arrangedDataTable(DataTable dataTable)
        {
            dataTable.Columns["Id"].SetOrdinal(0);
            dataTable.Columns["Id"].ColumnName = "معرف";

            dataTable.Columns["CodeBar"].SetOrdinal(1);
            dataTable.Columns["CodeBar"].ColumnName = "الباركود";


            dataTable.Columns["ProductName"].SetOrdinal(2);
            dataTable.Columns["ProductName"].ColumnName = "اسم المستخدم";


            dataTable.Columns["Quentity"].SetOrdinal(3);
            dataTable.Columns["Quentity"].ColumnName = "الكمية";

            dataTable.Columns["BuyPrice"].SetOrdinal(4);
            dataTable.Columns["BuyPrice"].ColumnName = "سعر الشراء";

            dataTable.Columns["SalePrice"].SetOrdinal(5);
            dataTable.Columns["SalePrice"].ColumnName = "سعر البيع";

            dataTable.Columns["WholesalePrice"].SetOrdinal(6);
            dataTable.Columns["WholesalePrice"].ColumnName = "سعر الجملة";

            dataTable.Columns["DateExperation"].SetOrdinal(7);
            dataTable.Columns["DateExperation"].ColumnName = "تاريخ انتهاء الصلاحية";


            dataTable.Columns["MinQty"].SetOrdinal(8);
            dataTable.Columns["MinQty"].ColumnName = "كمية التنبيه";


            dataTable.Columns["Category"].SetOrdinal(9);
            dataTable.Columns["Category"].ColumnName = "الصنف";


            dataTable.Columns["IsTaxed"].SetOrdinal(10);
            dataTable.Columns["IsTaxed"].ColumnName = "عليه ضريبة";


            dataTable.Columns["NbrProductInColis"].SetOrdinal(11);
            dataTable.Columns["NbrProductInColis"].ColumnName = "عدد المنتجات في الكرتونة";

            dataTable.Columns["ColisageBareCode"].SetOrdinal(12);
            dataTable.Columns["ColisageBareCode"].ColumnName = "باركود الكرتونة";



            // Removed columns
            dataTable.Columns.Remove("ProductImage");
            dataTable.Columns.Remove("CategoryId");
            dataTable.Columns.Remove("ProductFamilies");
            dataTable.Columns.Remove("MaxDiscount");
            dataTable.Columns.Remove("TaxValue");
            dataTable.Columns.Remove("SalePriceSeconde");

            return dataTable;
        }

        private void txtSearch_KeyDown(object sender, KeyEventArgs e)
        {
            if (e.KeyCode == Keys.Enter)
            {
                btnSearch_Click(sender, e);
            }
        }

        public void HandleKeyDown(Keys key)
        {

        }
    }
}
