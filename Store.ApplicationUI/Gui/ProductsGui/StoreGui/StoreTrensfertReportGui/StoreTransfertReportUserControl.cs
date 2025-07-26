using Microsoft.EntityFrameworkCore;
using Store.ApplicationUI.Code.Helper;
using Store.ApplicationUI.Gui.LoadingGui;
using Store.Core.Entities.Products;
using Store.Core.Interfaces;
using Store.Infrastructure.Data;

namespace Store.ApplicationUI.Gui.ProductsGui.StoreGui.StoreTrensfertReportGui
{
    public partial class StoreTransfertReportUserControl : UserControl
    {


        private readonly MainForm _main;
        private readonly ApplicationDbContext _context;
        private readonly IProductTransferRepository _repository;

        public StoreTransfertReportUserControl(MainForm main, ApplicationDbContext context, IProductTransferRepository repository)
        {
            InitializeComponent();
            _main = main;
            _context = context;

            _repository = repository;
        }
        public async void SetProductsToDgv(string t1, string t2, string barcode)
        {
            ////DgvSales.DataSource = await Task.Run(() => productsRepository.GetAll(p => p.Category));
            //var CustomerMoneyList = MainForm.Context.CustomersReports.
            //    Include(x => x.Customer).Include(x => x.Sale)
            //    .ToList();
            DgvSales.DataSource = new List<ProductTransfer>();
            var data = await _repository.GetAllTransfert(t1, t2, barcode);
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
            if (await _repository.IsConnectedAsync())
            {
                //Start Load Data
                cmbStoresFrom.DataSource = await _context.Stores.ToListAsync();
                cmbStoresFrom.DisplayMember = "StoreName";
                cmbStoresFrom.ValueMember = "Id";

                cmbStoresTo.DataSource = await _context.Stores.ToListAsync();
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
            txtSearch.Text = txtSearch.Text.Replace("\r\n", "");
            RefreshDgv();
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
                        var deleteedRefund = await _context.ProductsTransfers.Where(x => x.Id == Convert.ToInt32(DgvSales.Rows[i].Cells[11].Value.ToString())).FirstOrDefaultAsync();
                        if (deleteedRefund != null)
                        {
                            _context.Remove(deleteedRefund);
                            await _context.SaveChangesAsync();
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

        private void txtSearch_KeyDown(object sender, KeyEventArgs e)
        {
            if (e.KeyCode == Keys.Enter)
            {
                btnSearch_Click(sender, e);
            }
        }

        private void StoreTransfertReportUserControl_Load(object sender, EventArgs e)
        {
            LoadData();

        }
    }
}
