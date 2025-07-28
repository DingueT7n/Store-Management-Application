using Store.ApplicationUI.Code.Helper;
using Store.ApplicationUI.Code.System;
using Store.ApplicationUI.Gui.LoadingGui;
using Store.ApplicationUI.Gui.SupplierGui;
using Store.Core.Entities.Suppliers;
using Store.Core.Interfaces;

namespace Store.ApplicationUI.Gui.ProductsGui
{
    public partial class AddSupplierForm : Form
    {


        private readonly ISuppliersRepository _suppliersRepository;
        private readonly ControlManager _controlManager;
        private readonly MainForm _main;

        public AddSupplierForm(ISuppliersRepository suppliersRepository, ControlManager controlManager, MainForm main)
        {
            InitializeComponent();

            _suppliersRepository = suppliersRepository;
            _controlManager = controlManager;
            _main = main;
        }
        public async Task LoadData()
        {
            dgvHelper.ResetForm(this);
            vider();
            LoadingForm.Instance(_main).Show();

            if (await _suppliersRepository.IsConnectedAsync())
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
            txtNameSupplier.Text = "";
            txtPhoneNumber.Text = "";
            txtMaxDebtAllowed.Text = $"0{Properties.Settings.Default.DecimalSEP}00";
            txtNotes.Text = "";
            lblِSupplierId.Text = "";
            btnAddSupplier.Visible = true;
            btnEditSupplier.Visible = false;
            lblِSupplierId.Visible = false;
            label13.Visible = false;
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



        public async Task SetDataToEdit(string SupplierId)
        {
            var objet = await _suppliersRepository.GetAsync(Convert.ToInt32(SupplierId));

            txtNameSupplier.Text = objet.SupplierName;
            txtAddress.Text = objet.Address;

            txtPhoneNumber.Text = objet.PhoneNumber;

            txtMaxDebtAllowed.Text = objet.MaxDebtAllowed.ToString(); ;
            txtNotes.Text = objet.Notes;
            lblِSupplierId.Text = objet.Id.ToString();
            btnAddSupplier.Visible = false;
            btnEditSupplier.Visible = true;
            lblِSupplierId.Visible = true;
            label13.Visible = true;
        }

        private async void btnAddProduct_Click(object sender, EventArgs e)
        {
            try
            {


                ToasterHelper.PlayNotificationSound();
                Supplier customer = new Supplier();
                customer.SupplierName = txtNameSupplier.Text;
                customer.Address = txtAddress.Text;
                customer.PhoneNumber = txtPhoneNumber.Text;
                customer.Notes = txtNotes.Text;
                customer.MaxDebtAllowed = ConvertToFloat(txtMaxDebtAllowed.Text);


                var result = await _suppliersRepository.AddAsync(customer);
                await LoadData();

                if (_controlManager.TryGet<SuppliersUserControl>(out var UC))

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


                ToasterHelper.PlayNotificationSound();
                Supplier customer = _suppliersRepository.Find(lblِSupplierId.Text);
                if (customer is not null)
                {
                    customer.SupplierName = txtNameSupplier.Text;
                    customer.Address = txtAddress.Text;
                    customer.PhoneNumber = txtPhoneNumber.Text;
                    customer.Notes = txtNotes.Text;
                    customer.MaxDebtAllowed = ConvertToFloat(txtMaxDebtAllowed.Text);
                    var result = await _suppliersRepository.UpdateAsync(lblِSupplierId.Text, customer);
                    if (_controlManager.TryGet<SuppliersUserControl>(out var UC))

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
            ToasterHelper.PlayNotificationSound();
            this.Close();
        }

        private void AddSupplierForm_Load(object sender, EventArgs e)
        {

        }

        private async void AddSupplierForm_FormClosing(object sender, FormClosingEventArgs e)
        {
            await LoadData();
        }
    }
}
