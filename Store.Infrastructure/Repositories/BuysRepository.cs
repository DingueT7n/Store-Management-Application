using Microsoft.EntityFrameworkCore;
using Microsoft.IdentityModel.Tokens;
using Store.Core.Entities.Buys;
using Store.Core.Entities.Products;
using Store.Core.Interfaces;
using Store.Infrastructure.Data;

namespace Store.Infrastructure.Repositories
{
    public class BuysRepository : GenericRepository<Buy>, IBuysRepository
    {
        public BuysRepository(ApplicationDbContext context) : base(context)
        {
        }
        public async Task<BuyDetailDtoResult> SearchBoth(string searchItem, DateTime fromDate, DateTime toDate, int take, int skip)
        {
            try
            {
                var buyDetailsQuery = await _context.BuyDetails

                    .Include(bd => bd.Buy)
                    .Include(bd => bd.Product)
                    .Include(bd => bd.Supplier)
                    .Where(bd => fromDate <= bd.Buy.Date && bd.Buy.Date <= toDate) // Filter by date range
                                                                                   // Switch to client-side evaluation for further filtering
                    .Where(bd =>
                        bd.Supplier.SupplierName.ToLower().Contains(searchItem.ToLower()) ||
                        bd.Order_ID.ToString() == searchItem) // Client-side case-insensitive search
                    .OrderByDescending(bd => bd.Buy.Id).Skip(skip)
                    .Take(take)
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
                .ToListAsync();

                //var buyDetailDtos = buyDetailsQuery




                return new BuyDetailDtoResult
                {
                    result = buyDetailsQuery,
                    Count = buyDetailsQuery.Count()
                };
            }
            catch (Exception ex)
            {
                throw new Exception("Error retrieving the buy details", ex);
            }
        }
        public async Task<BuyDetailDtoResult> SearchBuysByDate(DateTime fromDate, DateTime toDate, int take, int skip)
        {
            try
            {
                return new BuyDetailDtoResult
                {
                    result = await _context.BuyDetails

                    .Include(x => x.Buy)
                    .Include(x => x.Product)
                    .Include(x => x.Supplier)
                    .Where(bd => fromDate <= bd.Buy.Date && bd.Buy.Date <= toDate) // Date range filter
                    .OrderByDescending(bd => bd.Buy.Id)
                      .Skip(skip)
                    .Take(take)
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
                    .ToListAsync(),
                    Count = await _context.BuyDetails.Where(bd => fromDate <= bd.Buy.Date && bd.Buy.Date <= toDate).CountAsync()
                };
            }
            catch (Exception ex)
            {
                // Log or handle the exception as needed
                throw new Exception("Error retrieving the buy details", ex);
            }
        }
        public async Task<BuyDetailDtoResult> SearchOnlySupplier(string searchItem, int take, int skip)
        {
            try
            {
                var searchLower = searchItem.ToLower();

                var query = await _context.BuyDetails
                    .Include(bd => bd.Buy)
                    .Include(bd => bd.Product)
                    .Include(bd => bd.Supplier)
                    .Where(bd => bd.Supplier.SupplierName.ToLower().Contains(searchLower) ||
                                 bd.Order_ID.ToString() == searchItem)
                    .OrderByDescending(bd => bd.Buy.Id)
                    .Skip(skip)
                    .Take(take)
                    .Select(bd => new BuyDetailDto
                    {
                        Order_ID = bd.Order_ID,
                        Date = bd.Buy.Date,
                        Time = bd.Buy.Time,
                        User_Name = bd.Buy.User_Name,
                        TotalFacture = bd.Buy.Total,
                        PaidUp = bd.Buy.PaidUP,
                        Remain = bd.Buy.Remain,
                        SupplierName = bd.Supplier.SupplierName,
                        ProductName = bd.Product.ProductName,
                        Quantity = bd.Quentity,
                        PriceWithTax = bd.PriceWithTax,
                        TotalPrice = bd.Total,
                        Discount = bd.Discount,
                    })
                    .ToListAsync();

                // Get the total count
                var totalCount = await _context.BuyDetails
                    .Where(bd => bd.Supplier.SupplierName.ToLower().Contains(searchLower) ||
                                 bd.Order_ID.ToString() == searchItem)
                    .CountAsync();

                return new BuyDetailDtoResult
                {
                    result = query,
                    Count = totalCount
                };
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
                var lastBuy = _context.Buys.OrderByDescending(b => b.Id).FirstOrDefault();
                int nextId = (lastBuy != null) ? lastBuy.Id + 1 : 1;
                return nextId.ToString();
            }
            catch (Exception ex)
            {

                throw new Exception("Error retrieving the last facture number", ex);
            }

        }
        public async Task<BuyDetailDtoResult> GetAllBuysWithDetails(int take, int skip)
        {

            try
            {
                var lastBuy = await _context.BuyDetails

                    .Include(x => x.Buy)
                    .Include(x => x.Product)
                    .Include(x => x.Supplier).
                    OrderByDescending(x => x.Buy.Id)
                     .Skip(skip)
                    .Take(take)
                    .Select(bd => new BuyDetailDto
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
                    .ToListAsync();
                return new BuyDetailDtoResult
                {
                    result = lastBuy,
                    Count = await _context.BuyDetails.CountAsync()
                };
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
