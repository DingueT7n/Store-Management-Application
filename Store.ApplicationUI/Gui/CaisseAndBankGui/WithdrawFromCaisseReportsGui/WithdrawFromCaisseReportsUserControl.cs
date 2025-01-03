using Store.ApplicationUI.Code.Helper;
using Store.ApplicationUI.Gui.LoadingGui;
using Store.Infrastructure.Data;
using Store.Infrastructure.Repositories;

namespace Store.ApplicationUI.Gui.CaisseAndBankGui.WithdrawFromCaisseReportsGui
{
    public partial class WithdrawFromCaisseReportsUserControl : UserControl
    {
        private static MainForm? _main;
        private static ApplicationDbContext _contex;
        public static CaisseWithdrawRepository? repository;
        private static WithdrawFromCaisseReportsUserControl? _UserControl;

        public WithdrawFromCaisseReportsUserControl()
        {
            InitializeComponent();
        }
        public static bool CheckInstance()
        {
            return (_UserControl == null);
        }
        public static WithdrawFromCaisseReportsUserControl Instance(MainForm main)
        {
            _main = main;
            // If the instance is null, create a new one and assign it to the static field
            _contex = new ApplicationDbContext();
            if (CheckInstance())
            {
                repository = new CaisseWithdrawRepository(_contex);

                _UserControl = new WithdrawFromCaisseReportsUserControl();

            }

            // Return the singleton instance
            _UserControl.LoadData();
            return _UserControl;
        }
        public async void SetProductsToDgv(string t1, string barcode)
        {
            ////DgvSales.DataSource = await Task.Run(() => productsRepository.GetAll(p => p.Category));
            //var CustomerMoneyList = MainForm.Context.CustomersReports.
            //    Include(x => x.Customer).Include(x => x.Sale)
            //    .ToList();

            var data = repository.GetAllDepositToCaisse(t1, barcode, dtpFrom.Value, dtpTo.Value);
            DgvSales.DataSource = data;

        }
        void RefreshDgv()
        {
            string t1 = string.Empty;

            if (rbStoresFrom.Checked) t1 = cmbCaisse.Text;

            SetProductsToDgv(t1, txtSearch.Text);
            SetColumns();
            lblEmptyData.Visible = dgvHelper.IsEmpty(DgvSales);
        }
        public async void LoadData()
        {
            dtpTo.Value = DateTime.Now;

            //ShowLoading
            LoadingForm.Instance(_main).Show();
            if (await Task.Run(() => repository.IsConnected()))
            {
                //Start Load Data
                cmbCaisse.DataSource = _contex.Caisses.ToList();
                cmbCaisse.DisplayMember = "CaisseName";
                cmbCaisse.ValueMember = "Id";


                // if its an admin or Normal user 
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
            RefreshDgv();
        }

        private void rbStoresFrom_CheckedChanged(object sender, EventArgs e)
        {
            cmbCaisse.Enabled = true;
            RefreshDgv();
        }

        private void btnSearch_Click(object sender, EventArgs e)
        {
            RefreshDgv();
        }

        private void cmbCaisse_SelectionChangeCommitted(object sender, EventArgs e)
        {
            RefreshDgv();
        }

        private void button2_Click(object sender, EventArgs e)
        {
            ToasterHelper.PlayNotificationSound();

            try
            {
                if (MsgHelper.ShowDeleteDialog())
                {
                    for (int i = 0; i <= DgvSales.Rows.Count - 1; i++)
                    {
                        var deleteedRefund = _contex.CaissesWithdraws.Where(x => x.Id == Convert.ToInt32(DgvSales.Rows[i].Cells[8].Value.ToString())).FirstOrDefault();
                        if (deleteedRefund != null)
                        {
                            _contex.Remove(deleteedRefund);
                            _contex.SaveChanges();
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
    }
}
