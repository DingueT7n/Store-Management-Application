using System.Data;
using Microsoft.EntityFrameworkCore;
using Store.ApplicationUI.Code.Helper;
using Store.ApplicationUI.Code.System;
using Store.ApplicationUI.Gui.LoadingGui;
using Store.Core.Entities.Caisses;
using Store.Core.Entities.Customers;
using Store.Core.Interfaces;
using Store.Infrastructure.Data;

namespace Store.ApplicationUI.Gui.CustomersGui.CustomerAccountGui
{
    public partial class CustomerAccountUserControl : UserControl
    {
        private readonly MainForm _main;
        private readonly ApplicationDbContext _context;
        private readonly ICustomerMoneyRepository _customerMoneyRepository;
        private readonly ControlManager _controlManager;

        public CustomerAccountUserControl(
       MainForm main,
       ApplicationDbContext context,
       ICustomerMoneyRepository customerMoneyRepository, ControlManager controlManager)
        {
            InitializeComponent();

            _main = main;
            _context = context;
            _customerMoneyRepository = customerMoneyRepository;
            _controlManager = controlManager;

        }
        public async Task SetDataToDgv()
        {
            //DgvِCustomer.DataSource = await Task.Run(() => productsRepository.GetAll(p => p.Category));
            DgvِCustomer.DataSource = new List<CustomerMoney>();
            var CustomerMoneyList = await _context.CustomersMoneys.
                Include(x => x.Customer).Include(x => x.Sale)
                .ToListAsync();
            var uniqueCustomerCount = CustomerMoneyList
                .Select(x => x.Customer.Id) // Replace CustomerId with the actual unique identifier property
                .Distinct()
                .Count();
            DgvِCustomer.DataSource = CustomerMoneyList;
            if (DgvِCustomer.Rows.Count > 0)
            {
                if (DgvِCustomer.SelectedRows.Count > 0)
                {
                    lblPayFacture.Text = $" فاتورة رقم {DgvِCustomer.CurrentRow.Cells[1].Value} الدين : {DgvِCustomer.CurrentRow.Cells[3].Value} دج";
                    lblPayAllDebts.Text = $"دج {CustomerMoneyList.Sum(x => x.Price)}";
                    lblTotalDebt.Text = $"مجموع الديون على العملاء:{CustomerMoneyList.Sum(x => x.Price)}";
                    lblTotalCustomers.Text = $"مجموع العملاء:{uniqueCustomerCount}";
                    lblTotalFactures.Text = $"مجموع الفواتير في الجدول:{DgvِCustomer.Rows.Count}";
                }
            }
        }


