using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;
using Store.Core.Entities.Helpers;

namespace Store.Infrastructure.Data.Config
{
    public class RandomBarcodeConfiguration : IEntityTypeConfiguration<RandomBarcode>
    {
        public void Configure(EntityTypeBuilder<RandomBarcode> builder)
        {
            builder.HasNoKey();


        }
    }

}
