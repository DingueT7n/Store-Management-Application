using Store.Core.Entities.Customers;
using Store.Core.Interfaces;
using Store.Infrastructure.Data;

namespace Store.Infrastructure.Repositories
{
    public class CustomersRepository : GenericRepository<Customer>, ICustomersRepository
    {
        public CustomersRepository(ApplicationDbContext context) : base(context)
        {
        }
        public List<Customer> SearchAll(string searchIteam)
        {

            try
            {
                return _context.Customers.Where(x => x.Id.ToString() == searchIteam ||
                x.CustomerName.ToString().Contains(searchIteam) ||
                x.Address.Contains(searchIteam) ||
                x.TotalDebts.ToString() == (searchIteam) ||
                x.Notes.Contains(searchIteam)

                )
                    .OrderBy(x => x.CustomerName).ToList();

            }
            catch
            {
                return new List<Customer>();
            }
        }
    }
    public class CustomerMoneyRepository : GenericRepository<CustomerMoney>, ICustomerMoneyRepository
    {
        public CustomerMoneyRepository(ApplicationDbContext context) : base(context)
        {
        }
    }
    public class CustomerReportRepository : GenericRepository<CustomerReport>, ICustomerReportRepository
    {
        public CustomerReportRepository(ApplicationDbContext context) : base(context)
        {
        }
    }
}
