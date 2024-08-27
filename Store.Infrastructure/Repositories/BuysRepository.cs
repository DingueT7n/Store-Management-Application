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
                return (_context.Buys.Last().Id + 1).ToString();
            }
            catch
            {
                throw;
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
