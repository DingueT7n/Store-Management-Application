using Store.Core.Entities.Employees;
using Store.Core.Interfaces;
using Store.Infrastructure.Data;

namespace Store.Infrastructure.Repositories
{
    public class EmployeesRepository : GenericRepository<Employee>, IEmployeesRepository
    {
        public EmployeesRepository(ApplicationDbContext context) : base(context)
        {
        }
    }

    public class EmployeeBorrowItemRepository : GenericRepository<EmployeeBorrowItem>, IEmployeeBorrowItemRepository
    {
        public EmployeeBorrowItemRepository(ApplicationDbContext context) : base(context)
        {
        }
    }
    public class EmployeeBorrowMoneyRepository : GenericRepository<EmployeeBorrowMoney>, IEmployeeBorrowMoneyRepository
    {
        public EmployeeBorrowMoneyRepository(ApplicationDbContext context) : base(context)
        {
        }
    }
    public class EmployeeSalaryRepository : GenericRepository<EmployeeSalary>, IEmployeeSalaryRepository
    {
        public EmployeeSalaryRepository(ApplicationDbContext context) : base(context)
        {
        }
    }
    public class EmployeeSalaryMinusRepository : GenericRepository<EmployeeSalaryMinus>, IEmployeeSalaryMinusRepository
    {
        public EmployeeSalaryMinusRepository(ApplicationDbContext context) : base(context)
        {
        }
    }
}
