using Store.ApplicationUI.Code.Helper;
using Store.ApplicationUI.Code.Models;

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
            ToasterHelper.PlayNotificationSound();
            if (LocalUser.User is not null)

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
