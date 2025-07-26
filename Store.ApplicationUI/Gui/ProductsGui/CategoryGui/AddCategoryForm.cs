using DevExpress.Xpo;
using Store.ApplicationUI.Code.Helper;
using Store.ApplicationUI.Gui.LoadingGui;
using Store.Core.Interfaces;
using Store.Infrastructure.Data;

namespace Store.ApplicationUI.Gui.ProductsGui.Category
{
    public partial class AddCategoryForm : Form
    {
        private readonly MainForm _main;
        private readonly ApplicationDbContext _context;
        private readonly ICategoryRepository _categoryRepository;

        public AddCategoryForm(MainForm main, ApplicationDbContext context, ICategoryRepository categoryRepository)
        {
            InitializeComponent();
            _main = main;
            _context = context;
            _categoryRepository = categoryRepository;
            this.Owner = _main;
            LoadData();
        }

        //public static AddCategoryForm Instance(MainForm main)
        //{
        //    if (_addCategoryForm == null || _addCategoryForm.IsDisposed)
        //    {
        //        _context = new ApplicationDbContext();
        //        _addCategoryForm = new AddCategoryForm(main);
        //    }
        //    else
        //    {
        //        if (!_addCategoryForm.Visible)
        //        {
        //            _addCategoryForm.Show();
        //        }
        //        _addCategoryForm.BringToFront();
        //    }
        //    return _addCategoryForm;
        //}
        public async void SetCategoryToDgv()
        {
            DgvCategory.DataSource = new List<Store.Core.Entities.Products.Category>();

            DgvCategory.DataSource = await _categoryRepository.GetAllAsync();
            lblCategoryId.Text = (_context.Categories.Count() + 1).ToString();
            lblEmptyData.Visible = dgvHelper.IsEmpty(DgvCategory);
        }
        public async void LoadData()
        {
            //ShowLoading
            LoadingForm.Instance(_main).Show();
            if (await _context.Database.CanConnectAsync())
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
            SetCategoryToDgv();
        }

        private void SetColumns()
        {
            //DgvProducts.Columns[0].HeaderCell.Value = "المعرف";

            DgvCategory.Columns[1].HeaderCell.Value = "معرف الصنف";
            DgvCategory.Columns[0].HeaderCell.Value = "اسم الصنف";



        }
        private async void btnAddCategory_Click(object sender, EventArgs e)
        {
            if (string.IsNullOrWhiteSpace(txtNameِCategory.Text))
            {
                MsgHelper.ShowRequiredFields();
                return;
            }

            try
            {
                var category = new Store.Core.Entities.Products.Category
                {
                    CategoryName = txtNameِCategory.Text.Trim()
                };

                var result = await _categoryRepository.AddAsync(category);

                if (result == "1")
                {
                    Code.Helper.ToasterHelper.ShowAddToast();
                    vider(); // Clear the form after success
                    SetCategoryToDgv(); // Refresh the DataGridView
                }
                else
                {
                    ToasterHelper.ShowErrorHappened("حدث خطأ أثناء الإضافة:\n" + result);
                }
            }
            catch (Exception ex)
            {
                Code.Helper.ToasterHelper.ShowErrorHappened(ex.Message);
            }

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

        private async void btnEditCategory_Click(object sender, EventArgs e)
        {
            if (DgvCategory.CurrentRow == null || DgvCategory.CurrentRow.Cells[1].Value == null)
            {
                MessageBox.Show("الرجاء تحديد صنف للتعديل.");
                return;
            }

            if (string.IsNullOrWhiteSpace(txtNameِCategory.Text))
            {
                MessageBox.Show("الرجاء إدخال اسم الصنف الجديد.");
                return;
            }

            if (MsgHelper.ShowEditDialog())
            {
                try
                {
                    int categoryId = Convert.ToInt32(DgvCategory.CurrentRow.Cells[1].Value);

                    var existingCategory = await _categoryRepository.GetAsync(categoryId);

                    if (existingCategory == null)
                    {
                        ToasterHelper.ShowErrorHappened("لم يتم العثور على الصنف.");
                        return;
                    }

                    existingCategory.CategoryName = txtNameِCategory.Text;

                    var result = await _categoryRepository.UpdateAsync(categoryId.ToString(), existingCategory);

                    if (result == "1")
                    {
                        Code.Helper.ToasterHelper.ShowEditToast();
                        vider();
                        SetCategoryToDgv(); // await if method is async
                    }
                    else
                    {
                        ToasterHelper.ShowErrorHappened("حدث خطأ أثناء التعديل:\n" + result);
                    }
                }
                catch (Exception ex)
                {
                    Code.Helper.ToasterHelper.ShowErrorHappened(ex.Message);
                }
            }
        }

        private async void btnDeleteCategory_Click(object sender, EventArgs e)
        {
            if (DgvCategory.CurrentRow == null || DgvCategory.CurrentRow.Cells[1].Value == null)
            {
                MessageBox.Show("الرجاء تحديد صنف للحذف.");
                return;
            }

            if (MsgHelper.ShowDeleteDialog())
            {
                try
                {
                    int categoryId = Convert.ToInt32(DgvCategory.CurrentRow.Cells[1].Value);

                    var cate = await _categoryRepository.DeleteAsync(categoryId.ToString());

                    if (cate is null)
                    {
                        MessageBox.Show("هذا الصنف غير موجود.");
                        return;
                    }


                    if (cate == "1")
                        Code.Helper.ToasterHelper.ShowDeletedToast();

                    SetCategoryToDgv(); // Await this to update the UI properly
                }
                catch (Exception ex)
                {
                    MessageBox.Show("حدث خطأ أثناء الحذف:\n" + ex.Message);
                }
            }
        }
        private void button1_Click(object sender, EventArgs e)
        {
            btnAddCategory.Enabled = true;
            vider();
            btnEditCategory.Enabled = false;


        }

        private async void btnSearch_Click(object sender, EventArgs e)
        {
            txtSearch.Text = txtSearch.Text.Replace("\r\n", "");

            DgvCategory.DataSource = await _context.Categories.Where(x => x.Id.ToString() == txtSearch.Text ||
            x.CategoryName.Contains(txtSearch.Text)).ToListAsync();
            lblEmptyData.Visible = dgvHelper.IsEmpty(DgvCategory);
            txtSearch.Text = string.Empty;
        }

        private void btnClose_Click(object sender, EventArgs e)
        {
            this.Close();

        }
    }
}
