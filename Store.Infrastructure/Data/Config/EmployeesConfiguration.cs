using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;
using Store.Core.Entities.Employees;

namespace Store.Infrastructure.Data.Config
{
    public class EmployeesConfiguration : IEntityTypeConfiguration<Employee>
    {
        public void Configure(EntityTypeBuilder<Employee> builder)
        {
            builder.Property(x => x.Id).IsRequired();
            builder.Property(x => x.Email).HasMaxLength(75);
            builder.Property(p => p.Salary).HasColumnType("decimal(18,2)");
        }
    }
    public class EmployeesBorrowItemsConfiguration : IEntityTypeConfiguration<EmployeeBorrowItem>
    {
        public void Configure(EntityTypeBuilder<EmployeeBorrowItem> builder)
        {
            builder.Property(x => x.Id).IsRequired();
            builder.HasOne(x => x.Employee).WithMany().HasForeignKey(x => x.Emp_Id);
            builder.HasOne(x => x.Product).WithMany().HasForeignKey(x => x.Item_Id);
            builder.Property(p => p.Quentity).HasColumnType("decimal(18,2)");

        }
    }
    public class EmployeesBorrowMoneysConfiguration : IEntityTypeConfiguration<EmployeeBorrowMoney>
    {
        public void Configure(EntityTypeBuilder<EmployeeBorrowMoney> builder)
        {
            builder.Property(x => x.Id).IsRequired();
            builder.HasOne(x => x.Employee).WithMany().HasForeignKey(x => x.Emp_Id);
            builder.Property(p => p.Value).HasColumnType("decimal(18,2)");
        }
    }
    public class EmployeeSalarysConfiguration : IEntityTypeConfiguration<EmployeeSalary>
    {
        public void Configure(EntityTypeBuilder<EmployeeSalary> builder)
        {
            builder.Property(x => x.Id).IsRequired();
            builder.HasOne(x => x.Employee).WithMany().HasForeignKey(x => x.Emp_ID);
            builder.Property(p => p.TotalSalary).HasColumnType("decimal(18,2)");
            builder.Property(p => p.TotalBorrow).HasColumnType("decimal(18,2)");
            builder.Property(p => p.NetSalary).HasColumnType("decimal(18,2)");


        }
    }
    public class EmployeeSalaryMinusConfiguration : IEntityTypeConfiguration<EmployeeSalaryMinus>
    {
        public void Configure(EntityTypeBuilder<EmployeeSalaryMinus> builder)
        {
            builder.Property(x => x.Id).IsRequired();
            builder.HasOne(x => x.Employee).WithMany().HasForeignKey(x => x.Emp_ID);
            builder.Property(p => p.Price).HasColumnType("decimal(18,2)");

        }
    }

}
