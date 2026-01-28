using System.ComponentModel;
using System.Globalization;
using System.IO;
using Microsoft.Data.SqlClient;
using Microsoft.EntityFrameworkCore;
using Microsoft.SqlServer.Management.Smo;
using Store.ApplicationUI.Code.GUIHelper;
using Store.ApplicationUI.Code.Helper;
using Store.ApplicationUI.Code.Models;
using Store.ApplicationUI.Code.System;
using Store.ApplicationUI.Gui.BuysGui;
using Store.ApplicationUI.Gui.BuysGui.BuysReportsGui;
using Store.ApplicationUI.Gui.CaisseAndBankGui;
using Store.ApplicationUI.Gui.CaisseAndBankGui.DepositToBankReportGui;
using Store.ApplicationUI.Gui.CaisseAndBankGui.DepositToCaisseReportGui;
using Store.ApplicationUI.Gui.CaisseAndBankGui.FondCaisseGui;
using Store.ApplicationUI.Gui.CaisseAndBankGui.TransfertBetweenCaisseAndBankReportGui;
using Store.ApplicationUI.Gui.CaisseAndBankGui.TransfertBetweenCaisseReportGui;
using Store.ApplicationUI.Gui.CaisseAndBankGui.WithdrawFromBankReportGui;
using Store.ApplicationUI.Gui.CaisseAndBankGui.WithdrawFromCaisseReportsGui;
using Store.ApplicationUI.Gui.CustomersGui;
using Store.ApplicationUI.Gui.CustomersGui.CustomerAccountGui;
using Store.ApplicationUI.Gui.CustomersGui.CustomerReportsGui;
using Store.ApplicationUI.Gui.DeservedGui;
using Store.ApplicationUI.Gui.DeservedGui.VouchersGui;
using Store.ApplicationUI.Gui.DeservedGui.VouchersReportGui;
using Store.ApplicationUI.Gui.EmployeesGui;
using Store.ApplicationUI.Gui.EmployeesGui.EmployeeBorrowItemsGui;
using Store.ApplicationUI.Gui.EmployeesGui.EmployeeBorrowMoneyGui;
using Store.ApplicationUI.Gui.EmployeesGui.EmployeeBorrowMoneyReport;
using Store.ApplicationUI.Gui.EmployeesGui.EmployeeBorrowsItemReport;
using Store.ApplicationUI.Gui.EmployeesGui.EmployeeSalaryGui;
using Store.ApplicationUI.Gui.EmployeesGui.EmployeeSalaryReportGui;
using Store.ApplicationUI.Gui.GeneralSettingsGui;
using Store.ApplicationUI.Gui.GeneralSettingsGui.UserRolesGui;
using Store.ApplicationUI.Gui.HomeGui;
using Store.ApplicationUI.Gui.ProductsGui;
using Store.ApplicationUI.Gui.ProductsGui.Category;
using Store.ApplicationUI.Gui.ProductsGui.ProductDiscountGui;
using Store.ApplicationUI.Gui.ProductsGui.StoreGui;
using Store.ApplicationUI.Gui.ProductsGui.StoreGui.StoreDamagedProductReportGui;
using Store.ApplicationUI.Gui.ProductsGui.StoreGui.StoreInventoryGui;
using Store.ApplicationUI.Gui.ProductsGui.StoreGui.StoreTrensfertReportGui;
using Store.ApplicationUI.Gui.ReturnsGui;
using Store.ApplicationUI.Gui.ReturnsGui.ReturnsReportsGui;
using Store.ApplicationUI.Gui.SalesGui;
using Store.ApplicationUI.Gui.SalesGui.PosGui;
using Store.ApplicationUI.Gui.SalesGui.ProformaGui;
using Store.ApplicationUI.Gui.SalesGui.SaleProfitGui;
using Store.ApplicationUI.Gui.SalesGui.SalesReportsGui;
using Store.ApplicationUI.Gui.SupplierGui;
using Store.ApplicationUI.Gui.SupplierGui.SupplierAccountGui;
using Store.ApplicationUI.Gui.SupplierGui.SupplierReportsGui;
using Store.Infrastructure.Data;



namespace Store.ApplicationUI
{
    public partial class MainForm : Form
    {
        private readonly PageHelper pageHelper;

        [DesignerSerializationVisibility(DesignerSerializationVisibility.Hidden)]
        public readonly ApplicationDbContext Context;
        private readonly ControlManager _controlManager;

