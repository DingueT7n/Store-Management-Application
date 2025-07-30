using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;
using Store.Core.Entities.Sales;

namespace Store.Infrastructure.Data.Config
{
    public class SalesConfiguration : IEntityTypeConfiguration<Sale>
    {
        public void Configure(EntityTypeBuilder<Sale> builder)
        {
            builder.Property(x => x.Id).IsRequired();
            builder.HasKey(x => x.Id);
            builder.Property(x => x.User_Name).HasMaxLength(50);
            builder.HasOne(x => x.Customer).WithMany().HasForeignKey(x => x.CustomerId);
            builder.Property(p => p.Remain).HasColumnType("decimal(18,2)");
            builder.Property(p => p.TotalOrder).HasColumnType("decimal(18,2)");
            builder.Property(p => p.PaidUP).HasColumnType("decimal(18,2)");

        }
    }
    public class SaleDetailConfiguration : IEntityTypeConfiguration<SaleDetail>
    {
        public void Configure(EntityTypeBuilder<SaleDetail> builder)
        {
            builder.HasKey(bd => bd.Id);

            builder.HasOne(x => x.Customer)
                .WithMany()
                .HasForeignKey(x => x.Cust_ID).OnDelete(DeleteBehavior.Restrict);
            builder.HasOne(x => x.Sale)
                .WithMany()
                .HasForeignKey(x => x.Order_ID).OnDelete(DeleteBehavior.Restrict);
            builder.HasOne(x => x.Product)
                .WithMany()
                .HasForeignKey(x => x.Pro_ID).OnDelete(DeleteBehavior.Restrict);

            builder.Property(p => p.Total).HasColumnType("decimal(18,2)");
            builder.Property(p => p.Quentity).HasColumnType("decimal(18,2)");
            builder.Property(p => p.Price).HasColumnType("decimal(18,2)");
            builder.Property(p => p.PriceWithTax).HasColumnType("decimal(18,2)");
            builder.Property(p => p.Discount).HasColumnType("decimal(18,2)");
            builder.Property(p => p.TaxValue).HasColumnType("decimal(18,2)");
        }
    }
    public class ProformaInvoiceConfiguration : IEntityTypeConfiguration<ProformaInvoice>
    {
        public void Configure(EntityTypeBuilder<ProformaInvoice> builder)
        {
            builder.HasKey(bd => bd.Id);

            builder.HasMany(p => p.Details)
                .WithOne(i => i.ProformaInvoice)
                .HasForeignKey(i => i.ProformaId)
                .OnDelete(DeleteBehavior.Cascade);
            builder.HasOne(p => p.Customer)
                    .WithMany() // or .WithMany(c => c.ProformaInvoices) if you want
                    .HasForeignKey(p => p.CustomerId);

            builder.HasOne(x => x.Customer)
                .WithMany()
                .HasForeignKey(x => x.CustomerId).OnDelete(DeleteBehavior.Restrict);
            builder.Property(p => p.TotalFaacture).HasColumnType("decimal(18,2)");

        }
    }
    public class ProformaInvoiceDetailsConfiguration : IEntityTypeConfiguration<ProformaInvoiceDetails>
    {
        public void Configure(EntityTypeBuilder<ProformaInvoiceDetails> builder)
        {
            builder.HasKey(bd => bd.Id);


            builder.HasOne(p => p.Product)
                    .WithMany() // or .WithMany(c => c.ProformaInvoices) if you want
                    .HasForeignKey(p => p.ProductId);

            builder.HasOne(x => x.ProformaInvoice)
                .WithMany()
                .HasForeignKey(x => x.ProformaId).OnDelete(DeleteBehavior.Restrict);

            builder.Property(p => p.Quentity).HasColumnType("decimal(18,2)");
            builder.Property(p => p.Total).HasColumnType("decimal(18,2)");
            builder.Property(p => p.Discount).HasColumnType("decimal(18,2)");
            builder.Property(p => p.UnitPrice).HasColumnType("decimal(18,2)");

        }
    }
    public class SaleProfitConfiguration : IEntityTypeConfiguration<SaleProfit>
    {
        public void Configure(EntityTypeBuilder<SaleProfit> builder)
        {
            builder.HasKey(bd => bd.Id);
            builder.HasOne(x => x.Sale).WithMany().HasForeignKey(x => x.Order_ID);
            builder.HasOne(x => x.Product).WithMany().HasForeignKey(x => x.Pro_ID);
            builder.Property(p => p.Total).HasColumnType("decimal(18,2)");
            builder.Property(p => p.Quentity).HasColumnType("decimal(18,2)");
            builder.Property(p => p.Price).HasColumnType("decimal(18,2)");
            builder.Property(p => p.Price_Tax).HasColumnType("decimal(18,2)");
            builder.Property(p => p.Discount).HasColumnType("decimal(18,2)");
            builder.Property(p => p.Buy_Price).HasColumnType("decimal(18,2)");
            builder.Property(p => p.Tax_Value).HasColumnType("decimal(18,2)");
        }
    }
    public class sale8cmConfiguration : IEntityTypeConfiguration<sale8cm>
    {
        public void Configure(EntityTypeBuilder<sale8cm> builder)
        {
            builder.HasNoKey();
            builder.Property(p => p.Total).HasColumnType("decimal(18,2)");
            builder.Property(p => p.Quentity).HasColumnType("decimal(18,2)");
            builder.Property(p => p.Price).HasColumnType("decimal(18,2)");
            builder.Property(p => p.PaidUP).HasColumnType("decimal(18,2)");
            builder.Property(p => p.Discount).HasColumnType("decimal(18,2)");
            builder.Property(p => p.Remain).HasColumnType("decimal(18,2)");
            builder.Property(p => p.TotalOrder).HasColumnType("decimal(18,2)");
        }
    }


}
