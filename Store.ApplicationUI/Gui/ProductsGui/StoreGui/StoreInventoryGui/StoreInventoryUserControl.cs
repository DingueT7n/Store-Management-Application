using Store.ApplicationUI.Code.Helper;
using Store.ApplicationUI.Gui.LoadingGui;
using Store.ApplicationUI.Gui.ProductsGui.StoreGui.StoreDeleteDamagedProductGui;
using Store.ApplicationUI.Gui.ProductsGui.StoreGui.TransferBetweenStoresGui;
using Store.Infrastructure.Data;
using Store.Infrastructure.Repositories;

namespace Store.ApplicationUI.Gui.ProductsGui.StoreGui.StoreInventoryGui
{
    public partial class StoreInventoryUserControl : UserControl
    {
        private static MainForm? _main;
        private static ApplicationDbContext _contex;
        private static StoreTransfertForm storeTransfertForm;
        private static StoreDamagedProductForm storeDamagedProductForm;
        public static ProductsQuantitieRepository? productQtyRepository;
        private static StoreInventoryUserControl? _storeInventoryUserControl;

        public StoreInventoryUserControl()
        {
            InitializeComponent();
        }
        public static bool CheckInstance()
        {
            return (_storeInventoryUserControl == null);
        }
        public static StoreInventoryUserControl Instance(MainForm main)
        {
            _main = main;
            _contex = new ApplicationDbContext();
            // If the instance is null, create a new one and assign it to the static field
            if (CheckInstance())
            {
                productQtyRepository = new ProductsQuantitieRepository(_contex);

                _storeInventoryUserControl = new StoreInventoryUserControl();

            }

            // Return the singleton instance
            _storeInventoryUserControl.LoadData();
            return _storeInventoryUserControl;
        }
        public async void SetProductsToDgv(int type)
        {
            ////DgvSales.DataSource = await Task.Run(() => productsRepository.GetAll(p => p.Category));
            //var CustomerMoneyList = MainForm.Context.CustomersReports.
            //    Include(x => x.Customer).Include(x => x.Sale)
            //    .ToList();
            string searchitem = txtSearch.Text == string.Empty ? "" : txtSearch.Text;
            if (type == 0)
            {
                var data = productQtyRepository.GetAllProductQty(searchitem);
                DgvSales.DataSource = data.result;
            }
            else
            {
                var data = productQtyRepository.GetProductQty(Convert.ToInt32(cmbStores.SelectedValue), searchitem);
                DgvSales.DataSource = data.result;
            }



        }
        void RefreshDgv()
        {
            if (rbStoreAll.Checked)
            {
                SetProductsToDgv(0);
            }
            else if (rbSelectedStore.Checked)
            {
                SetProductsToDgv(1);
            }

            lblEmptyData.Visible = dgvHelper.IsEmpty(DgvSales);
        }
        public async void LoadData()
        {


            //ShowLoading
            LoadingForm.Instance(_main).Show();
            if (await Task.Run(() => productQtyRepository.IsConnected()))
            {
                //Start Load Data

                // if its an admin or Normal user 
                cmbStores.DataSource = _contex.Stores.ToList();
                cmbStores.DisplayMember = "StoreName";
                cmbStores.ValueMember = "Id";
                RefreshDgv();
                SetColumns();

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
            DgvSales.Columns[2].HeaderCell.Value = "اسم المخزن الموجود فيه";
            DgvSales.Columns[3].HeaderCell.Value = "الكمية";
            DgvSales.Columns[4].HeaderCell.Value = "سعر الشراء";
            DgvSales.Columns[5].HeaderCell.Value = "سعر البيع باحتساب الضريبة";
            DgvSales.Columns[6].HeaderCell.Value = "تاريخ انتهاء الصلاحية";
            DgvSales.Columns[7].HeaderCell.Value = "باركود المنتج";
            //DgvSales.Columns[8].HeaderCell.Value = "الكمية";
            //DgvSales.Columns[9].HeaderCell.Value = "سعر المنتج";
            //DgvSales.Columns[10].HeaderCell.Value = "السعر الاجمالي";
            //DgvSales.Columns[11].HeaderCell.Value = "قيمة الضريبة";
            //DgvSales.Columns[12].HeaderCell.Value = "السعر مع الضريبة";
            //DgvSales.Columns[13].HeaderCell.Value = "حسبة الفاتورة";
            //DgvSales.Columns[14].HeaderCell.Value = "المدفوع";
            //DgvSales.Columns[15].HeaderCell.Value = "الباقي";

            //if (type == 1)
            //{
            //    DgvSales.Columns[3].Visible = false;
            //    DgvSales.Columns[2].Visible = true;
            //}
            //else if (type == 2)
            //{
            //    DgvSales.Columns[2].Visible = false;
            //    DgvSales.Columns[3].Visible = true;
            //}
            //else
            //{
            //    DgvSales.Columns[2].Visible = true;
            //    DgvSales.Columns[3].Visible = true;
            //}
            //DgvSales.Columns[8].Width = 50;
            //DgvSales.Columns[12].Visible = false;

            //DgvSales.Columns[6].Visible = false;
            //DgvSales.Columns[7].Visible = false;
            //DgvSales.Columns[4].Visible = false;



        }

        private void rbSelectedStore_CheckedChanged(object sender, EventArgs e)
        {
            cmbStores.Enabled = true;
        }

        private void rbStoreAll_CheckedChanged(object sender, EventArgs e)
        {
            cmbStores.Enabled = false;

        }

        private void cmbStores_SelectionChangeCommitted(object sender, EventArgs e)
        {
            RefreshDgv();
        }

        private void btnSearch_Click(object sender, EventArgs e)
        {
            RefreshDgv();
        }

        private void button2_Click(object sender, EventArgs e)
        {
            ToasterHelper.PlayNotificationSound();
            if (storeTransfertForm == null || storeTransfertForm.IsDisposed)
            {
                storeTransfertForm = StoreTransfertForm.Instance(_main);
                storeTransfertForm.Show();
            }
            else
            {
                storeTransfertForm.Focus();
            }
        }

        private void button1_Click(object sender, EventArgs e)
        {
            ToasterHelper.PlayNotificationSound();
            if (storeDamagedProductForm == null || storeDamagedProductForm.IsDisposed)
            {
                storeDamagedProductForm = StoreDamagedProductForm.Instance(_main);
                storeDamagedProductForm.Show();
            }
            else
            {
                storeDamagedProductForm.Focus();
            }
        }
    }
}
