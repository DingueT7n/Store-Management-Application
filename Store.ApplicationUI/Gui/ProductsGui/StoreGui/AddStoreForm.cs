using Microsoft.IdentityModel.Tokens;
using Store.ApplicationUI.Code.Helper;
using Store.ApplicationUI.Gui.LoadingGui;

namespace Store.ApplicationUI.Gui.ProductsGui.StoreGui
{
    public partial class AddStoreForm : Form
    {
        private static MainForm? _main;
        private static AddStoreForm _addStoreForm;
        public AddStoreForm(MainForm main)
        {
            InitializeComponent();
            _main = main;
            this.Owner = _main;
            LoadData();
        }
        public static AddStoreForm Instance(MainForm main)
        {
            _main = main;
            // If the instance is null, create a new one and assign it to the static field
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
            DgvStore.DataSource = MainForm.Context.Stores
                .ToList();
            lblCategoryId.Text = (MainForm.Context.Stores.Count() + 1).ToString();
            lblEmptyData.Visible = dgvHelper.IsEmpty(DgvStore);
        }
        public async void LoadData()
        {
            //ShowLoading
            LoadingForm.Instance(_main).Show();
            if (await Task.Run(() => MainForm.Context.Database.CanConnect()))
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
            if (txtNameِCategory.Text.IsNullOrEmpty())
            {
                MsgHelper.ShowRequiredFields();

            }
            else
            {
                Store.Core.Entities.Stores.Store store = new();
                store.StoreName = txtNameِCategory.Text;
                MainForm.Context.Stores.Add(store);
                MainForm.Context.SaveChanges();
            }
            RefreshDgv();
        }

        private void btnEditStore_Click(object sender, EventArgs e)
        {
            if (MsgHelper.ShowEditDialog())
            {
                Store.Core.Entities.Stores.Store store = MainForm.Context.Stores.FirstOrDefault(x => x.Id ==
                Convert.ToInt32(DgvStore.CurrentRow.Cells[1].Value.ToString())
                );

                store.StoreName = txtNameِCategory.Text;
                MainForm.Context.Update(store);
                MainForm.Context.SaveChanges();
                vider();
            }
        }
        private void RefreshDgv()
        {

            SetCategoryToDgv();
            txtNameِCategory.Text = string.Empty;
        }
        private void btnDeleteStore_Click(object sender, EventArgs e)
        {
            if (MsgHelper.ShowDeleteDialog())
            {
                MainForm.Context.Remove(Convert.ToInt32(DgvStore.CurrentRow.Cells[1].Value.ToString()));
                MainForm.Context.SaveChanges();
            }
            RefreshDgv();
        }

        private void btnSearch_Click(object sender, EventArgs e)
        {
            DgvStore.DataSource = MainForm.Context.Stores.Where(x => x.Id.ToString() == txtSearch.Text ||
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
