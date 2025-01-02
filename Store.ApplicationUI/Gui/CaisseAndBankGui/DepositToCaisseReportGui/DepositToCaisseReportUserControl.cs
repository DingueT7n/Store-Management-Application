using Store.ApplicationUI.Code.Helper;
using Store.ApplicationUI.Gui.LoadingGui;
using Store.Infrastructure.Data;
using Store.Infrastructure.Repositories;

namespace Store.ApplicationUI.Gui.CaisseAndBankGui.DepositToCaisseReportGui
{
    public partial class DepositToCaisseReportUserControl : UserControl
    {
        private static MainForm? _main;
        private static ApplicationDbContext _contex;
        public static CaisseDepositRepository? repository;
        private static DepositToCaisseReportUserControl? _UserControl;

        public DepositToCaisseReportUserControl()
        {
            InitializeComponent();
        }
        public static bool CheckInstance()
        {
            return (_UserControl == null);
        }
        public static DepositToCaisseReportUserControl Instance(MainForm main)
        {
            _main = main;
            // If the instance is null, create a new one and assign it to the static field
            _contex = new ApplicationDbContext();
            if (CheckInstance())
            {
                repository = new CaisseDepositRepository(_contex);

                _UserControl = new DepositToCaisseReportUserControl();

            }

            // Return the singleton instance
            _UserControl.LoadDataAsync();
            return _UserControl;
        }
        public async Task SetProductsToDgvAsync(string t1, string barcode, int skip)
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
                    cmbpagination.Items.Add(i);
                }

                if (cmbpagination.Items.Count > 0)
                {
                    cmbpagination.SelectedIndex = skip / Properties.Settings.Default.NoOfDataInDgvs;
                }

                PaginationHide();
            }
            catch (Exception)
            {

            }
        }

        private async Task RefreshDgvAsync(int skip)
        {
            try
            {
                string t1 = rbStoresFrom.Checked ? cmbCaisse.Text : string.Empty;

                await SetProductsToDgvAsync(t1, txtSearch.Text, skip);
                SetColumns();
                lblEmptyData.Visible = dgvHelper.IsEmpty(DgvSales);
            }
            catch (Exception ex)
            {
            }
        }
        public async Task LoadDataAsync()
        {
            try
            {
                dtpTo.Value = DateTime.Now;

                // Show loading indicator
                LoadingForm.Instance(_main).Show();

                if (await Task.Run(() => repository.IsConnected()))
                {
                    cmbCaisse.DataSource = _contex.Caisses.ToList();
                    cmbCaisse.DisplayMember = "CaisseName";
                    cmbCaisse.ValueMember = "Id";

                    // Load initial data
                    await RefreshDgvAsync(0);
                }
                else
                {
                    MsgHelper.ShowServerError();
                }
            }
            catch (Exception ex)
            {

            }
            finally
            {
                LoadingForm.Instance(_main).Hide();
                lblEmptyData.Visible = dgvHelper.IsEmpty(DgvSales);
            }
        }

        private void SetColumns()
        {
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


        private void rbStoresFromAll_CheckedChanged(object sender, EventArgs e) => RefreshDgvAsync(0);
        private void rbStoresFrom_CheckedChanged(object sender, EventArgs e) => RefreshDgvAsync(0);
        private void btnSearch_Click(object sender, EventArgs e) => RefreshDgvAsync(0);
        private void cmbCaisse_SelectionChangeCommitted(object sender, EventArgs e) => RefreshDgvAsync(0);

        private void button2_Click(object sender, EventArgs e)
        {
            try
            {
                ToasterHelper.PlayNotificationSound();
                if (MsgHelper.ShowDeleteDialog())
                {
                    foreach (DataGridViewRow row in DgvSales.Rows)
                    {
                        int id = Convert.ToInt32(row.Cells[8].Value);
                        var deposit = _contex.CaissesDeposits.FirstOrDefault(x => x.Id == id);

                        if (deposit != null)
                        {
                            _contex.CaissesDeposits.Remove(deposit);
                            _contex.SaveChanges();
                        }
                    }
                    Code.Helper.ToasterHelper.ShowDeletedToast();

                    DgvSales.DataSource = null;
                    RefreshDgvAsync(0);
                }
            }
            catch (Exception ex)
            {
            }
        }

        void PaginationHide()
        {
            btnNext.Enabled = cmbpagination.SelectedIndex < cmbpagination.Items.Count - 1 && !dgvHelper.IsEmpty(DgvSales);
            btnPrev.Enabled = cmbpagination.SelectedIndex > 0 && !dgvHelper.IsEmpty(DgvSales);
            cmbpagination.Enabled = !dgvHelper.IsEmpty(DgvSales);
        }
        private void btnNext_Click(object sender, EventArgs e)
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
    }
}
