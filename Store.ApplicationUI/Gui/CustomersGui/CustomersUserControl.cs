using Store.ApplicationUI.Code.Helper;
using Store.ApplicationUI.Gui.LoadingGui;
using Store.ApplicationUI.Gui.ProductsGui;
using Store.Infrastructure.Data;
using Store.Infrastructure.Repositories;

namespace Store.ApplicationUI.Gui.CustomersGui
{
    public partial class CustomersUserControl : UserControl
    {
        private static CustomersGui.CustomersUserControl? _customersUserControl;
        private static MainForm? _main;
        private AddCustomerForm addCustomerForm;
        public static CustomersRepository? customersRepository;
        private static ApplicationDbContext _context;


        public CustomersUserControl()
        {
            InitializeComponent();
        }
        public static bool CheckInstance()
        {
            return (_customersUserControl == null);

        }

        public static CustomersUserControl Instance(MainForm main)
        {
            _main = main;
            // If the instance is null, create a new one and assign it to the static field
            if (CheckInstance())
            {
                _context = new ApplicationDbContext();
                customersRepository = new CustomersRepository(_context);

                _customersUserControl = new CustomersUserControl();

            }

            // Return the singleton instance
            _customersUserControl.LoadData();
            return _customersUserControl;
        }
        public async void SetProductsToDgv()
        {
            //DgvِCustomer.DataSource = await Task.Run(() => productsRepository.GetAll(p => p.Category));
            DgvِCustomer.DataSource = customersRepository.GetAllData();

        }

        public static void RefreshDgv()
        {
            //DgvِCustomer.DataSource = await Task.Run(() => productsRepository.GetAllProducts());
            _customersUserControl.LoadData();
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
            DgvِCustomer.Columns[1].HeaderCell.Value = "العنوان";
            DgvِCustomer.Columns[2].HeaderCell.Value = "رقم الهاتف";
            DgvِCustomer.Columns[3].HeaderCell.Value = "ملاحظة";
            DgvِCustomer.Columns[4].HeaderCell.Value = "اعلى دين مسموح به";
            DgvِCustomer.Columns[5].HeaderCell.Value = "مجموع الديون";
            DgvِCustomer.Columns[6].HeaderCell.Value = "معرف العميل";
        }

        private void btnRefresh_Click(object sender, EventArgs e)
        {
            LoadData();
        }

        private void btnAddCustomer_Click(object sender, EventArgs e)
        {

            addCustomerForm = AddCustomerForm.Instance(_main);
            addCustomerForm.Show();

        }

        private void btnEditCustomer_Click(object sender, EventArgs e)
        {
            if (DgvِCustomer.Rows.Count > 0)
            {
                if (addCustomerForm == null || addCustomerForm.IsDisposed)
                {
                    addCustomerForm = AddCustomerForm.Instance(_main);


                    addCustomerForm.SetDataToEdit(
                        DgvِCustomer.CurrentRow.Cells[0].Value.ToString(),
                        DgvِCustomer.CurrentRow.Cells[1].Value.ToString(),
                        DgvِCustomer.CurrentRow.Cells[2].Value.ToString(),
                        DgvِCustomer.CurrentRow.Cells[4].Value.ToString(),
                        DgvِCustomer.CurrentRow.Cells[3].Value.ToString(),
                        DgvِCustomer.CurrentRow.Cells[6].Value.ToString());

                    addCustomerForm.Show();
                }
                else
                {
                    addCustomerForm.Focus();
                }
            }
        }

        private void btnDeleteCustomer_Click(object sender, EventArgs e)
        {
            try
            {
                if (MsgHelper.ShowDeleteDialog())
                {
                    var customer = customersRepository.DeleteAsync(DgvِCustomer.CurrentRow.Cells[6].Value.ToString());


                }
                RefreshDgv();
            }
            catch (Exception ex)
            {

                MessageBox.Show(ex.Message);
            }

        }

        private void btnSearch_Click(object sender, EventArgs e)
        {
            DgvِCustomer.DataSource = customersRepository.SearchAll(txtSearch.Text);
            lblEmptyData.Visible = dgvHelper.IsEmpty(DgvِCustomer);
            txtSearch.Text = string.Empty;
        }
    }
}
