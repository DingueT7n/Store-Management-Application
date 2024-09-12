using Store.ApplicationUI.Code.Helper;
using Store.ApplicationUI.Gui.LoadingGui;
using Store.Infrastructure.Data;
using Store.Infrastructure.Repositories;

namespace Store.ApplicationUI.Gui.SalesGui.SaleProfitGui
{
    public partial class SalesProfitUserControl : UserControl
    {
        private static MainForm? _main;
        private static ApplicationDbContext _context;
        public static SaleProfitRepository? SaleProfitRepository;
        private static SalesProfitUserControl? _salesProfitUserControl;
        public SalesProfitUserControl()
        {
            InitializeComponent();

        }
        public static bool CheckInstance()
        {
            return (_salesProfitUserControl == null);
        }
        public static SalesProfitUserControl Instance(MainForm main)
        {
            _main = main;
            // If the instance is null, create a new one and assign it to the static field
            if (CheckInstance())
            {
                _context = new ApplicationDbContext();
                SaleProfitRepository = new(_context);

                _salesProfitUserControl = new SalesProfitUserControl();
                _salesProfitUserControl.dtpTo.Value = DateTime.Now;

            }

            // Return the singleton instance
            _salesProfitUserControl.LoadData();
            return _salesProfitUserControl;
        }
        public async void SetProductsToDgv()
        {
            ////DgvSalesProfit.DataSource = await Task.Run(() => productsRepository.GetAll(p => p.Category));
            //var CustomerMoneyList = MainForm.Context.CustomersReports.
            //    Include(x => x.Customer).Include(x => x.Sale)
            //    .ToList();
            DgvSalesProfit.DataSource = SaleProfitRepository.GetAllProfit();
            //var uniqueCustomerCount = CustomerMoneyList
            //    .Select(x => x.Customer.Id) // Replace CustomerId with the actual unique identifier property
            //    .Distinct()
            //    .Count();
            //DgvSalesProfit.DataSource = CustomerMoneyList;
            //if (DgvSalesProfit.Rows.Count > 0)
            //{
            //    if (DgvSalesProfit.SelectedRows.Count > 0)
            //    {
            //        //lblPayFacture.Text = $" فاتورة رقم {DgvSalesProfit.Columns[7].HeaderCell.Value} الدين : {DgvSalesProfit.Columns[1].HeaderCell.Value} دج";
            //        //lblPayAllDebts.Text = $"دج {CustomerMoneyList.Sum(x => x.Price)}";
            //        lblTotalDebt.Text = $"مجموع مدفوعات الموردين في الجدول:{CustomerMoneyList.Sum(x => x.Price)}";
            //        lblTotalCustomers.Text = $"مجموع الموردين:{uniqueCustomerCount}";

            //    }
            //}
        }

