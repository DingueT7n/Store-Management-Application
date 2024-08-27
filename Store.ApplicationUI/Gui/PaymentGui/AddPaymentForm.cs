using Store.ApplicationUI.Gui.BuysGui;

namespace Store.ApplicationUI.Gui.PaymentGui
{
    public partial class AddPaymentForm : Form
    {

        private static MainForm _main;
        private AddPaymentForm? _addPaymentForm;

        public AddPaymentForm(MainForm userControl)
        {
            InitializeComponent();
            _main = userControl;
            this.Owner = _main;
        }
        public async void LoadData(string Total, string paidUp, string remaining)
        {
            txtFacturePrice.Text = Total;
            txtpaidUp.Text = paidUp;
            txtRemain.Text = remaining;

        }

        private void button1_Click(object sender, EventArgs e)
        {
            this.Close();
        }
        private void btnSearchImage_Click(object sender, EventArgs e)
        {

            BuysUserControl.InitializeData(txtpaidUp.Text, txtRemain.Text);
            this.Close();

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
            if (!char.IsDigit(e.KeyChar) && e.KeyChar != Properties.Settings.Default.DecimalSEP[0] && e.KeyChar != 8)
            {
                e.Handled = true;
            }
        }
    }
}
