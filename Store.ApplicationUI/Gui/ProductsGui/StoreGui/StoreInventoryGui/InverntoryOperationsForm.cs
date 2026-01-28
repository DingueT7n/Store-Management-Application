using Microsoft.EntityFrameworkCore;
using Microsoft.IdentityModel.Tokens;
using Store.ApplicationUI.Code.Helper;
using Store.ApplicationUI.Code.System;
using Store.ApplicationUI.Gui.LoadingGui;
using Store.Core.Interfaces;
using Store.Infrastructure.Data;

namespace Store.ApplicationUI.Gui.ProductsGui.StoreGui.StoreInventoryGui
{
    public partial class InverntoryOperationsForm : Form
    {
        private readonly MainForm _main;
        private readonly ApplicationDbContext _context;
        private readonly ControlManager _controlManager;
        private readonly IInventorySessionRepository _inventorySessionRepository;

        public InverntoryOperationsForm(MainForm main, ApplicationDbContext context, ControlManager controlManager, IInventorySessionRepository inventorySessionRepository)
        {
            InitializeComponent();
            _main = main;
            _context = context;
            _controlManager = controlManager;
            _inventorySessionRepository = inventorySessionRepository;
        }
        public async Task SetCategoryToDgv()
        {
            //DgvProducts.DataSource = await Task.Run(() => productsRepository.GetAll(p => p.Category));
            DgvStore.DataSource = await _inventorySessionRepository.GetAllInventorySession();
            lblCategoryId.Text = (_context.InventorySessions.Count() + 1).ToString();
            lblEmptyData.Visible = dgvHelper.IsEmpty(DgvStore);
        }
        public async Task LoadData()
        {
            //ShowLoading
            dgvHelper.ResetForm(this);
            vider();
            LoadingForm.Instance(_main).Show();
            if (await _inventorySessionRepository.IsConnectedAsync())
            {
                SetColumns();
                await SetCategoryToDgv();
                cmbStoresFrom.DataSource = await _context.Stores.ToListAsync();
                cmbStoresFrom.DisplayMember = "StoreName";
                cmbStoresFrom.ValueMember = "Id";

                rbStoresFromAll.Checked = true;
                cmbStoresFrom.Enabled = false;
                cmbStoresFrom.SelectedIndex = -1;
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
            txtPerformedBy.Text = "";

        }

        private void SetColumns()
        {
            DgvStore.DataSource = new List<Store.Core.Entities.Stores.InventorySessionDTO>();
            //DgvProducts.Columns[0].HeaderCell.Value = "المعرف";
            DgvStore.Columns[0].HeaderCell.Value = "معرف الجرد";
            //DgvStore.Columns[1].HeaderCell.Value = "معرف المخزن";
            DgvStore.Columns[1].HeaderCell.Value = "اسم المخزن";
            DgvStore.Columns[2].HeaderCell.Value = "المسؤول";
            DgvStore.Columns[3].HeaderCell.Value = "تاريخ البداية";
            DgvStore.Columns[4].HeaderCell.Value = "تاريخ الانتهاء";
            DgvStore.Columns[5].HeaderCell.Value = "جميع المخازن ؟";
            DgvStore.Columns[6].HeaderCell.Value = "حالة الجرد";
            DgvStore.Columns[7].HeaderCell.Value = "ملاحظة";



        }
        private async void RefreshDgv()
        {

            await SetCategoryToDgv();
            txtPerformedBy.Text = string.Empty;
        }

        private async void btnAddStore_Click(object sender, EventArgs e)
        {
            ToasterHelper.PlayNotificationSound();
            if (txtPerformedBy.Text.IsNullOrEmpty())
            {
                MsgHelper.ShowRequiredFields();

            }
            else if (rbStoresFrom.Checked && cmbStoresFrom.SelectedValue == null)
            {
                MsgHelper.ShowRequiredFields();
                return;
            }


            Store.Core.Entities.Stores.InventorySession obj = new();
            obj.DateStarted = dtpFrom.Value;
            obj.Notes = txtNotes.Text;
            obj.PerformedBy = txtPerformedBy.Text;
            obj.AllStores = rbStoresFrom.Checked;
            obj.StoreId = rbStoresFrom.Checked ? (int?)cmbStoresFrom.SelectedValue : null;
            await _inventorySessionRepository.AddAsync(obj);
            Code.Helper.ToasterHelper.ShowAddToast();


            await LoadData();
        }

        private async void btnEditStore_Click(object sender, EventArgs e)
        {
            ToasterHelper.PlayNotificationSound();
            if (MsgHelper.ShowEditDialog())
            {
                int? id = Convert.ToInt32(DgvStore.CurrentRow?.Cells[0].Value?.ToString());
                Store.Core.Entities.Stores.InventorySession? obj = await _context.InventorySessions.FirstOrDefaultAsync(x => x.Id == id);

                if (obj != null)
                {
                    obj.DateStarted = dtpFrom.Value;
                    obj.Notes = txtNotes.Text;
                    obj.PerformedBy = txtPerformedBy.Text;
                    obj.AllStores = rbStoresFrom.Checked;
                    obj.StoreId = rbStoresFrom.Checked ? (int?)cmbStoresFrom.SelectedValue : null;

                    await _inventorySessionRepository.UpdateAsync(id.ToString(), obj);

                    Code.Helper.ToasterHelper.ShowEditToast();

                    vider();
                    await LoadData();

                }

            }
        }

        private async void btnDeleteStore_Click(object sender, EventArgs e)
        {
            ToasterHelper.PlayNotificationSound();
            if (MsgHelper.ShowDeleteDialog())
            {
                int? id = Convert.ToInt32(DgvStore.CurrentRow?.Cells[0].Value?.ToString());

                var obj = await _context.InventorySessions.FirstOrDefaultAsync(x => x.Id == id);
                if (obj != null)
                {
                    await _inventorySessionRepository.DeleteAsync(id.ToString());
                    Code.Helper.ToasterHelper.ShowDeletedToast();
                }
            }
            await LoadData();
        }

        private void rbStoresFromAll_CheckedChanged(object sender, EventArgs e)
        {
            cmbStoresFrom.Enabled = false;

        }

        private void rbStoresFrom_CheckedChanged(object sender, EventArgs e)
        {
            cmbStoresFrom.Enabled = true;

        }

        private void btnRefresh_Click(object sender, EventArgs e)
        {
            ToasterHelper.PlayNotificationSound();
            btnAddStore.Enabled = true;
            vider();
            btnEditStore.Enabled = false;
        }

        private async void btnSearch_Click(object sender, EventArgs e)
        {
            ToasterHelper.PlayNotificationSound();
            if (string.IsNullOrEmpty(txtPerformedBy.Text))
            {
                //MsgHelper.ShowWarning("الرجاء ادخال اسم الجرد للبحث");
                return;
            }
            var searchResult = await _inventorySessionRepository.GetAllInventorySession(txtPerformedBy.Text);
            if (searchResult != null && searchResult.Any())
            {
                DgvStore.DataSource = searchResult;
                lblEmptyData.Visible = dgvHelper.IsEmpty(DgvStore);
            }
            else
            {
                //MsgHelper.ShowWarning("لا توجد نتائج مطابقة للبحث");
                lblEmptyData.Visible = true;
            }
        }

        private void DgvStore_CellMouseClick(object sender, DataGridViewCellMouseEventArgs e)
        {
            if (DgvStore.SelectedRows.Count > 0)
                try
                {
                    txtPerformedBy.Text = DgvStore.CurrentRow?.Cells[2].Value?.ToString();
                    lblCategoryId.Text = DgvStore.CurrentRow?.Cells[0].Value?.ToString();
                    dtpFrom.Value = Convert.ToDateTime(DgvStore.CurrentRow?.Cells[3].Value?.ToString());

                    lblCategoryId.Text = DgvStore.CurrentRow?.Cells[0].Value?.ToString();
                    txtNotes.Text = DgvStore.CurrentRow?.Cells[7].Value?.ToString();

                    bool isAllStores = !Convert.ToBoolean(DgvStore.CurrentRow?.Cells[5].Value);
                    rbStoresFromAll.Checked = isAllStores;
                    rbStoresFrom.Checked = !isAllStores;
                    cmbStoresFrom.Enabled = !isAllStores;
                    if (!isAllStores && DgvStore.CurrentRow?.Cells[1].Value != DBNull.Value)
                    {
                        cmbStoresFrom.SelectedValue = Convert.ToInt32(DgvStore.CurrentRow?.Cells[1].Value);
                    }

                    btnAddStore.Enabled = false;
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
