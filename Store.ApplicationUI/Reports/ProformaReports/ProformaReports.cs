using System.IO;
using DevExpress.XtraReports.UI;
using Microsoft.IdentityModel.Tokens;

namespace Store.ApplicationUI.Reports.ProformaReports
{
    public partial class ProformaReports : DevExpress.XtraReports.UI.XtraReport
    {
        public ProformaReports()
        {
            InitializeComponent();

            InitialElements();
        }
        void InitialElements()
        {

            if (!Properties.Settings.Default.AddressStore.IsNullOrEmpty())
            {
                lblAddress.Text = Properties.Settings.Default.AddressStore;
                lblAddress.Visible = true;
                xrLabel11.Visible = true;
            }

            if (!Properties.Settings.Default.FacturePhoneNumber.IsNullOrEmpty())
            {
                xrLabel6.Text = Properties.Settings.Default.FacturePhoneNumber;
                xrLabel6.Visible = true;
                xrLabel9.Visible = true;
            }

            if (!Properties.Settings.Default.StoreNameFacture.IsNullOrEmpty())
            {
                lblStoreName.Text = Properties.Settings.Default.StoreNameFacture;
                lblStoreName.Visible = true;
                xrLabel4.Visible = true;
            }
            if (!xrLabel8.Text.IsNullOrEmpty() || xrLabel8.Text == " ")
            {

                xrLabel7.Visible = false;
                xrLabel8.Visible = false;
            }
            if (!xrLabel3.Text.IsNullOrEmpty() || xrLabel3.Text == " ")
            {

                xrLabel1.Visible = false;
                xrLabel3.Visible = false;
            }
            pbLogo.Visible = Properties.Settings.Default.LogoYesNo;
            //ReportHeader.Visible = Properties.Settings.Default.LogoYesNo;
            pageInfo1.TextFormatString = Code.Helper.FactureHelper.GetHijriDate();
            if (Properties.Settings.Default.LogoYesNo)
            {
                LoadImageFromBase64();
            }
            if (xrTable2.Rows.Count > 6)
            {
                GroupFooter1.Visible = false;
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
