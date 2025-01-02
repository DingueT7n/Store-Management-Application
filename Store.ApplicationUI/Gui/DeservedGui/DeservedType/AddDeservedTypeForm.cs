using Microsoft.IdentityModel.Tokens;
using Store.ApplicationUI.Code.Helper;
using Store.ApplicationUI.Gui.LoadingGui;
using Store.Core.Entities.AllDeserved;
using Store.Infrastructure.Data;

namespace Store.ApplicationUI.Gui.DeservedGui
{
    public partial class AddDeservedTypeForm : Form
    {
        private static MainForm? _main;
        private static ApplicationDbContext _context;
        private static AddDeservedTypeForm _addDeservedTypeForm;
        public AddDeservedTypeForm(MainForm main)
        {
            InitializeComponent();
            _main = main;
            _context = new ApplicationDbContext();
            this.Owner = _main;
            LoadData();
        }
        public static AddDeservedTypeForm Instance(MainForm main)
        {
            _main = main;
            // If the instance is null, create a new one and assign it to the static field
            if (_addDeservedTypeForm == null)
            {
                _context = new ApplicationDbContext();

                _addDeservedTypeForm = new AddDeservedTypeForm(_main);

            }

            // Return the singleton instance

            return _addDeservedTypeForm;
        }
        public void SetCategoryToDgv()
        {
            //DgvProducts.DataSource = await Task.Run(() => productsRepository.GetAll(p => p.Category));
            DgvTypes.DataSource = _context.DeservedsTypes
                .ToList();
            lblCategoryId.Text = (_context.DeservedsTypes.Count() + 1).ToString();
            lblEmptyData.Visible = dgvHelper.IsEmpty(DgvTypes);
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
            DgvTypes.Columns[1].HeaderCell.Value = "معرف النوع";
            DgvTypes.Columns[0].HeaderCell.Value = "اسم النوع";



        }

        private async void btnAddTypes_Click(object sender, EventArgs e)
        {
            ToasterHelper.PlayNotificationSound();
            if (txtNameِCategory.Text.IsNullOrEmpty())
            {
                MsgHelper.ShowRequiredFields();
            }
            else
            {
                DeservedType deservedtype = new();
                deservedtype.Description = txtNameِCategory.Text;
                await _context.DeservedsTypes.AddAsync(deservedtype);
                await _context.SaveChangesAsync();
                Code.Helper.ToasterHelper.ShowAddToast();


            }
            RefreshDgv();
        }
        private void RefreshDgv()
        {

            SetCategoryToDgv();
        }

        private async void btnEditTypes_Click(object sender, EventArgs e)
        {
            try
            {
                ToasterHelper.PlayNotificationSound();


                if (MsgHelper.ShowEditDialog())
                {
                    DeservedType DeservedType = _context.DeservedsTypes.FirstOrDefault(x => x.Id ==
                    Convert.ToInt32(DgvTypes.CurrentRow.Cells[1].Value.ToString())
                    );
                    if (DeservedType != null)
                    {
                        DeservedType.Description = txtNameِCategory.Text;
                        _context.Update(DeservedType);
                        await _context.SaveChangesAsync();
                        Code.Helper.ToasterHelper.ShowEditToast();

                        vider();
                    }
                }
            }
            catch (Exception)
            {

                throw;
            }
        }

        private async void btnDeleteTypes_Click(object sender, EventArgs e)
        {
            try
            {


                ToasterHelper.PlayNotificationSound();
                if (MsgHelper.ShowDeleteDialog())
                {
                    var type = _context.DeservedsTypes.FirstOrDefault
                        (x => x.Id == Convert.ToInt32(DgvTypes.CurrentRow.Cells[1].Value.ToString()));
                    _context.DeservedsTypes.Remove(type);
                    await _context.SaveChangesAsync();
                    Code.Helper.ToasterHelper.ShowDeletedToast();

                }
            }
            catch (Exception)
            {

                throw;
            }
            RefreshDgv();
        }

        private void btnSearch_Click(object sender, EventArgs e)
        {
            DgvTypes.DataSource = _context.DeservedsTypes.Where(x => x.Id.ToString() == txtSearch.Text ||
           x.Description.Contains(txtSearch.Text)).ToList();
            lblEmptyData.Visible = dgvHelper.IsEmpty(DgvTypes);
            txtSearch.Text = string.Empty;
        }

        private void btnClose_Click(object sender, EventArgs e)
        {
            Close();
        }

        private void button1_Click(object sender, EventArgs e)
        {
            btnAddTypes.Enabled = true;
            vider();
            btnEditTypes.Enabled = false;
        }

        private void DgvTypes_CellMouseClick(object sender, DataGridViewCellMouseEventArgs e)
        {
            try
            {
                btnAddTypes.Enabled = false;
                txtNameِCategory.Text = DgvTypes.CurrentRow.Cells[0].Value.ToString();
                lblCategoryId.Text = DgvTypes.CurrentRow.Cells[1].Value.ToString();
                btnEditTypes.Enabled = true;
                //btnRefresh.Enabled = true;
            }
            catch (Exception ex) { MessageBox.Show(ex.Message); }
        }
    }
}
