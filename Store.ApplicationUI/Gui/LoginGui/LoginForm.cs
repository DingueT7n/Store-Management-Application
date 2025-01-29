using Microsoft.EntityFrameworkCore;
using Store.ApplicationUI.Code.Helper;
using Store.ApplicationUI.Code.Models;
using Store.Core.Entities.Caisses;
using Store.Core.Entities.Helpers;
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
            try
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
            catch (Exception ex)
            {
                ToasterHelper.ShowErrorHappened(ex.Message);
                throw;
            }
            if (double.TryParse(Properties.Settings.Default.Days_left, out double daysLeft))
            {
                if (daysLeft < 0)
                {
                    LoginGui.KeyActivationForm.KeyActivationForm activationForm = new();
                    activationForm.ShowDialog();
                }
            }
            else
            {
                LoginGui.KeyActivationForm.KeyActivationForm activationForm = new();
                activationForm.ShowDialog();

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
                if (!ValidateActivationKey())
                {
                    LoginGui.KeyActivationForm.KeyActivationForm activationForm = new();
                    activationForm.ShowDialog();
                    return;
                }

                if (!await ValidateUserCredentialsAsync())
                {
                    return;
                }

                NavigateToMainForm();
            }
            catch (Exception ex)
            {
                ToasterHelper.ShowErrorHappened(ex.Message);
            }
            finally
            {
                ClearFormFields();
            }
            //try
            //{
            //    SKGL.Validate validate = new SKGL.Validate();
            //    validate.secretPhase = Properties.Settings.Default.Key_crypt;
            //    validate.Key = Properties.Settings.Default.Key;
            //    try
            //    {
            //        double daysLeft = Convert.ToDouble(Properties.Settings.Default.Days_left);
            //        DateTime dateTimeCreate = Convert.ToDateTime(Properties.Settings.Default.Creation);
            //        DateTime dateTimeExp = Convert.ToDateTime(Properties.Settings.Default.Expiration);
            //        if (DateTime.Now.Date < dateTimeCreate.Date)
            //            return;
            //        if (DateTime.Now.Date > dateTimeExp.Date)
            //        {
            //            Properties.Settings.Default.Days_left = "0";
            //            Properties.Settings.Default.Save();
            //        }
            //        if (daysLeft < 0)
            //        {
            //            ToasterHelper.ShowActivationCompleted();
            //            MessageBox.Show("يرجى الاتصال بالمطور", "التفعيل", MessageBoxButtons.OK, MessageBoxIcon.Information);
            //            return;
            //        }

            //    }
            //    catch (Exception ex)
            //    {
            //        ToasterHelper.ShowErrorHappened(ex.Message);
            //        throw;
            //    }

            //    ToasterHelper.PlayNotificationSound();
            //    Code.Helper.ConStringHelper.SetConString();
            //    this._context = new ApplicationDbContext();
            //    if (string.IsNullOrWhiteSpace(txtUsername.Text) || string.IsNullOrWhiteSpace(txtPassowrd.Text))
            //    {
            //        MessageBox.Show("من فضلك ادخل اسم المستخدم وكلمة السر");
            //        return;
            //    }
            //    if (await _context.Database.CanConnectAsync())
            //    {
            //        if (_context.Users.Count() > 0)
            //        {
            //            var result = await _context.Users
            //             .Include(u => u.UserBuy)
            //            .Include(u => u.UserCaisseAndBank)
            //            .Include(u => u.UserCustomer)
            //            .Include(u => u.UserDeservedAndTax)
            //            .Include(u => u.UserEmployee)
            //            .Include(u => u.UserProductAndStore)
            //            .Include(u => u.UserRefund)
            //            .Include(u => u.UserSale)
            //            .Include(u => u.UserSetting)
            //            .Include(u => u.UserSupplier)
            //            .FirstOrDefaultAsync(u => u.UserName == txtUsername.Text && u.Password == txtPassowrd.Text);
            //            if (result == null)
            //            {

            //                ToasterHelper.ShowLoginFailed();

            //            }
            //            else
            //            {
            //                ToasterHelper.ShowLoginSucceded();

            //                _oginForm.Hide();
            //                Code.Models.LocalUser.User = result;
            //                MainForm mainForm = new MainForm();
            //                Properties.Settings.Default.UserName = txtUsername.Text;
            //                Properties.Settings.Default.Save();
            //                mainForm.Show();

            //            }
            //        }
            //        else
            //        {
            //            User user = new()
            //            {
            //                UserName = "ALGD",
            //                Password = "ALGD2025",
            //                UserProfit = 0.00m,
            //                Stock_Id = 1,
            //                type = "مدير"
            //            };
            //            if (_context.Caisses.Count() > 0)
            //            {
            //                if (_context.Caisses.FirstOrDefault(x => x.Id == Properties.Settings.Default.DefaultCaisseId) is not null)
            //                    user.Stock_Id = Properties.Settings.Default.DefaultCaisseId;
            //                else
            //                {
            //                    Caisse caisse = new()
            //                    {
            //                        CaisseName = "الصندوق الاول",
            //                        MoneyinCaisse = 0

            //                    };
            //                    _context.Add(caisse);
            //                    _context.SaveChanges();
            //                    user.Stock_Id = caisse.Id;
            //                }
            //            }
            //            _context.Add(user);
            //            _context.SaveChanges();
            //            AddUserRelatedEntities(user, true);


            //        }
            //    }
            //    else
            //    {
            //        ToasterHelper.ShowConnectionIsNotEstablished();

            //    }
            //}
            //catch (Exception ex)
            //{
            //    ToasterHelper.ShowErrorHappened(ex.Message);
            //    throw;
            //}
            //txtUsername.Text = string.Empty;
            //txtPassowrd.Text = string.Empty;
        }
        private bool ValidateActivationKey()
        {
            SKGL.Validate validate = new SKGL.Validate
            {
                secretPhase = Properties.Settings.Default.Key_crypt,
                Key = Properties.Settings.Default.Key
            };

            double daysLeft = Convert.ToDouble(Properties.Settings.Default.Days_left);
            DateTime dateTimeCreate = Convert.ToDateTime(Properties.Settings.Default.Creation);
            DateTime dateTimeExp = Convert.ToDateTime(Properties.Settings.Default.Expiration);

            if (DateTime.Now.Date < dateTimeCreate.Date)
            {
                return false;
            }

            if (DateTime.Now.Date > dateTimeExp.Date)
            {
                Properties.Settings.Default.Days_left = "0";
                Properties.Settings.Default.Save();
            }

            if (daysLeft < 0)
            {
                ToasterHelper.ShowActivationCompleted();
                MessageBox.Show("يرجى الاتصال بالمطور", "التفعيل", MessageBoxButtons.OK, MessageBoxIcon.Information);
                return false;
            }
            var daysleft = (validate.ExpireDate.Date - validate.CreationDate.Date).TotalDays;
            if (daysleft < 0)
            {
                ToasterHelper.ShowActivationCompleted();
                MessageBox.Show("يرجى الاتصال بالمطور", "التفعيل", MessageBoxButtons.OK, MessageBoxIcon.Information);
                return false;
            }
            Properties.Settings.Default.Days_left = daysleft.ToString();
            Properties.Settings.Default.Save();
            return (validate.IsValid && validate.ExpireDate >= DateTime.Now.Date);
        }

        private async Task<bool> ValidateUserCredentialsAsync()
        {
            if (string.IsNullOrWhiteSpace(txtUsername.Text) || string.IsNullOrWhiteSpace(txtPassowrd.Text))
            {
                MessageBox.Show("من فضلك ادخل اسم المستخدم وكلمة السر");
                return false;
            }

            if (!await _context.Database.CanConnectAsync())
            {
                ToasterHelper.ShowConnectionIsNotEstablished();
                return false;
            }
            if (_context.Users.Count() > 0)
            {
                var user = await _context.Users
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

                if (user == null)
                {
                    ToasterHelper.ShowLoginFailed();
                    return false;
                }
                Code.Models.LocalUser.User = user;
                if (Convert.ToDouble(Properties.Settings.Default.Days_left) < 30)
                {
                    string alerttype = "الاشتراك على وشك الانتهاء";
                    string Message = $"الاشتراك السنوي للبرنامج سوف ينتهي بعد {Properties.Settings.Default.Days_left} يرجي الاتصال بالمطور واخذ نسخة احتياطية من البرنامج";
                    var alert = _context.AlertsTable.FirstOrDefault(x => x.AlertType == alerttype && x.Message == Message && !x.IsResolved);
                    if (alert == null)
                    {
                        AlertTable alertTable = new AlertTable();
                        alertTable.AlertType = alerttype;
                        alertTable.Message = Message;
                        alertTable.Priority = PriorityAlert.High;
                        alertTable.CreatedDate = DateTime.Now;
                        alertTable.IsResolved = false;
                        alertTable.Category = LocalUser.User.UserName;
                        _context.Add(alertTable);
                        _context.SaveChanges();
                    }
                }
                Properties.Settings.Default.UserName = user.UserName;
                Properties.Settings.Default.Save();
                return true;

            }
            else
            {

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
            return false;
        }

        private void NavigateToMainForm()
        {
            _oginForm.Hide();
            //MainForm mainForm = new MainForm();

            //mainForm.Show();
            _oginForm.DialogResult = DialogResult.OK;
            _oginForm.Close();
            _oginForm.Dispose();

        }

        private void ClearFormFields()
        {
            txtUsername.Text = string.Empty;
            txtPassowrd.Text = string.Empty;
        }
        private void AddUserRelatedEntities(User user, bool isAdmin)
        {
            try
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
            catch (Exception ex)
            {
                ToasterHelper.ShowErrorHappened(ex.Message);
                throw;
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
            else if (e.KeyCode == Keys.F7)
                lblActivation.Visible = true;

        }

        private void LoginForm_Load(object sender, EventArgs e)
        {

        }

        private void label5_Click(object sender, EventArgs e)
        {
            LoginGui.KeyActivationForm.KeyActivationForm activationForm = new();
            activationForm.ShowDialog();
        }
    }
}
