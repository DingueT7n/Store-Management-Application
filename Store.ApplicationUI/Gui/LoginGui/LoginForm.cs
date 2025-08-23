using Microsoft.EntityFrameworkCore;
using Microsoft.IdentityModel.Tokens;
using Store.ApplicationUI.Code.Helper;
using Store.ApplicationUI.Code.Models;
using Store.ApplicationUI.Code.System;
using Store.Core.Entities.Caisses;
using Store.Core.Entities.Helpers;
using Store.Core.Entities.Users;
using Store.Infrastructure.Data;

namespace Store.ApplicationUI.Gui.LoginGui
{
    public partial class LoginForm : Form
    {
        private readonly ApplicationDbContext _context;
        public readonly LoginForm _oginForm;
        private readonly ControlManager _controlManager;

        public LoginForm(ApplicationDbContext context, ControlManager controlManager)
        {
            try
            {
                InitializeComponent();
                Code.Helper.ConStringHelper.SetConString();
                _context = context;
                _oginForm = this;

            }
            catch (Exception ex)
            {
                ToasterHelper.ShowErrorHappened(ex.Message);
                throw;
            }
            if (!Properties.Settings.Default.Days_left.IsNullOrEmpty() || Properties.Settings.Default.Days_left == string.Empty)
            {
                if (double.TryParse(Properties.Settings.Default.Days_left, out double daysLeft))
                {
                    if (daysLeft < 0)
                    {
                        LoginGui.KeyActivationForm.KeyActivationForm activationForm = _controlManager.GetF<KeyActivationForm.KeyActivationForm>();
                        activationForm.ShowDialog();
                    }
                }
            }
            else
            {
                LoginGui.KeyActivationForm.KeyActivationForm activationForm = _controlManager.GetF<KeyActivationForm.KeyActivationForm>();
                activationForm.ShowDialog();

            }

            _controlManager = controlManager;
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
                    LoginGui.KeyActivationForm.KeyActivationForm activationForm = _controlManager.GetF<KeyActivationForm.KeyActivationForm>();
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
        }
        private bool ValidateActivationKey()
        {
            try
            {
                // Initialize validator
                var validate = new SKGL.Validate
                {
                    secretPhase = Properties.Settings.Default.Key_crypt,
                    Key = Properties.Settings.Default.Key
                };

                // Load stored settings
                DateTime creationDate;
                DateTime expirationDate;
                double storedDaysLeft;

                if (!DateTime.TryParse(Properties.Settings.Default.Creation, out creationDate))
                    creationDate = DateTime.MinValue;

                if (!DateTime.TryParse(Properties.Settings.Default.Expiration, out expirationDate))
                    expirationDate = DateTime.MinValue;

                if (!double.TryParse(Properties.Settings.Default.Days_left, out storedDaysLeft))
                    storedDaysLeft = 0;

                // 1. Safety check: system clock tampering (date earlier than creation)
                if (DateTime.Now.Date < creationDate.Date)
                {
                    MessageBox.Show("تم اكتشاف مشكلة في التاريخ. يرجى التحقق من إعدادات النظام.",
                        "خطأ التفعيل", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                    return false;
                }

                // 2. Expired by saved expiration
                if (DateTime.Now.Date > expirationDate.Date)
                {
                    Properties.Settings.Default.Days_left = "0";
                    Properties.Settings.Default.Save();
                    MessageBox.Show("انتهت صلاحية المفتاح. يرجى الاتصال بالمطور.",
                        "التفعيل", MessageBoxButtons.OK, MessageBoxIcon.Information);
                    return false;
                }

                // 3. Days left check from stored value
                if (storedDaysLeft <= 0)
                {
                    ToasterHelper.ShowActivationCompleted();
                    MessageBox.Show("انتهت صلاحية المفتاح. يرجى الاتصال بالمطور.",
                        "التفعيل", MessageBoxButtons.OK, MessageBoxIcon.Information);
                    return false;
                }

                // 4. Validate using SKGL
                var daysLeft = (validate.ExpireDate.Date - DateTime.Now.Date).TotalDays;

                if (daysLeft < 0 || !validate.IsValid)
                {
                    ToasterHelper.ShowActivationCompleted();
                    MessageBox.Show("انتهت صلاحية المفتاح. يرجى الاتصال بالمطور.",
                        "التفعيل", MessageBoxButtons.OK, MessageBoxIcon.Information);
                    return false;
                }

                // Update settings safely
                Properties.Settings.Default.Days_left = daysLeft.ToString("F0");
                Properties.Settings.Default.Save();

                return true;
            }
            catch (Exception ex)
            {
                // Centralized error handling for unexpected failures
                MessageBox.Show($"حدث خطأ أثناء التحقق من التفعيل:\n{ex.Message}",
                    "خطأ", MessageBoxButtons.OK, MessageBoxIcon.Error);
                return false;
            }
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
            if (await _context.Users.AsNoTracking().CountAsync() > 0)
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
                    var alert = await _context.AlertsTable.AsNoTracking().FirstOrDefaultAsync(x => x.AlertType == alerttype && x.Message == Message && !x.IsResolved);
                    if (alert == null)
                    {
                        AlertTable alertTable = new AlertTable();
                        alertTable.AlertType = alerttype;
                        alertTable.Message = Message;
                        alertTable.Priority = PriorityAlert.High;
                        alertTable.CreatedDate = DateTime.Now;
                        alertTable.IsResolved = false;
                        alertTable.Category = LocalUser.User.UserName;
                        await _context.AddAsync(alertTable);
                        await _context.SaveChangesAsync();
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
                        if (await _context.Caisses.AsNoTracking().FirstOrDefaultAsync(x => x.Id == Properties.Settings.Default.DefaultCaisseId) is not null)
                            user.Stock_Id = Properties.Settings.Default.DefaultCaisseId;
                        else
                        {
                            Caisse caisse = new()
                            {
                                CaisseName = "الصندوق الاول",
                                MoneyinCaisse = 0

                            };
                            await _context.AddAsync(caisse);
                            await _context.SaveChangesAsync();
                            user.Stock_Id = caisse.Id;
                        }
                    }
                    await _context.AddAsync(user);
                    await _context.SaveChangesAsync();
                    await AddUserRelatedEntities(user, true);


                }
            }
            return false;
        }