        // methodes 
        public async Task LoadData()
        {


            //ShowLoading
            LoadingForm.Instance(_main).Show();
            if (await _customerMoneyRepository.IsConnectedAsync())
            {
                //Start Load Data

                // if its an admin or Normal user 

                await SetDataToDgv();
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
            DgvِCustomer.Columns[0].HeaderCell.Value = "معرف العميل";
            DgvِCustomer.Columns[1].HeaderCell.Value = "معرف الفاتورة";
            DgvِCustomer.Columns[2].HeaderCell.Value = "اسم العميل";
            DgvِCustomer.Columns[3].HeaderCell.Value = "الدين المتبقي";
            DgvِCustomer.Columns[4].HeaderCell.Value = "تاريخ الفاتورة";
            DgvِCustomer.Columns[5].HeaderCell.Value = "تاريخ تذكير";
            DgvِCustomer.Columns[6].HeaderCell.Value = "وقت الفاتورة";
            DgvِCustomer.Columns[7].HeaderCell.Value = "البيع";
            DgvِCustomer.Columns[8].HeaderCell.Value = "العميل";
            DgvِCustomer.Columns[9].HeaderCell.Value = "معرف الحسبة";



            //DgvِCustomer.Columns[0].Visible = false;

            DgvِCustomer.Columns[7].Visible = false;
            DgvِCustomer.Columns[8].Visible = false;


        }
        async Task<Caisse> SetCaisse(decimal value)
        {
            //dgvProducts.Rows[i].Cells[0].Value.ToString()

            Caisse caisse = await _context.Caisses.FirstOrDefaultAsync((x => x.Id == Properties.Settings.Default.DefaultCaisseId));
            if (caisse is not null)
            {
                caisse.MoneyinCaisse += value;
            }
            return caisse;

        }
        CaisseDeposit SetCaisseDeposit(decimal value)
        {
            //dgvProducts.Rows[i].Cells[0].Value.ToString()


            var caisseDeposit = new CaisseDeposit
            {
                Caisse_ID = Properties.Settings.Default.DefaultCaisseId,
                Time = DateTime.Now.ToString("HH:mm:ss"),
                Date = DateTime.Now,
                Name = $"  {Properties.Settings.Default.UserName}  دين سابق بحساب ",
                Money = value,
                Reason = "دين لمبيعة",
                Type = "ايداع عن طريق استلام دين (مال ربحي )"
            };

            return caisseDeposit;

        }


        private async void btnSearch_Click(object sender, EventArgs e)
        {
            txtSearch.Text = txtSearch.Text.Replace("\r\n", "");

            DgvِCustomer.DataSource = await _customerMoneyRepository.SearchAll(txtSearch.Text);
            lblEmptyData.Visible = dgvHelper.IsEmpty(DgvِCustomer);
            txtSearch.Text = string.Empty;
        }

        private async void btnPay_Click(object sender, EventArgs e)
        {
            ToasterHelper.PlayNotificationSound();
            if (DgvِCustomer.SelectedRows.Count > 0 && !dgvHelper.IsEmpty(DgvِCustomer))
            {

                if (rbPayFacture.Checked)
                {
                    var v1 = DgvِCustomer.CurrentRow.Cells[1].Value?.ToString();
                    var v2 = DgvِCustomer.CurrentRow.Cells[0].Value?.ToString();
                    var v3 = DgvِCustomer.CurrentRow.Cells[3].Value?.ToString();
                    var v4 = DgvِCustomer.CurrentRow.Cells[2].Value?.ToString();
                    await _customerMoneyRepository.TransactionOfCustomerDebt(
                           v1,
                           v2,
                           v3,
                           v4,
                           DateTime.Now
                           );
                    _context.Update(await SetCaisse(_main.ConvertToFloat(DgvِCustomer.CurrentRow.Cells[3].Value?.ToString())));
                    await _context.SaveChangesAsync();

                    if (_main.ConvertToFloat(DgvِCustomer.CurrentRow.Cells[3].Value?.ToString()) > 0)
                    {
                        _context.Add(SetCaisseDeposit(_main.ConvertToFloat(DgvِCustomer.CurrentRow.Cells[3].Value?.ToString())));
                        await _context.SaveChangesAsync();
                    }
                    Code.Helper.ToasterHelper.ShowDebtAdded();

                }
                else if (rbPayPartialFacture.Checked)
                {
                    var v1 = DgvِCustomer.CurrentRow.Cells[1].Value?.ToString();
                    var v2 = DgvِCustomer.CurrentRow.Cells[0].Value?.ToString();
                    var v3 = DgvِCustomer.CurrentRow.Cells[3].Value?.ToString();
                    var v4 = DgvِCustomer.CurrentRow.Cells[2].Value?.ToString();
                    await _customerMoneyRepository.TransactionOfEditingCustomerDebt(
                           v1,
                           v2,
                           v3,
                           v4,
                          txtPayAmout.Text,
                          DateTime.Now
                          );
                    _context.Update(await SetCaisse(_main.ConvertToFloat(txtPayAmout.Text)));
                    await _context.SaveChangesAsync();

                    if (_main.ConvertToFloat(txtPayAmout.Text) > 0)
                    {
                        _context.Add(SetCaisseDeposit(_main.ConvertToFloat(txtPayAmout.Text)));
                        await _context.SaveChangesAsync();
                    }
                    Code.Helper.ToasterHelper.ShowDebtAdded();

                }
                else
                {
                    for (int i = 0; i < DgvِCustomer.Rows.Count; i++)
                    {
                        var row = DgvِCustomer.Rows[i];
                        await _customerMoneyRepository.TransactionOfCustomerDebt(
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
                            _context.Add(SetCaisseDeposit(_main.ConvertToFloat(row.Cells[3].Value?.ToString())));
                            await _context.SaveChangesAsync();
                        }

                    }
                    Code.Helper.ToasterHelper.ShowDebtAdded();

                }

                await LoadData();
            }

        }

        private async void btnRefresh_Click_1(object sender, EventArgs e)
        {
            await LoadData();
        }

        private async void btnExportCustomer_Click(object sender, EventArgs e)
        {
            try
            {
                ToasterHelper.PlayNotificationSound();
                if (DgvِCustomer.SelectedRows.Count > 0)
                {
                    DataTable CustomerAccountAccountDetailsTable = await FactureHelper.GetCustomerAccountDataTableAsync(Convert.ToInt32(DgvِCustomer.CurrentRow.Cells[0].Value.ToString()));
                    Reports.CustomersAccountReports.CustomersAccountReport custAccount = _controlManager.GetR<Reports.CustomersAccountReports.CustomersAccountReport>();
                    custAccount.DataSource = CustomerAccountAccountDetailsTable;
                    var a = CustomerAccountAccountDetailsTable.Rows.Count.ToString();
                    custAccount.lblTotalFactures.Text = a;


                    Reports.ReportPerviwGui.PerviweForm xtraForm1 = _controlManager.GetF<Reports.ReportPerviwGui.PerviweForm>();
                    xtraForm1.LoadReport(custAccount);
                    xtraForm1.ShowDialog();
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

        private async void button1_Click(object sender, EventArgs e)
        {
            try
            {
                ToasterHelper.PlayNotificationSound();
                if (DgvِCustomer.SelectedRows.Count > 0)
                {
                    DataTable saleDetailsTable = await FactureHelper.GetSellDetailsDataTableAsync(Convert.ToInt32(DgvِCustomer.CurrentRow.Cells[1].Value.ToString()));
                    Reports.sale8cm sale8Cm = _controlManager.GetR<Reports.sale8cm>();
                    sale8Cm.DataSource = saleDetailsTable;


                    Reports.ReportPerviwGui.PerviweForm xtraForm1 = _controlManager.GetF<Reports.ReportPerviwGui.PerviweForm>();
                    xtraForm1.LoadReport(sale8Cm);
                    xtraForm1.ShowDialog();
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
                if (DgvِCustomer.SelectedRows.Count > 0)
                {
                    DataTable ProfitDetailsTable = await FactureHelper.GetSellDetailsDataTableAsync(Convert.ToInt32(DgvِCustomer.CurrentRow.Cells[1].Value.ToString()));
                    Reports.SalesReports.salesA4 salesA4 = _controlManager.GetR<Reports.SalesReports.salesA4>();
                    salesA4.DataSource = ProfitDetailsTable;


                    Reports.ReportPerviwGui.PerviweForm xtraForm1 = _controlManager.GetF<Reports.ReportPerviwGui.PerviweForm>();
                    xtraForm1.LoadReport(salesA4);
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
