using Store.Core.Entities.Employees;

namespace Store.Core.Interfaces
{
    public interface IEmployeesRepository : IGenericRepository<Employee>
    {
        //Task<Category> GetAsync(int id);
    }
    public interface IEmployeeBorrowItemRepository : IGenericRepository<EmployeeBorrowItem>
    {
        //Task<Category> GetAsync(int id);
    }
    public interface IEmployeeBorrowMoneyRepository : IGenericRepository<EmployeeBorrowMoney>
    {
        //Task<Category> GetAsync(int id);
    }
    public interface IEmployeeSalaryRepository : IGenericRepository<EmployeeSalary>
    {
        //Task<Category> GetAsync(int id);
    }
    public interface IEmployeeSalaryMinusRepository : IGenericRepository<EmployeeSalaryMinus>
    {
        //Task<Category> GetAsync(int id);
    }

}
