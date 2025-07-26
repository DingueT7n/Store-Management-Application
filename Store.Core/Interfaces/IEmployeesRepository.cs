using Store.Core.Entities.Employees;

namespace Store.Core.Interfaces
{
    public interface IEmployeesRepository : IGenericRepository<Employee>
    {
        //Task<Category> GetAsync(int id);
    }
    public interface IEmployeeBorrowItemRepository : IGenericRepository<EmployeeBorrowItem>
    {
        public List<EmployeeBorrowItem> GetAllEmpBorrowsItem(string t1, string barcode, DateTime dtpFrom, DateTime dtpTo);
        //Task<Category> GetAsync(int id);
    }
    public interface IEmployeeBorrowMoneyRepository : IGenericRepository<EmployeeBorrowMoney>
    {
        public List<EmployeeBorrowMoney> GetAllEmpBorrowsItem(string t1, string barcode, DateTime dtpFrom, DateTime dtpTo);
        //Task<Category> GetAsync(int id);
    }
    public interface IEmployeeSalaryRepository : IGenericRepository<EmployeeSalary>
    {
        public List<EmployeeSalary> GetAllEmpBorrowsItem(string t1, string barcode, DateTime dtpFrom, DateTime dtpTo);
        //Task<Category> GetAsync(int id);
    }
    public interface IEmployeeSalaryMinusRepository : IGenericRepository<EmployeeSalaryMinus>
    {
        //Task<Category> GetAsync(int id);
    }

}
