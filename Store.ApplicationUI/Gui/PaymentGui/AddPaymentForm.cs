using Store.ApplicationUI.Code.Helper;
using Store.ApplicationUI.Gui.BuysGui;
using Store.ApplicationUI.Gui.SalesGui;
using Store.ApplicationUI.Gui.SalesGui.PosGui;

namespace Store.ApplicationUI.Gui.PaymentGui
{
    public partial class AddPaymentForm : Form
    {

        private static MainForm _main;
        private static PosForm _PosForm;
        private readonly int _form;
        private AddPaymentForm? _addPaymentForm;

        public AddPaymentForm(MainForm userControl, int form)
        {
            InitializeComponent();
            _main = userControl;
            _form = form;
            this.Owner = _main;
        }
        public AddPaymentForm(PosForm userControl, int form)
        {
            InitializeComponent();
            _PosForm = userControl;
            _form = form;
            this.Owner = _main;
        }
        public async void LoadData(string Total, string paidUp, string remaining)
        {
            txtFacturePrice.Text = Total;
            txtpaidUp.Text = paidUp;
            txtRemain.Text = remaining;
            txtpaidUp.Focus();
            txtpaidUp.SelectAll();


        }

        private void button1_Click(object sender, EventArgs e)
        {

            ToasterHelper.PlayNotificationSound();
            this.Close();
        }
        private void btnSearchImage_Click(object sender, EventArgs e)
        {
            PaymentActivate();

        }
        void PaymentActivate()
        {
            ToasterHelper.PlayNotificationSound();
            if (Convert.ToDecimal(txtRemain.Text) + Convert.ToDecimal(txtpaidUp.Text) >= Convert.ToDecimal(txtFacturePrice.Text))
            {
                if (this._form == 1)
                {
                    SalesGui.SalesUserControl.InitializeData(txtpaidUp.Text, txtRemain.Text);
                    SalesUserControl.Process = true;
                }
                else if (_form == 0)
                {
                    BuysUserControl.InitializeData(txtpaidUp.Text, txtRemain.Text);
                    BuysUserControl.Process = true;
                }
                else if (PosForm.GetPosUserControl() is not null)
                {
                    PosForm.GetPosUserControl().InitializeData(txtpaidUp.Text, txtRemain.Text);
                }
                this.Close();
            }
        }
        private void txtpaidUp_TextChanged(object sender, EventArgs e)
        {
            try
            {
                if (txtpaidUp.Text != "")
                    txtRemain.Text = (Convert.ToDecimal(txtFacturePrice.Text) - Convert.ToDecimal(txtpaidUp.Text)).ToString();
            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.Message);
            }
        }
        private void txtpaidUp_KeyPress(object sender, KeyPressEventArgs e)
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

        private void txtFacturePrice_KeyPress(object sender, KeyPressEventArgs e)
        {

        }

        private void AddPaymentForm_KeyDown(object sender, KeyEventArgs e)
        {
            if (e.KeyCode == Keys.F12)
            {
                PaymentActivate();
            }
        }
    }
}
