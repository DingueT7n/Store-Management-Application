using Microsoft.EntityFrameworkCore;
using Store.ApplicationUI.Code.Helper;
using Store.ApplicationUI.Gui.LoadingGui;
using Store.Infrastructure.Repositories;

namespace Store.ApplicationUI.Gui.SupplierGui.SupplierAccountGui
{
    public partial class SupplierAccountUserControl : UserControl
    {
        private static MainForm? _main;
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
            if (CheckInstance())
            {
                suppliersRepository = new SupplierMoneyRepository(MainForm.Context);

                _supplierAccountUserControl = new SupplierAccountUserControl();

            }

            // Return the singleton instance
            _supplierAccountUserControl.LoadData();
            return _supplierAccountUserControl;
        }

        public async void SetProductsToDgv()
        {
            //DgvِCustomer.DataSource = await Task.Run(() => productsRepository.GetAll(p => p.Category));
            var CustomerMoneyList = MainForm.Context.SuppliersMoneys.
                Include(x => x.Supplier).Include(x => x.Buy)
                .ToList();
            var uniqueCustomerCount = CustomerMoneyList
                .Select(x => x.Supplier.Id) // Replace CustomerId with the actual unique identifier property
                .Distinct()
                .Count();
            DgvِCustomer.DataSource = CustomerMoneyList;
            if (DgvِCustomer.Rows.Count > 0)
            {
                if (DgvِCustomer.SelectedRows.Count > 0)
                {
                    lblPayFacture.Text = $" فاتورة رقم {DgvِCustomer.Columns[7].HeaderCell.Value} الدين : {DgvِCustomer.Columns[1].HeaderCell.Value} دج";
                    lblPayAllDebts.Text = $"دج {CustomerMoneyList.Sum(x => x.Price)}";
                    lblTotalDebt.Text = $"مجموع الديون على الموردين:{CustomerMoneyList.Sum(x => x.Price)}";
                    lblTotalCustomers.Text = $"مجموع الموردين:{uniqueCustomerCount}";
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

                SetProductsToDgv();
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
            DgvِCustomer.Columns[0].HeaderCell.Value = "اسم المورد";
            DgvِCustomer.Columns[1].HeaderCell.Value = "الدين";
            DgvِCustomer.Columns[2].HeaderCell.Value = "تاريخ الفاتورة";
            DgvِCustomer.Columns[3].HeaderCell.Value = "وقت الفاتورة";

            DgvِCustomer.Columns[4].HeaderCell.Value = "تاريخ تذكير";
            DgvِCustomer.Columns[5].HeaderCell.Value = "معرف المورد";
            DgvِCustomer.Columns[6].HeaderCell.Value = "معرف الفاتورة";
            DgvِCustomer.Columns[7].HeaderCell.Value = "معرف العملية";


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

        private void btnPay_Click(object sender, EventArgs e)
        {
            if (DgvِCustomer.SelectedRows.Count > 0 && dgvHelper.IsEmpty(DgvِCustomer))
            {
                if (rbPayFacture.Checked)
                {
                    suppliersRepository.TransactionOfCustomerDebt(
                        DgvِCustomer.CurrentRow.Cells[7].Value.ToString(),
                        DgvِCustomer.CurrentRow.Cells[6].Value.ToString(),
                        DgvِCustomer.CurrentRow.Cells[1].Value.ToString(),
                        DgvِCustomer.CurrentRow.Cells[0].Value.ToString(),
                        DateTime.Now, "13:00"
                        );
                }
                else if (rbPayPartialFacture.Checked)
                {
                    suppliersRepository.TransactionOfEditingCustomerDebt(
                       DgvِCustomer.CurrentRow.Cells[7].Value.ToString(),
                       DgvِCustomer.CurrentRow.Cells[6].Value.ToString(),
                       DgvِCustomer.CurrentRow.Cells[1].Value.ToString(),
                       DgvِCustomer.CurrentRow.Cells[0].Value.ToString(),
                       txtPayAmout.Text,
                       DateTime.Now, "13:00"
                       );
                }
                else
                {
                    for (int i = 0; i < DgvِCustomer.Rows.Count; i++)
                    {
                        var row = DgvِCustomer.Rows[i];
                        suppliersRepository.TransactionOfCustomerDebt(
                            row.Cells[7].Value?.ToString(),
                            row.Cells[6].Value?.ToString(),
                            row.Cells[1].Value?.ToString(),
                            row.Cells[0].Value?.ToString(),
                            DateTime.Now, "13:00"
                        );
                    }
                }
            }
        }
    }
}