        public MainForm(ApplicationDbContext dbContext, ControlManager controlManager)
        {
            InitializeComponent();
            KeyPreview = true;
            try
            {
                _controlManager = controlManager;


                Code.Helper.ConStringHelper.SetConString();

                pageHelper = new(this);



                Context = dbContext;
                SetScreenState(Properties.Settings.Default.IsMaxScreen);

                isPanelNull = true;
                //btnStatistics.Enabled = LocalUser.User.UserName

            }
            catch (Exception ex)
            {

                ToasterHelper.ShowErrorHappened(ex.Message);

            }

        }
        public bool DirectLoginUserCredential()
        {
            if (!Properties.Settings.Default.DirectLogin)
                return false;
            Code.Helper.ConStringHelper.SetConString();

            if (!Context.Database.CanConnect())
            {
                ToasterHelper.ShowConnectionIsNotEstablished();
                return false;
            }
            if (Context.Users.AsNoTracking().Count() > 0)
            {
                var user = Context.Users
                .Include(u => u.UserBuy)
                .Include(u => u.UserCaisseAndBank)
                .Include(u => u.UserCustomer)
                .Include(u => u.UserDeservedAndTax)
                .Include(u => u.UserEmployee)
                .Include(u => u.UserProductAndStore)
                .Include(u => u.UserRefund)
                .Include(u => u.UserSale)
                .Include(u => u.UserSetting)
                .Include(u => u.UserSupplier)
                .FirstOrDefault(u => u.UserName == Properties.Settings.Default.UserName
                        && u.Password == Properties.Settings.Default.Password);
                LocalUser.User = user;
                return user != null;
            }
            return false;

        }
        public void ApplyAcces()
        {

            if (LocalUser.User is not null && Code.Helper.VerificationSettingsHelper.ValidateActivationKey())
            {
                btnAllProducts.Enabled = LocalUser.User.UserProductAndStore.AllProducts;
                btnAllStores.Enabled = LocalUser.User.UserProductAndStore.allStores;
                btnAddProduct.Enabled = LocalUser.User.UserProductAndStore.AddProduct && !Properties.Settings.Default.TrialVersion;
                btnAllCategories.Enabled = LocalUser.User.UserProductAndStore.AllCategories;
                btnStoreInventory.Enabled = LocalUser.User.UserProductAndStore.StoreInventory;
                btnProductTransfertReport.Enabled = LocalUser.User.UserProductAndStore.TransfertReport;
                btnProductOutStoreReport.Enabled = LocalUser.User.UserProductAndStore.ProductOutStoreReport;


                btnAllCustomers.Enabled = LocalUser.User.UserCustomer.AllCustomers;
                btnAddCustomer.Enabled = LocalUser.User.UserCustomer.AddCustomer && !Properties.Settings.Default.TrialVersion;
                btnCustomerAccount.Enabled = LocalUser.User.UserCustomer.CustomerAccount;
                btnCustomerReport.Enabled = LocalUser.User.UserCustomer.CustomerReport;


                btnAllSuppliers.Enabled = LocalUser.User.UserSupplier.AllSuppliers;
                btnAddSupplier.Enabled = LocalUser.User.UserSupplier.AddSuppliers && !Properties.Settings.Default.TrialVersion;
                btnSupplierAccount.Enabled = LocalUser.User.UserSupplier.SuppliersAccount;
                btnSupplierReports.Enabled = LocalUser.User.UserSupplier.SuppliersReport;


                btnNewBuy.Enabled = LocalUser.User.UserBuy.NewBuy;
                btnBuysReports.Enabled = LocalUser.User.UserBuy.BuyReports && !Properties.Settings.Default.TrialVersion;


                btnNewSale.Enabled = LocalUser.User.UserSale.NewSale;
                btnSalesReport.Enabled = LocalUser.User.UserSale.SaleReports;
                btnProfitReport.Enabled = LocalUser.User.UserSale.SaleProfits;

                btnCaisseAndBank.Enabled = LocalUser.User.UserCaisseAndBank.CaissesAndBanks;
                btnDepositToCaisseReport.Enabled = LocalUser.User.UserCaisseAndBank.DepositToCaisse;
                btnDepositToBankReport.Enabled = LocalUser.User.UserCaisseAndBank.DepositToBank;
                btnWithdrawToCaisseReport.Enabled = LocalUser.User.UserCaisseAndBank.WithdrawFromCaisse;
                btnWithdrawBankReport.Enabled = LocalUser.User.UserCaisseAndBank.WithdrawFromBank;
                btnTransfertCaisse.Enabled = LocalUser.User.UserCaisseAndBank.TransfertBetweenCaisse;
                btnTreansfertBankCaisse.Enabled = LocalUser.User.UserCaisseAndBank.TransfertBetweenCaisseAndBank;

                btnAllDeserved.Enabled = LocalUser.User.UserDeservedAndTax.Deserved;
                btnVouchers.Enabled = LocalUser.User.UserDeservedAndTax.Vouchers;
                btnVouchersReport.Enabled = LocalUser.User.UserDeservedAndTax.Vouchers;


                btnAddRefund.Enabled = LocalUser.User.UserRefund.RefundProduct;
                btnRefundReport.Enabled = LocalUser.User.UserRefund.RefundReport;
                btnAllEmployees.Enabled = LocalUser.User.UserEmployee.AllEmployee;
                btnNewEmployee.Enabled = LocalUser.User.UserEmployee.AddEmployee;
                btnEmployeeBorrowItems.Enabled = LocalUser.User.UserEmployee.EmployeeBorrowItem;
                btnBorrowMonies.Enabled = LocalUser.User.UserEmployee.EmployeeBorrowMoney;
                btnSalaries.Enabled = LocalUser.User.UserEmployee.EmployeeSalaries;
                btnBorrowItemsReport.Enabled = LocalUser.User.UserEmployee.EmployeeBorrowItemsReport;
                btnBorrowMoniesReport.Enabled = LocalUser.User.UserEmployee.EmployeeBorrowMoneyReport;
                btnSalariesReport.Enabled = LocalUser.User.UserEmployee.EmployeeSalariesReport;

                btnApplicationSettings.Enabled = LocalUser.User.UserSetting.ApplicationSettings;
                btnUsersRoles.Enabled = LocalUser.User.UserSetting.UserPermession && !Properties.Settings.Default.TrialVersion;
                btnProductDiscount.Enabled = LocalUser.User.UserSetting.ProductDiscounts;
                btnComptoire.Enabled = LocalUser.User.UserSetting.Pos;
                btnStatistics.Enabled = LocalUser.User.UserSetting.Statistics;
                btnBackUp.Enabled = LocalUser.User.UserSetting.BackUp && !Properties.Settings.Default.TrialVersion;
                btnRestore.Enabled = LocalUser.User.UserSetting.Restore && !Properties.Settings.Default.TrialVersion;
                btnBackUp.Enabled = LocalUser.User.UserSetting.BackUp && !Properties.Settings.Default.TrialVersion;
                btnRestore.Enabled = LocalUser.User.UserSetting.Restore && !Properties.Settings.Default.TrialVersion;
            }
            else
            {  // 🔴 Disable ALL buttons if user is null or activation invalid
                btnAllProducts.Enabled = false;
                btnAllStores.Enabled = false;
                btnAddProduct.Enabled = false;
                btnAllCategories.Enabled = false;
                btnStoreInventory.Enabled = false;
                btnProductTransfertReport.Enabled = false;
                btnProductOutStoreReport.Enabled = false;

                btnAllCustomers.Enabled = false;
                btnAddCustomer.Enabled = false;
                btnCustomerAccount.Enabled = false;
                btnCustomerReport.Enabled = false;

                btnAllSuppliers.Enabled = false;
                btnAddSupplier.Enabled = false;
                btnSupplierAccount.Enabled = false;
                btnSupplierReports.Enabled = false;

                btnNewBuy.Enabled = false;
                btnBuysReports.Enabled = false;

                btnNewSale.Enabled = false;
                btnSalesReport.Enabled = false;
                btnProfitReport.Enabled = false;

                btnCaisseAndBank.Enabled = false;
                btnDepositToCaisseReport.Enabled = false;
                btnDepositToBankReport.Enabled = false;
                btnWithdrawToCaisseReport.Enabled = false;
                btnWithdrawBankReport.Enabled = false;
                btnTransfertCaisse.Enabled = false;
                btnTreansfertBankCaisse.Enabled = false;

                btnAllDeserved.Enabled = false;
                btnVouchers.Enabled = false;
                btnVouchersReport.Enabled = false;

                btnAddRefund.Enabled = false;
                btnRefundReport.Enabled = false;

                btnAllEmployees.Enabled = false;
                btnNewEmployee.Enabled = false;
                btnEmployeeBorrowItems.Enabled = false;
                btnBorrowMonies.Enabled = false;
                btnSalaries.Enabled = false;
                btnBorrowItemsReport.Enabled = false;
                btnBorrowMoniesReport.Enabled = false;
                btnSalariesReport.Enabled = false;

                btnApplicationSettings.Enabled = false;
                btnUsersRoles.Enabled = false;
                btnProductDiscount.Enabled = false;
                btnComptoire.Enabled = false;
                btnStatistics.Enabled = false;
                btnBackUp.Enabled = false;
                btnRestore.Enabled = false;
            }
        }
        private void SetScreenState(bool isMax)
        {
            if (isMax)
            {
                WindowState = FormWindowState.Maximized;
            }
            else
            {
                WindowState = FormWindowState.Normal;
            }

        }
        private int panelHeightIncrement = 5;
        FlowLayoutPanel generalFlowLayout;

