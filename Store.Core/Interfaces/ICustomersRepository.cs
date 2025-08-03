using Store.Core.Entities.Customers;

namespace Store.Core.Interfaces
{
    public interface ICustomersRepository : IGenericRepository<Customer>
    {
        public Task<List<Customer>> SearchAll(string searchIteam);

    }
    public interface ICustomerMoneyRepository : IGenericRepository<CustomerMoney>
    {
        public Task<List<CustomerMoney>> SearchAll(string searchIteam);
        public Task<bool> DeleteFacture(string order_Id, string cust_Id, string price);
        public Task<bool> TransactionOfCustomerDebt(string order_Id, string cust_Id, string price, string Cust_Name, DateTime date);
        public Task<bool> UpdateFacture(string order_Id, string cust_Id, string price, string PayedValue);
        public Task<bool> TransactionOfEditingCustomerDebt(string order_Id, string cust_Id, string price, string Cust_Name, string PayedValue, DateTime date);

    }
    public interface ICustomerReportRepository : IGenericRepository<CustomerReport>
    {
        public Task<CustomerReportDto> GetAllData(int skip, int take);
        public Task<CustomerReportDto> SearchBoth(string searchItem, DateTime fromDate, DateTime toDate, int take, int skip);
        public Task<CustomerReportDto> SearchOnlyDate(DateTime fromDate, DateTime toDate, int take, int skip);
        public Task<CustomerReportDto> SearchOnlyCustomer(string searchItem, int take, int skip);

    }
}
