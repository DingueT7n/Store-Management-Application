using Store.Core.Entities.Buys;
using Store.Core.Entities.Returns;
using Store.Core.Entities.Sales;

namespace Store.Core.Interfaces
{
    public interface IReturnsRepository : IGenericRepository<Return>
    {
        public List<SaleDetail> getSaleDetailById(string id);
        public ResultReturnDetailDto GetAllReturnsWithDetails(int type);
        public ResultReturnDetailDto SearchBoth(string searchItem, DateTime fromDate, DateTime toDate, int type);
        public List<BuyDetail> getBuyDetailById(string id);
        //Task<Category> GetAsync(int id);
    }
    public interface IReturnDetailRepository : IGenericRepository<ReturnDetail>
    {
        //Task<Category> GetAsync(int id);
    }
}