        public bool isPanelOpen()
        {

            return isPanelNull;
        }
        public void CloseSubPanels()
        {
            animationTimer.Interval = 10; // 10 milliseconds (100 FPS)
            ToasterHelper.PlayNotificationSound();
            if (isPanelAnimating)
                return;

            if (generalFlowLayout is null) return;
            if (generalFlowLayout.Height == generalFlowLayout.MaximumSize.Height)
            {
                isPanelCollapsing = true;
                isPanelAnimating = true;
                animationTimer.Start();
            }

        }


        public void ShowSubPanel(FlowLayoutPanel flowLayoutPanel)
        {

            if (isPanelAnimating)
                return;
            generalFlowLayout = flowLayoutPanel;

            if (generalFlowLayout.Visible == true)
            {
                CloseSubPanels();
                return;
            }
            generalFlowLayout.Height = 0;

            if (generalFlowLayout.Height == 0)
            {
                isPanelExpanding = true;
                isPanelAnimating = true;
                generalFlowLayout.Show();
                animationTimer.Start();
            }


        }

        private bool isPanelExpanding = false;
        private bool isPanelCollapsing = false;
        private bool isPanelAnimating = false;
        private bool isPanelNull;

        private void MainForm_FormClosing(object sender, FormClosingEventArgs e)
        {
            ToasterHelper.PlayNotificationSound();

            Properties.Settings.Default.IsMaxScreen = this.WindowState == FormWindowState.Maximized;
            Properties.Settings.Default.Save();
            //  Application.Exit();
        }

