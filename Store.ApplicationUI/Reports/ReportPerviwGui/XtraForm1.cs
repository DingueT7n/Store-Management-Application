using DevExpress.XtraReports.UI;

namespace Store.ApplicationUI.Reports.ReportPerviwGui
{
    public partial class XtraForm1 : DevExpress.XtraEditors.XtraForm
    {
        public XtraForm1(XtraReport report)
        {
            InitializeComponent();
            documentViewer1.DocumentSource = report;
            report.CreateDocument();
        }
        public XtraForm1()
        {
            InitializeComponent();

        }
    }
}