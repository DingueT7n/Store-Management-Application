using System.Data;
using System.Globalization;
using Microsoft.EntityFrameworkCore;
using Store.ApplicationUI.Code.Helper;
using Store.ApplicationUI.Code.System;
using Store.ApplicationUI.Gui.LoadingGui;
using Store.Core.Entities.Buys;
using Store.Core.Interfaces;
using Store.Infrastructure.Data;

namespace Store.ApplicationUI.Gui.BuysGui.BuysReportsGui
{
    public partial class BuysReportsUserControl : UserControl
    {

        private readonly ApplicationDbContext _context;
        private readonly ControlManager _controlManager;
        public readonly IBuysRepository? buysRepository;
        private readonly MainForm _main;

        public BuysReportsUserControl(MainForm mainForm, ApplicationDbContext context, ControlManager controlManager, IBuysRepository buysRepository)
        {
            InitializeComponent();
            _main = mainForm;
            _context = context;
            _controlManager = controlManager;
            this.buysRepository = buysRepository;
            LoadData();

        }

        public async void SetProductsToDgv(int skip)
        {
            ////DgvBuys.DataSource = await Task.Run(() => productsRepository.GetAll(p => p.Category));
            //var CustomerMoneyList = _context.CustomersReports.
            //    Include(x => x.Customer).Include(x => x.Sale)
            //    .ToList();

            DgvBuys.DataSource = new List<BuyDetailDto>();
            var data = await buysRepository.GetAllBuysWithDetails(Properties.Settings.Default.NoOfDataInDgvs, skip);
            DgvBuys.DataSource = data.result;
            double value = data.Count / Convert.ToDouble(Properties.Settings.Default.NoOfDataInDgvs);
            int PageValue = Convert.ToInt32(Math.Ceiling(value));
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


        }


