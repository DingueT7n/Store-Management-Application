using Microsoft.Extensions.DependencyInjection;
using Store.ApplicationUI.Gui.BuysGui;
using Store.ApplicationUI.Gui.BuysGui.BuysReportsGui;
using Store.ApplicationUI.Gui.CaisseAndBankGui;
using Store.ApplicationUI.Gui.CaisseAndBankGui.DepositToBankGui;
using Store.ApplicationUI.Gui.CaisseAndBankGui.DepositToBankReportGui;
using Store.ApplicationUI.Gui.CaisseAndBankGui.DepositToCaisseGui;
using Store.ApplicationUI.Gui.CaisseAndBankGui.DepositToCaisseReportGui;
using Store.ApplicationUI.Gui.CaisseAndBankGui.FondCaisseGui;
using Store.ApplicationUI.Gui.CaisseAndBankGui.TransferBetweenCaissesGui;
using Store.ApplicationUI.Gui.CaisseAndBankGui.TransfertBetweenBankAndCaisseGui;
using Store.ApplicationUI.Gui.CaisseAndBankGui.TransfertBetweenCaisseAndBankReportGui;
using Store.ApplicationUI.Gui.CaisseAndBankGui.TransfertBetweenCaisseReportGui;
using Store.ApplicationUI.Gui.CaisseAndBankGui.WithdrawFromBank;
using Store.ApplicationUI.Gui.CaisseAndBankGui.WithdrawFromBankReportGui;
using Store.ApplicationUI.Gui.CaisseAndBankGui.WithdrawFromCaisseGui;
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
using Store.ApplicationUI.Gui.LoginGui;
using Store.ApplicationUI.Gui.PaymentGui;
using Store.ApplicationUI.Gui.ProductsGui;
using Store.ApplicationUI.Gui.ProductsGui.BarcodeGui;
using Store.ApplicationUI.Gui.ProductsGui.Category;
using Store.ApplicationUI.Gui.ProductsGui.ProductDiscountGui;
using Store.ApplicationUI.Gui.ProductsGui.StoreGui;
using Store.ApplicationUI.Gui.ProductsGui.StoreGui.StoreDamagedProductReportGui;
using Store.ApplicationUI.Gui.ProductsGui.StoreGui.StoreDeleteDamagedProductGui;
using Store.ApplicationUI.Gui.ProductsGui.StoreGui.StoreInventoryGui;
using Store.ApplicationUI.Gui.ProductsGui.StoreGui.StoreTrensfertReportGui;
using Store.ApplicationUI.Gui.ProductsGui.StoreGui.TransferBetweenStoresGui;
using Store.ApplicationUI.Gui.ReturnsGui;
using Store.ApplicationUI.Gui.ReturnsGui.ReturnsReportsGui;
using Store.ApplicationUI.Gui.SalesGui;
using Store.ApplicationUI.Gui.SalesGui.PosGui;
using Store.ApplicationUI.Gui.SalesGui.SaleProfitGui;
using Store.ApplicationUI.Gui.SalesGui.SalesReportsGui;
using Store.ApplicationUI.Gui.SupplierGui;
using Store.ApplicationUI.Gui.SupplierGui.SupplierAccountGui;
using Store.ApplicationUI.Gui.SupplierGui.SupplierReportsGui;
using Store.ApplicationUI.Reports.BuysReports;
using Store.ApplicationUI.Reports.CustomersAccountReports;
using Store.ApplicationUI.Reports.ProductsReports;
using Store.ApplicationUI.Reports.SalesReports;
using Store.ApplicationUI.Reports.SuppliersAccountsReports;
using Store.ApplicationUI.Reports.VouchersReports;
using Store.Core.Entities.Sales;
using Store.Core.Interfaces;
using Store.Infrastructure.Data;
using Store.Infrastructure.Repositories;
using static Store.Infrastructure.Repositories.DeservedsRepository;
using sale8cm = Store.ApplicationUI.Reports.sale8cm;

