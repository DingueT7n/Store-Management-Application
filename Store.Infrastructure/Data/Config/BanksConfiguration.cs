using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;
using Store.Core.Entities.Banks;

namespace Store.Infrastructure.Data.Config
{
    public class BanksConfiguration : IEntityTypeConfiguration<Bank>
    {
        public void Configure(EntityTypeBuilder<Bank> builder)
        {
            builder.HasKey(b => b.Id);
            builder.HasData(
               new Bank { Id = 1, Money = 0 });
        }
    }

    public class BankDepositConfiguration : IEntityTypeConfiguration<BankDeposit>
    {
        public void Configure(EntityTypeBuilder<BankDeposit> builder)
        {
            builder.HasKey(bd => bd.Id);
            builder.Property(x => x.Id).IsRequired();


        }
    }
    public class BankWithdrawConfiguration : IEntityTypeConfiguration<BankWithdraw>
    {
        public void Configure(EntityTypeBuilder<BankWithdraw> builder)
        {
            builder.HasKey(bd => bd.Id);
            builder.Property(x => x.Id).IsRequired();


        }
    }

}
