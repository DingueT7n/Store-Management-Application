using Store.ApplicationUI.Code.Helper;
using Store.ApplicationUI.Gui.CustomersGui;
using Store.ApplicationUI.Gui.LoadingGui;
using Store.Core.Entities.Customers;
using Store.Infrastructure.Data;
using Store.Infrastructure.Repositories;

namespace Store.ApplicationUI.Gui.ProductsGui
{
    public partial class AddCustomerForm : Form
    {
        private readonly MainForm _main;
        private CustomersRepository? _customersRepository;
        private static AddCustomerForm? _addCustomerForm;

        public AddCustomerForm(MainForm main)
        {
            InitializeComponent();
            _main = main;
            this.Owner = _main;
            _customersRepository = new CustomersRepository(new ApplicationDbContext());

            LoadData();

        }
        public static AddCustomerForm Instance(MainForm main)
        {
            // If the instance is null or has been disposed, create a new one.
            if (_addCustomerForm == null || _addCustomerForm.IsDisposed)
            {
                _addCustomerForm = new AddCustomerForm(main);
            }
            else
            {
                // Bring the form to the front if it exists.
                if (!_addCustomerForm.Visible)
                {
                    _addCustomerForm.Show();
                }
                _addCustomerForm.BringToFront();
            }

            return _addCustomerForm;
        }
        public async void LoadData()
        {


            //ShowLoading
            LoadingForm.Instance(_main).Show();
            if (await Task.Run(() => MainForm.Context.Database.CanConnect()))
            {


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

        }
        void vider()
        {
            txtAddress.Text = "";
            txtNameCustomer.Text = "";
            txtPhoneNumber.Text = "";
            txtMaxDebtAllowed.Text = $"0{Properties.Settings.Default.DecimalSEP}00";
            txtNotes.Text = "";

        }
        private void txtTaxValue_KeyPress(object sender, KeyPressEventArgs e)
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

        public void SetDataToEdit(string NameCustomer, string Address, string PhoneNumber
            , string MaxdebtAllowed, string Notes, string CustomerId)
        {
            txtNameCustomer.Text = NameCustomer;
            txtAddress.Text = Address;

            txtPhoneNumber.Text = PhoneNumber;

            txtMaxDebtAllowed.Text = MaxdebtAllowed;
            txtNotes.Text = Notes;
            lblِCustomerId.Text = CustomerId;
            btnAddCustomer.Visible = false;
            btnEditCustomer.Visible = true;
            lblِCustomerId.Visible = true;
            label13.Visible = true;
        }
        private void btnAddProduct_Click(object sender, EventArgs e)
        {

            Customer customer = new Customer();
            customer.CustomerName = txtNameCustomer.Text;
            customer.Address = txtAddress.Text;
            customer.PhoneNumber = txtPhoneNumber.Text;
            customer.Notes = txtNotes.Text;
            customer.MaxDebtAllowed = ConvertToFloat(txtMaxDebtAllowed.Text);


            var result = _customersRepository.AddAsync(customer);
            vider();
            if (!CustomersUserControl.CheckInstance())
            {
                CustomersUserControl.RefreshDgv();
            }

        }

        decimal ConvertToFloat(string value)
        {
            //float quantity;
            //if (float.TryParse(value, out quantity))
            //{
            //    return quantity;
            //}
            return Convert.ToDecimal(value);
        }

        private void btnEditProduct_Click(object sender, EventArgs e)
        {

            Customer customer = _customersRepository.Find(lblِCustomerId.Text);
            customer.CustomerName = txtNameCustomer.Text;
            customer.Address = txtAddress.Text;
            customer.PhoneNumber = txtPhoneNumber.Text;
            customer.Notes = txtNotes.Text;
            customer.MaxDebtAllowed = ConvertToFloat(txtMaxDebtAllowed.Text);
            var result = _customersRepository.UpdateAsync(lblِCustomerId.Text, customer);

            if (!CustomersUserControl.CheckInstance())
            {
                CustomersUserControl.RefreshDgv();
            }
            customer = null;
        }
        private void button1_Click(object sender, EventArgs e)
        {
            this.Close();
        }
    }
}
