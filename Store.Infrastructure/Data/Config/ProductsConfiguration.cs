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
            builder.HasOne(x => x.Category).WithMany().HasForeignKey(x => x.CategoryId);

            builder.Property(p => p.Quentity).HasColumnType("decimal(18,2)");
            builder.Property(p => p.BuyPrice).HasColumnType("decimal(18,2)");
            builder.Property(p => p.SalePrice).HasColumnType("decimal(18,2)");
            builder.Property(p => p.WholesalePrice).HasColumnType("decimal(18,2)");
            builder.Property(p => p.TaxValue).HasColumnType("decimal(18,2)");
            builder.Property(p => p.SalePriceTax).HasColumnType("decimal(18,2)");
            builder.Property(p => p.MinQty).HasColumnType("decimal(18,2)");
            builder.Property(p => p.MaxDiscount).HasColumnType("decimal(18,2)");



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
            builder.HasOne(x => x.Product).WithMany().HasForeignKey(x => x.Pro_ID);
            builder.Property(p => p.Quentity).HasColumnType("decimal(18,2)");

        }
    }
    public class ProductsQuantitieConfiguration : IEntityTypeConfiguration<ProductsQuantitie>
    {
        public void Configure(EntityTypeBuilder<ProductsQuantitie> builder)
        {
            builder.Property(x => x.Id).IsRequired();
            builder.Property(x => x.StoreName).HasMaxLength(50);
            builder.HasKey(x => x.Id);
            builder.HasOne(x => x.Product).WithMany().HasForeignKey(x => x.Pro_ID);
            builder.HasOne(x => x.Store).WithMany().HasForeignKey(x => x.Store_ID);
            builder.Property(p => p.Qty).HasColumnType("decimal(18,2)");
            builder.Property(p => p.Buy_Price).HasColumnType("decimal(18,2)");
            builder.Property(p => p.Sale_PriceTax).HasColumnType("decimal(18,2)");

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
            builder.HasOne(x => x.Product).WithMany().HasForeignKey(x => x.Pro_ID);
            builder.Property(p => p.Quentity).HasColumnType("decimal(18,2)");
            builder.Property(p => p.BuyPrice).HasColumnType("decimal(18,2)");
            builder.Property(p => p.SalePrice).HasColumnType("decimal(18,2)");

        }
    }
    public class ProductDiscountConfiguration : IEntityTypeConfiguration<ProductDiscount>
    {
        public void Configure(EntityTypeBuilder<ProductDiscount> builder)
        {
            builder.Property(x => x.Id).IsRequired();

            builder.HasKey(x => x.Id);
            builder.HasOne(x => x.Product).WithMany().HasForeignKey(x => x.Pro_Id);
            builder.Property(p => p.DiscountValue).HasColumnType("decimal(18,2)");
            builder.Property(p => p.Quentity).HasColumnType("decimal(18,2)");
        }
    }
    public class ProductQuickAccessConfiguration : IEntityTypeConfiguration<ProductQuickAccess>
    {
        public void Configure(EntityTypeBuilder<ProductQuickAccess> builder)
        {
            builder.Property(x => x.Id).IsRequired();
            builder.Property(x => x.ProductName).HasMaxLength(50);
            builder.HasKey(x => x.Id);
            builder.HasOne(x => x.Product).WithMany().HasForeignKey(x => x.Pro_Id);

        }
    }

}
