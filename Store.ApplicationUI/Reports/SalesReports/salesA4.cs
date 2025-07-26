using System.IO;
using Microsoft.EntityFrameworkCore;
using Microsoft.IdentityModel.Tokens;
using Store.Infrastructure.Data;

namespace Store.ApplicationUI.Reports.SalesReports
{
    public partial class salesA4 : DevExpress.XtraReports.UI.XtraReport
    {
        private readonly ApplicationDbContext _context;

        public salesA4(ApplicationDbContext context)
        {
            InitializeComponent();
            _context = context;
            InitialElements();

        }
        async void InitialElements()
        {
            lblCaisse.Text = (await _context.Caisses
                    .FirstOrDefaultAsync(x => x.Id == Properties.Settings.Default.DefaultCaisseId)).CaisseName
                    ?? "الصندوق الافتراضي";
            lblPhoneNumber.Text = Properties.Settings.Default.FacturePhoneNumber;
            lblStoreName.Text = Properties.Settings.Default.StoreNameFacture;
            lblSentenceUnderFacture.Text = Properties.Settings.Default.SentenceUnderFacture;
            xrLabel6.Visible = lblPhoneNumber.Visible = lblPhoneNumber.Text != string.Empty || lblPhoneNumber.Text != "";
            lblStoreName.Visible = lblStoreName.Text != string.Empty;
            if (!Properties.Settings.Default.AddressStore.IsNullOrEmpty())
            {
                lblAddress.Text = Properties.Settings.Default.AddressStore;
                lblAddress.Visible = true;
                xrLabel20.Visible = true;
            }
            pbLogo.Visible = Properties.Settings.Default.LogoYesNo;


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
