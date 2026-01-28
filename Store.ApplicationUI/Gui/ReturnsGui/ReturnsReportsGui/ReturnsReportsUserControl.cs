using Microsoft.EntityFrameworkCore;
using Store.ApplicationUI.Code.Helper;
using Store.ApplicationUI.Gui.LoadingGui;
using Store.Core.Interfaces;
using Store.Infrastructure.Data;

namespace Store.ApplicationUI.Gui.ReturnsGui.ReturnsReportsGui
{
    public partial class ReturnsReportsUserControl : UserControl
    {
        private readonly MainForm _main;
        private readonly ApplicationDbContext _context;
        public readonly IReturnsRepository returnRepository;

        public ReturnsReportsUserControl(MainForm main, ApplicationDbContext context, IBuysRepository buysRepository, IReturnsRepository returnsRepository)
        {
            InitializeComponent();
            _main = main;
            _context = context;
            returnRepository = returnsRepository;
        }

        public async void SetProductsToDgv(int type)
        {
            ////DgvSales.DataSource = await Task.Run(() => productsRepository.GetAll(p => p.Category));
            //var CustomerMoneyList = MainForm.Context.CustomersReports.
            //    Include(x => x.Customer).Include(x => x.Sale)
            //    .ToList();
            var data = returnRepository.GetAllReturnsWithDetails(type);
            DgvSales.DataSource = data.result;



        }
        void RefreshDgv()
        {
            if (rbRefundAll.Checked)
            {
                SetProductsToDgv(0);
                SetColumns(0);
            }
            else if (rbRefundBuys.Checked)
            {
                SetProductsToDgv(2);
                SetColumns(2);
            }
            else
            {
                SetProductsToDgv(1);
                SetColumns(1);
            }
            lblEmptyData.Visible = dgvHelper.IsEmpty(DgvSales);
        }
        public async Task LoadData()
        {

            dtpTo.Value = DateTime.Now;
            //ShowLoading
            LoadingForm.Instance(_main).Show();
            if (await returnRepository.IsConnectedAsync())
            {
                //Start Load Data

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

        private void SetColumns(int type)
        {
            //DgvSales.Columns[0].HeaderCell.Value = "المعرف"; ""    



            DgvSales.Columns[0].HeaderCell.Value = "معرف الفاتورة";
            DgvSales.Columns[1].HeaderCell.Value = "تاريخ الفاتورة";
            DgvSales.Columns[2].HeaderCell.Value = "اسم العميل";
            DgvSales.Columns[3].HeaderCell.Value = "اسم المورد";
            DgvSales.Columns[4].HeaderCell.Value = "تاريخ الارجاع";
            DgvSales.Columns[5].HeaderCell.Value = "الوقت";
            DgvSales.Columns[6].HeaderCell.Value = "البائع";
            DgvSales.Columns[7].HeaderCell.Value = "اسم المنتج";
            DgvSales.Columns[8].HeaderCell.Value = "الكمية";
            DgvSales.Columns[9].HeaderCell.Value = "سعر المنتج";
            DgvSales.Columns[10].HeaderCell.Value = "السعر الاجمالي";
            DgvSales.Columns[11].HeaderCell.Value = "قيمة الضريبة";
            DgvSales.Columns[12].HeaderCell.Value = "السعر مع الضريبة";
            DgvSales.Columns[13].HeaderCell.Value = "حسبة الفاتورة";
            DgvSales.Columns[14].HeaderCell.Value = "المدفوع";
            DgvSales.Columns[15].HeaderCell.Value = "الباقي";

            if (type == 1)
            {
                DgvSales.Columns[3].Visible = false;
                DgvSales.Columns[2].Visible = true;
            }
            else if (type == 2)
            {
                DgvSales.Columns[2].Visible = false;
                DgvSales.Columns[3].Visible = true;
            }
            else
            {
                DgvSales.Columns[2].Visible = true;
                DgvSales.Columns[3].Visible = true;
            }
            DgvSales.Columns[8].Width = 50;
            DgvSales.Columns[12].Visible = false;

            //DgvSales.Columns[6].Visible = false;
            //DgvSales.Columns[7].Visible = false;
            //DgvSales.Columns[4].Visible = false;



        }

        private void rbRefundSales_CheckedChanged(object sender, EventArgs e)
        {
            RefreshDgv();
        }

        private void rbRefundBuys_CheckedChanged(object sender, EventArgs e)
        {
            RefreshDgv();
        }
        private void rbRefundAll_CheckedChanged(object sender, EventArgs e)
        {
            RefreshDgv();
        }
        private void btnSearch_Click(object sender, EventArgs e)
        {
            txtSearch.Text = txtSearch.Text.Replace("\r\n", "").Trim();
            int type = rbRefundBuys.Checked ? 2 : 1;
            if (rbRefundAll.Checked) type = 0;

            if (rbDateSearch.Checked)
            {
                var data = returnRepository.SearchBoth("", dtpFrom.Value, dtpTo.Value, type);
                DgvSales.DataSource = data.result;
            }
            else if (rbBoth.Checked)
            {
                var data = returnRepository.SearchBoth(txtSearch.Text, dtpFrom.Value, dtpTo.Value, type);
                DgvSales.DataSource = data.result;
            }
            lblEmptyData.Visible = dgvHelper.IsEmpty(DgvSales);
        }

        private async void button2_Click(object sender, EventArgs e)
        {
            try
            {
                ToasterHelper.PlayNotificationSound();

                if (MsgHelper.ShowDeleteDialog())
                {
                    List<int> idsToDelete = new List<int>();

                    // Collect IDs from column 0 (Invoice Id)
                    foreach (DataGridViewRow row in DgvSales.Rows)
                    {
                        if (row.Cells[0].Value != null && int.TryParse(row.Cells[0].Value.ToString(), out int id))
                        {
                            idsToDelete.Add(id);
                        }
                    }

                    if (idsToDelete.Any())
                    {
                        // Fetch all entities at once
                        var entitiesToDelete = await _context.Returns
                            .Where(x => idsToDelete.Contains(x.Id))
                            .ToListAsync();

                        if (entitiesToDelete.Any())
                        {
                            _context.Returns.RemoveRange(entitiesToDelete);
                            await _context.SaveChangesAsync(); // one database call
                        }
                    }

                    Code.Helper.ToasterHelper.ShowDeletedToast();

                    // Refresh DataGridView
                    DgvSales.DataSource = null;
                    RefreshDgv();  // optional, reloads data if needed
                }
            }
            catch (Exception ex)
            {
                ToasterHelper.ShowErrorHappened(ex.Message);
                throw;
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
