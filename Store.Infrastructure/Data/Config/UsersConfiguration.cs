using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;
using Store.Core.Entities.Users;

namespace Store.Infrastructure.Data.Config
{
    public class UsersConfiguration : IEntityTypeConfiguration<User>
    {
        public void Configure(EntityTypeBuilder<User> builder)
        {
            builder.Property(x => x.Id).IsRequired();

            builder.Property(p => p.UserProfit).HasColumnType("decimal(18,2)");
        }
    }
    public class UserSettingsConfiguration : IEntityTypeConfiguration<UserSetting>
    {
        public void Configure(EntityTypeBuilder<UserSetting> builder)
        {
            builder.Property(x => x.Id).IsRequired();
            builder.HasOne(bd => bd.User).WithMany().HasForeignKey(bd => bd.User_Id);


        }
    }
    public class UserCustomersConfiguration : IEntityTypeConfiguration<UserCustomer>
    {
        public void Configure(EntityTypeBuilder<UserCustomer> builder)
        {
            builder.Property(x => x.Id).IsRequired();
            builder.HasOne(bd => bd.User).WithMany().HasForeignKey(bd => bd.User_Id);


        }
    }
    public class UserProductsAndStoresConfiguration : IEntityTypeConfiguration<UserProductAndStore>
    {
        public void Configure(EntityTypeBuilder<UserProductAndStore> builder)
        {
            builder.Property(x => x.Id).IsRequired();
            builder.HasOne(bd => bd.User).WithMany().HasForeignKey(bd => bd.User_Id);


        }
    }
    public class UserSuppliersConfiguration : IEntityTypeConfiguration<UserSupplier>
    {
        public void Configure(EntityTypeBuilder<UserSupplier> builder)
        {
            builder.Property(x => x.Id).IsRequired();
            builder.HasOne(bd => bd.User).WithMany().HasForeignKey(bd => bd.User_Id);


        }
    }
    public class UserBuysConfiguration : IEntityTypeConfiguration<UserBuy>
    {
        public void Configure(EntityTypeBuilder<UserBuy> builder)
        {
            builder.Property(x => x.Id).IsRequired();
            builder.HasOne(bd => bd.User).WithMany().HasForeignKey(bd => bd.User_Id);


        }
    }
    public class UserSalesConfiguration : IEntityTypeConfiguration<UserSale>
    {
        public void Configure(EntityTypeBuilder<UserSale> builder)
        {
            builder.Property(x => x.Id).IsRequired();
            builder.HasOne(bd => bd.User).WithMany().HasForeignKey(bd => bd.User_Id);


        }
    }
    public class UserCaissesAndBanksConfiguration : IEntityTypeConfiguration<UserCaisseAndBank>
    {
        public void Configure(EntityTypeBuilder<UserCaisseAndBank> builder)
        {
            builder.Property(x => x.Id).IsRequired();
            builder.HasOne(bd => bd.User).WithMany().HasForeignKey(bd => bd.User_Id);


        }
    }
    public class UserDeservedsAndTaxsConfiguration : IEntityTypeConfiguration<UserDeservedAndTax>
    {
        public void Configure(EntityTypeBuilder<UserDeservedAndTax> builder)
        {
            builder.Property(x => x.Id).IsRequired();
            builder.HasOne(bd => bd.User).WithMany().HasForeignKey(bd => bd.User_Id);


        }
    }
    public class UserRefundsAndTaxsConfiguration : IEntityTypeConfiguration<UserRefund>
    {
        public void Configure(EntityTypeBuilder<UserRefund> builder)
        {
            builder.Property(x => x.Id).IsRequired();
            builder.HasOne(bd => bd.User).WithMany().HasForeignKey(bd => bd.User_Id);


        }
    }
    public class UserEmployeesConfiguration : IEntityTypeConfiguration<UserEmployee>
    {
        public void Configure(EntityTypeBuilder<UserEmployee> builder)
        {
            builder.Property(x => x.Id).IsRequired();
            builder.HasOne(bd => bd.User).WithMany().HasForeignKey(bd => bd.User_Id);


        }
    }

}
