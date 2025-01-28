using System.Security.Cryptography;
using System.Text;
using Store.ApplicationUI.Code.Helper;


namespace Store.ApplicationUI.Gui.LoginGui.KeyActivationForm
{
    public partial class KeyActivationForm : Form
    {
        public KeyActivationForm()
        {
            InitializeComponent();
            var computer = new LibreHardwareMonitor.Hardware.Computer()
            {
                IsCpuEnabled = true,
                IsMotherboardEnabled = true,
                IsMemoryEnabled = true
            };
            computer.Open();
            string val = string.Empty;
            foreach (var hardware in computer.Hardware)
            {
                hardware.Update();

                foreach (var sensor in hardware.Sensors)
                {
                    val += ($"{sensor.Name}: {sensor.Value}");
                }
            }
            txtProductId.Text = GetHash(val);
        }
        private static string GetHash(string s)
        {
            MD5CryptoServiceProvider mD5CryptoServiceProvider = new MD5CryptoServiceProvider();
            byte[] bytes = new ASCIIEncoding().GetBytes(s);
            return GetHexString(mD5CryptoServiceProvider.ComputeHash(bytes));
        }

        private static string GetHexString(byte[] bt)
        {
            string text = string.Empty;
            for (int i = 0; i < bt.Length; i++)
            {
                byte num = bt[i];
                int num2 = num & 0xF;
                int num3 = (num >> 4) & 0xF;
                text = ((num3 <= 9) ? (text + num3) : (text + (char)(num3 - 10 + 65)));
                text = ((num2 <= 9) ? (text + num2) : (text + (char)(num2 - 10 + 65)));
                if (i + 1 != bt.Length && (i + 1) % 2 == 0)
                {
                    text += "-";
                }
            }

            return text;
        }

        private void KeyActivationForm_Load(object sender, EventArgs e)
        {

            txtKey.Text = Properties.Settings.Default.Key;
            txtDatecreated.Text = Properties.Settings.Default.Creation;
            txtDaysLeft.Text = Properties.Settings.Default.Days_left;
            txtKeycrypt.Text = Properties.Settings.Default.Key_crypt;
            txtDateExp.Text = Properties.Settings.Default.Expiration;
        }

        private void rbtrial_CheckedChanged(object sender, EventArgs e)
        {
            if (rbtrial.Checked == true)
            {
                txtDuration.Text = "15";
            }
        }
        private string hach = "& @LG-D2025 GUERBOUz &";
        private void rbFull_CheckedChanged(object sender, EventArgs e)
        {
            if (rbFull.Checked == true)
            {
                txtDuration.Text = "365";
            }
        }

        private void button1_Click(object sender, EventArgs e)
        {
            try
            {
                if (rbtrial.Checked == true)
                {
                    byte[] data = UTF8Encoding.UTF8.GetBytes(txtProductId.Text);
                    using (MD5CryptoServiceProvider md5 = new MD5CryptoServiceProvider())
                    {
                        byte[] keys = md5.ComputeHash(UTF8Encoding.UTF8.GetBytes(hach));
                        using (TripleDESCryptoServiceProvider trip = new TripleDESCryptoServiceProvider() { Key = keys, Mode = CipherMode.ECB, Padding = PaddingMode.PKCS7 })
                        {
                            ICryptoTransform transform = trip.CreateEncryptor();
                            byte[] res = transform.TransformFinalBlock(data, 0, data.Length);
                            txtKeycrypt.Text = Convert.ToBase64String(res, 0, res.Length);
                            SKGL.Validate validate = new SKGL.Validate();
                            validate.secretPhase = txtKeycrypt.Text;
                            validate.Key = txtKey.Text;
                            txtDatecreated.Text = (validate.CreationDate).ToString();
                            txtDateExp.Text = (validate.ExpireDate).ToString();
                            txtDaysLeft.Text = (validate.DaysLeft).ToString();
                            MessageBox.Show("تم الاستفادة من فترة التجربة", "التفعيل", MessageBoxButtons.OK, MessageBoxIcon.Information);
                            ToasterHelper.ShowTrialVersionActivated();
                            Properties.Settings.Default.TrialVersion = true;
                            Properties.Settings.Default.Save();
                        }
                    }
                }
                else
                {
                    byte[] data = UTF32Encoding.UTF32.GetBytes(txtProductId.Text);
                    using (MD5CryptoServiceProvider md5 = new MD5CryptoServiceProvider())
                    {
                        byte[] keys = md5.ComputeHash(UTF32Encoding.UTF32.GetBytes(hach));
                        using (TripleDESCryptoServiceProvider trip = new TripleDESCryptoServiceProvider() { Key = keys, Mode = CipherMode.ECB, Padding = PaddingMode.PKCS7 })
                        {
                            ICryptoTransform transform = trip.CreateEncryptor();
                            byte[] res = transform.TransformFinalBlock(data, 0, data.Length);
                            txtKeycrypt.Text = Convert.ToBase64String(res, 0, res.Length);
                            SKGL.Validate validate = new SKGL.Validate();
                            validate.secretPhase = txtKeycrypt.Text;
                            validate.Key = txtKey.Text;
                            txtDatecreated.Text = (validate.CreationDate).ToString();
                            txtDateExp.Text = (validate.ExpireDate).ToString();
                            txtDaysLeft.Text = (validate.DaysLeft).ToString();
                            ToasterHelper.ShowFullVersionActivated();
                            MessageBox.Show("تم تفعيل البرنامج", "التفعيل", MessageBoxButtons.OK, MessageBoxIcon.Information);
                            Properties.Settings.Default.TrialVersion = false;
                            Properties.Settings.Default.Save();

                        }
                    }
                }
                Properties.Settings.Default.Key = txtKey.Text;
                Properties.Settings.Default.Creation = txtDatecreated.Text;
                Properties.Settings.Default.Days_left = txtDaysLeft.Text;
                Properties.Settings.Default.Key_crypt = txtKeycrypt.Text;
                Properties.Settings.Default.Expiration = txtDateExp.Text;
                Properties.Settings.Default.Save();
            }
            catch (Exception)
            {
                MessageBox.Show("اتصل بالمطور حصل خطأ", "التفعيل", MessageBoxButtons.OK, MessageBoxIcon.Error);

                //MessageBox.Show($"An error occurred: {ex.Message}", "Registration", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
        }
    }
}
