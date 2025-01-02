using System.Data;
using Store.ApplicationUI.Code.Helper;
using Store.ApplicationUI.Gui.LoadingGui;
using Store.Core.Entities.Vouchers;
using Store.Infrastructure.Data;
using Store.Infrastructure.Repositories;

namespace Store.ApplicationUI.Gui.DeservedGui.VouchersReportGui
{
    public partial class VouchersReportsUserControl : UserControl
    {
        private static MainForm? _main;
        private static ApplicationDbContext _contex;
        public static ReceiptVoucherRepository? repository;
        private static VouchersReportsUserControl? _UserControl;

        public VouchersReportsUserControl()
        {
            InitializeComponent();
        }
        public static bool CheckInstance()
        {
            return (_UserControl == null);
        }
        public static VouchersReportsUserControl Instance(MainForm main)
        {
            _main = main;
            // If the instance is null, create a new one and assign it to the static field
            if (CheckInstance())
            {
                _contex = new ApplicationDbContext();
                repository = new ReceiptVoucherRepository(_contex);

                _UserControl = new VouchersReportsUserControl();

            }

            // Return the singleton instance
            _UserControl.LoadData();
            return _UserControl;
        }
        public async void SetProductsToDgv(string barcode)
        {
            ////DgvSales.DataSource = await Task.Run(() => productsRepository.GetAll(p => p.Category));
            //var CustomerMoneyList = MainForm.Context.CustomersReports.
            //    Include(x => x.Customer).Include(x => x.Sale)
            //    .ToList();
            if (rbSendVoucher.Checked)
            {
                var data = GetAllSendVouchers(barcode, dtpFrom.Value, dtpTo.Value);
                DgvSales.DataSource = data;
            }
            else
            {
                var data = GetAllRecieptVouchers(barcode, dtpFrom.Value, dtpTo.Value);
                DgvSales.DataSource = data;
            }

        }

        private List<ReceiptVoucher> GetAllRecieptVouchers(string barcode, DateTime value1, DateTime value2)
        {
            try
            {
                var allTransfers = _contex.ReceiptVouchers
                      .AsEnumerable();
                if (barcode != string.Empty) allTransfers = allTransfers.Where(x => x.ReciverName == barcode || x.From.Contains(barcode));

                allTransfers = allTransfers.Where(x => x.Date >= value1 && x.Date <= value2)
                     ;

                return allTransfers.ToList();
            }
            catch (Exception ex)
            {

                throw new Exception("Error retrieving the buyFactures", ex);
            }
        }

        private List<SendVoucher> GetAllSendVouchers(string barcode, DateTime value1, DateTime value2)
        {
            try
            {
                var allTransfers = _contex.SendVouchers
                      .AsEnumerable();
                if (barcode != string.Empty) allTransfers = allTransfers.Where(x => x.SenderName == barcode || x.To.Contains(barcode));

                allTransfers = allTransfers.Where(x => x.Date >= value1 && x.Date <= value2)
                     ;

                return allTransfers.ToList();
            }
            catch (Exception ex)
            {

                throw new Exception("Error retrieving the buyFactures", ex);
            }
        }

