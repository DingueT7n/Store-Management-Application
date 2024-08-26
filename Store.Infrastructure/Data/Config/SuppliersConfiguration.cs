using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;
using Store.Core.Entities.Suppliers;

namespace Store.Infrastructure.Data.Config
{
    public class SuppliersConfiguration : IEntityTypeConfiguration<Supplier>
    {
        public void Configure(EntityTypeBuilder<Supplier> builder)
        {
            builder.Property(x => x.Id).IsRequired();
            builder.Property(x => x.SupplierName).HasMaxLength(75);
            builder.Property(x => x.PhoneNumber).HasMaxLength(30);
            builder.HasData(
                new Supplier { Id = 1, SupplierName = "Supplier One ", Address = "Ben Smara", PhoneNumber = "0697357397", Notes = "Seeded Data" },
                new Supplier { Id = 2, SupplierName = "Supplier two ", Address = "Mermad", PhoneNumber = "0754653721", Notes = "Seeded Data" },
                new Supplier { Id = 3, SupplierName = "Supplier Three ", Address = "HadjMEssaoud", PhoneNumber = "0697357546", Notes = "Seeded Data" }

                );
        }
    }
    public class SupplierMoneyConfiguration : IEntityTypeConfiguration<SupplierMoney>
    {
        public void Configure(EntityTypeBuilder<SupplierMoney> builder)
        {
            builder.HasKey(bd => new { bd.Order_ID, bd.Sup_ID });
            builder.Property(x => x.SupplierName).HasMaxLength(75);
            builder.HasOne(x => x.Supplier).WithMany().HasForeignKey(x => x.Sup_ID);
            builder.HasOne(x => x.Buy).WithMany().HasForeignKey(x => x.Order_ID);
        }
    }
    public class SupplierReportConfiguration : IEntityTypeConfiguration<SupplierReport>
    {
        public void Configure(EntityTypeBuilder<SupplierReport> builder)
        {
            builder.HasKey(bd => new { bd.Order_ID, bd.Sup_ID });
            builder.Property(x => x.SupplierName).HasMaxLength(75);
            builder.HasOne(x => x.Supplier).WithMany().HasForeignKey(x => x.Sup_ID);
            builder.HasOne(x => x.Buy).WithMany().HasForeignKey(x => x.Order_ID);
        }
    }

}
