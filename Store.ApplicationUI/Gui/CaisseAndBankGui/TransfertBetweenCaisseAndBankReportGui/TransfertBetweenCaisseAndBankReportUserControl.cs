using Store.ApplicationUI.Code.Helper;
using Store.ApplicationUI.Gui.LoadingGui;
using Store.Infrastructure.Data;
using Store.Infrastructure.Repositories;

namespace Store.ApplicationUI.Gui.CaisseAndBankGui.TransfertBetweenCaisseAndBankReportGui
{
    public partial class TransfertBetweenCaisseAndBankReportUserControl : UserControl
    {
        private static MainForm? _main;
        private static ApplicationDbContext _contex;
        public static CaisseBankTransfereRepository? repository;
        private static TransfertBetweenCaisseAndBankReportUserControl? _UserControl;

        public TransfertBetweenCaisseAndBankReportUserControl()
        {
            InitializeComponent();
        }
        public static bool CheckInstance()
        {
            return (_UserControl == null);
        }
        public static TransfertBetweenCaisseAndBankReportUserControl Instance(MainForm main)
        {
            _main = main;
            // If the instance is null, create a new one and assign it to the static field
            if (CheckInstance())
            {
                _contex = new ApplicationDbContext();
                repository = new CaisseBankTransfereRepository(_contex);

                _UserControl = new TransfertBetweenCaisseAndBankReportUserControl();

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

            if (rbAll.Checked)
            {
                var data = repository.GetAll(dtpFrom.Value, dtpTo.Value);
                DgvSales.DataSource = data;
            }
            else if (rbBankToCaisse.Checked)
            {
                var data = repository.GetAllBankToCaisse(t1, barcode, dtpFrom.Value, dtpTo.Value, cbCaisse.Checked);
                DgvSales.DataSource = data;
            }
            else if (rbCaisseToBank.Checked)
            {
                var data = repository.GetAllCaisseToBank(t1, barcode, dtpFrom.Value, dtpTo.Value, cbCaisse.Checked);
                DgvSales.DataSource = data;
            }

        }
        void RefreshDgv()
        {
            string t1 = cmbCaisse.Text;


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

        private void rbAll_CheckedChanged(object sender, EventArgs e)
        {
            RefreshDgv();
        }

        private void rbBankToCaisse_CheckedChanged(object sender, EventArgs e)
        {
            RefreshDgv();
        }

        private void rbCaisseToBank_CheckedChanged(object sender, EventArgs e)
        {
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
            try
            {
                if (MsgHelper.ShowDeleteDialog())
                {
                    for (int i = 0; i <= DgvSales.Rows.Count - 1; i++)
                    {
                        var deleteedRefund = _contex.CaissesBankTransferes.Where(x => x.Id == Convert.ToInt32(DgvSales.Rows[i].Cells[6].Value.ToString())).FirstOrDefault();
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
