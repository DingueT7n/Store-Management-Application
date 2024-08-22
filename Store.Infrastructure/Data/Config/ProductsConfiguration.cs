using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;
using Store.Core.Entities.Products;

namespace Store.Infrastructure.Data.Config
{
    public class ProductsConfiguration : IEntityTypeConfiguration<Product>
    {
        public void Configure(EntityTypeBuilder<Product> builder)
        {
            builder.Property(x => x.Id).IsRequired();
            builder.Property(x => x.ProductName).HasMaxLength(50);
            builder.HasKey(x => x.Id);
            builder.HasOne(x => x.Category).WithMany(c => c.Products).HasForeignKey(x => x.CategoryId);

        }
    }
    public class ProductOutStoreConfiguration : IEntityTypeConfiguration<ProductOutStore>
    {
        public void Configure(EntityTypeBuilder<ProductOutStore> builder)
        {
            builder.Property(x => x.Id).IsRequired();
            builder.Property(x => x.ProductName).HasMaxLength(50);
            builder.Property(x => x.StoreName).HasMaxLength(50);
            builder.Property(x => x.Name).HasMaxLength(50);
            builder.HasKey(x => x.Id);
            builder.HasOne(x => x.Product).WithMany(c => c.ProductOutStore).HasForeignKey(x => x.Pro_ID);

        }
    }
    public class ProductsQuantitieConfiguration : IEntityTypeConfiguration<ProductsQuantitie>
    {
        public void Configure(EntityTypeBuilder<ProductsQuantitie> builder)
        {
            builder.Property(x => x.Id).IsRequired();
            builder.Property(x => x.StoreName).HasMaxLength(50);
            builder.HasKey(x => x.Id);
            builder.HasOne(x => x.Product).WithMany(c => c.ProductsQuantitie).HasForeignKey(x => x.Pro_ID);
            builder.HasOne(x => x.Store).WithMany().HasForeignKey(x => x.Store_ID);

        }
    }
    public class ProductTransferConfiguration : IEntityTypeConfiguration<ProductTransfer>
    {
        public void Configure(EntityTypeBuilder<ProductTransfer> builder)
        {
            builder.Property(x => x.Id).IsRequired();
            builder.Property(x => x.StoreFrom).HasMaxLength(50);
            builder.Property(x => x.StoreTo).HasMaxLength(50);
            builder.Property(x => x.Name).HasMaxLength(50);
            builder.HasKey(x => x.Id);
            builder.HasOne(x => x.Product).WithMany(c => c.ProductTransfer).HasForeignKey(x => x.Pro_ID);

        }
    }


}
