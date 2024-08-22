using Store.Core.Entities.Customers;

namespace Store.Core.Interfaces
{
    public interface ICustomersRepository : IGenericRepository<Customer>
    {

    }
    public interface ICustomerMoneyRepository : IGenericRepository<CustomerMoney>
    {

    }
    public interface ICustomerReportRepository : IGenericRepository<CustomerReport>
    {

    }
}
