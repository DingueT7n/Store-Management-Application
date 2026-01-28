using Microsoft.EntityFrameworkCore;
using Store.ApplicationUI.Code.Helper;
using Store.ApplicationUI.Gui.LoadingGui;
using Store.Core.Entities.Caisses;
using Store.Core.Interfaces;
using Store.Infrastructure.Data;

namespace Store.ApplicationUI.Gui.CaisseAndBankGui.TransfertBetweenCaisseReportGui
{
    public partial class TransfertBetweenCaisseReportUserControl : UserControl
    {

        public readonly ICaisseTransfereRepository repository;
        private readonly MainForm _mainForm;
        private readonly ApplicationDbContext _context;

        public TransfertBetweenCaisseReportUserControl(MainForm mainForm, ApplicationDbContext context, ICaisseTransfereRepository repository)
        {
            InitializeComponent();
            _mainForm = mainForm;
            _context = context;
            this.repository = repository;
        }

        public async Task SetProductsToDgv(string t1, string t2, string barcode)
        {
            ////DgvSales.DataSource = await Task.Run(() => productsRepository.GetAll(p => p.Category));
            //var CustomerMoneyList = MainForm.Context.CustomersReports.
            //    Include(x => x.Customer).Include(x => x.Sale)
            //    .ToList();

            var data = await repository.GetAllDepositToCaisse(t1, t2, barcode, dtpFrom.Value, dtpTo.Value);
            DgvSales.DataSource = data;

        }
        async Task RefreshDgv()
        {
            string t1 = cmbcaisseFrom.SelectedValue.ToString();
            string t2 = cmbCaisse.SelectedValue.ToString();

            SetColumns();
            await SetProductsToDgv(t1, t2, txtSearch.Text);

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

                cmbcaisseFrom.DataSource = await _context.Caisses.ToListAsync();
                cmbcaisseFrom.DisplayMember = "CaisseName";
                cmbcaisseFrom.ValueMember = "Id";


                // if its an admin or Normal user 
                await RefreshDgv();
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
            //DgvSales.Columns[0].HeaderCell.Value = "المعرف"; ""    
            DgvSales.DataSource = new List<CaisseTransfere>();

            DgvSales.Columns[0].HeaderCell.Value = "قيمة الايداع";
            DgvSales.Columns[1].HeaderCell.Value = "تاريخ الايداع";
            DgvSales.Columns[2].HeaderCell.Value = "وقت الايداع";
            DgvSales.Columns[3].HeaderCell.Value = "اسم المودع";
            DgvSales.Columns[4].HeaderCell.Value = "السبب";
            DgvSales.Columns[5].HeaderCell.Value = "معرف الصندوق المرسل";
            DgvSales.Columns[6].HeaderCell.Value = "معرف الصندوق المستقبل";
            DgvSales.Columns[7].HeaderCell.Value = "الصندوق المرسل";
            DgvSales.Columns[8].HeaderCell.Value = "الصندوق المستقبل";
            DgvSales.Columns[9].HeaderCell.Value = "معرف العملية";

            DgvSales.Columns[9].Width = 100;
            //DgvSales.Columns[8].Visible = false;
            //DgvSales.Columns[8].Visible = false;
            //DgvSales.Columns[4].Visible = false;

        }

        private async void btnSearch_Click(object sender, EventArgs e)
        {
            txtSearch.Text = txtSearch.Text.Replace("\r\n", "").Trim();
            await RefreshDgv();
        }

        private async void cmbcaisseFrom_SelectionChangeCommitted(object sender, EventArgs e)
        {
            await RefreshDgv();
        }

        private async void cmbCaisse_SelectionChangeCommitted(object sender, EventArgs e)
        {
            await RefreshDgv();
        }

        private async void button2_Click(object sender, EventArgs e)
        {
            ToasterHelper.PlayNotificationSound();

            try
            {
                if (MsgHelper.ShowDeleteDialog())
                {
                    List<int> idsToDelete = new List<int>();

                    // Collect IDs from DataGridView (column index 9)
                    foreach (DataGridViewRow row in DgvSales.Rows)
                    {
                        if (row.Cells[9].Value != null && int.TryParse(row.Cells[9].Value.ToString(), out int id))
                        {
                            idsToDelete.Add(id);
                        }
                    }

                    // Fetch all entities at once
                    var entitiesToDelete = await _context.CaissesTransferes
                        .Where(x => idsToDelete.Contains(x.Id))
                        .ToListAsync();

                    if (entitiesToDelete.Any())
                    {
                        _context.CaissesTransferes.RemoveRange(entitiesToDelete);
                        await _context.SaveChangesAsync(); // Single DB call
                    }

                    Code.Helper.ToasterHelper.ShowDeletedToast();

                    // Refresh DataGridView (no need to set DataSource = null first)
                    await RefreshDgv();
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
    }
}