        private async void btnHomeSummary_Click(object sender, EventArgs e)
        {

            pageHelper.SetNewPage(await _controlManager.GetAsync<HomeUserControl>());

        }

        private void BtnProducts_Click(object sender, EventArgs e)
        {
            //pageHelper.SetNewPage(Gui.ProductsGui.ProductsUserControl.Instance(this));
            CloseSubPanels();
            ShowSubPanel(ProductsflowLayoutPanel);
        }
        public void SetBytilt(UserControl userControl)
        {
            pageHelper.SetNewPage(userControl);
        }
        private async void button1_Click(object sender, EventArgs e)
        {
            pageHelper.SetNewPage(await _controlManager.GetAsync<ProductsUserControl>());

        }

        private void animationTimer_Tick(object sender, EventArgs e)
        {

            if (!isPanelAnimating)
                return;

            if (isPanelExpanding)
            {
                if (generalFlowLayout.Height < generalFlowLayout.MaximumSize.Height)
                {
                    generalFlowLayout.Height += panelHeightIncrement;
                }
                else
                {
                    generalFlowLayout.Height = generalFlowLayout.MaximumSize.Height;
                    isPanelExpanding = false;
                    isPanelAnimating = false;
                    animationTimer.Stop();
                }
            }

            if (isPanelCollapsing)
            {
                if (generalFlowLayout.Height > 0)
                {
                    generalFlowLayout.Height -= panelHeightIncrement;
                }
                else
                {
                    generalFlowLayout.Height = 0;
                    isPanelCollapsing = false;
                    isPanelAnimating = false;
                    generalFlowLayout.Hide();
                    animationTimer.Stop();

                }
            }

        }

        private async void button2_Click(object sender, EventArgs e)
        {

            AddProductForm addProductForm = await _controlManager.GetFAsync<AddProductForm>();
            addProductForm.ShowDialog();
            CloseSubPanels();
        }

        private async void button3_Click(object sender, EventArgs e)
        {
            ToasterHelper.PlayNotificationSound();
            AddCategoryForm addCategoryForm = await _controlManager.GetFAsync<AddCategoryForm>();
            addCategoryForm.ShowDialog();
            CloseSubPanels();

        }

        private void btnCustomers_Click(object sender, EventArgs e)
        {
            CloseSubPanels();

            ShowSubPanel(CustomersflowLayoutPaneel);
        }

        private async void button2_Click_1(object sender, EventArgs e)
        {

            pageHelper.SetNewPage(await _controlManager.GetAsync<CustomersUserControl>());
        }

        private async void button3_Click_1(object sender, EventArgs e)
        {
            AddCustomerForm form = await _controlManager.GetFAsync<AddCustomerForm>();

            form.ShowDialog();
            CloseSubPanels();
        }

        private async void button4_Click(object sender, EventArgs e)
        {
            pageHelper.SetNewPage(await _controlManager.GetAsync<CustomerAccountUserControl>());

        }

        private async void button1_Click_1(object sender, EventArgs e)
        {
            pageHelper.SetNewPage(await _controlManager.GetAsync<CustomerReportsUserControl>());

        }

        private void btnSupplierPanel_Click(object sender, EventArgs e)
        {
            CloseSubPanels();

            ShowSubPanel(SuppliersflowLayoutPanel);
        }

