using System.Data;
using Microsoft.EntityFrameworkCore;
using Store.ApplicationUI.Code.Helper;
using Store.ApplicationUI.Gui.LoadingGui;
using Store.Core.Entities.Sales;
using Store.Infrastructure.Data;
using Store.Infrastructure.Repositories;

namespace Store.ApplicationUI.Gui.SalesGui.SalesReportsGui
{
    public partial class SalesReportsUserControl : UserControl
    {
        private static MainForm? _main;
        private static ApplicationDbContext _contex;
        public static SalesRepository? salesRepository;
        private static SalesReportsUserControl? _salesReportsUserControl;
        public SalesReportsUserControl()
        {
            InitializeComponent();
        }
        public static bool CheckInstance()
        {
            return (_salesReportsUserControl == null);
        }
        public static SalesReportsUserControl Instance(MainForm main)
        {
            _main = main;
            // If the instance is null, create a new one and assign it to the static field
            _contex = new ApplicationDbContext();
            if (CheckInstance())
            {
                salesRepository = new SalesRepository(_contex);

                _salesReportsUserControl = new SalesReportsUserControl();

            }

            // Return the singleton instance
            _salesReportsUserControl.LoadData();
            return _salesReportsUserControl;
        }
        public async void SetProductsToDgv(int skip)
        {
            ////DgvSales.DataSource = await Task.Run(() => productsRepository.GetAll(p => p.Category));
            //var CustomerMoneyList = MainForm.Context.CustomersReports.
            //    Include(x => x.Customer).Include(x => x.Sale)
            //    .ToList();
            var data = salesRepository.GetAllSalesWithDetails(Properties.Settings.Default.NoOfDataInDgvs, skip);
            DgvSales.DataSource = data.result;
            double value = data.count / Convert.ToDouble(Properties.Settings.Default.NoOfDataInDgvs);
            int PageValue = Convert.ToInt32(Math.Round(value, MidpointRounding.AwayFromZero));
            cmbpagination.Items.Clear();
            for (int i = 0; i <= PageValue; i++)
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
            //DgvSales.DataSource = CustomerMoneyList;
            //if (DgvSales.Rows.Count > 0)
            //{
            //    if (DgvSales.SelectedRows.Count > 0)
            //    {
            //        //lblPayFacture.Text = $" فاتورة رقم {DgvSales.Columns[7].HeaderCell.Value} الدين : {DgvSales.Columns[1].HeaderCell.Value} دج";
            //        //lblPayAllDebts.Text = $"دج {CustomerMoneyList.Sum(x => x.Price)}";
            //        lblTotalDebt.Text = $"مجموع مدفوعات الموردين في الجدول:{CustomerMoneyList.Sum(x => x.Price)}";
            //        lblTotalCustomers.Text = $"مجموع الموردين:{uniqueCustomerCount}";

            //    }
            //}
        }

        public static void RefreshDgv()
        {
            //DgvSales.DataSource = await Task.Run(() => productsRepository.GetAllProducts());
            _salesReportsUserControl.LoadData();
        }
        // methodes 
        public async void LoadData()
        {

            dtpTo.Value = DateTime.Now;
            //ShowLoading
            LoadingForm.Instance(_main).Show();
            if (await Task.Run(() => salesRepository.IsConnected()))
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
            lblEmptyData.Visible = dgvHelper.IsEmpty(DgvSales);
        }

        private void SetColumns()
        {
            //DgvSales.Columns[0].HeaderCell.Value = "المعرف";



            DgvSales.Columns[0].HeaderCell.Value = "معرف الفاتورة";
            DgvSales.Columns[1].HeaderCell.Value = "اسم المورد";
            DgvSales.Columns[2].HeaderCell.Value = "التاريخ";
            DgvSales.Columns[3].HeaderCell.Value = "الوقت";
            DgvSales.Columns[4].HeaderCell.Value = "اسم المنتج";
            DgvSales.Columns[5].HeaderCell.Value = "الكمية";
            DgvSales.Columns[6].HeaderCell.Value = "سعر المنتج";
            DgvSales.Columns[7].HeaderCell.Value = "التخفيض";
            DgvSales.Columns[8].HeaderCell.Value = "السعر الاجمالي";
            DgvSales.Columns[9].HeaderCell.Value = "البائع";
            DgvSales.Columns[10].HeaderCell.Value = "حسبة الفاتورة";
            DgvSales.Columns[11].HeaderCell.Value = "المدفوع";
            DgvSales.Columns[12].HeaderCell.Value = "الباقي";


            DgvSales.Columns[3].Width = 50;
            //DgvSales.Columns[6].Visible = false;
            //DgvSales.Columns[7].Visible = false;
            //DgvSales.Columns[4].Visible = false;



        }

