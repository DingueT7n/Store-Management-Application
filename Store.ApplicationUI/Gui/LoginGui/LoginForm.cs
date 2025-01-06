using Microsoft.EntityFrameworkCore;
using Store.ApplicationUI.Code.Helper;
using Store.Core.Entities.Caisses;
using Store.Core.Entities.Users;
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
                _splashScreen?.Dispose();


            }
            catch (Exception ex)
            {

                ToasterHelper.ShowConnectionIsNotEstablishedByError(ex.Message);

            }

        }
        private SplashScreen? _splashScreen;
        private void StartSplash()
        {
            try
            {
                _splashScreen = new SplashScreen();
                Application.Run(_splashScreen);
            }
            catch (Exception ex)
            {

                ToasterHelper.ShowConnectionIsNotEstablishedByError(ex.Message);

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
            try
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
                    if (_context.Users.Count() > 0)
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

                            ToasterHelper.ShowLoginFailed();

                        }
                        else
                        {
                            ToasterHelper.ShowLoginSucceded();

                            _oginForm.Hide();
                            Code.Models.LocalUser.User = result;
                            MainForm mainForm = new MainForm();
                            Properties.Settings.Default.UserName = txtUsername.Text;
                            Properties.Settings.Default.Save();
                            mainForm.Show();

                        }
                    }
                    else
                    {
                        User user = new()
                        {
                            UserName = "ALGD",
                            Password = "ALGD2025",
                            UserProfit = 0.00m,
                            Stock_Id = 1,
                            type = "مدير"
                        };
                        if (_context.Caisses.Count() > 0)
                        {
                            if (_context.Caisses.FirstOrDefault(x => x.Id == Properties.Settings.Default.DefaultCaisseId) is not null)
                                user.Stock_Id = Properties.Settings.Default.DefaultCaisseId;
                            else
                            {
                                Caisse caisse = new()
                                {
                                    CaisseName = "الصندوق الاول",
                                    MoneyinCaisse = 0

                                };
                                _context.Add(caisse);
                                _context.SaveChanges();
                                user.Stock_Id = caisse.Id;
                            }
                        }
                        _context.Add(user);
                        _context.SaveChanges();
                        AddUserRelatedEntities(user, true);


                    }
                }
                else
                {
                    ToasterHelper.ShowConnectionIsNotEstablished();

                }
            }
            catch (Exception ex)
            {

                ToasterHelper.ShowConnectionIsNotEstablishedByError(ex.Message);

            }
            txtUsername.Text = string.Empty;
            txtPassowrd.Text = string.Empty;
        }
        private void AddUserRelatedEntities(User user, bool isAdmin)
        {
            List<object> relatedEntities = new()
            {
                new UserBuy(isAdmin) { User_Id = user.Id },
                new UserCaisseAndBank(isAdmin) { User_Id = user.Id },
                new UserCustomer(isAdmin) { User_Id = user.Id },
                new UserDeservedAndTax(isAdmin) { User_Id = user.Id },
                new UserEmployee(isAdmin) { User_Id = user.Id },
                new UserProductAndStore(isAdmin) { User_Id = user.Id },
                new UserRefund(isAdmin) { User_Id = user.Id },
                new UserSale(isAdmin) { User_Id = user.Id },
                new UserSetting(isAdmin) { User_Id = user.Id },
                new UserSupplier(isAdmin) { User_Id = user.Id }
            };
            user.UserBuy = (UserBuy)relatedEntities[0];
            user.UserCaisseAndBank = (UserCaisseAndBank)relatedEntities[1];
            user.UserCustomer = (UserCustomer)relatedEntities[2];
            user.UserDeservedAndTax = (UserDeservedAndTax)relatedEntities[3];
            user.UserEmployee = (UserEmployee)relatedEntities[4];
            user.UserProductAndStore = (UserProductAndStore)relatedEntities[5];
            user.UserRefund = (UserRefund)relatedEntities[6];
            user.UserSale = (UserSale)relatedEntities[7];
            user.UserSetting = (UserSetting)relatedEntities[8];
            user.UserSupplier = (UserSupplier)relatedEntities[9];
            _context.AddRange(relatedEntities);
            _context.SaveChanges();
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
