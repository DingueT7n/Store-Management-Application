namespace Store.ApplicationUI.Gui.ProductsGui
{
    public partial class ProductsUserControl : UserControl
    {
        private static ProductsGui.ProductsUserControl? _productsUserControl;
        public ProductsUserControl()
        {
            InitializeComponent();
        }
        public static ProductsUserControl Instance()
        {

            // If the instance is null, create a new one and assign it to the static field
            if (_productsUserControl == null)
            {
                _productsUserControl = new ProductsUserControl();
            }

            // Return the singleton instance
            return _productsUserControl;
        }
    }
}
