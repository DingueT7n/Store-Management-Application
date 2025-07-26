using Microsoft.EntityFrameworkCore;
using Store.ApplicationUI.Code.Helper;
using Store.ApplicationUI.Code.System;
using Store.ApplicationUI.Gui.LoadingGui;
using Store.ApplicationUI.Gui.ProductsGui.StoreGui.StoreDeleteDamagedProductGui;
using Store.ApplicationUI.Gui.ProductsGui.StoreGui.TransferBetweenStoresGui;
using Store.Core.Entities.Products;
using Store.Core.Interfaces;
using Store.Infrastructure.Data;

namespace Store.ApplicationUI.Gui.ProductsGui.StoreGui.StoreInventoryGui
{
    public partial class StoreInventoryUserControl : UserControl
    {
        private readonly MainForm _main;
        private readonly ApplicationDbContext _context;
        private readonly ControlManager _controlManager;
        private readonly IProductsQuantitieRepository _productsQuantitieRepository;

        public StoreInventoryUserControl(MainForm main, ApplicationDbContext applicationDbContext,
            ControlManager controlManager, IProductsQuantitieRepository productsQuantitieRepository
            )
        {
            InitializeComponent();
            _main = main;
            _context = applicationDbContext;
            _controlManager = controlManager;
            _productsQuantitieRepository = productsQuantitieRepository;
        }
        void CalcStats()
        {
            try
            {

                lblEmptyData.Visible = dgvHelper.IsEmpty(DgvSales);
                if (DgvSales.Rows.Count > 0)
                {
                    // Calculate total buys
                    var totalBuy = DgvSales.Rows
                        .Cast<DataGridViewRow>()
                        .Where(row => !string.IsNullOrEmpty(row.Cells[4].FormattedValue.ToString()) &&
                                      !string.IsNullOrEmpty(row.Cells[3].FormattedValue.ToString()))
                        .Sum(row =>
                        {
                            decimal.TryParse(row.Cells[4].FormattedValue.ToString(), out decimal cell4);
                            decimal.TryParse(row.Cells[3].FormattedValue.ToString(), out decimal cell3);
                            return cell4 * cell3;
                        })
                        .ToString("f2");

                    // Calculate total income
                    var totalSales = DgvSales.Rows
                        .Cast<DataGridViewRow>()
                        .Where(row => !string.IsNullOrEmpty(row.Cells[5].FormattedValue.ToString()) &&
                      !string.IsNullOrEmpty(row.Cells[3].FormattedValue.ToString())
                        )

                        .Sum(row =>
                        {
                            decimal.TryParse(row.Cells[5].FormattedValue.ToString(), out decimal cell5);
                            decimal.TryParse(row.Cells[3].FormattedValue.ToString(), out decimal cell3);
                            return cell5 * cell3;
                        })
                        .ToString("f2");
                    var expectedSales = DgvSales.Rows
                       .Cast<DataGridViewRow>()
                       .Where(row => !string.IsNullOrEmpty(row.Cells[5].FormattedValue.ToString()) &&
                       !string.IsNullOrEmpty(row.Cells[4].FormattedValue.ToString()) &&
                     !string.IsNullOrEmpty(row.Cells[3].FormattedValue.ToString())
                       )

                       .Sum(row =>
                       {
                           decimal.TryParse(row.Cells[5].FormattedValue.ToString(), out decimal cell5);
                           decimal.TryParse(row.Cells[4].FormattedValue.ToString(), out decimal cell4);
                           decimal.TryParse(row.Cells[3].FormattedValue.ToString(), out decimal cell3);
                           return (cell5 - cell4) * cell3;
                       })
                       .ToString("f2");

                    // Calculate total profit
                    var totalQty = DgvSales.Rows
                        .Cast<DataGridViewRow>()
                        .Where(row => !string.IsNullOrEmpty(row.Cells[3].FormattedValue.ToString()))
                        .Sum(row =>
                        {
                            decimal.TryParse(row.Cells[3].FormattedValue.ToString(), out decimal cell3);
                            return cell3;
                        })
                        .ToString("f2");

                    // Calculate total profit
                    var totalProduct = DgvSales.Rows
                        .Cast<DataGridViewRow>()
                        .Where(row => !string.IsNullOrEmpty(row.Cells[0].FormattedValue.ToString()))
                        .Select(row =>
                        {
                            decimal.TryParse(row.Cells[0].FormattedValue.ToString(), out decimal cell0);
                            return cell0;
                        })
                        .Distinct()
                        .Count()
                        .ToString("f2");

                    // Set the labels with formatted values
                    lblBuys.Text = $"مجموع الشراء  : {totalBuy}";
                    lblSales.Text = $"مجموع البيع المتوقع : {totalSales}";
                    lblProfitExpected.Text = $"الأرباح المتوقعة : {expectedSales}";
                    lblQtyInTable.Text = $"الكميات في الجدول : {totalQty}";
                    lblProductInTables.Text = $"المنتجات في الجدول : {totalProduct}";
                }



                txtAllProducts.Text = _context.ProductsQuantities.Where(x => x.Qty > 0)
                    .Select(x => x.Pro_ID).Distinct().Count().ToString("f2");
                txtProductSum.Text = _context.Products.Count().ToString("f2");
                txtAllQty.Text = _context.ProductsQuantities.Sum(x => x.Qty).ToString("f2");
                txttotalBuy.Text = _context.ProductsQuantities.Sum(x => x.Buy_Price * x.Qty).ToString("f2");
                txttotalSell.Text = _context.ProductsQuantities.Sum(x => x.Sale_PriceTax * x.Qty).ToString("f2");
                txtTotalProfitExpected.Text = _context.ProductsQuantities
                    .Sum(x => (x.Sale_PriceTax - x.Buy_Price) * x.Qty).ToString("f2");
                txtCapital.Text = (Convert.ToDecimal(txttotalBuy.Text) + _context.Banks.Sum(x => x.Money) +
                    _context.Caisses.Sum(x => x.MoneyinCaisse)).ToString("f2");
            }
            catch (Exception ex)
            {

                ToasterHelper.ShowErrorHappened(ex.Message);
            }
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
                var data = await _productsQuantitieRepository.GetAllProductQty(searchitem);
                DgvSales.DataSource = data.result;
            }
            else
            {
                var data = await _productsQuantitieRepository.GetProductQty(Convert.ToInt32(cmbStores.SelectedValue), searchitem);
                DgvSales.DataSource = data.result;
            }

