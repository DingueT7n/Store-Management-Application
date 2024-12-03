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

    }
    public class ReturnDetailRepository : GenericRepository<ReturnDetail>, IReturnDetailRepository
    {
        public ReturnDetailRepository(ApplicationDbContext context) : base(context)
        {
        }
    }
}
