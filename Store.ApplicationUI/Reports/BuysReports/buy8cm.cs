using System.Globalization;
using System.IO;
using DevExpress.XtraReports.UI;
using Microsoft.IdentityModel.Tokens;
using Store.Infrastructure.Data;

namespace Store.ApplicationUI.Reports.BuysReports
{
    public partial class buy8cm : DevExpress.XtraReports.UI.XtraReport
    {
        ApplicationDbContext _context;

        public buy8cm()
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
            xrLabel6.Visible = lblPhoneNumber.Visible = lblPhoneNumber.Text != string.Empty || lblPhoneNumber.Text != "";
            if (!Properties.Settings.Default.AddressStore.IsNullOrEmpty())
            {
                lblAddress.Text = Properties.Settings.Default.AddressStore;
                lblAddress.Visible = true;
                xrLabel20.Visible = true;
            }
            pbLogo.Visible = Properties.Settings.Default.LogoYesNo;
            ReportHeader.Visible = Properties.Settings.Default.LogoYesNo;
            HijriCalendar hijriCalendar = new HijriCalendar();
            CultureInfo hijriCulture = new CultureInfo("ar-SA");
            hijriCulture.DateTimeFormat.Calendar = hijriCalendar; // Force Hijri calendar
            string hijriDate = DateTime.Now.ToString("dddd, dd MMMM yyyy", hijriCulture);
            pageInfo1.TextFormatString = hijriDate;
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
    }
}