        public static void RefreshDgv()
        {
            //DgvSalesProfit.DataSource = await Task.Run(() => productsRepository.GetAllProducts());
            _salesProfitUserControl.LoadData();
        }
        // methodes 
        public async void LoadData()
        {


            //ShowLoading
            LoadingForm.Instance(_main).Show();
            if (await Task.Run(() => SaleProfitRepository.IsConnected()))
            {
                //Start Load Data

                // if its an admin or Normal user 

                SetProductsToDgv();
                SetColumns();
                //_data.Clear();
                CalculateStatistics();
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
            lblEmptyData.Visible = dgvHelper.IsEmpty(DgvSalesProfit);
        }

        private void SetColumns()
        {
            //DgvSalesProfit.Columns[0].HeaderCell.Value = "المعرف";



            DgvSalesProfit.Columns[0].HeaderCell.Value = "معرف الفاتورة";
            DgvSalesProfit.Columns[1].HeaderCell.Value = "معرف المنتج";
            DgvSalesProfit.Columns[2].HeaderCell.Value = "اسم المنتج";
            DgvSalesProfit.Columns[3].HeaderCell.Value = "اسم العميل";
            DgvSalesProfit.Columns[4].HeaderCell.Value = "قيمة الضريبة";
            DgvSalesProfit.Columns[5].HeaderCell.Value = "الكمية";
            DgvSalesProfit.Columns[6].HeaderCell.Value = "سعر البيع";
            DgvSalesProfit.Columns[7].HeaderCell.Value = "سعر الشراء";
            DgvSalesProfit.Columns[8].HeaderCell.Value = "التخفيض";
            DgvSalesProfit.Columns[9].HeaderCell.Value = "السعر الاجمالي";
            DgvSalesProfit.Columns[10].HeaderCell.Value = "قيمة الربح";
            DgvSalesProfit.Columns[11].HeaderCell.Value = "حسبة الفاتورة";
            DgvSalesProfit.Columns[12].HeaderCell.Value = "المدفوع";
            DgvSalesProfit.Columns[13].HeaderCell.Value = "الباقي";
            DgvSalesProfit.Columns[14].HeaderCell.Value = "الوقت";
            DgvSalesProfit.Columns[15].HeaderCell.Value = "تاريخ الفاتورة";
            DgvSalesProfit.Columns[16].HeaderCell.Value = "البائع";


            DgvSalesProfit.Columns[5].Width = 50;
            DgvSalesProfit.Columns[4].Width = 50;
            DgvSalesProfit.Columns[13].Width = 50;
            DgvSalesProfit.Columns[14].Width = 50;
            DgvSalesProfit.Columns[1].Visible = false;
            DgvSalesProfit.Columns[4].Visible = false;
            DgvSalesProfit.Columns[8].Visible = false;
            //DgvSalesProfit.Columns[7].Visible = false;
            //DgvSalesProfit.Columns[4].Visible = false;



        }

        private void btnSearch_Click(object sender, EventArgs e)
        {
            if (rbBoth.Checked)
            {
                DgvSalesProfit.DataSource = SaleProfitRepository.SearchBoth(txtSearch.Text, dtpFrom.Value, dtpTo.Value);
                lblEmptyData.Visible = dgvHelper.IsEmpty(DgvSalesProfit);

            }
            else if (rbCustomerAndOrder.Checked)
            {
                DgvSalesProfit.DataSource = SaleProfitRepository.SearchOnlyNames(txtSearch.Text);
                lblEmptyData.Visible = dgvHelper.IsEmpty(DgvSalesProfit);
            }
            else
            {
                DgvSalesProfit.DataSource = SaleProfitRepository.SearchSalesByDate(dtpFrom.Value, dtpTo.Value);
                lblEmptyData.Visible = dgvHelper.IsEmpty(DgvSalesProfit);
            }

            txtSearch.Text = string.Empty;
        }
        void CalculateStatistics()
        {
            try
            {

                lblEmptyData.Visible = dgvHelper.IsEmpty(DgvSalesProfit);
                if (DgvSalesProfit.Rows.Count > 0)
                {
                    // Calculate total buys
                    var totalBuy = DgvSalesProfit.Rows
                        .Cast<DataGridViewRow>()
                        .Where(row => !string.IsNullOrEmpty(row.Cells[7].FormattedValue.ToString()) &&
                                      !string.IsNullOrEmpty(row.Cells[5].FormattedValue.ToString()))
                        .Sum(row =>
                        {
                            decimal.TryParse(row.Cells[7].FormattedValue.ToString(), out decimal cell8);
                            decimal.TryParse(row.Cells[5].FormattedValue.ToString(), out decimal cell6);
                            return cell8 * cell6;
                        })
                        .ToString("f2");

                    // Calculate total income
                    var totalIncome = DgvSalesProfit.Rows
                        .Cast<DataGridViewRow>()
                        .Where(row => !string.IsNullOrEmpty(row.Cells[6].FormattedValue.ToString()) &&
                      !string.IsNullOrEmpty(row.Cells[5].FormattedValue.ToString())
                        )

                        .Sum(row =>
                        {
                            decimal.TryParse(row.Cells[6].FormattedValue.ToString(), out decimal cell7);
                            decimal.TryParse(row.Cells[5].FormattedValue.ToString(), out decimal cell6);
                            return cell7 * cell6;
                        })
                        .ToString("f2");

                    // Calculate total profit
                    var totalProfit = DgvSalesProfit.Rows
                        .Cast<DataGridViewRow>()
                        .Where(row => !string.IsNullOrEmpty(row.Cells[10].FormattedValue.ToString()))
                        .Sum(row =>
                        {
                            decimal.TryParse(row.Cells[10].FormattedValue.ToString(), out decimal cell11);
                            return cell11;
                        })
                        .ToString("f2");

                    // Set the labels with formatted values
                    lblTotalIncome.Text = $"مجموع المداخيل : {totalIncome}";
                    lblTotalProfit.Text = $"مجموع الارباح : {totalProfit}";
                    lblTotalBuys.Text = $"مجموع المشتريات : {totalBuy}";
                }

            }
            catch (Exception)
            {

                throw;
            }

        }
        private void DgvSalesProfit_RowsAdded(object sender, DataGridViewRowsAddedEventArgs e)
        {

            CalculateStatistics();
        }

        private void DgvSalesProfit_RowsRemoved(object sender, DataGridViewRowsRemovedEventArgs e)
        {

        }
    }
}
