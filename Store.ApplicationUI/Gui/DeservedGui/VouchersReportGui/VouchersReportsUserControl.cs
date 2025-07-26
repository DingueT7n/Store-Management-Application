using System.Data;
using Microsoft.EntityFrameworkCore;
using Store.ApplicationUI.Code.Helper;
using Store.ApplicationUI.Gui.LoadingGui;
using Store.ApplicationUI.Reports.VouchersReports;
using Store.Core.Entities.Vouchers;
using Store.Core.Interfaces;
using Store.Infrastructure.Data;

namespace Store.ApplicationUI.Gui.DeservedGui.VouchersReportGui
{
    public partial class VouchersReportsUserControl : UserControl
    {
        private readonly ApplicationDbContext _context;
        private readonly MainForm _main;
        private readonly IReceiptVoucherRepository _receiptVoucherRepository;

        public VouchersReportsUserControl(ApplicationDbContext context, MainForm main, IReceiptVoucherRepository receiptVoucherRepository)
        {
            InitializeComponent();
            _context = context;
            _main = main;
            _receiptVoucherRepository = receiptVoucherRepository;
        }

        public async void SetProductsToDgv(string barcode)
        {
            ////DgvSales.DataSource = await Task.Run(() => productsRepository.GetAll(p => p.Category));
            //var CustomerMoneyList = MainForm.Context.CustomersReports.
            //    Include(x => x.Customer).Include(x => x.Sale)
            //    .ToList();
            if (rbSendVoucher.Checked)
            {
                var data = await GetAllSendVouchers(barcode, dtpFrom.Value, dtpTo.Value);
                DgvSales.DataSource = data;
            }
            else
            {
                var data = await GetAllRecieptVouchers(barcode, dtpFrom.Value, dtpTo.Value);
                DgvSales.DataSource = data;
            }

        }

        private async Task<List<ReceiptVoucher>> GetAllRecieptVouchers(string barcode, DateTime value1, DateTime value2)
        {
            try
            {
                var allTransfers = _context.ReceiptVouchers
                      .AsQueryable();
                if (barcode != string.Empty) allTransfers = allTransfers.Where(x => x.ReciverName == barcode || x.From.Contains(barcode));

                allTransfers = allTransfers.Where(x => x.Date >= value1 && x.Date <= value2)
                     ;

                return await allTransfers.ToListAsync();
            }
            catch (Exception ex)
            {

                throw new Exception("Error retrieving the buyFactures", ex);
            }
        }

        private async Task<List<Core.Entities.Vouchers.SendVoucher>> GetAllSendVouchers(string barcode, DateTime value1, DateTime value2)
        {
            try
            {
                var allTransfers = _context.SendVouchers
                      .AsQueryable();
                if (barcode != string.Empty) allTransfers = allTransfers.Where(x => x.SenderName == barcode || x.To.Contains(barcode));

                allTransfers = allTransfers.Where(x => x.Date >= value1 && x.Date <= value2)
                     ;

                return await allTransfers.ToListAsync();
            }
            catch (Exception ex)
            {

                throw new Exception("Error retrieving the buyFactures", ex);
            }
        }

        void RefreshDgv()
        {
            ;

            SetColumns();
            SetProductsToDgv(txtSearch.Text);
            lblEmptyData.Visible = dgvHelper.IsEmpty(DgvSales);
        }
        public async void LoadData()
        {
            dtpTo.Value = DateTime.Now;

            //ShowLoading
            LoadingForm.Instance(_main).Show();
            if (await _receiptVoucherRepository.IsConnectedAsync())
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
                DgvSales.DataSource = new List<Core.Entities.Vouchers.SendVoucher>();
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
                DgvSales.DataSource = new List<RecieptVoucher>();

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
            txtSearch.Text = txtSearch.Text.Replace("\r\n", "");
            RefreshDgv();
        }

        private async void button2_Click(object sender, EventArgs e)
        {
            ToasterHelper.PlayNotificationSound();
            try
            {
                if (MsgHelper.ShowDeleteDialog())
                {
                    for (int i = 0; i <= DgvSales.Rows.Count - 1; i++)
                    {
                        var deleteedsend = new Core.Entities.Vouchers.SendVoucher();
                        var deleteedRefund = new ReceiptVoucher();
                        if (rbRecieptVoucher.Checked)
                        {
                            deleteedRefund = await _context.ReceiptVouchers.Where(x => x.Id == Convert.ToInt32(DgvSales.Rows[i].Cells[6].Value.ToString())).FirstOrDefaultAsync();
                            if (deleteedRefund != null)
                            {
                                _context.Remove(deleteedRefund);
                                await _context.SaveChangesAsync();
                            }
                        }
                        else
                        {
                            deleteedsend = await _context.SendVouchers.Where(x => x.Id == Convert.ToInt32(DgvSales.Rows[i].Cells[6].Value.ToString())).FirstOrDefaultAsync();
                            if (deleteedsend != null)
                            {
                                _context.Remove(deleteedsend);
                                await _context.SaveChangesAsync();
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

        private void txtSearch_KeyDown(object sender, KeyEventArgs e)
        {
            if (e.KeyCode == Keys.Enter)
            {
                btnSearch_Click(sender, e);
            }
        }
    }
}
