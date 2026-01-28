using Microsoft.EntityFrameworkCore;
using Store.ApplicationUI.Code.Helper;
using Store.ApplicationUI.Gui.LoadingGui;
using Store.Core.Entities.Caisses;
using Store.Core.Interfaces;
using Store.Infrastructure.Data;

namespace Store.ApplicationUI.Gui.CaisseAndBankGui.TransfertBetweenCaisseAndBankReportGui
{
    public partial class TransfertBetweenCaisseAndBankReportUserControl : UserControl
    {
        private readonly MainForm _main;

        public readonly ICaisseBankTransfereRepository repository;
        private readonly ApplicationDbContext _context;

        public TransfertBetweenCaisseAndBankReportUserControl(ICaisseBankTransfereRepository repository, ApplicationDbContext context, MainForm main)
        {
            InitializeComponent();
            this.repository = repository;
            _context = context;
            _main = main;
        }
        public async Task SetProductsToDgv(string t1, string barcode)
        {
            ////DgvSales.DataSource = await Task.Run(() => productsRepository.GetAll(p => p.Category));
            //var CustomerMoneyList = MainForm.Context.CustomersReports.
            //    Include(x => x.Customer).Include(x => x.Sale)
            //    .ToList();

            if (rbAll.Checked)
            {
                var data = await repository.GetAll(dtpFrom.Value, dtpTo.Value);
                DgvSales.DataSource = data;
            }
            else if (rbBankToCaisse.Checked)
            {
                var data = await repository.GetAllBankToCaisse(t1, barcode, dtpFrom.Value, dtpTo.Value, cbCaisse.Checked);
                DgvSales.DataSource = data;
            }
            else if (rbCaisseToBank.Checked)
            {
                var data = await repository.GetAllCaisseToBank(t1, barcode, dtpFrom.Value, dtpTo.Value, cbCaisse.Checked);
                DgvSales.DataSource = data;
            }

        }
        async Task RefreshDgv()
        {
            string t1 = cmbCaisse.Text;


            SetColumns();
            await SetProductsToDgv(t1, txtSearch.Text);

            lblEmptyData.Visible = dgvHelper.IsEmpty(DgvSales);
        }
        public async Task LoadData()
        {
            dgvHelper.ResetForm(this);
            dtpTo.Value = DateTime.Now;

            //ShowLoading
            LoadingForm.Instance(_main).Show();
            if (await repository.IsConnectedAsync())
            {
                //Start Load Data
                cmbCaisse.DataSource = await _context.Caisses.ToListAsync();
                cmbCaisse.DisplayMember = "CaisseName";
                cmbCaisse.ValueMember = "Id";




                // if its an admin or Normal user 
                await RefreshDgv();
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
            lblEmptyData.Visible = dgvHelper.IsEmpty(DgvSales);
        }

        private void SetColumns()
        {
            //DgvSales.Columns[0].HeaderCell.Value = "المعرف"; ""    

            DgvSales.DataSource = new List<CaisseBankTransfere>();
            DgvSales.Columns[0].HeaderCell.Value = "قيمة التحويل";
            DgvSales.Columns[1].HeaderCell.Value = "تاريخ التحويل";
            DgvSales.Columns[2].HeaderCell.Value = "وقت التحويل";
            DgvSales.Columns[3].HeaderCell.Value = "من";
            DgvSales.Columns[4].HeaderCell.Value = "الى";
            DgvSales.Columns[5].HeaderCell.Value = "اسم المحول";
            DgvSales.Columns[6].HeaderCell.Value = "معرف العملية";


            //DgvSales.Columns[8].Visible = false;
            //DgvSales.Columns[8].Visible = false;
            //DgvSales.Columns[4].Visible = false;

        }
        private void checkBox1_CheckedChanged(object sender, EventArgs e)
        {
            if (cbCaisse.Checked)
            {
                cmbCaisse.Enabled = true;
            }
            else
            {
                cmbCaisse.Enabled = false;
            }
        }

        private async void rbAll_CheckedChanged(object sender, EventArgs e)
        {
            await RefreshDgv();
        }

        private async void rbBankToCaisse_CheckedChanged(object sender, EventArgs e)
        {
            await RefreshDgv();
        }

        private async void rbCaisseToBank_CheckedChanged(object sender, EventArgs e)
        {
            await RefreshDgv();
        }

        private async void btnSearch_Click(object sender, EventArgs e)
        {
            txtSearch.Text = txtSearch.Text.Replace("\r\n", "").Trim();
            await RefreshDgv();
        }

        private async void cmbCaisse_SelectionChangeCommitted(object sender, EventArgs e)
        {
            await RefreshDgv();
        }

        private async void button2_Click(object sender, EventArgs e)
        {
            try
            {
                ToasterHelper.PlayNotificationSound();

                if (MsgHelper.ShowDeleteDialog())
                {
                    List<int> idsToDelete = new List<int>();

                    // Collect IDs from DataGridView (column index 6)
                    foreach (DataGridViewRow row in DgvSales.Rows)
                    {
                        if (row.Cells[6].Value != null && int.TryParse(row.Cells[6].Value.ToString(), out int id))
                        {
                            idsToDelete.Add(id);
                        }
                    }

                    // Fetch all matching entities at once
                    var entitiesToDelete = await _context.CaissesBankTransferes
                        .Where(x => idsToDelete.Contains(x.Id))
                        .ToListAsync();

                    if (entitiesToDelete.Any())
                    {
                        _context.CaissesBankTransferes.RemoveRange(entitiesToDelete);
                        await _context.SaveChangesAsync(); // One DB call
                    }

                    Code.Helper.ToasterHelper.ShowDeletedToast();

                    // Refresh DataGridView (no need to clear DataSource first)
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
