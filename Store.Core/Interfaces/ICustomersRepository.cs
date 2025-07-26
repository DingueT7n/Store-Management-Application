using Store.Core.Entities.Customers;

namespace Store.Core.Interfaces
{
    public interface ICustomersRepository : IGenericRepository<Customer>
    {
        public List<Customer> SearchAll(string searchIteam);

    }
    public interface ICustomerMoneyRepository : IGenericRepository<CustomerMoney>
    {
        public List<CustomerMoney> SearchAll(string searchIteam);
        public bool DeleteFacture(string order_Id, string cust_Id, string price);
        public bool TransactionOfCustomerDebt(string order_Id, string cust_Id, string price, string Cust_Name, DateTime date);
        public bool UpdateFacture(string order_Id, string cust_Id, string price, string PayedValue);
        public bool TransactionOfEditingCustomerDebt(string order_Id, string cust_Id, string price, string Cust_Name, string PayedValue, DateTime date);

    }
    public interface ICustomerReportRepository : IGenericRepository<CustomerReport>
    {
        public Task<CustomerReportDto> GetAllData(int skip, int take);
        public Task<CustomerReportDto> SearchBoth(string searchItem, DateTime fromDate, DateTime toDate, int take, int skip);
        public Task<CustomerReportDto> SearchOnlyDate(DateTime fromDate, DateTime toDate, int take, int skip);
        public Task<CustomerReportDto> SearchOnlyCustomer(string searchItem, int take, int skip);

    }
}
