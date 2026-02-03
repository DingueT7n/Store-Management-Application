using System.Reflection;
using Microsoft.Data.SqlClient;
using Microsoft.EntityFrameworkCore;
using Store.Core.Entities.AllDeserved;
using Store.Core.Entities.Banks;
using Store.Core.Entities.Buys;
using Store.Core.Entities.Caisses;
using Store.Core.Entities.Customers;
using Store.Core.Entities.Employees;
using Store.Core.Entities.Helpers;
using Store.Core.Entities.Products;
using Store.Core.Entities.Returns;
using Store.Core.Entities.Sales;
using Store.Core.Entities.Suppliers;
using Store.Core.Entities.Users;
using Store.Core.Entities.Vouchers;

namespace Store.Infrastructure.Data
{
    public class ApplicationDbContext : DbContext
    {
        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            base.OnModelCreating(modelBuilder);
            modelBuilder.ApplyConfigurationsFromAssembly(Assembly.GetExecutingAssembly());

            modelBuilder.Entity<UserBuy>()
      .HasOne(ub => ub.User)
      .WithMany()
      .HasForeignKey(ub => ub.User_Id); // Use actual column name in the database

            modelBuilder.Entity<UserCaisseAndBank>()
               .HasOne(ub => ub.User)
               .WithMany()
               .HasForeignKey(ub => ub.User_Id);
            modelBuilder.Entity<UserCustomer>()
               .HasOne(ub => ub.User)
               .WithMany()
               .HasForeignKey(ub => ub.User_Id);

            modelBuilder.Entity<UserDeservedAndTax>()
              .HasOne(ub => ub.User)
              .WithMany()
              .HasForeignKey(ub => ub.User_Id);

            modelBuilder.Entity<UserEmployee>()
              .HasOne(ub => ub.User)
              .WithMany()
              .HasForeignKey(ub => ub.User_Id);
            modelBuilder.Entity<UserProductAndStore>()
             .HasOne(ub => ub.User)
             .WithMany()
             .HasForeignKey(ub => ub.User_Id);

            modelBuilder.Entity<UserRefund>()
            .HasOne(ub => ub.User)
            .WithMany()
            .HasForeignKey(ub => ub.User_Id);

            modelBuilder.Entity<UserSale>()
             .HasOne(ub => ub.User)
             .WithMany()
             .HasForeignKey(ub => ub.User_Id);

            modelBuilder.Entity<UserSetting>()
            .HasOne(ub => ub.User)
            .WithMany()
            .HasForeignKey(ub => ub.User_Id);

            modelBuilder.Entity<UserSupplier>()
              .HasOne(ub => ub.User)
              .WithMany()
              .HasForeignKey(ub => ub.User_Id);

            //CategorySeed.Seed(modelBuilder);
            //CaisseSeed.Seed(modelBuilder);
            //  ProductSeed.Seed(modelBuilder);

        }
        protected override void ConfigureConventions(ModelConfigurationBuilder configurationBuilder)
        {
            configurationBuilder.Properties<decimal>()
       .HavePrecision(18, 2);
            base.ConfigureConventions(configurationBuilder);
        }
        protected override void OnConfiguring(DbContextOptionsBuilder optionsBuilder)
        {
            string conString = ConString.ConStringValue;
            conString = @"Server=.\SQLEXPRESS; Database=StoreDbEFCoreTEST1;Encrypt=false; Integrated Security = true;";
            optionsBuilder.UseSqlServer(conString);
            base.OnConfiguring(optionsBuilder);
            //     string conString = "Server=localhost;Database=StoreDbEFCore;User=root;Password=admin;";
            //optionsBuilder.UseMySql(conString, new MySqlServerVersion(new Version(8, 0, 21))) // Replace with your MySQL version
            //    .EnableSensitiveDataLogging()
            //    .LogTo(Console.WriteLine, Microsoft.Extensions.Logging.LogLevel.Information);
        }

