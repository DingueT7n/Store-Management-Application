using Store.ApplicationUI.Code.Helper;
using Store.ApplicationUI.Code.Models;
using Store.Core.Entities.Banks;
using Store.Core.Entities.Caisses;
using Store.Infrastructure.Data;

namespace Store.ApplicationUI.Gui.CaisseAndBankGui.TransfertBetweenBankAndCaisseGui
{
    public partial class TransfertBetweenBankAndCaisseUserControl : UserControl
    {
        static TransfertBetweenBankAndCaisseUserControl _TransfertBetweenBankAndCaisseUserControl;
        private static CaisseDetailsForm _caisse;
        private static ApplicationDbContext _contex;
        private static MainForm _main;
        public TransfertBetweenBankAndCaisseUserControl()
        {
            InitializeComponent();
        }
        public static TransfertBetweenBankAndCaisseUserControl Instance(MainForm main, CaisseDetailsForm caisse)
        {
            _caisse = caisse;
            _main = main;
            _contex = new ApplicationDbContext();

            // If the instance is null, create a new one and assign it to the static field
            if (_TransfertBetweenBankAndCaisseUserControl == null || _TransfertBetweenBankAndCaisseUserControl.IsDisposed)
            {
                _TransfertBetweenBankAndCaisseUserControl = new TransfertBetweenBankAndCaisseUserControl();
            }
            _TransfertBetweenBankAndCaisseUserControl.LoadData();

            return _TransfertBetweenBankAndCaisseUserControl;
        }
        void validate()
        {

            if (cmbCaisseFrom.Items.Count <= 0) { MessageBox.Show("لا يوجد صناديق راجع بياناتك"); return; }
            if (cmbCaisseFrom.Text == "اختر صندوق") return;

        }
        public async void LoadData()
        {
            txtDepositorName.Text = string.Empty;
            txtValue.Text = string.Empty;
            lblValue.Text = "0";
            dateTimePicker.Value = DateTime.Now;

            if (await Task.Run(() => _contex.Database.CanConnect()))
            {
                cmbCaisseFrom.DataSource = _contex.Caisses.ToList();

                cmbCaisseFrom.DisplayMember = "CaisseName";
                cmbCaisseFrom.ValueMember = "Id";
                cmbCaisseFrom.Text = "اختر صندوق";
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

        private void cmbCaisseFrom_SelectionChangeCommitted(object sender, EventArgs e)
        {
            try
            {
                validate();
                var value = _contex.Caisses.FirstOrDefault(x => x.Id.ToString() == cmbCaisseFrom.SelectedValue.ToString()).MoneyinCaisse;
                lblValueCiasse.Text = value.ToString();
            }
            catch (Exception)
            {

                throw;
            }
        }

        private async void btnDepositToCaisse_Click(object sender, EventArgs e)
        {
            ToasterHelper.PlayNotificationSound();
            validate();
            if (rbCaisseToBank.Checked)
            {
                if (Convert.ToDouble(txtValue.Text) > Convert.ToDouble(lblValueCiasse.Text)) { MessageBox.Show($"الصنودق المرسل لديه قيمى اصغر من المحولة"); return; }


                using (var transaction = await _contex.Database.BeginTransactionAsync())
                {
                    try
                    {
                        var caisseFrom = _contex.Caisses.FirstOrDefault(x => x.Id.ToString() == cmbCaisseFrom.SelectedValue);
                        var bank = _contex.Banks.FirstOrDefault();

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
                                _contex.Caisses.Update(caisseFrom);
                                _contex.Banks.Update(bank);
                                await _contex.CaissesBankTransferes.AddAsync(caisseBankTransfere);
                                await _contex.CaissesWithdraws.AddAsync(caisseWithdraw);
                                await _contex.BankDeposits.AddAsync(BankDeposit);
                                await _contex.SaveChangesAsync();

                                // Commit the transaction
                                await transaction.CommitAsync();
                                Code.Helper.ToasterHelper.ShowTransfert();

                            }
                        }

                        // Load data after successful transaction
                        LoadData();
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


                using (var transaction = await _contex.Database.BeginTransactionAsync())
                {
                    try
                    {
                        var caisseFrom = _contex.Caisses.FirstOrDefault(x => x.Id.ToString() == cmbCaisseFrom.SelectedValue);
                        var bank = _contex.Banks.FirstOrDefault();

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
                                _contex.Caisses.Update(caisseFrom);
                                _contex.Banks.Update(bank);
                                await _contex.CaissesBankTransferes.AddAsync(caisseBankTransfere);
                                await _contex.CaissesDeposits.AddAsync(caisseDeposit);
                                await _contex.BankWithdraws.AddAsync(bankWithdraw);
                                await _contex.SaveChangesAsync();

                                // Commit the transaction
                                await transaction.CommitAsync();
                            }
                        }

                        // Load data after successful transaction
                        LoadData();
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