        private async void btnAddSupplier_Click(object sender, EventArgs e)
        {
            AddSupplierForm form = await _controlManager.GetFAsync<AddSupplierForm>();

            form.ShowDialog();
            CloseSubPanels();
        }

        private async void btnAllSuppliers_Click(object sender, EventArgs e)
        {
            pageHelper.SetNewPage(await _controlManager.GetAsync<SuppliersUserControl>());
        }

        private async void btnSupplierAccount_Click(object sender, EventArgs e)
        {
            pageHelper.SetNewPage(await _controlManager.GetAsync<SupplierAccountUserControl>());
        }

        private async void btnSupplierReports_Click(object sender, EventArgs e)
        {
            pageHelper.SetNewPage(await _controlManager.GetAsync<SupplierReportsUserControl>());
        }

        private async void button5_Click(object sender, EventArgs e)
        {
            ToasterHelper.PlayNotificationSound();
            var form = await _controlManager.GetFAsync<AddStoreForm>();
            form.ShowDialog();
            CloseSubPanels();


        }
        public decimal ConvertToFloat(string? value)
        {
            //decimal quantity;
            //if (float.TryParse(value, out quantity))
            //{
            //    return quantity;
            //}
            return Convert.ToDecimal(value, CultureInfo.InvariantCulture);
        }

        private void btnBuysPanel_Click(object sender, EventArgs e)
        {
            CloseSubPanels();

            ShowSubPanel(BuysflowLayoutPanel);
        }

        private async void btnNewBuy_Click(object sender, EventArgs e)
        {

            if (Code.Helper.VerificationSettingsHelper.IsAllSettingsAreApplied(Context))
                pageHelper.SetNewPage(await _controlManager.GetAsync<BuysUserControl>());

        }

        private void btnSalesPanel_Click(object sender, EventArgs e)
        {
            CloseSubPanels();

            ShowSubPanel(SalesflowLayoutPanel);
        }

        private async void button7_Click(object sender, EventArgs e)
        {

            if (Code.Helper.VerificationSettingsHelper.IsAllSettingsAreApplied(Context))

                pageHelper.SetNewPage(await _controlManager.GetAsync<SalesUserControl>());

        }

        private async void btnBuysReports_Click(object sender, EventArgs e)
        {
            pageHelper.SetNewPage(await _controlManager.GetAsync<BuysReportsUserControl>());
        }

        private async void btnComptoire_Click(object sender, EventArgs e)
        {
            ToasterHelper.PlayNotificationSound();

            if (Code.Helper.VerificationSettingsHelper.IsAllSettingsAreApplied(Context))
            {
                var caisse = await Context.Caisses.FirstOrDefaultAsync(x => x.Id == Properties.Settings.Default.DefaultCaisseId);
                if (caisse != null)
                {
                    if (caisse.Status == Core.Entities.Caisses.CaisseStatus.Closed)
                    {
                        OpenOrCloseCaisseForm Form = _controlManager.CreateF<OpenOrCloseCaisseForm>();
                        Form.SetMain(true);
                        Form.SetPose(false);

                        Form.ShowDialog();
                        if (Form.DialogResult == DialogResult.OK)
                        {
                            this.Hide();
                            PosForm posForm = _controlManager.CreateF<PosForm>();
                            posForm.ShowDialog();
                            this.Show();
                        }


                    }
                    else if (caisse.Status == Core.Entities.Caisses.CaisseStatus.Open)
                    {
                        this.Hide();
                        PosForm posForm = _controlManager.CreateF<PosForm>();
                        posForm.ShowDialog();
                        this.Show();

                    }
                }
                CloseSubPanels();

            }
        }

        private async void button8_Click(object sender, EventArgs e)
        {

            pageHelper.SetNewPage(await _controlManager.GetAsync<SalesReportsUserControl>());


        }

        private void button6_Click(object sender, EventArgs e)
        {
            CloseSubPanels();

            ShowSubPanel(flowLayoutPanelCaissesAndBank);


        }

        private async void button9_Click(object sender, EventArgs e)
        {

            pageHelper.SetNewPage(await _controlManager.GetAsync<SalesProfitUserControl>());


        }

        private async void button11_Click(object sender, EventArgs e)
        {

            pageHelper.SetNewPage(await _controlManager.GetAsync<DeservedUserControl>());


        }

        private void button10_Click(object sender, EventArgs e)
        {
            CloseSubPanels();

            ShowSubPanel(DeservedflowLayoutPanel);
        }

        private async void button12_Click(object sender, EventArgs e)
        {
            pageHelper.SetNewPage(await _controlManager.GetAsync<VouchersUserControl>());


        }

