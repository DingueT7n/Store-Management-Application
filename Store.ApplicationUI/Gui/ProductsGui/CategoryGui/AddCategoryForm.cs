using Microsoft.IdentityModel.Tokens;
using Store.ApplicationUI.Code.Helper;
using Store.ApplicationUI.Gui.LoadingGui;
using Store.Infrastructure.Data;

namespace Store.ApplicationUI.Gui.ProductsGui.Category
{
    public partial class AddCategoryForm : Form
    {
        private static MainForm? _main;
        private static ApplicationDbContext _context;
        private static AddCategoryForm _addCategoryForm;

        public AddCategoryForm(MainForm main)
        {
            InitializeComponent();
            _main = main;
            this.Owner = _main;
            LoadData();
        }
        public static AddCategoryForm Instance(MainForm main)
        {
            _main = main;
            // If the instance is null, create a new one and assign it to the static field
            if (_addCategoryForm == null)
            {
                _context = new ApplicationDbContext();

                _addCategoryForm = new AddCategoryForm(_main);

            }

            // Return the singleton instance

            return _addCategoryForm;
        }
        public void SetCategoryToDgv()
        {
            //DgvProducts.DataSource = await Task.Run(() => productsRepository.GetAll(p => p.Category));
            DgvCategory.DataSource = _context.Categories
                .ToList();
            lblCategoryId.Text = (_context.Categories.Count() + 1).ToString();
            lblEmptyData.Visible = dgvHelper.IsEmpty(DgvCategory);
        }
        public async void LoadData()
        {
            //ShowLoading
            LoadingForm.Instance(_main).Show();
            if (await Task.Run(() => _context.Database.CanConnect()))
            {
                SetCategoryToDgv();
                SetColumns();

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
            txtNameِCategory.Text = "";
            RefreshDgv();
        }

        private void SetColumns()
        {
            //DgvProducts.Columns[0].HeaderCell.Value = "المعرف";
            DgvCategory.Columns[1].HeaderCell.Value = "معرف الصنف";
            DgvCategory.Columns[0].HeaderCell.Value = "اسم الصنف";



        }
        private void btnAddCategory_Click(object sender, EventArgs e)
        {
            if (txtNameِCategory.Text.IsNullOrEmpty())
            {
                MsgHelper.ShowRequiredFields();

            }
            else
            {
                Store.Core.Entities.Products.Category category = new();
                category.CategoryName = txtNameِCategory.Text;
                _context.Categories.Add(category);
                _context.SaveChanges();

            }
            RefreshDgv();

        }

        private void CellMouseClick(object sender, DataGridViewCellMouseEventArgs e)
        {
            try
            {
                btnAddCategory.Enabled = false;
                txtNameِCategory.Text = DgvCategory.CurrentRow.Cells[0].Value.ToString();
                lblCategoryId.Text = DgvCategory.CurrentRow.Cells[1].Value.ToString();
                btnEditCategory.Enabled = true;
                //btnRefresh.Enabled = true;
            }
            catch (Exception ex) { MessageBox.Show(ex.Message); }
        }

        private void btnEditCategory_Click(object sender, EventArgs e)
        {
            if (MsgHelper.ShowEditDialog())
            {
                Store.Core.Entities.Products.Category category = _context.Categories.FirstOrDefault(x => x.Id ==
                Convert.ToInt32(DgvCategory.CurrentRow.Cells[1].Value.ToString())
                );

                category.CategoryName = txtNameِCategory.Text;
                _context.Update(category);
                _context.SaveChanges();
                vider();

            }
        }

        private void btnDeleteCategory_Click(object sender, EventArgs e)
        {
            if (MsgHelper.ShowDeleteDialog())
            {
                _context.Remove(Convert.ToInt32(DgvCategory.CurrentRow.Cells[1].Value.ToString()));
                _context.SaveChanges();
            }
            RefreshDgv();
        }

        private void RefreshDgv()
        {

            SetCategoryToDgv();
        }

        private void button1_Click(object sender, EventArgs e)
        {
            btnAddCategory.Enabled = true;
            vider();
            btnEditCategory.Enabled = false;


        }

        private void btnSearch_Click(object sender, EventArgs e)
        {
            DgvCategory.DataSource = _context.Categories.Where(x => x.Id.ToString() == txtSearch.Text ||
            x.CategoryName.Contains(txtSearch.Text)).ToList();
            lblEmptyData.Visible = dgvHelper.IsEmpty(DgvCategory);
            txtSearch.Text = string.Empty;
        }

        private void btnClose_Click(object sender, EventArgs e)
        {
            this.Close();

        }
    }
}
