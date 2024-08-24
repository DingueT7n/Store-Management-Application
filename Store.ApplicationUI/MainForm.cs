using Store.ApplicationUI.Code.Helper;
using Store.Infrastructure.Data;

namespace Store.ApplicationUI
{
    public partial class MainForm : Form
    {
        private PageHelper pageHelper;

        public static ApplicationDbContext? Context { get; set; }
        public MainForm()
        {
            InitializeComponent();

            // Set Home Page Default!!
            pageHelper = new(this);
            pageHelper.SetNewPage(Gui.HomeGui.HomeUserControl.Instance());

            // Retrive Last Window State
            Context = new ApplicationDbContext();
            SetScreenState(Properties.Settings.Default.IsMaxScreen);
        }
        private void SetScreenState(bool isMax)
        {
            if (isMax)
            {
                WindowState = FormWindowState.Maximized;
            }
            else
            {
                WindowState = FormWindowState.Normal;
            }

        }

        private void MainForm_FormClosing(object sender, FormClosingEventArgs e)
        {
            // Save the Windows State in the Settings
            Properties.Settings.Default.IsMaxScreen = this.WindowState == FormWindowState.Maximized;
            Properties.Settings.Default.Save();
        }

        private void btnHomeSummary_Click(object sender, EventArgs e)
        {
            pageHelper.SetNewPage(Gui.HomeGui.HomeUserControl.Instance());
        }

        private void BtnProducts_Click(object sender, EventArgs e)
        {
            pageHelper.SetNewPage(Gui.ProductsGui.ProductsUserControl.Instance(this));
        }
    }
}
