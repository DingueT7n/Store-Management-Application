using Microsoft.EntityFrameworkCore;
using Microsoft.IdentityModel.Tokens;
using Store.ApplicationUI.Code.Helper;
using Store.ApplicationUI.Gui.LoadingGui;
using Store.Core.Entities.Caisses;
using Store.Core.Entities.Users;
using Store.Infrastructure.Data;

namespace Store.ApplicationUI.Gui.GeneralSettingsGui.UserRolesGui
{
    public partial class UserRolesForm : Form
    {
        private readonly MainForm _main;
        private readonly ApplicationDbContext _context;

        public UserRolesForm(MainForm main, ApplicationDbContext context)
        {
            _main = main;
            _context = context;
            InitializeComponent();
            this.Owner = main;
            LoadData();

        }

        private void PopulateComboBox(ComboBox comboBox, IEnumerable<object> dataSource, string displayMember, string valueMember)
        {
            comboBox.DataSource = dataSource;
            comboBox.DisplayMember = displayMember;
            comboBox.ValueMember = valueMember;
        }

        public async Task SetCategoryToDgv()
        {
            try
            {
                var users = await _context.Users.ToListAsync();
                PopulateComboBox(cmbSuppliers, users, "UserName", "Id");
                PopulateComboBox(cmbUserGS, users, "UserName", "Id");
                PopulateComboBox(cmbUserPs, users, "UserName", "Id");
                PopulateComboBox(cmbUserCustomers, users, "UserName", "Id");
                PopulateComboBox(cmbBuys, users, "UserName", "Id");
                PopulateComboBox(cmbSales, users, "UserName", "Id");
                PopulateComboBox(cmbCaisseAndBanks, users, "UserName", "Id");
                PopulateComboBox(cmbDeservedAndTax, users, "UserName", "Id");
                PopulateComboBox(cmbRefund, users, "UserName", "Id");
                PopulateComboBox(cmbEmployee, users, "UserName", "Id");

                var caisses = await _context.Caisses.ToListAsync();
                PopulateComboBox(cmbCaisse, caisses, "CaisseName", "Id");

                Dgv.DataSource = users;
                lblEmptyData.Visible = dgvHelper.IsEmpty(Dgv);
            }
            catch (Exception ex)
            {
                ToasterHelper.ShowErrorHappened(ex.Message);
            }
        }
        public async void LoadData()
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
        async Task vider()
        {
            txtUserName.Text = string.Empty;
            txtPassowrd.Text = string.Empty;
            txtProfit.Text = "0";
            btnAdd.Enabled = true;

            btnEdit.Enabled = false;
            await RefreshDgv();
        }

