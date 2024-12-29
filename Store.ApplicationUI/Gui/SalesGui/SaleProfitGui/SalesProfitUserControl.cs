using System.Data;
using System.Globalization;
using Microsoft.EntityFrameworkCore;
using Store.ApplicationUI.Code.Helper;
using Store.ApplicationUI.Gui.LoadingGui;
using Store.Core.Entities.Sales;
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
            _context = new ApplicationDbContext();
            if (CheckInstance())
            {
                SaleProfitRepository = new(_context);

                _salesProfitUserControl = new SalesProfitUserControl();
                _salesProfitUserControl.dtpTo.Value = DateTime.Now;

            }

            // Return the singleton instance
            _salesProfitUserControl.LoadData();
            return _salesProfitUserControl;
        }
        public async void SetProductsToDgv(int skip)
        {
            ////DgvSalesProfit.DataSource = await Task.Run(() => productsRepository.GetAll(p => p.Category));
            //var CustomerMoneyList = MainForm.Context.CustomersReports.
            //    Include(x => x.Customer).Include(x => x.Sale)
            //    .ToList();
            var saleProfitDtoReturned = SaleProfitRepository.GetAllProfit(Properties.Settings.Default.NoOfDataInDgvs, skip);

            DgvSalesProfit.DataSource = saleProfitDtoReturned.Result;

            double value = saleProfitDtoReturned.Count / Convert.ToDouble(Properties.Settings.Default.NoOfDataInDgvs);
            int PageValue = Convert.ToInt32(Math.Round(value, MidpointRounding.AwayFromZero));
            cmbpagination.Items.Clear();
            for (int i = 0; i < PageValue; i++)
            {
                cmbpagination.Items.Add(i + 1);

            }
            if (cmbpagination.Items.Count > 0)
            {
                cmbpagination.SelectedIndex = 0;
            }
            PaginationHide();
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

                SetProductsToDgv(0);
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
            try
            {


                int take = Properties.Settings.Default.NoOfDataInDgvs;
                int selectedi = cmbpagination.SelectedIndex;
                if (selectedi == -1)
                {
                    selectedi = 0;

                }
                int skip = selectedi * take;
                SaleProfitDtoReturned a = new SaleProfitDtoReturned();
                DgvSalesProfit.DataSource = new List<SaleProfitDto>();
                if (rbBoth.Checked)
                {
                    a = SaleProfitRepository.SearchBoth(txtSearch.Text, dtpFrom.Value, dtpTo.Value, take, skip);


                }
                else if (rbCustomerAndOrder.Checked)
                {
                    a = SaleProfitRepository.SearchOnlyNames(txtSearch.Text, take, skip);

                }
                else
                {
                    a = SaleProfitRepository.SearchSalesByDate(dtpFrom.Value, dtpTo.Value, take, skip);

                }

                DgvSalesProfit.DataSource = a.Result;

                PaginationHide();
                lblEmptyData.Visible = dgvHelper.IsEmpty(DgvSalesProfit);
                int totalRecords = a.Count;
                int pageValue = (int)Math.Ceiling((double)totalRecords / take);
                cmbpagination.Items.Clear();

                for (int i = 0; i < pageValue; i++)
                {
                    cmbpagination.Items.Add(i + 1);
                }
                if (selectedi < cmbpagination.Items.Count && cmbpagination.Items.Count > 0)
                {
                    cmbpagination.SelectedIndex = selectedi;

                }
                CalculateStatistics();


            }
            catch (Exception)
            {

                throw;
            }
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
        void PaginationHide()
        {
            btnNext.Enabled = cmbpagination.SelectedIndex < cmbpagination.Items.Count - 1 && !dgvHelper.IsEmpty(DgvSalesProfit);
            btnPrev.Enabled = cmbpagination.SelectedIndex > 0 && !dgvHelper.IsEmpty(DgvSalesProfit);
            cmbpagination.Enabled = !dgvHelper.IsEmpty(DgvSalesProfit);
        }
        private void DgvSalesProfit_RowsAdded(object sender, DataGridViewRowsAddedEventArgs e)
        {


        }

        private void DgvSalesProfit_RowsRemoved(object sender, DataGridViewRowsRemovedEventArgs e)
        {

        }

        private void btnNext_Click(object sender, EventArgs e)
        {
            if (cmbpagination.SelectedIndex == -1)
            {
                cmbpagination.SelectedIndex = 0;  // Set to first page if no page is selected
            }

            if (cmbpagination.SelectedIndex < cmbpagination.Items.Count - 1)
            {
                cmbpagination.SelectedIndex += 1;
                btnSearch_Click(sender, e);
            }
        }

        private void btnPrev_Click(object sender, EventArgs e)
        {
            if (cmbpagination.SelectedIndex == -1)
            {
                cmbpagination.SelectedIndex = 0;
            }

            if (cmbpagination.SelectedIndex > 0)
            {
                cmbpagination.SelectedIndex -= 1;
                btnSearch_Click(sender, e);
            }
        }

        private void cmbpagination_SelectionChangeCommitted(object sender, EventArgs e)
        {
            if (cmbpagination.SelectedIndex == -1)
            {
                cmbpagination.SelectedIndex = 0;
            }
            //else if (cmbpagination.Items.Count == 1)
            //{
            //    return;
            //}
            else
            {

                btnSearch_Click(sender, e);
            }
        }

        private async void btnDeleteCurrentPage_Click(object sender, EventArgs e)
        {
            if (MsgHelper.ShowDeleteDialog())
            {
                for (int i = 0; i < DgvSalesProfit.Rows.Count; i++)
                {
                    SaleProfit saleProfit = _context.SalesProfits.FirstOrDefault(x => x.Order_ID.ToString() == DgvSalesProfit.Rows[i].Cells[0].Value.ToString());
                    _context.SalesProfits.Remove(saleProfit);
                    await _context.SaveChangesAsync();
                }
                LoadData();

            }
        }

        private async void btnDeleteReportsInPeriod_Click(object sender, EventArgs e)
        {
            if (MsgHelper.ShowDeleteDialog())
            {
                try
                {
                    var query = _context.SalesProfits
                        .Where(x => dtpFrom.Value <= x.Sale.Date && x.Sale.Date <= dtpTo.Value)
                        .ToList();

                    if (query.Any())
                    {
                        _context.SalesProfits.RemoveRange(query);
                        await _context.SaveChangesAsync();
                    }
                    else
                    {

                        MessageBox.Show("لا توجد بيانات في الفترة المحددة", "معلومة", MessageBoxButtons.OK, MessageBoxIcon.Information);
                    }
                    LoadData();
                }
                catch (Exception ex)
                {
                    // Handle or log the exception
                    MessageBox.Show($"لقد حدث خطأ : {ex.Message}", "خطأ برمجي", MessageBoxButtons.OK, MessageBoxIcon.Error);
                }
            }
        }

        private void btnDeleteAllReports_Click(object sender, EventArgs e)
        {
            if (MsgHelper.ShowDeleteDialog())
            {
                try
                {
                    _context.Database.ExecuteSqlRaw($"DELETE FROM [SalesProfits]");
                    LoadData();
                }
                catch (Exception ex)
                {
                    // Handle or log the exception
                    MessageBox.Show($"لقد حدث خطأ : {ex.Message}", "خطأ برمجي", MessageBoxButtons.OK, MessageBoxIcon.Error);
                }
            }
        }

        private async void btnExportCustomer_Click(object sender, EventArgs e)
        {
            try
            {
                if (DgvSalesProfit.SelectedRows.Count > 0)
                {
                    DataTable ProfitDetailsTable = await FactureHelper.GetProfitReportDataTableAsync(dtpFrom.Value, dtpTo.Value);
                    Reports.SalesReports.salesProfit saleReportsInPeriod = new();
                    saleReportsInPeriod.DataSource = ProfitDetailsTable;
                    saleReportsInPeriod.lbldateFrom.Text = dtpFrom.Value.ToString("yyyy-MM-dd", CultureInfo.InvariantCulture);
                    saleReportsInPeriod.lblDateTo.Text = dtpTo.Value.ToString("yyyy-MM-dd", CultureInfo.InvariantCulture);
                    Reports.ReportPerviwGui.XtraForm1 xtraForm1 = new(saleReportsInPeriod);
                    xtraForm1.ShowDialog();
                }
            }
            catch (Exception)
            {

                throw;
            }
        }
        private async void button2_Click(object sender, EventArgs e)
        {
            try
            {
                if (DgvSalesProfit.SelectedRows.Count > 0)
                {
                    DataTable ProfitDetailsTable = await FactureHelper.GetSellDetailsDataTableAsync(Convert.ToInt32(DgvSalesProfit.CurrentRow.Cells[0].Value.ToString()));
                    Reports.SalesReports.salesA4 salesA4 = new();
                    salesA4.DataSource = ProfitDetailsTable;
                    Reports.ReportPerviwGui.XtraForm1 xtraForm1 = new(salesA4);
                    xtraForm1.ShowDialog();
                }
            }
            catch (Exception)
            {

                throw;
            }
        }
    }
}
