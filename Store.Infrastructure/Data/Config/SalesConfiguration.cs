using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;
using Store.Core.Entities.Sales;

namespace Store.Infrastructure.Data.Config
{
    public class SalesConfiguration : IEntityTypeConfiguration<Sale>
    {
        public void Configure(EntityTypeBuilder<Sale> builder)
        {
            builder.Property(x => x.Id).IsRequired();
            builder.HasKey(x => x.Id);
            builder.Property(x => x.User_Name).HasMaxLength(50);
            builder.HasOne(x => x.Customer).WithMany().HasForeignKey(x => x.CustomerId);
        }
    }
    public class SaleDetailConfiguration : IEntityTypeConfiguration<SaleDetail>
    {
        public void Configure(EntityTypeBuilder<SaleDetail> builder)
        {
            builder.HasKey(bd => bd.Id);

            builder.HasOne(x => x.Customer)
                .WithMany()
                .HasForeignKey(x => x.Cust_ID).OnDelete(DeleteBehavior.Restrict);
            builder.HasOne(x => x.Sale)
                .WithMany()
                .HasForeignKey(x => x.Order_ID).OnDelete(DeleteBehavior.Restrict);
            builder.HasOne(x => x.Product)
                .WithMany()
                .HasForeignKey(x => x.Pro_ID).OnDelete(DeleteBehavior.Restrict);
        }
    }
    public class SaleProfitConfiguration : IEntityTypeConfiguration<SaleProfit>
    {
        public void Configure(EntityTypeBuilder<SaleProfit> builder)
        {
            builder.HasKey(bd => bd.Id);
            builder.HasOne(x => x.Sale).WithMany().HasForeignKey(x => x.Order_ID);
            builder.HasOne(x => x.Product).WithMany().HasForeignKey(x => x.Pro_ID);
        }
    }


}
