using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;
using Store.Core.Entities.Buys;

namespace Store.Infrastructure.Data.Config
{
    public class BuysConfiguration : IEntityTypeConfiguration<Buy>
    {
        public void Configure(EntityTypeBuilder<Buy> builder)
        {
            builder.Property(x => x.Id).IsRequired();
            builder.HasKey(x => x.Id);
            builder.Property(x => x.User_Name).HasMaxLength(50);
            builder.HasOne(x => x.Supplier).WithMany().HasForeignKey(x => x.SupplierId);

        }
    }
    public class BuyDetailConfiguration : IEntityTypeConfiguration<BuyDetail>
    {
        public void Configure(EntityTypeBuilder<BuyDetail> builder)
        {
            builder.HasKey(bd => new { bd.Pro_ID, bd.Sup_ID, bd.Order_ID });

            builder.HasOne(x => x.Supplier).WithMany().HasForeignKey(x => x.Sup_ID);
            builder.HasOne(x => x.Buy).WithMany().HasForeignKey(x => x.Order_ID);
            builder.HasOne(x => x.Product).WithMany().HasForeignKey(x => x.Pro_ID);

        }
    }

}
