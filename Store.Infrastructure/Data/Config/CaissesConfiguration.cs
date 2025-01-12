using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;
using Store.Core.Entities.Caisses;

namespace Store.Infrastructure.Data.Config
{
    public class CaissesConfiguration : IEntityTypeConfiguration<Caisse>
    {
        public void Configure(EntityTypeBuilder<Caisse> builder)
        {
            builder.Property(x => x.Id).IsRequired();
            builder.HasKey(x => x.Id);

            builder.Property(x => x.CaisseName).HasMaxLength(50);

            builder.Property(p => p.MoneyinCaisse).HasColumnType("decimal(18,2)");

            builder.HasData(
                new Caisse { Id = 1, CaisseName = "الصندوق الأول", MoneyinCaisse = 0 },
                     new Caisse { Id = 2, CaisseName = "الصندوق الثاني", MoneyinCaisse = 0 },
                     new Caisse { Id = 3, CaisseName = "الصندوق الثالث", MoneyinCaisse = 0 }
                );

        }
    }
    public class CaisseDepositConfiguration : IEntityTypeConfiguration<CaisseDeposit>
    {
        public void Configure(EntityTypeBuilder<CaisseDeposit> builder)
        {
            builder.Property(x => x.Id).IsRequired();
            builder.HasKey(x => x.Id);
            builder.HasOne(bd => bd.Caisse).WithMany().HasForeignKey(bd => bd.Caisse_ID);
            builder.Property(p => p.Money).HasColumnType("decimal(18,2)");


        }
    }
    public class CaisseWithdrawConfiguration : IEntityTypeConfiguration<CaisseWithdraw>
    {
        public void Configure(EntityTypeBuilder<CaisseWithdraw> builder)
        {
            builder.Property(x => x.Id).IsRequired();
            builder.HasKey(x => x.Id);
            builder.HasOne(bd => bd.Caisse).WithMany().HasForeignKey(bd => bd.Caisse_ID);
            builder.Property(p => p.Money).HasColumnType("decimal(18,2)");


        }
    }
    public class CaisseBankTransfereConfiguration : IEntityTypeConfiguration<CaisseBankTransfere>
    {
        public void Configure(EntityTypeBuilder<CaisseBankTransfere> builder)
        {
            builder.Property(x => x.Id).IsRequired();
            builder.HasKey(x => x.Id);
            builder.Property(p => p.Money).HasColumnType("decimal(18,2)");



        }
    }
    public class CaisseTransfereConfiguration : IEntityTypeConfiguration<CaisseTransfere>
    {
        public void Configure(EntityTypeBuilder<CaisseTransfere> builder)
        {
            builder.Property(x => x.Id).IsRequired();
            builder.HasKey(x => x.Id);
            builder.HasOne(bd => bd.CaisseFrom).WithMany().HasForeignKey(bd => bd.Caisse_From).OnDelete(DeleteBehavior.Restrict);
            builder.HasOne(bd => bd.CaisseTo).WithMany().HasForeignKey(bd => bd.Caisse_To);
            builder.Property(p => p.Money).HasColumnType("decimal(18,2)");



        }
    }
    public class CaisseStatusDetailConfiguration : IEntityTypeConfiguration<CaisseStatusDetail>
    {
        public void Configure(EntityTypeBuilder<CaisseStatusDetail> builder)
        {
            builder.Property(x => x.Id).IsRequired();
            builder.HasKey(x => x.Id);
            builder.HasOne(bd => bd.Caisse).WithMany().HasForeignKey(bd => bd.CaisseId).OnDelete(DeleteBehavior.Restrict);

            builder.Property(p => p.MoneyBeforeInCaisse).HasColumnType("decimal(18,2)");
            builder.Property(p => p.MoneyBefore).HasColumnType("decimal(18,2)");
            builder.Property(p => p.MoneyAfterInCaisse).HasColumnType("decimal(18,2)");
            builder.Property(p => p.MoneyAfter).HasColumnType("decimal(18,2)");
        }
    }
    public class CaisseOperationConfiguration : IEntityTypeConfiguration<CaisseOperation>
    {
        public void Configure(EntityTypeBuilder<CaisseOperation> builder)
        {
            builder.Property(x => x.Id).IsRequired();
            builder.HasKey(x => x.Id);
            builder.HasOne(bd => bd.CaisseStatusDetail).WithMany().HasForeignKey(bd => bd.CaisseStatusDetailId).OnDelete(DeleteBehavior.Restrict);
        }
    }

}
