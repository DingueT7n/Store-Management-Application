namespace Store.ApplicationUI.Gui.HomeGui
{
    public partial class HomeUserControl : UserControl
    {
        private static HomeUserControl? _homeUserControl;
        public HomeUserControl()
        {
            InitializeComponent();


        }

        public static HomeUserControl Instance()
        {

            // If the instance is null, create a new one and assign it to the static field
            if (_homeUserControl == null)
            {
                _homeUserControl = new HomeUserControl();
            }

            // Return the singleton instance
            return _homeUserControl;
        }
        private void timer1_Tick(object sender, EventArgs e)
        {
            lblhora.Text = DateTime.Now.ToString("hh:mm:ss ");
            lblFecha.Text = DateTime.Now.ToLongDateString();
        }
    }
}
