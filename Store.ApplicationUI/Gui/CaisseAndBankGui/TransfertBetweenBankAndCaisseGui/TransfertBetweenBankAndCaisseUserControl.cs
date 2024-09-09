using Store.ApplicationUI.Code.Helper;
using Store.Core.Entities.Banks;
using Store.Core.Entities.Caisses;

namespace Store.ApplicationUI.Gui.CaisseAndBankGui.TransfertBetweenBankAndCaisseGui
{
    public partial class TransfertBetweenBankAndCaisseUserControl : UserControl
    {
        static TransfertBetweenBankAndCaisseUserControl _TransfertBetweenBankAndCaisseUserControl;
        private static CaisseDetailsForm _caisse;
        private static MainForm _main;
        public TransfertBetweenBankAndCaisseUserControl()
        {
            InitializeComponent();
        }
        public static TransfertBetweenBankAndCaisseUserControl Instance(MainForm main, CaisseDetailsForm caisse)
        {
            _caisse = caisse;
            _main = main;
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

            if (await Task.Run(() => MainForm.Context.Database.CanConnect()))
            {
                cmbCaisseFrom.DataSource = MainForm.Context.Caisses.ToList();

                cmbCaisseFrom.DisplayMember = "CaisseName";
                cmbCaisseFrom.ValueMember = "Id";
                cmbCaisseFrom.Text = "اختر صندوق";
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

        private void cmbCaisseFrom_SelectionChangeCommitted(object sender, EventArgs e)
        {
            try
            {
                validate();
                var value = MainForm.Context.Caisses.FirstOrDefault(x => x.Id.ToString() == cmbCaisseFrom.SelectedValue.ToString()).MoneyinCaisse;
                lblValueCiasse.Text = value.ToString();
            }
            catch (Exception)
            {

                throw;
            }
        }

        private async void btnDepositToCaisse_Click(object sender, EventArgs e)
        {
            validate();
            if (rbCaisseToBank.Checked)
            {
                if (Convert.ToDouble(txtValue.Text) > Convert.ToDouble(lblValueCiasse.Text)) { MessageBox.Show($"الصنودق المرسل لديه قيمى اصغر من المحولة"); return; }


                using (var transaction = await MainForm.Context.Database.BeginTransactionAsync())
                {
                    try
                    {
                        var caisseFrom = MainForm.Context.Caisses.FirstOrDefault(x => x.Id.ToString() == cmbCaisseFrom.SelectedValue);
                        var bank = MainForm.Context.Banks.FirstOrDefault();

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
                                MainForm.Context.Caisses.Update(caisseFrom);
                                MainForm.Context.Banks.Update(bank);
                                await MainForm.Context.CaissesBankTransferes.AddAsync(caisseBankTransfere);
                                await MainForm.Context.CaissesWithdraws.AddAsync(caisseWithdraw);
                                await MainForm.Context.BankDeposits.AddAsync(BankDeposit);
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
                        MessageBox.Show(ex.Message);

                        await transaction.RollbackAsync();


                    }
                }
            }
            else
            {
                if (Convert.ToDouble(txtValue.Text) > Convert.ToDouble(lblValue.Text)) { MessageBox.Show($"البنك لديه قيمى اصغر من المحولة"); return; }


                using (var transaction = await MainForm.Context.Database.BeginTransactionAsync())
                {
                    try
                    {
                        var caisseFrom = MainForm.Context.Caisses.FirstOrDefault(x => x.Id.ToString() == cmbCaisseFrom.SelectedValue);
                        var bank = MainForm.Context.Banks.FirstOrDefault();

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
                                MainForm.Context.Caisses.Update(caisseFrom);
                                MainForm.Context.Banks.Update(bank);
                                await MainForm.Context.CaissesBankTransferes.AddAsync(caisseBankTransfere);
                                await MainForm.Context.CaissesDeposits.AddAsync(caisseDeposit);
                                await MainForm.Context.BankWithdraws.AddAsync(bankWithdraw);
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
                        MessageBox.Show(ex.Message);
                        await transaction.RollbackAsync();


                    }
                }
            }
        }
    }
}
