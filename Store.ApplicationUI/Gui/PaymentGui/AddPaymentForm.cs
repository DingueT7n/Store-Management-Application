using Store.ApplicationUI.Code.Helper;
using Store.ApplicationUI.Code.System;
using Store.ApplicationUI.Gui.BuysGui;
using Store.ApplicationUI.Gui.SalesGui;
using Store.ApplicationUI.Gui.SalesGui.PosGui;

namespace Store.ApplicationUI.Gui.PaymentGui
{
    public partial class AddPaymentForm : Form
    {

        private readonly MainForm _main;
        private static PosForm _PosForm;
        public int _form;
        private readonly ControlManager _controlManager;


        public AddPaymentForm(MainForm userControl, ControlManager controlManager)
        {
            InitializeComponent();
            _main = userControl;

            _controlManager = controlManager;
            this.Owner = _main;
        }
        public AddPaymentForm(MainForm userControl, int f)
        {
            InitializeComponent();
            _main = userControl;


            this.Owner = _main;
        }
        public void setTypeForm(int form) { _form = form; }
        public AddPaymentForm(PosForm userControl, int form)
        {
            InitializeComponent();
            _PosForm = userControl;
            _form = form;
            this.Owner = _main;
        }
        public void LoadData(string Total, string paidUp, string remaining, int form)
        {
            txtFacturePrice.Text = Total;
            txtpaidUp.Text = paidUp;
            txtRemain.Text = remaining;
            _form = form;

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

                    if (_controlManager.TryGet<SalesUserControl>(out var UCS))

                    {

                        UCS.InitializeData(txtpaidUp.Text, txtRemain.Text);

                        UCS.Process = true;
                    }
                }
                else if (_form == 0)
                {
                    if (_controlManager.TryGet<BuysUserControl>(out var UCB))

                    {

                        UCB.InitializeData(txtpaidUp.Text, txtRemain.Text);

                        UCB.Process = true;
                    }

                }
                else if (_controlManager.TryGet<PosUserControl>(out var UCP))

                {

                    UCP.InitializeData(txtpaidUp.Text, txtRemain.Text);


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
