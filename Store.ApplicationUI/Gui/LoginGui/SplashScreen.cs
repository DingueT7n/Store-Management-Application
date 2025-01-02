namespace Store.ApplicationUI.Gui.LoginGui
{
    public partial class SplashScreen : DevExpress.XtraSplashScreen.SplashScreen
    {
        public SplashScreen()
        {
            InitializeComponent();
            this.labelCopyright.Text = "Copyright ALG-D © 1998-" + DateTime.Now.Year.ToString();
            this.labelCopyright.Text = $"{DateTime.Now.Year.ToString()}-2024 ALG-D © جميع الحقوق محفوظة";
            this.BackColor = Color.White;
            Code.Helper.ConStringHelper.SetConString();
        }

        #region Overrides

        public override void ProcessCommand(Enum cmd, object arg)
        {
            base.ProcessCommand(cmd, arg);
        }

        #endregion

        public enum SplashScreenCommand
        {
        }
    }
}