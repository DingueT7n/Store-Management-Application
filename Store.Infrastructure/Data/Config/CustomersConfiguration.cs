using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;
using Store.Core.Entities.Customers;

namespace Store.Infrastructure.Data.Config
{
    public class CustomersConfiguration : IEntityTypeConfiguration<Customer>
    {
        public void Configure(EntityTypeBuilder<Customer> builder)
        {
            builder.Property(x => x.Id).IsRequired();
            builder.Property(x => x.CustomerName).HasMaxLength(75);
            builder.Property(x => x.PhoneNumber).HasMaxLength(30);
            builder.HasData(
                new Customer { Id = 1, CustomerName = "قربوز علاء", Address = "بن سمارة", PhoneNumber = "0697357397", Notes = "معلومات مشحونة", MaxDebtAllowed = 0, TotalDebts = 0 },
                new Customer { Id = 2, CustomerName = "بن خليفة", Address = "مرماد", PhoneNumber = "0754653721", Notes = "معلومات مشحونة", MaxDebtAllowed = 0, TotalDebts = 0 },
                new Customer { Id = 3, CustomerName = "دوادي", Address = "حاج مسعود", PhoneNumber = "0697357546", Notes = "معلومات مشحونة", MaxDebtAllowed = 0, TotalDebts = 0 },
                new Customer { Id = 4, CustomerName = "مشتري عادي", Address = "", PhoneNumber = "", Notes = "معلومات مشحونة", MaxDebtAllowed = 0, TotalDebts = 0 }
                );

        }
    }
    public class CustomerMoneyConfiguration : IEntityTypeConfiguration<CustomerMoney>
    {
        public void Configure(EntityTypeBuilder<CustomerMoney> builder)
        {
            builder.HasKey(bd => bd.Id);
            builder.Property(x => x.Cust_Name).HasMaxLength(75);
            builder.HasOne(x => x.Customer).WithMany().HasForeignKey(x => x.Cust_ID);
            builder.HasOne(x => x.Sale).WithMany().HasForeignKey(x => x.Order_ID).OnDelete(DeleteBehavior.Cascade);

        }
    }
    public class CustomerReportConfiguration : IEntityTypeConfiguration<CustomerReport>
    {
        public void Configure(EntityTypeBuilder<CustomerReport> builder)
        {
            builder.HasKey(bd => bd.Id);
            builder.Property(x => x.Cust_Name).HasMaxLength(75);
            builder.HasOne(x => x.Customer).WithMany().HasForeignKey(x => x.Cust_ID);
            builder.HasOne(x => x.Sale).WithMany().HasForeignKey(x => x.Order_ID).OnDelete(DeleteBehavior.Cascade);


        }
    }

}
