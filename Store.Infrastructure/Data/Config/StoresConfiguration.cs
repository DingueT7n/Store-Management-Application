using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;

using Store.Core.Entities.Stores;

namespace Store.Infrastructure.Data.Config
{
    public class StoresConfiguration : IEntityTypeConfiguration<Core.Entities.Stores.Store>
    {
        public void Configure(EntityTypeBuilder<Core.Entities.Stores.Store> builder)
        {
            builder.Property(x => x.Id).IsRequired();
            builder.HasData(

                new Core.Entities.Stores.Store { Id = 1, StoreName = "مخزن رئيسي" });

        }
    }

    public class InventorySessionConfiguration : IEntityTypeConfiguration<InventorySession>
    {
        public void Configure(EntityTypeBuilder<InventorySession> builder)
        {
            builder.HasKey(x => x.Id);

            builder.Property(x => x.PerformedBy)
                .IsRequired()
                .HasMaxLength(100);

            builder.Property(x => x.Notes)
                .HasMaxLength(500);


            builder.HasMany(x => x.InventoryChecks)
                .WithOne(x => x.InventorySession)
                .HasForeignKey(x => x.InventorySessionId)
                .OnDelete(DeleteBehavior.Cascade);

            // Optional Store relationship
            builder.HasOne(x => x.Store)
                .WithMany()
                .HasForeignKey(x => x.StoreId)
                .IsRequired(false)

                .OnDelete(DeleteBehavior.SetNull);

        }
    }

    public class InventoryCheckConfiguration : IEntityTypeConfiguration<InventoryCheck>
    {
        public void Configure(EntityTypeBuilder<InventoryCheck> builder)
        {
            builder.HasKey(x => x.Id);

            builder.Property(x => x.ExpectedQty).HasColumnType("decimal(18,2)");
            builder.Property(x => x.ActualQty).HasColumnType("decimal(18,2)");

            builder.HasOne(x => x.Product)
                .WithMany()
                .HasForeignKey(x => x.ProductId)
                .OnDelete(DeleteBehavior.Restrict);
        }
    }
}
