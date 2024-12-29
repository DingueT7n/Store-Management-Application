namespace Store.ApplicationUI.Gui.PaymentGui
{
    public partial class LockUnlockForm : Form
    {


        public LockUnlockForm()
        {


            InitializeComponent();

        }

        private void button1_Click(object sender, EventArgs e)
        {
            //if (maskedTextBox1.Text == "1")
            //{
            //    Close();
            //}
            if (maskedTextBox1.Text == Code.Models.LocalUser.User.Password && maskedTextBox2.Text == Code.Models.LocalUser.User.UserName)
            {
                Close();
            }
            else
            {
                maskedTextBox1.Text = "";
                maskedTextBox2.Text = "";
            }
        }
    }
}