        private void button14_Click(object sender, EventArgs e)
        {
            CloseSubPanels();

            ShowSubPanel(flowLayoutPaneReturns);

        }

        private async void button15_Click(object sender, EventArgs e)
        {
            pageHelper.SetNewPage(await _controlManager.GetAsync<ReturnUserControl>());

        }

        private async void button16_Click(object sender, EventArgs e)
        {
            pageHelper.SetNewPage(await _controlManager.GetAsync<ReturnsReportsUserControl>());


        }

        private async void button17_Click(object sender, EventArgs e)
        {
            pageHelper.SetNewPage(await _controlManager.GetAsync<StoreInventoryUserControl>());
        }

        private async void button18_Click(object sender, EventArgs e)
        {
            pageHelper.SetNewPage(await _controlManager.GetAsync<StoreTransfertReportUserControl>());

        }

        private async void button19_Click(object sender, EventArgs e)
        {

            pageHelper.SetNewPage(await _controlManager.GetAsync<StoreDamagedProductUserControl>());
        }

        private void btnEmployeerPanel_Click(object sender, EventArgs e)
        {
            CloseSubPanels();

            ShowSubPanel(flowLayoutPanelEmployees);

        }

        private async void btnAllEmployees_Click(object sender, EventArgs e)
        {

            pageHelper.SetNewPage(await _controlManager.GetAsync<EmployeeUserControl>());

        }

        private async void btnNewEmployee_Click(object sender, EventArgs e)
        {
            AddEmployeeForm addProductForm = await _controlManager.GetFAsync<AddEmployeeForm>();


            addProductForm.ShowDialog();
            CloseSubPanels();
        }

        private async void button20_Click(object sender, EventArgs e)
        {

            EmployeeBorrowItemForm addProductForm = await _controlManager.GetFAsync<EmployeeBorrowItemForm>();

            addProductForm.ShowDialog();
        }

        private async void button21_Click(object sender, EventArgs e)
        {

            EmployeeBorrowMoneyForm addProductForm = await _controlManager.GetFAsync<EmployeeBorrowMoneyForm>();

            addProductForm.ShowDialog();
            CloseSubPanels();

        }

        private async void button22_Click(object sender, EventArgs e)
        {

            EmployeeSalaryForm addProductForm = await _controlManager.GetFAsync<EmployeeSalaryForm>();


            addProductForm.ShowDialog();
            CloseSubPanels();
        }

        private async void button23_Click(object sender, EventArgs e)
        {

            pageHelper.SetNewPage(await _controlManager.GetAsync<EmployeeBorrowItemReportUserControl>());


        }

        private async void button24_Click(object sender, EventArgs e)
        {

            pageHelper.SetNewPage(await _controlManager.GetAsync<EmployeeBorrowMoneyReportUserControl>());


        }

        private async void button25_Click(object sender, EventArgs e)
        {

            pageHelper.SetNewPage(await _controlManager.GetAsync<EmployeeSalaryReportUserControl>());


        }

        private async void button27_Click(object sender, EventArgs e)
        {
            UserRolesForm userRolesForm = await _controlManager.GetFAsync<UserRolesForm>();

            userRolesForm.ShowDialog();
            CloseSubPanels();
        }

        private void button13_Click(object sender, EventArgs e)
        {
            CloseSubPanels();
            ShowSubPanel(flowLayoutPanelSettings);
        }

        private async void btnApplicationSettings_Click(object sender, EventArgs e)
        {
            ApplicationSettingsForm ApplicationSettingsForm = await _controlManager.GetFAsync<ApplicationSettingsForm>();

            ApplicationSettingsForm.ShowDialog();
            CloseSubPanels();
        }

        private async void button1_Click_2(object sender, EventArgs e)
        {
            CaisseDetailsForm caisseDetailsForm = await _controlManager.GetFAsync<CaisseDetailsForm>();
            caisseDetailsForm.ShowDialog();
            CloseSubPanels();
        }

        private async void button2_Click_2(object sender, EventArgs e)
        {
            pageHelper.SetNewPage(await _controlManager.GetAsync<DepositToCaisseReportUserControl>());


        }
        private async void button3_Click_2(object sender, EventArgs e)
        {
            pageHelper.SetNewPage(await _controlManager.GetAsync<DepositToBankReportUserControl>());


        }

        private async void button4_Click_1(object sender, EventArgs e)
        {
            pageHelper.SetNewPage(await _controlManager.GetAsync<WithdrawFromCaisseReportsUserControl>());

        }

        private async void button6_Click_1(object sender, EventArgs e)
        {
            pageHelper.SetNewPage(await _controlManager.GetAsync<TransfertBetweenCaisseReportUserControl>());


        }

