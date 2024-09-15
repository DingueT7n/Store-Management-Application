using Store.ApplicationUI.Code.Helper;
using Store.ApplicationUI.Gui.LoadingGui;
using Store.Infrastructure.Data;
using Store.Infrastructure.Repositories;

namespace Store.ApplicationUI.Gui.DeservedGui
{
    public partial class AddDeservedForm : Form
    {
        private static MainForm _main;
        private ApplicationDbContext _context;
        private DeservedsRepository? deservedsRepository;
        private static AddDeservedForm _adddeservedForm;

        public AddDeservedForm(MainForm main)
        {
            InitializeComponent();
            _main = main;
            this.Owner = _main;
            _context = new ApplicationDbContext();

            deservedsRepository = new DeservedsRepository(_context);
            LoadData();
            ConfigDate();
        }
        public static bool CheckInstance()
        {
            return (_adddeservedForm == null);
        }
        public static void LoadCategory()
        {
            var s = _adddeservedForm.CMBType.SelectedValue;
            _adddeservedForm.LoadData();
            _adddeservedForm.CMBType.SelectedValue = s;
        }

        public static AddDeservedForm Instance(MainForm main)
        {
            _main = main;
            // If the instance is null, create a new one and assign it to the static field


            _adddeservedForm = new AddDeservedForm(_main);



            // Return the singleton instance

            return _adddeservedForm;
        }
        private void ConfigDate()
        {
            DtpExperation.Value = DateTime.Now;

            DtpExperation.CustomFormat = DtpExperation.CustomFormat = "yyyy-MM-dd";
        }
        public void LoadData()
        {


            //ShowLoading


            LoadingForm.Instance(_main).Show();
            if (/*await Task.Run(() =>*/ _context.Database.CanConnect())/*)*/
            {
                //Start Load Data

                // if its an admin or Normal user 

                CMBType.DataSource = _context.Categories.ToList();



                CMBType.DisplayMember = "Description"; // Set the property to display
                CMBType.ValueMember = "Id"; // Set the property to use as the value
                CMBType.Text = "اختر نوع";

                // Optionally select the first item if needed
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
        void vider()
        {
            txtValueDeserved.Text = "";

        }
        private void button1_Click(object sender, EventArgs e)
        {
            Close();
        }
    }
}
