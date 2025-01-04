using DevExpress.XtraReports.UI;

namespace Store.ApplicationUI.Reports.ReportPerviwGui
{
    public partial class PerviweForm : Form
    {
        public PerviweForm()
        {
            InitializeComponent();
        }
        private static PerviweForm? _Form;

        public static PerviweForm Instance(XtraReport report)
        {
            if (_Form == null || _Form.IsDisposed)
            {
                _Form = new PerviweForm();
            }
            else
            {
                // Bring the form to the front if it exists.
                if (!_Form.Visible)
                {
                    _Form.Show();
                }
                _Form.BringToFront();
            }
            if (_Form != null && report is not null)
            {

                _Form.documentViewer1.LookAndFeel.SetSkinStyle(DevExpress.LookAndFeel.SkinStyle.WXI);
                _Form.documentViewer1.DocumentSource = report;
                report.CreateDocument();
            }

            return _Form;
        }

        private void PerviweForm_Load(object sender, EventArgs e)
        {

            documentViewer1.LookAndFeel.SetSkinStyle(DevExpress.LookAndFeel.SkinStyle.WXI);
            var a = documentViewer1.LookAndFeel.SkinName;


        }
    }
}