        private void SetColumns()
        {
            //DgvProducts.Columns[0].HeaderCell.Value = "المعرف";
            Dgv.DataSource = new List<User>();
            Dgv.Columns[0].HeaderCell.Value = "اسم المستخدم";
            Dgv.Columns[1].HeaderCell.Value = "كلمة السر";
            Dgv.Columns[2].HeaderCell.Value = "نوع المستخدم";
            Dgv.Columns[3].HeaderCell.Value = "معرف الخزنة";
            Dgv.Columns[4].HeaderCell.Value = "نسبة الربح";
            Dgv.Columns[15].HeaderCell.Value = "معرف المستخدم";

            var columnsToHide = new[] { 5, 6, 7, 8, 9, 10, 11, 12, 13, 14 };
            foreach (var index in columnsToHide)
            {
                Dgv.Columns[index].Visible = false;
            }

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
        private async Task RefreshDgv()
        {

            await SetCategoryToDgv();
            txtUserName.Text = string.Empty;
            txtPassowrd.Text = string.Empty;
            txtProfit.Text = string.Empty;
        }

        private async void btnAdd_Click(object sender, EventArgs e)
        {
            ToasterHelper.PlayNotificationSound();
            if (txtUserName.Text.IsNullOrEmpty() || txtPassowrd.Text.IsNullOrEmpty())
            {
                MsgHelper.ShowRequiredFields();
                return;
            }

            using (var transaction = await _context.Database.BeginTransactionAsync())
            {
                try
                {
                    // Create new User
                    User user = new()
                    {
                        UserName = txtUserName.Text,
                        Password = txtPassowrd.Text,
                        UserProfit = _main.ConvertToFloat(txtProfit.Text),
                        Stock_Id = Convert.ToInt32(cmbCaisse.SelectedValue),
                        type = cmbType.Text
                    };
                    await _context.Users.AddAsync(user);
                    await _context.SaveChangesAsync(); // Save to generate UserId

                    // Add related entities based on User type
                    if (cmbType.Text == "مدير")
                    {
                        AddUserRelatedEntities(user, true);
                    }
                    else
                    {
                        AddUserRelatedEntities(user, false);
                    }

                    // Commit transaction
                    transaction.Commit();
                    Code.Helper.ToasterHelper.ShowAddToast();

                    // Refresh DataGridView
                    RefreshDgv();
                }
                catch (Exception ex)
                {
                    // Rollback transaction on error
                    transaction.Rollback();
                    MessageBox.Show(ex.Message);
                }
            }
        }
        private async void AddUserRelatedEntities(User user, bool isAdmin)
        {
            List<object> relatedEntities = new()
            {
                new UserBuy(isAdmin) { User_Id = user.Id },
                new UserCaisseAndBank(isAdmin) { User_Id = user.Id },
                new UserCustomer(isAdmin) { User_Id = user.Id },
                new UserDeservedAndTax(isAdmin) { User_Id = user.Id },
                new UserEmployee(isAdmin) { User_Id = user.Id },
                new UserProductAndStore(isAdmin) { User_Id = user.Id },
                new UserRefund(isAdmin) { User_Id = user.Id },
                new UserSale(isAdmin) { User_Id = user.Id },
                new UserSetting(isAdmin) { User_Id = user.Id },
                new UserSupplier(isAdmin) { User_Id = user.Id }
            };
            user.UserBuy = (UserBuy)relatedEntities[0];
            user.UserCaisseAndBank = (UserCaisseAndBank)relatedEntities[1];
            user.UserCustomer = (UserCustomer)relatedEntities[2];
            user.UserDeservedAndTax = (UserDeservedAndTax)relatedEntities[3];
            user.UserEmployee = (UserEmployee)relatedEntities[4];
            user.UserProductAndStore = (UserProductAndStore)relatedEntities[5];
            user.UserRefund = (UserRefund)relatedEntities[6];
            user.UserSale = (UserSale)relatedEntities[7];
            user.UserSetting = (UserSetting)relatedEntities[8];
            user.UserSupplier = (UserSupplier)relatedEntities[9];
            await _context.AddRangeAsync(relatedEntities);
            await _context.SaveChangesAsync();
        }
        private async void btnEdit_Click(object sender, EventArgs e)
        {
            ToasterHelper.PlayNotificationSound();
            if (MsgHelper.ShowEditDialog())
            {
                if (Dgv.SelectedRows.Count > 0)
                {
                    User user = await _context.Users.FirstOrDefaultAsync(x => x.Id == Convert.ToInt32(Dgv.CurrentRow.Cells[15].Value.ToString())
                    ); if (user != null)
                    {
                        user.UserName = txtUserName.Text;
                        user.Password = txtPassowrd.Text;
                        user.UserProfit = _main.ConvertToFloat(txtProfit.Text);
                        user.Stock_Id = Convert.ToInt32(cmbCaisse.SelectedValue);
                        user.type = cmbType.Text;
                        _context.Update(user);
                        await _context.SaveChangesAsync();
                        Code.Helper.ToasterHelper.ShowEditToast();

                    }
                }
                await vider();
            }
        }
        private async void btnDelete_Click(object sender, EventArgs e)
        {
            ToasterHelper.PlayNotificationSound();
            if (MsgHelper.ShowDeleteDialog())
            {
                if (Dgv.SelectedRows.Count > 0)
                {
                    var user = await _context.Users
               .Include(u => u.UserBuy)
              .Include(u => u.UserCaisseAndBank)
              .Include(u => u.UserCustomer)
              .Include(u => u.UserDeservedAndTax)
              .Include(u => u.UserEmployee)
              .Include(u => u.UserProductAndStore)
              .Include(u => u.UserRefund)
              .Include(u => u.UserSale)
              .Include(u => u.UserSetting)
              .Include(u => u.UserSupplier).FirstOrDefaultAsync(x => x.Id == Convert.ToInt32(Dgv.CurrentRow.Cells[15].Value.ToString()));
                    if (user is not null)
                    {
                        _context.Remove(user.UserBuy);
                        _context.Remove(user.UserCaisseAndBank);
                        _context.Remove(user.UserCustomer);
                        _context.Remove(user.UserDeservedAndTax);
                        _context.Remove(user.UserEmployee);
                        _context.Remove(user.UserProductAndStore);
                        _context.Remove(user.UserRefund);
                        _context.Remove(user.UserSale);
                        _context.Remove(user.UserSetting);
                        _context.Remove(user.UserSupplier);
                        await _context.SaveChangesAsync();
                        _context.Remove(user);
                        await _context.SaveChangesAsync();

                        Code.Helper.ToasterHelper.ShowDeletedToast();

                    }
                }
                await RefreshDgv();
                if (_context.Users.Count() < 1)
                {
                    int caisse = Convert.ToInt32(cmbCaisse.SelectedValue);
                    if (_context.Caisses.Count() < 1)
                    {
                        Caisse Caisse = new()
                        {
                            CaisseName = "الصندوق الأول",

                        };
                        await _context.AddAsync(Caisse);
                        await _context.SaveChangesAsync();
                        caisse = Caisse.Id;
                    }
                    // Create new User
                    User user = new()
                    {
                        UserName = "ALG-D",
                        Password = "2025",
                        UserProfit = _main.ConvertToFloat(txtProfit.Text),
                        Stock_Id = caisse,
                        type = "مدير"
                    };
                    await _context.Users.AddAsync(user);
                    await _context.SaveChangesAsync(); // Save to generate UserId

                    // Add related entities based on User type

                    AddUserRelatedEntities(user, true);


                }
            }
        }


        private async void btnSearch_Click(object sender, EventArgs e)
        {
            txtSearch.Text = txtSearch.Text.Replace("\r\n", "");
            ToasterHelper.PlayNotificationSound();
            Dgv.DataSource = await _context.Users.Where(x => x.Id.ToString() == txtSearch.Text ||
           x.UserName == (txtSearch.Text)).ToListAsync();
            lblEmptyData.Visible = dgvHelper.IsEmpty(Dgv);
            txtSearch.Text = string.Empty;
        }

        private async void btnRefresh_Click(object sender, EventArgs e)
        {
            ToasterHelper.PlayNotificationSound();
            btnAdd.Enabled = true;
            await vider();
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
                    lblidCaisse.Text = Dgv.CurrentRow.Cells[15].Value.ToString();
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

        private async void cmbUserGS_SelectionChangeCommitted(object sender, EventArgs e)
        {
            try
            {
                var user = await _context.UserSettings.FirstOrDefaultAsync(x => x.User_Id.ToString() == cmbUserGS.SelectedValue.ToString());
                if (user != null)
                {
                    cbApplicationSettings.Checked = user.ApplicationSettings;
                    cbPermessions.Checked = user.UserPermession;
                    cbComptoire.Checked = user.Pos;
                    cbStatistics.Checked = user.Statistics;
                    cbProductDiscount.Checked = user.ProductDiscounts;
                    cbBackup.Checked = user.BackUp;
                    cbRestore.Checked = user.Restore;
                }
            }
            catch (Exception)
            {

                throw;
            }
        }

        private async void button1_Click(object sender, EventArgs e)
        {
            try
            {
                ToasterHelper.PlayNotificationSound();
                var user = await _context.UserSettings.FirstOrDefaultAsync(x => x.User_Id.ToString() == cmbUserGS.SelectedValue.ToString());
                if (user != null)
                {
                    user.ApplicationSettings = cbApplicationSettings.Checked;
                    user.UserPermession = cbPermessions.Checked;
                    user.Pos = cbComptoire.Checked;
                    user.Statistics = cbStatistics.Checked;
                    user.ProductDiscounts = cbProductDiscount.Checked;
                    user.BackUp = cbBackup.Checked;
                    user.Restore = cbRestore.Checked;
                    _context.Update(user);
                    await _context.SaveChangesAsync();
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

        private async void cmbUserPs_SelectionChangeCommitted(object sender, EventArgs e)
        {
            try
            {
                var user = await _context.UserProductsAndStores.FirstOrDefaultAsync(x => x.User_Id.ToString() == cmbUserPs.SelectedValue.ToString());
                if (user != null)
                {
                    cbAllProducts.Checked = user.AllProducts;
                    cbAddProduct.Checked = user.AddProduct;
                    cbCategories.Checked = user.AllCategories;
                    cbStoreInventory.Checked = user.StoreInventory;
                    cbProductOutStore.Checked = user.ProductOutStoreReport;
                    cbTransfertReport.Checked = user.TransfertReport;
                    cbAllStores.Checked = user.allStores;
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

        private async void button2_Click(object sender, EventArgs e)
        {
            try
            {
                ToasterHelper.PlayNotificationSound();
                var user = await _context.UserProductsAndStores.FirstOrDefaultAsync(x => x.User_Id.ToString() == cmbUserPs.SelectedValue.ToString());
                if (user != null)
                {
                    user.AllProducts = cbAllProducts.Checked;
                    user.AddProduct = cbAddProduct.Checked;
                    user.AllCategories = cbCategories.Checked;
                    user.StoreInventory = cbStoreInventory.Checked;
                    user.ProductOutStoreReport = cbProductOutStore.Checked;
                    user.TransfertReport = cbTransfertReport.Checked;
                    user.allStores = cbAllStores.Checked;
                    _context.Update(user);
                    await _context.SaveChangesAsync();
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

        private async void cmbUserCustomers_SelectionChangeCommitted(object sender, EventArgs e)
        {
            try
            {
                var user = await _context.UserCustomers.FirstOrDefaultAsync(x => x.User_Id.ToString() == cmbUserCustomers.SelectedValue.ToString());
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

        private async void button3_Click(object sender, EventArgs e)
        {
            try
            {
                ToasterHelper.PlayNotificationSound();
                var user = await _context.UserCustomers.FirstOrDefaultAsync(x => x.User_Id.ToString() == cmbUserCustomers.SelectedValue.ToString());
                if (user != null)
                {
                    user.AllCustomers = cbAllCustomer.Checked;
                    user.AddCustomer = cbAddCustomer.Checked;
                    user.CustomerAccount = cbCustomerAccount.Checked;
                    user.CustomerReport = cbCustomerReport.Checked;
                    _context.Update(user);
                    await _context.SaveChangesAsync();
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

        private async void cmbSuppliers_SelectionChangeCommitted(object sender, EventArgs e)
        {
            try
            {
                var user = await _context.UserSuppliers.FirstOrDefaultAsync(x => x.User_Id.ToString() == cmbSuppliers.SelectedValue.ToString());
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

        private async void button4_Click(object sender, EventArgs e)
        {
            try
            {
                ToasterHelper.PlayNotificationSound();
                var user = await _context.UserSuppliers.FirstOrDefaultAsync(x => x.User_Id.ToString() == cmbSuppliers.SelectedValue.ToString());
                if (user != null)
                {
                    user.AllSuppliers = cbAllSupliers.Checked;
                    user.AddSuppliers = cbAddSupplier.Checked;
                    user.SuppliersAccount = cbSupplierAccounts.Checked;
                    user.SuppliersReport = cbSupplierReports.Checked;
                    _context.Update(user);
                    await _context.SaveChangesAsync();
                }

            }
            catch (Exception)
            {

                throw;
            }
        }

        private async void cmbBuys_SelectionChangeCommitted(object sender, EventArgs e)
        {
            try
            {
                var user = await _context.UserBuys.FirstOrDefaultAsync(x => x.User_Id.ToString() == cmbBuys.SelectedValue.ToString());
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
        private async void button5_Click(object sender, EventArgs e)
        {
            try
            {
                ToasterHelper.PlayNotificationSound();
                var user = await _context.UserBuys.FirstOrDefaultAsync(x => x.User_Id.ToString() == cmbBuys.SelectedValue.ToString());
                if (user != null)
                {
                    user.NewBuy = cbNewBuy.Checked;
                    user.BuyReports = cbBuyReport.Checked;
                    _context.Update(user);
                    await _context.SaveChangesAsync();
                }

            }
            catch (Exception)
            {

                throw;
            }
        }

        private async void cmbSales_SelectionChangeCommitted(object sender, EventArgs e)
        {
            try
            {
                var user = await _context.UserSales.FirstOrDefaultAsync(x => x.User_Id.ToString() == cmbSales.SelectedValue.ToString());
                if (user != null)
                {
                    cbNewSale.Checked = user.NewSale;
                    cbSalesReport.Checked = user.SaleReports;
                    cbSaleProfit.Checked = user.SaleProfits;
                }
            }
            catch (Exception)
            {
                throw;
            }
        }

        private async void button6_Click(object sender, EventArgs e)
        {
            try
            {
                ToasterHelper.PlayNotificationSound();
                var user = await _context.UserSales.FirstOrDefaultAsync(x => x.User_Id.ToString() == cmbSales.SelectedValue.ToString());
                if (user != null)
                {
                    user.NewSale = cbNewSale.Checked;
                    user.SaleReports = cbSalesReport.Checked;
                    user.SaleProfits = cbSaleProfit.Checked;
                    _context.Update(user);
                    await _context.SaveChangesAsync();
                }

            }
            catch (Exception)
            {

                throw;
            }
        }

        private async void button7_Click(object sender, EventArgs e)
        {
            try
            {
                ToasterHelper.PlayNotificationSound();
                var user = await _context.UserCaissesAndBanks.FirstOrDefaultAsync(x => x.User_Id.ToString() == cmbCaisseAndBanks.SelectedValue.ToString());
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
                    await _context.SaveChangesAsync();
                }
            }
            catch (Exception)
            {

                throw;
            }
        }

        private async void cmbCaisseAndBanks_SelectionChangeCommitted(object sender, EventArgs e)
        {
            try
            {
                var user = await _context.UserCaissesAndBanks.FirstOrDefaultAsync(x => x.User_Id.ToString() == cmbCaisseAndBanks.SelectedValue.ToString());
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

        private async void cmbDeservedAndTax_SelectionChangeCommitted(object sender, EventArgs e)
        {
            try
            {
                var user = await _context.UserDeservedAndTaxs.FirstOrDefaultAsync(x => x.User_Id.ToString() == cmbDeservedAndTax.SelectedValue.ToString());
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

        private async void button8_Click(object sender, EventArgs e)
        {
            try
            {
                ToasterHelper.PlayNotificationSound();
                var user = await _context.UserDeservedAndTaxs.FirstOrDefaultAsync(x => x.User_Id.ToString() == cmbDeservedAndTax.SelectedValue.ToString());
                if (user != null)
                {
                    user.Deserved = cbDeserved.Checked;
                    user.Vouchers = cbVouchers.Checked;
                    _context.Update(user);
                    await _context.SaveChangesAsync();
                }
            }
            catch (Exception)
            {

                throw;
            }
        }

        private async void cmbRefund_SelectionChangeCommitted(object sender, EventArgs e)
        {
            try
            {
                var user = await _context.UserRefunds.FirstOrDefaultAsync(x => x.User_Id.ToString() == cmbRefund.SelectedValue.ToString());
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

        private async void button9_Click(object sender, EventArgs e)
        {
            try
            {
                ToasterHelper.PlayNotificationSound();
                var user = await _context.UserRefunds.FirstOrDefaultAsync(x => x.User_Id.ToString() == cmbRefund.SelectedValue.ToString());
                if (user != null)
                {
                    user.RefundProduct = cbRefund.Checked;
                    user.RefundReport = cbRefundReport.Checked;
                    _context.Update(user);
                    await _context.SaveChangesAsync();
                }
            }
            catch (Exception)
            {

                throw;
            }
        }

        private async void cmbEmployee_SelectionChangeCommitted(object sender, EventArgs e)
        {
            try
            {
                var user = await _context.UserEmployees.FirstOrDefaultAsync(x => x.User_Id.ToString() == cmbEmployee.SelectedValue.ToString());
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

        private async void button10_Click(object sender, EventArgs e)
        {
            try
            {
                ToasterHelper.PlayNotificationSound();
                var user = await _context.UserEmployees.FirstOrDefaultAsync(x => x.User_Id.ToString() == cmbEmployee.SelectedValue.ToString());
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
                    await _context.SaveChangesAsync();
                }
            }
            catch (Exception)
            {

                throw;
            }
        }

        private void txtProfit_KeyPress(object sender, KeyPressEventArgs e)
        {
            string currentText = (sender as TextBox)?.Text ?? string.Empty;


            char decimalSeparator = Properties.Settings.Default.DecimalSEP[0];


            if (!char.IsDigit(e.KeyChar) && e.KeyChar != decimalSeparator && e.KeyChar != (char)8)
            {
                e.Handled = true;
            }

            else if (e.KeyChar == decimalSeparator && currentText.Contains(decimalSeparator))
            {
                e.Handled = true;
            }
        }
    }
}
