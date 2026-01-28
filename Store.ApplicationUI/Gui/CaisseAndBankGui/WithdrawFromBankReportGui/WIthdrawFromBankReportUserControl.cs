using Microsoft.EntityFrameworkCore;
using Store.ApplicationUI.Code.Helper;
using Store.ApplicationUI.Gui.LoadingGui;
using Store.Core.Entities.Banks;
using Store.Infrastructure.Data;

namespace Store.ApplicationUI.Gui.CaisseAndBankGui.WithdrawFromBankReportGui
{
    public partial class WIthdrawFromBankReportUserControl : UserControl
    {
        private readonly MainForm _mainForm;
        private readonly ApplicationDbContext _context;


        public WIthdrawFromBankReportUserControl(MainForm mainForm, ApplicationDbContext context)
        {
            InitializeComponent();
            _mainForm = mainForm;
            _context = context;
        }

        public async Task SetProductsToDgv(string barcode)
        {
            ////DgvSales.DataSource = await Task.Run(() => productsRepository.GetAll(p => p.Category));
            //var CustomerMoneyList = MainForm.Context.CustomersReports.
            //    Include(x => x.Customer).Include(x => x.Sale)
            //    .ToList();

            var data = await GetAllDepositToCaisse(barcode, dtpFrom.Value, dtpTo.Value);
            DgvSales.DataSource = data;

        }

        private async Task<List<BankWithdraw>> GetAllDepositToCaisse(string barcode, DateTime value1, DateTime value2)
        {
            try
            {
                var allTransfers = _context.BankWithdraws
                      .AsQueryable();
                if (barcode != string.Empty) allTransfers = allTransfers.Where(x => x.Reason == barcode || x.Name.Contains(barcode));
                allTransfers = allTransfers.Where(x => x.Date >= value1 && x.Date <= value2)
                     ;
                return await allTransfers.ToListAsync();
            }
            catch (Exception ex)
            {

                throw new Exception("Error retrieving the buyFactures", ex);
            }
        }

        async Task RefreshDgv()
        {




            SetColumns();
            await SetProductsToDgv(txtSearch.Text);
            lblEmptyData.Visible = dgvHelper.IsEmpty(DgvSales);
        }
        public async Task LoadData()
        {
            dgvHelper.ResetForm(this);
            dtpTo.Value = DateTime.Now;

            //ShowLoading
            LoadingForm.Instance(_mainForm).Show();
            if (await _context.Database.CanConnectAsync())
            {
                //Start Load Data


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
            DgvSales.DataSource = new List<BankWithdraw>();
            //DgvSales.Columns[0].HeaderCell.Value = "المعرف"; ""    
            DgvSales.Columns[0].HeaderCell.Value = "قيمة السحب";
            DgvSales.Columns[1].HeaderCell.Value = "تاريخ السحب";
            DgvSales.Columns[2].HeaderCell.Value = "وقت السحب";
            DgvSales.Columns[3].HeaderCell.Value = "اسم الساحب";
            DgvSales.Columns[4].HeaderCell.Value = "نوع السحب";
            DgvSales.Columns[5].HeaderCell.Value = "السبب";
            DgvSales.Columns[6].HeaderCell.Value = "معرف العملية";


            //DgvSales.Columns[8].Visible = false;
            //DgvSales.Columns[8].Visible = false;
            //DgvSales.Columns[4].Visible = false;

        }

        private async void btnSearch_Click(object sender, EventArgs e)
        {
            txtSearch.Text = txtSearch.Text.Replace("\r\n", "").Trim();
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

                    // Collect IDs from DataGridView column index 6
                    foreach (DataGridViewRow row in DgvSales.Rows)
                    {
                        if (row.Cells[6].Value != null && int.TryParse(row.Cells[6].Value.ToString(), out int id))
                        {
                            idsToDelete.Add(id);
                        }
                    }

                    // Fetch all matching entities at once
                    var entitiesToDelete = await _context.BankWithdraws
                        .Where(x => idsToDelete.Contains(x.Id))
                        .ToListAsync();

                    if (entitiesToDelete.Any())
                    {
                        _context.BankWithdraws.RemoveRange(entitiesToDelete);
                        await _context.SaveChangesAsync(); // Single DB call
                    }

                    Code.Helper.ToasterHelper.ShowDeletedToast();

                    // Refresh DataGridView (no need to set DataSource = null before)
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
