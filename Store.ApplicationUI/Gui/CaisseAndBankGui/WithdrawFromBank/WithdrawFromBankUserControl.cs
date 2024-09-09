using Store.ApplicationUI.Code.Helper;
using Store.Core.Entities.Banks;

namespace Store.ApplicationUI.Gui.CaisseAndBankGui.WithdrawFromBank
{
    public partial class WithdrawFromBankUserControl : UserControl
    {
        static WithdrawFromBankUserControl _WithdrawFromBankUserControl;
        private static CaisseDetailsForm _caisse;
        private static MainForm _main;
        public WithdrawFromBankUserControl()
        {
            InitializeComponent();
        }
        public static WithdrawFromBankUserControl Instance(MainForm main, CaisseDetailsForm caisse)
        {
            _caisse = caisse;
            _main = main;
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

            if (await Task.Run(() => MainForm.Context.Database.CanConnect()))
            {
                lblValue.Text = MainForm.Context.Banks.FirstOrDefault().Money.ToString();

            }
            else
            {
                MsgHelper.ShowServerError();
            }


        }

        private void txtValue_KeyPress(object sender, KeyPressEventArgs e)
        {
            if (!char.IsDigit(e.KeyChar) && e.KeyChar != Properties.Settings.Default.DecimalSEP[0] && e.KeyChar != 8)
            {
                e.Handled = true;
            }
        }

        private async void btnWithdraw_Click(object sender, EventArgs e)
        {
            using (var transaction = await MainForm.Context.Database.BeginTransactionAsync())
            {
                try
                {
                    var bank = MainForm.Context.Banks.FirstOrDefault();

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

                            MainForm.Context.Banks.Update(bank);
                            await MainForm.Context.BankWithdraws.AddAsync(bankDeposit);

                            // Save all changes to the database
                            await MainForm.Context.SaveChangesAsync();

                            // Commit the transaction
                            await transaction.CommitAsync();
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
