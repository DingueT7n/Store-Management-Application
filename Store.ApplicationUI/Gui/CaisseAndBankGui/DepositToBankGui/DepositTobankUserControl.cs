using Microsoft.EntityFrameworkCore;
using Store.ApplicationUI.Code.Helper;
using Store.Core.Entities.Banks;
using Store.Infrastructure.Data;

namespace Store.ApplicationUI.Gui.CaisseAndBankGui.DepositToBankGui
{
    public partial class DepositTobankUserControl : UserControl
    {
        private readonly MainForm _main;
        private readonly CaisseDetailsForm _caisse;
        private readonly ApplicationDbContext _context;

        public DepositTobankUserControl(MainForm main, CaisseDetailsForm caisse, ApplicationDbContext context)
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

        private async void btnDepositToCaisse_Click(object sender, EventArgs e)
        {
            ToasterHelper.PlayNotificationSound();
            using (var transaction = await _context.Database.BeginTransactionAsync())
            {
                try
                {
                    var Bank = await _context.Banks.FirstOrDefaultAsync();

                    if (Bank is not null)
                    {
                        if (_main.ConvertToFloat(txtValue.Text) > 0)
                        {
                            Bank.Money += _main.ConvertToFloat(txtValue.Text);

                            var BankDeposit = new BankDeposit
                            {
                                Time = DateTime.Now.ToString("HH:mm:ss"),
                                Date = dateTimePicker.Value,
                                Name = $"  {Properties.Settings.Default.UserName}  {txtDepositorName.Text} بحساب ",
                                Money = _main.ConvertToFloat(txtValue.Text),
                                Reason = textBox1.Text,
                                Type = "ايداع عادي (مال اضافي )"
                            };

                            _context.Banks.Update(Bank);
                            await _context.BankDeposits.AddAsync(BankDeposit);

                            // Save all changes to the database
                            await _context.SaveChangesAsync();

                            // Commit the transaction
                            await transaction.CommitAsync();
                            Code.Helper.ToasterHelper.ShowDeposit();
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
