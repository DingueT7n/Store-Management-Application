using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;
using Store.Core.Entities.Buys;

namespace Store.Infrastructure.Data.Config
{
    public class BuysConfiguration : IEntityTypeConfiguration<Buy>
    {
        public void Configure(EntityTypeBuilder<Buy> builder)
        {
            builder.Ignore(x => x.BuyDetails);
            builder.Property(x => x.Id).IsRequired();
            builder.HasKey(x => x.Id);
            builder.Property(x => x.User_Name).HasMaxLength(50);
            builder.HasOne(x => x.Supplier).WithMany().HasForeignKey(x => x.SupplierId).OnDelete(DeleteBehavior.Restrict);
            builder.Property(p => p.Total).HasColumnType("decimal(18,2)");
            builder.Property(p => p.PaidUP).HasColumnType("decimal(18,2)");
            builder.Property(p => p.Remain).HasColumnType("decimal(18,2)");


        }
    }
    public class BuyDetailConfiguration : IEntityTypeConfiguration<BuyDetail>
    {
        public void Configure(EntityTypeBuilder<BuyDetail> builder)
        {
            builder.HasKey(x => x.Id);

            builder.HasOne(x => x.Supplier).WithMany().HasForeignKey(x => x.Sup_ID).OnDelete(DeleteBehavior.Restrict); ;
            builder.HasOne(x => x.Buy).WithMany().HasForeignKey(x => x.Order_ID).OnDelete(DeleteBehavior.Cascade); ;
            builder.HasOne(x => x.Product).WithMany().HasForeignKey(x => x.Pro_ID).OnDelete(DeleteBehavior.Restrict); ;
            builder.Property(p => p.Total).HasColumnType("decimal(18,2)");
            builder.Property(p => p.Quentity).HasColumnType("decimal(18,2)");
            builder.Property(p => p.Price).HasColumnType("decimal(18,2)");
            builder.Property(p => p.PriceWithTax).HasColumnType("decimal(18,2)");
            builder.Property(p => p.Discount).HasColumnType("decimal(18,2)");
            builder.Property(p => p.TaxValue).HasColumnType("decimal(18,2)");

        }
    }

}
