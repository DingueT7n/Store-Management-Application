using Microsoft.IdentityModel.Tokens;
using Store.ApplicationUI.Code.Helper;
using Store.ApplicationUI.Gui.LoadingGui;
using Store.Core.Entities.Users;
using Store.Infrastructure.Data;

namespace Store.ApplicationUI.Gui.GeneralSettingsGui.UserRolesGui
{
    public partial class UserRolesForm : Form
    {
        private ApplicationDbContext _context;
        private static MainForm _main;

        private static UserRolesForm? _userRolesForm;

        public UserRolesForm(MainForm main)
        {
            _context = new ApplicationDbContext();
            _main = main;
            InitializeComponent();
            this.Owner = main;
            LoadData();
        }
        public static UserRolesForm Instance(MainForm main)
        {
            if (_userRolesForm == null || _userRolesForm.IsDisposed)
            {
                _userRolesForm = new UserRolesForm(main);
            }
            else
            {
                // Bring the form to the front if it exists.
                if (!_userRolesForm.Visible)
                {
                    _userRolesForm.Show();
                }
                _userRolesForm.BringToFront();
            }

            return _userRolesForm;

        }
        public void SetCategoryToDgv()
        {
            //DgvProducts.DataSource = await Task.Run(() => productsRepository.GetAll(p => p.Category));
            Dgv.DataSource = _context.Users
                .ToList();
            lblidCaisse.Text = (_context.Users.Count() + 1).ToString();
            var data = _context.Caisses.ToList();
            cmbCaisse.DataSource = data;
            cmbCaisse.DisplayMember = "CaisseName";
            cmbCaisse.ValueMember = "Id";

            var users = _context.Users.ToList();
            cmbSuppliers.DataSource = users;
            cmbSuppliers.DisplayMember = "UserName";
            cmbSuppliers.ValueMember = "Id";

            cmbUserGS.DataSource = users;
            cmbUserGS.DisplayMember = "UserName";
            cmbUserGS.ValueMember = "Id";

            cmbUserPs.DataSource = users;
            cmbUserPs.DisplayMember = "UserName";
            cmbUserPs.ValueMember = "Id";


            cmbUserCustomers.DataSource = users;
            cmbUserCustomers.DisplayMember = "UserName";
            cmbUserCustomers.ValueMember = "Id";

            cmbBuys.DataSource = users;
            cmbBuys.DisplayMember = "UserName";
            cmbBuys.ValueMember = "Id";

            cmbSuppliers.DataSource = users;
            cmbSuppliers.DisplayMember = "UserName";
            cmbSuppliers.ValueMember = "Id";

            cmbSales.DataSource = users;
            cmbSales.DisplayMember = "UserName";
            cmbSales.ValueMember = "Id";

            cmbCaisseAndBanks.DataSource = users;
            cmbCaisseAndBanks.DisplayMember = "UserName";
            cmbCaisseAndBanks.ValueMember = "Id";

            cmbDeservedAndTax.DataSource = users;
            cmbDeservedAndTax.DisplayMember = "UserName";
            cmbDeservedAndTax.ValueMember = "Id";

            cmbRefund.DataSource = users;
            cmbRefund.DisplayMember = "UserName";
            cmbRefund.ValueMember = "Id";

            cmbEmployee.DataSource = users;
            cmbEmployee.DisplayMember = "UserName";
            cmbEmployee.ValueMember = "Id";

            cmbType.SelectedIndex = 0;

            lblEmptyData.Visible = dgvHelper.IsEmpty(Dgv);
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
            txtUserName.Text = string.Empty;
            txtPassowrd.Text = string.Empty;
            txtProfit.Text = "0";
            btnAdd.Enabled = true;

            btnEdit.Enabled = false;
            RefreshDgv();
        }
        private void SetColumns()
        {
            //DgvProducts.Columns[0].HeaderCell.Value = "المعرف";
            Dgv.Columns[0].HeaderCell.Value = "اسم المستخدم";
            Dgv.Columns[1].HeaderCell.Value = "كلمة السر";
            Dgv.Columns[2].HeaderCell.Value = "نوع المستخدم";
            Dgv.Columns[3].HeaderCell.Value = "معرف الخزنة";
            Dgv.Columns[4].HeaderCell.Value = "نسبة الربح";
            Dgv.Columns[5].HeaderCell.Value = "معرف المستخدم";
            Dgv.CellFormatting += (s, e) =>
            {
                // Check if this is the column you want to mask
                if (e.ColumnIndex == 1 && e.Value != null)
                {
                    // Mask the value
                    e.Value = new string('*', e.Value.ToString().Length);
                    e.FormattingApplied = true;
                }
            };
        }
        private void RefreshDgv()
        {

            SetCategoryToDgv();
            txtUserName.Text = string.Empty;
            txtPassowrd.Text = string.Empty;
            txtProfit.Text = string.Empty;
        }

