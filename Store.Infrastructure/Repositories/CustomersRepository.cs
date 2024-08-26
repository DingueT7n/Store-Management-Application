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
        public List<CustomerMoney> SearchAll(string searchIteam)
        {

            try
            {
                return _context.CustomersMoneys.Where(x =>
                x.Cust_Name.ToString().Contains(searchIteam) ||
                x.Price.ToString() == (searchIteam)
                )
                    .OrderBy(x => x.Id).ToList();

            }
            catch
            {
                return new List<CustomerMoney>();
            }
        }

        public bool DeleteFacture(string order_Id, string cust_Id, string price)
        {

            try
            {
                var customerMoney = _context.CustomersMoneys.FirstOrDefault(x =>
                  x.Cust_ID.ToString() == order_Id && x.Order_ID.ToString() == order_Id &&
                  x.Price.ToString() == (price)
                  );
                _context.Remove(customerMoney);
                _context.SaveChanges();
                return true;

            }
            catch
            {
                return false;
            }
        }

        float ConvertToFloat(string value)
        {
            float quantity;
            if (float.TryParse(value, out quantity))
            {
                return quantity;
            }
            return quantity;
        }
        public bool TransactionOfCustomerDebt(string order_Id, string cust_Id, string price, string Cust_Name, DateTime date)
        {
            using (var transaction = _context.Database.BeginTransaction())
            {
                try
                {
                    DeleteFacture(order_Id, cust_Id, price);
                    CustomerReport customerReport = new CustomerReport();
                    customerReport.Cust_ID = Convert.ToInt32(cust_Id);
                    customerReport.Cust_Name = Cust_Name;
                    customerReport.Date = date;
                    customerReport.Order_ID = Convert.ToInt32(order_Id);
                    customerReport.Price = ConvertToFloat(price);
                    _context.Add(customerReport);
                    _context.SaveChanges();
                    transaction.CommitAsync();
                    return true;
                }
                catch
                {
                    return false;
                }
            }
        }
        public bool UpdateFacture(string order_Id, string cust_Id, string price, string PayedValue)
        {
            try
            {
                var customerMoney = _context.CustomersMoneys.FirstOrDefault(x =>
                  x.Cust_ID.ToString() == cust_Id && x.Order_ID.ToString() == order_Id
                  );
                customerMoney.Price = ConvertToFloat(price);
                _context.Update(customerMoney);
                _context.SaveChanges();
                return true;
            }
            catch
            {
                return false;
            }
        }
        public bool TransactionOfEditingCustomerDebt(string order_Id, string cust_Id, string price, string Cust_Name, string PayedValue, DateTime date)
        {
            using (var transaction = _context.Database.BeginTransaction())
            {
                try
                {
                    if (Convert.ToDouble(price) - Convert.ToDouble(PayedValue) <= 0)
                        DeleteFacture(order_Id, cust_Id, price);
                    else
                        UpdateFacture(order_Id, cust_Id, price, PayedValue);

                    CustomerReport customerReport = new CustomerReport();
                    customerReport.Cust_ID = Convert.ToInt32(cust_Id);
                    customerReport.Cust_Name = Cust_Name;
                    customerReport.Date = date;
                    customerReport.Order_ID = Convert.ToInt32(order_Id);
                    customerReport.Price = ConvertToFloat(PayedValue);
                    _context.Add(customerReport);
                    _context.SaveChanges();
                    transaction.CommitAsync();
                    return true;
                }
                catch
                {
                    return false;
                }
            }
        }


    }
    public class CustomerReportRepository : GenericRepository<CustomerReport>, ICustomerReportRepository
    {
        public CustomerReportRepository(ApplicationDbContext context) : base(context)
        {
        }


        public List<CustomerReport> SearchBoth(string searchItem, DateTime fromDate, DateTime toDate)
        {

            try
            {
                return _context.CustomersReports
             .Where(x =>
                 (x.Cust_Name.Contains(searchItem, StringComparison.OrdinalIgnoreCase) ||
                  x.Order_ID.ToString() == searchItem) &&
                 fromDate <= x.Date && x.Date <= toDate)
             .OrderBy(x => x.Date)
             .ToList();

            }
            catch
            {
                return new List<CustomerReport>();
            }
        }
        public List<CustomerReport> SearchOnlyDate(DateTime fromDate, DateTime toDate)
        {

            try
            {
                return _context.CustomersReports
             .Where(x => (fromDate <= x.Date && x.Date <= toDate))
             .OrderBy(x => x.Date)
             .ToList();

            }
            catch
            {
                return new List<CustomerReport>();
            }
        }
        public List<CustomerReport> SearchOnlyCustomer(string searchItem)
        {

            try
            {
                return _context.CustomersReports
             .Where(x =>
                 x.Cust_Name.Contains(searchItem, StringComparison.OrdinalIgnoreCase) ||
                  x.Order_ID.ToString() == searchItem)
             .OrderBy(x => x.Date)
             .ToList();

            }
            catch
            {
                return new List<CustomerReport>();
            }
        }
    }
}
