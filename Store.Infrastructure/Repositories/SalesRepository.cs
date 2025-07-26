using Microsoft.Data.SqlClient;
using Microsoft.EntityFrameworkCore;
using Microsoft.IdentityModel.Tokens;
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
                if (barCode.IsNullOrEmpty()) { return null; }

                var product = _context.Products.FirstOrDefault(x => x.CodeBar == barCode);


                if (product == null)
                {
                    product = _context.Products.FirstOrDefault(x => x.ColisageBareCode == barCode);
                }
                if (product == null)
                {
                    product = _context.ProductFamilies
                        .Where(x => x.CodeBar == barCode)
                        .Select(x => x.Product)
                        .FirstOrDefault();
                }

                return product;
            }
            catch (Exception)
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
        public async Task<ResultSaleDetailDto> GetAllSalesWithDetails(int take, int skip)
        {

            try
            {
                var lastBuy = await _context.SalesDetails
                    .OrderByDescending(x => x.Sale.Id)
                    .Include(x => x.Sale)
                    .Include(x => x.Product)
                    .Include(x => x.Customer)
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
                        CustomerName = bd.Customer.CustomerName, // Assuming `Name` is the property for the supplier's name
                        ProductName = bd.Product.ProductName,   // Assuming `Name` is the property for the product's name
                        Quantity = bd.Quentity,
                        PriceWithTax = bd.PriceWithTax,
                        TotalPrice = bd.Total,
                        Discount = bd.Discount,
                    })
                    .ToListAsync();
                return new ResultSaleDetailDto
                {
                    result = lastBuy,
                    count = await _context.SalesDetails.Include(x => x.Sale)
                    .Include(x => x.Product)
                    .Include(x => x.Customer).CountAsync()
                };
            }
            catch (Exception ex)
            {

                throw new Exception("Error retrieving the buyFactures", ex);
            }

        }
        public async Task<ResultSaleDetailDto> SearchBoth(string searchItem, DateTime fromDate, DateTime toDate, int take, int skip)
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
                var saleDetails = await query
                    .OrderByDescending(bd => bd.Sale.Id)
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
                    .ToListAsync();

                // Get the total count of matching records (without pagination)
                var totalCount = await query.CountAsync();

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
        public async Task<ResultSaleDetailDto> SearchSalesByDate(DateTime fromDate, DateTime toDate, int take, int skip)
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
                    .OrderByDescending(bd => bd.Sale.Id)
                    .Skip(skip)
                    .Take(take);

                // Project the result to DTO
                var saleDetails = await salesDetailsQuery
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
                    .ToListAsync();

                // Get total count of records for the date range (without pagination)
                var totalCount = await _context.SalesDetails
                    .Where(bd => fromDate <= bd.Sale.Date && bd.Sale.Date <= toDate)
                    .CountAsync();

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
        public async Task<ResultSaleDetailDto> SearchOnlySupplier(string searchItem, int take, int skip)
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
                var saleDetails = await query
                    .OrderByDescending(bd => bd.Sale.Id)
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
                    .ToListAsync();

                // Get the total count of matching records (without pagination)
                var totalCount = await query.CountAsync();

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
        public async Task<SaleProfitDtoReturned> GetAllProfit(int take, int skip)
        {
            try
            {
                return new SaleProfitDtoReturned
                {
                    Result = await _context.SalesProfits
                    .Include(bd => bd.Sale)
                    .Include(bd => bd.Product)

                    //.Where(bd =>
                    //    bd.Customer.CustomerName.Contains(searchItem, StringComparison.OrdinalIgnoreCase) ||
                    //    bd.Order_ID.ToString() == searchItem)
                    .OrderByDescending(bd => bd.Sale.Id)
                    .Skip(skip)
                    .Take(take)
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
                        profit = Convert.ToDecimal((bd.Total - (bd.Quentity * bd.Buy_Price)).ToString("f2")),
                        TotalFacture = bd.Sale.TotalOrder,
                        PaidUp = bd.Sale.PaidUP,
                        Remain = bd.Sale.Remain,
                        Time = bd.Time,
                        date = bd.Sale.Date,
                        Sallesman = bd.Sale.User_Name,
                    })
                    .ToListAsync(),
                    Count = await _context.SalesProfits.Include(bd => bd.Sale)
                    .Include(bd => bd.Product).CountAsync()
                };
            }
            catch (Exception ex)
            {
                // Log or handle the exception as needed
                throw new Exception("Error retrieving the saleProfit", ex);
            }
        }
        public async Task<SaleProfitDtoReturned> SearchBoth(string searchItem, DateTime fromDate, DateTime toDate, int take, int skip)
        {
            try
            {
                var query = _context.SalesProfits

                    .Include(bd => bd.Sale)
                    .ThenInclude(b => b.Customer)
                    .Include(bd => bd.Product)

                    .Where(bd => fromDate <= bd.Sale.Date && bd.Sale.Date <= toDate)

                    .Where(bd =>
                        bd.Sale.Customer.CustomerName.ToLower().Contains(searchItem.ToLower()) ||
                        bd.Product.ProductName.ToLower().Contains(searchItem.ToLower()) ||

                        bd.Order_ID.ToString() == searchItem)
                    .OrderByDescending(bd => bd.Sale.Id);

                var result = await query
                      .Skip(skip)
                    .Take(take)
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
                        profit = Convert.ToDecimal((bd.Total - (bd.Quentity * bd.Buy_Price)).ToString("f2")),

                        TotalFacture = bd.Sale.TotalOrder,
                        PaidUp = bd.Sale.PaidUP,
                        Remain = bd.Sale.Remain,
                        Time = bd.Time,
                        date = bd.Sale.Date,
                        Sallesman = bd.Sale.User_Name,
                    })
                .ToListAsync();

                return new SaleProfitDtoReturned
                {

                    Result = result
                ,
                    Count = await query.CountAsync()
                };
            }
            catch (Exception ex)
            {
                throw new Exception("Error retrieving the buy details", ex);
            }
        }
        public async Task<SaleProfitDtoReturned> SearchSalesByDate(DateTime fromDate, DateTime toDate, int take, int skip)
        {
            try
            {
                return new SaleProfitDtoReturned
                {
                    Result = await _context.SalesProfits
                    .Include(x => x.Sale)
                    .Include(x => x.Product)

                    .Where(bd => fromDate <= bd.Sale.Date && bd.Sale.Date <= toDate) // Date range filter
                    .OrderByDescending(bd => bd.Sale.Id)
                    .Skip(skip)
                    .Take(take)
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
                        profit = Convert.ToDecimal((bd.Total - (bd.Quentity * bd.Buy_Price)).ToString("f2")),

                        TotalFacture = bd.Sale.TotalOrder,
                        PaidUp = bd.Sale.PaidUP,
                        Remain = bd.Sale.Remain,
                        Time = bd.Time,
                        date = bd.Sale.Date,
                        Sallesman = bd.Sale.User_Name,
                    })
                    .ToListAsync(),
                    Count = await _context.SalesProfits.Include(x => x.Sale)
                    .Include(x => x.Product)

                    .Where(bd => fromDate <= bd.Sale.Date && bd.Sale.Date <= toDate).CountAsync()
                };
            }
            catch (Exception ex)
            {
                // Log or handle the exception as needed
                throw new Exception("Error retrieving the Sale details", ex);
            }
        }
        public async Task<SaleProfitDtoReturned> SearchOnlyNames(string searchItem, int take, int skip)
        {
            try
            {
                return new SaleProfitDtoReturned
                {
                    Result = await _context.SalesProfits
                    .Include(bd => bd.Sale)
                    .Include(bd => bd.Product)
                    // Forces client-side evaluation for case-insensitive search
                    .Where(bd =>
                         bd.Sale.Customer.CustomerName.ToLower().Contains(searchItem.ToLower()) ||
                        bd.Product.ProductName.ToLower().Contains(searchItem.ToLower()) ||  // Client-side case-insensitive search
                        bd.Order_ID.ToString() == searchItem)
                    .OrderByDescending(bd => bd.Sale.Id)
                    .Skip(skip)
                    .Take(take)
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
                        profit = Convert.ToDecimal((bd.Total - (bd.Quentity * bd.Buy_Price)).ToString("f2")),

                        TotalFacture = bd.Sale.TotalOrder,
                        PaidUp = bd.Sale.PaidUP,
                        Remain = bd.Sale.Remain,
                        Time = bd.Time,
                        date = bd.Sale.Date,
                        Sallesman = bd.Sale.User_Name,
                    })
                    .ToListAsync(),
                    Count = await _context.SalesProfits
                    .Where(bd =>
                         bd.Sale.Customer.CustomerName.ToLower().Contains(searchItem.ToLower()) ||
                        bd.Product.ProductName.ToLower().Contains(searchItem.ToLower()) ||  // Client-side case-insensitive search
                        bd.Order_ID.ToString() == searchItem).CountAsync()
                };
            }
            catch (Exception ex)
            {
                // Log or handle the exception as needed
                throw new Exception("Error retrieving the buy details by supplier", ex);
            }
        }
    }
}
