using Store.Core.Entities.Sales;

namespace Store.Core.Interfaces
{
    public interface ISalesRepository : IGenericRepository<Sale>
    {
        //Task<Category> GetAsync(int id);
    }
    public interface ISaleDetailRepository : IGenericRepository<SaleDetail>
    {
        //Task<Category> GetAsync(int id);
    }
    public interface ISaleProfitRepository : IGenericRepository<SaleProfit>
    {
        //Task<Category> GetAsync(int id);
    }
}
