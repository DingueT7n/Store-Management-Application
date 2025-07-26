using Microsoft.EntityFrameworkCore;
using Microsoft.IdentityModel.Tokens;
using Store.ApplicationUI.Code.Helper;
using Store.ApplicationUI.Code.System;
using Store.ApplicationUI.Gui.CaisseAndBankGui.DepositToBankGui;
using Store.ApplicationUI.Gui.CaisseAndBankGui.DepositToCaisseGui;
using Store.ApplicationUI.Gui.CaisseAndBankGui.TransferBetweenCaissesGui;
using Store.ApplicationUI.Gui.CaisseAndBankGui.TransfertBetweenBankAndCaisseGui;
using Store.ApplicationUI.Gui.CaisseAndBankGui.WithdrawFromBank;
using Store.ApplicationUI.Gui.CaisseAndBankGui.WithdrawFromCaisseGui;
using Store.ApplicationUI.Gui.LoadingGui;
using Store.Core.Entities.Caisses;
using Store.Infrastructure.Data;

namespace Store.ApplicationUI.Gui.CaisseAndBankGui
{
    public partial class CaisseDetailsForm : Form
    {

        private readonly MainForm _main;
        private readonly ApplicationDbContext _context;
        private readonly ControlManager _controlManager1;

        public CaisseDetailsForm(MainForm main, ApplicationDbContext context, ControlManager controlManager1)
        {

            _main = main;

            _context = context;
            _controlManager1 = controlManager1;
            InitializeComponent();
            this.Owner = main;
            LoadData();
        }

        public async void SetCategoryToDgv()
        {
            //DgvProducts.DataSource = await Task.Run(() => productsRepository.GetAll(p => p.Category));

            DgvCaisser.DataSource = await _context.Caisses
                .ToListAsync();
            lblidCaisse.Text = (_context.Caisses.Count() + 1).ToString();
            lblEmptyData.Visible = dgvHelper.IsEmpty(DgvCaisser);
        }
        public async void LoadData()
        {
            //ShowLoading
            LoadingForm.Instance(_main).Show();
            if (await _context.Database.CanConnectAsync())
            {
                SetColumns();
                SetCategoryToDgv();

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
            DgvCaisser.DataSource = new List<Caisse>();
            DgvCaisser.Columns[0].HeaderCell.Value = "اسم الصندوق";
            DgvCaisser.Columns[1].HeaderCell.Value = "رصيد الصندوق";
            DgvCaisser.Columns[2].HeaderCell.Value = "حالة الصندوق";
            DgvCaisser.Columns[5].HeaderCell.Value = "معرف الصندوق";
            DgvCaisser.Columns[3].Visible = false;
            DgvCaisser.Columns[4].Visible = false;
            //DgvCaisser.Columns[3].Visible = false;

        }
        private void RefreshDgv()
        {

            SetCategoryToDgv();
            txtNameِCategory.Text = string.Empty;
        }

        private async void btnAddCaisse_Click(object sender, EventArgs e)
        {
            ToasterHelper.PlayNotificationSound();
            if (txtNameِCategory.Text.IsNullOrEmpty())
            {
                MsgHelper.ShowRequiredFields();

            }
            else
            {
                Store.Core.Entities.Caisses.Caisse caisse = new();
                caisse.CaisseName = txtNameِCategory.Text;
                caisse.MoneyinCaisse = 0;
                await _context.Caisses.AddAsync(caisse);
                await _context.SaveChangesAsync();
                Code.Helper.ToasterHelper.ShowAddToast();

            }
            RefreshDgv();
        }

        private async void btnEditCaisse_Click(object sender, EventArgs e)
        {
            try
            {

                ToasterHelper.PlayNotificationSound();

                if (MsgHelper.ShowEditDialog())
                {
                    Store.Core.Entities.Caisses.Caisse caisse = await _context.Caisses.FirstOrDefaultAsync(x => x.Id ==
                    Convert.ToInt32(DgvCaisser.CurrentRow.Cells[5].Value.ToString())
                    );
                    if (caisse != null)
                    {
                        caisse.CaisseName = txtNameِCategory.Text;
                        _context.Update(caisse);
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

        private async void btnDeleteCaisse_Click(object sender, EventArgs e)
        {
            try
            {
                ToasterHelper.PlayNotificationSound();


                if (MsgHelper.ShowDeleteDialog())
                {
                    Store.Core.Entities.Caisses.Caisse caisse = await _context.Caisses.FirstOrDefaultAsync(x => x.Id ==
                    Convert.ToInt32(DgvCaisser.CurrentRow.Cells[5].Value.ToString()) && x.Status == CaisseStatus.Closed
                    );
                    if (caisse != null)
                    {
                        _context.Remove(caisse);
                        await _context.SaveChangesAsync();
                        Code.Helper.ToasterHelper.ShowDeletedToast();
                    }
                    if (_context.Caisses.Count() < 1)
                    {
                        var val = new Caisse
                        {
                            CaisseName = "الصندوق الاول",
                            MoneyinCaisse = 0
                        };
                        await _context.AddAsync(val);
                        await _context.SaveChangesAsync();

                        Properties.Settings.Default.DefaultCaisseId = val.Id;
                        Properties.Settings.Default.Save();
                    }
                }
                RefreshDgv();
            }
            catch (Exception)
            {

                throw;
            }
        }

        private async void btnSearch_Click(object sender, EventArgs e)
        {
            txtSearch.Text = txtSearch.Text.Replace("\r\n", "");

            DgvCaisser.DataSource = await _context.Caisses.Where(x => x.Id.ToString() == txtSearch.Text ||
            x.CaisseName.Contains(txtSearch.Text)).ToListAsync();
            lblEmptyData.Visible = dgvHelper.IsEmpty(DgvCaisser);
            txtSearch.Text = string.Empty;
        }

        private void btnClose_Click(object sender, EventArgs e)
        {
            this.Close();
        }

        private void btnRefresh_Click(object sender, EventArgs e)
        {
            ToasterHelper.PlayNotificationSound();

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
                    lblidCaisse.Text = DgvCaisser.CurrentRow.Cells[5].Value.ToString();
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
            PageHelper.SetOperation(_controlManager1.Get<DepositCaisseUserControl>(), this);
        }

        private void button1_Click(object sender, EventArgs e)
        {
            this.Size = this.MaximumSize;

            PageHelper.SetOperation(_controlManager1.Get<DepositTobankUserControl>(), this);

        }

        private void button2_Click(object sender, EventArgs e)
        {
            this.Size = this.MaximumSize;

            PageHelper.SetOperation(_controlManager1.Get<WithdrawFromCaisseUserControl>(), this);
        }

        private void button3_Click(object sender, EventArgs e)
        {
            this.Size = this.MaximumSize;
            PageHelper.SetOperation(_controlManager1.Get<WithdrawFromBankUserControl>(), this);

        }

        private void button4_Click(object sender, EventArgs e)
        {
            this.Size = this.MaximumSize;
            PageHelper.SetOperation(_controlManager1.Get<TransferBetweenCaissesGuiUserControl>(), this);

        }

        private void button5_Click(object sender, EventArgs e)
        {
            this.Size = this.MaximumSize;
            PageHelper.SetOperation(_controlManager1.Get<TransfertBetweenBankAndCaisseUserControl>(), this);

        }

        private void txtSearch_KeyDown(object sender, KeyEventArgs e)
        {
            if (e.KeyCode == Keys.Enter)
            {
                btnSearch_Click(sender, e);
            }
        }

        private void CaisseDetailsForm_Load(object sender, EventArgs e)
        {
            LoadData();
        }
    }
}
