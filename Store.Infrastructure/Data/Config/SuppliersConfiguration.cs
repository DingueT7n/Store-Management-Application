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
              new Supplier { Id = 1, SupplierName = "مورد سعيدة", Address = "بوهراوة", PhoneNumber = "0697357397", Notes = "معلومات مشحونة", MaxDebtAllowed = 400, TotalDebts = 0 },
              new Supplier { Id = 2, SupplierName = "مورد الزعيم", Address = "مراماد", PhoneNumber = "0754653721", Notes = "معلومات مشحونة", MaxDebtAllowed = 5000, TotalDebts = 0 },
              new Supplier { Id = 3, SupplierName = "مورد القولية", Address = "العطف", PhoneNumber = "0697357546", Notes = "معلومات مشحونة", MaxDebtAllowed = 5500, TotalDebts = 0 }

              );
        }
    }
    public class SupplierMoneyConfiguration : IEntityTypeConfiguration<SupplierMoney>
    {
        public void Configure(EntityTypeBuilder<SupplierMoney> builder)
        {
            builder.HasKey(bd => bd.Id);
            builder.Property(x => x.SupplierName).HasMaxLength(75);
            builder.HasOne(x => x.Supplier).WithMany().HasForeignKey(x => x.Sup_ID);
            builder.HasOne(x => x.Buy).WithMany().HasForeignKey(x => x.Order_ID);
        }
    }
    public class SupplierReportConfiguration : IEntityTypeConfiguration<SupplierReport>
    {
        public void Configure(EntityTypeBuilder<SupplierReport> builder)
        {
            builder.HasKey(bd => bd.Id);
            builder.Property(x => x.SupplierName).HasMaxLength(75);
            builder.HasOne(x => x.Supplier).WithMany().HasForeignKey(x => x.Sup_ID);
            builder.HasOne(x => x.Buy).WithMany().HasForeignKey(x => x.Order_ID);
        }
    }

}
