using Microsoft.EntityFrameworkCore;
using Store.ApplicationUI.Code.Helper;
using Store.ApplicationUI.Code.Models;
using Store.Core.Entities.Banks;
using Store.Core.Entities.Caisses;
using Store.Infrastructure.Data;

namespace Store.ApplicationUI.Gui.CaisseAndBankGui.TransfertBetweenBankAndCaisseGui
{
    public partial class TransfertBetweenBankAndCaisseUserControl : UserControl
    {
        private readonly MainForm _main;
        private readonly CaisseDetailsForm _caisse;
        private readonly ApplicationDbContext _context;
        public TransfertBetweenBankAndCaisseUserControl(MainForm main, CaisseDetailsForm caisse, ApplicationDbContext context)
        {
            InitializeComponent();
            _main = main;
            _caisse = caisse;
            _context = context;
        }

        void validate()
        {

            if (cmbCaisseFrom.Items.Count <= 0) { MessageBox.Show("لا يوجد صناديق راجع بياناتك"); return; }
            if (cmbCaisseFrom.Text == "اختر صندوق") return;

        }
        public async Task LoadData()
        {
            dgvHelper.ResetForm(this);

            txtDepositorName.Text = string.Empty;
            txtValue.Text = string.Empty;
            lblValue.Text = "0";
            dateTimePicker.Value = DateTime.Now;

            if (await _context.Database.CanConnectAsync())
            {
                cmbCaisseFrom.DataSource = await _context.Caisses.ToListAsync();

                cmbCaisseFrom.DisplayMember = "CaisseName";
                cmbCaisseFrom.ValueMember = "Id";
                cmbCaisseFrom.Text = "اختر صندوق";
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

        private async void cmbCaisseFrom_SelectionChangeCommitted(object sender, EventArgs e)
        {

            validate();
            var value = (await _context.Caisses.FirstOrDefaultAsync(x => x.Id.ToString() == cmbCaisseFrom.SelectedValue.ToString())).MoneyinCaisse;
            lblValueCiasse.Text = value.ToString();

        }

        private async void btnDepositToCaisse_Click(object sender, EventArgs e)
        {
            ToasterHelper.PlayNotificationSound();
            validate();
            if (rbCaisseToBank.Checked)
            {
                if (Convert.ToDouble(txtValue.Text) > Convert.ToDouble(lblValueCiasse.Text)) { MessageBox.Show($"الصنودق المرسل لديه قيمى اصغر من المحولة"); return; }


                using (var transaction = await _context.Database.BeginTransactionAsync())
                {
                    try
                    {
                        var caisseFrom = await _context.Caisses.FirstOrDefaultAsync(x => x.Id.ToString() == cmbCaisseFrom.SelectedValue);
                        var bank = await _context.Banks.FirstOrDefaultAsync();

                        if (caisseFrom is not null)
                        {
                            if (_main.ConvertToFloat(txtValue.Text) > 0)
                            {
                                caisseFrom.MoneyinCaisse -= _main.ConvertToFloat(txtValue.Text);

                                bank.Money += _main.ConvertToFloat(txtValue.Text);
                                var caisseWithdraw = new CaisseWithdraw
                                {
                                    Caisse_ID = Convert.ToInt32(cmbCaisseFrom.SelectedValue),
                                    Time = DateTime.Now.ToString("HH:mm:ss"),
                                    Date = dateTimePicker.Value,
                                    Name = $"  {Properties.Settings.Default.UserName}  {txtDepositorName.Text} بحساب ",
                                    Money = _main.ConvertToFloat(txtValue.Text),
                                    Reason = textBox1.Text,
                                    Type = $"سحب مرسل الى البنك (مال محول )"
                                };
                                var caisseBankTransfere = new CaisseBankTransfere
                                {
                                    To_ = "بنك",
                                    From_ = cmbCaisseFrom.Text,
                                    Time = DateTime.Now.ToString("HH:mm:ss"),
                                    Date = dateTimePicker.Value,
                                    Name = $"  {Properties.Settings.Default.UserName}  {txtDepositorName.Text} بحساب ",
                                    Money = _main.ConvertToFloat(txtValue.Text),

                                };
                                var BankDeposit = new BankDeposit
                                {
                                    Time = DateTime.Now.ToString("HH:mm:ss"),
                                    Date = dateTimePicker.Value,
                                    Name = $"  {Properties.Settings.Default.UserName}  {txtDepositorName.Text} بحساب ",
                                    Money = _main.ConvertToFloat(txtValue.Text),
                                    Reason = textBox1.Text,
                                    Type = $"ايداع محول من {cmbCaisseFrom.Text} (مال اضافي )"
                                };
                                _context.Caisses.Update(caisseFrom);
                                _context.Banks.Update(bank);
                                await _context.CaissesBankTransferes.AddAsync(caisseBankTransfere);
                                await _context.CaissesWithdraws.AddAsync(caisseWithdraw);
                                await _context.BankDeposits.AddAsync(BankDeposit);
                                await _context.SaveChangesAsync();

                                // Commit the transaction
                                await transaction.CommitAsync();
                                Code.Helper.ToasterHelper.ShowTransfert();
                                await _caisse.LoadData();
                            }
                        }

                        // Load data after successful transaction
                        await LoadData();
                    }
                    catch (Exception ex)
                    {
                        MessageBox.Show(ex.Message);

                        await transaction.RollbackAsync();


                    }
                }
            }
            else
            {
                if (Convert.ToDouble(txtValue.Text) > Convert.ToDouble(lblValue.Text)) { MessageBox.Show($"البنك لديه قيمى اصغر من المحولة"); return; }


                using (var transaction = await _context.Database.BeginTransactionAsync())
                {
                    try
                    {
                        var caisseFrom = await _context.Caisses.FirstOrDefaultAsync(x => x.Id.ToString() == cmbCaisseFrom.SelectedValue);
                        var bank = await _context.Banks.FirstOrDefaultAsync();

                        if (caisseFrom is not null)
                        {
                            if (_main.ConvertToFloat(txtValue.Text) > 0)
                            {
                                caisseFrom.MoneyinCaisse += _main.ConvertToFloat(txtValue.Text);

                                bank.Money -= _main.ConvertToFloat(txtValue.Text);
                                var caisseDeposit = new CaisseDeposit
                                {
                                    Caisse_ID = Convert.ToInt32(cmbCaisseFrom.SelectedValue),
                                    Time = DateTime.Now.ToString("HH:mm:ss"),
                                    Date = dateTimePicker.Value,
                                    Name = $"  {Properties.Settings.Default.UserName}  {txtDepositorName.Text} بحساب ",
                                    Money = _main.ConvertToFloat(txtValue.Text),
                                    Reason = textBox1.Text,
                                    Type = $"ايداع مستقبل من البنك (مال محول )"
                                };
                                var caisseBankTransfere = new CaisseBankTransfere
                                {
                                    To_ = cmbCaisseFrom.Text,
                                    From_ = "بنك",
                                    Time = DateTime.Now.ToString("HH:mm:ss"),
                                    Date = dateTimePicker.Value,
                                    Name = $"  {Properties.Settings.Default.UserName}  {txtDepositorName.Text} بحساب ",
                                    Money = _main.ConvertToFloat(txtValue.Text),

                                };
                                var bankWithdraw = new BankWithdraw
                                {
                                    Time = DateTime.Now.ToString("HH:mm:ss"),
                                    Date = dateTimePicker.Value,
                                    Name = $"  {Properties.Settings.Default.UserName}  {txtDepositorName.Text} بحساب ",
                                    Money = _main.ConvertToFloat(txtValue.Text),
                                    Reason = textBox1.Text,
                                    Type = $"سحب محول الى {cmbCaisseFrom.Text} (مال مودع )"
                                };
                                _context.Caisses.Update(caisseFrom);
                                _context.Banks.Update(bank);
                                await _context.CaissesBankTransferes.AddAsync(caisseBankTransfere);
                                await _context.CaissesDeposits.AddAsync(caisseDeposit);
                                await _context.BankWithdraws.AddAsync(bankWithdraw);
                                await _context.SaveChangesAsync();

                                // Commit the transaction
                                await transaction.CommitAsync();
                                Code.Helper.ToasterHelper.ShowTransfert();
                                await _caisse.LoadData();
                            }
                        }

                        // Load data after successful transaction
                        await LoadData();
                    }
                    catch (Exception ex)
                    {
                        MessageBox.Show(ex.Message);
                        await transaction.RollbackAsync();


                    }
                }
            }
        }
    }
}
