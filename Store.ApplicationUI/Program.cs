using System.Globalization;
using Store.ApplicationUI.Gui.LoginGui;

namespace Store.ApplicationUI
{
    internal static class Program
    {
        /// <summary>
        ///  The main entry point for the application.
        /// </summary>
        [STAThread]
        static void Main()
        {
            // To customize application configuration such as set high DPI settings or default font,
            // see https://aka.ms/applicationconfiguration.
            ApplicationConfiguration.Initialize();

            NumberFormatInfo numberFormat = CultureInfo.CurrentCulture.NumberFormat;
            Properties.Settings.Default.DecimalSEP = numberFormat.NumberDecimalSeparator;
            Properties.Settings.Default.Save();

            Application.EnableVisualStyles();
            Application.SetCompatibleTextRenderingDefault(false);

            LoginForm loginForm = new LoginForm();
            if (loginForm.ShowDialog() == DialogResult.OK)
            {

                MainForm mainForm = new MainForm();

                loginForm.Dispose();
                loginForm = null;
                Application.Run(mainForm);
            }
            else
            {

                Application.Exit();
            }

            //Application.Run(new MainForm());
        }
    }
}