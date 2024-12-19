using DevExpress.XtraCharts;
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
            if (CheckInstance())
            {
                _context = new ApplicationDbContext();
                _UserControl = new StatisticsUserControl();
            }
            // Return the singleton instance
            _UserControl?.LoadData();
            return _UserControl;
        }


        public async void LoadData()
        {

            dtpTo.Value = DateTime.Now;
            //ShowLoading
            LoadingForm.Instance(_main).Show();
            if (await Task.Run(() => _context.Database.CanConnect()))
            {
                //Start Load Data

                // if its an admin or Normal user 

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


        }
        private void LoadChartData()
        {
            var selectedCaisseId = cmbCaisse.SelectedValue as int?;
            var selectedCustomerId = cmbCustomers.SelectedValue as int?;
            var selectedUserId = cmbUser.Text == "اختر البائع" ? "" : cmbUser.Text;
            // Step 1: Retrieve Data for Sales and Buys

            var salesData = GetChartData(
              _context.Sales,
              s => s.Date,
              s => s.TotalOrder,
              // Apply filters dynamically
              //s => selectedCaisseId == null || s. == selectedCaisseId,
              s => selectedCustomerId == null || s.CustomerId == selectedCustomerId,
              s => selectedUserId == null || s.User_Name.Contains(selectedUserId)
          );

            // Buys data filtered by the selected values
            var buysData = GetChartData(
                _context.Buys,
                b => b.Date,
                b => b.Total,
                //b => selectedCaisseId == null || b.CaisseId == selectedCaisseId,
                //b => selectedCustomerId == null || b.CustomerId == selectedCustomerId,
                b => selectedUserId == null || b.User_Name.Contains(selectedUserId)
            );

            // Deserved data filtered by the selected values
            var deservedData = GetChartData(
                _context.Deserveds,
                d => d.Date,
                d => d.Price,
                //d => selectedCaisseId == null || d.CaisseId == selectedCaisseId,
                //d => selectedCustomerId == null || d.CustomerId == selectedCustomerId,
                d => selectedUserId == null || d.UserName.Contains(selectedUserId)
            );
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
            PieBuysSales(salesData, buysData, deservedData);

            VisualizeTop10Products();

            VisualizeTop10ProductsByProfit();
            VisualizeNetProfit();
            VisualizeProfit();


        }
        void PieBuysSales(List<(DateTime, decimal Total)> salesData, List<(DateTime, decimal Total)> buysData, List<(DateTime, decimal Total)> deservedData)
        {
            chartControl3.Series.Clear();

            // Create Pie Chart Series
            Series series = new Series("نسبة المبيعات والمشتريات", ViewType.Pie);

            var salesSums = salesData.Sum(s => s.Total);
            var BuysSums = buysData.Sum(s => s.Total);
            var deservedSums = deservedData.Sum(s => s.Total);

            txtTotalSales.Text = salesSums.ToString();
            txtTotalBuys.Text = BuysSums.ToString();
            txtTotalDeserved.Text = deservedSums.ToString();

            // Add Points for Sales and Buys
            series.Points.Add(new SeriesPoint("مجموع المبيعات", salesSums));
            series.Points.Add(new SeriesPoint("مجموع المشتريات", BuysSums));
            series.Points.Add(new SeriesPoint("مجموع المصروفات", deservedSums));

            // Set custom colors for each point
            series.Points[0].Color = Color.Green; // مجموع المبيعات (Green)
            series.Points[1].Color = Color.Blue;   // مجموع المشتريات (Red)
            series.Points[2].Color = Color.Red;   // مجموع المشتريات (Red)

            // Add the Series to the ChartControl
            chartControl3.Series.Add(series);

            // Show Labels
            series.LabelsVisibility = DevExpress.Utils.DefaultBoolean.True;

            // Optional: Customize Label Position (if needed)
            PieSeriesLabel label = (PieSeriesLabel)series.Label;
            label.Position = PieSeriesLabelPosition.TwoColumns;

            // Optional: Adjust Legend Visibility

            // Enable Labels and Percentages
            series.LabelsVisibility = DevExpress.Utils.DefaultBoolean.True;

            label.Position = PieSeriesLabelPosition.TwoColumns; // Position outside for clarity
            label.TextPattern = "{A}: {VP:p2}"; // Show argument and percentage (e.g., 78.33%)


            // Add a Title to the Chart
            ChartTitle chartTitle = new ChartTitle();
            chartTitle.Text = "نسبة المبيعات والمشتريات والمصروفات"; // Title Text
            chartTitle.Alignment = StringAlignment.Center; // Center Align
            chartTitle.Font = new Font("Calibri", 12, FontStyle.Bold); // Custom Font
            if (chartControl3.Titles.Count == 0)
                chartControl3.Titles.Add(chartTitle);

            // Optional: Adjust Legend
            chartControl3.Legend.Visibility = DevExpress.Utils.DefaultBoolean.True;
            chartControl3.Legend.AlignmentHorizontal = LegendAlignmentHorizontal.Center;
            chartControl3.Legend.AlignmentVertical = LegendAlignmentVertical.Bottom;

            // Optional: Customize Appearance
            series.View.Color = Color.Black; // Keep custom colors
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
                .Where(x => dtpFrom.Value <= x.Date && dtpTo.Value >= x.Date)
                .AsEnumerable()
                .Select(x => (x.Date, x.Total))
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
                    Font = new Font("Calibri", 12, FontStyle.Bold)
                });
                chartControl.Legend.Visibility = DevExpress.Utils.DefaultBoolean.True;
            }
            chartControl.Series.Add(series);
        }

        private void VisualizeTop10ProductsByProfit()
        {
            // Clear previous series
            chartControl6.Series.Clear();

            // Step 1: Retrieve the Top 10 Products Sold by Profit
            var top10ProductsByProfit = _context.SalesProfits // Adjust the table name if needed
               .Where(x => dtpFrom.Value <= x.Sale.Date && dtpTo.Value >= x.Sale.Date)

                .GroupBy(s => s.Product.ProductName) // Group by Product Name
                                                     // Group by Product Name
                .Select(g => new
                {
                    ProductName = g.Key,
                    TotalProfit = g.Sum(s => (s.Price - s.Buy_Price) * s.Quentity) // Calculate Profit (SalePrice - BuyPrice)
                })
                .OrderByDescending(p => p.TotalProfit) // Sort by Profit Descending
                .Take(15) // Take the Top 10 Products
                .ToList();

            // Step 2: Create a Series for Visualization
            Series series = new Series("أفضل 15 منتجات مبيعًا حسب الربح", ViewType.Bar);

            // Step 3: Add Data Points to the Series
            foreach (var product in top10ProductsByProfit)
            {
                series.Points.Add(new SeriesPoint(product.ProductName, product.TotalProfit));
            }

            // Step 4: Customize Series Appearance
            series.LabelsVisibility = DevExpress.Utils.DefaultBoolean.True;
            BarSeriesLabel label = series.Label as BarSeriesLabel;
            if (label != null)
            {
                label.TextPattern = "{A}: {V} دج"; // Show Product Name (A) and Profit Value (V) as Currency
            }

            // Step 5: Add Series to ChartControl
            chartControl6.Series.Add(series);

            // Step 6: Add a Title to the Chart
            ChartTitle chartTitle = new ChartTitle();
            chartTitle.Text = "أفضل 15 منتجات مبيعًا حسب الربح";
            chartTitle.Font = new Font("Calibri", 12, FontStyle.Bold);
            chartTitle.Alignment = StringAlignment.Center;

            chartControl6.Titles.Clear();
            chartControl6.Titles.Add(chartTitle);

            // Step 7: Optional - Customize the Chart Appearance
            chartControl6.Legend.Visibility = DevExpress.Utils.DefaultBoolean.False;

            // Configure X and Y axis titles
            XYDiagram diagram = chartControl6.Diagram as XYDiagram;
            if (diagram != null)
            {
                diagram.AxisX.Title.Text = "المنتج";
                diagram.AxisX.Title.Visibility = DevExpress.Utils.DefaultBoolean.True;

                diagram.AxisY.Title.Text = "(اجمال الربح (دج";
                diagram.AxisY.Title.Visibility = DevExpress.Utils.DefaultBoolean.True;

                diagram.AxisY.Label.TextPattern = "{V} دج"; // Format Y-axis as currency
            }
        }
        private void VisualizeNetProfit()
        {
            // Clear any existing series in the chart
            chartControl7.Series.Clear();

            // Step 1: Calculate Net Profit
            var netProfitData = _context.SalesProfits // Assuming SalesProfit contains profits
               .Where(x => dtpFrom.Value <= x.Sale.Date && dtpTo.Value >= x.Sale.Date)
                .GroupBy(sp => sp.Sale.Date.Date) // Group by Date
                .Select(g => new
                {
                    Date = g.Key,
                    TotalSalesProfit = g.Sum(sp => (sp.Price - sp.Buy_Price) * sp.Quentity) // Sum of Profit per Date
                })
                .ToList();
            var Profit = netProfitData.Sum(s => s.TotalSalesProfit);

            txtProfit.Text = Profit.ToString();

            var deservedData = _context.Deserveds // Assuming Deserved contains expenses/deductions
               .Where(x => dtpFrom.Value <= x.Date && dtpTo.Value >= x.Date)

                .GroupBy(d => d.Date.Date) // Group by Date
                .Select(g => new
                {
                    Date = g.Key,
                    TotalDeserved = g.Sum(d => d.Price) // Sum of Deserved per Date
                })
                .ToList();

            // Merge SalesProfit and Deserved data to calculate Net Profit
            var netProfitByDate = netProfitData
                .GroupJoin(deservedData,
                    sales => sales.Date,
                    deserved => deserved.Date,
                    (sales, deserved) => new
                    {
                        Date = sales.Date,
                        NetProfit = sales.TotalSalesProfit - deserved.Sum(d => d.TotalDeserved) // Calculate Net Profit
                    })
                .OrderBy(data => data.Date) // Sort by Date
                .ToList();
            var netProfitByDatee = netProfitByDate.Sum(s => s.NetProfit);

            txtNetProfits.Text = netProfitByDatee.ToString();
            // Step 2: Create Series for Net Profit Visualization
            Series series = new Series("صافي الربح", ViewType.Line);

            // Add Data Points for Net Profit
            foreach (var data in netProfitByDate)
            {
                series.Points.Add(new SeriesPoint(data.Date, data.NetProfit));
            }


            // Enable labels and set their text pattern
            series.LabelsVisibility = DevExpress.Utils.DefaultBoolean.True;
            series.Label.TextPattern = "{V} دج"; // Display net profit values in دج
                                                 // Customize Series Appearance

            LineSeriesView view = series.View as LineSeriesView;
            if (view != null)
            {
                view.Color = Color.Orange; // Set line color to orange
                view.LineMarkerOptions.Kind = MarkerKind.Circle; // Add markers for better visualization
            }

            // Set label text pattern to show currency


            // Add series to chart
            chartControl7.Series.Add(series);

            // Step 3: Add a Title to the Chart
            ChartTitle chartTitle = new ChartTitle
            {
                Text = "صافي الربح حسب التاريخ",
                Font = new Font("Calibri", 12, FontStyle.Bold),
                Alignment = StringAlignment.Center
            };

            chartControl7.Titles.Clear();
            chartControl7.Titles.Add(chartTitle);

            // Step 4: Configure X and Y axis
            XYDiagram diagram = chartControl7.Diagram as XYDiagram;
            if (diagram != null)
            {
                // Configure X-axis
                diagram.AxisX.Title.Text = "التاريخ";
                diagram.AxisX.Title.Visibility = DevExpress.Utils.DefaultBoolean.True;
                diagram.AxisX.Label.Angle = -45; // Rotate labels for better readability
                diagram.AxisX.DateTimeScaleOptions.MeasureUnit = DateTimeMeasureUnit.Day;

                // Configure Y-axis
                diagram.AxisY.Title.Text = "صافي الربح (دج)";
                diagram.AxisY.Title.Visibility = DevExpress.Utils.DefaultBoolean.True;
                diagram.AxisY.Label.TextPattern = "{V} دج"; // Format Y-axis labels with currency
            }
        }

        private void VisualizeProfit()
        {
            // Clear any existing series in the chart
            chartControl8.Series.Clear();

            // Step 1: Calculate Net Profit
            var netProfitData = _context.SalesProfits // Assuming SalesProfit contains profits
               .Where(x => dtpFrom.Value <= x.Sale.Date && dtpTo.Value >= x.Sale.Date)

                .GroupBy(sp => sp.Sale.Date.Date) // Group by Date
                .Select(g => new
                {
                    Date = g.Key,
                    TotalSalesProfit = g.Sum(sp => (sp.Price - sp.Buy_Price) * sp.Quentity) // Sum of Profit per Date
                })
                .ToList();
            // Step 2: Create Series for Net Profit Visualization
            Series series = new Series("الربح", ViewType.Line);

            // Add Data Points for Net Profit
            foreach (var data in netProfitData)
            {
                series.Points.Add(new SeriesPoint(data.Date, data.TotalSalesProfit));
            }


            // Enable labels and set their text pattern
            series.LabelsVisibility = DevExpress.Utils.DefaultBoolean.True;
            series.Label.TextPattern = "{V} دج"; // Display net profit values in دج
                                                 // Customize Series Appearance

            LineSeriesView view = series.View as LineSeriesView;
            if (view != null)
            {
                view.Color = Color.Orange; // Set line color to orange
                view.LineMarkerOptions.Kind = MarkerKind.Circle; // Add markers for better visualization
            }

            // Set label text pattern to show currency


            // Add series to chart
            chartControl8.Series.Add(series);

            // Step 3: Add a Title to the Chart
            ChartTitle chartTitle = new ChartTitle
            {
                Text = "الربح حسب التاريخ",
                Font = new Font("Calibri", 12, FontStyle.Bold),
                Alignment = StringAlignment.Center
            };

            chartControl8.Titles.Clear();
            chartControl8.Titles.Add(chartTitle);

            // Step 4: Configure X and Y axis
            XYDiagram diagram = chartControl8.Diagram as XYDiagram;
            if (diagram != null)
            {
                // Configure X-axis
                diagram.AxisX.Title.Text = "التاريخ";
                diagram.AxisX.Title.Visibility = DevExpress.Utils.DefaultBoolean.True;
                diagram.AxisX.Label.Angle = -45; // Rotate labels for better readability
                diagram.AxisX.DateTimeScaleOptions.MeasureUnit = DateTimeMeasureUnit.Day;

                // Configure Y-axis
                diagram.AxisY.Title.Text = "الربح دج";
                diagram.AxisY.Title.Visibility = DevExpress.Utils.DefaultBoolean.True;
                diagram.AxisY.Label.TextPattern = "{V} دج"; // Format Y-axis labels with currency
            }
        }

        private void VisualizeTop10Products()
        {
            // Clear previous series
            chartControl5.Series.Clear();

            // Step 1: Retrieve the Top 10 Products Sold by Quantity
            var top15Products = _context.SalesDetails // Adjust table name as necessary
               .Where(x => dtpFrom.Value <= x.Sale.Date && dtpTo.Value >= x.Sale.Date)
                .GroupBy(s => s.Product.ProductName) // Group by Product Name
                .Select(g => new
                {
                    ProductName = g.Key,
                    TotalQuantity = g.Sum(s => s.Quentity) // Sum of Quantity Sold
                })
                .OrderByDescending(p => p.TotalQuantity) // Sort by Quantity Descending
                .Take(15) // Get the top 10 products
                .ToList();

            // Step 2: Create a Series for Visualization
            Series series = new Series("أفضل 15 منتجات مبيعًا حسب الكمية", ViewType.Bar);

            // Step 3: Add Data Points to the Series
            foreach (var product in top15Products)
            {
                series.Points.Add(new SeriesPoint(product.ProductName, product.TotalQuantity));
            }

            // Step 4: Customize Series Appearance
            series.LabelsVisibility = DevExpress.Utils.DefaultBoolean.True;
            BarSeriesLabel label = series.Label as BarSeriesLabel;
            if (label != null)
            {
                label.TextPattern = "{A}: {V}"; // Show Product Name (A) and Quantity Sold (V)
            }

            // Step 5: Add Series to ChartControl
            chartControl5.Series.Add(series);

            // Step 6: Add a Title to the Chart
            ChartTitle chartTitle = new ChartTitle();
            chartTitle.Text = "أفضل 15 منتجات مبيعًا حسب الكمية";
            chartTitle.Font = new Font("Calibri", 12, FontStyle.Bold);
            chartTitle.Alignment = StringAlignment.Center;

            chartControl5.Titles.Clear();
            chartControl5.Titles.Add(chartTitle);

            // Step 7: Optional - Customize the Chart Appearance
            chartControl5.Legend.Visibility = DevExpress.Utils.DefaultBoolean.False;
            ((XYDiagram)chartControl5.Diagram).AxisX.Title.Text = "المنتج";
            ((XYDiagram)chartControl5.Diagram).AxisX.Title.Visibility = DevExpress.Utils.DefaultBoolean.True;
            ((XYDiagram)chartControl5.Diagram).AxisY.Title.Text = "الكمية المباعة";
            ((XYDiagram)chartControl5.Diagram).AxisY.Title.Visibility = DevExpress.Utils.DefaultBoolean.True;
        }
        #endregion



        private void flowLayoutPanel10_Paint(object sender, PaintEventArgs e)
        {

        }

        private void btnSearch_Click(object sender, EventArgs e)
        {
            LoadChartData();
        }
    }
}
