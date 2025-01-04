using System.Data;
using System.Globalization;
using Microsoft.EntityFrameworkCore;
using Store.ApplicationUI.Code.Helper;
using Store.ApplicationUI.Gui.LoadingGui;
using Store.Core.Entities.Buys;
using Store.Infrastructure.Data;
using Store.Infrastructure.Repositories;

namespace Store.ApplicationUI.Gui.BuysGui.BuysReportsGui
{
    public partial class BuysReportsUserControl : UserControl
    {
        private static MainForm? _main;
        private static ApplicationDbContext _context;
        public static BuysRepository? buysRepository;
        private static BuysReportsUserControl? _buyReportsUserControl;
        public BuysReportsUserControl()
        {
            InitializeComponent();
        }
        public static bool CheckInstance()
        {
            return (_buyReportsUserControl == null);
        }
        public static BuysReportsUserControl Instance(MainForm main)
        {
            _main = main;
            // If the instance is null, create a new one and assign it to the static field
            _context = new ApplicationDbContext();
            if (CheckInstance())
            {

                buysRepository = new BuysRepository(_context);

                _buyReportsUserControl = new BuysReportsUserControl();

            }

            // Return the singleton instance
            _buyReportsUserControl.LoadData();
            return _buyReportsUserControl;
        }
        public async void SetProductsToDgv(int skip)
        {
            ////DgvBuys.DataSource = await Task.Run(() => productsRepository.GetAll(p => p.Category));
            //var CustomerMoneyList = _context.CustomersReports.
            //    Include(x => x.Customer).Include(x => x.Sale)
            //    .ToList();
            var data = buysRepository.GetAllBuysWithDetails(Properties.Settings.Default.NoOfDataInDgvs, skip);
            DgvBuys.DataSource = data.result;
            double value = data.Count / Convert.ToDouble(Properties.Settings.Default.NoOfDataInDgvs);
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
            //DgvBuys.DataSource = CustomerMoneyList;
            //if (DgvBuys.Rows.Count > 0)
            //{
            //    if (DgvBuys.SelectedRows.Count > 0)
            //    {
            //        //lblPayFacture.Text = $" فاتورة رقم {DgvBuys.Columns[7].HeaderCell.Value} الدين : {DgvBuys.Columns[1].HeaderCell.Value} دج";
            //        //lblPayAllDebts.Text = $"دج {CustomerMoneyList.Sum(x => x.Price)}";
            //        lblTotalDebt.Text = $"مجموع مدفوعات الموردين في الجدول:{CustomerMoneyList.Sum(x => x.Price)}";
            //        lblTotalCustomers.Text = $"مجموع الموردين:{uniqueCustomerCount}";

            //    }
            //}
        }

        public static void RefreshDgv()
        {
            //DgvBuys.DataSource = await Task.Run(() => productsRepository.GetAllProducts());
            _buyReportsUserControl.LoadData();
        }
        // methodes 
        public async void LoadData()
        {

            dtpTo.Value = DateTime.Now;

            //ShowLoading
            LoadingForm.Instance(_main).Show();
            if (await Task.Run(() => buysRepository.IsConnected()))
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

        private void btnSearch_Click(object sender, EventArgs e)
        {
            ToasterHelper.PlayNotificationSound();

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
                a = buysRepository.SearchBoth(txtSearch.Text, dtpFrom.Value, dtpTo.Value, take, skip);
            }
            else if (rbSupplierAndOrder.Checked)
            {
                a = buysRepository.SearchOnlySupplier(txtSearch.Text, take, skip);
            }
            else
            {
                a = buysRepository.SearchBuysByDate(dtpFrom.Value, dtpTo.Value, take, skip);
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
                    Reports.BuysReports.buy8cm buy8cm = new();
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
                    Reports.BuysReports.buyReportsInPeriod buyReportsInPeriod = new();
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
                    Reports.BuysReports.buyA4 buyA4 = new();
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

                    Buy buy = _context.Buys.FirstOrDefault(x => x.Id.ToString() == DgvBuys.Rows[i].Cells[0].Value.ToString());
                    _context.Remove(buy);
                    await _context.SaveChangesAsync();
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
                    var query = _context.Buys
                        .Where(x => dtpFrom.Value <= x.Date && x.Date <= dtpTo.Value)
                        .ToList();

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

        private void btnDeleteAllReports_Click(object sender, EventArgs e)
        {
            ToasterHelper.PlayNotificationSound();
            if (MsgHelper.ShowDeleteDialog())
            {
                try
                {
                    _context.Database.ExecuteSqlRaw($"DELETE FROM [Buys]");
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
