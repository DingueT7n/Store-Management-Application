using Store.ApplicationUI.Code.Helper;
using Store.Core.Entities.Caisses;
using Store.Infrastructure.Data;

namespace Store.ApplicationUI.Gui.CaisseAndBankGui.WithdrawFromCaisseGui
{
    public partial class WithdrawFromCaisseUserControl : UserControl
    {
        static WithdrawFromCaisseUserControl _WithdrawFromCaisseUserControl;
        private static CaisseDetailsForm _caisse;
        private static MainForm _main;
        private static ApplicationDbContext _contex;

        public WithdrawFromCaisseUserControl()
        {
            InitializeComponent();
        }
        public static WithdrawFromCaisseUserControl Instance(MainForm main, CaisseDetailsForm caisse)
        {
            _caisse = caisse;
            _main = main;
            _contex = new ApplicationDbContext();

            // If the instance is null, create a new one and assign it to the static field
            if (_WithdrawFromCaisseUserControl == null || _WithdrawFromCaisseUserControl.IsDisposed)
            {
                _WithdrawFromCaisseUserControl = new WithdrawFromCaisseUserControl();
            }
            _WithdrawFromCaisseUserControl.LoadData();

            return _WithdrawFromCaisseUserControl;
        }
        void validate()
        {

            if (cmbCaisse.Items.Count <= 0) { MessageBox.Show("لا يوجد صناديق راجع بياناتك"); return; }
            if (cmbCaisse.Text == "اختر صندوق") return;
        }
        public async void LoadData()
        {
            txtDepositorName.Text = string.Empty;
            txtValue.Text = string.Empty;
            lblValue.Text = "0";
            dateTimePicker.Value = DateTime.Now;

            if (await Task.Run(() => _contex.Database.CanConnect()))
            {
                cmbCaisse.DataSource = _contex.Caisses.ToList();
                cmbCaisse.DisplayMember = "CaisseName";
                cmbCaisse.ValueMember = "Id";
                cmbCaisse.Text = "اختر صندوق";
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

        private void cmbCaisse_SelectionChangeCommitted(object sender, EventArgs e)
        {
            try
            {
                validate();
                var value = _contex.Caisses.FirstOrDefault(x => x.Id.ToString() == cmbCaisse.SelectedValue.ToString()).MoneyinCaisse;
                lblValue.Text = value.ToString();
            }
            catch (Exception)
            {

                throw;
            }
        }

        private async void btnDepositToCaisse_Click(object sender, EventArgs e)
        {
            using (var transaction = await _contex.Database.BeginTransactionAsync())
            {
                try
                {
                    var caisse = _contex.Caisses.FirstOrDefault(x => x.Id.ToString() == cmbCaisse.SelectedValue);

                    if (caisse is not null)
                    {
                        if (_main.ConvertToFloat(txtValue.Text) > 0)
                        {
                            caisse.MoneyinCaisse -= _main.ConvertToFloat(txtValue.Text);

                            var caisseDeposit = new CaisseWithdraw
                            {
                                Caisse_ID = Convert.ToInt32(cmbCaisse.SelectedValue),
                                Time = DateTime.Now.ToString("HH:mm:ss"),
                                Date = dateTimePicker.Value,
                                Name = $"  {Properties.Settings.Default.UserName}  {txtDepositorName.Text} بحساب ",
                                Money = _main.ConvertToFloat(txtValue.Text),
                                Reason = textBox1.Text,
                                Type = "سحب عادي (مال فائض )"
                            };

                            _contex.Caisses.Update(caisse);
                            await _contex.CaissesWithdraws.AddAsync(caisseDeposit);

                            // Save all changes to the database
                            await _contex.SaveChangesAsync();

                            // Commit the transaction
                            await transaction.CommitAsync();
                            Code.Helper.ToasterHelper.ShowWithdraw();

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