            CalcStats();

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
            if (await _context.Database.CanConnectAsync())
            {
                //Start Load Data

                SetColumns();
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

            LoadingForm.Instance(_main).Hide();
            // Show EmptyDAta
            lblEmptyData.Visible = dgvHelper.IsEmpty(DgvSales);
        }

        private void SetColumns()
        {
            //DgvSales.Columns[0].HeaderCell.Value = "المعرف"; ""    


            DgvSales.DataSource = new List<ProductQtyDto>();
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
            txtSearch.Text = txtSearch.Text.Replace("\r\n", "");
            RefreshDgv();
        }

        private void button2_Click(object sender, EventArgs e)
        {
            ToasterHelper.PlayNotificationSound();
            var form = _controlManager.GetF<StoreTransfertForm>();


            form.ShowDialog();

        }

        private void button1_Click(object sender, EventArgs e)
        {
            ToasterHelper.PlayNotificationSound();
            var form = _controlManager.GetF<StoreDamagedProductForm>();
            form.ShowDialog();

        }

        private void txtSearch_KeyDown(object sender, KeyEventArgs e)
        {
            if (e.KeyCode == Keys.Enter)
            {
                btnSearch_Click(sender, e);
            }
        }

        private void StoreInventoryUserControl_Load(object sender, EventArgs e)
        {
            LoadData();

        }
    }
}
