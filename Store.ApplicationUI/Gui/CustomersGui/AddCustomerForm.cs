using Store.ApplicationUI.Code.Helper;
using Store.ApplicationUI.Code.System;
using Store.ApplicationUI.Gui.CustomersGui;
using Store.ApplicationUI.Gui.LoadingGui;
using Store.Core.Entities.Customers;
using Store.Core.Interfaces;
using Store.Infrastructure.Data;

namespace Store.ApplicationUI.Gui.ProductsGui
{
    public partial class AddCustomerForm : Form
    {
        private readonly MainForm _main;
        private readonly ApplicationDbContext _context;
        private readonly ControlManager _controlManager;
        private ICustomersRepository? _customersRepository;
        private static AddCustomerForm? _addCustomerForm;

        public AddCustomerForm(MainForm main,
             ApplicationDbContext context, ControlManager controlManager, ICustomersRepository customersRepository)
        {
            InitializeComponent();
            _main = main;
            _context = context;
            _controlManager = controlManager;

            _customersRepository = customersRepository;



        }
        public async Task LoadData()
        {
            dgvHelper.ResetForm(this);
            vider();
            LoadingForm.Instance(_main).Show();

            if (await _customersRepository.IsConnectedAsync())
            {

            }
            else
            {
                LoadingForm.Instance(_main).Hide();
                MsgHelper.ShowServerError();
            }

            LoadingForm.Instance(_main).Hide();

        }
        void vider()
        {
            txtAddress.Text = "";
            txtNameCustomer.Text = "";
            txtPhoneNumber.Text = "";
            txtMaxDebtAllowed.Text = $"0{Properties.Settings.Default.DecimalSEP}00";
            txtNotes.Text = "";
            btnAddCustomer.Visible = true;
            btnEditCustomer.Visible = false;
            lblِCustomerId.Visible = false;
            label13.Visible = false;

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
        public void SetDataToEditFromId(string CustomerId)
        {
            Customer customer = _customersRepository.Get(Convert.ToInt32(CustomerId));
            txtNameCustomer.Text = customer.CustomerName;
            txtAddress.Text = customer.Address;

            txtPhoneNumber.Text = customer.PhoneNumber;

            txtMaxDebtAllowed.Text = customer.MaxDebtAllowed.ToString(); ;
            txtNotes.Text = customer.Notes;
            lblِCustomerId.Text = CustomerId;
            btnAddCustomer.Visible = false;
            btnEditCustomer.Visible = true;
            lblِCustomerId.Visible = true;
            label13.Visible = true;
        }
        private async void btnAddProduct_Click(object sender, EventArgs e)
        {
            try
            {


                Customer customer = new Customer();
                customer.CustomerName = txtNameCustomer.Text;
                customer.Address = txtAddress.Text;
                customer.PhoneNumber = txtPhoneNumber.Text;
                customer.Notes = txtNotes.Text;
                customer.MaxDebtAllowed = ConvertToFloat(txtMaxDebtAllowed.Text);


                var result = await _customersRepository.AddAsync(customer);
                vider();
                if (_controlManager.TryGet<CustomersUserControl>(out var UC))

                {
                    await UC.LoadData();
                }

                Code.Helper.ToasterHelper.ShowAddToast();

            }
            catch (Exception)
            {

                throw;
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

        private async void btnEditProduct_Click(object sender, EventArgs e)
        {
            try
            {


                Customer customer = _customersRepository.Find(lblِCustomerId.Text);
                if (customer is not null)
                {
                    customer.CustomerName = txtNameCustomer.Text;
                    customer.Address = txtAddress.Text;
                    customer.PhoneNumber = txtPhoneNumber.Text;
                    customer.Notes = txtNotes.Text;
                    customer.MaxDebtAllowed = ConvertToFloat(txtMaxDebtAllowed.Text);
                    var result = await _customersRepository.UpdateAsync(lblِCustomerId.Text, customer);

                    if (_controlManager.TryGet<CustomersUserControl>(out var UC))

                    {
                        await UC.LoadData();
                    }
                    customer = null;
                    Code.Helper.ToasterHelper.ShowEditToast();

                }
            }
            catch (Exception)
            {

                throw;
            }
        }
        private void button1_Click(object sender, EventArgs e)
        {
            this.Close();
        }
    }
}
