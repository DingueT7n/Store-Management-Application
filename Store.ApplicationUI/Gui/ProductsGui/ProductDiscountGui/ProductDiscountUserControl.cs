
using Microsoft.EntityFrameworkCore;
using Store.ApplicationUI.Code.Helper;
using Store.ApplicationUI.Code.System;
using Store.ApplicationUI.Gui.LoadingGui;
using Store.Core.Entities.Products;
using Store.Core.Interfaces;
using Store.Infrastructure.Data;

namespace Store.ApplicationUI.Gui.ProductsGui.ProductDiscountGui
{
    public partial class ProductDiscountUserControl : UserControl
    {
        private readonly MainForm _main;


        private readonly ApplicationDbContext _context;
        public readonly IProductDiscountRepository _Repository;
        private readonly ControlManager _controlManager;

        public ProductDiscountUserControl(MainForm main, IProductDiscountRepository productDiscountRepository, ControlManager controlManager, ApplicationDbContext context)
        {
            InitializeComponent();


            _main = main;
            _Repository = productDiscountRepository;
            _controlManager = controlManager;
            _context = context;
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
                var data = await _Repository.GetAllData(dtpFrom.Value, dtpTo.Value, searchitem, cmbStores.Text);
                DgvSales.DataSource = data;
            }
            else
            {
                var data = await _Repository.GetAllData(dtpFrom.Value, dtpTo.Value, searchitem, "");
                DgvSales.DataSource = data;
            }



        }
        void RefreshDgv()
        {
            SetColumns();
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
            if (await _Repository.IsConnectedAsync())
            {
                //Start Load Data

                // if its an admin or Normal user 
                cmbStores.DataSource = await _context.Stores.ToListAsync();
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

            DgvSales.DataSource = new List<ProductDiscount>();

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

            //_Form =_contr AddProductDiscountForm.Instance(_main);
            //_Form.ShowDialog();

            var form = _controlManager.GetF<AddProductDiscountForm>();
            form.ShowDialog();


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
            txtSearch.Text = txtSearch.Text.Replace("\r\n", "");
            RefreshDgv();
        }

        private async void button1_Click(object sender, EventArgs e)
        {
            try
            {
                if (DgvSales.Rows.Count > 0)
                {
                    if (MsgHelper.ShowDeleteDialog())
                    {

                        var deleteedRefund = await _context.ProductDiscounts.Where(x => x.Id ==
                        Convert.ToInt32(DgvSales.CurrentRow.Cells[10].Value.ToString())).FirstOrDefaultAsync();
                        if (deleteedRefund != null)
                        {
                            _context.Remove(deleteedRefund);
                            await _context.SaveChangesAsync();
                            Code.Helper.ToasterHelper.ShowDeletedToast();

                        }

                        DgvSales.DataSource = null;
                        RefreshDgv();
                    }
                }
            }
            catch (Exception ex)
            {
                ToasterHelper.ShowErrorHappened(ex.Message);
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