namespace Store.ApplicationUI.Code.System
{
    public static class DependencyInjection
    {
        public static void AddApplicationServices(this IServiceCollection services)
        {
            // DbContext
            services.AddDbContext<ApplicationDbContext>();

            // Repositories
            services.AddScoped<IProductRepository, ProductsRepository>();
            services.AddScoped<IProductOutStoreRepository, ProductOutStoreRepository>();
            services.AddScoped<IProductsQuantitieRepository, ProductsQuantitieRepository>();
            services.AddScoped<IProductTransferRepository, ProductTransferRepository>();
            services.AddScoped<IProductDiscountRepository, ProductDiscountRepository>();
            services.AddScoped<ICategoryRepository, CategorysRepository>();

            services.AddScoped<IBuysRepository, BuysRepository>();
            services.AddScoped<IBuyDetailRepository, BuyDetailRepository>();

            services.AddScoped<ICaissesRepository, CaissesRepository>();
            services.AddScoped<ICaisseTransfereRepository, CaisseTransfereRepository>();
            services.AddScoped<ICaisseDepositRepository, CaisseDepositRepository>();
            services.AddScoped<ICaisseWithdrawRepository, CaisseWithdrawRepository>();
            services.AddScoped<ICaisseBankTransfereRepository, CaisseBankTransfereRepository>();
            services.AddScoped<ICaisseStatusDetailRepository, CaisseStatusDetailRepository>();
            services.AddScoped<ICaisseOperationRepository, CaisseOperationRepository>();

            services.AddScoped<ICustomersRepository, CustomersRepository>();
            services.AddScoped<ICustomerMoneyRepository, CustomerMoneyRepository>();
            services.AddScoped<ICustomerReportRepository, CustomerReportRepository>();

            services.AddScoped<IDeservedsRepository, DeservedsRepository>();
            services.AddScoped<IDeservedTypesRepository, DeservedTypesRepository>();


            services.AddScoped<IEmployeesRepository, EmployeesRepository>();
            services.AddScoped<IEmployeeBorrowItemRepository, EmployeeBorrowItemRepository>();
            services.AddScoped<IEmployeeBorrowMoneyRepository, EmployeeBorrowMoneyRepository>();
            services.AddScoped<IEmployeeSalaryRepository, EmployeeSalaryRepository>();
            services.AddScoped<IEmployeeSalaryMinusRepository, EmployeeSalaryMinusRepository>();




            services.AddScoped<IReturnsRepository, ReturnsRepository>();
            services.AddScoped<IReturnDetailRepository, ReturnDetailRepository>();


            services.AddScoped<ISalesRepository, SalesRepository>();
            services.AddScoped<ISaleDetailRepository, SaleDetailRepository>();
            services.AddScoped<ISaleProfitRepository, SaleProfitRepository>();


            services.AddScoped<IStoresRepository, StoresRepository>();
            services.AddScoped<IReceiptVoucherRepository, ReceiptVoucherRepository>();
            services.AddScoped<ISendVoucherRepository, SendVoucherRepository>();

            services.AddScoped<ISuppliersRepository, SuppliersRepository>();
            services.AddScoped<ISupplierMoneyRepository, SupplierMoneyRepository>();
            services.AddScoped<ISupplierReportRepository, SupplierReportRepository>();

            //services.AddScoped<IProformaInvoiceRepository, ProformaInvoiceRepository>();

            // Services
            //services.AddScoped<IProductService, ProductService>();
            //services.AddScoped<IProformaInvoiceService, ProformaInvoiceService>();

            // UI Forms and Controls

            services.AddScoped<MainForm>();
            services.AddSingleton<ControlManager>();


            services.AddScoped<LoginForm>();

            services.AddScoped<BuysReportsUserControl>();
            services.AddScoped<BuysUserControl>();

            services.AddScoped<DepositTobankUserControl>();
            services.AddScoped<DepositToBankReportUserControl>();
            services.AddScoped<DepositCaisseUserControl>();
            services.AddScoped<DepositToCaisseReportUserControl>();
            services.AddScoped<CaisseStatusAndOperationUserControl>();
            services.AddScoped<OpenOrCloseCaisseForm>();
            services.AddScoped<TransferBetweenCaissesGuiUserControl>();
            services.AddScoped<TransfertBetweenBankAndCaisseUserControl>();
            services.AddScoped<TransfertBetweenCaisseReportUserControl>();
            services.AddScoped<TransfertBetweenCaisseAndBankReportUserControl>();
            services.AddScoped<TransfertBetweenCaisseReportUserControl>();
            services.AddScoped<WithdrawFromBankUserControl>();
            services.AddScoped<WIthdrawFromBankReportUserControl>();
            services.AddScoped<WithdrawFromCaisseUserControl>();
            services.AddScoped<WithdrawFromCaisseReportsUserControl>();
            services.AddScoped<CaisseDetailsForm>();


            services.AddScoped<CustomerAccountUserControl>();
            services.AddScoped<CustomerReportsUserControl>();
            services.AddScoped<AddCustomerForm>();
            services.AddScoped<CustomersUserControl>();

            services.AddScoped<AddDeservedTypeForm>();
            services.AddScoped<AddVoucherForm>();
            services.AddScoped<VouchersUserControl>();
            services.AddScoped<VouchersReportsUserControl>();
            services.AddScoped<AddDeservedForm>();
            services.AddScoped<DeservedUserControl>();

            services.AddScoped<EmployeeBorrowItemForm>();
            services.AddScoped<EmployeeBorrowMoneyForm>();
            services.AddScoped<EmployeeBorrowMoneyReportUserControl>();
            services.AddScoped<EmployeeBorrowItemReportUserControl>();
            services.AddScoped<EmployeeSalaryForm>();
            services.AddScoped<EmployeeSalaryReportUserControl>();
            services.AddScoped<AddEmployeeForm>();
            services.AddScoped<EmployeeUserControl>();

            services.AddScoped<ApplicationSettingsForm>();
            services.AddScoped<UserRolesForm>();

            services.AddScoped<AlertsUserControl>();
            services.AddScoped<HomeUserControl>();
            services.AddScoped<StatisticsUserControl>();


            services.AddScoped<ConnectionSettingsForm>();
            services.AddScoped<AddPaymentForm>();
            services.AddScoped<LockUnlockForm>();
            services.AddScoped<SelectCustomerForm>();
            services.AddScoped<SelectProductsForm>();

            services.AddScoped<BarCodeForm>();
            services.AddScoped<AddCategoryForm>();
            services.AddScoped<AddProductDiscountForm>();
            services.AddScoped<ProductDiscountUserControl>();
            services.AddScoped<StoreDamagedProductUserControl>();
            services.AddScoped<StoreDamagedProductForm>();
            services.AddScoped<AddStoreForm>();
            services.AddScoped<StoreInventoryUserControl>();
            services.AddScoped<StoreTransfertReportUserControl>();
            services.AddScoped<StoreTransfertForm>();
            services.AddScoped<AddProductForm>();
            services.AddScoped<ProductsUserControl>();

            services.AddScoped<ReturnUserControl>();
            services.AddScoped<ReturnsReportsUserControl>();

            services.AddScoped<PosForm>();
            services.AddTransient<PosUserControl>();
            services.AddScoped<SalesProfitUserControl>();
            services.AddScoped<SalesReportsUserControl>();
            services.AddScoped<SalesUserControl>();

            services.AddScoped<SupplierReportsUserControl>();
            services.AddScoped<SupplierAccountUserControl>();
            services.AddScoped<AddSupplierForm>();
            services.AddScoped<SuppliersUserControl>();

            services.AddScoped<buy8cm>();
            services.AddScoped<buyA4>();
            services.AddScoped<buyReportsInPeriod>();

            services.AddScoped<CustomersAccountReport>();
            services.AddScoped<ProductBarCode>();

            services.AddScoped<salesA4>();
            services.AddScoped<sale8cm>();
            services.AddScoped<SaleProfit>();

            services.AddScoped<SuppliersAccountsReports>();
            services.AddScoped<RecieptVoucher>();
            services.AddScoped<SendVoucher>();


            //services.AddScoped<ProformaInvoiceControl>();
        }
    }
}
