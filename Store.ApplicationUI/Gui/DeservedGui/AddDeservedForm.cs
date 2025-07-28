using Microsoft.EntityFrameworkCore;
using Store.ApplicationUI.Code.Helper;
using Store.ApplicationUI.Code.System;
using Store.ApplicationUI.Gui.LoadingGui;
using Store.Core.Entities.AllDeserved;
using Store.Core.Entities.Caisses;
using Store.Infrastructure.Data;

namespace Store.ApplicationUI.Gui.DeservedGui
{
    public partial class AddDeservedForm : Form
    {
        private readonly MainForm _main;
        private readonly ApplicationDbContext _context;
        private readonly ControlManager _controlManager;

        public AddDeservedForm(MainForm main, ApplicationDbContext context, ControlManager controlManager)
        {
            InitializeComponent();
            _main = main;
            _context = context;
            _controlManager = controlManager;
            this.Owner = _main;

        }
        private void ConfigDate()
        {
            DtpExperation.Value = DateTime.Now;

            DtpExperation.CustomFormat = DtpExperation.CustomFormat = "yyyy-MM-dd";
        }
        public async Task LoadData()
        {

            dgvHelper.ResetForm(this);
            vider();
            //ShowLoading


            LoadingForm.Instance(_main).Show();
            if (/*await Task.Run(() =>*/ await _context.Database.CanConnectAsync())/*)*/
            {
                //Start Load Data

                // if its an admin or Normal user 

                CMBType.DataSource = await _context.DeservedsTypes.ToListAsync();



                CMBType.DisplayMember = "Description"; // Set the property to display
                CMBType.ValueMember = "Id"; // Set the property to use as the value
                CMBType.Text = "اختر نوع";
                ConfigDate();
                // Optionally select the first item if needed
                btnAddDeserved.Visible = true;
                btnEditDeserved.Visible = false;
                lblDeservedID.Visible = false;
                label13.Visible = false;
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
            txtValueDeserved.Text = "0";
            txtUserName.Text = Properties.Settings.Default.UserName;


        }
        private void button1_Click(object sender, EventArgs e)
        {
            Close();
        }

        private void txtValueDeserved_KeyPress(object sender, KeyPressEventArgs e)
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
        public async Task SetDataToEdit(string username, string value, string notes, string typesId,
             string deservedId, DateTime DateExpiration)
        {
            await LoadData();
            txtUserName.Text = username;
            txtValueDeserved.Text = value;
            CMBType.SelectedValue = Convert.ToInt32(typesId);
            txtNotes.Text = notes;
            DtpExperation.Value = DateExpiration;
            lblDeservedID.Text = deservedId;
            btnAddDeserved.Visible = false;
            btnEditDeserved.Visible = true;
            lblDeservedID.Visible = true;
            label13.Visible = true;
        }
        public void SetDataToEditFromID(string username, string value, string notes, string typesId,
         string deservedId, DateTime DateExpiration)
        {

            txtUserName.Text = username;
            txtValueDeserved.Text = value;
            CMBType.SelectedValue = Convert.ToInt32(typesId);
            txtNotes.Text = notes;
            DtpExperation.Value = DateExpiration;
            lblDeservedID.Text = deservedId;
            btnAddDeserved.Visible = false;
            btnEditDeserved.Visible = true;
            lblDeservedID.Visible = true;
            label13.Visible = true;
        }
        async Task<Caisse> SetCaisse(decimal value)
        {
            //dgvProducts.Rows[i].Cells[0].Value.ToString()

            Caisse caisse = await _context.Caisses.Where(x => x.Id == Properties.Settings.Default.DefaultCaisseId).FirstOrDefaultAsync();
            if (caisse is not null)
            {
                caisse.MoneyinCaisse -= value;
            }
            return caisse is not null ? caisse : new Caisse { CaisseName = "CaisseNull", MoneyinCaisse = -value };

        }
        async Task<Caisse> SetCaissedepos(decimal value)
        {
            //dgvProducts.Rows[i].Cells[0].Value.ToString()

            Caisse caisse = await _context.Caisses.Where(x => x.Id == Properties.Settings.Default.DefaultCaisseId).FirstOrDefaultAsync();
            if (caisse is not null)
            {
                caisse.MoneyinCaisse += value;
            }
            return caisse is not null ? caisse : new Caisse { CaisseName = "CaisseNull", MoneyinCaisse = -value };

        }
        CaisseWithdraw SetCaisseWithdraw(decimal value)
        {
            //dgvProducts.Rows[i].Cells[0].Value.ToString()


            var caisseWithdraw = new CaisseWithdraw
            {
                Caisse_ID = Properties.Settings.Default.DefaultCaisseId,
                Time = DateTime.Now.ToString("HH:mm"),
                Date = DateTime.Now,
                Name = $"{Properties.Settings.Default.UserName}",
                Money = value,
                Reason = $"مصروفة {CMBType.Text}",
                Type = "سحب عن طريق مصروفة"
            };

            return caisseWithdraw;

        }
        CaisseDeposit SetCaisseDeposit(decimal value)
        {
            //dgvProducts.Rows[i].Cells[0].Value.ToString()


            var caisseWithdraw = new CaisseDeposit
            {
                Caisse_ID = Properties.Settings.Default.DefaultCaisseId,
                Time = DateTime.Now.ToString("HH:mm"),
                Date = DateTime.Now,
                Name = $"{Properties.Settings.Default.UserName}",
                Money = value,
                Reason = $"مصروفة {CMBType.Text}",
                Type = "ايداع عن طريق مصروفة"
            };

            return caisseWithdraw;

        }
        private async void btnAddDeserved_Click(object sender, EventArgs e)
        {
            try
            {

                ToasterHelper.PlayNotificationSound();

                if (CMBType.Text != "اختر نوع")
                {
                    await _context.Deserveds.AddAsync(new Deserved
                    {
                        TypeId = (int)CMBType.SelectedValue,
                        UserName = txtUserName.Text,
                        Price = Convert.ToDecimal(txtValueDeserved.Text),
                        Date = DtpExperation.Value,
                        Notes = txtNotes.Text,
                        Time = DateTime.Now.ToString("HH:mm:ss"),
                    });
                    await _context.SaveChangesAsync();
                    _context.Update(await SetCaisse(Convert.ToDecimal(txtValueDeserved.Text)));
                    await _context.AddAsync(SetCaisseWithdraw(Convert.ToDecimal(txtValueDeserved.Text)));
                    await _context.SaveChangesAsync();



                    if (_controlManager.TryGet<DeservedUserControl>(out var UC))
                    {
                        await UC.LoadData();
                    }
                    Code.Helper.ToasterHelper.ShowAddToast();
                }
                else
                    MsgHelper.ShowRequiredFields();
            }
            catch (Exception)
            {

                throw;
            }
        }

        private async void btnEditDeserved_Click(object sender, EventArgs e)
        {
            try
            {
                decimal value = Convert.ToDecimal(txtValueDeserved.Text);
                ToasterHelper.PlayNotificationSound();

                Deserved deserved = await _context.Deserveds.FirstOrDefaultAsync(x => x.Id.ToString() == lblDeservedID.Text);

                if (deserved != null)
                {
                    if (deserved.Price > Convert.ToDecimal(txtValueDeserved.Text))
                    {
                        value = deserved.Price - Convert.ToDecimal(txtValueDeserved.Text);
                        _context.Update(await SetCaissedepos(value));
                        _context.Add(SetCaisseDeposit(value));
                        await _context.SaveChangesAsync();

                    }
                    else if (deserved.Price < Convert.ToDecimal(txtValueDeserved.Text))
                    {
                        value = Convert.ToDecimal(txtValueDeserved.Text) - deserved.Price;
                        _context.Update(await SetCaisse(value));
                        _context.Add(SetCaisseWithdraw(value));
                        await _context.SaveChangesAsync();

                    }
                    deserved.TypeId = Convert.ToInt32(CMBType.SelectedValue);
                    deserved.UserName = txtUserName.Text;
                    deserved.Price = Convert.ToDecimal(txtValueDeserved.Text);
                    deserved.Date = DtpExperation.Value;
                    deserved.Notes = txtNotes.Text;
                    _context.Update(deserved);
                    await _context.SaveChangesAsync();
                    Code.Helper.ToasterHelper.ShowEditToast();


                    if (_controlManager.TryGet<DeservedUserControl>(out var UC))
                    {
                        await UC.LoadData();
                    }
                    deserved = null;
                }
            }
            catch (Exception)
            {

                throw;
            }
        }

        private async void btnAddTypes_Click(object sender, EventArgs e)
        {
            ToasterHelper.PlayNotificationSound();
            AddDeservedTypeForm addDeservedType = await _controlManager.GetFAsync<AddDeservedTypeForm>();
            this.Hide();
            addDeservedType.ShowDialog();
            this.Show();
        }
    }
}
