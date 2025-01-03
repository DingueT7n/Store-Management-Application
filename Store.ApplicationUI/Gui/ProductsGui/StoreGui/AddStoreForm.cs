using Microsoft.IdentityModel.Tokens;
using Store.ApplicationUI.Code.Helper;
using Store.ApplicationUI.Gui.LoadingGui;
using Store.Infrastructure.Data;

namespace Store.ApplicationUI.Gui.ProductsGui.StoreGui
{
    public partial class AddStoreForm : Form
    {
        private static MainForm? _main;
        private static ApplicationDbContext _context;
        private static AddStoreForm _addStoreForm;
        public AddStoreForm(MainForm main)
        {
            InitializeComponent();
            _main = main;
            this.Owner = _main;
            _context = new ApplicationDbContext();
            LoadData();
        }
        public static AddStoreForm Instance(MainForm main)
        {
            _main = main;
            // If the instance is null, create a new one and assign it to the static field
            _context = new ApplicationDbContext();
            if (_addStoreForm == null)
            {

                _addStoreForm = new AddStoreForm(_main);
            }

            // Return the singleton instance

            return _addStoreForm;
        }
        public void SetCategoryToDgv()
        {
            //DgvProducts.DataSource = await Task.Run(() => productsRepository.GetAll(p => p.Category));
            DgvStore.DataSource = _context.Stores
                .ToList();
            lblCategoryId.Text = (_context.Stores.Count() + 1).ToString();
            lblEmptyData.Visible = dgvHelper.IsEmpty(DgvStore);
        }
        public async void LoadData()
        {
            //ShowLoading
            LoadingForm.Instance(_main).Show();
            if (await Task.Run(() => _context.Database.CanConnect()))
            {
                SetCategoryToDgv();
                SetColumns();

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
        void vider()
        {
            txtNameِCategory.Text = "";
            RefreshDgv();
        }

        private void SetColumns()
        {
            //DgvProducts.Columns[0].HeaderCell.Value = "المعرف";
            DgvStore.Columns[1].HeaderCell.Value = "معرف المخزن";
            DgvStore.Columns[0].HeaderCell.Value = "اسم المخزن";



        }
        private void btnAddStore_Click(object sender, EventArgs e)
        {
            ToasterHelper.PlayNotificationSound();
            if (txtNameِCategory.Text.IsNullOrEmpty())
            {
                MsgHelper.ShowRequiredFields();

            }
            else
            {
                Store.Core.Entities.Stores.Store store = new();
                store.StoreName = txtNameِCategory.Text;
                _context.Stores.Add(store);
                _context.SaveChanges();
                Code.Helper.ToasterHelper.ShowAddToast();

            }
            RefreshDgv();
        }

        private void btnEditStore_Click(object sender, EventArgs e)
        {
            ToasterHelper.PlayNotificationSound();
            if (MsgHelper.ShowEditDialog())
            {
                Store.Core.Entities.Stores.Store store = _context.Stores.FirstOrDefault(x => x.Id ==
                Convert.ToInt32(DgvStore.CurrentRow.Cells[1].Value.ToString())
                );
                if (store != null)
                {
                    store.StoreName = txtNameِCategory.Text;
                    _context.Update(store);
                    _context.SaveChanges();
                    Code.Helper.ToasterHelper.ShowEditToast();

                    vider();
                }
            }
        }
        private void RefreshDgv()
        {

            SetCategoryToDgv();
            txtNameِCategory.Text = string.Empty;
        }
        private void btnDeleteStore_Click(object sender, EventArgs e)
        {
            ToasterHelper.PlayNotificationSound();
            if (MsgHelper.ShowDeleteDialog())
            {
                var store = _context.Stores.FirstOrDefault(x => x.Id == Convert.ToInt32(DgvStore.CurrentRow.Cells[1].Value.ToString()));
                if (store != null)
                {
                    _context.Remove(store);
                    _context.SaveChanges();
                    Code.Helper.ToasterHelper.ShowDeletedToast();
                }
                if (_context.Stores.Count() < 1)
                {
                    var val = new Store.Core.Entities.Stores.Store
                    {
                        StoreName = "مخزن رئيسي",
                    };
                    _context.Add(val);
                    _context.SaveChanges();
                    Properties.Settings.Default.FastSaleStore = Properties.Settings.Default.StoreIdDefault = val.Id;
                    Properties.Settings.Default.DefaultStoreSaleId = val.Id.ToString();
                    Properties.Settings.Default.Save();
                }
            }
            RefreshDgv();
        }

        private void btnSearch_Click(object sender, EventArgs e)
        {
            ToasterHelper.PlayNotificationSound();
            DgvStore.DataSource = _context.Stores.Where(x => x.Id.ToString() == txtSearch.Text ||
            x.StoreName.Contains(txtSearch.Text)).ToList();
            lblEmptyData.Visible = dgvHelper.IsEmpty(DgvStore);
            txtSearch.Text = string.Empty;
        }

        private void btnClose_Click(object sender, EventArgs e)
        {
            this.Close();
        }

        private void btnRefresh_Click(object sender, EventArgs e)
        {
            ToasterHelper.PlayNotificationSound();
            btnAddStore.Enabled = true;
            vider();
            btnEditStore.Enabled = false;
        }

        private void DgvStore_CellMouseClick(object sender, DataGridViewCellMouseEventArgs e)
        {
            if (DgvStore.SelectedRows.Count > 0)
                try
                {
                    btnAddStore.Enabled = false;
                    txtNameِCategory.Text = DgvStore.CurrentRow.Cells[0].Value.ToString();
                    lblCategoryId.Text = DgvStore.CurrentRow.Cells[1].Value.ToString();
                    btnEditStore.Enabled = true;
                    //btnRefresh.Enabled = true;
                }
                catch (Exception ex) { MessageBox.Show(ex.Message); }
            else
            {
                MsgHelper.ShowEmptyDataGridView();
            }
        }
    }
}
