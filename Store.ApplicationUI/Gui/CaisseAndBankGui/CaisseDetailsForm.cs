using Microsoft.IdentityModel.Tokens;
using Store.ApplicationUI.Code.Helper;
using Store.ApplicationUI.Gui.LoadingGui;
using Store.Core.Entities.Caisses;
using Store.Infrastructure.Data;

namespace Store.ApplicationUI.Gui.CaisseAndBankGui
{
    public partial class CaisseDetailsForm : Form
    {
        private ApplicationDbContext _context;
        private static MainForm _main;

        private static CaisseDetailsForm? _caisseDetailsForm;

        public CaisseDetailsForm(MainForm main)
        {
            _context = new ApplicationDbContext();
            _main = main;
            InitializeComponent();
            this.Owner = main;
            LoadData();
        }
        public static void CheckInstance()
        {
            if (_caisseDetailsForm is not null)
            {
                _caisseDetailsForm.LoadData();
            }
        }
        public static CaisseDetailsForm Instance(MainForm main)
        {
            if (_caisseDetailsForm == null || _caisseDetailsForm.IsDisposed)
            {
                _caisseDetailsForm = new CaisseDetailsForm(main);
            }
            else
            {
                // Bring the form to the front if it exists.
                if (!_caisseDetailsForm.Visible)
                {
                    _caisseDetailsForm.Show();
                }
                _caisseDetailsForm.BringToFront();
            }

            return _caisseDetailsForm;

        }
        public void SetCategoryToDgv()
        {
            //DgvProducts.DataSource = await Task.Run(() => productsRepository.GetAll(p => p.Category));
            _context = new ApplicationDbContext();
            DgvCaisser.DataSource = _context.Caisses
                .ToList();
            lblidCaisse.Text = (_context.Caisses.Count() + 1).ToString();
            lblEmptyData.Visible = dgvHelper.IsEmpty(DgvCaisser);
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

        private void btnAddCaisse_Click(object sender, EventArgs e)
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
                _context.Caisses.Add(caisse);
                _context.SaveChanges();
                Code.Helper.ToasterHelper.ShowAddToast();

            }
            RefreshDgv();
        }

        private void btnEditCaisse_Click(object sender, EventArgs e)
        {
            try
            {

                ToasterHelper.PlayNotificationSound();

                if (MsgHelper.ShowEditDialog())
                {
                    Store.Core.Entities.Caisses.Caisse caisse = _context.Caisses.FirstOrDefault(x => x.Id ==
                    Convert.ToInt32(DgvCaisser.CurrentRow.Cells[5].Value.ToString())
                    );
                    if (caisse != null)
                    {
                        caisse.CaisseName = txtNameِCategory.Text;
                        _context.Update(caisse);
                        _context.SaveChangesAsync();
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

        private void btnDeleteCaisse_Click(object sender, EventArgs e)
        {
            try
            {
                ToasterHelper.PlayNotificationSound();


                if (MsgHelper.ShowDeleteDialog())
                {
                    Store.Core.Entities.Caisses.Caisse caisse = _context.Caisses.FirstOrDefault(x => x.Id ==
                    Convert.ToInt32(DgvCaisser.CurrentRow.Cells[5].Value.ToString()) && x.Status == CaisseStatus.Closed
                    );
                    if (caisse != null)
                    {
                        _context.Remove(caisse);
                        _context.SaveChanges();
                        Code.Helper.ToasterHelper.ShowDeletedToast();
                    }
                    if (_context.Caisses.Count() < 1)
                    {
                        var val = new Caisse
                        {
                            CaisseName = "الصندوق الاول",
                            MoneyinCaisse = 0
                        };
                        _context.Add(val);
                        _context.SaveChanges();

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

        private void btnSearch_Click(object sender, EventArgs e)
        {
            txtSearch.Text = txtSearch.Text.Replace("\r\n", "");

            DgvCaisser.DataSource = _context.Caisses.Where(x => x.Id.ToString() == txtSearch.Text ||
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

        private void button4_Click(object sender, EventArgs e)
        {
            this.Size = this.MaximumSize;
            PageHelper.SetOperation(TransferBetweenCaissesGui.TransferBetweenCaissesGuiUserControl.Instance(_main, this), this);
        }

        private void button5_Click(object sender, EventArgs e)
        {
            this.Size = this.MaximumSize;
            PageHelper.SetOperation(TransfertBetweenBankAndCaisseGui.TransfertBetweenBankAndCaisseUserControl.Instance(_main, this), this);
        }

        private void txtSearch_KeyDown(object sender, KeyEventArgs e)
        {
            if (e.KeyCode == Keys.Enter)
            {
                btnSearch_Click(sender, e);
            }
        }
    }
}
