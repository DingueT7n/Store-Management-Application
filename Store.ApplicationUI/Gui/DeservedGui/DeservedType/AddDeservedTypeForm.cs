using Microsoft.EntityFrameworkCore;
using Microsoft.IdentityModel.Tokens;
using Store.ApplicationUI.Code.Helper;
using Store.ApplicationUI.Gui.LoadingGui;
using Store.Core.Entities.AllDeserved;
using Store.Infrastructure.Data;

namespace Store.ApplicationUI.Gui.DeservedGui
{
    public partial class AddDeservedTypeForm : Form
    {
        private readonly MainForm _main;
        private readonly ApplicationDbContext _context;


        public AddDeservedTypeForm(MainForm main, ApplicationDbContext context)
        {
            InitializeComponent();

            _main = main;
            this.Owner = _main;
            _context = context;


        }

        public async Task SetCategoryToDgv()
        {
            //DgvProducts.DataSource = await Task.Run(() => productsRepository.GetAll(p => p.Category));
            DgvTypes.DataSource = await _context.DeservedsTypes
                .ToListAsync();
            lblCategoryId.Text = (_context.DeservedsTypes.Count() + 1).ToString();
            lblEmptyData.Visible = dgvHelper.IsEmpty(DgvTypes);
        }
        public async Task LoadData()
        {
            //ShowLoading
            LoadingForm.Instance(_main).Show();
            if (await _context.Database.CanConnectAsync())
            {
                SetColumns();
                await SetCategoryToDgv();

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
            //DgvProducts.Columns[0].HeaderCell.Value = "المعرف";
            DgvTypes.DataSource = new List<DeservedType>();
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
            await LoadData();
        }


        private async void btnEditTypes_Click(object sender, EventArgs e)
        {
            try
            {
                ToasterHelper.PlayNotificationSound();


                if (MsgHelper.ShowEditDialog())
                {
                    DeservedType DeservedType = await _context.DeservedsTypes.FirstOrDefaultAsync(x => x.Id ==
                    Convert.ToInt32(DgvTypes.CurrentRow.Cells[1].Value.ToString())
                    );
                    if (DeservedType != null)
                    {
                        DeservedType.Description = txtNameِCategory.Text;
                        _context.Update(DeservedType);
                        await _context.SaveChangesAsync();
                        Code.Helper.ToasterHelper.ShowEditToast();

                        await LoadData();
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
                    var type = await _context.DeservedsTypes.FirstOrDefaultAsync
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
            await LoadData();
        }

        private async void btnSearch_Click(object sender, EventArgs e)
        {
            txtSearch.Text = txtSearch.Text.Replace("\r\n", "");

            DgvTypes.DataSource = await _context.DeservedsTypes.Where(x => x.Id.ToString() == txtSearch.Text ||
           x.Description.Contains(txtSearch.Text)).ToListAsync();
            lblEmptyData.Visible = dgvHelper.IsEmpty(DgvTypes);
            txtSearch.Text = string.Empty;
        }

        private void btnClose_Click(object sender, EventArgs e)
        {
            Close();
        }

        private async void button1_Click(object sender, EventArgs e)
        {
            btnAddTypes.Enabled = true;
            await LoadData();
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
