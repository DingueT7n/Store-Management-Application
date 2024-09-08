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
        public List<SaleDetailDto> GetAllSalesWithDetails()
        {

            try
            {
                var lastBuy = _context.SalesDetails
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
                return lastBuy;
            }
            catch (Exception ex)
            {

                throw new Exception("Error retrieving the buyFactures", ex);
            }

        }
        public List<SaleDetailDto> SearchBoth(string searchItem, DateTime fromDate, DateTime toDate)
        {
            try
            {
                var buyDetailsQuery = _context.SalesDetails
                    .Include(bd => bd.Sale)
                    .Include(bd => bd.Product)
                    .Include(bd => bd.Customer)
                    .Where(bd => fromDate <= bd.Sale.Date && bd.Sale.Date <= toDate) // Filter by date range
                    .AsEnumerable()  // Switch to client-side evaluation for further filtering
                    .Where(bd =>
                        bd.Customer.CustomerName.Contains(searchItem, StringComparison.OrdinalIgnoreCase) ||
                        bd.Order_ID.ToString() == searchItem) // Client-side case-insensitive search
                    .OrderBy(bd => bd.Sale.Date);

                var buyDetailDtos = buyDetailsQuery.Select(bd => new SaleDetailDto
                {
                    Order_ID = bd.Order_ID,
                    Date = bd.Sale.Date,
                    Time = bd.Sale.Time,
                    User_Name = bd.Sale.User_Name,
                    TotalFacture = bd.Sale.TotalOrder,
                    PaidUp = bd.Sale.PaidUP,
                    Remain = bd.Sale.Remain,
                    CustomerName = bd.Customer.CustomerName, // Assuming `SupplierName` is correct
                    ProductName = bd.Product.ProductName,    // Assuming `ProductName` is correct
                    Quantity = bd.Quentity,
                    PriceWithTax = bd.PriceWithTax,
                    TotalPrice = bd.Total,
                    Discount = bd.Discount,
                })
                .ToList();

                return buyDetailDtos;
            }
            catch (Exception ex)
            {
                throw new Exception("Error retrieving the buy details", ex);
            }
        }
        public List<SaleDetailDto> SearchSalesByDate(DateTime fromDate, DateTime toDate)
        {
            try
            {
                return _context.SalesDetails
                    .Include(x => x.Sale)
                    .Include(x => x.Product)
                    .Include(x => x.Customer)
                    .Where(bd => fromDate <= bd.Sale.Date && bd.Sale.Date <= toDate) // Date range filter
                    .OrderBy(bd => bd.Sale.Date)
                    .Select(bd => new SaleDetailDto
                    {
                        Order_ID = bd.Order_ID,
                        Date = bd.Sale.Date,
                        Time = bd.Sale.Time,
                        User_Name = bd.Sale.User_Name,
                        TotalFacture = bd.Sale.TotalOrder,
                        PaidUp = bd.Sale.PaidUP,
                        Remain = bd.Sale.Remain,
                        CustomerName = bd.Customer.CustomerName, // Assuming `SupplierName` is correct
                        ProductName = bd.Product.ProductName,    // Assuming `ProductName` is correct
                        Quantity = bd.Quentity,
                        PriceWithTax = bd.PriceWithTax,
                        TotalPrice = bd.Total,
                        Discount = bd.Discount,
                    })
                    .ToList();
            }
            catch (Exception ex)
            {
                // Log or handle the exception as needed
                throw new Exception("Error retrieving the Sale details", ex);
            }
        }
        public List<SaleDetailDto> SearchOnlySupplier(string searchItem)
        {
            try
            {
                return _context.SalesDetails
                    .Include(bd => bd.Sale)
                    .Include(bd => bd.Product)
                    .Include(bd => bd.Customer)
                    .AsEnumerable()  // Forces client-side evaluation for case-insensitive search
                    .Where(bd =>
                        bd.Customer.CustomerName.Contains(searchItem, StringComparison.OrdinalIgnoreCase) ||  // Client-side case-insensitive search
                        bd.Order_ID.ToString() == searchItem)
                    .OrderBy(bd => bd.Sale.Date)
                    .Select(bd => new SaleDetailDto
                    {
                        Order_ID = bd.Order_ID,
                        Date = bd.Sale.Date,
                        Time = bd.Sale.Time,
                        User_Name = bd.Sale.User_Name,
                        TotalFacture = bd.Sale.TotalOrder,
                        PaidUp = bd.Sale.PaidUP,
                        Remain = bd.Sale.Remain,
                        CustomerName = bd.Customer.CustomerName, // Assuming `SupplierName` is correct
                        ProductName = bd.Product.ProductName,    // Assuming `ProductName` is correct
                        Quantity = bd.Quentity,
                        PriceWithTax = bd.PriceWithTax,
                        TotalPrice = bd.Total,
                        Discount = bd.Discount,
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
    }
}
