using Store.ApplicationUI.Code.Helper;
using Store.ApplicationUI.Gui.LoadingGui;
using Store.Core.Entities.Caisses;
using Store.Core.Entities.Vouchers;
using Store.Infrastructure.Data;

namespace Store.ApplicationUI.Gui.DeservedGui.VouchersGui
{
    public partial class AddVoucherForm : Form
    {
        private static MainForm _main;
        private ApplicationDbContext _context;
        private static AddVoucherForm _addVoucherForm;
        public AddVoucherForm(MainForm main)
        {
            InitializeComponent();
            _main = main;
            this.Owner = _main;
            _context = new ApplicationDbContext();
            LoadData();
            ConfigDate();
        }
        void DataChanges()
        {
            if (rbReciptVoucher.Checked)
            {
                if (!btnEditDeserved.Visible)
                    lblNumberD.Text = (_context.ReceiptVouchers.Count() + 1).ToString();
                lblfromToPerson.Text = "قبض السند من :";

            }
            else
            {
                if (!btnEditDeserved.Visible)
                    lblNumberD.Text = (_context.SendVouchers.Count() + 1).ToString();
                lblfromToPerson.Text = "صرف السند الى :";
            }
            vider();

        }
        public static AddVoucherForm Instance(MainForm main)
        {
            _main = main;
            // If the instance is null, create a new one and assign it to the static field


            _addVoucherForm = new AddVoucherForm(_main);



            // Return the singleton instance

            return _addVoucherForm;
        }
        private void ConfigDate()
        {
            Dtp.Value = DateTime.Now;

            Dtp.CustomFormat = Dtp.CustomFormat = "yyyy-MM-dd";
        }
        public void LoadData()
        {


            //ShowLoading


            LoadingForm.Instance(_main).Show();
            if (/*await Task.Run(() =>*/ _context.Database.CanConnect())/*)*/
            {
                //Start Load Data

                // if its an admin or Normal user 


                DataChanges();




                // Optionally select the first item if needed
            }
            else
            {

                LoadingForm.Instance(_main).Hide();
                //No Connection
                MsgHelper.ShowServerError();
            }
            //Hideloading
            LoadingForm.Instance(_main).Hide();
            // Show EmptyDAta

        }
        void vider()
        {
            txtValue.Text = "0.00";
            txtUserName.Text = Properties.Settings.Default.UserName;
            txtNotes.Text = "";

        }
        private void button1_Click(object sender, EventArgs e)
        {
            Close();
        }

        private void txtValue_KeyPress(object sender, KeyPressEventArgs e)
        {
            if (!char.IsDigit(e.KeyChar) && e.KeyChar != Properties.Settings.Default.DecimalSEP[0] && e.KeyChar != 8)
            {
                e.Handled = true;
            }
        }
        public void SetDataToEdit(string username, string value, string notes, bool ReciptVoucher,
            string VoucherId, DateTime DateExpiration, string toPerson)
        {
            LoadData();
            txtUserName.Text = username;
            txtValue.Text = value;
            if (ReciptVoucher)
            {
                rbReciptVoucher.Checked = true;
            }
            else
            {
                rbSendVoucher.Checked = true;
            }
            txtNotes.Text = notes;
            Dtp.Value = DateExpiration;
            lblNumberD.Text = VoucherId;
            txtPerson.Text = toPerson;
            btnAddDeserved.Visible = false;
            btnEditDeserved.Visible = true;

        }

