using System.Globalization;
using Microsoft.Extensions.DependencyInjection;
using Store.ApplicationUI.Code.System;
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

            Application.ThreadException += GlobalExceptionHandler;
            AppDomain.CurrentDomain.UnhandledException += GlobalFatalErrorHandler;

            var services = new ServiceCollection();
            services.AddApplicationServices();

            var serviceProvider = services.BuildServiceProvider(); // ✅ FIX: moved up
            AppContainer.Services = serviceProvider;               // ✅ FIX: after building

            SetCultureInfo();

            // Optional: Persist decimal separator
            NumberFormatInfo numberFormat = CultureInfo.CurrentCulture.NumberFormat;
            Properties.Settings.Default.DecimalSEP = numberFormat.NumberDecimalSeparator;
            Properties.Settings.Default.Save();

            Application.EnableVisualStyles();
            Application.SetCompatibleTextRenderingDefault(false);

            var loginForm = serviceProvider.GetRequiredService<LoginForm>();
            var mainForm = serviceProvider.GetRequiredService<MainForm>();
            Application.Run(mainForm);
            //if (loginForm.ShowDialog() == DialogResult.OK)
            //{
            //    loginForm.Dispose();
            //}
            //else
            //{
            //    Application.Exit();
            //}


        }
        private static void GlobalExceptionHandler(object sender, ThreadExceptionEventArgs e)
        {
            MessageBox.Show($"Unhandled exception: {e.Exception.Message}", "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
        }

        private static void GlobalFatalErrorHandler(object sender, UnhandledExceptionEventArgs e)
        {
            var ex = e.ExceptionObject as Exception;
            MessageBox.Show($"Fatal error: {ex?.Message}", "Critical Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
        }
        private static void SetCultureInfo()
        {
            CultureInfo culture = new("en-US"); // or "fr-FR", "ar-DZ", etc.
            Thread.CurrentThread.CurrentCulture = culture;
            Thread.CurrentThread.CurrentUICulture = culture;
        }
    }
}