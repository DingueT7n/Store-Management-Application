using Microsoft.EntityFrameworkCore;
using Store.Core.Entities.Buys;
using Store.Core.Entities.Products;
using Store.Core.Interfaces;
using Store.Infrastructure.Data;

namespace Store.Infrastructure.Repositories
{
    public class BuysRepository : GenericRepository<Buy>
    {
        public BuysRepository(ApplicationDbContext context) : base(context)
        {
        }
        public List<BuyDetailDto> SearchBoth(string searchItem, DateTime fromDate, DateTime toDate)
        {
            try
            {
                var buyDetailsQuery = _context.BuyDetails
                    .Include(bd => bd.Buy)
                    .Include(bd => bd.Product)
                    .Include(bd => bd.Supplier)
                    .Where(bd => fromDate <= bd.Buy.Date && bd.Buy.Date <= toDate) // Filter by date range
                    .AsEnumerable()  // Switch to client-side evaluation for further filtering
                    .Where(bd =>
                        bd.Supplier.SupplierName.Contains(searchItem, StringComparison.OrdinalIgnoreCase) ||
                        bd.Order_ID.ToString() == searchItem) // Client-side case-insensitive search
                    .OrderBy(bd => bd.Buy.Date);

                var buyDetailDtos = buyDetailsQuery.Select(bd => new BuyDetailDto
                {
                    Order_ID = bd.Order_ID,
                    Date = bd.Buy.Date,
                    Time = bd.Buy.Time,
                    User_Name = bd.Buy.User_Name,
                    TotalFacture = bd.Buy.Total,
                    PaidUp = bd.Buy.PaidUP,
                    Remain = bd.Buy.Remain,
                    SupplierName = bd.Supplier.SupplierName, // Assuming `SupplierName` is correct
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
        public List<BuyDetailDto> SearchBuysByDate(DateTime fromDate, DateTime toDate)
        {
            try
            {
                return _context.BuyDetails
                    .Include(x => x.Buy)
                    .Include(x => x.Product)
                    .Include(x => x.Supplier)
                    .Where(bd => fromDate <= bd.Buy.Date && bd.Buy.Date <= toDate) // Date range filter
                    .OrderBy(bd => bd.Buy.Date)
                    .Select(bd => new BuyDetailDto
                    {
                        Order_ID = bd.Order_ID,
                        Date = bd.Buy.Date,
                        Time = bd.Buy.Time,
                        User_Name = bd.Buy.User_Name,
                        TotalFacture = bd.Buy.Total,
                        PaidUp = bd.Buy.PaidUP,
                        Remain = bd.Buy.Remain,
                        SupplierName = bd.Supplier.SupplierName, // Assuming `SupplierName` is correct
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
                throw new Exception("Error retrieving the buy details", ex);
            }
        }
        public List<BuyDetailDto> SearchOnlySupplier(string searchItem)
        {
            try
            {
                return _context.BuyDetails
                    .Include(bd => bd.Buy)
                    .Include(bd => bd.Product)
                    .Include(bd => bd.Supplier)
                    .AsEnumerable()  // Forces client-side evaluation for case-insensitive search
                    .Where(bd =>
                        bd.Supplier.SupplierName.Contains(searchItem, StringComparison.OrdinalIgnoreCase) ||  // Client-side case-insensitive search
                        bd.Order_ID.ToString() == searchItem)
                    .OrderBy(bd => bd.Buy.Date)
                    .Select(bd => new BuyDetailDto
                    {
                        Order_ID = bd.Order_ID,
                        Date = bd.Buy.Date,
                        Time = bd.Buy.Time,
                        User_Name = bd.Buy.User_Name,
                        TotalFacture = bd.Buy.Total,
                        PaidUp = bd.Buy.PaidUP,
                        Remain = bd.Buy.Remain,
                        SupplierName = bd.Supplier.SupplierName, // Assuming `SupplierName` is correct
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
                var lastBuy = _context.Buys.OrderByDescending(b => b.Id).FirstOrDefault();
                int nextId = (lastBuy != null) ? lastBuy.Id + 1 : 1;
                return nextId.ToString();
            }
            catch (Exception ex)
            {

                throw new Exception("Error retrieving the last facture number", ex);
            }

        }
        public List<BuyDetailDto> GetAllBuysWithDetails()
        {

            try
            {
                var lastBuy = _context.BuyDetails
                    .Include(x => x.Buy)
                    .Include(x => x.Product)
                    .Include(x => x.Supplier).Select(bd => new BuyDetailDto
                    {
                        Order_ID = bd.Order_ID,
                        Date = bd.Buy.Date,
                        Time = bd.Buy.Time,
                        User_Name = bd.Buy.User_Name,
                        TotalFacture = bd.Buy.Total,
                        PaidUp = bd.Buy.PaidUP,
                        Remain = bd.Buy.Remain,
                        SupplierName = bd.Supplier.SupplierName, // Assuming `Name` is the property for the supplier's name
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

    }
    public class BuyDetailRepository : GenericRepository<BuyDetail>, IBuyDetailRepository
    {
        public BuyDetailRepository(ApplicationDbContext context) : base(context)
        {
        }
    }


}