        public static async Task<bool> IsValidConnectionStringAsync(string connectionString)
        {
            try
            {
                // Try to open the connection
                using (var connection = new SqlConnection(connectionString))
                {
                    await connection.OpenAsync();
                }
                return true; // Connection successful
            }
            catch (Exception)
            {
                return false; // Connection failed
            }
        }
        public DbSet<Bank> Banks { get; set; }
        public DbSet<BankDeposit> BankDeposits { get; set; }
        public DbSet<BankWithdraw> BankWithdraws { get; set; }
        public DbSet<Employee> Employees { get; set; }
        public DbSet<EmployeeSalaryMinus> EmployeesSalaryMinus { get; set; }
        public DbSet<EmployeeBorrowItem> EmployeesBorrowItems { get; set; }
        public DbSet<EmployeeBorrowMoney> EmployeesBorrowMonies { get; set; }
        public DbSet<EmployeeSalary> EmployeesSalaries { get; set; }
        public DbSet<Product> Products { get; set; }
        public DbSet<ProductFamily> ProductFamilies { get; set; }
        public DbSet<ProductDiscount> ProductDiscounts { get; set; }
        public DbSet<ProductQuickAccess> ProductQuickAccess { get; set; }
        public DbSet<ReceiptVoucher> ReceiptVouchers { get; set; }
        public DbSet<SendVoucher> SendVouchers { get; set; }
        public DbSet<OrderPrintData> OrderPrintData { get; set; }
        public DbSet<AlertTable> AlertsTable { get; set; }
        public DbSet<RandomBarcode> RandomBarcode { get; set; }
        public DbSet<BarcodePrint> BarcodePrints { get; set; }
        public DbSet<Category> Categories { get; set; }
        public DbSet<ProductTransfer> ProductsTransfers { get; set; }
        public DbSet<ProductOutStore> ProductsOutStore { get; set; }
        public DbSet<ProductsQuantitie> ProductsQuantities { get; set; }
        public DbSet<Supplier> Suppliers { get; set; }
        public DbSet<SupplierMoney> SuppliersMoneys { get; set; }
        public DbSet<SupplierReport> SuppliersReports { get; set; }
        public DbSet<Customer> Customers { get; set; }
        public DbSet<CustomerMoney> CustomersMoneys { get; set; }
        public DbSet<CustomerReport> CustomersReports { get; set; }
        public DbSet<Buy> Buys { get; set; }
        public DbSet<BuyDetail> BuyDetails { get; set; }
        public DbSet<Deserved> Deserveds { get; set; }
        public DbSet<DeservedType> DeservedsTypes { get; set; }
        public DbSet<TaxesReport> TaxesReports { get; set; }

        public DbSet<Return> Returns { get; set; }
        public DbSet<ReturnDetail> ReturnsDetails { get; set; }

        public DbSet<Sale> Sales { get; set; }
        public DbSet<SaleDetail> SalesDetails { get; set; }
        public DbSet<SaleProfit> SalesProfits { get; set; }
        public DbSet<ProformaInvoice> ProformaInvoices { get; set; }
        public DbSet<ProformaInvoiceDetails> ProformaInvoiceDetails { get; set; }

        public DbSet<Core.Entities.Stores.Store> Stores { get; set; }
        public DbSet<Core.Entities.Stores.InventoryCheck> InventoryChecks { get; set; }
        public DbSet<Core.Entities.Stores.InventorySession> InventorySessions { get; set; }

        public DbSet<Caisse> Caisses { get; set; }
        public DbSet<CaisseOperation> CaisseOperations { get; set; }
        public DbSet<CaisseStatusDetail> CaisseStatusDetails { get; set; }
        public DbSet<CaisseDeposit> CaissesDeposits { get; set; }
        public DbSet<CaisseWithdraw> CaissesWithdraws { get; set; }
        public DbSet<CaisseTransfere> CaissesTransferes { get; set; }
        public DbSet<CaisseBankTransfere> CaissesBankTransferes { get; set; }
        public DbSet<sale8cm> sale8cms { get; set; }
        public DbSet<User> Users { get; set; }
        public DbSet<UserSetting> UserSettings { get; set; }
        public DbSet<UserCustomer> UserCustomers { get; set; }
        public DbSet<UserProductAndStore> UserProductsAndStores { get; set; }
        public DbSet<UserSupplier> UserSuppliers { get; set; }
        public DbSet<UserBuy> UserBuys { get; set; }
        public DbSet<UserSale> UserSales { get; set; }
        public DbSet<UserCaisseAndBank> UserCaissesAndBanks { get; set; }
        public DbSet<UserDeservedAndTax> UserDeservedAndTaxs { get; set; }
        public DbSet<UserRefund> UserRefunds { get; set; }
        public DbSet<UserEmployee> UserEmployees { get; set; }
    }
}
