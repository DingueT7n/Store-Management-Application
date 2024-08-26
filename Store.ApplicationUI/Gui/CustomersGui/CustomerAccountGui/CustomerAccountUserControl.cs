using Microsoft.EntityFrameworkCore;
using Store.ApplicationUI.Code.Helper;
using Store.ApplicationUI.Gui.LoadingGui;
using Store.Infrastructure.Repositories;

namespace Store.ApplicationUI.Gui.CustomersGui.CustomerAccountGui
{
    public partial class CustomerAccountUserControl : UserControl
    {
        private static MainForm? _main;
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
                customersRepository = new CustomerMoneyRepository(MainForm.Context);

                _customerAccountUserControl = new CustomerAccountUserControl();

            }

            // Return the singleton instance
            _customerAccountUserControl.LoadData();
            return _customerAccountUserControl;
        }

        public async void SetProductsToDgv()
        {
            //DgvِCustomer.DataSource = await Task.Run(() => productsRepository.GetAll(p => p.Category));
            var CustomerMoneyList = MainForm.Context.CustomersMoneys.
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
                    lblPayFacture.Text = $" فاتورة رقم {DgvِCustomer.Columns[7].HeaderCell.Value} الدين : {DgvِCustomer.Columns[1].HeaderCell.Value} دج";
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
            DgvِCustomer.Columns[0].HeaderCell.Value = "اسم العميل";
            DgvِCustomer.Columns[1].HeaderCell.Value = "الدين";
            DgvِCustomer.Columns[2].HeaderCell.Value = "تاريخ الفاتورة";
            DgvِCustomer.Columns[3].HeaderCell.Value = "تاريخ تذكير";
            DgvِCustomer.Columns[4].HeaderCell.Value = "اعلى دين مسموح به";
            DgvِCustomer.Columns[5].HeaderCell.Value = "مجموع الديون";
            DgvِCustomer.Columns[6].HeaderCell.Value = "معرف العميل";
            DgvِCustomer.Columns[7].HeaderCell.Value = "معرف الفاتورة";
            DgvِCustomer.Columns[8].HeaderCell.Value = "معرف العملية";


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
            if (DgvِCustomer.SelectedRows.Count > 0 && dgvHelper.IsEmpty(DgvِCustomer))
            {
                if (rbPayFacture.Checked)
                {

                    customersRepository.TransactionOfCustomerDebt(
                        DgvِCustomer.CurrentRow.Cells[7].Value.ToString(),
                        DgvِCustomer.CurrentRow.Cells[6].Value.ToString(),
                        DgvِCustomer.CurrentRow.Cells[1].Value.ToString(),
                        DgvِCustomer.CurrentRow.Cells[0].Value.ToString(),
                        DateTime.Now
                        );

                }
                else if (rbPayPartialFacture.Checked)
                {
                    customersRepository.TransactionOfEditingCustomerDebt(
                       DgvِCustomer.CurrentRow.Cells[7].Value.ToString(),
                       DgvِCustomer.CurrentRow.Cells[6].Value.ToString(),
                       DgvِCustomer.CurrentRow.Cells[1].Value.ToString(),
                       DgvِCustomer.CurrentRow.Cells[0].Value.ToString(),
                       txtPayAmout.Text,
                       DateTime.Now
                       );
                }
                else
                {
                    for (int i = 0; i < DgvِCustomer.Rows.Count; i++)
                    {
                        var row = DgvِCustomer.Rows[i];
                        customersRepository.TransactionOfCustomerDebt(
                            row.Cells[7].Value?.ToString(),
                            row.Cells[6].Value?.ToString(),
                            row.Cells[1].Value?.ToString(),
                            row.Cells[0].Value?.ToString(),
                            DateTime.Now
                        );
                    }

                }


            }

        }

        private void btnRefresh_Click_1(object sender, EventArgs e)
        {
            LoadData();
        }
    }
}
