using Store.ApplicationUI.Code.Helper;
using Store.ApplicationUI.Gui.LoadingGui;
using Store.Infrastructure.Data;
using Store.Infrastructure.Repositories;

namespace Store.ApplicationUI.Gui.ProductsGui.StoreGui.StoreTrensfertReportGui
{
    public partial class StoreTransfertReportUserControl : UserControl
    {
        private static MainForm? _main;
        private static ApplicationDbContext _contex;
        public static ProductTransferRepository? productTransferRepository;
        private static StoreTransfertReportUserControl? _storeTransfertReportUserControl;
        public StoreTransfertReportUserControl()
        {
            InitializeComponent();
        }
        public static bool CheckInstance()
        {
            return (_storeTransfertReportUserControl == null);
        }
        public static StoreTransfertReportUserControl Instance(MainForm main)
        {
            _main = main;
            // If the instance is null, create a new one and assign it to the static field
            _contex = new ApplicationDbContext();
            if (CheckInstance())
            {
                productTransferRepository = new ProductTransferRepository(_contex);

                _storeTransfertReportUserControl = new StoreTransfertReportUserControl();

            }

            // Return the singleton instance
            _storeTransfertReportUserControl.LoadData();
            return _storeTransfertReportUserControl;
        }
        public async void SetProductsToDgv(string t1, string t2, string barcode)
        {
            ////DgvSales.DataSource = await Task.Run(() => productsRepository.GetAll(p => p.Category));
            //var CustomerMoneyList = MainForm.Context.CustomersReports.
            //    Include(x => x.Customer).Include(x => x.Sale)
            //    .ToList();
            var data = productTransferRepository.GetAllTransfert(t1, t2, barcode);
            DgvSales.DataSource = data;



        }
        void RefreshDgv()
        {
            string t1 = string.Empty;
            string t2 = string.Empty;
            if (rbStoresFrom.Checked) t1 = cmbStoresFrom.Text;

            if (rbStoresTo.Checked) t2 = cmbStoresTo.Text;

            SetProductsToDgv(t1, t2, txtSearch.Text);
            SetColumns();
            lblEmptyData.Visible = dgvHelper.IsEmpty(DgvSales);
        }
        public async void LoadData()
        {


            //ShowLoading
            LoadingForm.Instance(_main).Show();
            if (await Task.Run(() => productTransferRepository.IsConnected()))
            {
                //Start Load Data
                cmbStoresFrom.DataSource = _contex.Stores.ToList();
                cmbStoresFrom.DisplayMember = "StoreName";
                cmbStoresFrom.ValueMember = "Id";

                cmbStoresTo.DataSource = _contex.Stores.ToList();
                cmbStoresTo.DisplayMember = "StoreName";
                cmbStoresTo.ValueMember = "Id";
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



            DgvSales.Columns[0].HeaderCell.Value = "معرف المنتج";
            DgvSales.Columns[1].HeaderCell.Value = "اسم المنتج";
            DgvSales.Columns[2].HeaderCell.Value = "المخزن المحول منه";
            DgvSales.Columns[3].HeaderCell.Value = "المخزن المحول له";
            DgvSales.Columns[4].HeaderCell.Value = "الكمية";
            DgvSales.Columns[5].HeaderCell.Value = "سعر الشراء";
            DgvSales.Columns[6].HeaderCell.Value = "سعر البيع";
            DgvSales.Columns[7].HeaderCell.Value = "تاريخ التحويل";
            DgvSales.Columns[8].HeaderCell.Value = "المسؤول عن التحويل";
            DgvSales.Columns[9].HeaderCell.Value = "السبب";
            DgvSales.Columns[10].HeaderCell.Value = "";
            DgvSales.Columns[11].HeaderCell.Value = "معرف العملية";



            DgvSales.Columns[4].Width = 50;


            DgvSales.Columns[10].Visible = false;
            //DgvSales.Columns[7].Visible = false;
            //DgvSales.Columns[4].Visible = false;



        }

        private void rbStoresFrom_CheckedChanged(object sender, EventArgs e)
        {
            cmbStoresFrom.Enabled = true;
            RefreshDgv();
        }

        private void rbStoresTo_CheckedChanged(object sender, EventArgs e)
        {
            cmbStoresTo.Enabled = true;
            RefreshDgv();
        }

        private void rbStoresFromAll_CheckedChanged(object sender, EventArgs e)
        {
            cmbStoresFrom.Enabled = false;
            RefreshDgv();
        }

        private void rbAllStoresTo_CheckedChanged(object sender, EventArgs e)
        {
            cmbStoresTo.Enabled = false;
            RefreshDgv();
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
                        var deleteedRefund = _contex.ProductsTransfers.Where(x => x.Id == Convert.ToInt32(DgvSales.Rows[i].Cells[11].Value.ToString())).FirstOrDefault();
                        if (deleteedRefund != null)
                        {
                            _contex.Remove(deleteedRefund);
                            _contex.SaveChanges();
                        }
                    }
                    Code.Helper.ToasterHelper.ShowDeletedToast();

                }
                DgvSales.DataSource = null;
                RefreshDgv();
            }
            catch (Exception)
            {

                throw;
            }
        }
    }
}
