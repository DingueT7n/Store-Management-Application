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
                x.Id.ToString() == (searchIteam)
                )
                    .OrderBy(x => x.Order_Date).ToList();

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
                  x.Cust_ID.ToString() == cust_Id && x.Order_ID.ToString() == order_Id &&
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

        decimal ConvertToFloat(string value)
        {
            //float quantity;
            //if (float.TryParse(value, out quantity))
            //{
            //    return quantity;
            //}
            return Convert.ToDecimal(value);
        }
        public bool TransactionOfCustomerDebt(string order_Id, string cust_Id, string price, string Cust_Name, DateTime date)
        {
            using (var transaction = _context.Database.BeginTransaction())
            {
                try
                {
                    Customer customer = _context.Customers.Where(x => x.Id.ToString() == cust_Id).FirstOrDefault();
                    if (customer is not null)
                    {
                        customer.TotalDebts = customer.TotalDebts - ConvertToFloat(price);
                    }
                    _context.Update(customer);
                    DeleteFacture(order_Id, cust_Id, price);
                    CustomerReport customerReport = new CustomerReport();
                    customerReport.Cust_ID = Convert.ToInt32(cust_Id);
                    customerReport.Cust_Name = Cust_Name;
                    customerReport.Date = date;
                    customerReport.Order_ID = Convert.ToInt32(order_Id);
                    customerReport.Price = ConvertToFloat(price);
                    customerReport.Time = DateTime.Now.ToString("HH:mm");
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
                customerMoney.Price = customerMoney.Price - ConvertToFloat(PayedValue);
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
                    double diffrence = Convert.ToDouble(PayedValue);
                    if (Convert.ToDouble(price) - diffrence <= 0)
                    {
                        DeleteFacture(order_Id, cust_Id, price);
                        diffrence = Convert.ToDouble(price);
                    }
                    else
                        UpdateFacture(order_Id, cust_Id, price, PayedValue);
                    Customer customer = _context.Customers.Where(x => x.Id.ToString() == cust_Id).FirstOrDefault();
                    if (customer is not null)
                    {
                        customer.TotalDebts = customer.TotalDebts - ConvertToFloat(PayedValue.ToString());
                    }
                    _context.Update(customer);
                    CustomerReport customerReport = new CustomerReport();
                    customerReport.Cust_ID = Convert.ToInt32(cust_Id);
                    customerReport.Cust_Name = Cust_Name;
                    customerReport.Date = date;
                    customerReport.Order_ID = Convert.ToInt32(order_Id);
                    customerReport.Price = ConvertToFloat(PayedValue);
                    customerReport.Time = DateTime.Now.ToString("HH:mm");
                    _context.Add(customerReport);
                    _context.SaveChanges();
                    transaction.CommitAsync();
                    return true;
                }
                catch
                {
                    transaction.RollbackAsync();
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
                  .AsEnumerable()  // Forces client-side evaluation
                  .Where(x =>
                      (x.Cust_Name.Contains(searchItem, StringComparison.OrdinalIgnoreCase) ||  // Client-side case-insensitive search
                      x.Order_ID.ToString() == searchItem) &&
                      fromDate <= x.Date && x.Date <= toDate)  // Date range filter
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
       .AsEnumerable()  // Forces client-side evaluation
       .Where(x =>
           x.Cust_Name.Contains(searchItem, StringComparison.OrdinalIgnoreCase) ||  // Client-side case-insensitive search
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
