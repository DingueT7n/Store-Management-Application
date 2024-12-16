using Store.ApplicationUI.Code.Helper;
using Store.ApplicationUI.Gui.LoadingGui;
using Store.Infrastructure.Data;

namespace Store.ApplicationUI.Gui.HomeGui
{
    public partial class StatisticsUserControl : UserControl
    {
        private static StatisticsUserControl? _UserControl;
        private static MainForm? _main;
        private static ApplicationDbContext? _context;

        public StatisticsUserControl()
        {
            InitializeComponent();

        }
        public static bool CheckInstance()
        {
            return (_UserControl == null);


        }

        public static StatisticsUserControl? Instance(MainForm main)
        {
            _main = main;
            // If the instance is null, create a new one and assign it to the static field
            if (CheckInstance())
            {
                _context = new ApplicationDbContext();
                _UserControl = new StatisticsUserControl();
            }
            // Return the singleton instance
            _UserControl?.LoadData();
            return _UserControl;
        }
        public void SetProductsToDgv()
        {

        }

        public static void RefreshDgv()
        {
            //DgvِCustomer.DataSource = await Task.Run(() => productsRepository.GetAllProducts());
            _UserControl?.LoadData();
        }
        // methodes 
        public async void LoadData()
        {


            //ShowLoading
            LoadingForm.Instance(_main).Show();
            if (await Task.Run(() => _context.Database.CanConnect()))
            {
                //Start Load Data

                // if its an admin or Normal user 

                SetProductsToDgv();
                SetColumns();
                //_data.Clear();
            }
            else
            {

                LoadingForm.Instance(_main).Hide();
                //No Connection
                MsgHelper.ShowServerError();
            }
            //Hideloading
            LoadingForm.Instance(_main).Hide();
            // Show EmptyDAta


        }

        private void SetColumns()
        {
            ////DgvِCustomer.Columns[0].HeaderCell.Value = "المعرف";
            //DgvِCustomer.Columns[0].HeaderCell.Value = "اسم الموظف";
            //DgvِCustomer.Columns[1].HeaderCell.Value = "راتب الموظف";
            //DgvِCustomer.Columns[2].HeaderCell.Value = "تاريخ انضمام الموظف";
            //DgvِCustomer.Columns[3].HeaderCell.Value = "رقم بطاقة التعريف الوطني";
            //DgvِCustomer.Columns[4].HeaderCell.Value = "البريد الالكتروني";
            //DgvِCustomer.Columns[5].HeaderCell.Value = "العنوان";
            //DgvِCustomer.Columns[6].HeaderCell.Value = "رقم الهاتف";
            //DgvِCustomer.Columns[7].HeaderCell.Value = "معرف الموظف";
        }


    }
}
