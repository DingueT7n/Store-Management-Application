using System.Linq.Expressions;
using DevExpress.XtraCharts;
using Microsoft.EntityFrameworkCore;
using Store.ApplicationUI.Code.Helper;
using Store.ApplicationUI.Gui.LoadingGui;
using Store.Infrastructure.Data;

namespace Store.ApplicationUI.Gui.HomeGui
{
    public partial class StatisticsUserControl : UserControl
    {
        private static StatisticsUserControl? _UserControl;
        private static MainForm? _main;
        private static ApplicationDbContext? _context;
        public StatisticsUserControl()
        {
            InitializeComponent();
        }
        public static bool CheckInstance()
        {
            return (_UserControl == null);
        }
        public static StatisticsUserControl? Instance(MainForm main)
        {
            _main = main;
            // If the instance is null, create a new one and assign it to the static field
            _context = new ApplicationDbContext();
            if (CheckInstance())
            {
                _UserControl = new StatisticsUserControl();
            }
            // Return the singleton instance
            _UserControl?.LoadData();
            return _UserControl;
        }
        public async void LoadData()
        {
            dtpTo.Value = DateTime.Now.AddDays(30);
            //ShowLoading
            LoadingForm.Instance(_main).Show();
            if (await Task.Run(() => _context.Database.CanConnect()))
            {
                //Start Load Data

                // if its an admin or Normal user 
                try
                {
                    var dataCaisse = _context.Caisses.ToList();
                    cmbCaisse.DataSource = dataCaisse;
                    cmbCaisse.DisplayMember = "CaisseName";
                    cmbCaisse.ValueMember = "Id";
                    cmbCustomers.Text = "اختر الصندوق";

                    cmbCustomers.DataSource = _context.Customers.ToList();
                    cmbCustomers.DisplayMember = "CustomerName";
                    cmbCustomers.ValueMember = "Id";
                    cmbCustomers.Text = "اختر العميل";

                    cmbUser.DataSource = _context.Users.ToList();
                    cmbUser.DisplayMember = "UserName";
                    cmbUser.ValueMember = "Id";
                    cmbUser.Text = "اختر البائع";

                    LoadChartData();
                }
                catch (Exception ex)
                {
                    ToasterHelper.ShowErrorHappened(ex.Message);
                    throw;
                }
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
            cmbCaisse.SelectedValue = Properties.Settings.Default.DefaultCaisseId;


        }
        private async void LoadChartData()
        {
            try
            {
                var selectedCaisseId = cmbCaisse.SelectedValue as int?;
                var selectedCustomerId = cmbCustomers.Text == "اختر العميل" ? null : cmbCustomers.SelectedValue.ToString();
                var selectedUserId = cmbUser.Text == "اختر البائع" ? null : cmbUser.Text;

                var salesData = await GetChartDataAsync(
                    _context.Sales,
                    s => s.Date.Date,
                    s => s.TotalOrder,
                    s => s.Date.Date >= dtpFrom.Value.Date && s.Date.Date <= dtpTo.Value.Date,
                    s => selectedCustomerId == null || s.CustomerId.ToString() == selectedCustomerId,
                    s => selectedUserId == null || s.User_Name.Contains(selectedUserId)
                );

                var buysData = await GetChartDataAsync(
                    _context.Buys,
                    b => b.Date.Date,
                    b => b.Total,
                    b => b.Date.Date >= dtpFrom.Value.Date && b.Date.Date <= dtpTo.Value.Date,
                    b => selectedUserId == null || b.User_Name.Contains(selectedUserId)
                );

                var deservedData = await GetChartDataAsync(
                    _context.Deserveds,
                    d => d.Date.Date,
                    d => d.Price,
                    d => d.Date.Date >= dtpFrom.Value.Date && d.Date.Date <= dtpTo.Value.Date,
                    d => selectedUserId == null || d.UserName.Contains(selectedUserId)
                );

                //  var selectedCaisseId = cmbCaisse.SelectedValue as int?;
                //  var selectedCustomerId = cmbCustomers.Text == "اختر العميل" ? null : cmbCustomers.SelectedValue.ToString();
                //  var selectedUserId = cmbUser.Text == "اختر البائع" ? null : cmbUser.Text;

                //  // Step 1: Retrieve Data for Sales and Buys

                //  var salesData = GetChartData(
                //    _context.Sales,
                //    s => s.Date.Date,
                //    s => (s.TotalOrder),
                //    s => (s.Date.Date >= dtpFrom.Value.Date && s.Date.Date <= dtpTo.Value.Date),
                //   // Apply filters dynamically
                //   //s => selectedCaisseId == null || s. == selectedCaisseId,
                //   s => selectedCustomerId == null || s.CustomerId.ToString() == selectedCustomerId,
                //     s => selectedUserId == null || s.User_Name.Contains(selectedUserId)

                //);

                //  // Buys data filtered by the selected values
                //  var buysData = GetChartData(
                //      _context.Buys,
                //      b => b.Date.Date,
                //      b => b.Total, s => (s.Date.Date >= dtpFrom.Value.Date && s.Date.Date <= dtpTo.Value.Date),
                //      //b => selectedCaisseId == null || b.CaisseId == selectedCaisseId,
                //      //b => selectedCustomerId == null || b.CustomerId == selectedCustomerId,
                //      b => selectedUserId == null || b.User_Name.Contains(selectedUserId)
                //  );

                //  // Deserved data filtered by the selected values
                //  var deservedData = GetChartData(
                //      _context.Deserveds,
                //      d => d.Date.Date,
                //      d => d.Price, s => (s.Date.Date >= dtpFrom.Value.Date && s.Date.Date <= dtpTo.Value.Date),
                //      //d => selectedCaisseId == null || d.CaisseId == selectedCaisseId,
                //      //d => selectedCustomerId == null || d.CustomerId == selectedCustomerId,
                //      d => selectedUserId == null || d.UserName.Contains(selectedUserId)
                //  );
                // Step 2: Clear existing series and add new series to chartControl1
                chartControl1.Series.Clear(); // Clear previous data

                // Add "مجموع المبيعات" Series
                AddSeriesToChart(chartControl1, "مجموع المبيعات", salesData, ViewType.Line, Color.Green, "إحصائيات المبيعات");
                chartControl2.Series.Clear();
                // Add "مجموع المشتريات" Series
                AddSeriesToChart(chartControl2, "مجموع المشتريات", buysData, ViewType.Line, Color.Blue, "إحصائيات المشتريات");

                chartControl4.Series.Clear();
                // Add "مجموع المشتريات" Series
                AddSeriesToChart(chartControl4, "مجموع المصروفات", deservedData, ViewType.Line, Color.Blue, "إحصائيات المصروفات");
                chartControl9.Series.Clear();
                var caisseDepositData = GetChartData(
                    _context.CaissesDeposits,
                    s => s.Date.Date,
                    s => s.Money,
                    s => s.Caisse_ID == (selectedCaisseId is not null ? selectedCaisseId : null),
                    s => (s.Date.Date >= dtpFrom.Value.Date && s.Date.Date <= dtpTo.Value.Date)

                            //selectedCaisseId is not null ? s => s.Id == selectedCaisseId : null
                            );
                //s => selectedCustomerId == null || s.Caisse_ID.ToString() == (selectedCustomerId)
                var caisseWithdrawData = GetChartData(
                     _context.CaissesWithdraws,
                     s => s.Date.Date,
                     s => s.Money,
                        s => s.Caisse_ID == (selectedCaisseId is not null ? selectedCaisseId : null),
                        s => (s.Date.Date >= dtpFrom.Value.Date && s.Date.Date <= dtpTo.Value.Date)

                 );

                // Combine the data into a single list for plotting
                var combinedData = caisseDepositData
                    .Select(d => new { d.Date.Date, Total = d.Total, Type = "Deposit" })
                    .Concat(
                        caisseWithdrawData.Select(w => new { w.Date.Date, Total = w.Total, Type = "Withdraw" })
                    )
                    .OrderBy(x => x.Date.Date) // Ensure the data is sorted by date
                    .ToList();
                var combinedDataq = caisseDepositData
                .Select(d => new { d.Date.Date, Total = d.Total, Type = "Deposit" })
                .Concat(
                    caisseWithdrawData.Select(w => new { w.Date.Date, Total = w.Total, Type = "Withdraw" })
                )
                .GroupBy(x => new { x.Date.Date, x.Type })
                .Select(g => new { g.Key.Date.Date, g.Key.Type, Total = g.Sum(x => x.Total) })
                .OrderBy(x => x.Date.Date)
                .ToList();

                // Group data for easier plotting (optional, in case dates overlap)
                var groupedData = combinedData
                    .GroupBy(x => new { x.Date.Date, x.Type })
                    .Select(g => (g.Key.Date.Date, g.Key.Type, Total: g.Sum(x => x.Total)))
                    .ToList();
                var combinedData1 = caisseDepositData
         .Select(d => new { d.Date.Date, Amount = d.Total }) // Deposits as positive
         .Concat(
             caisseWithdrawData.Select(w => new { w.Date.Date, Amount = -w.Total }) // Withdrawals as negative
         )
         .OrderBy(x => x.Date.Date) // Ensure sorted by date
         .ToList();

                // Step 2: Calculate cumulative real value
                decimal cumulativeValue = 0;
                var realValueData = combinedData1
                    .GroupBy(x => x.Date.Date) // Group by date
                    .OrderBy(g => g.Key)  // Ensure dates are processed in order
                    .Select(g =>
                    {
                        cumulativeValue += g.Sum(x => x.Amount); // Update cumulative value
                        return (Date: g.Key, CumulativeValue: cumulativeValue);
                    })
                    .ToList();



                AddSeriesToChart(chartControl9,
                    "الايداع في الصناديق",
                    groupedData.Where(g => g.Type == "Deposit").Select(g => (g.Date.Date, g.Total)).ToList(),
                    ViewType.Line,
                    Color.Blue,
                    "معاملات الصناديق السحب والايداع");


                AddSeriesToChart(chartControl9,
                    "السحب من الصناديق",
                    groupedData.Where(g => g.Type == "Withdraw").Select(g => (g.Date.Date, g.Total)).ToList(),
                    ViewType.Line,
                    Color.Red,
                    "معاملات الصناديق");


                AddSeriesToChart(chartControl9,
                    "القيمة الحقيقية في الصناديق",
                    realValueData,
                    ViewType.Line,
                    Color.Green,
                    "القيمة الحقيقية");
                await PieBuysSalesAsync(salesData, buysData, deservedData);

                await VisualizeTopProductsByProfitAsync();

                await VisualizeTopProductsByQuantityAsync();
                await VisualizeNetProfitAsync();
                await VisualizeProfitAsync();
            }
            catch (Exception ex)
            {
                ToasterHelper.ShowErrorHappened(ex.Message);
                throw;
            }

        }
        private async Task PieBuysSalesAsync(List<(DateTime, decimal Total)> salesData,
                                          List<(DateTime, decimal Total)> buysData,
                                          List<(DateTime, decimal Total)> deservedData)
        {
            try
            {
                await Task.Run(() =>
                {
                    // Calculate totals
                    var salesSums = salesData.Sum(s => s.Total);
                    var buysSums = buysData.Sum(s => s.Total);
                    var deservedSums = deservedData.Sum(s => s.Total);

                    // Update UI on the main thread
                    chartControl3.Invoke(new Action(() =>
                    {
                        chartControl3.Series.Clear();

                        // Update text fields
                        txtTotalSales.Text = salesSums.ToString("f2");
                        txtTotalBuys.Text = buysSums.ToString("f2");
                        txtTotalDeserved.Text = deservedSums.ToString("f2");

                        // Create and configure the Pie Series
                        Series series = new Series("نسبة المبيعات والمشتريات", ViewType.Pie);
                        series.Points.Add(new SeriesPoint("مجموع المبيعات", salesSums));
                        series.Points.Add(new SeriesPoint("مجموع المشتريات", buysSums));
                        series.Points.Add(new SeriesPoint("مجموع المصروفات", deservedSums));

                        // Set custom colors
                        series.Points[0].Color = Color.Green; // مجموع المبيعات
                        series.Points[1].Color = Color.Blue;   // مجموع المشتريات
                        series.Points[2].Color = Color.Red;    // مجموع المصروفات

                        // Add the Series to the ChartControl
                        chartControl3.Series.Add(series);

                        // Enable Labels and Percentages
                        series.LabelsVisibility = DevExpress.Utils.DefaultBoolean.True;
                        PieSeriesLabel label = (PieSeriesLabel)series.Label;
                        label.Position = PieSeriesLabelPosition.TwoColumns;
                        label.TextPattern = "{A}: {VP:p2}";

                        // Add Chart Title
                        if (chartControl3.Titles.Count == 0)
                        {
                            ChartTitle chartTitle = new ChartTitle
                            {
                                Text = "نسبة المبيعات والمشتريات والمصروفات",
                                Alignment = StringAlignment.Center,
                                Font = new Font("Calibri", 16, FontStyle.Bold),
                                TextColor = Color.Black
                            };
                            chartControl3.Titles.Add(chartTitle);
                        }

                        // Adjust Legend
                        chartControl3.Legend.Visibility = DevExpress.Utils.DefaultBoolean.True;
                        chartControl3.Legend.AlignmentHorizontal = LegendAlignmentHorizontal.Center;
                        chartControl3.Legend.AlignmentVertical = LegendAlignmentVertical.Bottom;
                    }));
                });
            }
            catch (Exception ex)
            {
                ToasterHelper.ShowErrorHappened(ex.Message);
            }
        }


        #region Helper Methods

        /// <summary>
        /// Retrieves grouped chart data from the database.
        /// </summary>
        /// <typeparam name="T">Entity type (e.g., Sales, Buys)</typeparam>
        /// <param name="data">DbSet to query</param>
        /// <param name="groupKey">Grouping key selector (e.g., date)</param>
        /// <param name="sumSelector">Sum selector for the total</param>
        /// <returns>List of grouped data with Date and Total</returns>
        private async Task<List<(DateTime Date, decimal Total)>> GetChartDataAsync<T>(
      IQueryable<T> data,
      Expression<Func<T, DateTime>> groupKey,
      Expression<Func<T, decimal>> sumSelector,
      params Expression<Func<T, bool>>[] filters)
        {
            // Apply filters dynamically
            foreach (var filter in filters)
            {
                data = data.Where(filter);
            }

            // Perform the grouping and summing
            var result = await data
                .GroupBy(groupKey) // Group by the date field
                .Select(g => new
                {
                    Date = g.Key,
                    Total = g.AsQueryable().Sum(sumSelector) // Sum the elements in each group
                })
                .ToListAsync(); // Execute asynchronously

            return result.Select(x => (x.Date.Date, x.Total)).ToList(); // Convert to List
        }
        private List<(DateTime Date, decimal Total)> GetChartData<T>(
          IQueryable<T> data,
          Func<T, DateTime> groupKey,
          Func<T, decimal> sumSelector,
          params Func<T, bool>[] filters)
        {
            // Apply each filter dynamically
            foreach (var filter in filters)
            {
                data = data.Where(filter).AsQueryable();
            }

            return data
                .GroupBy(groupKey)
                .Select(g => new { Date = g.Key, Total = g.Sum(sumSelector) })
                //.Where(x => dtpFrom.Value <= x.Date && dtpTo.Value >= x.Date)
                .AsEnumerable()
                .Select(x => (x.Date.Date, x.Total))
                .ToList();
        }

        /// <summary>
        /// Adds a series with data points to a chart control.
        /// </summary>
        /// <param name="chartControl">Target ChartControl</param>
        /// <param name="seriesName">Name of the series</param>
        /// <param name="data">Data points</param>
        /// <param name="viewType">Type of chart view</param>
        /// <param name="color">Color for the series</param>
        private void AddSeriesToChart(
            ChartControl chartControl,
            string seriesName,
            List<(DateTime Date, decimal Total)> data,
            ViewType viewType,
            Color color, string Title)
        {
            chartControl.ClearCache();
            chartControl.ClearSelection();
            var series = new Series(seriesName, viewType)
            {
                View = { Color = color }
            };

            foreach (var point in data)
            {
                series.Points.Add(new SeriesPoint(point.Date, point.Total));
            }
            if (chartControl.Titles.Count < 1)
            {
                chartControl.Titles.Add(new ChartTitle()
                {
                    Text = Title,
                    Alignment = StringAlignment.Center,
                    TextColor = Color.Black,
                    Font = new Font("Calibri", 16, FontStyle.Bold)
                });
                chartControl.Legend.Visibility = DevExpress.Utils.DefaultBoolean.True;
            }
            chartControl.Series.Add(series);
            // Step 4: Configure X and Y axis
            if (chartControl.Diagram is XYDiagram diagram)
            {
                // Configure X-axis
                diagram.AxisX.Title.Text = "التاريخ";
                diagram.AxisX.Title.TextColor = Color.Black;

                diagram.AxisX.Title.Visibility = DevExpress.Utils.DefaultBoolean.True;
                diagram.AxisX.Label.Angle = -45;
                diagram.AxisX.DateTimeScaleOptions.MeasureUnit = DateTimeMeasureUnit.Day;

                // Configure Y-axis
                diagram.AxisY.Title.Text = "القيمة المالية";
                diagram.AxisY.Title.TextColor = Color.Black;

                diagram.AxisY.Title.Visibility = DevExpress.Utils.DefaultBoolean.True;
                diagram.AxisY.Label.TextPattern = "{V} دج";
            }
        }

        private async Task VisualizeTopProductsByProfitAsync()
        {
            try
            {
                // Clear previous series
                chartControl6.Series.Clear();

                int topN = Convert.ToInt32(cmbSaleProfit.Text);

                // Execute database query asynchronously
                var topProductsByProfit = await _context.SalesProfits
                    .Where(x => dtpFrom.Value.Date <= x.Sale.Date && dtpTo.Value.Date >= x.Sale.Date)
                    .GroupBy(s => s.Product.ProductName)
                    .Select(g => new
                    {
                        ProductName = g.Key,
                        TotalProfit = g.Sum(s => (s.Price - s.Buy_Price) * s.Quentity)
                    })
                    .OrderByDescending(p => p.TotalProfit)
                    .Take(topN)
                    .ToListAsync(); // **Use async to avoid blocking the UI**

                // Create series for visualization
                var series = new Series($"أفضل {topN} منتجات مبيعًا حسب الربح", ViewType.Bar);

                foreach (var product in topProductsByProfit)
                {
                    series.Points.Add(new SeriesPoint(product.ProductName, product.TotalProfit));
                }

                // Customize labels
                series.LabelsVisibility = DevExpress.Utils.DefaultBoolean.True;

                if (series.Label is BarSeriesLabel label)
                {
                    label.TextPattern = "{A}: {V} دج"; // Display Product Name (A) and Profit Value (V)
                    label.TextColor = Color.Black;
                }

                // Add series to chart
                chartControl6.Series.Add(series);

                // Configure chart title
                chartControl6.Titles.Clear();
                chartControl6.Titles.Add(new ChartTitle
                {
                    Text = $"أفضل {topN} منتجات مبيعًا حسب الربح",
                    Font = new Font("Calibri", 16, FontStyle.Bold),
                    Alignment = StringAlignment.Center,
                    TextColor = Color.Black
                });

                // Configure X and Y axis titles
                if (chartControl6.Diagram is XYDiagram diagram)
                {
                    diagram.AxisX.Title.Text = "المنتج";
                    diagram.AxisX.Title.TextColor = Color.Black;
                    diagram.AxisX.Title.Visibility = DevExpress.Utils.DefaultBoolean.True;

                    diagram.AxisY.Title.Text = "(اجمال الربح (دج";
                    diagram.AxisY.Title.TextColor = Color.Black;
                    diagram.AxisY.Title.Visibility = DevExpress.Utils.DefaultBoolean.True;
                    diagram.AxisY.Label.TextPattern = "{V} دج"; // Format Y-axis as currency
                }

                // Hide legend
                chartControl6.Legend.Visibility = DevExpress.Utils.DefaultBoolean.False;
            }
            catch (Exception ex)
            {
                ToasterHelper.ShowErrorHappened($"حدث خطأ أثناء عرض بيانات الأرباح: {ex.Message}");
            }
        }

        private async Task VisualizeNetProfitAsync()
        {
            try
            {
                // Clear existing series in the chart
                chartControl7.Series.Clear();

                // Get selected values
                string? selectedCustomerId = cmbCustomers.Text == "اختر العميل" ? null : cmbCustomers.SelectedValue?.ToString();
                string? selectedUserId = cmbUser.Text == "اختر البائع" ? null : cmbUser.Text;

                // Validate date range
                DateTime startDate = dtpFrom.Value.Date;
                DateTime endDate = dtpTo.Value.Date;

                // Query sales profit data
                var salesProfitQuery = _context.SalesProfits.AsQueryable();

                if (!string.IsNullOrEmpty(selectedCustomerId))
                    salesProfitQuery = salesProfitQuery.Where(s => s.Sale.CustomerId.ToString() == selectedCustomerId);

                if (!string.IsNullOrEmpty(selectedUserId))
                    salesProfitQuery = salesProfitQuery.Where(s => s.Sale.User_Name.Contains(selectedUserId));

                salesProfitQuery = salesProfitQuery.Where(s => s.Sale.Date >= startDate && s.Sale.Date <= endDate);

                var netProfitData = await salesProfitQuery
                    .GroupBy(sp => sp.Sale.Date.Date)
                    .Select(g => new
                    {
                        Date = g.Key,
                        TotalSalesProfit = g.Sum(sp => (sp.Price - sp.Buy_Price) * sp.Quentity)
                    })
                    .ToListAsync();

                decimal totalSalesProfit = netProfitData.Sum(s => s.TotalSalesProfit);
                txtProfit.Text = totalSalesProfit.ToString("F2");

                // Query deserved data
                var deservedQuery = _context.Deserveds.AsQueryable();

                if (!string.IsNullOrEmpty(selectedUserId))
                    deservedQuery = deservedQuery.Where(d => d.UserName.Contains(selectedUserId));

                deservedQuery = deservedQuery.Where(d => d.Date.Date >= startDate && d.Date.Date <= endDate);

                var deservedData = await deservedQuery
                    .GroupBy(d => d.Date.Date)
                    .Select(g => new
                    {
                        Date = g.Key,
                        TotalDeserved = g.Sum(d => d.Price)
                    })
                    .ToListAsync();

                // Merge sales profits and deserveds
                var combinedData = netProfitData
                    .Concat(
                        deservedData
                            .Where(d => !netProfitData.Any(s => s.Date == d.Date))
                            .Select(d => new { Date = d.Date, TotalSalesProfit = 0m })
                    )
                    .GroupJoin(deservedData,
                        sales => sales.Date,
                        deserved => deserved.Date,
                        (sales, deserved) => new
                        {
                            Date = sales.Date,
                            NetProfit = sales.TotalSalesProfit - deserved.Sum(d => d.TotalDeserved)
                        })
                    .OrderBy(data => data.Date)
                    .ToList();

                decimal totalNetProfit = combinedData.Sum(data => data.NetProfit);
                txtNetProfits.Text = totalNetProfit.ToString("F2");

                // Create series for visualization
                Series series = new Series("صافي الربح", ViewType.Line);

                foreach (var data in combinedData)
                {
                    series.Points.Add(new SeriesPoint(data.Date, data.NetProfit));
                }

                // Enable labels and set their text pattern
                series.LabelsVisibility = DevExpress.Utils.DefaultBoolean.True;
                series.Label.TextPattern = "{V} دج";
                series.Label.TextColor = Color.Black;

                if (series.View is LineSeriesView view)
                {
                    view.Color = Color.Orange;
                    view.LineMarkerOptions.Kind = MarkerKind.Circle;
                }

                // Add series to chart
                chartControl7.Series.Add(series);

                // Configure chart title
                chartControl7.Titles.Clear();
                chartControl7.Titles.Add(new ChartTitle
                {
                    Text = "صافي الربح حسب التاريخ",
                    Font = new Font("Calibri", 16, FontStyle.Bold),
                    Alignment = StringAlignment.Center,
                    TextColor = Color.Black
                });

                // Configure X and Y axes
                if (chartControl7.Diagram is XYDiagram diagram)
                {
                    diagram.AxisX.Title.Text = "التاريخ";
                    diagram.AxisX.Title.TextColor = Color.Black;
                    diagram.AxisX.Title.Visibility = DevExpress.Utils.DefaultBoolean.True;
                    diagram.AxisX.Label.Angle = -45;
                    diagram.AxisX.DateTimeScaleOptions.MeasureUnit = DateTimeMeasureUnit.Day;

                    diagram.AxisY.Title.Text = "(صافي الربح (دج";
                    diagram.AxisY.Title.TextColor = Color.Black;
                    diagram.AxisY.Title.Visibility = DevExpress.Utils.DefaultBoolean.True;
                    diagram.AxisY.Label.TextPattern = "{V} دج";
                }
            }
            catch (Exception ex)
            {
                ToasterHelper.ShowErrorHappened(ex.Message);
                throw;
            }
        }

        private async Task VisualizeProfitAsync()
        {
            try
            {
                // Ensure chart control is not null
                if (chartControl8 == null) return;

                // Clear any existing series in the chart
                chartControl8.Series.Clear();

                // Ensure the database context is available
                if (_context == null) return;


                var selectedCustomerId = cmbCustomers.Text == "اختر العميل" ? null : cmbCustomers.SelectedValue.ToString();
                var selectedUserId = cmbUser.Text == "اختر البائع" ? null : cmbUser.Text;

                // Ensure the date pickers are valid
                DateTime fromDate = dtpFrom?.Value.Date ?? DateTime.MinValue;
                DateTime toDate = dtpTo?.Value.Date ?? DateTime.MaxValue;

                // Step 1: Query Net Profit Data using IQueryable
                var netProfitQuery = _context.SalesProfits.AsQueryable();

                if (!string.IsNullOrEmpty(selectedCustomerId))
                    netProfitQuery = netProfitQuery.Where(s => s.Sale.CustomerId.ToString() == (selectedCustomerId));

                if (!string.IsNullOrEmpty(selectedUserId))
                    netProfitQuery = netProfitQuery.Where(s => s.Sale.User_Name.Contains(selectedUserId));

                netProfitQuery = netProfitQuery.Where(x => x.Sale.Date >= fromDate && x.Sale.Date <= toDate);

                // Perform grouping and projection asynchronously
                var netProfitData = await netProfitQuery
                    .GroupBy(sp => sp.Sale.Date.Date)
                    .Select(g => new
                    {
                        Date = g.Key,
                        TotalSalesProfit = g.Sum(sp => (sp.Price - sp.Buy_Price) * sp.Quentity)
                    })
                    .ToListAsync();
                var li = netProfitData.Count();

                // Step 2: Create Series for Net Profit Visualization
                Series series = new Series("الربح", ViewType.Line);

                // Add Data Points for Net Profit
                foreach (var data in netProfitData)
                {
                    series.Points.Add(new SeriesPoint(data.Date, data.TotalSalesProfit));
                }

                // Enable labels and set their text pattern
                series.LabelsVisibility = DevExpress.Utils.DefaultBoolean.True;
                series.Label.TextPattern = "{V} دج"; // Display net profit values in DZD
                series.Label.TextColor = Color.Black;

                // Customize Series Appearance
                if (series.View is LineSeriesView view)
                {
                    view.Color = Color.Orange;
                    view.LineMarkerOptions.Kind = MarkerKind.Circle;
                }

                // Add series to chart
                chartControl8.Series.Add(series);

                // Step 3: Add a Title to the Chart
                ChartTitle chartTitle = new ChartTitle
                {
                    Text = "الربح حسب التاريخ",
                    Font = new Font("Calibri", 16, FontStyle.Bold),
                    Alignment = StringAlignment.Center,
                    TextColor = Color.Black
                };

                chartControl8.Titles.Clear();
                chartControl8.Titles.Add(chartTitle);

                // Step 4: Configure X and Y axis
                if (chartControl8.Diagram is XYDiagram diagram)
                {
                    // Configure X-axis
                    diagram.AxisX.Title.Text = "التاريخ";
                    diagram.AxisX.Title.Visibility = DevExpress.Utils.DefaultBoolean.True;
                    diagram.AxisX.Title.TextColor = Color.Black;
                    diagram.AxisX.Label.Angle = -45;
                    diagram.AxisX.DateTimeScaleOptions.MeasureUnit = DateTimeMeasureUnit.Day;

                    // Configure Y-axis
                    diagram.AxisY.Title.Text = "الربح دج";
                    diagram.AxisY.Title.TextColor = Color.Black;
                    diagram.AxisY.Title.Visibility = DevExpress.Utils.DefaultBoolean.True;
                    diagram.AxisY.Label.TextPattern = "{V} دج";
                }
            }
            catch (Exception ex)
            {
                ToasterHelper.ShowErrorHappened(ex.Message);
            }
        }

        private async Task VisualizeTopProductsByQuantityAsync()
        {
            try
            {
                // Clear previous series
                chartControl5.Series.Clear();

                int topN = Convert.ToInt32(cmbNbrProductQty.Text);

                // Retrieve the Top N Products Sold by Quantity (Asynchronously)
                var topProductsByQuantity = await _context.SalesDetails
                    .Where(x => dtpFrom.Value.Date <= x.Sale.Date && dtpTo.Value.Date >= x.Sale.Date)
                    .GroupBy(s => s.Product.ProductName)
                    .Select(g => new
                    {
                        ProductName = g.Key,
                        TotalQuantity = g.Sum(s => s.Quentity) // Sum of Quantity Sold
                    })
                    .OrderByDescending(p => p.TotalQuantity)
                    .Take(topN)
                    .ToListAsync(); // **Asynchronous execution**

                // Create a Series for Visualization
                var series = new Series($"أفضل {topN} منتجات مبيعًا حسب الكمية", ViewType.Bar);

                // Add Data Points to the Series
                foreach (var product in topProductsByQuantity)
                {
                    series.Points.Add(new SeriesPoint(product.ProductName, product.TotalQuantity));
                }

                // Customize Labels
                series.LabelsVisibility = DevExpress.Utils.DefaultBoolean.True;
                if (series.Label is BarSeriesLabel label)
                {
                    label.TextPattern = "{A}: {V}"; // Show Product Name (A) and Quantity Sold (V)
                    label.TextColor = Color.Black;
                }

                // Add Series to ChartControl
                chartControl5.Series.Add(series);

                // Configure Chart Title
                chartControl5.Titles.Clear();
                chartControl5.Titles.Add(new ChartTitle
                {
                    Text = $"أفضل {topN} منتجات مبيعًا حسب الكمية",
                    Font = new Font("Calibri", 16, FontStyle.Bold),
                    Alignment = StringAlignment.Center,
                    TextColor = Color.Black
                });

                // Customize X and Y Axis Titles
                if (chartControl5.Diagram is XYDiagram diagram)
                {
                    diagram.AxisX.Title.Text = "المنتج";
                    diagram.AxisX.Title.TextColor = Color.Black;
                    diagram.AxisX.Title.Visibility = DevExpress.Utils.DefaultBoolean.True;

                    diagram.AxisY.Title.Text = "الكمية المباعة";
                    diagram.AxisY.Title.TextColor = Color.Black;
                    diagram.AxisY.Title.Visibility = DevExpress.Utils.DefaultBoolean.True;
                }

                // Hide Legend
                chartControl5.Legend.Visibility = DevExpress.Utils.DefaultBoolean.False;
            }
            catch (Exception ex)
            {
                ToasterHelper.ShowErrorHappened($"حدث خطأ أثناء عرض بيانات الكمية: {ex.Message}");
            }
        }

        #endregion



        private void flowLayoutPanel10_Paint(object sender, PaintEventArgs e)
        {

        }

        private void btnSearch_Click(object sender, EventArgs e)
        {
            ToasterHelper.PlayNotificationSound();
            LoadChartData();
        }

        private void button1_Click(object sender, EventArgs e)
        {
            ToasterHelper.PlayNotificationSound();
            //flowLayoutPanel6.Size = new Size(1034, 463);
            flowLayoutPanel6.AutoSize = true;
            calcZakat();
            panelZakat.Visible = true;

        }

        private void calcZakat()
        {
            try
            {
                _context = new();
                decimal totalbuySales = 0.00m;
                if (rbBuy.Checked)
                {
                    totalbuySales = _context.Products.Sum(x => x.Quentity * x.BuyPrice);
                }
                else if (rbSale.Checked)
                {
                    totalbuySales = _context.Products.Sum(x => x.Quentity * x.SalePriceTax);
                }
                txtBuySale.Text = totalbuySales.ToString("f2");
                var customerDebts = _context.Customers.Sum(x => x.TotalDebts);
                txtDebtCustomer.Text = customerDebts.ToString("f2");

                var caisseAndBank = _context.Caisses.Sum(x => x.MoneyinCaisse) + _context.Banks.Sum(x => x.Money);
                txtCaisseValue.Text = caisseAndBank.ToString("f2");
                var SupplierDebts = _context.Suppliers.Sum(x => x.TotalDebts);
                txtDebtSupplier.Text = SupplierDebts.ToString("f2");
                txtTotal.Text = ((totalbuySales + customerDebts + caisseAndBank) - SupplierDebts).ToString("f2");
                txtZakat.Text = ((Convert.ToDecimal(txtTotal.Text) * 2.5m) / 100).ToString("f2");


            }
            catch (Exception ex)
            {

                ToasterHelper.ShowErrorHappened(ex.Message);
            }
        }

        private void pictureBox1_Click(object sender, EventArgs e)
        {
            panelZakat.Visible = false;



        }

        private void cmbNbrProductQty_SelectionChangeCommitted(object sender, EventArgs e)
        {

        }
        private void cmbSaleProfit_SelectionChangeCommitted(object sender, EventArgs e)
        {

        }
        private async void cmbNbrProductQty_SelectedIndexChanged(object sender, EventArgs e)
        {
            await VisualizeTopProductsByQuantityAsync();
        }
        private async void cmbSaleProfit_SelectedIndexChanged(object sender, EventArgs e)
        {
            await VisualizeTopProductsByProfitAsync();
        }

        private void rbSale_CheckedChanged(object sender, EventArgs e)
        {
            calcZakat();
        }

        private void rbBuy_CheckedChanged(object sender, EventArgs e)
        {
            calcZakat();
        }
    }
}
