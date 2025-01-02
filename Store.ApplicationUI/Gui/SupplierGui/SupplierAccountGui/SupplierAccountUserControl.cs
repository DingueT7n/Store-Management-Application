using System.Data;
using Microsoft.EntityFrameworkCore;
using Store.ApplicationUI.Code.Helper;
using Store.ApplicationUI.Gui.LoadingGui;
using Store.Core.Entities.Caisses;
using Store.Infrastructure.Data;
using Store.Infrastructure.Repositories;

namespace Store.ApplicationUI.Gui.SupplierGui.SupplierAccountGui
{
    public partial class SupplierAccountUserControl : UserControl
    {
        private static MainForm? _main;
        private static ApplicationDbContext _context;
        public static SupplierMoneyRepository? suppliersRepository;
        private static SupplierAccountUserControl? _supplierAccountUserControl;
        public SupplierAccountUserControl()
        {
            InitializeComponent();
        }
        public static bool CheckInstance()
        {
            return (_supplierAccountUserControl == null);

        }
        public static SupplierAccountUserControl Instance(MainForm main)
        {
            _main = main;
            // If the instance is null, create a new one and assign it to the static field
            _context = new ApplicationDbContext();
            if (CheckInstance())
            {

                suppliersRepository = new SupplierMoneyRepository(_context);

                _supplierAccountUserControl = new SupplierAccountUserControl();

            }

            // Return the singleton instance
            _supplierAccountUserControl.LoadData();

            return _supplierAccountUserControl;
        }

        public async void SetDataToDgv()
        {

            //DgvِCustomer.DataSource = await Task.Run(() => productsRepository.GetAll(p => p.Category));
            var SuppliersMoneyList = _context.SuppliersMoneys.
                Include(x => x.Supplier).Include(x => x.Buy)
                .ToList();
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

        public static void RefreshDgv()
        {
            //DgvِCustomer.DataSource = await Task.Run(() => productsRepository.GetAllProducts());
            _supplierAccountUserControl.LoadData();
        }
        // methodes 
        public async void LoadData()
        {


            //ShowLoading
            LoadingForm.Instance(_main).Show();
            if (await Task.Run(() => suppliersRepository.IsConnected()))
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

        private void btnSearch_Click(object sender, EventArgs e)
        {
            DgvِCustomer.DataSource = suppliersRepository.SearchAll(txtSearch.Text);
            lblEmptyData.Visible = dgvHelper.IsEmpty(DgvِCustomer);
            txtSearch.Text = string.Empty;
        }
        Caisse SetCaisse(decimal value)
        {
            //dgvProducts.Rows[i].Cells[0].Value.ToString()

            Caisse caisse = _context.Caisses.Where(x => x.Id == Properties.Settings.Default.DefaultCaisseId).FirstOrDefault();
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
                Reason = "شراء بالفاتورة لعميل",
                Type = "سحب عن طريق شراء منتجات (مال مستثمر )"
            };

            return caisseWithdraw;

        }
        private void btnPay_Click(object sender, EventArgs e)
        {
            if (DgvِCustomer.SelectedRows.Count > 0 && !dgvHelper.IsEmpty(DgvِCustomer))
            {
                _context = new ApplicationDbContext();
                if (rbPayFacture.Checked)
                {
                    suppliersRepository.TransactionOfSupplierDebt(
                        DgvِCustomer.CurrentRow.Cells[1].Value.ToString(),
                        DgvِCustomer.CurrentRow.Cells[0].Value.ToString(),
                        DgvِCustomer.CurrentRow.Cells[3].Value.ToString(),
                        DgvِCustomer.CurrentRow.Cells[2].Value.ToString(),
                        DateTime.Now
                        );
                    _context.Update(SetCaisse(_main.ConvertToFloat(DgvِCustomer.CurrentRow.Cells[3].Value?.ToString())));
                    _context.SaveChanges();
                    if (_main.ConvertToFloat(DgvِCustomer.CurrentRow.Cells[3].Value?.ToString()) > 0)
                    {
                        _context.Add(SetCaisseWithdraw(_main.ConvertToFloat(DgvِCustomer.CurrentRow.Cells[3].Value?.ToString()),
                            DgvِCustomer.CurrentRow.Cells[2].Value.ToString()
                            ));
                        _context.SaveChanges();
                    }

                }
                else if (rbPayPartialFacture.Checked)
                {
                    suppliersRepository.TransactionOfEditingSupplierDebt(
                        DgvِCustomer.CurrentRow.Cells[1].Value.ToString(),
                        DgvِCustomer.CurrentRow.Cells[0].Value.ToString(),
                        DgvِCustomer.CurrentRow.Cells[3].Value.ToString(),
                        DgvِCustomer.CurrentRow.Cells[2].Value.ToString(),
                       txtPayAmout.Text,
                       DateTime.Now
                       );
                    _context.Update(SetCaisse(_main.ConvertToFloat(txtPayAmout.Text)));
                    _context.SaveChanges();
                    if (_main.ConvertToFloat(txtPayAmout.Text) > 0)
                    {
                        _context.Add(SetCaisseWithdraw(_main.ConvertToFloat(txtPayAmout.Text),
                         DgvِCustomer.CurrentRow.Cells[2].Value.ToString()));
                        _context.SaveChanges();
                    }

                }
                else
                {
                    for (int i = 0; i < DgvِCustomer.Rows.Count; i++)
                    {
                        var row = DgvِCustomer.Rows[i];
                        suppliersRepository.TransactionOfSupplierDebt(
                            row.Cells[1].Value?.ToString(),
                            row.Cells[0].Value?.ToString(),
                            row.Cells[3].Value?.ToString(),
                            row.Cells[2].Value?.ToString(),
                            DateTime.Now
                        );
                        _context.Update(SetCaisse(_main.ConvertToFloat(row.Cells[3].Value?.ToString())));
                        _context.SaveChanges();
                        if (_main.ConvertToFloat(row.Cells[3].Value?.ToString()) > 0)
                        {
                            _context.Add(SetCaisseWithdraw(
                            _main.ConvertToFloat(row.Cells[3].Value?.ToString())
                            , row.Cells[2].Value.ToString()));
                            _context.SaveChanges();
                        }

                    }
                }
                SetDataToDgv();
            }
        }

        private async void btnExportCustomer_Click(object sender, EventArgs e)
        {
            try
            {
                if (DgvِCustomer.SelectedRows.Count > 0)
                {
                    DataTable suplierAccountDetailsTable = await FactureHelper.GetSupplierAccountDataTableAsync(Convert.ToInt32(DgvِCustomer.CurrentRow.Cells[0].Value.ToString()));
                    Reports.SuppliersAccountsReports.SuppliersAccountsReports supAccount = new();
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
    }
}
