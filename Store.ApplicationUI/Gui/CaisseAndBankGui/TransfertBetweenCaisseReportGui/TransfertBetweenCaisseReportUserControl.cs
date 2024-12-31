using Store.ApplicationUI.Code.Helper;
using Store.ApplicationUI.Gui.LoadingGui;
using Store.Infrastructure.Data;
using Store.Infrastructure.Repositories;

namespace Store.ApplicationUI.Gui.CaisseAndBankGui.TransfertBetweenCaisseReportGui
{
    public partial class TransfertBetweenCaisseReportUserControl : UserControl
    {
        private static MainForm? _main;
        private static ApplicationDbContext _contex;
        public static CaisseTransfereRepository? repository;
        private static TransfertBetweenCaisseReportUserControl? _UserControl;

        public TransfertBetweenCaisseReportUserControl()
        {
            InitializeComponent();
        }
        public static bool CheckInstance()
        {
            return (_UserControl == null);
        }
        public static TransfertBetweenCaisseReportUserControl Instance(MainForm main)
        {
            _main = main;
            // If the instance is null, create a new one and assign it to the static field
            _contex = new ApplicationDbContext();
            if (CheckInstance())
            {
                repository = new CaisseTransfereRepository(_contex);

                _UserControl = new TransfertBetweenCaisseReportUserControl();

            }

            // Return the singleton instance
            _UserControl.LoadData();
            return _UserControl;
        }
        public async void SetProductsToDgv(string t1, string t2, string barcode)
        {
            ////DgvSales.DataSource = await Task.Run(() => productsRepository.GetAll(p => p.Category));
            //var CustomerMoneyList = MainForm.Context.CustomersReports.
            //    Include(x => x.Customer).Include(x => x.Sale)
            //    .ToList();

            var data = repository.GetAllDepositToCaisse(t1, t2, barcode, dtpFrom.Value, dtpTo.Value);
            DgvSales.DataSource = data;

        }
        void RefreshDgv()
        {
            string t1 = cmbcaisseFrom.SelectedValue.ToString();
            string t2 = cmbCaisse.SelectedValue.ToString();

            SetProductsToDgv(t1, t2, txtSearch.Text);
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

                cmbcaisseFrom.DataSource = _contex.Caisses.ToList();
                cmbcaisseFrom.DisplayMember = "CaisseName";
                cmbcaisseFrom.ValueMember = "Id";


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

        private void button2_Click(object sender, EventArgs e)
        {
            try
            {
                if (MsgHelper.ShowDeleteDialog())
                {
                    for (int i = 0; i <= DgvSales.Rows.Count - 1; i++)
                    {
                        var deleteedRefund = _contex.CaissesTransferes.Where(x => x.Id == Convert.ToInt32(DgvSales.Rows[i].Cells[9].Value.ToString())).FirstOrDefault();
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
