using System.Data;
using Microsoft.EntityFrameworkCore;
using Store.ApplicationUI.Code.Helper;
using Store.ApplicationUI.Gui.LoadingGui;
using Store.Core.Entities.Caisses;
using Store.Infrastructure.Data;
using Store.Infrastructure.Repositories;

namespace Store.ApplicationUI.Gui.CustomersGui.CustomerAccountGui
{
    public partial class CustomerAccountUserControl : UserControl
    {
        private static MainForm? _main;
        private static ApplicationDbContext _context;
        public static CustomerMoneyRepository? customersRepository;
        private static CustomerAccountUserControl? _customerAccountUserControl;
        public CustomerAccountUserControl()
        {
            InitializeComponent();
        }
        public static bool CheckInstance()
        {
            return (_customerAccountUserControl == null);

        }
        public static CustomerAccountUserControl Instance(MainForm main)
        {
            _main = main;
            // If the instance is null, create a new one and assign it to the static field
            if (CheckInstance())
            {
                _context = new ApplicationDbContext();

                customersRepository = new CustomerMoneyRepository(_context);

                _customerAccountUserControl = new CustomerAccountUserControl();

            }

            // Return the singleton instance
            _customerAccountUserControl.LoadData();

            return _customerAccountUserControl;
        }

        public async void SetDataToDgv()
        {
            //DgvِCustomer.DataSource = await Task.Run(() => productsRepository.GetAll(p => p.Category));
            var CustomerMoneyList = _context.CustomersMoneys.
                Include(x => x.Customer).Include(x => x.Sale)
                .ToList();
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

        public static void RefreshDgv()
        {
            //DgvِCustomer.DataSource = await Task.Run(() => productsRepository.GetAllProducts());
            _customerAccountUserControl.LoadData();
        }
        // methodes 
        public async void LoadData()
        {


            //ShowLoading
            LoadingForm.Instance(_main).Show();
            if (await Task.Run(() => customersRepository.IsConnected()))
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
        Caisse SetCaisse(decimal value)
        {
            //dgvProducts.Rows[i].Cells[0].Value.ToString()

            Caisse caisse = _context.Caisses.FirstOrDefault((x => x.Id == Properties.Settings.Default.DefaultCaisseId));
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
        private void btnRefresh_Click(object sender, EventArgs e)
        {
            LoadData();
        }

        private void btnSearch_Click(object sender, EventArgs e)
        {
            DgvِCustomer.DataSource = customersRepository.SearchAll(txtSearch.Text);
            lblEmptyData.Visible = dgvHelper.IsEmpty(DgvِCustomer);
            txtSearch.Text = string.Empty;
        }

        private void btnPay_Click(object sender, EventArgs e)
        {
            if (DgvِCustomer.SelectedRows.Count > 0 && !dgvHelper.IsEmpty(DgvِCustomer))
            {
                _context = new ApplicationDbContext();
                if (rbPayFacture.Checked)
                {
                    var v1 = DgvِCustomer.CurrentRow.Cells[1].Value?.ToString();
                    var v2 = DgvِCustomer.CurrentRow.Cells[0].Value?.ToString();
                    var v3 = DgvِCustomer.CurrentRow.Cells[3].Value?.ToString();
                    var v4 = DgvِCustomer.CurrentRow.Cells[2].Value?.ToString();
                    customersRepository.TransactionOfCustomerDebt(
                        v1,
                        v2,
                        v3,
                        v4,
                        DateTime.Now
                        );
                    _context.Update(SetCaisse(_main.ConvertToFloat(DgvِCustomer.CurrentRow.Cells[3].Value?.ToString())));
                    _context.Add(SetCaisseDeposit(_main.ConvertToFloat(DgvِCustomer.CurrentRow.Cells[3].Value?.ToString())));
                    _context.SaveChanges();

                }
                else if (rbPayPartialFacture.Checked)
                {
                    var v1 = DgvِCustomer.CurrentRow.Cells[1].Value?.ToString();
                    var v2 = DgvِCustomer.CurrentRow.Cells[0].Value?.ToString();
                    var v3 = DgvِCustomer.CurrentRow.Cells[3].Value?.ToString();
                    var v4 = DgvِCustomer.CurrentRow.Cells[2].Value?.ToString();
                    customersRepository.TransactionOfEditingCustomerDebt(
                        v1,
                        v2,
                        v3,
                        v4,
                       txtPayAmout.Text,
                       DateTime.Now
                       );
                    _context.Update(SetCaisse(_main.ConvertToFloat(txtPayAmout.Text)));
                    _context.Add(SetCaisseDeposit(_main.ConvertToFloat(txtPayAmout.Text)));
                    _context.SaveChanges();

                }
                else
                {
                    for (int i = 0; i < DgvِCustomer.Rows.Count; i++)
                    {
                        var row = DgvِCustomer.Rows[i];
                        customersRepository.TransactionOfCustomerDebt(
                            row.Cells[1].Value?.ToString(),
                            row.Cells[0].Value?.ToString(),
                            row.Cells[3].Value?.ToString(),
                            row.Cells[2].Value?.ToString(),
                            DateTime.Now
                        );
                        _context.Update(SetCaisse(_main.ConvertToFloat(row.Cells[3].Value?.ToString())));
                        _context.Add(SetCaisseDeposit(_main.ConvertToFloat(row.Cells[3].Value?.ToString())));
                        _context.SaveChanges();

                    }

                }

                LoadData();
            }

        }

        private void btnRefresh_Click_1(object sender, EventArgs e)
        {
            LoadData();
        }

        private async void btnExportCustomer_Click(object sender, EventArgs e)
        {
            try
            {
                if (DgvِCustomer.SelectedRows.Count > 0)
                {
                    DataTable CustomerAccountAccountDetailsTable = await FactureHelper.GetCustomerAccountDataTableAsync(Convert.ToInt32(DgvِCustomer.CurrentRow.Cells[0].Value.ToString()));
                    Reports.CustomersAccountReports.CustomersAccountReport custAccount = new();
                    custAccount.DataSource = CustomerAccountAccountDetailsTable;
                    var a = CustomerAccountAccountDetailsTable.Rows.Count.ToString();
                    custAccount.lblTotalFactures.Text = a;
                    Reports.ReportPerviwGui.XtraForm1 xtraForm1 = new(custAccount);
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
    }
}
