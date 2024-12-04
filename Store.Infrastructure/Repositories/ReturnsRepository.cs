using Microsoft.EntityFrameworkCore;
using Store.Core.Entities.Buys;
using Store.Core.Entities.Returns;
using Store.Core.Entities.Sales;
using Store.Core.Interfaces;
using Store.Infrastructure.Data;

namespace Store.Infrastructure.Repositories
{
    public class ReturnsRepository : GenericRepository<Return>, IReturnsRepository
    {
        public ReturnsRepository(ApplicationDbContext context) : base(context)
        {
        }
        public List<BuyDetail> getBuyDetailById(string id)
        {
            try
            {
                var result = _context.BuyDetails.Where(x => x.Order_ID.ToString() == id).
                         Include(x => x.Buy)
                      .Include(x => x.Supplier)
                      .Include(x => x.Product)
                      .ToList();
                return result;
            }
            catch (Exception)
            {

                return new();
            }
        }
        public List<SaleDetail> getSaleDetailById(string id)
        {
            try
            {
                var result = _context.SalesDetails.Where(x => x.Order_ID.ToString() == id).
                         Include(x => x.Sale)
                      .Include(x => x.Customer)
                      .Include(x => x.Product)
                      .ToList();
                return result;
            }
            catch (Exception)
            {

                return new();
            }
        }
        public ResultReturnDetailDto GetAllReturnsWithDetails(int type)
        {
            string filter = type switch
            {
                2 => "Refund Buy",
                0 => "Refund",
                _ => "Refund Sale"
            };

            try
            {
                var lastRefund = _context.ReturnsDetails
                    .Include(x => x.Returns)
                    .Include(x => x.Product)
                    .Where(x => x.Returns.OrderType.Contains(filter))
                    .Select(bd => new ReturnDetailDto
                    {
                        Order_ID = bd.Order_ID,
                        DateFacture = Convert.ToDateTime(bd.Date),
                        Time = bd.Returns.Time,
                        User_Name = bd.Returns.User_Name,
                        TotalFacture = bd.Returns.TotalOrder,
                        PaidUp = bd.Returns.PaidUP,
                        Remain = bd.Returns.Remain,
                        CustomerName = bd.Cust_Name, // Assuming `Name` is the property for the supplier's name
                        SupplierName = bd.Sup_Name,
                        ProductName = bd.Product.ProductName,   // Assuming `Name` is the property for the product's name
                        Quantity = bd.Qty,
                        Price = bd.Price,
                        PriceWithTax = bd.PriceWithTax,
                        TotalPrice = bd.Total,
                        TaxValue = bd.TaxValue,
                        DateRefund = bd.Returns.OrderDate,
                    })
                    .ToList();
                return new ResultReturnDetailDto
                {
                    result = lastRefund,
                    count = _context.ReturnsDetails.Count()
                };
            }
            catch (Exception ex)
            {

                throw new Exception("Error retrieving the buyFactures", ex);
            }

        }
        public ResultReturnDetailDto SearchBoth(string searchItem, DateTime fromDate, DateTime toDate, int type)
        {
            string filter = type switch
            {
                2 => "Refund Buy",
                0 => "Refund",
                _ => "Refund Sale"
            };
            try
            {

                var query = _context.ReturnsDetails
                    .Include(bd => bd.Returns)
                    .Include(bd => bd.Product)
                         .Where(x => x.Returns.OrderType.Contains(filter))
                    .Where(bd => fromDate <= bd.Returns.OrderDate && bd.Returns.OrderDate <= toDate) // Date range filter
                    .Where(bd =>
                        EF.Functions.Like(bd.Cust_Name, $"%{searchItem}%") ||
                        EF.Functions.Like(bd.Sup_Name, $"%{searchItem}%") ||
                        bd.Order_ID.ToString() == searchItem);

                // Get the result list with pagination
                var returnDetails = query
                    .OrderByDescending(bd => bd.Id)
                    .Select(bd => new ReturnDetailDto
                    {
                        Order_ID = bd.Order_ID,
                        DateFacture = Convert.ToDateTime(bd.Date),
                        Time = bd.Returns.Time,
                        User_Name = bd.Returns.User_Name,
                        TotalFacture = bd.Returns.TotalOrder,
                        PaidUp = bd.Returns.PaidUP,
                        Remain = bd.Returns.Remain,
                        CustomerName = bd.Cust_Name, // Assuming `Name` is the property for the supplier's name
                        SupplierName = bd.Sup_Name,
                        ProductName = bd.Product.ProductName,   // Assuming `Name` is the property for the product's name
                        Quantity = bd.Qty,
                        Price = bd.Price,
                        PriceWithTax = bd.PriceWithTax,
                        TotalPrice = bd.Total,
                        TaxValue = bd.TaxValue,
                        DateRefund = bd.Returns.OrderDate,
                    })
                    .ToList();

                // Get the total count of matching records (without pagination)
                var totalCount = query.Count();

                return new ResultReturnDetailDto
                {
                    result = returnDetails,
                    count = totalCount
                };
            }
            catch (Exception ex)
            {
                // Log or handle the exception as needed
                throw new Exception("Error retrieving the buy details", ex);
            }
        }

    }
    public class ReturnDetailRepository : GenericRepository<ReturnDetail>, IReturnDetailRepository
    {
        public ReturnDetailRepository(ApplicationDbContext context) : base(context)
        {
        }
    }
}
