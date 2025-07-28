using System.Data;
using Microsoft.EntityFrameworkCore;
using Store.ApplicationUI.Code.Helper;
using Store.ApplicationUI.Code.System;
using Store.ApplicationUI.Gui.LoadingGui;
using Store.ApplicationUI.Reports.VouchersReports;
using Store.Core.Entities.Vouchers;
using Store.Core.Interfaces;
using Store.Infrastructure.Data;

namespace Store.ApplicationUI.Gui.DeservedGui.VouchersGui
{
    public partial class VouchersUserControl : UserControl
    {
        private readonly ApplicationDbContext _context;
        private readonly MainForm _main;
        public IReceiptVoucherRepository _receiptVoucherRepository;
        private readonly ControlManager _controlManager;

        public VouchersUserControl(ApplicationDbContext context, MainForm main, IReceiptVoucherRepository receiptVoucherRepository, ControlManager controlManager)
        {
            InitializeComponent();
            _context = context;
            _main = main;
            _receiptVoucherRepository = receiptVoucherRepository;
            _controlManager = controlManager;
        }


        public async Task SetProductsToDgv()
        {


            if (rbReciptVoucher.Checked)
                DgvProducts.DataSource = await _receiptVoucherRepository.GetAllReciptVouchers();
            else
                DgvProducts.DataSource = await _receiptVoucherRepository.GetAllSentVouchers();
            lblEmptyData.Visible = dgvHelper.IsEmpty(DgvProducts);

            if (rbReciptVoucher.Checked)
                SetColumnsForRecipent();
            else
                SetColumnsForSender();
            //DgvProducts.DataSource = await Task.Run(() => productsRepository.GetAll(p => p.Category));
            //_context.SaveChanges();
            //var data = deservedsRepository.GetAll(x => x.DeservedType);
            //DgvProducts.DataSource = data;
        }


