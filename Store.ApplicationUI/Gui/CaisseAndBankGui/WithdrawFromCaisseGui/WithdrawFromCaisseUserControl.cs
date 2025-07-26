using Microsoft.EntityFrameworkCore;
using Store.ApplicationUI.Code.Helper;
using Store.ApplicationUI.Code.Models;
using Store.Core.Entities.Caisses;
using Store.Infrastructure.Data;

namespace Store.ApplicationUI.Gui.CaisseAndBankGui.WithdrawFromCaisseGui
{
    public partial class WithdrawFromCaisseUserControl : UserControl
    {
        private readonly MainForm _main;
        private readonly CaisseDetailsForm _caisse;
        private readonly ApplicationDbContext _context;
        public WithdrawFromCaisseUserControl(MainForm main, CaisseDetailsForm caisse, ApplicationDbContext context)
        {
            InitializeComponent();
            _main = main;
            _caisse = caisse;
            _context = context;
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

            if (await _context.Database.CanConnectAsync())
            {
                cmbCaisse.DataSource = await _context.Caisses.ToListAsync();
                cmbCaisse.DisplayMember = "CaisseName";
                cmbCaisse.ValueMember = "Id";
                cmbCaisse.Text = "اختر صندوق";
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

        private async void cmbCaisse_SelectionChangeCommitted(object sender, EventArgs e)
        {
            try
            {
                validate();
                var value = (await _context.Caisses.FirstOrDefaultAsync(x => x.Id.ToString() == cmbCaisse.SelectedValue.ToString())).MoneyinCaisse;
                lblValue.Text = value.ToString();
            }
            catch (Exception)
            {

                throw;
            }
        }

        private async void btnDepositToCaisse_Click(object sender, EventArgs e)
        {
            ToasterHelper.PlayNotificationSound();
            using (var transaction = await _context.Database.BeginTransactionAsync())
            {
                try
                {
                    var caisse = await _context.Caisses.FirstOrDefaultAsync(x => x.Id.ToString() == cmbCaisse.SelectedValue);

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

                            _context.Caisses.Update(caisse);
                            await _context.CaissesWithdraws.AddAsync(caisseDeposit);

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
