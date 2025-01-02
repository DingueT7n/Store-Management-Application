using Store.ApplicationUI.Code.Helper;
using Store.Core.Entities.Banks;
using Store.Infrastructure.Data;

namespace Store.ApplicationUI.Gui.CaisseAndBankGui.DepositToBankGui
{
    public partial class DepositTobankUserControl : UserControl
    {
        static DepositTobankUserControl _depositTobankUserControl;
        private static CaisseDetailsForm _caisse;
        private static MainForm _main;
        private static ApplicationDbContext _context;

        public DepositTobankUserControl()
        {
            InitializeComponent();
        }
        public static DepositTobankUserControl Instance(MainForm main, CaisseDetailsForm caisse)
        {
            _caisse = caisse;
            _main = main;
            // If the instance is null, create a new one and assign it to the static field
            _context = new ApplicationDbContext();
            if (_depositTobankUserControl == null || _depositTobankUserControl.IsDisposed)
            {
                _depositTobankUserControl = new DepositTobankUserControl();
            }
            _depositTobankUserControl.LoadData();

            return _depositTobankUserControl;
        }

        public async void LoadData()
        {
            txtDepositorName.Text = string.Empty;
            txtValue.Text = string.Empty;
            lblValue.Text = "0";
            dateTimePicker.Value = DateTime.Now;

            if (await Task.Run(() => _context.Database.CanConnect()))
            {
                lblValue.Text = _context.Banks.FirstOrDefault().Money.ToString();

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
                    var Bank = _context.Banks.FirstOrDefault();

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
