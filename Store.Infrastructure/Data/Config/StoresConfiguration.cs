using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;

namespace Store.Infrastructure.Data.Config
{
    public class StoresConfiguration : IEntityTypeConfiguration<Core.Entities.Stores.Store>
    {
        public void Configure(EntityTypeBuilder<Core.Entities.Stores.Store> builder)
        {
            builder.Property(x => x.Id).IsRequired();


        }
    }


}