        private void btnAdd_Click(object sender, EventArgs e)
        {
            if (txtUserName.Text.IsNullOrEmpty() || txtPassowrd.Text.IsNullOrEmpty())
            {
                MsgHelper.ShowRequiredFields();
            }
            else
            {
                User user = new();
                user.UserName = txtUserName.Text;
                user.Password = txtPassowrd.Text;
                user.UserProfit = _main.ConvertToFloat(txtProfit.Text);
                user.Stock_Id = Convert.ToInt32(cmbCaisse.SelectedValue);
                user.type = cmbType.Text;
                _context.Users.Add(user);
                _context.SaveChanges();
                UserBuy userBuy = new();
                userBuy.User_Id = user.Id;

                _context.Add(userBuy);
                _context.SaveChanges();
                UserCaisseAndBank UserCaisseAndBank = new();
                UserCaisseAndBank.User_Id = user.Id;

                _context.Add(UserCaisseAndBank);
                _context.SaveChanges();
                UserCustomer UserCustomer = new();
                UserCustomer.User_Id = user.Id;

                _context.Add(UserCustomer);
                _context.SaveChanges();

                UserDeservedAndTax UserDeservedAndTax = new();
                UserDeservedAndTax.User_Id = user.Id;

                _context.Add(UserDeservedAndTax);
                _context.SaveChanges();

                UserEmployee UserEmployee = new();
                UserEmployee.User_Id = user.Id;

                _context.Add(UserEmployee);
                _context.SaveChanges();

                UserProductAndStore UserProductAndStore = new();
                UserProductAndStore.User_Id = user.Id;

                _context.Add(UserProductAndStore);
                _context.SaveChanges();

                UserRefund UserRefund = new();
                UserRefund.User_Id = user.Id;

                _context.Add(UserRefund);
                _context.SaveChanges();

                UserSale UserSale = new();
                UserSale.User_Id = user.Id;

                _context.Add(UserSale);
                _context.SaveChanges();
                UserSetting UserSetting = new();
                UserSetting.User_Id = user.Id;

                _context.Add(UserSetting);
                _context.SaveChanges();
                UserSupplier UserSupplier = new();
                UserSupplier.User_Id = user.Id;

                _context.Add(UserSupplier);
                _context.SaveChanges();
            }
            RefreshDgv();
        }

        private void btnEdit_Click(object sender, EventArgs e)
        {
            if (MsgHelper.ShowEditDialog())
            {
                if (Dgv.SelectedRows.Count > 0)
                {
                    User user = _context?.Users.FirstOrDefault(x => x.Id ==
                    Convert.ToInt32(Dgv.CurrentRow.Cells[5].Value.ToString())
                    );
                    if (user != null)
                    {
                        user.UserName = txtUserName.Text;
                        user.Password = txtPassowrd.Text;
                        user.UserProfit = _main.ConvertToFloat(txtProfit.Text);
                        user.Stock_Id = Convert.ToInt32(cmbCaisse.SelectedValue);
                        user.type = cmbType.Text;
                        _context.Update(user);
                        _context.SaveChanges();
                    }
                }
                vider();
            }
        }

