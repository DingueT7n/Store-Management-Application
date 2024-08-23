namespace Store.ApplicationUI.Gui.LoadingGui
{
    public partial class LoadingForm : Form
    {

        private static LoadingForm? loadingForm;
        private static MainForm _main;

        public LoadingForm()
        {
            InitializeComponent();
            this.Owner = _main;

        }
        public static LoadingForm Instance(MainForm main)
        {
            _main = main;
            return loadingForm ?? (loadingForm = new LoadingForm());
        }
    }
}
