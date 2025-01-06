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
            // If the instance is null or has been disposed, create a new one.
            if (loadingForm == null || loadingForm.IsDisposed)
            {
                loadingForm = new LoadingForm();
            }
            else
            {
                // Bring the form to the front if it exists.
                if (!loadingForm.Visible)
                {
                    loadingForm.Show();
                }
                loadingForm.BringToFront();
            }

            return loadingForm;
        }

    }

}
