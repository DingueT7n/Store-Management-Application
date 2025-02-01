using System.IO;
using DevExpress.XtraReports.UI;
using Microsoft.IdentityModel.Tokens;
using Store.Infrastructure.Data;

namespace Store.ApplicationUI.Reports.SuppliersAccountsReports
{
    public partial class SuppliersAccountsReports : DevExpress.XtraReports.UI.XtraReport
    {
        ApplicationDbContext _context;
        public SuppliersAccountsReports()
        {
            InitializeComponent();
            _context = new ApplicationDbContext();
            InitialElements();
        }
        void InitialElements()
        {
            lblStoreName.Text = Properties.Settings.Default.StoreNameFacture;

            if (!Properties.Settings.Default.AddressStore.IsNullOrEmpty())
            {
                lblAddress.Text = Properties.Settings.Default.AddressStore;
                lblAddress.Visible = true;
                xrLabel20.Visible = true;
            }
            pbLogo.Visible = Properties.Settings.Default.LogoYesNo;
            ReportHeader.Visible = Properties.Settings.Default.LogoYesNo;
            pageInfo1.TextFormatString = Code.Helper.FactureHelper.GetHijriDate();

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
