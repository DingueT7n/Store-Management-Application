using Microsoft.EntityFrameworkCore;
using Store.ApplicationUI.Code.Helper;
using Store.ApplicationUI.Code.Models;
using Store.Core.Entities.Banks;
using Store.Infrastructure.Data;

namespace Store.ApplicationUI.Gui.CaisseAndBankGui.WithdrawFromBank
{
    public partial class WithdrawFromBankUserControl : UserControl
    {
        private readonly MainForm _main;
        private readonly CaisseDetailsForm _caisse;
        private readonly ApplicationDbContext _context;

        public WithdrawFromBankUserControl(MainForm main, CaisseDetailsForm caisse, ApplicationDbContext context)
        {
            InitializeComponent();
            _main = main;
            _caisse = caisse;
            _context = context;
        }

        public async void LoadData()
        {
            txtDepositorName.Text = string.Empty;
            txtValue.Text = string.Empty;
            lblValue.Text = "0";
            dateTimePicker.Value = DateTime.Now;

            if (await _context.Database.CanConnectAsync())
            {
                lblValue.Text = (await _context.Banks.FirstOrDefaultAsync()).Money.ToString();

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
            using (var transaction = await _context.Database.BeginTransactionAsync())
            {
                try
                {
                    var bank = await _context.Banks.FirstOrDefaultAsync();

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

                            _context.Banks.Update(bank);
                            await _context.BankWithdraws.AddAsync(bankDeposit);

                            // Save all changes to the database
                            await _context.SaveChangesAsync();

                            // Commit the transaction
                            await transaction.CommitAsync();
                            Code.Helper.ToasterHelper.ShowWithdraw();
                            _caisse.LoadData();
                        }
                    }

                    // Load data after successful transaction
                    LoadData();
                }
                catch (Exception)
                {

                    await transaction.RollbackAsync();


                }
            }
        }
    }
}
