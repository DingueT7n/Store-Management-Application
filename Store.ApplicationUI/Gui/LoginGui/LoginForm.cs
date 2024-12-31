using Microsoft.EntityFrameworkCore;
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
            this._context = new ApplicationDbContext();
            InitializeComponent();
            _oginForm = this;
            try
            {
                Thread = new Thread(new ThreadStart(StartSplash));
                Thread.Start();
                _context.Database.CanConnect();
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

            if (string.IsNullOrWhiteSpace(txtUsername.Text) || string.IsNullOrWhiteSpace(txtPassowrd.Text))
            {
                MessageBox.Show("Please enter both username and password.");
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
    }
}