        public async void LoadData()
        {

            dtpTo.Value = DateTime.Now;

            //ShowLoading
            LoadingForm.Instance(_main).Show();
            if (await buysRepository.IsConnectedAsync())
            {
                //Start Load Data

                // if its an admin or Normal user 

                SetProductsToDgv(0);
                SetColumns();
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
            lblEmptyData.Visible = dgvHelper.IsEmpty(DgvBuys);
        }

        private void SetColumns()
        {
            //DgvBuys.Columns[0].HeaderCell.Value = "المعرف";



            DgvBuys.Columns[0].HeaderCell.Value = "معرف الفاتورة";
            DgvBuys.Columns[1].HeaderCell.Value = "اسم المورد";
            DgvBuys.Columns[2].HeaderCell.Value = "التاريخ";
            DgvBuys.Columns[3].HeaderCell.Value = "الوقت";
            DgvBuys.Columns[4].HeaderCell.Value = "اسم المنتج";
            DgvBuys.Columns[5].HeaderCell.Value = "الكمية";
            DgvBuys.Columns[6].HeaderCell.Value = "سعر المنتج";
            DgvBuys.Columns[7].HeaderCell.Value = "التخفيض";
            DgvBuys.Columns[8].HeaderCell.Value = "السعر الاجمالي";
            DgvBuys.Columns[9].HeaderCell.Value = "المشتري";
            DgvBuys.Columns[10].HeaderCell.Value = "حسبة الفاتورة";
            DgvBuys.Columns[11].HeaderCell.Value = "المدفوع";
            DgvBuys.Columns[12].HeaderCell.Value = "الباقي";


            DgvBuys.Columns[3].Width = 50;
            //DgvBuys.Columns[6].Visible = false;
            //DgvBuys.Columns[7].Visible = false;
            //DgvBuys.Columns[4].Visible = false;



        }

        private async void btnSearch_Click(object sender, EventArgs e)
        {
            ToasterHelper.PlayNotificationSound();
            txtSearch.Text = txtSearch.Text.Replace("\r\n", "");

            int take = Properties.Settings.Default.NoOfDataInDgvs;
            int selectedi = cmbpagination.SelectedIndex;

            if (selectedi == -1)
            {
                selectedi = 0;

            }
            int skip = selectedi * take;
            BuyDetailDtoResult a = new BuyDetailDtoResult();
            DgvBuys.DataSource = new List<BuyDetailDto>();
            if (rbBoth.Checked)
            {
                a = await buysRepository.SearchBoth(txtSearch.Text, dtpFrom.Value, dtpTo.Value, take, skip);
            }
            else if (rbSupplierAndOrder.Checked)
            {
                a = await buysRepository.SearchOnlySupplier(txtSearch.Text, take, skip);
            }
            else
            {
                a = await buysRepository.SearchBuysByDate(dtpFrom.Value, dtpTo.Value, take, skip);
            }

            DgvBuys.DataSource = a.result;

            lblEmptyData.Visible = dgvHelper.IsEmpty(DgvBuys);
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
            PaginationHide();
        }
        void PaginationHide()
        {
            btnNext.Enabled = cmbpagination.SelectedIndex < cmbpagination.Items.Count - 1 && !dgvHelper.IsEmpty(DgvBuys);
            btnPrev.Enabled = cmbpagination.SelectedIndex > 0 && !dgvHelper.IsEmpty(DgvBuys);
            cmbpagination.Enabled = !dgvHelper.IsEmpty(DgvBuys);
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

        private async void btnExportCustomer_Click(object sender, EventArgs e)
        {
            try
            {
                ToasterHelper.PlayNotificationSound();
                if (DgvBuys.SelectedRows.Count > 0)
                {
                    DataTable buyDetailsTable = await FactureHelper.GetBuyDetailsDataTableAsync(Convert.ToInt32(DgvBuys.CurrentRow.Cells[0].Value.ToString()));
                    Reports.BuysReports.buy8cm buy8cm = _controlManager.GetR<Reports.BuysReports.buy8cm>();
                    buy8cm.DataSource = buyDetailsTable;
                    Reports.ReportPerviwGui.PerviweForm perv = Reports.ReportPerviwGui.PerviweForm.Instance(buy8cm);
                    perv.Show();
                }
            }
            catch (Exception)
            {

                throw;
            }
        }

        private async void button1_Click(object sender, EventArgs e)
        {
            try
            {
                ToasterHelper.PlayNotificationSound();
                if (DgvBuys.SelectedRows.Count > 0)
                {
                    DataTable buyDetailsTable = await FactureHelper.GetBuyReportDataTableAsync(dtpFrom.Value, dtpTo.Value);
                    Reports.BuysReports.buyReportsInPeriod buyReportsInPeriod = _controlManager.GetR<Reports.BuysReports.buyReportsInPeriod>();
                    buyReportsInPeriod.DataSource = buyDetailsTable;
                    buyReportsInPeriod.lbldateFrom.Text = dtpFrom.Value.ToString("yyyy-MM-dd", CultureInfo.InvariantCulture);
                    buyReportsInPeriod.lblDateTo.Text = dtpTo.Value.ToString("yyyy-MM-dd", CultureInfo.InvariantCulture);
                    Reports.ReportPerviwGui.PerviweForm perv = Reports.ReportPerviwGui.PerviweForm.Instance(buyReportsInPeriod);

                    perv.Show();
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
                ToasterHelper.PlayNotificationSound();
                if (DgvBuys.SelectedRows.Count > 0)
                {
                    DataTable buyDetailsTable = await FactureHelper.GetBuyDetailsDataTableAsync(Convert.ToInt32(DgvBuys.CurrentRow.Cells[0].Value.ToString()));
                    Reports.BuysReports.buyA4 buyA4 = _controlManager.GetR<Reports.BuysReports.buyA4>();
                    buyA4.DataSource = buyDetailsTable;
                    Reports.ReportPerviwGui.PerviweForm perv = Reports.ReportPerviwGui.PerviweForm.Instance(buyA4);
                    perv.Show();
                }
            }
            catch (Exception)
            {

                throw;
            }
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
                for (int i = 0; i < DgvBuys.Rows.Count; i++)
                {
                    await buysRepository.DeleteAsync(DgvBuys.Rows[i].Cells[0].Value.ToString());
                }
            }
            Code.Helper.ToasterHelper.ShowDeletedToast();

            LoadData();


        }

        private async void btnDeleteReportsInPeriod_Click(object sender, EventArgs e)
        {
            ToasterHelper.PlayNotificationSound();
            if (MsgHelper.ShowDeleteDialog())
            {
                try
                {
                    var query = await _context.Buys
                        .Where(x => dtpFrom.Value <= x.Date && x.Date <= dtpTo.Value)
                        .ToListAsync();

                    if (query.Any())
                    {
                        _context.Buys.RemoveRange(query);
                        await _context.SaveChangesAsync();
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

        private async void btnDeleteAllReports_Click(object sender, EventArgs e)
        {
            ToasterHelper.PlayNotificationSound();
            if (MsgHelper.ShowDeleteDialog())
            {
                try
                {
                    await _context.Database.ExecuteSqlRawAsync($"DELETE FROM [Buys]");
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


        private async void button3_Click(object sender, EventArgs e)
        {
            var lastBuy = await _context.BuyDetails

                  .Include(x => x.Buy)
                  .Include(x => x.Product)
                  .Include(x => x.Supplier).
                  OrderByDescending(x => x.Buy.Id)
                  .Select(bd => new BuyDetailDto
                  {
                      Order_ID = bd.Order_ID,
                      Date = bd.Buy.Date,
                      Time = bd.Buy.Time,
                      User_Name = bd.Buy.User_Name,
                      TotalFacture = bd.Buy.Total,
                      PaidUp = bd.Buy.PaidUP,
                      Remain = bd.Buy.Remain,
                      SupplierName = bd.Supplier.SupplierName, // Assuming `Name` is the property for the supplier's name
                      ProductName = bd.Product.ProductName,   // Assuming `Name` is the property for the product's name
                      Quantity = bd.Quentity,
                      PriceWithTax = bd.PriceWithTax,
                      TotalPrice = bd.Total,
                      Discount = bd.Discount,
                  })
                  .ToListAsync();





            ExportExcel(lastBuy);

        }
        private void ExportExcel(List<Core.Entities.Buys.BuyDetailDto> data)
        {

            DataTable dataTable = new DataTable();


            using (var reader = FastMember.ObjectReader.Create(data))
            {
                dataTable.Load(reader);
            }


            dataTable = arrangedDataTable(dataTable);


            ExcelHelper.Export(dataTable, $"AllBuys {data.Count}");
        }
        private DataTable arrangedDataTable(DataTable dataTable)
        {

            dataTable.Columns["Order_ID"].SetOrdinal(0);
            dataTable.Columns["Order_ID"].ColumnName = "معرف الفاتورة";

            dataTable.Columns["SupplierName"].SetOrdinal(1);
            dataTable.Columns["SupplierName"].ColumnName = "اسم المورد";


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
            dataTable.Columns["User_Name"].ColumnName = "المشتري";


            dataTable.Columns["TotalFacture"].SetOrdinal(10);
            dataTable.Columns["TotalFacture"].ColumnName = "حسبة الفاتورة";


            dataTable.Columns["PaidUp"].SetOrdinal(11);
            dataTable.Columns["PaidUp"].ColumnName = "المدفوع";

            dataTable.Columns["Remain"].SetOrdinal(12);
            dataTable.Columns["Remain"].ColumnName = "الباقي";
            return dataTable;
        }
    }
}
