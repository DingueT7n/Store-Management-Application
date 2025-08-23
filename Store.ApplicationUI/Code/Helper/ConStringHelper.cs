namespace Store.ApplicationUI.Code.Helper
{
    public static class ConStringHelper
    {


        public static void SetConString()
        {
            string server = Properties.Settings.Default.Server;
            string db = Properties.Settings.Default.DataBase;


            if (Properties.Settings.Default.ConType == "local")
            {
                Store.Infrastructure.ConString.ConStringValue = $"Server={server};Database={db};Encrypt=false;Trusted_Connection=True;MultipleActiveResultSets=True;";
            }
            else
            {
                string user = Properties.Settings.Default.UserName;
                string password = Properties.Settings.Default.PassCon;

                Store.Infrastructure.ConString.ConStringValue = $"Server={server};Database={db};User Id={user};Password={password};Encrypt=false;Timeout={60};MultipleActiveResultSets=True;";

            }
        }

    }
}