        private void btnDelete_Click(object sender, EventArgs e)
        {
            if (MsgHelper.ShowDeleteDialog())
            {
                if (Dgv.SelectedRows.Count > 0)
                {
                    var user = _context.Users.FirstOrDefault(x => x.Id == Convert.ToInt32(Dgv.CurrentRow.Cells[5].Value.ToString()));
                    if (user is not null)
                    {
                        _context.Remove(user);
                        _context.SaveChanges();
                    }

                }
            }
            RefreshDgv();
        }

        private void btnSearch_Click(object sender, EventArgs e)
        {
            Dgv.DataSource = _context.Users.Where(x => x.Id.ToString() == txtSearch.Text ||
           x.UserName == (txtSearch.Text)).ToList();
            lblEmptyData.Visible = dgvHelper.IsEmpty(Dgv);
            txtSearch.Text = string.Empty;
        }

        private void btnRefresh_Click(object sender, EventArgs e)
        {
            btnAdd.Enabled = true;
            vider();
            btnEdit.Enabled = false;
        }

        private void Dgv_CellMouseClick(object sender, DataGridViewCellMouseEventArgs e)
        {
            if (Dgv.SelectedRows.Count > 0)
                try
                {
                    btnAdd.Enabled = false;
                    txtUserName.Text = Dgv.CurrentRow.Cells[0].Value.ToString();
                    txtPassowrd.Text = Dgv.CurrentRow.Cells[1].Value.ToString();
                    cmbType.Text = Dgv.CurrentRow.Cells[2].Value.ToString();
                    cmbCaisse.SelectedValue = Convert.ToInt32(Dgv.CurrentRow.Cells[3].Value.ToString());
                    txtProfit.Text = Dgv.CurrentRow.Cells[4].Value.ToString();
                    lblidCaisse.Text = Dgv.CurrentRow.Cells[5].Value.ToString();
                    btnEdit.Enabled = true;
                    //btnRefresh.Enabled = true;
                }
                catch (Exception ex) { MessageBox.Show(ex.Message); }
            else
            {
                MsgHelper.ShowEmptyDataGridView();
            }
        }

        private void tabPageGeneralSettings_Click(object sender, EventArgs e)
        {

        }

        private void cmbUserGS_SelectionChangeCommitted(object sender, EventArgs e)
        {
            try
            {
                var user = _context.UserSettings.FirstOrDefault(x => x.User_Id.ToString() == cmbUserGS.SelectedValue.ToString());
                if (user != null)
                {
                    cbApplicationSettings.Checked = user.ApplicationSettings;
                    cbPermessions.Checked = user.UserPermession;
                }
            }
            catch (Exception)
            {

                throw;
            }
        }

        private void button1_Click(object sender, EventArgs e)
        {
            try
            {
                var user = _context.UserSettings.FirstOrDefault(x => x.User_Id.ToString() == cmbUserGS.SelectedValue.ToString());
                if (user != null)
                {
                    user.ApplicationSettings = cbApplicationSettings.Checked;
                    user.UserPermession = cbPermessions.Checked;
                    _context.Update(user);
                    _context.SaveChanges();
                }

            }
            catch (Exception)
            {

                throw;
            }
        }

        private void tabPageProductsStores_Click(object sender, EventArgs e)
        {

        }

        private void cmbUserPs_SelectionChangeCommitted(object sender, EventArgs e)
        {
            try
            {
                var user = _context.UserProductsAndStores.FirstOrDefault(x => x.User_Id.ToString() == cmbUserPs.SelectedValue.ToString());
                if (user != null)
                {
                    cbAllProducts.Checked = user.AllProducts;
                    cbAddProduct.Checked = user.AddProduct;
                    cbCategories.Checked = user.AllCategories;
                    cbStoreInventory.Checked = user.StoreInventory;
                    cbProductOutStore.Checked = user.ProductOutStoreReport;
                    cbTransfertReport.Checked = user.TransfertReport;
                }
            }
            catch (Exception)
            {

                throw;
            }
        }

