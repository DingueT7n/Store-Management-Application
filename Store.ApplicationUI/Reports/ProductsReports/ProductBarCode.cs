namespace Store.ApplicationUI.Reports.ProductsReports
{
    public partial class ProductBarCode : DevExpress.XtraReports.UI.XtraReport
    {
        public ProductBarCode()
        {
            InitializeComponent();
            xrLabel1.Text = Properties.Settings.Default.StoreNameFacture;
        }
    }
}
