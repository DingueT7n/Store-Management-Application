using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;
using Store.Core.Entities.AllDeserved;

namespace Store.Infrastructure.Data.Config
{
    public class DeservedConfiguration : IEntityTypeConfiguration<Deserved>
    {
        public void Configure(EntityTypeBuilder<Deserved> builder)
        {
            builder.Property(x => x.Id);
            builder.HasKey(x => x.Id);
            builder.HasOne(bd => bd.DeservedType).WithMany().HasForeignKey(x => x.TypeId);

        }
    }
    public class DeservedTypeConfiguration : IEntityTypeConfiguration<DeservedType>
    {
        public void Configure(EntityTypeBuilder<DeservedType> builder)
        {
            builder.Property(x => x.Id);
            builder.HasKey(x => x.Id);


        }
    }
    public class TaxesReportTypeConfiguration : IEntityTypeConfiguration<TaxesReport>
    {
        public void Configure(EntityTypeBuilder<TaxesReport> builder)
        {
            builder.Property(x => x.Id);
            builder.HasKey(x => x.Id);
        }
    }

}
