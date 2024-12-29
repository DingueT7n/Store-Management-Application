using Store.ApplicationUI.Code.Helper;
using Store.ApplicationUI.Gui.LoadingGui;
using Store.Core.Entities.Banks;
using Store.Infrastructure.Data;

namespace Store.ApplicationUI.Gui.CaisseAndBankGui.DepositToBankReportGui
{
    public partial class DepositToBankReportUserControl : UserControl
    {
        private static MainForm? _main;
        private static ApplicationDbContext _contex;

        private static DepositToBankReportUserControl? _UserControl;

        public DepositToBankReportUserControl()
        {
            InitializeComponent();
        }
        public static bool CheckInstance()
        {
            return (_UserControl == null);
        }
        public static DepositToBankReportUserControl Instance(MainForm main)
        {
            _main = main;
            // If the instance is null, create a new one and assign it to the static field
            _contex = new ApplicationDbContext();
            if (CheckInstance())
            {
                _UserControl = new DepositToBankReportUserControl();

            }

            // Return the singleton instance
            _UserControl.LoadData();
            return _UserControl;
        }
        public async void SetProductsToDgv(string barcode)
        {
            ////DgvSales.DataSource = await Task.Run(() => productsRepository.GetAll(p => p.Category));
            //var CustomerMoneyList = MainForm.Context.CustomersReports.
            //    Include(x => x.Customer).Include(x => x.Sale)
            //    .ToList();

            var data = GetAllDepositToCaisse(barcode, dtpFrom.Value, dtpTo.Value);
            DgvSales.DataSource = data;

        }

        private List<BankDeposit> GetAllDepositToCaisse(string barcode, DateTime value1, DateTime value2)
        {
            try
            {
                var allTransfers = _contex.BankDeposits
                      .AsEnumerable();
                if (barcode != string.Empty) allTransfers = allTransfers.Where(x => x.Reason == barcode || x.Name.Contains(barcode));
                allTransfers = allTransfers.Where(x => x.Date >= value1 && x.Date <= value2)
                     ;
                return allTransfers.ToList();
            }
            catch (Exception ex)
            {

                throw new Exception("Error retrieving the buyFactures", ex);
            }
        }

        void RefreshDgv()
        {
            SetProductsToDgv(txtSearch.Text);
            SetColumns();
            lblEmptyData.Visible = dgvHelper.IsEmpty(DgvSales);
        }
        public async void LoadData()
        {
            dtpTo.Value = DateTime.Now;

            //ShowLoading
            LoadingForm.Instance(_main).Show();
            if (await Task.Run(() => _contex.Database.CanConnect()))
            {

                RefreshDgv();
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

        private void btnSearch_Click(object sender, EventArgs e)
        {
            RefreshDgv();
        }
        private void button2_Click(object sender, EventArgs e)
        {
            try
            {
                if (MsgHelper.ShowDeleteDialog())
                {
                    for (int i = 0; i <= DgvSales.Rows.Count - 1; i++)
                    {
                        var deleteedRefund = _contex.BankDeposits.Where(x => x.Id == Convert.ToInt32(DgvSales.Rows[i].Cells[6].Value.ToString())).FirstOrDefault();
                        if (deleteedRefund != null)
                        {
                            _contex.Remove(deleteedRefund);
                            _contex.SaveChanges();
                        }
                    }
                    DgvSales.DataSource = null;
                    RefreshDgv();
                }
            }
            catch (Exception)
            {
                throw;
            }
        }
    }
}
