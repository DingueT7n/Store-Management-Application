using Microsoft.EntityFrameworkCore;
using Microsoft.IdentityModel.Tokens;
using Store.ApplicationUI.Code.Helper;
using Store.ApplicationUI.Gui.LoadingGui;
using Store.Infrastructure.Data;

namespace Store.ApplicationUI.Gui.ProductsGui.StoreGui
{
    public partial class AddStoreForm : Form
    {
        private readonly MainForm _main;
        private readonly ApplicationDbContext _context;


        public AddStoreForm(MainForm main, ApplicationDbContext applicationDbContext)
        {
            InitializeComponent();
            _main = main;
            _context = applicationDbContext;
            this.Owner = _main;

        }

        public async Task SetCategoryToDgv()
        {
            //DgvProducts.DataSource = await Task.Run(() => productsRepository.GetAll(p => p.Category));
            DgvStore.DataSource = await _context.Stores
                .ToListAsync();
            lblCategoryId.Text = (_context.Stores.Count() + 1).ToString();
            lblEmptyData.Visible = dgvHelper.IsEmpty(DgvStore);
        }
        public async void LoadData()
        {
            //ShowLoading
            LoadingForm.Instance(_main).Show();
            if (await _context.Database.CanConnectAsync())
            {
                SetColumns();
                await SetCategoryToDgv();

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
            DgvStore.DataSource = new List<Store.Core.Entities.Stores.Store>();
            //DgvProducts.Columns[0].HeaderCell.Value = "المعرف";
            DgvStore.Columns[1].HeaderCell.Value = "معرف المخزن";
            DgvStore.Columns[0].HeaderCell.Value = "اسم المخزن";



        }
        private async void btnAddStore_Click(object sender, EventArgs e)
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
                await _context.Stores.AddAsync(store);
                await _context.SaveChangesAsync();
                Code.Helper.ToasterHelper.ShowAddToast();

            }
            RefreshDgv();
        }

        private async void btnEditStore_Click(object sender, EventArgs e)
        {
            ToasterHelper.PlayNotificationSound();
            if (MsgHelper.ShowEditDialog())
            {
                Store.Core.Entities.Stores.Store store = await _context.Stores.FirstOrDefaultAsync(x => x.Id ==
                Convert.ToInt32(DgvStore.CurrentRow.Cells[1].Value.ToString())
                );
                if (store != null)
                {
                    store.StoreName = txtNameِCategory.Text;
                    _context.Update(store);
                    await _context.SaveChangesAsync();
                    Code.Helper.ToasterHelper.ShowEditToast();

                    vider();
                }
            }
        }
        private async void RefreshDgv()
        {

            await SetCategoryToDgv();
            txtNameِCategory.Text = string.Empty;
        }
        private async void btnDeleteStore_Click(object sender, EventArgs e)
        {
            ToasterHelper.PlayNotificationSound();
            if (MsgHelper.ShowDeleteDialog())
            {
                var store = await _context.Stores.FirstOrDefaultAsync(x => x.Id == Convert.ToInt32(DgvStore.CurrentRow.Cells[1].Value.ToString()));
                if (store != null)
                {
                    _context.Remove(store);
                    await _context.SaveChangesAsync();
                    Code.Helper.ToasterHelper.ShowDeletedToast();
                }
                if (_context.Stores.Count() < 1)
                {
                    var val = new Store.Core.Entities.Stores.Store
                    {
                        StoreName = "مخزن رئيسي",
                    };
                    await _context.AddAsync(val);
                    await _context.SaveChangesAsync();
                    Properties.Settings.Default.FastSaleStore = Properties.Settings.Default.StoreIdDefault = val.Id;
                    Properties.Settings.Default.DefaultStoreSaleId = val.Id.ToString();

                    Properties.Settings.Default.Save();
                }
            }
            RefreshDgv();
        }

        private async void btnSearch_Click(object sender, EventArgs e)
        {
            ToasterHelper.PlayNotificationSound();
            txtSearch.Text = txtSearch.Text.Replace("\r\n", "");

            DgvStore.DataSource = await _context.Stores.Where(x => x.Id.ToString() == txtSearch.Text ||
            x.StoreName.Contains(txtSearch.Text)).ToListAsync();
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

        private void AddStoreForm_Load(object sender, EventArgs e)
        {
            LoadData();

        }
    }
}
