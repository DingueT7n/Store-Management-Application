using Microsoft.IdentityModel.Tokens;
using Store.ApplicationUI.Code.Helper;
using Store.ApplicationUI.Gui.LoadingGui;

namespace Store.ApplicationUI.Gui.CaisseAndBankGui
{
    public partial class CaisseDetailsForm : Form
    {
        private static MainForm _main;

        public CaisseDetailsForm(MainForm main)
        {
            _main = main;
            InitializeComponent();
            this.Owner = main;
            LoadData();
        }

        public void SetCategoryToDgv()
        {
            //DgvProducts.DataSource = await Task.Run(() => productsRepository.GetAll(p => p.Category));
            DgvCaisser.DataSource = MainForm.Context.Caisses
                .ToList();
            lblidCaisse.Text = (MainForm.Context.Caisses.Count() + 1).ToString();
            lblEmptyData.Visible = dgvHelper.IsEmpty(DgvCaisser);
        }
        public async void LoadData()
        {
            //ShowLoading
            LoadingForm.Instance(_main).Show();
            if (await Task.Run(() => MainForm.Context.Database.CanConnect()))
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
            DgvCaisser.Columns[2].HeaderCell.Value = "معرف الصندوق";
            DgvCaisser.Columns[0].HeaderCell.Value = "اسم الصندوق";
            DgvCaisser.Columns[1].HeaderCell.Value = "رصيد الصندوق";
        }
        private void RefreshDgv()
        {

            SetCategoryToDgv();
            txtNameِCategory.Text = string.Empty;
        }

        private void btnAddCaisse_Click(object sender, EventArgs e)
        {
            if (txtNameِCategory.Text.IsNullOrEmpty())
            {
                MsgHelper.ShowRequiredFields();

            }
            else
            {
                Store.Core.Entities.Caisses.Caisse caisse = new();
                caisse.CaisseName = txtNameِCategory.Text;
                caisse.MoneyinCaisse = 0;
                MainForm.Context.Caisses.Add(caisse);
                MainForm.Context.SaveChanges();
            }
            RefreshDgv();
        }

        private void btnEditCaisse_Click(object sender, EventArgs e)
        {
            if (MsgHelper.ShowEditDialog())
            {
                Store.Core.Entities.Caisses.Caisse caisse = MainForm.Context.Caisses.FirstOrDefault(x => x.Id ==
                Convert.ToInt32(DgvCaisser.CurrentRow.Cells[2].Value.ToString())
                );

                caisse.CaisseName = txtNameِCategory.Text;
                MainForm.Context.Update(caisse);
                MainForm.Context.SaveChangesAsync();
                vider();
            }
        }

        private void btnDeleteCaisse_Click(object sender, EventArgs e)
        {
            if (MsgHelper.ShowDeleteDialog())
            {
                MainForm.Context.Remove(Convert.ToInt32(DgvCaisser.CurrentRow.Cells[2].Value.ToString()));
                MainForm.Context.SaveChangesAsync();
            }
            RefreshDgv();
        }

        private void btnSearch_Click(object sender, EventArgs e)
        {
            DgvCaisser.DataSource = MainForm.Context.Caisses.Where(x => x.Id.ToString() == txtSearch.Text ||
            x.CaisseName.Contains(txtSearch.Text)).ToList();
            lblEmptyData.Visible = dgvHelper.IsEmpty(DgvCaisser);
            txtSearch.Text = string.Empty;
        }

        private void btnClose_Click(object sender, EventArgs e)
        {
            this.Close();
        }

        private void btnRefresh_Click(object sender, EventArgs e)
        {
            btnAddCaisse.Enabled = true;
            vider();
            btnEditCaisse.Enabled = false;
        }

        private void DgvCaisser_CellMouseClick(object sender, DataGridViewCellMouseEventArgs e)
        {
            if (DgvCaisser.SelectedRows.Count > 0)
                try
                {
                    btnAddCaisse.Enabled = false;
                    txtNameِCategory.Text = DgvCaisser.CurrentRow.Cells[0].Value.ToString();
                    lblidCaisse.Text = DgvCaisser.CurrentRow.Cells[2].Value.ToString();
                    btnEditCaisse.Enabled = true;
                    //btnRefresh.Enabled = true;
                }
                catch (Exception ex) { MessageBox.Show(ex.Message); }
            else
            {
                MsgHelper.ShowEmptyDataGridView();
            }
        }

        private void btnDepositToCaisse_Click(object sender, EventArgs e)
        {
            this.Size = this.MaximumSize;
            PageHelper.SetOperation(DepositToCaisseGui.DepositCaisseUserControl.Instance(_main, this), this);
        }

        private void button1_Click(object sender, EventArgs e)
        {
            this.Size = this.MaximumSize;
            PageHelper.SetOperation(DepositToBankGui.DepositTobankUserControl.Instance(_main, this), this);
        }

        private void button2_Click(object sender, EventArgs e)
        {
            this.Size = this.MaximumSize;
            PageHelper.SetOperation(WithdrawFromCaisseGui.WithdrawFromCaisseUserControl.Instance(_main, this), this);
        }

        private void button3_Click(object sender, EventArgs e)
        {
            this.Size = this.MaximumSize;
            PageHelper.SetOperation(WithdrawFromBank.WithdrawFromBankUserControl.Instance(_main, this), this);
        }
    }
}
