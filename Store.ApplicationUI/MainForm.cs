using System.ComponentModel;
using System.Globalization;
using System.IO;
using Microsoft.Data.SqlClient;
using Microsoft.EntityFrameworkCore;
using Microsoft.SqlServer.Management.Smo;
using Store.ApplicationUI.Code.GUIHelper;
using Store.ApplicationUI.Code.Helper;
using Store.ApplicationUI.Code.Models;
using Store.ApplicationUI.Gui.CaisseAndBankGui;
using Store.ApplicationUI.Gui.CaisseAndBankGui.FondCaisseGui;
using Store.ApplicationUI.Gui.EmployeesGui;
using Store.ApplicationUI.Gui.EmployeesGui.EmployeeBorrowItemsGui;
using Store.ApplicationUI.Gui.EmployeesGui.EmployeeBorrowMoneyGui;
using Store.ApplicationUI.Gui.EmployeesGui.EmployeeSalaryGui;
using Store.ApplicationUI.Gui.GeneralSettingsGui;
using Store.ApplicationUI.Gui.GeneralSettingsGui.UserRolesGui;
using Store.ApplicationUI.Gui.ProductsGui;
using Store.ApplicationUI.Gui.ProductsGui.Category;
using Store.ApplicationUI.Gui.ProductsGui.StoreGui;
using Store.ApplicationUI.Gui.SalesGui.PosGui;
using Store.Infrastructure.Data;



namespace Store.ApplicationUI
{
    public partial class MainForm : Form
    {
        private PageHelper pageHelper;

