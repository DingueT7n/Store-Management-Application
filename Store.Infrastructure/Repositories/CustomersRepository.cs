using Microsoft.EntityFrameworkCore;

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
                    .OrderByDescending(x => x.Id).ToList();

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
                        _context.Update(customer);
                        _context.SaveChanges();

                    }
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
                    transaction.Commit();
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
        public async Task<CustomerReportDto> GetAllData(int skip, int take)
        {

            try
            {

                var query = _context.CustomersReports.AsQueryable();

                var result = query.Include(x => x.Sale).Include(x => x.Customer)
                    .OrderByDescending(x => x.Id).AsNoTracking()
                    ;
                var totalCount = await result.CountAsync();



                return new CustomerReportDto
                {
                    Result = await result.Skip(skip)
                    .Take(take).ToListAsync(),
                    count = totalCount
                };
            }
            catch
            {
                return new CustomerReportDto();
            }

        }

        public async Task<CustomerReportDto> SearchBoth(string searchItem, DateTime fromDate, DateTime toDate, int take, int skip)
        {
            try
            {

                var query = _context.CustomersReports
                    .Where(x =>
                        (EF.Functions.Like(x.Cust_Name, $"%{searchItem}%") ||
                        x.Order_ID.ToString() == searchItem) &&
                        fromDate <= x.Date && x.Date <= toDate);  // Filter by searchItem and date range

                var result = await query.Include(x => x.Sale).Include(x => x.Customer)
                    .OrderByDescending(x => x.Id).AsNoTracking()
                    .Skip(skip)
                    .Take(take)
                    .ToListAsync();

                var totalCount = await query.CountAsync();  // Get total count after filtering

                return new CustomerReportDto
                {
                    Result = result,
                    count = totalCount
                };
            }
            catch
            {
                return new CustomerReportDto();
            }
        }
        public async Task<CustomerReportDto> SearchOnlyDate(DateTime fromDate, DateTime toDate, int take, int skip)
        {
            try
            {

                var query = _context.CustomersReports.AsNoTracking().Include(x => x.Sale).Include(x => x.Customer)
                    .Where(x => fromDate <= x.Date && x.Date <= toDate)// Date range filter
                    .OrderByDescending(x => x.Id); // Order by descending date

                return new CustomerReportDto
                {
                    Result = await query.Skip(skip).Take(take).ToListAsync(), // Pagination
                    count = await query.CountAsync() // Count of the filtered data
                };
            }
            catch
            {
                return new CustomerReportDto();
            }
        }
        public async Task<CustomerReportDto> SearchOnlyCustomer(string searchItem, int take, int skip)
        {
            try
            {

                var query = _context.CustomersReports
                    .Where(x =>
                        EF.Functions.Like(x.Cust_Name, $"%{searchItem}%") ||
                        x.Order_ID.ToString() == searchItem);  // Filter by customer name or order ID

                var result = await query.Include(x => x.Sale).Include(x => x.Customer)
                    .OrderByDescending(x => x.Id).AsNoTracking()  // Order by date in descending order
                    .Skip(skip)
                    .Take(take)
                    .ToListAsync();

                var totalCount = await query.CountAsync();  // Get total count after filtering

                return new CustomerReportDto
                {
                    Result = result,
                    count = totalCount
                };
            }
            catch
            {
                return new CustomerReportDto();
            }
        }
    }
}
