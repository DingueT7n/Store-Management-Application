using Microsoft.EntityFrameworkCore;
using Store.ApplicationUI.Code.Helper;
using Store.ApplicationUI.Code.System;
using Store.ApplicationUI.Gui.LoadingGui;
using Store.Core.Entities.Caisses;
using Store.Core.Entities.Vouchers;
using Store.Infrastructure.Data;

namespace Store.ApplicationUI.Gui.DeservedGui.VouchersGui
{
    public partial class AddVoucherForm : Form
    {
        private readonly ApplicationDbContext _context;
        private readonly MainForm _main;
        private readonly ControlManager _controlManager;

        public AddVoucherForm(ApplicationDbContext context, MainForm main, ControlManager controlManager)
        {
            InitializeComponent();
            _main = main;

            _controlManager = controlManager;
            this.Owner = _main;


            _context = context;

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

        private void ConfigDate()
        {
            Dtp.Value = DateTime.Now;

            Dtp.CustomFormat = Dtp.CustomFormat = "yyyy-MM-dd";
        }
        public async Task LoadData()
        {

            dgvHelper.ResetForm(this);
            //ShowLoading


            LoadingForm.Instance(_main).Show();
            if (/*await Task.Run(() =>*/await _context.Database.CanConnectAsync())/*)*/
            {
                //Start Load Data

                // if its an admin or Normal user 


                DataChanges();

                ConfigDate();



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
        public async Task SetDataToEdit(string username, string value, string notes, bool ReciptVoucher,
            string VoucherId, DateTime DateExpiration, string toPerson)
        {
            await LoadData();
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
        private async void btnAddDeserved_Click(object sender, EventArgs e)
        {
            try
            {
                if (rbReciptVoucher.Checked)
                {
                    await _context.ReceiptVouchers.AddAsync(new ReceiptVoucher
                    {
                        From = txtPerson.Text,
                        ReciverName = txtUserName.Text,
                        Price = Convert.ToDecimal(txtValue.Text),
                        Date = Dtp.Value,
                        Reason = txtNotes.Text,
                        Time = DateTime.Now.ToString("HH:mm:ss"),
                    });
                    _context.Update(await AddCaisse(Convert.ToDecimal(txtValue.Text)));
                    await _context.AddAsync(SetCaisseDeposit(Convert.ToDecimal(txtValue.Text)));
                    await _context.SaveChangesAsync();
                }
                else
                {
                    await _context.SendVouchers.AddAsync(new SendVoucher
                    {
                        To = txtPerson.Text,
                        SenderName = txtUserName.Text,
                        Price = Convert.ToDecimal(txtValue.Text),
                        Date = Dtp.Value,
                        Reason = txtNotes.Text,
                        Time = DateTime.Now.ToString("HH:mm:ss"),
                    });
                    _context.Update(await MinusCaisse(Convert.ToDecimal(txtValue.Text)));
                    await _context.AddAsync(SetCaisseWithdraw(Convert.ToDecimal(txtValue.Text)));
                    await _context.SaveChangesAsync();
                }


                if (_controlManager.TryGet<VouchersUserControl>(out var UC))
                {
                    await UC.LoadData();
                }
                ToasterHelper.ShowAddToast();
            }
            catch (Exception)
            {
                throw;
            }
        }
        async Task<Caisse> AddCaisse(decimal value)
        {
            var caisse = await _context.Caisses.FirstOrDefaultAsync(x => x.Id == Properties.Settings.Default.DefaultCaisseId);
            if (caisse != null)
            {
                caisse.MoneyinCaisse += value;
            }
            return caisse;

        }
        async Task<Caisse> MinusCaisse(decimal value)
        {
            var caisse = await _context.Caisses.FirstOrDefaultAsync(x => x.Id == Properties.Settings.Default.DefaultCaisseId);
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
            try
            {


                if (rbReciptVoucher.Checked)
                {
                    ReceiptVoucher receipt = await _context.ReceiptVouchers.FirstOrDefaultAsync(x => x.Id.ToString() == lblNumberD.Text);
                    if (receipt != null)
                    {
                        receipt.From = txtPerson.Text;
                        receipt.ReciverName = txtUserName.Text;
                        receipt.Price = Convert.ToDecimal(txtValue.Text);
                        receipt.Date = Dtp.Value;
                        receipt.Reason = txtNotes.Text;

                        _context.Update(receipt);
                        await _context.SaveChangesAsync();
                    }

                }
                else
                {
                    SendVoucher receipt = await _context.SendVouchers.FirstOrDefaultAsync(x => x.Id.ToString() == lblNumberD.Text);
                    if (receipt != null)
                    {
                        receipt.To = txtPerson.Text;
                        receipt.SenderName = txtUserName.Text;
                        receipt.Price = Convert.ToDecimal(txtValue.Text);
                        receipt.Date = Dtp.Value;
                        receipt.Reason = txtNotes.Text;
                        _context.Update(receipt);
                        await _context.SaveChangesAsync();

                    }
                }

                if (_controlManager.TryGet<VouchersUserControl>(out var UC))
                {
                    await UC.LoadData();
                }
            }
            catch (Exception)
            {

                throw;
            }
            DataChanges();
        }
    }
}
