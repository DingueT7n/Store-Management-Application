using System.IO;

namespace Store.ApplicationUI.Reports.VouchersReports
{
    public partial class RecieptVoucher : DevExpress.XtraReports.UI.XtraReport
    {
        public RecieptVoucher()
        {
            InitializeComponent();
            InitialElements();


        }
        void InitialElements()
        {
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
    }
}
