using System.IO;
using Store.Infrastructure.Data;

namespace Store.ApplicationUI.Reports.BuysReports
{
    public partial class buyReportsInPeriod : DevExpress.XtraReports.UI.XtraReport
    {
        private readonly ApplicationDbContext _context;

        public buyReportsInPeriod(ApplicationDbContext context)
        {
            InitializeComponent();

            _context = context;
            InitialElements();
        }
        void InitialElements()
        {


            lblStoreName.Text = Properties.Settings.Default.StoreNameFacture;


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
