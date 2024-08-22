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

        }
    }
    public class CaisseDepositConfiguration : IEntityTypeConfiguration<CaisseDeposit>
    {
        public void Configure(EntityTypeBuilder<CaisseDeposit> builder)
        {
            builder.Property(x => x.Id).IsRequired();
            builder.HasKey(x => x.Id);
            builder.HasOne(bd => bd.Caisse).WithMany().HasForeignKey(bd => bd.Caisse_ID);

        }
    }
    public class CaisseWithdrawConfiguration : IEntityTypeConfiguration<CaisseWithdraw>
    {
        public void Configure(EntityTypeBuilder<CaisseWithdraw> builder)
        {
            builder.Property(x => x.Id).IsRequired();
            builder.HasKey(x => x.Id);
            builder.HasOne(bd => bd.Caisse).WithMany().HasForeignKey(bd => bd.Caisse_ID);

        }
    }
    public class CaisseBankTransfereConfiguration : IEntityTypeConfiguration<CaisseBankTransfere>
    {
        public void Configure(EntityTypeBuilder<CaisseBankTransfere> builder)
        {
            builder.Property(x => x.Id).IsRequired();
            builder.HasKey(x => x.Id);


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


        }
    }

}
