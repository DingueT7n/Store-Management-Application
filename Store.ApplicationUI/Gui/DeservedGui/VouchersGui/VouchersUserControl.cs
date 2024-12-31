using System.Data;
using Store.ApplicationUI.Code.Helper;
using Store.ApplicationUI.Gui.LoadingGui;
using Store.ApplicationUI.Reports.VouchersReports;
using Store.Core.Entities.Vouchers;
using Store.Infrastructure.Data;

namespace Store.ApplicationUI.Gui.DeservedGui.VouchersGui
{
    public partial class VouchersUserControl : UserControl
    {
        private static VouchersUserControl? _vouchersUserControl;
        private static MainForm? _main;
        private AddVoucherForm AddVoucherForm;

        private static ApplicationDbContext _context;
        public static Infrastructure.Repositories.ReceiptVoucherRepository? _receiptVoucherRepository;
        public VouchersUserControl()
        {
            InitializeComponent();
        }
        public static VouchersUserControl Instance(MainForm main)
        {
            _main = main;
            // If the instance is null, create a new one and assign it to the static field
            if (_vouchersUserControl == null)
            {
                _context = new ApplicationDbContext();

                _receiptVoucherRepository = new Infrastructure.Repositories.ReceiptVoucherRepository(_context);
                //categoryRepository = new CategorysRepository(_context);
                _vouchersUserControl = new VouchersUserControl();

            }

            // Return the singleton instance
            _vouchersUserControl.LoadData();
            return _vouchersUserControl;
        }
        public static bool CheckInstance()
        {
            return (_vouchersUserControl == null);
        }
        public async void SetProductsToDgv()
        {

            if (rbReciptVoucher.Checked)
                DgvProducts.DataSource = _receiptVoucherRepository.GetAllReciptVouchers();
            else
                DgvProducts.DataSource = _receiptVoucherRepository.GetAllSentVouchers();
            if (rbReciptVoucher.Checked)
                SetColumnsForRecipent();
            else
                SetColumnsForSender();

            lblEmptyData.Visible = dgvHelper.IsEmpty(DgvProducts);

            //DgvProducts.DataSource = await Task.Run(() => productsRepository.GetAll(p => p.Category));
            //_context.SaveChanges();
            //var data = deservedsRepository.GetAll(x => x.DeservedType);
            //DgvProducts.DataSource = data;
        }

        public static void RefreshDgv()
        {
            //DgvProducts.DataSource = await Task.Run(() => productsRepository.GetAllProducts());
            _vouchersUserControl.LoadData();
        }
        // methodes 
        public async void LoadData()
        {
            DgvProducts.DataSource = null;
            dtpTo.Value = DateTime.Now;
            //ShowLoading
            LoadingForm.Instance(_main).Show();
            if (await Task.Run(() => _context.Database.CanConnect()))
            {
                //Start Load Data

                // if its an admin or Normal user 

                SetProductsToDgv();


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
            DgvProducts.Columns[0].HeaderCell.Value = "اسم المرسل";
            DgvProducts.Columns[1].HeaderCell.Value = "المبلغ المرسل";
            DgvProducts.Columns[2].HeaderCell.Value = "تاريخ السند";
            DgvProducts.Columns[3].HeaderCell.Value = "وقت السند";
            DgvProducts.Columns[4].HeaderCell.Value = "الى السيد";
            DgvProducts.Columns[5].HeaderCell.Value = "سبب السند";
            DgvProducts.Columns[6].HeaderCell.Value = "معرف السند";
        }

        private void btnAddDeserved_Click(object sender, EventArgs e)
        {
            AddVoucherForm AddVoucherForm = AddVoucherForm.Instance(_main);
            AddVoucherForm.ShowDialog();
        }

        private void rbReciptVoucher_CheckedChanged(object sender, EventArgs e)
        {
            SetProductsToDgv();
        }
        private void rbSendVoucher_CheckedChanged(object sender, EventArgs e)
        {
            SetProductsToDgv();
        }

        private async void btnDeleteDeserved_Click(object sender, EventArgs e)
        {
            if (MsgHelper.ShowDeleteDialog())
            {
                if (rbReciptVoucher.Checked)
                {
                    ReceiptVoucher receipt = _context.ReceiptVouchers.FirstOrDefault(x => x.Id.ToString() == DgvProducts.CurrentRow.Cells[6].Value.ToString());

                    if (receipt != null)
                        _context.Remove(receipt);

                }
                else
                {
                    Core.Entities.Vouchers.SendVoucher send = _context.SendVouchers.FirstOrDefault(x => x.Id.ToString() == DgvProducts.CurrentRow.Cells[7].Value.ToString());

                    if (send != null)
                        _context.Remove(send);
                }
                await _context.SaveChangesAsync();
                Code.Helper.ToasterHelper.ShowDeletedToast();

                SetProductsToDgv();

            }
        }

        private void btnEditDeserved_Click(object sender, EventArgs e)
        {
            if (DgvProducts.Rows.Count > 0)
            {
                if (AddVoucherForm == null || AddVoucherForm.IsDisposed)
                {
                    AddVoucherForm = DeservedGui.VouchersGui.AddVoucherForm.Instance(_main);


                    AddVoucherForm.SetDataToEdit(
                        DgvProducts.CurrentRow.Cells[0].Value.ToString(),
                        DgvProducts.CurrentRow.Cells[1].Value.ToString(),
                        DgvProducts.CurrentRow.Cells[5].Value.ToString(),
                        rbReciptVoucher.Checked,
                        DgvProducts.CurrentRow.Cells[6].Value.ToString(),
                        Convert.ToDateTime(DgvProducts.CurrentRow.Cells[2].Value),
                        DgvProducts.CurrentRow.Cells[4].Value.ToString()
                    );

                    AddVoucherForm.Show();
                }
                else
                {
                    AddVoucherForm.Focus();
                }
            }
        }

        private async void button1_Click(object sender, EventArgs e)
        {
            if (MsgHelper.ShowDeleteDialog())
            {
                for (int i = 0; i < DgvProducts.Rows.Count; i++)
                {
                    if (rbReciptVoucher.Checked)
                    {
                        ReceiptVoucher receipt = _context.ReceiptVouchers.FirstOrDefault(x => x.Id.ToString() == DgvProducts.CurrentRow.Cells[6].Value.ToString());


                        _context.Remove(receipt);
                    }
                    else
                    {
                        Core.Entities.Vouchers.SendVoucher send = _context.SendVouchers.FirstOrDefault(x => x.Id.ToString() == DgvProducts.CurrentRow.Cells[7].Value.ToString());


                        _context.Remove(send);
                    }
                    await _context.SaveChangesAsync();
                    SetProductsToDgv();

                }
            }
        }

        private async void button2_Click(object sender, EventArgs e)
        {
            if (rbReciptVoucher.Checked)
            {
                try
                {
                    if (DgvProducts.SelectedRows.Count > 0)
                    {
                        DataTable DetailsTable = await FactureHelper.GetVoucherRecieptDataTableAsync(Convert.ToInt32(DgvProducts.CurrentRow.Cells[6].Value.ToString()));
                        Reports.VouchersReports.RecieptVoucher RecieptVoucher = new();
                        RecieptVoucher.DataSource = DetailsTable;
                        Reports.ReportPerviwGui.XtraForm1 xtraForm1 = new(RecieptVoucher);
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
                        Reports.VouchersReports.SendVoucher SendVoucher = new();
                        SendVoucher.DataSource = DetailsTable;
                        Reports.ReportPerviwGui.XtraForm1 xtraForm1 = new(SendVoucher);
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
}