        private void btnSearch_Click(object sender, EventArgs e)
        {
            txtSearch.Text = txtSearch.Text.Replace("\r\n", "");

            int take = Properties.Settings.Default.NoOfDataInDgvs;
            int selectedi = cmbpagination.SelectedIndex;

            if (selectedi == -1)
            {
                selectedi = 0;

            }
            int skip = selectedi * take;
            ResultSaleDetailDto a = new ResultSaleDetailDto();
            DgvSales.DataSource = new List<SaleDetailDto>();
            if (rbBoth.Checked)
            {
                a = salesRepository.SearchBoth(txtSearch.Text, dtpFrom.Value, dtpTo.Value, take, skip);

            }
            else if (rbCustomerAndOrder.Checked)
            {
                a = salesRepository.SearchOnlySupplier(txtSearch.Text, take, skip);

            }
            else
            {
                a = salesRepository.SearchSalesByDate(dtpFrom.Value, dtpTo.Value, take, skip);

            }
            DgvSales.DataSource = a.result;

            lblEmptyData.Visible = dgvHelper.IsEmpty(DgvSales);
            int totalRecords = a.count;
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
            PaginationHide();

            CalculateStatistics();

        }

        private void cmbpagination_SelectedIndexChanged(object sender, EventArgs e)
        {
            //if (cmbpagination.SelectedIndex == -1)
            //{
            //    cmbpagination.SelectedIndex = 0;
            //}
            //else
            //{
            //    int skip = cmbpagination.SelectedIndex * Properties.Settings.Default.NoOfDataInDgvs;
            //    SetProductsToDgv(skip);
            //}
        }
        void PaginationHide()
        {
            btnNext.Enabled = cmbpagination.SelectedIndex < cmbpagination.Items.Count - 1 && !dgvHelper.IsEmpty(DgvSales);
            btnPrev.Enabled = cmbpagination.SelectedIndex > 0 && !dgvHelper.IsEmpty(DgvSales);
            cmbpagination.Enabled = !dgvHelper.IsEmpty(DgvSales);
        }
        private void btnNext_Click(object sender, EventArgs e)
        {

            ToasterHelper.PlayNotificationSound();
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
            ToasterHelper.PlayNotificationSound();
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
            ToasterHelper.PlayNotificationSound();
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
        void CalculateStatistics()
        {
            try
            {

                lblEmptyData.Visible = dgvHelper.IsEmpty(DgvSales);
                if (DgvSales.Rows.Count > 0)
                {
                    // Calculate total buys
                    //var totalBuy = DgvSales.Rows
                    //    .Cast<DataGridViewRow>()
                    //    .Where(row => !string.IsNullOrEmpty(row.Cells[7].FormattedValue.ToString()) &&
                    //                  !string.IsNullOrEmpty(row.Cells[5].FormattedValue.ToString()))
                    //    .Sum(row =>
                    //    {
                    //        decimal.TryParse(row.Cells[7].FormattedValue.ToString(), out decimal cell8);
                    //        decimal.TryParse(row.Cells[5].FormattedValue.ToString(), out decimal cell6);
                    //        return cell8 * cell6;
                    //    })
                    //    .ToString("f2");

                    // Calculate total income
                    var totalIncome = DgvSales.Rows
                        .Cast<DataGridViewRow>()
                        .Where(row => !string.IsNullOrEmpty(row.Cells[6].FormattedValue.ToString()) &&
                      !string.IsNullOrEmpty(row.Cells[5].FormattedValue.ToString()) &&
                      !string.IsNullOrEmpty(row.Cells[4].FormattedValue.ToString())
                        )

                        .Sum(row =>
                        {
                            decimal.TryParse(row.Cells[6].FormattedValue.ToString(), out decimal cell6);
                            decimal.TryParse(row.Cells[7].FormattedValue.ToString(), out decimal cell7);
                            decimal.TryParse(row.Cells[5].FormattedValue.ToString(), out decimal cell5);
                            return ((cell6 * cell5) - ((cell6 * cell5) * (cell7 / 100)));
                        })
                        .ToString("f2");

                    //  var totalPaidUp = DgvSales.Rows
                    //  .Cast<DataGridViewRow>()
                    //  .Where(row =>
                    //!string.IsNullOrEmpty(row.Cells[11].FormattedValue.ToString())
                    //  )

                    //  .Sum(row =>
                    //  {
                    //      decimal.TryParse(row.Cells[11].FormattedValue.ToString(), out decimal cell6);
                    //      return cell6;
                    //  })
                    //  .ToString("f2");


                    //var totalProfit = DgvSales.Rows
                    //    .Cast<DataGridViewRow>()
                    //    .Where(row => !string.IsNullOrEmpty(row.Cells[10].FormattedValue.ToString()))
                    //    .Sum(row =>
                    //    {
                    //        decimal.TryParse(row.Cells[10].FormattedValue.ToString(), out decimal cell11);
                    //        return cell11;
                    //    })
                    //    .ToString("f2");


                    lblTotalIncome.Text = $"مجموع المداخيل : {totalIncome}";
                    //lblTotalProfit.Text = $"مجموع المدفوعات : {totalPaidUp}";
                    //lblTotalBuys.Text = $"مجموع المشتريات : {totalBuy}";
                }

            }
            catch (Exception)
            {

                throw;
            }

        }
        private async void btnExportCustomer_Click(object sender, EventArgs e)
        {
            try
            {
                ToasterHelper.PlayNotificationSound();
                if (DgvSales.SelectedRows.Count > 0)
                {
                    DataTable saleDetailsTable = await FactureHelper.GetSellDetailsDataTableAsync(Convert.ToInt32(DgvSales.CurrentRow.Cells[0].Value.ToString()));
                    Reports.sale8cm sale8Cm = new();
                    sale8Cm.DataSource = saleDetailsTable;
                    var xtraForm1 = Reports.ReportPerviwGui.PerviweForm.Instance(sale8Cm);
                    xtraForm1.Show();
                }
            }
            catch (Exception)
            {

                throw;
            }

        }

        private void button2_Click(object sender, EventArgs e)
        {

        }

        private async void button1_Click(object sender, EventArgs e)
        {
            var sales = await _contex.SalesDetails
                   .OrderByDescending(x => x.Sale.Id)
                   .Include(x => x.Sale)
                   .Include(x => x.Product)
                   .Include(x => x.Customer)

                   .Select(bd => new SaleDetailDto
                   {
                       Order_ID = bd.Order_ID,
                       Date = bd.Sale.Date,
                       Time = bd.Sale.Time,
                       User_Name = bd.Sale.User_Name,
                       TotalFacture = bd.Sale.TotalOrder,
                       PaidUp = bd.Sale.PaidUP,
                       Remain = bd.Sale.Remain,
                       CustomerName = bd.Customer.CustomerName, // Assuming `Name` is the property for the supplier's name
                       ProductName = bd.Product.ProductName,   // Assuming `Name` is the property for the product's name
                       Quantity = bd.Quentity,
                       PriceWithTax = bd.PriceWithTax,
                       TotalPrice = bd.Total,
                       Discount = bd.Discount,
                   })
                   .ToListAsync();



            ExportExcel(sales);
        }
        private void ExportExcel(List<Core.Entities.Sales.SaleDetailDto> data)
        {

            DataTable dataTable = new DataTable();


            using (var reader = FastMember.ObjectReader.Create(data))
            {
                dataTable.Load(reader);
            }


            dataTable = arrangedDataTable(dataTable);


            ExcelHelper.Export(dataTable, $"AllSales {data.Count}");
        }
        private DataTable arrangedDataTable(DataTable dataTable)
        {

            dataTable.Columns["Order_ID"].SetOrdinal(0);
            dataTable.Columns["Order_ID"].ColumnName = "معرف الفاتورة";

            dataTable.Columns["CustomerName"].SetOrdinal(1);
            dataTable.Columns["CustomerName"].ColumnName = "اسم العميل";


            dataTable.Columns["Date"].SetOrdinal(2);
            dataTable.Columns["Date"].ColumnName = "تاريخ الفاتورة";


            dataTable.Columns["Time"].SetOrdinal(3);
            dataTable.Columns["Time"].ColumnName = "وقت الفاتورة";

            dataTable.Columns["ProductName"].SetOrdinal(4);
            dataTable.Columns["ProductName"].ColumnName = "اسم المنتج";

            dataTable.Columns["Quantity"].SetOrdinal(5);
            dataTable.Columns["Quantity"].ColumnName = "الكمية";

            dataTable.Columns["PriceWithTax"].SetOrdinal(6);
            dataTable.Columns["PriceWithTax"].ColumnName = "سعر المنتج";

            dataTable.Columns["Discount"].SetOrdinal(7);
            dataTable.Columns["Discount"].ColumnName = "التخفيض";


            dataTable.Columns["TotalPrice"].SetOrdinal(8);
            dataTable.Columns["TotalPrice"].ColumnName = "السعر الاجمالي";


            dataTable.Columns["User_Name"].SetOrdinal(9);
            dataTable.Columns["User_Name"].ColumnName = "البائع";


            dataTable.Columns["TotalFacture"].SetOrdinal(10);
            dataTable.Columns["TotalFacture"].ColumnName = "حسبة الفاتورة";


            dataTable.Columns["PaidUp"].SetOrdinal(11);
            dataTable.Columns["PaidUp"].ColumnName = "المدفوع";

            dataTable.Columns["Remain"].SetOrdinal(12);
            dataTable.Columns["Remain"].ColumnName = "الباقي";
            return dataTable;
        }
        private void btnRefresh_Click(object sender, EventArgs e)
        {
            ToasterHelper.PlayNotificationSound();
            LoadData();
        }

        private async void btnDeleteCurrentPage_Click(object sender, EventArgs e)
        {
            ToasterHelper.PlayNotificationSound();
            if (MsgHelper.ShowDeleteDialog())
            {
                for (int i = 0; i < DgvSales.Rows.Count; i++)
                {
                    //string idfacture = DgvSales.Rows[i].Cells[0].Value.ToString();
                    //_contex.SalesProfits.Where(x => x.Order_ID.ToString() == idfacture).ExecuteDelete();
                    //_contex.SaveChanges();
                    //var saleDetails = _contex.SalesDetails.Where(x => x.Order_ID.ToString() == idfacture);
                    //_contex.SalesDetails.RemoveRange(saleDetails);
                    //_contex.SaveChanges();
                    //_contex.Sales.Remove(_contex.Sales.FirstOrDefault(x => x.Id.ToString() == idfacture));
                    //_contex.SaveChanges();

                    Sale sale = _contex.Sales.FirstOrDefault(x => x.Id.ToString() == DgvSales.Rows[i].Cells[0].Value.ToString());
                    _contex.Sales.Remove(sale);
                    await _contex.SaveChangesAsync();
                }
                Code.Helper.ToasterHelper.ShowDeletedToast();

                LoadData();

            }
        }

        private async void btnDeleteReportsInPeriod_Click(object sender, EventArgs e)
        {
            ToasterHelper.PlayNotificationSound();
            if (MsgHelper.ShowDeleteDialog())
            {
                try
                {
                    var query = _contex.Sales
                        .Where(x => dtpFrom.Value <= x.Date && x.Date <= dtpTo.Value)
                        .ToList();

                    if (query.Any())
                    {
                        _contex.Sales.RemoveRange(query);
                        await _contex.SaveChangesAsync();
                    }
                    else
                    {

                        MessageBox.Show("لا توجد بيانات في الفترة المحددة", "معلومة", MessageBoxButtons.OK, MessageBoxIcon.Information);
                    }
                    LoadData();
                    Code.Helper.ToasterHelper.ShowDeletedToast();

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
            ToasterHelper.PlayNotificationSound();
            if (MsgHelper.ShowDeleteDialog())
            {
                try
                {
                    _contex.Database.ExecuteSqlRaw($"DELETE FROM [Sales]");
                    LoadData();
                    Code.Helper.ToasterHelper.ShowDeletedToast();

                }
                catch (Exception ex)
                {
                    // Handle or log the exception
                    MessageBox.Show($"لقد حدث خطأ : {ex.Message}", "خطأ برمجي", MessageBoxButtons.OK, MessageBoxIcon.Error);
                }
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
