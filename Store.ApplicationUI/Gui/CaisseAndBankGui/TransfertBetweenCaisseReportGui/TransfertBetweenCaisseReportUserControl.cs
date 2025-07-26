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

        public async void SetProductsToDgv(string t1, string t2, string barcode)
        {
            ////DgvSales.DataSource = await Task.Run(() => productsRepository.GetAll(p => p.Category));
            //var CustomerMoneyList = MainForm.Context.CustomersReports.
            //    Include(x => x.Customer).Include(x => x.Sale)
            //    .ToList();

            var data = await repository.GetAllDepositToCaisse(t1, t2, barcode, dtpFrom.Value, dtpTo.Value);
            DgvSales.DataSource = data;

        }
        void RefreshDgv()
        {
            string t1 = cmbcaisseFrom.SelectedValue.ToString();
            string t2 = cmbCaisse.SelectedValue.ToString();

            SetColumns();
            SetProductsToDgv(t1, t2, txtSearch.Text);

            lblEmptyData.Visible = dgvHelper.IsEmpty(DgvSales);
        }
        public async void LoadData()
        {
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
                RefreshDgv();
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

        private void btnSearch_Click(object sender, EventArgs e)
        {
            txtSearch.Text = txtSearch.Text.Replace("\r\n", "");
            RefreshDgv();
        }

        private void cmbcaisseFrom_SelectionChangeCommitted(object sender, EventArgs e)
        {
            RefreshDgv();
        }

        private void cmbCaisse_SelectionChangeCommitted(object sender, EventArgs e)
        {
            RefreshDgv();
        }

        private async void button2_Click(object sender, EventArgs e)
        {
            ToasterHelper.PlayNotificationSound();
            try
            {
                if (MsgHelper.ShowDeleteDialog())
                {
                    for (int i = 0; i <= DgvSales.Rows.Count - 1; i++)
                    {
                        var deleteedRefund = await _context.CaissesTransferes.Where(x => x.Id == Convert.ToInt32(DgvSales.Rows[i]
                            .Cells[9].Value.ToString())).FirstOrDefaultAsync();
                        if (deleteedRefund != null)
                        {
                            _context.Remove(deleteedRefund);
                            await _context.SaveChangesAsync();
                        }
                    }

                    Code.Helper.ToasterHelper.ShowDeletedToast();
                    DgvSales.DataSource = null;
                    RefreshDgv();
                }
            }
            catch (Exception)
            {
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