        private void btnAddDeserved_Click(object sender, EventArgs e)
        {
            if (rbReciptVoucher.Checked)
            {
                _context.ReceiptVouchers.Add(new Core.Entities.Vouchers.ReceiptVoucher
                {
                    From = txtPerson.Text,
                    ReciverName = txtUserName.Text,
                    Price = Convert.ToDecimal(txtValue.Text),
                    Date = Dtp.Value,
                    Reason = txtNotes.Text,
                    Time = DateTime.Now.ToString("HH:mm:ss"),
                });
                _context.Update(AddCaisse(Convert.ToDecimal(txtValue.Text)));
                _context.Add(SetCaisseDeposit(Convert.ToDecimal(txtValue.Text)));
            }
            else
            {
                _context.SendVouchers.Add(new Core.Entities.Vouchers.SendVoucher
                {
                    To = txtPerson.Text,
                    SenderName = txtUserName.Text,
                    Price = Convert.ToDecimal(txtValue.Text),
                    Date = Dtp.Value,
                    Reason = txtNotes.Text,
                    Time = DateTime.Now.ToString("HH:mm:ss"),
                });
                _context.Update(MinusCaisse(Convert.ToDecimal(txtValue.Text)));
                _context.Add(SetCaisseWithdraw(Convert.ToDecimal(txtValue.Text)));

            }
            _context.SaveChanges();
            if (!VouchersUserControl.CheckInstance())
            {
                VouchersUserControl.RefreshDgv();
            }
        }
        Caisse AddCaisse(decimal value)
        {
            var caisse = _context.Caisses.FirstOrDefault(x => x.Id == Properties.Settings.Default.DefaultCaisseId);
            if (caisse != null)
            {
                caisse.MoneyinCaisse += value;
            }
            return caisse;

        }
        Caisse MinusCaisse(decimal value)
        {
            var caisse = _context.Caisses.FirstOrDefault(x => x.Id == Properties.Settings.Default.DefaultCaisseId);
            if (caisse != null)
            {
                caisse.MoneyinCaisse -= value;
            }
            return caisse;

        }
        CaisseDeposit SetCaisseDeposit(decimal value)
        {
            //dgvProducts.Rows[i].Cells[0].Value.ToString()

            return new CaisseDeposit
            {
                Caisse_ID = Properties.Settings.Default.DefaultCaisseId,
                Time = DateTime.Now.ToString("HH:mm:ss"),
                Date = DateTime.Now,
                Name = $"  {Properties.Settings.Default.UserName} بحساب ",
                Money = value,
                Reason = txtNotes.Text,
                Type = "سند القبض"
            };
        }
        CaisseWithdraw SetCaisseWithdraw(decimal value)
        {
            //dgvProducts.Rows[i].Cells[0].Value.ToString()


            var caisseWithdraw = new CaisseWithdraw
            {
                Caisse_ID = Properties.Settings.Default.DefaultCaisseId,
                Time = DateTime.Now.ToString("HH:mm:ss"),
                Date = DateTime.Now,
                Name = $"  {Properties.Settings.Default.UserName}",
                Money = value,
                Reason = txtNotes.Text,
                Type = "سند الصرف"
            };

            return caisseWithdraw;

        }
        private async void btnEditDeserved_Click(object sender, EventArgs e)
        {

            if (rbReciptVoucher.Checked)
            {
                ReceiptVoucher receipt = _context.ReceiptVouchers.FirstOrDefault(x => x.Id.ToString() == lblNumberD.Text);
                receipt.From = txtPerson.Text;
                receipt.ReciverName = txtUserName.Text;
                receipt.Price = Convert.ToDecimal(txtValue.Text);
                receipt.Date = Dtp.Value;
                receipt.Reason = txtNotes.Text;

                _context.Update(receipt);

            }
            else
            {
                SendVoucher receipt = _context.SendVouchers.FirstOrDefault(x => x.Id.ToString() == lblNumberD.Text);
                receipt.To = txtPerson.Text;
                receipt.SenderName = txtUserName.Text;
                receipt.Price = Convert.ToDecimal(txtValue.Text);
                receipt.Date = Dtp.Value;
                receipt.Reason = txtNotes.Text;

                _context.Update(receipt);
            }
            await _context.SaveChangesAsync();
            if (!VouchersUserControl.CheckInstance())
            {
                VouchersUserControl.RefreshDgv();
            }

            DataChanges();
        }
    }
}
