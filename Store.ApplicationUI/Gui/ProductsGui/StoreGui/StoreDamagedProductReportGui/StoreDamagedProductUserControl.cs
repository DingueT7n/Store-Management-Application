using Microsoft.EntityFrameworkCore;
using Store.ApplicationUI.Code.Helper;
using Store.ApplicationUI.Gui.LoadingGui;
using Store.Core.Entities.Products;
using Store.Core.Interfaces;
using Store.Infrastructure.Data;

namespace Store.ApplicationUI.Gui.ProductsGui.StoreGui.StoreDamagedProductReportGui
{
    public partial class StoreDamagedProductUserControl : UserControl
    {


        public readonly IProductOutStoreRepository productOutStoreRepository;
        private readonly MainForm _main;
        private readonly ApplicationDbContext _context;

        public StoreDamagedProductUserControl(IProductOutStoreRepository productOutStoreRepository, MainForm mainForm, ApplicationDbContext applicationDbContext)
        {
            InitializeComponent();
            this.productOutStoreRepository = productOutStoreRepository;
            _main = mainForm;
            _context = applicationDbContext;
        }
        public async void SetProductsToDgv(string t1, string barcode)
        {
            ////DgvSales.DataSource = await Task.Run(() => productsRepository.GetAll(p => p.Category));
            //var CustomerMoneyList = MainForm.Context.CustomersReports.
            //    Include(x => x.Customer).Include(x => x.Sale)
            //    .ToList();
            var data = await productOutStoreRepository.GetAllOutStore(t1, barcode, dtpFrom.Value, dtpTo.Value);
            DgvSales.DataSource = data;



        }
        void RefreshDgv()
        {
            SetColumns();
            string t1 = string.Empty;

            if (rbStoresFrom.Checked) t1 = cmbStoresFrom.Text;



            SetProductsToDgv(t1, txtSearch.Text);
            lblEmptyData.Visible = dgvHelper.IsEmpty(DgvSales);
        }
        public async Task LoadData()
        {
            dtpTo.Value = DateTime.Now;

            //ShowLoading
            LoadingForm.Instance(_main).Show();
            if (await productOutStoreRepository.IsConnectedAsync())
            {
                //Start Load Data
                cmbStoresFrom.DataSource = await _context.Stores.ToListAsync();
                cmbStoresFrom.DisplayMember = "StoreName";
                cmbStoresFrom.ValueMember = "Id";


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

            DgvSales.DataSource = new List<ProductOutStore>();

            DgvSales.Columns[0].HeaderCell.Value = "معرف المنتج";
            DgvSales.Columns[1].HeaderCell.Value = "اسم المنتج";
            DgvSales.Columns[2].HeaderCell.Value = "المخزن المخرج منه";
            DgvSales.Columns[3].HeaderCell.Value = "الكمية";
            DgvSales.Columns[4].HeaderCell.Value = "تاريخ الاخراج";
            DgvSales.Columns[5].HeaderCell.Value = "وقت الاخراج";
            DgvSales.Columns[6].HeaderCell.Value = "المسؤول عن الاخراج";
            DgvSales.Columns[7].HeaderCell.Value = "السبب";
            DgvSales.Columns[8].HeaderCell.Value = "";
            DgvSales.Columns[9].HeaderCell.Value = "معرف العملية";





            DgvSales.Columns[8].Visible = false;
            //DgvSales.Columns[7].Visible = false;
            //DgvSales.Columns[4].Visible = false;



        }

        private async void button2_Click(object sender, EventArgs e)
        {
            try
            {
                ToasterHelper.PlayNotificationSound();
                if (MsgHelper.ShowDeleteDialog())
                {
                    for (int i = 0; i <= DgvSales.Rows.Count - 1; i++)
                    {
                        var deleteedRefund = await _context.ProductsOutStore.Where(x => x.Id == Convert.ToInt32(DgvSales.Rows[i].Cells[9].Value.ToString())).FirstOrDefaultAsync();
                        if (deleteedRefund != null)
                        {
                            _context.Remove(deleteedRefund);
                            await _context.SaveChangesAsync();
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

        private void rbStoresFrom_CheckedChanged(object sender, EventArgs e)
        {
            cmbStoresFrom.Enabled = true;
            RefreshDgv();
        }

        private void rbStoresFromAll_CheckedChanged(object sender, EventArgs e)
        {
            cmbStoresFrom.Enabled = false;
            RefreshDgv();
        }

        private void btnSearch_Click(object sender, EventArgs e)
        {
            txtSearch.Text = txtSearch.Text.Replace("\r\n", "").Trim();
            RefreshDgv();
        }

        private void cmbStoresFrom_SelectionChangeCommitted(object sender, EventArgs e)
        {
            RefreshDgv();
        }

        private void txtSearch_KeyDown(object sender, KeyEventArgs e)
        {
            if (e.KeyCode == Keys.Enter)
            {
                btnSearch_Click(sender, e);
            }
        }

        private void StoreDamagedProductUserControl_Load(object sender, EventArgs e)
        {

        }
    }
}
