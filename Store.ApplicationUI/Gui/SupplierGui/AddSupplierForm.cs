using Store.ApplicationUI.Code.Helper;
using Store.ApplicationUI.Gui.LoadingGui;
using Store.ApplicationUI.Gui.SupplierGui;
using Store.Core.Entities.Suppliers;
using Store.Infrastructure.Data;
using Store.Infrastructure.Repositories;

namespace Store.ApplicationUI.Gui.ProductsGui
{
    public partial class AddSupplierForm : Form
    {
        private readonly MainForm _main;
        private ApplicationDbContext _context;
        private SuppliersRepository? _suppliersRepository;
        private static AddSupplierForm? _addSupplierForm;

        public AddSupplierForm(MainForm main)
        {
            InitializeComponent();
            _main = main;
            this.Owner = _main;
            _context = new ApplicationDbContext();

            _suppliersRepository = new SuppliersRepository(_context);

            LoadData();

        }
        public static AddSupplierForm Instance(MainForm main)
        {
            // If the instance is null or has been disposed, create a new one.
            if (_addSupplierForm == null || _addSupplierForm.IsDisposed)
            {
                _addSupplierForm = new AddSupplierForm(main);
            }
            else
            {
                // Bring the form to the front if it exists.
                if (!_addSupplierForm.Visible)
                {
                    _addSupplierForm.Show();
                }
                _addSupplierForm.BringToFront();
            }

            return _addSupplierForm;
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
            txtNameSupplier.Text = "";
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



        public void SetDataToEdit(string NameSupplier, string Address, string PhoneNumber
            , string MaxdebtAllowed, string Notes, string SupplierId)
        {
            txtNameSupplier.Text = NameSupplier;
            txtAddress.Text = Address;

            txtPhoneNumber.Text = PhoneNumber;

            txtMaxDebtAllowed.Text = MaxdebtAllowed;
            txtNotes.Text = Notes;
            lblِSupplierId.Text = SupplierId;
            btnAddSupplier.Visible = false;
            btnEditSupplier.Visible = true;
            lblِSupplierId.Visible = true;
            label13.Visible = true;
        }
        private void btnAddProduct_Click(object sender, EventArgs e)
        {

            Supplier customer = new Supplier();
            customer.SupplierName = txtNameSupplier.Text;
            customer.Address = txtAddress.Text;
            customer.PhoneNumber = txtPhoneNumber.Text;
            customer.Notes = txtNotes.Text;
            customer.MaxDebtAllowed = ConvertToFloat(txtMaxDebtAllowed.Text);


            var result = _suppliersRepository.AddAsync(customer);
            vider();
            if (!SuppliersUserControl.CheckInstance())
            {
                SuppliersUserControl.RefreshDgv();
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

            Supplier customer = _suppliersRepository.Find(lblِSupplierId.Text);
            customer.SupplierName = txtNameSupplier.Text;
            customer.Address = txtAddress.Text;
            customer.PhoneNumber = txtPhoneNumber.Text;
            customer.Notes = txtNotes.Text;
            customer.MaxDebtAllowed = ConvertToFloat(txtMaxDebtAllowed.Text);
            var result = _suppliersRepository.UpdateAsync(lblِSupplierId.Text, customer);

            if (!SuppliersUserControl.CheckInstance())
            {
                SuppliersUserControl.RefreshDgv();
            }
            customer = null;
        }
        private void button1_Click(object sender, EventArgs e)
        {
            this.Close();
        }
    }
}
