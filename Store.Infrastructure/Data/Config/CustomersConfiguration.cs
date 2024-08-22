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
                new Customer { Id = 1, CustomerName = "Customer One ", Address = "Ben Smara", PhoneNumber = "0697357397", Notes = "Seeded Data" },
                new Customer { Id = 2, CustomerName = "Customer two ", Address = "Mermad", PhoneNumber = "0754653721", Notes = "Seeded Data" },
                new Customer { Id = 3, CustomerName = "Customer Three ", Address = "HadjMEssaoud", PhoneNumber = "0697357546", Notes = "Seeded Data" }

                );

        }
    }
    public class CustomerMoneyConfiguration : IEntityTypeConfiguration<CustomerMoney>
    {
        public void Configure(EntityTypeBuilder<CustomerMoney> builder)
        {
            builder.HasKey(bd => new { bd.Order_ID, bd.Cust_ID });
            builder.Property(x => x.Cust_Name).HasMaxLength(75);
            builder.HasOne(x => x.Customer).WithMany().HasForeignKey(x => x.Cust_ID);
            builder.HasOne(x => x.Sale).WithMany().HasForeignKey(x => x.Order_ID);


        }
    }
    public class CustomerReportConfiguration : IEntityTypeConfiguration<CustomerReport>
    {
        public void Configure(EntityTypeBuilder<CustomerReport> builder)
        {
            builder.HasKey(bd => new { bd.Order_ID, bd.Cust_ID });
            builder.Property(x => x.Cust_Name).HasMaxLength(75);
            builder.HasOne(x => x.Customer).WithMany().HasForeignKey(x => x.Cust_ID);
            builder.HasOne(x => x.Sale).WithMany().HasForeignKey(x => x.Order_ID);


        }
    }

}
