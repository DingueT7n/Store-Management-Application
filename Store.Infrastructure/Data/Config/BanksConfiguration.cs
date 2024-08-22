using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;
using Store.Core.Entities.Banks;

namespace Store.Infrastructure.Data.Config
{
    public class BanksConfiguration : IEntityTypeConfiguration<Bank>
    {
        public void Configure(EntityTypeBuilder<Bank> builder)
        {
            builder.HasNoKey();


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
