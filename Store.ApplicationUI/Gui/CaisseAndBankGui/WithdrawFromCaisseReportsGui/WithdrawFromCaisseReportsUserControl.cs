using Microsoft.EntityFrameworkCore;
using Store.ApplicationUI.Code.Helper;
using Store.ApplicationUI.Gui.LoadingGui;
using Store.Core.Entities.Caisses;
using Store.Core.Interfaces;
using Store.Infrastructure.Data;

namespace Store.ApplicationUI.Gui.CaisseAndBankGui.WithdrawFromCaisseReportsGui
{
    public partial class WithdrawFromCaisseReportsUserControl : UserControl
    {
        private readonly MainForm _mainForm;
        private readonly ApplicationDbContext _context;
        public readonly ICaisseWithdrawRepository repository;


        public WithdrawFromCaisseReportsUserControl(MainForm mainForm, ApplicationDbContext context, ICaisseWithdrawRepository repository)
        {
            InitializeComponent();
            _mainForm = mainForm;
            _context = context;
            this.repository = repository;
        }

        public void SetProductsToDgv(string t1, string barcode, int skip)
        {
            ////DgvSales.DataSource = await Task.Run(() => productsRepository.GetAll(p => p.Category));
            //var CustomerMoneyList = MainForm.Context.CustomersReports.
            //    Include(x => x.Customer).Include(x => x.Sale)
            //    .ToList();
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
        void RefreshDgv(int skip)
        {
            string t1 = string.Empty;

            SetColumns();
            if (rbStoresFrom.Checked) t1 = cmbCaisse.Text;

            SetProductsToDgv(t1, txtSearch.Text, skip);
            lblEmptyData.Visible = dgvHelper.IsEmpty(DgvSales);
        }
        public async Task LoadData()
        {
            dgvHelper.ResetForm(this);
            dtpTo.Value = DateTime.Now;

            //ShowLoading
            LoadingForm.Instance(_mainForm).Show();
            if (await repository.IsConnectedAsync())
            {
                //Start Load Data
                cmbCaisse.DataSource = await _context.Caisses.ToListAsync();
                cmbCaisse.DisplayMember = "CaisseName";
                cmbCaisse.ValueMember = "Id";


                // if its an admin or Normal user 
                RefreshDgv(0);
                //_data.Clear();
            }
            else
            {

                LoadingForm.Instance(_mainForm).Hide();
                //No Connection
                MsgHelper.ShowServerError();
            }
            //Hideloading

            LoadingForm.Instance(_mainForm).Hide();
            // Show EmptyDAta
            lblEmptyData.Visible = dgvHelper.IsEmpty(DgvSales);
        }

        private void SetColumns()
        {
            DgvSales
                .DataSource = new List<CaisseWithdraw>();
            //DgvSales.Columns[0].HeaderCell.Value = "المعرف"; ""    
            DgvSales.Columns[0].HeaderCell.Value = "معرف الصندوق";
            DgvSales.Columns[1].HeaderCell.Value = "قيمة السحب";
            DgvSales.Columns[2].HeaderCell.Value = "تاريخ السحب";
            DgvSales.Columns[3].HeaderCell.Value = "وقت السحب";
            DgvSales.Columns[4].HeaderCell.Value = "اسم المودع";
            DgvSales.Columns[5].HeaderCell.Value = "نوع السحب";
            DgvSales.Columns[6].HeaderCell.Value = "السبب";
            DgvSales.Columns[7].HeaderCell.Value = "الصندوق";
            DgvSales.Columns[8].HeaderCell.Value = "معرف العملية";

            DgvSales.Columns[0].Width = 105;
            DgvSales.Columns[2].Width = 100;
            DgvSales.Columns[3].Width = 95;

            DgvSales.Columns[6].Width = 150;
            DgvSales.Columns[7].Width = 110;
            DgvSales.Columns[8].Width = 100;
            //DgvSales.Columns[8].Visible = false;
            //DgvSales.Columns[8].Visible = false;
            //DgvSales.Columns[4].Visible = false;

        }

        private void rbStoresFromAll_CheckedChanged(object sender, EventArgs e)
        {
            cmbCaisse.Enabled = false;
            RefreshDgv(0);
        }

        private void rbStoresFrom_CheckedChanged(object sender, EventArgs e)
        {
            cmbCaisse.Enabled = true;
            RefreshDgv(0);
        }

        private void btnSearch_Click(object sender, EventArgs e)
        {
            txtSearch.Text = txtSearch.Text.Replace("\r\n", "").Trim();
            RefreshDgv(0);
        }

        private void cmbCaisse_SelectionChangeCommitted(object sender, EventArgs e)
        {
            RefreshDgv(0);
        }

        private async void button2_Click(object sender, EventArgs e)
        {
            ToasterHelper.PlayNotificationSound();

            try
            {
                if (MsgHelper.ShowDeleteDialog())
                {
                    List<int> idsToDelete = new List<int>();

                    // Collect IDs from DataGridView
                    foreach (DataGridViewRow row in DgvSales.Rows)
                    {
                        if (row.Cells[8].Value != null && int.TryParse(row.Cells[8].Value.ToString(), out int id))
                        {
                            idsToDelete.Add(id);
                        }
                    }

                    // Fetch all matching entities at once
                    var entitiesToDelete = await _context.CaissesWithdraws
                        .Where(x => idsToDelete.Contains(x.Id))
                        .ToListAsync();

                    if (entitiesToDelete.Any())
                    {
                        _context.CaissesWithdraws.RemoveRange(entitiesToDelete);
                        await _context.SaveChangesAsync(); // Single DB call
                    }

                    Code.Helper.ToasterHelper.ShowDeletedToast();

                    // Refresh DataGridView
                    RefreshDgv(0);
                }
            }
            catch (Exception ex)
            {
                ToasterHelper.ShowErrorHappened(ex.Message);
                throw;
            }

        }

        private void txtSearch_KeyDown(object sender, KeyEventArgs e)
        {
            if (e.KeyCode == Keys.Enter)
            {
                btnSearch_Click(sender, e);
            }
        }

        private void btnNext_Click(object sender, EventArgs e)
        {
            ToasterHelper.PlayNotificationSound();
            if (cmbpagination.SelectedIndex < cmbpagination.Items.Count - 1)
            {
                cmbpagination.SelectedIndex++;
                int skip = cmbpagination.SelectedIndex * Properties.Settings.Default.NoOfDataInDgvs;
                RefreshDgv(skip);

            }
        }

        private void btnPrev_Click(object sender, EventArgs e)
        {
            ToasterHelper.PlayNotificationSound();
            if (cmbpagination.SelectedIndex > 0)
            {
                cmbpagination.SelectedIndex--;
                int skip = cmbpagination.SelectedIndex * Properties.Settings.Default.NoOfDataInDgvs;

                RefreshDgv(skip);
            }
        }
        void PaginationHide()
        {
            btnNext.Enabled = cmbpagination.SelectedIndex < cmbpagination.Items.Count - 1 && !dgvHelper.IsEmpty(DgvSales);
            btnPrev.Enabled = cmbpagination.SelectedIndex > 0 && !dgvHelper.IsEmpty(DgvSales);
            cmbpagination.Enabled = !dgvHelper.IsEmpty(DgvSales);
        }
        private void cmbpagination_SelectionChangeCommitted(object sender, EventArgs e)
        {
            ToasterHelper.PlayNotificationSound();
            if (cmbpagination.SelectedIndex != -1)
            {
                int skip = cmbpagination.SelectedIndex * Properties.Settings.Default.NoOfDataInDgvs;
                RefreshDgv(skip);
            }
        }
    }
}
