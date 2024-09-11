using Store.ApplicationUI.Code.Helper;
using Store.Core.Entities.Caisses;
using Store.Infrastructure.Data;

namespace Store.ApplicationUI.Gui.CaisseAndBankGui.TransferBetweenCaissesGui
{
    public partial class TransferBetweenCaissesGuiUserControl : UserControl
    {
        private static ApplicationDbContext _context;
        static TransferBetweenCaissesGuiUserControl _TransferBetweenCaissesGuiUserControl;
        private static CaisseDetailsForm _caisse;
        private static MainForm _main;

        public TransferBetweenCaissesGuiUserControl()
        {
            InitializeComponent();
        }

        public static TransferBetweenCaissesGuiUserControl Instance(MainForm main, CaisseDetailsForm caisse)
        {
            _caisse = caisse;
            _main = main;
            // If the instance is null, create a new one and assign it to the static field
            if (_TransferBetweenCaissesGuiUserControl == null || _TransferBetweenCaissesGuiUserControl.IsDisposed)
            {
                _context = new ApplicationDbContext();

                _TransferBetweenCaissesGuiUserControl = new TransferBetweenCaissesGuiUserControl();
            }
            _TransferBetweenCaissesGuiUserControl.LoadData();

            return _TransferBetweenCaissesGuiUserControl;
        }
        void validate()
        {

            if (cmbCaisseFrom.Items.Count <= 0) { MessageBox.Show("لا يوجد صناديق راجع بياناتك"); return; }
            if (cmbCaisseFrom.Text == "اختر صندوق") return;
            if (cmbCaisseTo.Items.Count <= 0) { MessageBox.Show("لا يوجد صناديق راجع بياناتك"); return; }
            if (cmbCaisseTo.Text == "اختر صندوق") return;
        }
        public async void LoadData()
        {
            txtDepositorName.Text = string.Empty;
            txtValue.Text = string.Empty;
            lblValue.Text = "0";
            dateTimePicker.Value = DateTime.Now;

            if (await Task.Run(() => _context.Database.CanConnect()))
            {
                cmbCaisseFrom.DataSource = _context.Caisses.ToList();

                cmbCaisseFrom.DisplayMember = "CaisseName";
                cmbCaisseFrom.ValueMember = "Id";
                cmbCaisseFrom.Text = "اختر صندوق";

                cmbCaisseTo.DataSource = _context.Caisses.ToList();
                cmbCaisseTo.DisplayMember = "CaisseName";
                cmbCaisseTo.ValueMember = "Id";
                cmbCaisseTo.Text = "اختر صندوق";
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
                var value = _context.Caisses.FirstOrDefault(x => x.Id.ToString() == cmbCaisseFrom.SelectedValue.ToString()).MoneyinCaisse;
                lblValue.Text = value.ToString();
            }
            catch (Exception)
            {

                throw;
            }
        }

        private void cmbCaisseTo_SelectionChangeCommitted(object sender, EventArgs e)
        {
            try
            {
                validate();
                var value = _context.Caisses.FirstOrDefault(x => x.Id.ToString() == cmbCaisseTo.SelectedValue.ToString()).MoneyinCaisse;
                lblValueTo.Text = value.ToString();
            }
            catch (Exception)
            {

                throw;
            }
        }

        private async void btnDepositToCaisse_Click(object sender, EventArgs e)
        {
            validate();
            if (Convert.ToInt32(cmbCaisseFrom.SelectedValue) == Convert.ToInt32(cmbCaisseTo.SelectedValue)) { MessageBox.Show("لا يمكنك التحويل إلى نفس الصندوق"); return; }
            if (Convert.ToDouble(txtValue.Text) > Convert.ToDouble(lblValue.Text)) { MessageBox.Show($"الصنودق المرسل لديه قيمى اصغر من المحولة"); return; }


            using (var transaction = await _context.Database.BeginTransactionAsync())
            {
                try
                {
                    var caisseFrom = _context.Caisses.FirstOrDefault(x => x.Id.ToString() == cmbCaisseFrom.SelectedValue);
                    var caisseTo = _context.Caisses.FirstOrDefault(x => x.Id.ToString() == cmbCaisseTo.SelectedValue);
                    if (caisseFrom is not null && caisseTo is not null)
                    {
                        if (_main.ConvertToFloat(txtValue.Text) > 0)
                        {
                            caisseTo.MoneyinCaisse += _main.ConvertToFloat(txtValue.Text);
                            caisseFrom.MoneyinCaisse -= _main.ConvertToFloat(txtValue.Text);

                            var caisseDeposit = new CaisseDeposit
                            {
                                Caisse_ID = Convert.ToInt32(cmbCaisseTo.SelectedValue),
                                Time = DateTime.Now.ToString("HH:mm:ss"),
                                Date = dateTimePicker.Value,
                                Name = $"  {Properties.Settings.Default.UserName}  {txtDepositorName.Text} بحساب ",
                                Money = _main.ConvertToFloat(txtValue.Text),
                                Reason = textBox1.Text,
                                Type = $"ايداع محول من {cmbCaisseFrom.Text} (مال محول )"
                            };
                            var caisseWithdraw = new CaisseWithdraw
                            {
                                Caisse_ID = Convert.ToInt32(cmbCaisseTo.SelectedValue),
                                Time = DateTime.Now.ToString("HH:mm:ss"),
                                Date = dateTimePicker.Value,
                                Name = $"  {Properties.Settings.Default.UserName}  {txtDepositorName.Text} بحساب ",
                                Money = _main.ConvertToFloat(txtValue.Text),
                                Reason = textBox1.Text,
                                Type = $"سحب مرسل الى {cmbCaisseTo.Text} (مال محول )"
                            };
                            var caisseTransfere = new CaisseTransfere
                            {
                                Caisse_To = Convert.ToInt32(cmbCaisseTo.SelectedValue),
                                Caisse_From = Convert.ToInt32(cmbCaisseFrom.SelectedValue),
                                Time = DateTime.Now.ToString("HH:mm:ss"),
                                Date = dateTimePicker.Value,
                                Name = $"  {Properties.Settings.Default.UserName}  {txtDepositorName.Text} بحساب ",
                                Money = _main.ConvertToFloat(txtValue.Text),
                                Reason = textBox1.Text,
                            };
                            _context.Caisses.Update(caisseTo);
                            _context.Caisses.Update(caisseFrom);
                            await _context.CaissesDeposits.AddAsync(caisseDeposit);
                            await _context.CaissesWithdraws.AddAsync(caisseWithdraw);
                            await _context.CaissesTransferes.AddAsync(caisseTransfere);
                            await _context.SaveChangesAsync();

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
