using System.Data;
using Store.ApplicationUI.Code.Helper;
using Store.ApplicationUI.Reports.ReportPerviwGui;

namespace Store.ApplicationUI.Gui.ProductsGui.BarcodeGui
{
    public partial class BarCodeForm : Form
    {
        public BarCodeForm()
        {
            InitializeComponent();
        }
        private void btnReviewPrint_Click(object sender, EventArgs e)
        {
            try
            {

                if (!string.IsNullOrEmpty(txtBarCode.Text) &&
                    !string.IsNullOrEmpty(txtProductName.Text) &&
                    !string.IsNullOrEmpty(txtPrice.Text))
                {
                    if (!MsgHelper.ShowBareCodeIsGoingToChange())
                        return;

                    // Initialize the report
                    Reports.ProductsReports.ProductBarCode barCode = new();

                    // Set the report's label values
                    barCode.lblCodeBar.Text = txtBarCode.Text;
                    barCode.lblProductLineBar.Text = txtBarCode.Text;
                    barCode.lblProductName.Text = txtProductName.Text;
                    barCode.lblPrice.Text = txtPrice.Text;

                    // Ensure DataSource is set properly, even if it's empty
                    barCode.DataSource = new DataTable();

                    // Use the report in a form viewer
                    XtraForm1 xtraForm1 = new();
                    barCode.CreateDocument();
                    xtraForm1.documentViewer1.DocumentSource = barCode;
                    xtraForm1.ShowDialog();
                }
                else
                {
                    MsgHelper.ShowRequiredFields2();
                }
            }
            catch (Exception ex)
            {
                MessageBox.Show($"حدث خطأ: {ex.Message}", "خطأ", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
        }

    }
}