        private void NavigateToMainForm()
        {
            //_oginForm.Hide();
            //MainForm mainForm = new MainForm();

            //mainForm.Show();
            Properties.Settings.Default.UserName = txtUsername.Text;
            Properties.Settings.Default.Password = txtPassowrd.Text;
            Properties.Settings.Default.Save();
            _oginForm.DialogResult = DialogResult.OK;
            _oginForm.Close();
            _oginForm.Dispose();

        }

        private void ClearFormFields()
        {
            txtUsername.Text = string.Empty;
            txtPassowrd.Text = string.Empty;
        }
        private async Task AddUserRelatedEntities(User user, bool isAdmin)
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
                await _context.SaveChangesAsync();
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
            ConnectionSettingsForm connectionSettingsForm = _controlManager.GetF<ConnectionSettingsForm>();
            this.Hide();
            connectionSettingsForm.ShowDialog();
            this.Show();

        }

        private void LoginForm_KeyDown(object sender, KeyEventArgs e)
        {
            if (e.KeyCode == Keys.F12)
            {
                ToasterHelper.PlayNotificationSound();
                ConnectionSettingsForm connectionSettingsForm = _controlManager.GetF<ConnectionSettingsForm>();
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

        private async void button2_Click_1(object sender, EventArgs e)
        {
            ToasterHelper.PlayNotificationSound();
            Close();
            Application.Exit();
        }

        private async void button1_Click_1(object sender, EventArgs e)
        {
            try
            {
                if (!ValidateActivationKey())
                {
                    LoginGui.KeyActivationForm.KeyActivationForm activationForm = _controlManager.GetF<KeyActivationForm.KeyActivationForm>();
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
        }
    }
}