        private void checkBox1_CheckedChanged(object sender, EventArgs e)
        {

        }

        private void button2_Click(object sender, EventArgs e)
        {
            try
            {
                var user = _context.UserProductsAndStores.FirstOrDefault(x => x.User_Id.ToString() == cmbUserPs.SelectedValue.ToString());
                if (user != null)
                {
                    user.AllProducts = cbAllProducts.Checked;
                    user.AddProduct = cbAddProduct.Checked;
                    user.AllCategories = cbCategories.Checked;
                    user.StoreInventory = cbStoreInventory.Checked;
                    user.ProductOutStoreReport = cbProductOutStore.Checked;
                    user.TransfertReport = cbTransfertReport.Checked;
                    _context.Update(user);
                    _context.SaveChanges();
                }

            }
            catch (Exception)
            {

                throw;
            }
        }

        private void tabPageCustomers_Click(object sender, EventArgs e)
        {

        }

        private void cmbUserCustomers_SelectionChangeCommitted(object sender, EventArgs e)
        {
            try
            {
                var user = _context.UserCustomers.FirstOrDefault(x => x.User_Id.ToString() == cmbUserCustomers.SelectedValue.ToString());
                if (user != null)
                {
                    cbAllCustomer.Checked = user.AllCustomers;
                    cbAddCustomer.Checked = user.AddCustomer;
                    cbCustomerAccount.Checked = user.CustomerAccount;
                    cbCustomerReport.Checked = user.CustomerReport;

                }
            }
            catch (Exception)
            {

                throw;
            }
        }

        private void button3_Click(object sender, EventArgs e)
        {
            try
            {
                var user = _context.UserCustomers.FirstOrDefault(x => x.User_Id.ToString() == cmbUserCustomers.SelectedValue.ToString());
                if (user != null)
                {
                    user.AllCustomers = cbAllCustomer.Checked;
                    user.AddCustomer = cbAddCustomer.Checked;
                    user.CustomerAccount = cbCustomerAccount.Checked;
                    user.CustomerReport = cbCustomerReport.Checked;
                    _context.Update(user);
                    _context.SaveChanges();
                }

            }
            catch (Exception)
            {

                throw;
            }
        }

        private void tabPageSuppliers_Click(object sender, EventArgs e)
        {

        }

        private void cmbSuppliers_SelectionChangeCommitted(object sender, EventArgs e)
        {
            try
            {
                var user = _context.UserSuppliers.FirstOrDefault(x => x.User_Id.ToString() == cmbSuppliers.SelectedValue.ToString());
                if (user != null)
                {
                    cbAllSupliers.Checked = user.AllSuppliers;
                    cbAddSupplier.Checked = user.AddSuppliers;
                    cbSupplierAccounts.Checked = user.SuppliersAccount;
                    cbSupplierReports.Checked = user.SuppliersReport;

                }
            }
            catch (Exception)
            {
                throw;
            }

        }

        private void button4_Click(object sender, EventArgs e)
        {
            try
            {
                var user = _context.UserSuppliers.FirstOrDefault(x => x.User_Id.ToString() == cmbSuppliers.SelectedValue.ToString());
                if (user != null)
                {
                    user.AllSuppliers = cbAllSupliers.Checked;
                    user.AddSuppliers = cbAddSupplier.Checked;
                    user.SuppliersAccount = cbSupplierAccounts.Checked;
                    user.SuppliersReport = cbSupplierReports.Checked;
                    _context.Update(user);
                    _context.SaveChanges();
                }

            }
            catch (Exception)
            {

                throw;
            }
        }

