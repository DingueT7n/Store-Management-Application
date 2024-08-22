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
