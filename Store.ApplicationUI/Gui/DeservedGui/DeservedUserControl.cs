using Store.ApplicationUI.Code.Helper;
using Store.ApplicationUI.Gui.LoadingGui;
using Store.Infrastructure.Data;

namespace Store.ApplicationUI.Gui.DeservedGui
{
    public partial class DeservedUserControl : UserControl
    {
        private static DeservedGui.DeservedUserControl? _deservedUserControl;
        private static MainForm? _main;
        //private AddDeservedForm addDeservedForm;
        public AddDeservedTypeForm addDeservedTypeyForm;
        private static ApplicationDbContext _context;
        public static Infrastructure.Repositories.DeservedsRepository? deservedsRepository;
        //public static CategorysRepository? categoryRepository;
        public DeservedUserControl()
        {
            InitializeComponent();
        }
        public static DeservedUserControl Instance(MainForm main)
        {
            _main = main;
            // If the instance is null, create a new one and assign it to the static field
            if (_deservedUserControl == null)
            {
                _context = new ApplicationDbContext();

                deservedsRepository = new Infrastructure.Repositories.DeservedsRepository(_context);
                //categoryRepository = new CategorysRepository(_context);
                _deservedUserControl = new DeservedUserControl();

            }

            // Return the singleton instance
            _deservedUserControl.LoadData();
            return _deservedUserControl;
        }
        public static bool CheckInstance()
        {
            return (_deservedUserControl == null);
        }
        public async void SetProductsToDgv()
        {
            //DgvProducts.DataSource = await Task.Run(() => productsRepository.GetAll(p => p.Category));
            DgvProducts.DataSource = deservedsRepository.GetAll(x => x.DeservedType);
        }

        public static void RefreshDgv()
        {
            //DgvProducts.DataSource = await Task.Run(() => productsRepository.GetAllProducts());
            _deservedUserControl.LoadData();
        }
        // methodes 
        public async void LoadData()
        {


            //ShowLoading
            LoadingForm.Instance(_main).Show();
            if (await Task.Run(() => deservedsRepository.IsConnected()))
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
            lblEmptyData.Visible = dgvHelper.IsEmpty(DgvProducts);
        }

        private void SetColumns()
        {
            DgvProducts.Columns[0].HeaderCell.Value = "اسم المستخدم";
            DgvProducts.Columns[1].HeaderCell.Value = "الثمن المدفوع";
            DgvProducts.Columns[2].HeaderCell.Value = "تاريخ المصروفة";
            DgvProducts.Columns[3].HeaderCell.Value = "وقت المصروفة";
            DgvProducts.Columns[4].HeaderCell.Value = "الملاحظة";
            DgvProducts.Columns[5].HeaderCell.Value = "معرف النوع";
            DgvProducts.Columns[6].HeaderCell.Value = "نوع المصروفة";
            DgvProducts.Columns[7].HeaderCell.Value = "معرف المصروفة";
        }

        private void btnAddDeserved_Click(object sender, EventArgs e)
        {

        }

        private void btnEditDeserved_Click(object sender, EventArgs e)
        {

        }

        private void btnAddDeservedType_Click(object sender, EventArgs e)
        {
            if (addDeservedTypeyForm == null || addDeservedTypeyForm.IsDisposed)
            {
                addDeservedTypeyForm = AddDeservedTypeForm.Instance(_main);
                addDeservedTypeyForm.Show();
            }
            else
            {
                addDeservedTypeyForm.Focus();
            }
        }
    }
}