        private void cmbBuys_SelectionChangeCommitted(object sender, EventArgs e)
        {
            try
            {
                var user = _context.UserBuys.FirstOrDefault(x => x.User_Id.ToString() == cmbBuys.SelectedValue.ToString());
                if (user != null)
                {
                    cbNewBuy.Checked = user.NewBuy;
                    cbBuyReport.Checked = user.BuyReports;

                }
            }
            catch (Exception)
            {
                throw;
            }

        }
        private void button5_Click(object sender, EventArgs e)
        {
            try
            {
                var user = _context.UserBuys.FirstOrDefault(x => x.User_Id.ToString() == cmbBuys.SelectedValue.ToString());
                if (user != null)
                {
                    user.NewBuy = cbNewBuy.Checked;
                    user.BuyReports = cbBuyReport.Checked;
                    _context.Update(user);
                    _context.SaveChanges();
                }

            }
            catch (Exception)
            {

                throw;
            }
        }

        private void cmbSales_SelectionChangeCommitted(object sender, EventArgs e)
        {
            try
            {
                var user = _context.UserSales.FirstOrDefault(x => x.User_Id.ToString() == cmbSales.SelectedValue.ToString());
                if (user != null)
                {
                    cbNewBuy.Checked = user.NewSale;
                    cbBuyReport.Checked = user.SaleReports;
                    cbSaleProfit.Checked = user.SaleProfits;

                }
            }
            catch (Exception)
            {
                throw;
            }
        }

        private void button6_Click(object sender, EventArgs e)
        {
            try
            {
                var user = _context.UserSales.FirstOrDefault(x => x.User_Id.ToString() == cmbSales.SelectedValue.ToString());
                if (user != null)
                {
                    user.NewSale = cbNewSale.Checked;
                    user.SaleReports = cbSalesReport.Checked;
                    user.SaleProfits = cbSaleProfit.Checked;
                    _context.Update(user);
                    _context.SaveChanges();
                }

            }
            catch (Exception)
            {

                throw;
            }
        }

        private void button7_Click(object sender, EventArgs e)
        {
            try
            {
                var user = _context.UserCaissesAndBanks.FirstOrDefault(x => x.User_Id.ToString() == cmbCaisseAndBanks.SelectedValue.ToString());
                if (user != null)
                {
                    user.CaissesAndBanks = cbCaisseAndBanks.Checked;
                    user.DepositToCaisse = cbDepositToCaisse.Checked;
                    user.DepositToBank = cbDepositBanks.Checked;
                    user.WithdrawFromBank = cbWithdrawBank.Checked;
                    user.WithdrawFromCaisse = cbWithdrawCaisse.Checked;
                    user.TransfertBetweenCaisseAndBank = cbTransfertBankCaisse.Checked;
                    user.TransfertBetweenCaisse = cbTransfertCaisse.Checked;
                    _context.Update(user);
                    _context.SaveChanges();
                }
            }
            catch (Exception)
            {

                throw;
            }
        }

        private void cmbCaisseAndBanks_SelectionChangeCommitted(object sender, EventArgs e)
        {
            try
            {
                var user = _context.UserCaissesAndBanks.FirstOrDefault(x => x.User_Id.ToString() == cmbCaisseAndBanks.SelectedValue.ToString());
                if (user != null)
                {
                    cbCaisseAndBanks.Checked = user.CaissesAndBanks;
                    cbDepositToCaisse.Checked = user.DepositToCaisse;
                    cbDepositBanks.Checked = user.DepositToBank;
                    cbWithdrawBank.Checked = user.WithdrawFromBank;
                    cbWithdrawCaisse.Checked = user.WithdrawFromCaisse;
                    cbTransfertBankCaisse.Checked = user.TransfertBetweenCaisseAndBank;
                    cbTransfertCaisse.Checked = user.TransfertBetweenCaisse;
                }
            }
            catch (Exception)
            {
                throw;
            }
        }

