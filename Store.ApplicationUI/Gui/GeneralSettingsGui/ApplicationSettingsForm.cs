using System.Drawing.Printing;
using System.IO;
using Store.ApplicationUI.Code.Helper;
using Store.ApplicationUI.Gui.LoadingGui;
using Store.Core.Entities.Helpers;
using Store.Infrastructure.Data;

namespace Store.ApplicationUI.Gui.GeneralSettingsGui
{
    public partial class ApplicationSettingsForm : Form
    {
        private ApplicationDbContext _context;
        private static MainForm _main;
        private static ApplicationSettingsForm? _userRolesForm;

        public ApplicationSettingsForm(MainForm main)
        {
            _context = new ApplicationDbContext();
            _main = main;
            InitializeComponent();
            this.Owner = main;
            LoadData();
        }
        public static ApplicationSettingsForm Instance(MainForm main)
        {
            if (_userRolesForm == null || _userRolesForm.IsDisposed)
            {
                _userRolesForm = new ApplicationSettingsForm(main);
            }
            else
            {
                if (!_userRolesForm.Visible)
                {
                    _userRolesForm.Show();
                }
                _userRolesForm.BringToFront();
            }

            return _userRolesForm;
        }

        public async void LoadData()
        {
            //ShowLoading
            LoadingForm.Instance(_main).Show();
            if (await Task.Run(() => _context.Database.CanConnect()))
            {
                List<string> printer = new List<string>();
                for (int i = 0; i < PrinterSettings.InstalledPrinters.Count; i++)
                {

                    cmb8cm.Items.Add(PrinterSettings.InstalledPrinters[i]);
                    cmbA4.Items.Add(PrinterSettings.InstalledPrinters[i]);
                    cmbBarcode.Items.Add(PrinterSettings.InstalledPrinters[i]);

                }


                cmbBarcode.SelectedIndex = 0;
                cmb8cm.SelectedIndex = 0;
                cmbA4.SelectedIndex = 0;
                if (Properties.Settings.Default.PrinterBarCode != string.Empty)
                    cmbBarcode.Text = Properties.Settings.Default.PrinterBarCode;

                if (Properties.Settings.Default.Printer8cm != string.Empty)
                    cmb8cm.Text = Properties.Settings.Default.Printer8cm;

                if (Properties.Settings.Default.PrinterA4 != string.Empty)
                    cmbA4.Text = Properties.Settings.Default.PrinterA4;
                LoadImageFromBase64();
                if (!string.IsNullOrEmpty(Properties.Settings.Default.LogoPicture))
                    EnablePicture();

                txtStoreName.Text = Properties.Settings.Default.StoreNameFacture;
                txtSentenceUnderFacture.Text = Properties.Settings.Default.SentenceUnderFacture;




                cmbCustomers.DataSource = _context.Customers.ToList();
                cmbCustomers.DisplayMember = "CustomerName";
                cmbCustomers.ValueMember = "Id";

                if (Properties.Settings.Default.IdCustomerSale != string.Empty)
                    cmbCustomers.SelectedValue = Convert.ToInt32(Properties.Settings.Default.IdCustomerSale);
                else
                {
                    cmbCustomers.SelectedValue = 0;
                    Properties.Settings.Default.IdCustomerSale = "0";
                    Properties.Settings.Default.Save();
                }
                cblogoStore.Checked = Properties.Settings.Default.LogoYesNo;

                if (Properties.Settings.Default.PrintBuyFactureType8cm)
                    rbBuy8cm.Checked = true;
                else
                    rbBuyA4.Checked = true;
                if (Properties.Settings.Default.PrintSaleFactureType8cm)
                    rbSale8cm.Checked = true;
                else
                    rbSaleA4.Checked = true;

                cbBuyPrinterState.Checked = Properties.Settings.Default.PrintBuyOnOrOff;
                cbSalePrinterState.Checked = Properties.Settings.Default.PrintSaleOnOrOff;

                txtDaysDelaysDebt.Text = Properties.Settings.Default.DaysAddDebt.ToString();
                txtDataInDgv.Text = Properties.Settings.Default.NoOfDataInDgvs.ToString();

                txtSaleCopy.Text = Properties.Settings.Default.NbrCopyOfSaleFacture.ToString();
                txtBuyCopy.Text = Properties.Settings.Default.NbrCopyOfBuyFacture.ToString();

                cmbFastCaisse.DataSource = _context.Caisses.ToList();
                cmbFastCaisse.DisplayMember = "CaisseName";
                cmbFastCaisse.ValueMember = "Id";

                int a = Properties.Settings.Default.DefaultCaisseId;
                cmbFastCaisse.SelectedValue = a;

                cmbFastStores.DataSource = _context.Stores.ToList();
                cmbFastStores.DisplayMember = "StoreName";
                cmbFastStores.ValueMember = "Id";


                cmbFastStores.SelectedValue = Properties.Settings.Default.FastSaleStore;

                cbEditBuyPrice.Checked = Properties.Settings.Default.ApplyBuyPrice;
                cbEditWholeSaleprice.Checked = Properties.Settings.Default.ApplyWholeSale;
                cbEditSalePrice.Checked = Properties.Settings.Default.ApplySalePrice;


                txtSentenceUnderFacture.Text = Properties.Settings.Default.SentenceUnderFacture;
                txtPhoneNumber.Text = Properties.Settings.Default.FacturePhoneNumber;
                txtAddress.Text = Properties.Settings.Default.AddressStore;
                var data = _context.OrderPrintData.FirstOrDefault();
                if (data != null)
                {
                    if (!string.IsNullOrEmpty(data.Logo))
                    {
                        byte[] imageBytes = Convert.FromBase64String(data.Logo);
                        using (MemoryStream ms = new MemoryStream(imageBytes))
                        {
                            pbLogo.Image = Image.FromStream(ms);

                        }
                    }
                    txtStoreName.Text = data.Name;
                    txtAddress.Text = data.Address;
                    txtSentenceUnderFacture.Text = data.Description;
                    txtPhoneNumber.Text = data.Phone1;
                    txtFax.Text = data.Fax;
                    txtRC.Text = data.RC;
                    txtAI.Text = data.AI;
                    txtIdFiscale.Text = data.IDFiscal;
                    txtNIS.Text = data.NIS;
                }
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

        private void button1_Click(object sender, EventArgs e)
        {
            ToasterHelper.PlayNotificationSound();
            Properties.Settings.Default.PrinterBarCode = cmbBarcode.Text;
            Properties.Settings.Default.Save();

            Properties.Settings.Default.Printer8cm = cmb8cm.Text;
            Properties.Settings.Default.Save();

            Properties.Settings.Default.PrinterA4 = cmbA4.Text;
            Properties.Settings.Default.Save();
        }
        private void LoadImageFromBase64()
        {
            string base64Image = Properties.Settings.Default.LogoPicture;

            if (!string.IsNullOrEmpty(base64Image))
            {
                byte[] imageBytes = Convert.FromBase64String(base64Image);
                using (MemoryStream ms = new MemoryStream(imageBytes))
                {
                    pbLogo.Image = Image.FromStream(ms);
                }
            }

        }
        private string SaveImageAsBase64()
        {
            if (pbLogo.Image != null)
            {
                using (MemoryStream ms = new MemoryStream())
                {
                    pbLogo.Image.Save(ms, System.Drawing.Imaging.ImageFormat.Png);
                    string base64Image = Convert.ToBase64String(ms.ToArray());

                    // Save Base64 string to settings
                    Properties.Settings.Default.LogoPicture = base64Image;
                    Properties.Settings.Default.Save();
                    return base64Image;

                }
            }
            else
            {
                Properties.Settings.Default.LogoPicture = string.Empty;
                Properties.Settings.Default.Save();
                return string.Empty;

            }
        }

        private void button2_Click(object sender, EventArgs e)
        {

            ToasterHelper.PlayNotificationSound();
            var data = _context.OrderPrintData.FirstOrDefault();
            if (data is null)
            {

                OrderPrintData orderPrintData = new()
                {
                    Logo = SaveImageAsBase64(),
                    Name = txtStoreName.Text,
                    Address = txtAddress.Text,
                    Description = txtSentenceUnderFacture.Text,
                    Phone1 = txtPhoneNumber.Text,
                    Fax = txtFax.Text,
                    CompteRib = string.Empty,
                    RC = txtRC.Text,
                    AI = txtAI.Text,
                    IDFiscal = txtIdFiscale.Text,
                    NIS = txtNIS.Text,
                };
                _context.Add(orderPrintData);
                _context.SaveChanges();
            }
            else
            {

                data.Logo = SaveImageAsBase64();
                data.Name = txtStoreName.Text;
                data.Address = txtAddress.Text;
                data.Description = txtSentenceUnderFacture.Text;
                data.Phone1 = txtPhoneNumber.Text;
                data.Fax = txtFax.Text;
                data.CompteRib = string.Empty;
                data.RC = txtRC.Text;
                data.AI = txtAI.Text;
                data.IDFiscal = txtIdFiscale.Text;
                data.NIS = txtNIS.Text;
                _context.Update(data);
                _context.SaveChanges();

            }
            if (cblogoStore.Checked)
                SaveImageAsBase64();
            Properties.Settings.Default.SentenceUnderFacture = txtSentenceUnderFacture.Text;
            Properties.Settings.Default.Save();

            Properties.Settings.Default.FacturePhoneNumber = txtPhoneNumber.Text;
            Properties.Settings.Default.Save();

            Properties.Settings.Default.AddressStore = txtAddress.Text;
            Properties.Settings.Default.LogoYesNo = cblogoStore.Checked;
            Properties.Settings.Default.StoreNameFacture = txtStoreName.Text;
            Properties.Settings.Default.Save();
        }

        private void button3_Click(object sender, EventArgs e)
        {
            using (OpenFileDialog openFileDialog = new OpenFileDialog())
            {
                openFileDialog.Filter = "ملفات الصور |*.JPG; *.PNG; *.GIF; *.BMP";
                if (openFileDialog.ShowDialog() == DialogResult.OK)
                {
                    pbLogo.Image = Image.FromFile(openFileDialog.FileName);
                }
            }
        }

        private void button4_Click(object sender, EventArgs e)
        {
            ToasterHelper.PlayNotificationSound();
            pbLogo.BackgroundImage = null;
            pbLogo.Image = null;
        }
        void EnablePicture()
        {
            cblogoStore.Checked = true;
            pbLogo.Enabled = true;
            btnChoosePicture.Enabled = true;
            btnDeletePicture.Enabled = true;
        }
        void DisablePicture()
        {
            pbLogo.Enabled = false;
            btnChoosePicture.Enabled = false;
            btnDeletePicture.Enabled = false;
        }
        private void cblogoStore_CheckedChanged(object sender, EventArgs e)
        {
            if (cblogoStore.Checked)
            {
                EnablePicture();
            }
            else
            {
                DisablePicture();
            }
        }

        private void button3_Click_1(object sender, EventArgs e)
        {
            ToasterHelper.PlayNotificationSound();
            Properties.Settings.Default.FastSaleStore = Convert.ToInt32(cmbFastStores.SelectedValue);

            Properties.Settings.Default.DefaultCaisseId = Convert.ToInt32(cmbFastCaisse.SelectedValue);


            Properties.Settings.Default.PrintBuyOnOrOff = cbBuyPrinterState.Checked;
            Properties.Settings.Default.PrintSaleOnOrOff = cbSalePrinterState.Checked;

            Properties.Settings.Default.DaysAddDebt = Convert.ToInt32(txtDaysDelaysDebt.Text);
            Properties.Settings.Default.NoOfDataInDgvs = Convert.ToInt32(txtDataInDgv.Text);

            Properties.Settings.Default.NbrCopyOfSaleFacture = Convert.ToInt32(txtSaleCopy.Text);
            Properties.Settings.Default.NbrCopyOfBuyFacture = Convert.ToInt32(txtBuyCopy.Text);


            Properties.Settings.Default.PrintBuyFactureType8cm = rbBuy8cm.Checked;


            Properties.Settings.Default.PrintSaleFactureType8cm = rbSale8cm.Checked;

            Properties.Settings.Default.ApplyBuyPrice = cbEditBuyPrice.Checked;
            Properties.Settings.Default.ApplyWholeSale = cbEditWholeSaleprice.Checked;
            Properties.Settings.Default.ApplySalePrice = cbEditSalePrice.Checked;


            Properties.Settings.Default.IdCustomerSale = Convert.ToInt32(cmbCustomers.SelectedValue).ToString();
            Properties.Settings.Default.Save();





        }

        private void txtDaysDelaysDebt_KeyPress(object sender, KeyPressEventArgs e)
        {
            string currentText = (sender as TextBox)?.Text ?? string.Empty;


            char decimalSeparator = Properties.Settings.Default.DecimalSEP[0];


            if (!char.IsDigit(e.KeyChar) /*&& e.KeyChar != decimalSeparator && e.KeyChar != (char)8*/)
            {
                e.Handled = true;
            }

            //else if (e.KeyChar == decimalSeparator && currentText.Contains(decimalSeparator))
            //{
            //    e.Handled = true;
            //}
        }
    }
}