        [DesignerSerializationVisibility(DesignerSerializationVisibility.Hidden)]
        public static ApplicationDbContext? Context { get; set; }
        public MainForm()
        {
            InitializeComponent();
            KeyPreview = true;
            try
            {


                Code.Helper.ConStringHelper.SetConString();

                pageHelper = new(this);
                pageHelper.SetNewPage(Gui.HomeGui.HomeUserControl.Instance(this));


                Context = new ApplicationDbContext();
                SetScreenState(Properties.Settings.Default.IsMaxScreen);

                isPanelNull = true;
                //btnStatistics.Enabled = LocalUser.User.UserName
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
                    btnBackUp.Visible = LocalUser.User.UserSetting.BackUp && !Properties.Settings.Default.TrialVersion;
                    btnRestore.Visible = LocalUser.User.UserSetting.Restore && !Properties.Settings.Default.TrialVersion;
                }
            }
            catch (Exception ex)
            {

                ToasterHelper.ShowErrorHappened(ex.Message);

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
        void TiltOptions()
        {

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
            Application.Exit();
        }

        private void btnHomeSummary_Click(object sender, EventArgs e)
        {

            pageHelper.SetNewPage(Gui.HomeGui.HomeUserControl.Instance(this));
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
        private void button1_Click(object sender, EventArgs e)
        {
            pageHelper.SetNewPage(Gui.ProductsGui.ProductsUserControl.Instance(this));
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

        private void button2_Click(object sender, EventArgs e)
        {

            AddProductForm addProductForm = AddProductForm.Instance(this);
            addProductForm.Show();
            CloseSubPanels();
        }

        private void button3_Click(object sender, EventArgs e)
        {
            ToasterHelper.PlayNotificationSound();
            AddCategoryForm addCategoryForm = AddCategoryForm.Instance(this);
            addCategoryForm.Show();
            CloseSubPanels();

        }

        private void btnCustomers_Click(object sender, EventArgs e)
        {
            CloseSubPanels();

            ShowSubPanel(CustomersflowLayoutPaneel);
        }

        private void button2_Click_1(object sender, EventArgs e)
        {
            pageHelper.SetNewPage(Gui.CustomersGui.CustomersUserControl.Instance(this));
        }

        private void button3_Click_1(object sender, EventArgs e)
        {
            AddCustomerForm addProductForm = AddCustomerForm.Instance(this);

            addProductForm.Show();
            CloseSubPanels();
        }

        private void button4_Click(object sender, EventArgs e)
        {
            pageHelper.SetNewPage(Gui.CustomersGui.CustomerAccountGui.CustomerAccountUserControl.Instance(this));

        }

        private void button1_Click_1(object sender, EventArgs e)
        {
            pageHelper.SetNewPage(Gui.CustomersGui.CustomerReportsGui.CustomerReportsUserControl.Instance(this));

        }

        private void btnSupplierPanel_Click(object sender, EventArgs e)
        {
            CloseSubPanels();

            ShowSubPanel(SuppliersflowLayoutPanel);
        }

        private void btnAddSupplier_Click(object sender, EventArgs e)
        {
            AddSupplierForm addSupplierForm = AddSupplierForm.Instance(this);

            addSupplierForm.Show();
            CloseSubPanels();
        }

        private void btnAllSuppliers_Click(object sender, EventArgs e)
        {
            pageHelper.SetNewPage(Gui.SupplierGui.SuppliersUserControl.Instance(this));
        }

        private void btnSupplierAccount_Click(object sender, EventArgs e)
        {
            pageHelper.SetNewPage(Gui.SupplierGui.SupplierAccountGui.SupplierAccountUserControl.Instance(this));

        }

        private void btnSupplierReports_Click(object sender, EventArgs e)
        {
            pageHelper.SetNewPage(Gui.SupplierGui.SupplierReportsGui.SupplierReportsUserControl.Instance(this));

        }

        private void button5_Click(object sender, EventArgs e)
        {
            ToasterHelper.PlayNotificationSound();
            AddStoreForm addStoreForm = AddStoreForm.Instance(this);
            addStoreForm.Show();
            CloseSubPanels();

        }
        public decimal ConvertToFloat(string value)
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

        private void btnNewBuy_Click(object sender, EventArgs e)
        {
            Context = new ApplicationDbContext();
            if (Code.Helper.VerificationSettingsHelper.IsAllSettingsAreApplied(Context))
                pageHelper.SetNewPage(Gui.BuysGui.BuysUserControl.Instance(this));
        }

        private void btnSalesPanel_Click(object sender, EventArgs e)
        {
            CloseSubPanels();

            ShowSubPanel(SalesflowLayoutPanel);
        }

        private void button7_Click(object sender, EventArgs e)
        {
            Context = new ApplicationDbContext();
            if (Code.Helper.VerificationSettingsHelper.IsAllSettingsAreApplied(Context))
                pageHelper.SetNewPage(Gui.SalesGui.SalesUserControl.Instance(this));
        }

        private void btnBuysReports_Click(object sender, EventArgs e)
        {
            pageHelper.SetNewPage(Gui.BuysGui.BuysReportsGui.BuysReportsUserControl.Instance(this));
        }

        private void btnComptoire_Click(object sender, EventArgs e)
        {
            ToasterHelper.PlayNotificationSound();
            Context = new ApplicationDbContext();
            if (Code.Helper.VerificationSettingsHelper.IsAllSettingsAreApplied(Context))
            {
                var caisse = Context.Caisses.FirstOrDefault(x => x.Id == Properties.Settings.Default.DefaultCaisseId);
                if (caisse != null)
                {
                    if (caisse.Status == Core.Entities.Caisses.CaisseStatus.Closed)
                    {
                        OpenOrCloseCaisseForm Form = new OpenOrCloseCaisseForm(this);
                        Form.ShowDialog();
                    }
                    else if (caisse.Status == Core.Entities.Caisses.CaisseStatus.Open)
                    {
                        this.Hide();
                        PosForm posForm = new PosForm(this);
                        posForm.ShowDialog();
                        this.Show();

                    }
                }
                CloseSubPanels();

            }
        }

        private void button8_Click(object sender, EventArgs e)
        {
            pageHelper.SetNewPage(Gui.SalesGui.SalesReportsGui.SalesReportsUserControl.Instance(this));

        }

        private void button6_Click(object sender, EventArgs e)
        {
            CloseSubPanels();

            ShowSubPanel(flowLayoutPanelCaissesAndBank);


        }

        private void button9_Click(object sender, EventArgs e)
        {
            pageHelper.SetNewPage(Gui.SalesGui.SaleProfitGui.SalesProfitUserControl.Instance(this));

        }

        private void button11_Click(object sender, EventArgs e)
        {
            pageHelper.SetNewPage(Gui.DeservedGui.DeservedUserControl.Instance(this));

        }

        private void button10_Click(object sender, EventArgs e)
        {
            CloseSubPanels();

            ShowSubPanel(DeservedflowLayoutPanel);
        }

        private void button12_Click(object sender, EventArgs e)
        {
            pageHelper.SetNewPage(Gui.DeservedGui.VouchersGui.VouchersUserControl.Instance(this));

        }

        private void button14_Click(object sender, EventArgs e)
        {
            CloseSubPanels();

            ShowSubPanel(flowLayoutPaneReturns);

        }

        private void button15_Click(object sender, EventArgs e)
        {
            pageHelper.SetNewPage(Gui.ReturnsGui.ReturnUserControl.Instance(this));
        }

        private void button16_Click(object sender, EventArgs e)
        {
            pageHelper.SetNewPage(Gui.ReturnsGui.ReturnsReportsGui.ReturnsReportsUserControl.Instance(this));

        }

        private void button17_Click(object sender, EventArgs e)
        {
            pageHelper.SetNewPage(Gui.ProductsGui.StoreGui.StoreInventoryGui.StoreInventoryUserControl.Instance(this));

        }

        private void button18_Click(object sender, EventArgs e)
        {
            pageHelper.SetNewPage(Gui.ProductsGui.StoreGui.StoreTrensfertReportGui.StoreTransfertReportUserControl.Instance(this));

        }

        private void button19_Click(object sender, EventArgs e)
        {

            pageHelper.SetNewPage(Gui.ProductsGui.StoreGui.StoreDamagedProductReportGui.StoreDamagedProductUserControl.Instance(this));
        }

        private void btnEmployeerPanel_Click(object sender, EventArgs e)
        {
            CloseSubPanels();

            ShowSubPanel(flowLayoutPanelEmployees);

        }

        private void btnAllEmployees_Click(object sender, EventArgs e)
        {
            pageHelper.SetNewPage(Gui.EmployeesGui.EmployeeUserControl.Instance(this));

        }

        private void btnNewEmployee_Click(object sender, EventArgs e)
        {
            AddEmployeeForm addProductForm = AddEmployeeForm.Instance(this);

            addProductForm.Show();
            CloseSubPanels();
        }

        private void button20_Click(object sender, EventArgs e)
        {
            EmployeeBorrowItemForm addProductForm = EmployeeBorrowItemForm.Instance(this);

            addProductForm.Show();
        }

        private void button21_Click(object sender, EventArgs e)
        {
            EmployeeBorrowMoneyForm addProductForm = EmployeeBorrowMoneyForm.Instance(this);

            addProductForm.Show();
            CloseSubPanels();

        }

        private void button22_Click(object sender, EventArgs e)
        {
            EmployeeSalaryForm addProductForm = EmployeeSalaryForm.Instance(this);

            addProductForm.Show();
            CloseSubPanels();
        }

        private void button23_Click(object sender, EventArgs e)
        {
            pageHelper.SetNewPage(Gui.EmployeesGui.EmployeeBorrowsItemReport.EmployeeBorrowItemReportUserControl.Instance(this));

        }

        private void button24_Click(object sender, EventArgs e)
        {
            pageHelper.SetNewPage(Gui.EmployeesGui.EmployeeBorrowMoneyReport.EmployeeBorrowMoneyReportUserControl.Instance(this));

        }

        private void button25_Click(object sender, EventArgs e)
        {
            pageHelper.SetNewPage(Gui.EmployeesGui.EmployeeSalaryReportGui.EmployeeSalaryReportUserControl.Instance(this));

        }

        private void button27_Click(object sender, EventArgs e)
        {
            UserRolesForm userRolesForm = UserRolesForm.Instance(this);

            userRolesForm.Show();
            CloseSubPanels();
        }

        private void button13_Click(object sender, EventArgs e)
        {
            CloseSubPanels();
            ShowSubPanel(flowLayoutPanelSettings);
        }

        private void btnApplicationSettings_Click(object sender, EventArgs e)
        {
            ApplicationSettingsForm ApplicationSettingsForm = ApplicationSettingsForm.Instance(this);

            ApplicationSettingsForm.Show();
            CloseSubPanels();
        }

        private void button1_Click_2(object sender, EventArgs e)
        {
            CaisseDetailsForm caisseDetailsForm = CaisseDetailsForm.Instance(this);
            caisseDetailsForm.Show();
            CloseSubPanels();
        }

        private void button2_Click_2(object sender, EventArgs e)
        {
            pageHelper.SetNewPage(Gui.CaisseAndBankGui.DepositToCaisseReportGui.DepositToCaisseReportUserControl.Instance(this));

        }
        private void button3_Click_2(object sender, EventArgs e)
        {
            pageHelper.SetNewPage(Gui.CaisseAndBankGui.DepositToBankReportGui.DepositToBankReportUserControl.Instance(this));

        }

        private void button4_Click_1(object sender, EventArgs e)
        {
            pageHelper.SetNewPage(Gui.CaisseAndBankGui.WithdrawFromCaisseReportsGui.WithdrawFromCaisseReportsUserControl.Instance(this));
        }

        private void button6_Click_1(object sender, EventArgs e)
        {
            pageHelper.SetNewPage(Gui.CaisseAndBankGui.TransfertBetweenCaisseReportGui.TransfertBetweenCaisseReportUserControl.Instance(this));

        }

        private void button5_Click_1(object sender, EventArgs e)
        {
            pageHelper.SetNewPage(Gui.CaisseAndBankGui.WithdrawFromBankReportGui.WIthdrawFromBankReportUserControl.Instance(this));

        }

        private void button7_Click_1(object sender, EventArgs e)
        {
            pageHelper.SetNewPage(Gui.CaisseAndBankGui.TransfertBetweenCaisseAndBankReportGui.TransfertBetweenCaisseAndBankReportUserControl.Instance(this));

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
                    masterConnection.Open();

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
                        restore.SqlRestore(server);
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




            //try
            //{

            //    Server server = new Server($"{Properties.Settings.Default.Server}");
            //    Database db = server.Databases[$"{Properties.Settings.Default.DataBase}"];
            //    if (db != null)
            //    {
            //        server.KillAllProcesses(db.Name);
            //    }
            //    Restore restore = new Restore();
            //    restore.Database = db.Name;
            //    restore.Action = RestoreActionType.Database;
            //    OpenFileDialog openFileDialog = new OpenFileDialog
            //    {
            //        Filter = "Backup Files (*.bak)|*.bak",
            //        Title = "اختر ملف النسخة الاحتياطية"
            //    };
            //    if (openFileDialog.ShowDialog() == DialogResult.OK)
            //    {

            //        restore.Devices.AddDevice(openFileDialog.FileName, DeviceType.File);
            //        restore.ReplaceDatabase = true;
            //        restore.NoRecovery = false;
            //        restore.SqlRestore(server);

            //        MessageBox.Show("Restore Has Been Successfully", "Operation Finished");


            //    }

            //}
            //catch (Exception)
            //{

            //}

        }

        private void button10_Click_1(object sender, EventArgs e)
        {
            pageHelper.SetNewPage(Gui.DeservedGui.VouchersReportGui.VouchersReportsUserControl.Instance(this));

        }

        private void btnStatics_Click(object sender, EventArgs e)
        {
            CloseSubPanels();
            ShowSubPanel(flowLayoutPanelStateAndDiscount);

        }

        private void button11_Click_1(object sender, EventArgs e)
        {
            pageHelper.SetNewPage(Gui.HomeGui.StatisticsUserControl.Instance(this));

        }

        private void btnProductDiscount_Click(object sender, EventArgs e)
        {
            pageHelper.SetNewPage(Gui.ProductsGui.ProductDiscountGui.ProductDiscountUserControl.Instance(this));

        }

        private void button1_Click_3(object sender, EventArgs e)
        {
            pageHelper.SetNewPage(Gui.CaisseAndBankGui.FondCaisseGui.CaisseStatusAndOperationUserControl.Instance(this));

        }

        private void btnAlerts_Click(object sender, EventArgs e)
        {
            pageHelper.SetNewPage(Gui.HomeGui.AlertsUserControl.Instance(this));

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
                pageHelper.SetNewPage(Gui.HomeGui.HomeUserControl.Instance(this));
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
    }
}
