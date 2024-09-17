using Microsoft.Data.SqlClient;
using Microsoft.EntityFrameworkCore;
using Store.Core.Entities.Products;
using Store.Core.Entities.Sales;
using Store.Core.Interfaces;
using Store.Infrastructure.Data;

namespace Store.Infrastructure.Repositories
{
    public class SalesRepository : GenericRepository<Sale>, ISalesRepository
    {
        public SalesRepository(ApplicationDbContext context) : base(context)
        {
        }
        public Product GetProductBarCode(string barCode)
        {

            try
            {
                return _context.Products.Where(x =>
                x.CodeBar == (barCode)
                )
                    .FirstOrDefault();

            }
            catch
            {
                return new Product();
            }
        }
        public string GetFactureNumber()
        {

            try
            {
                var lastBuy = _context.Sales.OrderByDescending(b => b.Id).FirstOrDefault();
                int nextId = (lastBuy != null) ? lastBuy.Id + 1 : 1;
                return nextId.ToString();
            }
            catch (Exception ex)
            {

                throw new Exception("Error retrieving the last facture number", ex);
            }

        }
        public ResultSaleDetailDto GetAllSalesWithDetails(int take, int skip)
        {

            try
            {
                var lastBuy = _context.SalesDetails.Skip(skip).Take(take)
                    .Include(x => x.Sale)
                    .Include(x => x.Product)
                    .Include(x => x.Customer).Select(bd => new SaleDetailDto
                    {
                        Order_ID = bd.Order_ID,
                        Date = bd.Sale.Date,
                        Time = bd.Sale.Time,
                        User_Name = bd.Sale.User_Name,
                        TotalFacture = bd.Sale.TotalOrder,
                        PaidUp = bd.Sale.PaidUP,
                        Remain = bd.Sale.Remain,
                        CustomerName = bd.Customer.CustomerName, // Assuming `Name` is the property for the supplier's name
                        ProductName = bd.Product.ProductName,   // Assuming `Name` is the property for the product's name
                        Quantity = bd.Quentity,
                        PriceWithTax = bd.PriceWithTax,
                        TotalPrice = bd.Total,
                        Discount = bd.Discount,
                    })
                    .ToList();
                return new ResultSaleDetailDto
                {
                    result = lastBuy,
                    count = _context.SalesDetails.Count()
                };
            }
            catch (Exception ex)
            {

                throw new Exception("Error retrieving the buyFactures", ex);
            }

        }
        public ResultSaleDetailDto SearchBoth(string searchItem, DateTime fromDate, DateTime toDate, int take, int skip)
        {
            try
            {
                // Ensure that skip is non-negative
                skip = Math.Max(0, skip);

                // Query with server-side filtering for both the date range and the search item
                var query = _context.SalesDetails
                    .Include(bd => bd.Sale)
                    .Include(bd => bd.Product)
                    .Include(bd => bd.Customer)
                    .Where(bd => fromDate <= bd.Sale.Date && bd.Sale.Date <= toDate) // Date range filter
                    .Where(bd =>
                        EF.Functions.Like(bd.Customer.CustomerName, $"%{searchItem}%") ||
                        bd.Order_ID.ToString() == searchItem);

                // Get the result list with pagination
                var saleDetails = query
                    .OrderBy(bd => bd.Sale.Date)
                    .Skip(skip)
                    .Take(take)
                    .Select(bd => new SaleDetailDto
                    {
                        Order_ID = bd.Order_ID,
                        Date = bd.Sale.Date,
                        Time = bd.Sale.Time,
                        User_Name = bd.Sale.User_Name,
                        TotalFacture = bd.Sale.TotalOrder,
                        PaidUp = bd.Sale.PaidUP,
                        Remain = bd.Sale.Remain,
                        CustomerName = bd.Customer.CustomerName,
                        ProductName = bd.Product.ProductName,
                        Quantity = bd.Quentity,
                        PriceWithTax = bd.PriceWithTax,
                        TotalPrice = bd.Total,
                        Discount = bd.Discount,
                    })
                    .ToList();

                // Get the total count of matching records (without pagination)
                var totalCount = query.Count();

                return new ResultSaleDetailDto
                {
                    result = saleDetails,
                    count = totalCount
                };
            }
            catch (Exception ex)
            {
                // Log or handle the exception as needed
                throw new Exception("Error retrieving the buy details", ex);
            }
        }
        public ResultSaleDetailDto SearchSalesByDate(DateTime fromDate, DateTime toDate, int take, int skip)
        {
            try
            {
                // Ensure 'skip' is non-negative
                skip = Math.Max(0, skip);

                // Query for fetching the sale details within the date range
                var salesDetailsQuery = _context.SalesDetails
                    .Include(x => x.Sale)
                    .Include(x => x.Product)
                    .Include(x => x.Customer)
                    .Where(bd => fromDate <= bd.Sale.Date && bd.Sale.Date <= toDate) // Date range filter
                    .OrderBy(bd => bd.Sale.Date)
                    .Skip(skip)
                    .Take(take);

                // Project the result to DTO
                var saleDetails = salesDetailsQuery
                    .Select(bd => new SaleDetailDto
                    {
                        Order_ID = bd.Order_ID,
                        Date = bd.Sale.Date,
                        Time = bd.Sale.Time,
                        User_Name = bd.Sale.User_Name,
                        TotalFacture = bd.Sale.TotalOrder,
                        PaidUp = bd.Sale.PaidUP,
                        Remain = bd.Sale.Remain,
                        CustomerName = bd.Customer.CustomerName,
                        ProductName = bd.Product.ProductName,
                        Quantity = bd.Quentity,
                        PriceWithTax = bd.PriceWithTax,
                        TotalPrice = bd.Total,
                        Discount = bd.Discount,
                    })
                    .ToList();

                // Get total count of records for the date range (without pagination)
                var totalCount = _context.SalesDetails
                    .Where(bd => fromDate <= bd.Sale.Date && bd.Sale.Date <= toDate)
                    .Count();

                return new ResultSaleDetailDto
                {
                    result = saleDetails,
                    count = totalCount
                };
            }
            catch (SqlException sqlEx)
            {

                throw new Exception("A database error occurred while retrieving the Sale details.", sqlEx);
            }
            catch (Exception ex)
            {

                throw new Exception("Error retrieving the Sale details", ex);
            }
        }
        public ResultSaleDetailDto SearchOnlySupplier(string searchItem, int take, int skip)
        {
            try
            {
                // Ensure that skip is non-negative
                skip = Math.Max(0, skip); // Prevent negative skip values

                // Server-side filtering and pagination
                var query = _context.SalesDetails
                    .Include(bd => bd.Sale)
                    .Include(bd => bd.Product)
                    .Include(bd => bd.Customer)
                    .Where(bd =>
                        EF.Functions.Like(bd.Customer.CustomerName, $"%{searchItem}%") || // Server-side case-insensitive search
                        bd.Order_ID.ToString() == searchItem);

                // Get the result list with pagination
                var saleDetails = query
                    .OrderBy(bd => bd.Sale.Date)
                    .Skip(skip)
                    .Take(take)
                    .Select(bd => new SaleDetailDto
                    {
                        Order_ID = bd.Order_ID,
                        Date = bd.Sale.Date,
                        Time = bd.Sale.Time,
                        User_Name = bd.Sale.User_Name,
                        TotalFacture = bd.Sale.TotalOrder,
                        PaidUp = bd.Sale.PaidUP,
                        Remain = bd.Sale.Remain,
                        CustomerName = bd.Customer.CustomerName,
                        ProductName = bd.Product.ProductName,
                        Quantity = bd.Quentity,
                        PriceWithTax = bd.PriceWithTax,
                        TotalPrice = bd.Total,
                        Discount = bd.Discount,
                    })
                    .ToList();

                // Get the total count of matching records (without pagination)
                var totalCount = query.Count();

                return new ResultSaleDetailDto
                {
                    result = saleDetails,
                    count = totalCount
                };
            }
            catch (Exception ex)
            {
                // Log or handle the exception as needed
                throw new Exception("Error retrieving the buy details by supplier", ex);
            }
        }
    }
    public class SaleDetailRepository : GenericRepository<SaleDetail>, ISaleDetailRepository
    {
        public SaleDetailRepository(ApplicationDbContext context) : base(context)
        {
        }
    }
    public class SaleProfitRepository : GenericRepository<SaleProfit>, ISaleProfitRepository
    {
        public SaleProfitRepository(ApplicationDbContext context) : base(context)
        {
        }
        public List<SaleProfitDto> GetAllProfit()
        {
            try
            {
                return _context.SalesProfits
                    .Include(bd => bd.Sale)
                    .Include(bd => bd.Product)
                    .AsEnumerable()
                    //.Where(bd =>
                    //    bd.Customer.CustomerName.Contains(searchItem, StringComparison.OrdinalIgnoreCase) ||
                    //    bd.Order_ID.ToString() == searchItem)
                    .OrderBy(bd => bd.Sale.Date)
                    .Select(bd => new SaleProfitDto
                    {
                        Order_ID = bd.Order_ID,
                        Pro_ID = bd.Pro_ID,
                        ProductName = bd.Product.ProductName,    // Assuming `ProductName` is correct
                        Cust_Name = bd.Cust_Name, // Assuming `SupplierName` is correct
                        Tax_Value = bd.Tax_Value,
                        Quentity = bd.Quentity,
                        Price = bd.Price,
                        Buy_Price = bd.Buy_Price,
                        Discount = bd.Discount,
                        Total = bd.Total,
                        profit = Convert.ToDecimal((bd.Total - (bd.Quentity * bd.Buy_Price))),
                        TotalFacture = bd.Sale.TotalOrder,
                        PaidUp = bd.Sale.PaidUP,
                        Remain = bd.Sale.Remain,
                        Time = bd.Time,
                        date = bd.Sale.Date,
                        Sallesman = bd.Sale.User_Name,
                    })
                    .ToList();
            }
            catch (Exception ex)
            {
                // Log or handle the exception as needed
                throw new Exception("Error retrieving the saleProfit", ex);
            }
        }
        public List<SaleProfitDto> SearchBoth(string searchItem, DateTime fromDate, DateTime toDate)
        {
            try
            {
                var buyDetailsQuery = _context.SalesProfits
                    .Include(bd => bd.Sale)
                    .ThenInclude(b => b.Customer)
                    .Include(bd => bd.Product)

                    .Where(bd => fromDate <= bd.Sale.Date && bd.Sale.Date <= toDate) // Filter by date range
                    .AsEnumerable()  // Switch to client-side evaluation for further filtering
                    .Where(bd =>
                        bd.Sale.Customer.CustomerName.ToLower().Contains(searchItem.ToLower()) ||
                        bd.Product.ProductName.ToLower().Contains(searchItem.ToLower()) ||

                        bd.Order_ID.ToString() == searchItem) // Client-side case-insensitive search
                    .OrderBy(bd => bd.Sale.Date);

                var buyDetailDtos = buyDetailsQuery.Select(bd => new SaleProfitDto
                {
                    Order_ID = bd.Order_ID,
                    Pro_ID = bd.Pro_ID,
                    ProductName = bd.Product.ProductName,    // Assuming `ProductName` is correct
                    Cust_Name = bd.Cust_Name, // Assuming `SupplierName` is correct
                    Tax_Value = bd.Tax_Value,
                    Quentity = bd.Quentity,
                    Price = bd.Price,
                    Buy_Price = bd.Buy_Price,
                    Discount = bd.Discount,
                    Total = bd.Total,
                    profit = Convert.ToDecimal((bd.Total - (bd.Quentity * bd.Buy_Price))),
                    TotalFacture = bd.Sale.TotalOrder,
                    PaidUp = bd.Sale.PaidUP,
                    Remain = bd.Sale.Remain,
                    Time = bd.Time,
                    date = bd.Sale.Date,
                    Sallesman = bd.Sale.User_Name,
                })
                .ToList();

                return buyDetailDtos;
            }
            catch (Exception ex)
            {
                throw new Exception("Error retrieving the buy details", ex);
            }
        }
        public List<SaleProfitDto> SearchSalesByDate(DateTime fromDate, DateTime toDate)
        {
            try
            {
                return _context.SalesProfits
                    .Include(x => x.Sale)
                    .Include(x => x.Product)

                    .Where(bd => fromDate <= bd.Sale.Date && bd.Sale.Date <= toDate) // Date range filter
                    .OrderBy(bd => bd.Sale.Date)
                    .Select(bd => new SaleProfitDto
                    {
                        Order_ID = bd.Order_ID,
                        Pro_ID = bd.Pro_ID,
                        ProductName = bd.Product.ProductName,    // Assuming `ProductName` is correct
                        Cust_Name = bd.Cust_Name, // Assuming `SupplierName` is correct
                        Tax_Value = bd.Tax_Value,
                        Quentity = bd.Quentity,
                        Price = bd.Price,
                        Buy_Price = bd.Buy_Price,
                        Discount = bd.Discount,
                        Total = bd.Total,
                        profit = Convert.ToDecimal((bd.Total - (bd.Quentity * bd.Buy_Price))),
                        TotalFacture = bd.Sale.TotalOrder,
                        PaidUp = bd.Sale.PaidUP,
                        Remain = bd.Sale.Remain,
                        Time = bd.Time,
                        date = bd.Sale.Date,
                        Sallesman = bd.Sale.User_Name,
                    })
                    .ToList();
            }
            catch (Exception ex)
            {
                // Log or handle the exception as needed
                throw new Exception("Error retrieving the Sale details", ex);
            }
        }
        public List<SaleProfitDto> SearchOnlyNames(string searchItem)
        {
            try
            {
                return _context.SalesProfits
                    .Include(bd => bd.Sale)
                    .Include(bd => bd.Product)

                    .AsEnumerable()  // Forces client-side evaluation for case-insensitive search
                    .Where(bd =>
                         bd.Sale.Customer.CustomerName.ToLower().Contains(searchItem.ToLower()) ||
                        bd.Product.ProductName.ToLower().Contains(searchItem.ToLower()) ||  // Client-side case-insensitive search
                        bd.Order_ID.ToString() == searchItem)
                    .OrderBy(bd => bd.Sale.Date)
                    .Select(bd => new SaleProfitDto
                    {
                        Order_ID = bd.Order_ID,
                        Pro_ID = bd.Pro_ID,
                        ProductName = bd.Product.ProductName,
                        Cust_Name = bd.Cust_Name,
                        Tax_Value = bd.Tax_Value,
                        Quentity = bd.Quentity,
                        Price = bd.Price,
                        Buy_Price = bd.Buy_Price,
                        Discount = bd.Discount,
                        Total = bd.Total,
                        profit = Convert.ToDecimal((bd.Total - (bd.Quentity * bd.Buy_Price))),
                        TotalFacture = bd.Sale.TotalOrder,
                        PaidUp = bd.Sale.PaidUP,
                        Remain = bd.Sale.Remain,
                        Time = bd.Time,
                        date = bd.Sale.Date,
                        Sallesman = bd.Sale.User_Name,
                    })
                    .ToList();
            }
            catch (Exception ex)
            {
                // Log or handle the exception as needed
                throw new Exception("Error retrieving the buy details by supplier", ex);
            }
        }
    }
}
