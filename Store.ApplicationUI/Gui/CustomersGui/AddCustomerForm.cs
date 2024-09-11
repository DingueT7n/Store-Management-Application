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

        public AddCustomerForm(MainForm main)
        {
            InitializeComponent();
            _main = main;
            this.Owner = _main;
            _customersRepository = new CustomersRepository(new ApplicationDbContext());

            LoadData();

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

        private void txtBarCode_KeyPress(object sender, KeyPressEventArgs e)
        {
            if (!char.IsDigit(e.KeyChar) && e.KeyChar != Properties.Settings.Default.DecimalSEP[0] && e.KeyChar != 8)
            {
                e.Handled = true;
            }
        }

        private void txtMinQty_KeyPress(object sender, KeyPressEventArgs e)
        {
            if (!char.IsDigit(e.KeyChar) && e.KeyChar != Properties.Settings.Default.DecimalSEP[0] && e.KeyChar != 8)
            {
                e.Handled = true;
            }
        }

        private void txtTaxValue_KeyPress(object sender, KeyPressEventArgs e)
        {
            if (!char.IsDigit(e.KeyChar) && e.KeyChar != Properties.Settings.Default.DecimalSEP[0] && e.KeyChar != 8)
            {
                e.Handled = true;
            }
        }

        private void txtBuyPrice_KeyPress(object sender, KeyPressEventArgs e)
        {
            if (!char.IsDigit(e.KeyChar) && e.KeyChar != Properties.Settings.Default.DecimalSEP[0] && e.KeyChar != 8)
            {
                e.Handled = true;
            }
        }

        private void txtTotalQty_KeyPress(object sender, KeyPressEventArgs e)
        {
            if (!char.IsDigit(e.KeyChar) && e.KeyChar != Properties.Settings.Default.DecimalSEP[0] && e.KeyChar != 8)
            {
                e.Handled = true;
            }
        }

        private void txtWholeSalePrice_KeyPress(object sender, KeyPressEventArgs e)
        {
            if (!char.IsDigit(e.KeyChar) && e.KeyChar != Properties.Settings.Default.DecimalSEP[0] && e.KeyChar != 8)
            {
                e.Handled = true;
            }
        }

        private void txtSalePrice_KeyPress(object sender, KeyPressEventArgs e)
        {
            if (!char.IsDigit(e.KeyChar) && e.KeyChar != Properties.Settings.Default.DecimalSEP[0] && e.KeyChar != 8)
            {
                e.Handled = true;
            }
        }

        private void txtDiscountAllowed_KeyPress(object sender, KeyPressEventArgs e)
        {
            if (!char.IsDigit(e.KeyChar) && e.KeyChar != Properties.Settings.Default.DecimalSEP[0] && e.KeyChar != 8)
            {
                e.Handled = true;
            }
        }

        private void txtSaleAfterTax_KeyPress(object sender, KeyPressEventArgs e)
        {
            if (!char.IsDigit(e.KeyChar) && e.KeyChar != Properties.Settings.Default.DecimalSEP[0] && e.KeyChar != 8)
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
