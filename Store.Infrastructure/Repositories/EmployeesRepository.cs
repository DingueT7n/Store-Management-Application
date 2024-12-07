using Microsoft.EntityFrameworkCore;
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
        public List<EmployeeBorrowItem> GetAllEmpBorrowsItem(string t1, string barcode, DateTime dtpFrom, DateTime dtpTo)
        {
            try
            {
                var allTransfers = _context.EmployeesBorrowItems
                      .Include(x => x.Product)
                      .Include(x => x.Employee)
                      .AsEnumerable();
                if (barcode != string.Empty) allTransfers = allTransfers.Where(x => x.Product.CodeBar == barcode);
                if (t1 != string.Empty)
                    allTransfers = allTransfers.Where(x => x.Employee.EmployeeName == t1);

                allTransfers = allTransfers.Where(x => x.Date >= dtpFrom && x.Date <= dtpTo)
                     ;

                return allTransfers.ToList();
            }
            catch (Exception ex)
            {

                throw new Exception("Error retrieving the buyFactures", ex);
            }
        }
        public EmployeeBorrowItemRepository(ApplicationDbContext context) : base(context)
        {
        }
    }
    public class EmployeeBorrowMoneyRepository : GenericRepository<EmployeeBorrowMoney>, IEmployeeBorrowMoneyRepository
    {
        public List<EmployeeBorrowMoney> GetAllEmpBorrowsItem(string t1, string barcode, DateTime dtpFrom, DateTime dtpTo)
        {
            try
            {
                var allTransfers = _context.EmployeesBorrowMonies
                    .Include(x => x.Employee)
                      .AsEnumerable();
                if (barcode != string.Empty) allTransfers = allTransfers.Where(x => x.BorrowTo == barcode);
                if (t1 != string.Empty)
                    allTransfers = allTransfers.Where(x => x.Employee is not null && x.Employee.EmployeeName == t1);

                allTransfers = allTransfers.Where(x => x.OrderDate >= dtpFrom && x.OrderDate <= dtpTo)
                     ;

                return allTransfers.ToList();
            }
            catch (Exception ex)
            {

                throw new Exception("Error retrieving the buyFactures", ex);
            }
        }
        public EmployeeBorrowMoneyRepository(ApplicationDbContext context) : base(context)
        {
        }
    }
    public class EmployeeSalaryRepository : GenericRepository<EmployeeSalary>, IEmployeeSalaryRepository
    {
        public List<EmployeeSalary> GetAllEmpBorrowsItem(string t1, string barcode, DateTime dtpFrom, DateTime dtpTo)
        {
            try
            {
                var allTransfers = _context.EmployeesSalaries
                      .Include(x => x.Employee)

                      .AsEnumerable();
                if (barcode != string.Empty) allTransfers = allTransfers.Where(x => x.Employee.EmployeeName == barcode);
                if (t1 != string.Empty)
                    allTransfers = allTransfers.Where(x => x.Employee.EmployeeName == t1);

                allTransfers = allTransfers.Where(x => x.OrderDate >= dtpFrom && x.OrderDate <= dtpTo)
                     ;

                return allTransfers.ToList();
            }
            catch (Exception ex)
            {

                throw new Exception("Error retrieving the buyFactures", ex);
            }
        }
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
