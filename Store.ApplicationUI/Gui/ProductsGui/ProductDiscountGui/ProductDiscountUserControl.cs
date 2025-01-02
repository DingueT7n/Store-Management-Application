using Store.ApplicationUI.Code.Helper;
using Store.ApplicationUI.Gui.LoadingGui;
using Store.Infrastructure.Data;
using Store.Infrastructure.Repositories;

namespace Store.ApplicationUI.Gui.ProductsGui.ProductDiscountGui
{
    public partial class ProductDiscountUserControl : UserControl
    {
        private static MainForm? _main;
        private static ApplicationDbContext _contex;
        private static AddProductDiscountForm _Form;
        public static ProductDiscountRepository? _Repository;


        private static ProductDiscountUserControl? _UserControl;

        public ProductDiscountUserControl()
        {
            InitializeComponent();
        }
        public static bool CheckInstance()
        {
            return _UserControl == null;
        }
        public static bool RefreshInstance()
        {
            if (_UserControl == null)
                return _UserControl == null;
            else
            {
                _UserControl.LoadData();
                return _UserControl == null;

            }

        }
        public static ProductDiscountUserControl Instance(MainForm main)
        {
            _main = main;
            _contex = new ApplicationDbContext();
            // If the instance is null, create a new one and assign it to the static field
            if (CheckInstance())
            {
                _Repository = new ProductDiscountRepository(_contex);
                _UserControl = new ProductDiscountUserControl();

            }

            // Return the singleton instance
            _UserControl.LoadData();
            return _UserControl;
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
                var data = _Repository.GetAllData(dtpFrom.Value, dtpTo.Value, searchitem, cmbStores.Text);
                DgvSales.DataSource = data;
            }
            else
            {
                var data = _Repository.GetAllData(dtpFrom.Value, dtpTo.Value, searchitem, "");
                DgvSales.DataSource = data;
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
            SetColumns();
            lblEmptyData.Visible = dgvHelper.IsEmpty(DgvSales);
        }
        public async void LoadData()
        {


            //ShowLoading
            LoadingForm.Instance(_main).Show();
            if (await Task.Run(() => _Repository.IsConnected()))
            {
                //Start Load Data

                // if its an admin or Normal user 
                cmbStores.DataSource = _contex.Stores.ToList();
                cmbStores.DisplayMember = "StoreName";
                cmbStores.ValueMember = "Id";
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
            dtpTo.Value = DateTime.Now;
            LoadingForm.Instance(_main).Hide();
            // Show EmptyDAta
            lblEmptyData.Visible = dgvHelper.IsEmpty(DgvSales);
        }

        private void SetColumns()
        {
            //DgvSales.Columns[0].HeaderCell.Value = "المعرف"; ""    



            DgvSales.Columns[0].HeaderCell.Value = "معرف المنتج";
            DgvSales.Columns[1].HeaderCell.Value = "معرف المخزن";
            DgvSales.Columns[2].HeaderCell.Value = "سعر التخفيض";
            DgvSales.Columns[3].HeaderCell.Value = "الكمية";
            DgvSales.Columns[4].HeaderCell.Value = "تاريخ بدأ التخفيض";
            DgvSales.Columns[5].HeaderCell.Value = "وقت بدأ التخفيض";
            DgvSales.Columns[6].HeaderCell.Value = "تاريخ انتهاء التخفيض";
            DgvSales.Columns[7].HeaderCell.Value = "وقت انتهاء التخفيض";
            DgvSales.Columns[8].HeaderCell.Value = "اسم المنتج";
            DgvSales.Columns[9].HeaderCell.Value = "اسم المخزن";
            DgvSales.Columns[10].HeaderCell.Value = "معرف العملية";
            //DgvSales.Columns[8].HeaderCell.Value = "الكمية";


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
            DgvSales.Columns[0].Width = 105;
            DgvSales.Columns[1].Width = 105;
            DgvSales.Columns[10].Width = 105;
            //DgvSales.Columns[12].Visible = false;

            //DgvSales.Columns[6].Visible = false;
            //DgvSales.Columns[7].Visible = false;
            //DgvSales.Columns[4].Visible = false;



        }

        private void btnAddDiscount_Click(object sender, EventArgs e)
        {
            if (_Form == null || _Form.IsDisposed)
            {
                _Form = AddProductDiscountForm.Instance(_main);
                _Form.Show();
            }
            else
            {
                _Form.Focus();
            }
        }

        private void rbSelectedStore_CheckedChanged(object sender, EventArgs e)
        {
            cmbStores.Enabled = rbSelectedStore.Checked;
            RefreshDgv();
        }

        private void rbStoreAll_CheckedChanged(object sender, EventArgs e)
        {
            cmbStores.Enabled = rbSelectedStore.Checked;
            RefreshDgv();

        }

        private void btnSearch_Click(object sender, EventArgs e)
        {
            RefreshDgv();
        }

        private void button1_Click(object sender, EventArgs e)
        {
            try
            {
                if (MsgHelper.ShowDeleteDialog())
                {
                    _contex = new ApplicationDbContext();
                    var deleteedRefund = _contex.ProductDiscounts.Where(x => x.Id ==
                    Convert.ToInt32(DgvSales.CurrentRow.Cells[10].Value.ToString())).FirstOrDefault();
                    if (deleteedRefund != null)
                    {
                        _contex.Remove(deleteedRefund);
                        _contex.SaveChanges();
                        Code.Helper.ToasterHelper.ShowDeletedToast();

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
