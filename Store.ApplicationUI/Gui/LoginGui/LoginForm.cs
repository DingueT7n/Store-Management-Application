using Microsoft.EntityFrameworkCore;
using Store.ApplicationUI.Code.Helper;
using Store.Infrastructure.Data;

namespace Store.ApplicationUI.Gui.LoginGui
{
    public partial class LoginForm : Form
    {
        private ApplicationDbContext _context;
        public static LoginForm _oginForm;
        Thread Thread;
        public LoginForm()

        {
            Code.Helper.ConStringHelper.SetConString();
            this._context = new ApplicationDbContext();
            InitializeComponent();
            _oginForm = this;
            try
            {
                Thread = new Thread(new ThreadStart(StartSplash));
                Thread.Start();
                if (!_context.Database.CanConnect())
                {
                    lblCon.Visible = true;
                }
                Thread.Sleep(5000);

            }
            catch (Exception)
            {

                throw;
            }

        }

        private void StartSplash()
        {
            try
            {
                Application.Run(new SplashScreen());
            }
            catch (Exception)
            {

                throw;
            }
        }

        private void button2_Click(object sender, EventArgs e)
        {
            ToasterHelper.PlayNotificationSound();
            Close();
            Application.Exit();
        }

        private void txtUsername_KeyPress(object sender, KeyPressEventArgs e)
        {
            if (e.KeyChar == 13)
            {
                txtPassowrd.Focus();
                return;
            }
        }

        private void txtUsername_KeyDown(object sender, KeyEventArgs e)
        {
            if (e.KeyCode == Keys.Enter)
            {
                txtPassowrd.Focus();
            }
        }

        private void txtPassowrd_KeyDown(object sender, KeyEventArgs e)
        {

        }

        private async void button1_Click(object sender, EventArgs e)
        {
            ToasterHelper.PlayNotificationSound();
            Code.Helper.ConStringHelper.SetConString();
            this._context = new ApplicationDbContext();


            if (string.IsNullOrWhiteSpace(txtUsername.Text) || string.IsNullOrWhiteSpace(txtPassowrd.Text))
            {
                MessageBox.Show("من فضلك ادخل اسم المستخدم وكلمة السر");
                return;
            }
            if (await _context.Database.CanConnectAsync())
            {
                var result = await _context.Users
                 .Include(u => u.UserBuy)
                .Include(u => u.UserCaisseAndBank)
                .Include(u => u.UserCustomer)
                .Include(u => u.UserDeservedAndTax)
                .Include(u => u.UserEmployee)
                .Include(u => u.UserProductAndStore)
                .Include(u => u.UserRefund)
                .Include(u => u.UserSale)
                .Include(u => u.UserSetting)
                .Include(u => u.UserSupplier)
                .FirstOrDefaultAsync(u => u.UserName == txtUsername.Text && u.Password == txtPassowrd.Text);
                if (result == null)
                {
                    // wrong passowrd
                }
                else
                {
                    _oginForm.Hide();
                    Code.Models.LocalUser.User = result;
                    MainForm mainForm = new MainForm();
                    Properties.Settings.Default.UserName = txtUsername.Text;
                    Properties.Settings.Default.Save();
                    mainForm.Show();

                }
            }
        }

        private void txtPassowrd_KeyPress(object sender, KeyPressEventArgs e)
        {
            if (e.KeyChar == 13)
            {
                button1_Click(sender, e);
                e.Handled = true;
            }
        }

        private void lblCon_Click(object sender, EventArgs e)
        {
            ToasterHelper.PlayNotificationSound();
            ConnectionSettingsForm connectionSettingsForm = new ConnectionSettingsForm();
            this.Hide();
            connectionSettingsForm.ShowDialog();
            this.Show();

        }

        private void LoginForm_KeyDown(object sender, KeyEventArgs e)
        {
            if (e.KeyCode == Keys.F12)
            {
                ToasterHelper.PlayNotificationSound();
                ConnectionSettingsForm connectionSettingsForm = new ConnectionSettingsForm();
                this.Hide();
                connectionSettingsForm.ShowDialog();
                this.Show();
            }
        }
    }
}
