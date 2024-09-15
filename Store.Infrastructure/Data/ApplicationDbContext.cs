using System.Reflection;
using Microsoft.EntityFrameworkCore;
using Store.Core.Entities.AllDeserved;
using Store.Core.Entities.Banks;
using Store.Core.Entities.Buys;
using Store.Core.Entities.Caisses;
using Store.Core.Entities.Customers;
using Store.Core.Entities.Helpers;
using Store.Core.Entities.Products;
using Store.Core.Entities.Returns;
using Store.Core.Entities.Sales;
using Store.Core.Entities.Suppliers;
using Store.Core.Entities.Vouchers;

namespace Store.Infrastructure.Data
{
    public class ApplicationDbContext : DbContext
    {
        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            base.OnModelCreating(modelBuilder);
            modelBuilder.ApplyConfigurationsFromAssembly(Assembly.GetExecutingAssembly());

        }
        protected override void OnConfiguring(DbContextOptionsBuilder optionsBuilder)
        {
            string conString = @"Server=.\SQLEXPRESS; Database=StoreDbEFCore;Encrypt=false; Integrated Security = true;";
            optionsBuilder.UseSqlServer(conString).EnableSensitiveDataLogging() // Enables detailed logging
                  .LogTo(Console.WriteLine, Microsoft.Extensions.Logging.LogLevel.Information); ;
            base.OnConfiguring(optionsBuilder);
            //     string conString = "Server=localhost;Database=StoreDbEFCore;User=root;Password=admin;";
            //optionsBuilder.UseMySql(conString, new MySqlServerVersion(new Version(8, 0, 21))) // Replace with your MySQL version
            //    .EnableSensitiveDataLogging()
            //    .LogTo(Console.WriteLine, Microsoft.Extensions.Logging.LogLevel.Information);
        }


        public DbSet<Bank> Banks { get; set; }
        public DbSet<BankDeposit> BankDeposits { get; set; }
        public DbSet<BankWithdraw> BankWithdraws { get; set; }

        //DbSet<Employee> Employees { get; set; }
        //DbSet<EmployeeSalaryMinus> EmployeesSalaryMinus { get; set; }
        //DbSet<EmployeeBorrowItem> EmployeesBorrowItems { get; set; }
        //DbSet<EmployeeBorrowMoney> EmployeesBorrowMonies { get; set; }
        //DbSet<EmployeeSalary> EmployeesSalaries { get; set; }
        public DbSet<Product> Products { get; set; }
        public DbSet<ProductDiscount> ProductDiscounts { get; set; }
        public DbSet<ProductQuickAccess> ProductQuickAccess { get; set; }
        public DbSet<ReceiptVoucher> ReceiptVouchers { get; set; }
        public DbSet<SendVoucher> SendVouchers { get; set; }
        public DbSet<OrderPrintData> OrderPrintData { get; set; }
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
        public DbSet<Core.Entities.Stores.Store> Stores { get; set; }
        public DbSet<Caisse> Caisses { get; set; }
        public DbSet<CaisseDeposit> CaissesDeposits { get; set; }
        public DbSet<CaisseWithdraw> CaissesWithdraws { get; set; }
        public DbSet<CaisseTransfere> CaissesTransferes { get; set; }
        public DbSet<CaisseBankTransfere> CaissesBankTransferes { get; set; }
        public DbSet<sale8cm> sale8cms { get; set; }









        //public DbSet<UserDeserved> UserDeserved { get; set; }
        //public DbSet<UserEmp> UserEmp { get; set; }
        //public DbSet<UserReport> UserReport { get; set; }
        //public DbSet<UserReturn> UserReturn { get; set; }
        //public DbSet<UserSale> UserSale { get; set; }
        //public DbSet<UserSetting> UserSetting { get; set; }
        //public DbSet<UserStockBank> UserStockBank { get; set; }
        //public DbSet<UserSupplier> UserSupplier { get; set; }
    }
}
