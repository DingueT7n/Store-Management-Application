using Microsoft.EntityFrameworkCore;
using Store.ApplicationUI.Code.Helper;
using Store.ApplicationUI.Gui.LoadingGui;
using Store.Core.Entities.Banks;
using Store.Infrastructure.Data;

namespace Store.ApplicationUI.Gui.CaisseAndBankGui.DepositToBankReportGui
{
    public partial class DepositToBankReportUserControl : UserControl
    {
        private readonly MainForm _main;
        private readonly ApplicationDbContext _context;
        public DepositToBankReportUserControl(MainForm main, ApplicationDbContext context)
        {
            InitializeComponent();
            _main = main;
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

        private async Task<List<BankDeposit>> GetAllDepositToCaisse(string barcode, DateTime value1, DateTime value2)
        {
            try
            {
                var allTransfers = _context.BankDeposits
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
            LoadingForm.Instance(_main).Show();
            if (await _context.Database.CanConnectAsync())
            {

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


            DgvSales.DataSource = new List<BankDeposit>();
            DgvSales.Columns[0].HeaderCell.Value = "قيمة الايداع";
            DgvSales.Columns[1].HeaderCell.Value = "تاريخ الايداع";
            DgvSales.Columns[2].HeaderCell.Value = "وقت الايداع";
            DgvSales.Columns[3].HeaderCell.Value = "اسم المودع";
            DgvSales.Columns[4].HeaderCell.Value = "نوع الايداع";
            DgvSales.Columns[5].HeaderCell.Value = "السبب";
            DgvSales.Columns[6].HeaderCell.Value = "معرف العملية";



            DgvSales.Columns[6].Width = 100;

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
            try
            {
                ToasterHelper.PlayNotificationSound();

                if (MsgHelper.ShowDeleteDialog())
                {
                    List<int> idsToDelete = new List<int>();

                    // Collect IDs safely from column index 6
                    foreach (DataGridViewRow row in DgvSales.Rows)
                    {
                        if (row.Cells[6].Value != null && int.TryParse(row.Cells[6].Value.ToString(), out int id))
                        {
                            idsToDelete.Add(id);
                        }
                    }

                    // Fetch all matching entities at once
                    var entitiesToDelete = await _context.BankDeposits
                        .Where(x => idsToDelete.Contains(x.Id))
                        .ToListAsync();

                    if (entitiesToDelete.Any())
                    {
                        _context.BankDeposits.RemoveRange(entitiesToDelete);
                        await _context.SaveChangesAsync(); // One DB call
                    }

                    Code.Helper.ToasterHelper.ShowDeletedToast();

                    // Refresh DataGridView
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
