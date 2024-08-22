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
