using System.IO;
using Microsoft.IdentityModel.Tokens;
using Store.Infrastructure.Data;

namespace Store.ApplicationUI.Reports
{
    public partial class sale8cm : DevExpress.XtraReports.UI.XtraReport
    {
        ApplicationDbContext _context;
        public sale8cm()
        {
            InitializeComponent();
            _context = new ApplicationDbContext();

            InitialElements();


        }
        void InitialElements()
        {
            lblCaisse.Text = _context.Caisses
                    .FirstOrDefault(x => x.Id == Properties.Settings.Default.DefaultCaisseId)?.CaisseName
                    ?? "الصندوق الافتراضي";
            lblPhoneNumber.Text = Properties.Settings.Default.FacturePhoneNumber;
            lblStoreName.Text = Properties.Settings.Default.StoreNameFacture;
            lblSentenceUnderFacture.Text = Properties.Settings.Default.SentenceUnderFacture;
            if (!Properties.Settings.Default.AddressStore.IsNullOrEmpty())
            {
                lblAddress.Text = Properties.Settings.Default.AddressStore;
                lblAddress.Visible = true;
                xrLabel20.Visible = true;
            }
            pbLogo.Visible = Properties.Settings.Default.LogoYesNo;
            ReportHeader.Visible = Properties.Settings.Default.LogoYesNo;

            if (Properties.Settings.Default.LogoYesNo)
            {
                LoadImageFromBase64();
            }
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
            else
            {

            }
        }
        private void sale8cm_BeforePrint(object sender, System.ComponentModel.CancelEventArgs e)
        {

        }
    }
}