        // methodes 
        public async Task LoadData()
        {
            DgvProducts.DataSource = null;
            dtpTo.Value = DateTime.Now;
            //ShowLoading
            LoadingForm.Instance(_main).Show();
            if (await _context.Database.CanConnectAsync())
            {
                //Start Load Data

                // if its an admin or Normal user 

                await SetProductsToDgv();


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
            lblEmptyData.Visible = dgvHelper.IsEmpty(DgvProducts);
        }

        private void SetColumnsForRecipent()
        {
            //DgvProducts.DataSource = null; // Clear the DataGridView first

            //DgvProducts.DataSource = new List<RecieptVoucher>();
            DgvProducts.Columns[0].HeaderCell.Value = "اسم المستقبل";
            DgvProducts.Columns[1].HeaderCell.Value = "المبلغ المستقبل";
            DgvProducts.Columns[2].HeaderCell.Value = "تاريخ السند";
            DgvProducts.Columns[3].HeaderCell.Value = "وقت السند";
            DgvProducts.Columns[4].HeaderCell.Value = "من قبل";
            DgvProducts.Columns[5].HeaderCell.Value = "سبب السند";
            DgvProducts.Columns[6].HeaderCell.Value = "معرف السند";
        }
        private void SetColumnsForSender()
        {
            //DgvProducts.DataSource = null; // Clear the DataGridView first

            //DgvProducts.DataSource = new List<Core.Entities.Vouchers.SendVoucher>();

            DgvProducts.Columns[0].HeaderCell.Value = "اسم المرسل";
            DgvProducts.Columns[1].HeaderCell.Value = "المبلغ المرسل";
            DgvProducts.Columns[2].HeaderCell.Value = "تاريخ السند";
            DgvProducts.Columns[3].HeaderCell.Value = "وقت السند";
            DgvProducts.Columns[4].HeaderCell.Value = "الى السيد";
            DgvProducts.Columns[5].HeaderCell.Value = "سبب السند";
            DgvProducts.Columns[6].HeaderCell.Value = "معرف السند";
        }

        private async void btnAddDeserved_Click(object sender, EventArgs e)
        {
            ToasterHelper.PlayNotificationSound();
            AddVoucherForm AddVoucherForm = await _controlManager.GetFAsync<AddVoucherForm>();
            AddVoucherForm.ShowDialog();
        }

        private async void rbReciptVoucher_CheckedChanged(object sender, EventArgs e)
        {
            if (rbReciptVoucher.Checked)
                await SetProductsToDgv();
        }
        private async void rbSendVoucher_CheckedChanged(object sender, EventArgs e)
        {
            if (rbSendVoucher.Checked)
                await SetProductsToDgv();
        }

        private async void btnDeleteDeserved_Click(object sender, EventArgs e)
        {
            ToasterHelper.PlayNotificationSound();
            if (MsgHelper.ShowDeleteDialog())
            {
                if (rbReciptVoucher.Checked)
                {
                    ReceiptVoucher receipt = await _context.ReceiptVouchers.FirstOrDefaultAsync(x => x.Id.ToString() == DgvProducts.CurrentRow.Cells[6].Value.ToString());

                    if (receipt != null)
                        _context.Remove(receipt);

                }
                else
                {
                    Core.Entities.Vouchers.SendVoucher send = await _context.SendVouchers.FirstOrDefaultAsync(x => x.Id.ToString() == DgvProducts.CurrentRow.Cells[7].Value.ToString());

                    if (send != null)
                        _context.Remove(send);
                }
                await _context.SaveChangesAsync();
                Code.Helper.ToasterHelper.ShowDeletedToast();

                await SetProductsToDgv();

            }
        }

        private async void btnEditDeserved_Click(object sender, EventArgs e)
        {
            ToasterHelper.PlayNotificationSound();
            if (DgvProducts.Rows.Count > 0)
            {
                AddVoucherForm AddVoucherForm = await _controlManager.GetFAsync<AddVoucherForm>();

                await AddVoucherForm.SetDataToEdit(
                        DgvProducts.CurrentRow.Cells[0].Value.ToString(),
                        DgvProducts.CurrentRow.Cells[1].Value.ToString(),
                        DgvProducts.CurrentRow.Cells[5].Value.ToString(),
                        rbReciptVoucher.Checked,
                        DgvProducts.CurrentRow.Cells[6].Value.ToString(),
                        Convert.ToDateTime(DgvProducts.CurrentRow.Cells[2].Value),
                        DgvProducts.CurrentRow.Cells[4].Value.ToString()
                    );

                AddVoucherForm.ShowDialog();


            }
        }

        private async void button1_Click(object sender, EventArgs e)
        {
            ToasterHelper.PlayNotificationSound();
            if (MsgHelper.ShowDeleteDialog())
            {
                for (int i = 0; i < DgvProducts.Rows.Count; i++)
                {
                    if (rbReciptVoucher.Checked)
                    {
                        ReceiptVoucher receipt = await _context.ReceiptVouchers.FirstOrDefaultAsync(x => x.Id.ToString() == DgvProducts.CurrentRow.Cells[6].Value.ToString());

                        if (receipt != null)

                            _context.Remove(receipt);
                    }
                    else
                    {
                        Core.Entities.Vouchers.SendVoucher send = await _context.SendVouchers.FirstOrDefaultAsync(x => x.Id.ToString() == DgvProducts.CurrentRow.Cells[7].Value.ToString());

                        if (send != null)

                            _context.Remove(send);
                    }
                    await _context.SaveChangesAsync();
                    await SetProductsToDgv();

                }
            }
        }

        private async void button2_Click(object sender, EventArgs e)
        {
            ToasterHelper.PlayNotificationSound();
            if (rbReciptVoucher.Checked)
            {
                try
                {
                    if (DgvProducts.SelectedRows.Count > 0)
                    {
                        DataTable DetailsTable = await FactureHelper.GetVoucherRecieptDataTableAsync(Convert.ToInt32(DgvProducts.CurrentRow.Cells[6].Value.ToString()));
                        Reports.VouchersReports.RecieptVoucher RecieptVoucher = _controlManager.GetR<RecieptVoucher>();
                        RecieptVoucher.DataSource = DetailsTable;


                        Reports.ReportPerviwGui.PerviweForm xtraForm1 = _controlManager.GetF<Reports.ReportPerviwGui.PerviweForm>();
                        xtraForm1.LoadReport(RecieptVoucher);
                        xtraForm1.ShowDialog();
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
                    if (DgvProducts.SelectedRows.Count > 0)
                    {
                        DataTable DetailsTable = await FactureHelper.GetVoucherSenderDataTableAsync(Convert.ToInt32(DgvProducts.CurrentRow.Cells[6].Value.ToString()));
                        Reports.VouchersReports.SendVoucher SendVoucher = _controlManager.GetR<Reports.VouchersReports.SendVoucher>();
                        SendVoucher.DataSource = DetailsTable;



                        Reports.ReportPerviwGui.PerviweForm xtraForm1 = _controlManager.GetF<Reports.ReportPerviwGui.PerviweForm>();
                        xtraForm1.LoadReport(SendVoucher);
                        xtraForm1.ShowDialog();
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

        private async void btnSearch_Click(object sender, EventArgs e)
        {
            txtSearch.Text = txtSearch.Text.Replace("\r\n", "");
            if (rbReciptVoucher.Checked)
                DgvProducts.DataSource = await _context.ReceiptVouchers.Where
                    (x => x.From == txtSearch.Text || x.ReciverName == txtSearch.Text
                    || (x.Date >= dtpFrom.Value && x.Date <= dtpTo.Value)).ToListAsync();
            else
                DgvProducts.DataSource = await _context.SendVouchers.Where
                    (x => x.To == txtSearch.Text || x.SenderName == txtSearch.Text
                    || (x.Date >= dtpFrom.Value && x.Date <= dtpTo.Value)).ToListAsync();

            lblEmptyData.Visible = dgvHelper.IsEmpty(DgvProducts);
            if (rbReciptVoucher.Checked)
                SetColumnsForRecipent();
            else
                SetColumnsForSender();
        }
    }
}
