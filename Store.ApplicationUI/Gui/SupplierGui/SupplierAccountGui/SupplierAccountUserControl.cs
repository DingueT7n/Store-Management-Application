using System.Data;
using Microsoft.EntityFrameworkCore;
using Store.ApplicationUI.Code.Helper;
using Store.ApplicationUI.Code.System;
using Store.ApplicationUI.Gui.LoadingGui;
using Store.Core.Entities.Caisses;
using Store.Core.Entities.Suppliers;
using Store.Core.Interfaces;
using Store.Infrastructure.Data;

namespace Store.ApplicationUI.Gui.SupplierGui.SupplierAccountGui
{
    public partial class SupplierAccountUserControl : UserControl
    {
        private readonly MainForm _main;
        private readonly ApplicationDbContext _context;
        private readonly ISupplierMoneyRepository _supplierMoneyRepository;
        private readonly ControlManager _controlManager;

        public SupplierAccountUserControl(MainForm main, ApplicationDbContext context, ISupplierMoneyRepository supplierMoneyRepository
          , ControlManager controlManager)
        {
            InitializeComponent();
            _main = main;
            _context = context;
            _supplierMoneyRepository = supplierMoneyRepository;
            _controlManager = controlManager;
            LoadData();
        }
        public async void SetDataToDgv()
        {

            //DgvِCustomer.DataSource = await Task.Run(() => productsRepository.GetAll(p => p.Category));
            DgvِCustomer.DataSource = new List<SupplierMoney>();
            var SuppliersMoneyList = await _context.SuppliersMoneys.
                Include(x => x.Supplier).Include(x => x.Buy)
                .ToListAsync();
            var uniqueSupplierCount = SuppliersMoneyList
                .Select(x => x.Supplier.Id) // Replace CustomerId with the actual unique identifier property
                .Distinct()
                .Count();
            DgvِCustomer.DataSource = SuppliersMoneyList;
            if (DgvِCustomer.Rows.Count > 0)
            {
                if (DgvِCustomer.SelectedRows.Count > 0)
                {
                    lblPayFacture.Text = $" فاتورة رقم {DgvِCustomer.CurrentRow.Cells[1].Value} الدين : {DgvِCustomer.CurrentRow.Cells[3].Value} دج";
                    lblPayAllDebts.Text = $"دج {SuppliersMoneyList.Sum(x => x.Price)}";
                    lblTotalDebt.Text = $"مجموع الديون على الموردين:{SuppliersMoneyList.Sum(x => x.Price)}";
                    lblTotalCustomers.Text = $"مجموع الموردين:{uniqueSupplierCount}";
                    lblTotalFactures.Text = $"مجموع الفواتير في الجدول:{DgvِCustomer.Rows.Count}";
                }
            }
        }

