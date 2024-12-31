using Store.ApplicationUI.Code.Helper;
using Store.ApplicationUI.Gui.LoadingGui;
using Store.ApplicationUI.Gui.ProductsGui;
using Store.Infrastructure.Data;
using Store.Infrastructure.Repositories;

namespace Store.ApplicationUI.Gui.SupplierGui
{
    public partial class SuppliersUserControl : UserControl
    {
        private static SuppliersUserControl? _suppliersUserControl;
        private static MainForm? _main;
        private static ApplicationDbContext _context;
        public static SuppliersRepository? suppliersRepository;
        private AddSupplierForm addSupplierrForm;
        public SuppliersUserControl()
        {
            InitializeComponent();
        }
        public static bool CheckInstance()
        {
            return (_suppliersUserControl == null);
        }

        public static SuppliersUserControl Instance(MainForm main)
        {
            _main = main;
            // If the instance is null, create a new one and assign it to the static field
            _context = new ApplicationDbContext();
            if (CheckInstance())
            {
                suppliersRepository = new SuppliersRepository(_context);


                _suppliersUserControl = new SuppliersUserControl();

            }

            // Return the singleton instance
            _suppliersUserControl.LoadData();
            return _suppliersUserControl;
        }
        public async void SetProductsToDgv()
        {
            //DgvِSupplier.DataSource = await Task.Run(() => productsRepository.GetAll(p => p.Category));
            DgvِSupplier.DataSource = _context.Suppliers.OrderBy(x => x.SupplierName)
                .ToList();
        }

        public static void RefreshDgv()
        {
            //DgvِSupplier.DataSource = await Task.Run(() => productsRepository.GetAllProducts());
            _suppliersUserControl.LoadData();
        }
        // methodes 
        public async void LoadData()
        {


            //ShowLoading
            LoadingForm.Instance(_main).Show();
            if (await Task.Run(() => suppliersRepository.IsConnected()))
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
            lblEmptyData.Visible = dgvHelper.IsEmpty(DgvِSupplier);
        }

        private void SetColumns()
        {
            //DgvِSupplier.Columns[0].HeaderCell.Value = "المعرف";
            DgvِSupplier.Columns[0].HeaderCell.Value = "اسم المورد";
            DgvِSupplier.Columns[1].HeaderCell.Value = "العنوان";
            DgvِSupplier.Columns[2].HeaderCell.Value = "رقم الهاتف";
            DgvِSupplier.Columns[3].HeaderCell.Value = "ملاحظة";
            DgvِSupplier.Columns[4].HeaderCell.Value = "اعلى دين مسموح به";
            DgvِSupplier.Columns[5].HeaderCell.Value = "مجموع الديون";
            DgvِSupplier.Columns[6].HeaderCell.Value = "معرف المورد";
        }

        private void btnAddSupplier_Click(object sender, EventArgs e)
        {

            addSupplierrForm = AddSupplierForm.Instance(_main);
            addSupplierrForm.Show();

        }

        private void btnEditSupplier_Click(object sender, EventArgs e)
        {
            if (DgvِSupplier.Rows.Count > 0)
            {
                if (addSupplierrForm == null || addSupplierrForm.IsDisposed)
                {
                    addSupplierrForm = AddSupplierForm.Instance(_main);
                    addSupplierrForm.SetDataToEdit(
                        DgvِSupplier.CurrentRow.Cells[0].Value.ToString(),
                        DgvِSupplier.CurrentRow.Cells[1].Value.ToString(),
                        DgvِSupplier.CurrentRow.Cells[2].Value.ToString(),
                        DgvِSupplier.CurrentRow.Cells[4].Value.ToString(),
                        DgvِSupplier.CurrentRow.Cells[3].Value.ToString(),
                        DgvِSupplier.CurrentRow.Cells[6].Value.ToString());
                    addSupplierrForm.Show();
                }
                else
                {
                    addSupplierrForm.Focus();
                }
            }
        }

        private void btnDeleteSupplier_Click(object sender, EventArgs e)
        {
            if (MsgHelper.ShowDeleteDialog())
            {
                suppliersRepository.DeleteAsync(DgvِSupplier.CurrentRow.Cells[6].Value.ToString());
                Code.Helper.ToasterHelper.ShowDeletedToast();

            }
            RefreshDgv();
        }

        private void btnSearch_Click(object sender, EventArgs e)
        {
            DgvِSupplier.DataSource = suppliersRepository.SearchAll(txtSearch.Text);
            lblEmptyData.Visible = dgvHelper.IsEmpty(DgvِSupplier);
            txtSearch.Text = string.Empty;
        }

        private void btnRefresh_Click(object sender, EventArgs e)
        {
            LoadData();
        }
    }
}