        void RefreshDgv()
        {
            ;

            SetProductsToDgv(txtSearch.Text);
            SetColumns();
            lblEmptyData.Visible = dgvHelper.IsEmpty(DgvSales);
        }
        public async void LoadData()
        {
            dtpTo.Value = DateTime.Now;

            //ShowLoading
            LoadingForm.Instance(_main).Show();
            if (await Task.Run(() => repository.IsConnected()))
            {



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
            if (rbSendVoucher.Checked)
            {
                //DgvSales.Columns[0].HeaderCell.Value = "المعرف"; ""    
                DgvSales.Columns[0].HeaderCell.Value = "اسم المسؤول عن الصرف";
                DgvSales.Columns[1].HeaderCell.Value = "قيمة السند";
                DgvSales.Columns[2].HeaderCell.Value = "تاريخ العملية";
                DgvSales.Columns[3].HeaderCell.Value = "وقت العملية";
                DgvSales.Columns[4].HeaderCell.Value = "تم الصرف لـ";
                DgvSales.Columns[5].HeaderCell.Value = "السبب";
                DgvSales.Columns[6].HeaderCell.Value = "معرف سند الصرف";

            }
            else
            {
                DgvSales.Columns[0].HeaderCell.Value = "اسم المسؤول عن القبض";
                DgvSales.Columns[1].HeaderCell.Value = "قيمة السند";
                DgvSales.Columns[2].HeaderCell.Value = "تاريخ العملية";
                DgvSales.Columns[3].HeaderCell.Value = "وقت العملية";
                DgvSales.Columns[4].HeaderCell.Value = "تم القبض من";
                DgvSales.Columns[5].HeaderCell.Value = "السبب";
                DgvSales.Columns[6].HeaderCell.Value = "معرف سند القبض";
            }
            //DgvSales.Columns[8].Visible = false;
            //DgvSales.Columns[8].Visible = false;
            //DgvSales.Columns[4].Visible = false;

        }

        private void rbRecieptVoucher_CheckedChanged(object sender, EventArgs e)
        {
            RefreshDgv();
        }

        private void rbSendVoucher_CheckedChanged(object sender, EventArgs e)
        {
            RefreshDgv();
        }

        private void btnSearch_Click(object sender, EventArgs e)
        {
            RefreshDgv();
        }

        private void button2_Click(object sender, EventArgs e)
        {
            ToasterHelper.PlayNotificationSound();
            try
            {
                if (MsgHelper.ShowDeleteDialog())
                {
                    for (int i = 0; i <= DgvSales.Rows.Count - 1; i++)
                    {
                        var deleteedsend = new SendVoucher();
                        var deleteedRefund = new ReceiptVoucher();
                        if (rbRecieptVoucher.Checked)
                        {
                            deleteedRefund = _contex.ReceiptVouchers.Where(x => x.Id == Convert.ToInt32(DgvSales.Rows[i].Cells[6].Value.ToString())).FirstOrDefault();
                            if (deleteedRefund != null)
                            {
                                _contex.Remove(deleteedRefund);
                                _contex.SaveChanges();
                            }
                        }
                        else
                        {
                            deleteedsend = _contex.SendVouchers.Where(x => x.Id == Convert.ToInt32(DgvSales.Rows[i].Cells[6].Value.ToString())).FirstOrDefault();
                            if (deleteedsend != null)
                            {
                                _contex.Remove(deleteedsend);
                                _contex.SaveChanges();
                            }

                        }

                    }
                    Code.Helper.ToasterHelper.ShowDeletedToast();

                    DgvSales.DataSource = null;
                    RefreshDgv();
                }
            }
            catch (Exception)
            {
                throw;
            }
        }

        private async void btnExportCustomer_Click(object sender, EventArgs e)
        {
            if (rbRecieptVoucher.Checked)
            {
                try
                {
                    if (DgvSales.SelectedRows.Count > 0)
                    {
                        DataTable DetailsTable = await FactureHelper.GetVoucherRecieptDataTableAsync(Convert.ToInt32(DgvSales.CurrentRow.Cells[6].Value.ToString()));
                        Reports.VouchersReports.RecieptVoucher RecieptVoucher = new();
                        RecieptVoucher.DataSource = DetailsTable;
                        Reports.ReportPerviwGui.PerviweForm xtraForm1 = Reports.ReportPerviwGui.PerviweForm.Instance(RecieptVoucher);
                        xtraForm1.Show();
                    }
                }
                catch (Exception)
                {

                    throw;
                }
            }
            else
            {

                try
                {
                    if (DgvSales.SelectedRows.Count > 0)
                    {
                        DataTable DetailsTable = await FactureHelper.GetVoucherSenderDataTableAsync(Convert.ToInt32(DgvSales.CurrentRow.Cells[6].Value.ToString()));
                        Reports.VouchersReports.SendVoucher SendVoucher = new();
                        SendVoucher.DataSource = DetailsTable;
                        Reports.ReportPerviwGui.PerviweForm xtraForm1 = Reports.ReportPerviwGui.PerviweForm.Instance(SendVoucher);
                        xtraForm1.Show();
                    }
                }
                catch (Exception)
                {

                    throw;
                }
            }
        }
    }
}
