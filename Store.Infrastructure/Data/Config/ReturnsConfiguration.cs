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
        }
    }
    public class ReturnDetailConfiguration : IEntityTypeConfiguration<ReturnDetail>
    {
        public void Configure(EntityTypeBuilder<ReturnDetail> builder)
        {
            builder.HasKey(x => x.Id);
            builder.HasOne(x => x.Product).WithMany().HasForeignKey(x => x.Pro_ID);
            builder.HasOne(x => x.Returns).WithMany().HasForeignKey(x => x.Order_ID);
        }
    }


}
