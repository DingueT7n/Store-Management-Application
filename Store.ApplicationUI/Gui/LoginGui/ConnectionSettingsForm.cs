using Store.ApplicationUI.Code.Helper;
using Store.Infrastructure.Data;

namespace Store.ApplicationUI.Gui.LoginGui
{
    public partial class ConnectionSettingsForm : Form
    {
        public ConnectionSettingsForm()
        {
            InitializeComponent();
            txtServer.Text = Properties.Settings.Default.Server;
            txtDb.Text = Properties.Settings.Default.DataBase;


            if (Properties.Settings.Default.ConType != "local")
            {
                rbWide.Checked = true;
                txtUserCon.Text = Properties.Settings.Default.UserCon;
                txtUserpass.Text = Properties.Settings.Default.PassCon;
            }
        }

        private void button1_Click(object sender, EventArgs e)
        {

            ToasterHelper.PlayNotificationSound();
            Properties.Settings.Default.Server = txtServer.Text;
            Properties.Settings.Default.DataBase = txtDb.Text;


            if (rbWide.Checked)
            {
                Properties.Settings.Default.ConType = "Wide";
                Properties.Settings.Default.UserCon = txtUserCon.Text;
                Properties.Settings.Default.PassCon = txtUserpass.Text;



            }
            else
            {
                Properties.Settings.Default.ConType = "local";
            }
            Properties.Settings.Default.Save();
            Code.Helper.ToasterHelper.ShowAddToast();

        }

        private void rbWide_CheckedChanged(object sender, EventArgs e)
        {
            txtUserCon.Enabled = txtUserpass.Enabled = rbWide.Checked;
        }

        private void rbLocal_CheckedChanged(object sender, EventArgs e)
        {
            txtUserCon.Enabled = txtUserpass.Enabled = rbWide.Checked;

        }

        private async void button2_Click(object sender, EventArgs e)
        {
            ToasterHelper.PlayNotificationSound();
            string con;



            if (rbLocal.Checked)
            {
                con = $"Server={txtServer.Text};Database={txtDb.Text};Encrypt=false;Trusted_Connection=True;";
            }
            else
            {
                string user = Properties.Settings.Default.UserName;
                string password = Properties.Settings.Default.PassCon;

                con = $"Server={txtServer.Text};Database={txtDb.Text};User Id={txtUserCon.Text};Password={txtUserpass.Text};Encrypt=false;Timeout={60};";

            }


            bool isValid = await ApplicationDbContext.IsValidConnectionStringAsync(con);

            if (isValid)
            {
                Code.Helper.ToasterHelper.ShowConnectionIsEstablished();
            }
            else
            {
                Code.Helper.ToasterHelper.ShowConnectionIsNotEstablished();

            }
        }
    }
}

