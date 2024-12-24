using System.Data;
using Store.ApplicationUI.Code.Helper;
using Store.ApplicationUI.Reports.ReportPerviwGui;
using Store.Infrastructure.Data;

namespace Store.ApplicationUI.Gui.ProductsGui.BarcodeGui
{
    public partial class BarCodeForm : Form
    {
        private static BarCodeForm? _Form;
        private MainForm _main;
        private ApplicationDbContext _context;

        public BarCodeForm(MainForm main)
        {
            InitializeComponent();
            _main = main;
            this.Owner = _main;
            _context = new ApplicationDbContext();
        }
        public static BarCodeForm Instance(MainForm main)
        {
            if (_Form == null || _Form.IsDisposed)
            {
                _Form = new BarCodeForm(main);
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

            return _Form;

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
