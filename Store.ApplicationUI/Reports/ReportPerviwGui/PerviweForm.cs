using DevExpress.XtraReports.UI;

namespace Store.ApplicationUI.Reports.ReportPerviwGui
{
    public partial class PerviweForm : Form
    {
        public PerviweForm()
        {
            InitializeComponent();
        }



        public async void LoadReport(XtraReport report)
        {

            documentViewer1.LookAndFeel.SetSkinStyle(DevExpress.LookAndFeel.SkinStyle.WXI);
            documentViewer1.DocumentSource = report;
            await report.CreateDocumentAsync();
        }

        private void PerviweForm_Load(object sender, EventArgs e)
        {

            documentViewer1.LookAndFeel.SetSkinStyle(DevExpress.LookAndFeel.SkinStyle.WXI);
            var a = documentViewer1.LookAndFeel.SkinName;


        }
    }
}
