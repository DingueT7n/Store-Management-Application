using Store.ApplicationUI.Code.Helper;
using Store.ApplicationUI.Code.System;
using Store.Infrastructure.Data;

namespace Store.ApplicationUI.Gui.ProductsGui.BarcodeGui
{
    public partial class BarCodeForm : Form
    {
        private readonly MainForm _main;
        private readonly ApplicationDbContext _context;
        private readonly ControlManager _controlManager;

        public BarCodeForm(MainForm main, ApplicationDbContext context, ControlManager controlManager)
        {
            InitializeComponent();
            _main = main;
            _context = context;
            _controlManager = controlManager;
        }

        private void btnReviewPrint_Click(object sender, EventArgs e)
        {
            try
            {

                if (!string.IsNullOrEmpty(txtBarCode.Text) &&
                    !string.IsNullOrEmpty(txtProductName.Text) &&
                    !string.IsNullOrEmpty(txtPrice.Text))
                {
                    if (lblIdProduct.Text != string.Empty)
                    {
                        var product = _context.Products.FirstOrDefault(x => x.Id.ToString() == lblIdProduct.Text);
                        if (product != null && product.CodeBar != txtBarCode.Text)
                        {
                            if (!MsgHelper.ShowBareCodeIsGoingToChange())
                                return;
                            if (!MsgHelper.ShowBareCodeDuplicated(_context, txtBarCode.Text))
                            {
                                product.CodeBar = txtBarCode.Text;
                                _context.Update(product);
                                _context.SaveChanges();
                            }

                            else { return; }
                        }
                        // Initialize the report
                        Code.Helper.ToasterHelper.ShowPrinting();
                        Reports.ProductsReports.ProductBarCode barCode = new();

                        // Set the report's label values
                        barCode.lblCodeBar.Text = txtBarCode.Text;
                        barCode.lblProductLineBar.Text = txtBarCode.Text;
                        barCode.lblProductName.Text = txtProductName.Text;
                        barCode.lblPrice.Text = $"السعر {txtPrice.Text}";

                        barCode.CreateDocument();
                        // Ensure DataSource is set properly, even if it's empty
                        //barCode.DataSource = new DataTable();

                        // Use the report in a form viewer

                        Reports.ReportPerviwGui.PerviweForm xtraForm1 = _controlManager.GetF<Reports.ReportPerviwGui.PerviweForm>();
                        xtraForm1.LoadReport(barCode);
                        xtraForm1.ShowDialog();

                        //xtraForm1.documentViewer1.DocumentSource = barCode;
                        //xtraForm1.Show();


                    }
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

        private void btnPrint_Click(object sender, EventArgs e)
        {
            Code.Helper.ToasterHelper.ShowPrinting();
            Reports.ProductsReports.ProductBarCode barCode = new();

            // Set the report's label values
            barCode.lblCodeBar.Text = txtBarCode.Text;
            barCode.lblProductLineBar.Text = txtBarCode.Text;
            barCode.lblProductName.Text = txtProductName.Text;
            barCode.lblPrice.Text = $"السعر {txtPrice.Text}";
            barCode.CreateDocument();
            string printername = Properties.Settings.Default.PrinterBarCode;
            for (int i = 0; i < Convert.ToInt32(nbrCopies.Value); i++)
            {


                // Force print to the specified printer
                var printTool = new DevExpress.XtraReports.UI.ReportPrintTool(barCode);
                printTool.PrinterSettings.PrinterName = printername;
                printTool.Print(printername);

            }
        }

        private void BarCodeForm_Load(object sender, EventArgs e)
        {

            Reports.ProductsReports.ProductBarCode barCode = new();

            // Set the report's label values
            barCode.lblCodeBar.Text = txtBarCode.Text;
            barCode.lblProductLineBar.Text = txtBarCode.Text;
            barCode.lblProductName.Text = txtProductName.Text;
            barCode.lblPrice.Text = $"السعر {txtPrice.Text}";
            barCode.CreateDocument();
            documentViewer1.DocumentSource = barCode;
        }
    }
}