        private async void button5_Click_1(object sender, EventArgs e)
        {
            pageHelper.SetNewPage(await _controlManager.GetAsync<WIthdrawFromBankReportUserControl>());


        }

        private async void button7_Click_1(object sender, EventArgs e)
        {
            pageHelper.SetNewPage(await _controlManager.GetAsync<TransfertBetweenCaisseAndBankReportUserControl>());


        }

        private async void button8_Click_1(object sender, EventArgs e)
        {
            try
            {
                // Define the backup file path
                string backupFilePath = $@"C:\DatabaseBackups\MyDatabaseBackup {DateTime.Now.Year} - {DateTime.Now.Month} - {DateTime.Now.Day} Time ; {DateTime.Now.Hour}H - {DateTime.Now.Minute}m - {DateTime.Now.Second}s.bak";

                // Create the backup directory if it doesn't exist
                string backupDirectory = Path.GetDirectoryName(backupFilePath);
                if (!Directory.Exists(backupDirectory))
                {
                    Directory.CreateDirectory(backupDirectory);
                }

                // SQL command to back up the database
                string backupSql = $@"
            BACKUP DATABASE [{Context.Database.GetDbConnection().Database}]
            TO DISK = '{backupFilePath}'
            WITH FORMAT, MEDIANAME = 'SQLServerBackups', NAME = 'Full Backup of MyDatabase';";

                // Execute the SQL command
                await Context.Database.ExecuteSqlRawAsync(backupSql);

                MessageBox.Show($"تم النسخ الاحتياطي لقاعدة البيانات بنجاح.\n ملف النسخة الاحتياطية: {backupFilePath}", "نجاح النسخ الاحتياطي", MessageBoxButtons.OK, MessageBoxIcon.Information);
                ToasterHelper.ShowBackUp();
            }
            catch (Exception ex)
            {
                MessageBox.Show($"حدث خطأ أثناء النسخ الاحتياطي لقاعدة البيانات:\n{ex.Message}", "فشل النسخ الاحتياطي", MessageBoxButtons.OK, MessageBoxIcon.Error);



                ToasterHelper.ShowErrorHappened(ex.Message);


            }
        }
        public void KillAllProcessesUsingDbContext(DbContext context)
        {
            try
            {
                // Get the database name and server connection
                var databaseName = context.Database.GetDbConnection().Database;
                var connectionString = context.Database.GetDbConnection().ConnectionString;

                // Parse the connection string to extract the server name
                var builder = new SqlConnectionStringBuilder(connectionString);
                var serverName = builder.DataSource;

                // Create a connection to the master database
                using (var masterConnection = new SqlConnection($"Server={serverName};Database=master;{builder.ConnectionString}"))
                {
                    masterConnection.OpenAsync();

                    // Kill all processes connected to the target database
                    var killProcessesCommand = $@"
                DECLARE @sql NVARCHAR(MAX)
                SET @sql = ''
                SELECT @sql += 'KILL ' + CONVERT(VARCHAR, session_id) + ';'
                FROM sys.dm_exec_sessions
                WHERE database_id = DB_ID('{databaseName}')
                EXEC sp_executesql @sql";

                    using (var command = new SqlCommand(killProcessesCommand, masterConnection))
                    {
                        command.ExecuteNonQuery();
                    }


                }


            }
            catch (Exception ex)
            {
                ToasterHelper.ShowErrorHappened(ex.Message);
            }
        }
        private void button9_Click_1(object sender, EventArgs e)
        {
            try
            {
                OpenFileDialog openFileDialog = new OpenFileDialog
                {
                    Filter = "Backup Files (*.bak)|*.bak",
                    Title = "اختر ملف النسخة الاحتياطية"
                };

                if (openFileDialog.ShowDialog() == DialogResult.OK)
                {
                    string backupFilePath = openFileDialog.FileName;

                    var result = MessageBox.Show(
                        "استعادة النسخة الاحتياطية ستقوم بالكتابة فوق قاعدة البيانات الحالية. هل تريد المتابعة؟",
                        "تأكيد الاستعادة",
                        MessageBoxButtons.YesNo,
                        MessageBoxIcon.Warning);

                    if (result == DialogResult.Yes)
                    {
                        var databaseName = Context?.Database.GetDbConnection().Database;
                        var connectionString = Context?.Database.GetDbConnection().ConnectionString;


                        Server server = new Server($"{Properties.Settings.Default.Server}");
                        Database db = server.Databases[$"{Properties.Settings.Default.DataBase}"];
                        //Database db = server.Databases[databaseName];
                        if (db != null)
                        {
                            server.KillAllProcesses(db.Name);
                        }
                        Restore restore = new Restore();
                        restore.Database = db.Name;
                        restore.Action = RestoreActionType.Database;
                        restore.Devices.AddDevice(openFileDialog.FileName, DeviceType.File);

                        restore.ReplaceDatabase = true;
                        restore.NoRecovery = false;
                        restore.SqlRestoreAsync(server);
                        //// Use the SQL command for restoring the database
                        //string restoreQuery = $"RESTORE DATABASE YourDatabaseName FROM DISK = '{backupFilePath}' WITH REPLACE;";

                        //// Execute the SQL command using Microsoft.Data.SqlClient
                        //using (var connection = new SqlConnection(Context?.Database.GetDbConnection().ConnectionString))
                        //{
                        //    connection.Open();
                        //    using (var command = new SqlCommand(restoreQuery, connection))
                        //    {
                        //        command.ExecuteNonQuery();
                        //    }
                        //}
                        ToasterHelper.ShowRestore();
                        MessageBox.Show("تم استعادة قاعدة البيانات بنجاح!", "نجاح", MessageBoxButtons.OK, MessageBoxIcon.Information);
                    }
                }
            }
            catch (Exception ex)
            {
                MessageBox.Show($"حدث خطأ أثناء استعادة قاعدة البيانات: {ex.Message}", "خطأ", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
        }

        private async void button10_Click_1(object sender, EventArgs e)
        {
            pageHelper.SetNewPage(await _controlManager.GetAsync<VouchersReportsUserControl>());


        }

        private void btnStatics_Click(object sender, EventArgs e)
        {
            CloseSubPanels();
            ShowSubPanel(flowLayoutPanelStateAndDiscount);

        }

        private async void button11_Click_1(object sender, EventArgs e)
        {

            pageHelper.SetNewPage(await _controlManager.GetAsync<StatisticsUserControl>());

        }

        private async void btnProductDiscount_Click(object sender, EventArgs e)
        {
            pageHelper.SetNewPage(await _controlManager.GetAsync<ProductDiscountUserControl>());

        }

        private async void button1_Click_3(object sender, EventArgs e)
        {
            pageHelper.SetNewPage(await _controlManager.GetAsync<CaisseStatusAndOperationUserControl>());
        }

        private async void btnAlerts_Click(object sender, EventArgs e)
        {
            pageHelper.SetNewPage(await _controlManager.GetAsync<AlertsUserControl>());
        }

        private void barButtonItem1_ItemClick(object sender, DevExpress.XtraBars.ItemClickEventArgs e)
        {
            if (flowLayoutPanelNavBar.Visible == false)
                flowLayoutPanelNavBar.Visible = true;
            else flowLayoutPanelNavBar.Visible = false;
        }

        private void btnStatusAlert_ItemClick(object sender, DevExpress.XtraBars.ItemClickEventArgs e)
        {
            btnAlerts_Click(sender, e);
        }
        private IKeyAwareControl GetCurrentUserControl()
        {
            var uc = ContainerPanel.Controls.OfType<UserControl>().FirstOrDefault();
            return uc as IKeyAwareControl;
        }
        private Control GetDeepFocusedControl(Control parent)
        {
            if (parent == null) return null;
            Control focused = parent;
            while (focused is ContainerControl container && container.ActiveControl != null)
            {
                focused = container.ActiveControl;
            }
            return focused;
        }

        protected override bool ProcessCmdKey(ref Message msg, Keys keyData)
        {
            var keyAware = GetCurrentUserControl();
            Control focusedControl = GetDeepFocusedControl(this);

            // Check if focused control is a text input and the key is a character key (A-Z, 0-9, etc.)
            if (focusedControl is TextBoxBase || focusedControl is ComboBox || focusedControl is RichTextBox)
            {
                // Let character keys pass through (typing), but intercept function keys (F1–F12), etc.
                if (!(keyData >= Keys.F1 && keyData <= Keys.F24))
                {
                    return base.ProcessCmdKey(ref msg, keyData);
                }
            }

            // Escape: Return to Home
            if (keyData == Keys.Escape)
            {
                pageHelper.SetNewPage(_controlManager.Get<HomeUserControl>());

                return true;
            }

            // Handle custom global keys like F11
            if (keyAware != null)
            {
                keyAware.HandleKeyDown(keyData);
                return true;
            }

            return base.ProcessCmdKey(ref msg, keyData);
        }

        private async void MainForm_Load(object sender, EventArgs e)
        {
            pageHelper.SetNewPage(await _controlManager.GetAsync<HomeUserControl>());
            ApplyAcces();

        }
        public UserControl GetUserControl()
        {
            return ContainerPanel.Controls.OfType<UserControl>().FirstOrDefault();

        }
        private async void button2_Click_3(object sender, EventArgs e)
        {
            pageHelper.SetNewPage(await _controlManager.GetAsync<ProformaUserControl>());

        }
    }
}