        private void cmbDeservedAndTax_SelectionChangeCommitted(object sender, EventArgs e)
        {
            try
            {
                var user = _context.UserDeservedAndTaxs.FirstOrDefault(x => x.User_Id.ToString() == cmbDeservedAndTax.SelectedValue.ToString());
                if (user != null)
                {
                    cbDeserved.Checked = user.Deserved;
                    cbVouchers.Checked = user.Vouchers;

                }
            }
            catch (Exception)
            {
                throw;
            }
        }

        private void button8_Click(object sender, EventArgs e)
        {
            try
            {
                var user = _context.UserDeservedAndTaxs.FirstOrDefault(x => x.User_Id.ToString() == cmbDeservedAndTax.SelectedValue.ToString());
                if (user != null)
                {
                    user.Deserved = cbDeserved.Checked;
                    user.Vouchers = cbVouchers.Checked;
                    _context.Update(user);
                    _context.SaveChanges();
                }
            }
            catch (Exception)
            {

                throw;
            }
        }

        private void cmbRefund_SelectionChangeCommitted(object sender, EventArgs e)
        {
            try
            {
                var user = _context.UserRefunds.FirstOrDefault(x => x.User_Id.ToString() == cmbRefund.SelectedValue.ToString());
                if (user != null)
                {
                    cbRefund.Checked = user.RefundProduct;
                    cbRefundReport.Checked = user.RefundReport;
                }
            }
            catch (Exception)
            {
                throw;
            }
        }

        private void button9_Click(object sender, EventArgs e)
        {
            try
            {
                var user = _context.UserRefunds.FirstOrDefault(x => x.User_Id.ToString() == cmbRefund.SelectedValue.ToString());
                if (user != null)
                {
                    user.RefundProduct = cbRefund.Checked;
                    user.RefundReport = cbRefundReport.Checked;
                    _context.Update(user);
                    _context.SaveChanges();
                }
            }
            catch (Exception)
            {

                throw;
            }
        }

        private void cmbEmployee_SelectionChangeCommitted(object sender, EventArgs e)
        {
            try
            {
                var user = _context.UserEmployees.FirstOrDefault(x => x.User_Id.ToString() == cmbEmployee.SelectedValue.ToString());
                if (user != null)
                {
                    cbEmployeeBorrowItem.Checked = user.EmployeeBorrowItem;
                    cbEmployeeSalaries.Checked = user.EmployeeSalaries;
                    cbAllEmployees.Checked = user.AllEmployee;
                    cbAddEmployee.Checked = user.AddEmployee;
                    cbEmployeeSalaryReports.Checked = user.EmployeeSalariesReport;
                    cbborrowMonies.Checked = user.EmployeeBorrowMoney;
                    cbBorrowItemReport.Checked = user.EmployeeBorrowItemsReport;
                    cbBorrowMoneyReports.Checked = user.EmployeeBorrowMoneyReport;
                }
            }
            catch (Exception)
            {
                throw;
            }
        }

        private void button10_Click(object sender, EventArgs e)
        {
            try
            {
                var user = _context.UserEmployees.FirstOrDefault(x => x.User_Id.ToString() == cmbEmployee.SelectedValue.ToString());
                if (user != null)
                {
                    user.EmployeeBorrowItem = cbEmployeeBorrowItem.Checked;
                    user.EmployeeSalaries = cbEmployeeSalaries.Checked;
                    user.AllEmployee = cbAllEmployees.Checked;
                    user.AddEmployee = cbAddEmployee.Checked;
                    user.EmployeeSalariesReport = cbEmployeeSalaryReports.Checked;
                    user.EmployeeBorrowMoney = cbborrowMonies.Checked;
                    user.EmployeeBorrowItemsReport = cbBorrowItemReport.Checked;
                    user.EmployeeBorrowMoneyReport = cbBorrowMoneyReports.Checked;
                    _context.Update(user);
                    _context.SaveChanges();
                }
            }
            catch (Exception)
            {

                throw;
            }
        }
    }
}
