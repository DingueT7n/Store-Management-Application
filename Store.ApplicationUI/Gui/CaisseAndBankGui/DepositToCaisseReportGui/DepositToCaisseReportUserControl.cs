using Microsoft.EntityFrameworkCore;
using Store.ApplicationUI.Code.Helper;
using Store.ApplicationUI.Gui.LoadingGui;
using Store.Core.Entities.Caisses;
using Store.Core.Interfaces;
using Store.Infrastructure.Data;

namespace Store.ApplicationUI.Gui.CaisseAndBankGui.DepositToCaisseReportGui
{
    public partial class DepositToCaisseReportUserControl : UserControl
    {

        public readonly ICaisseDepositRepository repository;
        private readonly MainForm _main;
        private readonly ApplicationDbContext _context;

        public DepositToCaisseReportUserControl(MainForm main, ApplicationDbContext context, ICaisseDepositRepository repository)
        {
            InitializeComponent();
            _main = main;
            _context = context;
            this.repository = repository;
        }
        public void SetProductsToDgvAsync(string t1, string barcode, int skip)
        {
            try
            {
                var data = repository.GetAllDepositToCaisse(t1, barcode, dtpFrom.Value, dtpTo.Value, Properties.Settings.Default.NoOfDataInDgvs, skip);

                // Set data source
                DgvSales.DataSource = data.Deposits;

                // Calculate total pages
                double value = data.TotalCount / Convert.ToDouble(Properties.Settings.Default.NoOfDataInDgvs);
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

                PaginationHide();
            }
            catch (Exception ex)
            {
                ToasterHelper.ShowErrorHappened(ex.Message);
            }
        }

        private void RefreshDgvAsync(int skip)
        {
            try
            {
                SetColumns();
                string t1 = rbStoresFrom.Checked ? cmbCaisse.Text : string.Empty;

                SetProductsToDgvAsync(t1, txtSearch.Text, skip);
                lblEmptyData.Visible = dgvHelper.IsEmpty(DgvSales);
            }
            catch (Exception ex)
            {
                ToasterHelper.ShowErrorHappened(ex.Message);
            }
        }
        public async Task LoadData()
        {
            try
            {
                dgvHelper.ResetForm(this);
                dtpTo.Value = DateTime.Now;

                // Show loading indicator
                LoadingForm.Instance(_main).Show();

                if (await repository.IsConnectedAsync())
                {
                    cmbCaisse.DataSource = await _context.Caisses.ToListAsync();
                    cmbCaisse.DisplayMember = "CaisseName";
                    cmbCaisse.ValueMember = "Id";

                    // Load initial data
                    RefreshDgvAsync(0);
                }
                else
                {
                    MsgHelper.ShowServerError();
                }
            }
            catch (Exception ex)
            {
                ToasterHelper.ShowErrorHappened(ex.Message);

            }
            finally
            {
                LoadingForm.Instance(_main).Hide();
                lblEmptyData.Visible = dgvHelper.IsEmpty(DgvSales);
            }
        }

        private void SetColumns()
        {
            DgvSales.DataSource = new List<CaisseDeposit>();
            string[] headers = { "معرف الصندوق", "قيمة الايداع", "تاريخ الايداع", "وقت الايداع", "اسم المودع", "نوع الايداع", "السبب", "الصندوق", "معرف العملية" };
            int[] widths = { 105, 0, 100, 95, 0, 0, 150, 110, 100 };

            for (int i = 0; i < headers.Length; i++)
            {
                DgvSales.Columns[i].HeaderCell.Value = headers[i];
                if (widths[i] > 0)
                {
                    DgvSales.Columns[i].Width = widths[i];
                }
            }
        }

        private void rbStoresFromAll_CheckedChanged(object sender, EventArgs e)
        {
            cmbCaisse.Enabled = rbStoresFrom.Checked;
            RefreshDgvAsync(0);
        }
        private void rbStoresFrom_CheckedChanged(object sender, EventArgs e)
        {
            cmbCaisse.Enabled = rbStoresFrom.Checked;
            RefreshDgvAsync(0);
        }
        private void btnSearch_Click(object sender, EventArgs e) => RefreshDgvAsync(0);
        private void cmbCaisse_SelectionChangeCommitted(object sender, EventArgs e) => RefreshDgvAsync(0);

        private async void button2_Click(object sender, EventArgs e)
        {
            try
            {
                ToasterHelper.PlayNotificationSound();

                if (MsgHelper.ShowDeleteDialog())
                {
                    List<int> idsToDelete = new List<int>();

                    // Collect IDs safely from column index 8
                    foreach (DataGridViewRow row in DgvSales.Rows)
                    {
                        if (row.Cells[8].Value != null && int.TryParse(row.Cells[8].Value.ToString(), out int id))
                        {
                            idsToDelete.Add(id);
                        }
                    }

                    // Fetch all matching entities at once
                    var entitiesToDelete = await _context.CaissesDeposits
                        .Where(x => idsToDelete.Contains(x.Id))
                        .ToListAsync();

                    if (entitiesToDelete.Any())
                    {
                        _context.CaissesDeposits.RemoveRange(entitiesToDelete);
                        await _context.SaveChangesAsync(); // One DB call
                    }

                    Code.Helper.ToasterHelper.ShowDeletedToast();

                    // Refresh DataGridView
                    RefreshDgvAsync(0);
                }
            }
            catch (Exception ex)
            {
                ToasterHelper.ShowErrorHappened(ex.Message);
                throw;
            }

        }

        void PaginationHide()
        {
            btnNext.Enabled = cmbpagination.SelectedIndex < cmbpagination.Items.Count - 1 && !dgvHelper.IsEmpty(DgvSales);
            btnPrev.Enabled = cmbpagination.SelectedIndex > 0 && !dgvHelper.IsEmpty(DgvSales);
            cmbpagination.Enabled = !dgvHelper.IsEmpty(DgvSales);
        }
        private async void btnNext_Click(object sender, EventArgs e)
        {
            ToasterHelper.PlayNotificationSound();
            if (cmbpagination.SelectedIndex < cmbpagination.Items.Count - 1)
            {
                cmbpagination.SelectedIndex++;
                int skip = cmbpagination.SelectedIndex * Properties.Settings.Default.NoOfDataInDgvs;
                RefreshDgvAsync(skip);

            }
        }

        private void btnPrev_Click(object sender, EventArgs e)
        {
            ToasterHelper.PlayNotificationSound();
            if (cmbpagination.SelectedIndex > 0)
            {
                cmbpagination.SelectedIndex--;
                int skip = cmbpagination.SelectedIndex * Properties.Settings.Default.NoOfDataInDgvs;

                RefreshDgvAsync(skip);
            }
        }

        private void cmbpagination_SelectionChangeCommitted(object sender, EventArgs e)
        {
            ToasterHelper.PlayNotificationSound();
            if (cmbpagination.SelectedIndex != -1)
            {
                int skip = cmbpagination.SelectedIndex * Properties.Settings.Default.NoOfDataInDgvs;
                RefreshDgvAsync(skip);
            }
        }

        private void txtSearch_KeyDown(object sender, KeyEventArgs e)
        {
            if (e.KeyCode == Keys.Enter)
            {
                btnSearch_Click(sender, e);
            }
        }
    }
}
