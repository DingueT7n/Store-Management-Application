using Store.ApplicationUI.Code.Helper;
using Store.ApplicationUI.Code.Models;
using Store.Core.Entities.Banks;
using Store.Infrastructure.Data;

namespace Store.ApplicationUI.Gui.CaisseAndBankGui.WithdrawFromBank
{
    public partial class WithdrawFromBankUserControl : UserControl
    {
        static WithdrawFromBankUserControl _WithdrawFromBankUserControl;
        private static CaisseDetailsForm _caisse;
        private static MainForm _main;
        private static ApplicationDbContext _contex;

        public WithdrawFromBankUserControl()
        {
            InitializeComponent();
        }
        public static WithdrawFromBankUserControl Instance(MainForm main, CaisseDetailsForm caisse)
        {
            _caisse = caisse;
            _main = main;
            _contex = new ApplicationDbContext();

            // If the instance is null, create a new one and assign it to the static field
            if (_WithdrawFromBankUserControl == null || _WithdrawFromBankUserControl.IsDisposed)
            {
                _WithdrawFromBankUserControl = new WithdrawFromBankUserControl();
            }
            _WithdrawFromBankUserControl.LoadData();

            return _WithdrawFromBankUserControl;
        }
        public async void LoadData()
        {
            txtDepositorName.Text = string.Empty;
            txtValue.Text = string.Empty;
            lblValue.Text = "0";
            dateTimePicker.Value = DateTime.Now;

            if (await Task.Run(() => _contex.Database.CanConnect()))
            {
                lblValue.Text = _contex.Banks.FirstOrDefault().Money.ToString();

            }
            else
            {
                MsgHelper.ShowServerError();
            }
            if (LocalUser.User is not null)
                txtDepositorName.Text = LocalUser.User.UserName;


        }

        private void txtValue_KeyPress(object sender, KeyPressEventArgs e)
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

        private async void btnWithdraw_Click(object sender, EventArgs e)
        {
            ToasterHelper.PlayNotificationSound();
            using (var transaction = await _contex.Database.BeginTransactionAsync())
            {
                try
                {
                    var bank = _contex.Banks.FirstOrDefault();

                    if (bank is not null)
                    {
                        if (_main.ConvertToFloat(txtValue.Text) > 0)
                        {
                            bank.Money -= _main.ConvertToFloat(txtValue.Text);

                            var bankDeposit = new BankWithdraw
                            {

                                Time = DateTime.Now.ToString("HH:mm:ss"),
                                Date = dateTimePicker.Value,
                                Name = $"  {Properties.Settings.Default.UserName}  {txtDepositorName.Text} بحساب ",
                                Money = _main.ConvertToFloat(txtValue.Text),
                                Reason = textBox1.Text,
                                Type = "سحب عادي (مال فائض )"
                            };

                            _contex.Banks.Update(bank);
                            await _contex.BankWithdraws.AddAsync(bankDeposit);

                            // Save all changes to the database
                            await _contex.SaveChangesAsync();

                            // Commit the transaction
                            await transaction.CommitAsync();
                            Code.Helper.ToasterHelper.ShowWithdraw();
                            CaisseDetailsForm.CheckInstance();
                        }
                    }

                    // Load data after successful transaction
                    LoadData();
                }
                catch (Exception ex)
                {

                    await transaction.RollbackAsync();


                }
            }
        }
    }
}
