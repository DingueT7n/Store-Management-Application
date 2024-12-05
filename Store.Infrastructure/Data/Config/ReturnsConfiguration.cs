using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;
using Store.Core.Entities.Returns;

namespace Store.Infrastructure.Data.Config
{
    public class ReturnsConfiguration : IEntityTypeConfiguration<Return>
    {
        public void Configure(EntityTypeBuilder<Return> builder)
        {
            builder.Property(x => x.Id).IsRequired();
            builder.HasKey(x => x.Id);
            builder.Property(p => p.TotalOrder).HasColumnType("decimal(18,2)");
            builder.Property(p => p.PaidUP).HasColumnType("decimal(18,2)");
            builder.Property(p => p.Remain).HasColumnType("decimal(18,2)");
        }
    }
    public class ReturnDetailConfiguration : IEntityTypeConfiguration<ReturnDetail>
    {
        public void Configure(EntityTypeBuilder<ReturnDetail> builder)
        {
            builder.HasKey(x => x.Id);
            builder.HasOne(x => x.Product).WithMany().HasForeignKey(x => x.Pro_ID);
            builder.HasOne(x => x.Returns).WithMany().HasForeignKey(x => x.Order_ID);
            builder.Property(p => p.Qty).HasColumnType("decimal(18,2)");
            builder.Property(p => p.Price).HasColumnType("decimal(18,2)");
            builder.Property(p => p.Total).HasColumnType("decimal(18,2)");
            builder.Property(p => p.TaxValue).HasColumnType("decimal(18,2)");
            builder.Property(p => p.PriceWithTax).HasColumnType("decimal(18,2)");
        }
    }


}
