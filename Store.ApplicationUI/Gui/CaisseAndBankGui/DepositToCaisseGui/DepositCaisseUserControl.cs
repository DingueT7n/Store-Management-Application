using Store.ApplicationUI.Code.Helper;
using Store.Core.Entities.Caisses;

namespace Store.ApplicationUI.Gui.CaisseAndBankGui.DepositToCaisseGui
{
    public partial class DepositCaisseUserControl : UserControl
    {
        static DepositCaisseUserControl _depositCaisseUserControl;
        private static CaisseDetailsForm _caisse;
        private static MainForm _main;

        public DepositCaisseUserControl()
        {
            InitializeComponent();
        }
        public static DepositCaisseUserControl Instance(MainForm main, CaisseDetailsForm caisse)
        {
            _caisse = caisse;
            _main = main;
            // If the instance is null, create a new one and assign it to the static field
            if (_depositCaisseUserControl == null || _depositCaisseUserControl.IsDisposed)
            {
                _depositCaisseUserControl = new DepositCaisseUserControl();
            }
            _depositCaisseUserControl.LoadData();

            return _depositCaisseUserControl;
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

            if (await Task.Run(() => MainForm.Context.Database.CanConnect()))
            {
                cmbCaisse.DataSource = MainForm.Context.Caisses.ToList();
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
            if (!char.IsDigit(e.KeyChar) && e.KeyChar != Properties.Settings.Default.DecimalSEP[0] && e.KeyChar != 8)
            {
                e.Handled = true;
            }
        }

        private void cmbCaisse_SelectionChangeCommitted(object sender, EventArgs e)
        {
            try
            {
                validate();
                var value = MainForm.Context.Caisses.FirstOrDefault(x => x.Id.ToString() == cmbCaisse.SelectedValue.ToString()).MoneyinCaisse;
                lblValue.Text = value.ToString();
            }
            catch (Exception)
            {

                throw;
            }
        }

        private async void btnDepositToCaisse_Click(object sender, EventArgs e)
        {
            using (var transaction = await MainForm.Context.Database.BeginTransactionAsync())
            {
                try
                {
                    var caisse = MainForm.Context.Caisses.FirstOrDefault(x => x.Id.ToString() == cmbCaisse.SelectedValue);
                    if (caisse is not null)
                    {
                        if (_main.ConvertToFloat(txtValue.Text) > 0)
                        {
                            caisse.MoneyinCaisse += _main.ConvertToFloat(txtValue.Text);
                            var caisseDeposit = new CaisseDeposit
                            {
                                Caisse_ID = Convert.ToInt32(cmbCaisse.SelectedValue),
                                Time = DateTime.Now.ToString("HH:mm:ss"),
                                Date = dateTimePicker.Value,
                                Name = $"  {Properties.Settings.Default.UserName}  {txtDepositorName.Text} بحساب ",
                                Money = _main.ConvertToFloat(txtValue.Text),
                                Reason = textBox1.Text,
                                Type = "ايداع عادي (مال اضافي )"
                            };
                            MainForm.Context.Caisses.Update(caisse);
                            await MainForm.Context.CaissesDeposits.AddAsync(caisseDeposit);

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