using System.Globalization;

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
            if (string.IsNullOrEmpty(Properties.Settings.Default.DecimalSEP))
            {
                NumberFormatInfo numberFormat = CultureInfo.CurrentCulture.NumberFormat;
                Properties.Settings.Default.DecimalSEP = numberFormat.NumberDecimalSeparator;
                Properties.Settings.Default.Save();
            }
            Application.Run(new MainForm());
        }
    }
}