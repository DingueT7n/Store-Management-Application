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