        public async void LoadData()
        {


            //ShowLoading
            LoadingForm.Instance(_main).Show();
            if (await _supplierMoneyRepository.IsConnectedAsync())
            {
                //Start Load Data

                // if its an admin or Normal user 

                SetDataToDgv();
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
            lblEmptyData.Visible = dgvHelper.IsEmpty(DgvِCustomer);
        }

        private void SetColumns()
        {
            //DgvِCustomer.Columns[0].HeaderCell.Value = "المعرف";
            DgvِCustomer.Columns[0].HeaderCell.Value = "معرف المورد";
            DgvِCustomer.Columns[1].HeaderCell.Value = "معرف الفاتورة";
            DgvِCustomer.Columns[2].HeaderCell.Value = "اسم المورد";
            DgvِCustomer.Columns[3].HeaderCell.Value = "الدين المتبقي";
            DgvِCustomer.Columns[4].HeaderCell.Value = "تاريخ الفاتورة";
            DgvِCustomer.Columns[5].HeaderCell.Value = "وقت الفاتورة";
            DgvِCustomer.Columns[6].HeaderCell.Value = "تاريخ التذكير";
            DgvِCustomer.Columns[7].HeaderCell.Value = "الشراء";
            DgvِCustomer.Columns[8].HeaderCell.Value = "المورد";
            DgvِCustomer.Columns[9].HeaderCell.Value = "معرف الحسبة";



            //DgvِCustomer.Columns[0].Visible = false;
            //DgvِCustomer.Columns[1].Visible = false;
            DgvِCustomer.Columns[7].Visible = false;
            DgvِCustomer.Columns[8].Visible = false;
            //DgvِCustomer.Columns[9].Visible = false;



        }

        private void btnRefresh_Click(object sender, EventArgs e)
        {
            LoadData();
        }

        private async void btnSearch_Click(object sender, EventArgs e)
        {
            txtSearch.Text = txtSearch.Text.Replace("\r\n", "");
            DgvِCustomer.DataSource = await _supplierMoneyRepository.SearchAll(txtSearch.Text);
            lblEmptyData.Visible = dgvHelper.IsEmpty(DgvِCustomer);
            txtSearch.Text = string.Empty;
        }
        async Task<Caisse> SetCaisse(decimal value)
        {
            //dgvProducts.Rows[i].Cells[0].Value.ToString()

            Caisse caisse = await _context.Caisses.Where(x => x.Id == Properties.Settings.Default.DefaultCaisseId).FirstOrDefaultAsync();
            if (caisse is not null)
            {
                caisse.MoneyinCaisse -= value;
            }
            return caisse;
        }
        CaisseWithdraw SetCaisseWithdraw(decimal value, string suppname)
        {
            //dgvProducts.Rows[i].Cells[0].Value.ToString()


            var caisseWithdraw = new CaisseWithdraw
            {
                Caisse_ID = Properties.Settings.Default.DefaultCaisseId,
                Time = DateTime.Now.ToString("HH:mm:ss"),
                Date = DateTime.Now,
                Name = $"  {Properties.Settings.Default.UserName} دين للمورد {suppname} بحساب ",
                Money = value,
                Reason = "شراء بالفاتورة لمورد",
                Type = "سحب عن طريق شراء منتجات (مال مستثمر )"
            };

            return caisseWithdraw;

        }
        private async void btnPay_Click(object sender, EventArgs e)
        {
            ToasterHelper.PlayNotificationSound();
            if (DgvِCustomer.SelectedRows.Count > 0 && !dgvHelper.IsEmpty(DgvِCustomer))
            {
                if (rbPayFacture.Checked)
                {
                    try
                    {
                        // Validate DataGridView cell values
                        if (DgvِCustomer.CurrentRow == null)
                            throw new InvalidOperationException("No row is selected in the DataGridView.");

                        string orderId = DgvِCustomer.CurrentRow.Cells[1]?.Value?.ToString();
                        string supplierId = DgvِCustomer.CurrentRow.Cells[0]?.Value?.ToString();
                        string price = DgvِCustomer.CurrentRow.Cells[3]?.Value?.ToString();
                        string supplierName = DgvِCustomer.CurrentRow.Cells[2]?.Value?.ToString();

                        if (string.IsNullOrWhiteSpace(orderId) ||
                            string.IsNullOrWhiteSpace(supplierId) ||
                            string.IsNullOrWhiteSpace(price) ||
                            string.IsNullOrWhiteSpace(supplierName))
                        {
                            throw new InvalidOperationException("One or more required fields are empty.");
                        }

                        decimal parsedPrice = _main.ConvertToFloat(price);

                        // Start a transaction
                        using (var transaction = await _context.Database.BeginTransactionAsync())
                        {
                            try
                            {


                                // Perform supplier debt transaction
                                var transactionCompleted = await _supplierMoneyRepository.TransactionOfSupplierDebt(orderId, supplierId, price, supplierName, DateTime.Now);

                                // Update the caisse
                                if (transactionCompleted)
                                {
                                    var updatedCaisse = await SetCaisse(parsedPrice);
                                    _context.Update(updatedCaisse);
                                    await _context.SaveChangesAsync();
                                }
                                else
                                {
                                    ToasterHelper.ShowErrorHappened("العملية لم تكتمل");
                                }

                                // Add a caisse withdrawal if the price is greater than 0
                                if (parsedPrice > 0 && transactionCompleted)
                                {
                                    var caisseWithdraw = SetCaisseWithdraw(parsedPrice, supplierName);
                                    await _context.AddAsync(caisseWithdraw);
                                    await _context.SaveChangesAsync();
                                }

                                // Commit the transaction
                                await transaction.CommitAsync();
                            }
                            catch (Exception)
                            {
                                await transaction.RollbackAsync();

                                throw;
                            }
                        }
                    }
                    catch (Exception ex)
                    {
                        // Log the exception for debugging
                        // Console.WriteLine($"Error: {ex.Message}");
                        ToasterHelper.ShowErrorHappened(ex.Message);

                        throw; // Re-throw the exception for higher-level handling if necessary
                    }
                }
                else if (rbPayPartialFacture.Checked)
                {
                    using (var transaction = await _context.Database.BeginTransactionAsync())
                    {
                        try
                        {
                            var trancomp = await _supplierMoneyRepository.TransactionOfEditingSupplierDebt(
                           DgvِCustomer.CurrentRow.Cells[1].Value.ToString(),
                           DgvِCustomer.CurrentRow.Cells[0].Value.ToString(),
                           DgvِCustomer.CurrentRow.Cells[3].Value.ToString(),
                           DgvِCustomer.CurrentRow.Cells[2].Value.ToString(),
                          txtPayAmout.Text,
                          DateTime.Now
                          );
                            var caisse = await SetCaisse(_main.ConvertToFloat(txtPayAmout.Text));
                            _context.Update(caisse);
                            await _context.SaveChangesAsync();
                            if (_main.ConvertToFloat(txtPayAmout.Text) > 0)
                            {
                                await _context.AddAsync(SetCaisseWithdraw(_main.ConvertToFloat(txtPayAmout.Text),
                                   DgvِCustomer.CurrentRow.Cells[2].Value.ToString()));
                                await _context.SaveChangesAsync();
                            }
                            await transaction.CommitAsync();

                        }
                        catch (Exception)
                        {
                            await transaction.RollbackAsync();

                            throw;
                        }

                    }
                }
                else
                {
                    using (var transaction = await _context.Database.BeginTransactionAsync())
                    {
                        try
                        {
                            for (int i = 0; i < DgvِCustomer.Rows.Count; i++)
                            {
                                var row = DgvِCustomer.Rows[i];
                                await _supplierMoneyRepository.TransactionOfSupplierDebt(
                                     row.Cells[1].Value?.ToString(),
                                     row.Cells[0].Value?.ToString(),
                                     row.Cells[3].Value?.ToString(),
                                     row.Cells[2].Value?.ToString(),
                                     DateTime.Now
                                 );
                                _context.Update(await SetCaisse(_main.ConvertToFloat(row.Cells[3].Value?.ToString())));
                                await _context.SaveChangesAsync();
                                if (_main.ConvertToFloat(row.Cells[3].Value?.ToString()) > 0)
                                {
                                    _context.Add(SetCaisseWithdraw(
                                    _main.ConvertToFloat(row.Cells[3].Value?.ToString())
                                    , row.Cells[2].Value.ToString()));
                                    await _context.SaveChangesAsync();
                                }

                            }
                            await transaction.CommitAsync();

                        }
                        catch (Exception)
                        {
                            await transaction.RollbackAsync();

                            throw;
                        }
                    }
                }
                ToasterHelper.ShowDebtAdded();

                SetDataToDgv();
            }
        }

        private async void btnExportCustomer_Click(object sender, EventArgs e)
        {
            try
            {
                ToasterHelper.PlayNotificationSound();
                if (DgvِCustomer.SelectedRows.Count > 0)
                {
                    DataTable suplierAccountDetailsTable = await FactureHelper.GetSupplierAccountDataTableAsync(Convert.ToInt32(DgvِCustomer.CurrentRow.Cells[0].Value.ToString()));
                    Reports.SuppliersAccountsReports.SuppliersAccountsReports supAccount = _controlManager.GetR<Reports.SuppliersAccountsReports.SuppliersAccountsReports>();
                    supAccount.DataSource = suplierAccountDetailsTable;
                    var a = suplierAccountDetailsTable.Rows.Count.ToString();
                    supAccount.lblTotalFactures.Text = a;
                    Reports.ReportPerviwGui.PerviweForm xtraForm1 = Reports.ReportPerviwGui.PerviweForm.Instance(supAccount);
                    xtraForm1.Show();
                }
            }
            catch (Exception)
            {

                throw;
            }
        }

        private void txtPayAmout_KeyPress(object sender, KeyPressEventArgs e)
        {
            string currentText = (sender as TextBox)?.Text ?? string.Empty;


            char decimalSeparator = Properties.Settings.Default.DecimalSEP[0];


            if (!char.IsDigit(e.KeyChar) && e.KeyChar != decimalSeparator && e.KeyChar != (char)8)
            {
                e.Handled = true;
            }

            else if (e.KeyChar == decimalSeparator && currentText.Contains(decimalSeparator))
            {
                e.Handled = true;
            }
        }

        private void rbPayPartialFacture_CheckedChanged(object sender, EventArgs e)
        {
            txtPayAmout.Enabled = rbPayPartialFacture.Checked;

        }

        private void txtSearch_KeyDown(object sender, KeyEventArgs e)
        {
            if (e.KeyCode == Keys.Enter)
            {
                btnSearch_Click(sender, e);
            }
        }

        private async void button2_Click(object sender, EventArgs e)
        {
            try
            {
                ToasterHelper.PlayNotificationSound();
                if (DgvِCustomer.SelectedRows.Count > 0)
                {
                    DataTable buyDetailsTable = await FactureHelper.GetBuyDetailsDataTableAsync(Convert.ToInt32(DgvِCustomer.CurrentRow.Cells[1].Value.ToString()));
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

        private async void button1_Click(object sender, EventArgs e)
        {
            try
            {
                ToasterHelper.PlayNotificationSound();
                if (DgvِCustomer.SelectedRows.Count > 0)
                {
                    DataTable buyDetailsTable = await FactureHelper.GetBuyDetailsDataTableAsync(Convert.ToInt32(DgvِCustomer.CurrentRow.Cells[0].Value.ToString()));
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
    }
}
