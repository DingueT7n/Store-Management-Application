using Store.Core.Entities.Buys;
using Store.Core.Entities.Products;

namespace Store.Core.Interfaces
{
    public interface IBuysRepository : IGenericRepository<Buy>
    {
        public Task<BuyDetailDtoResult> SearchBoth(string searchItem, DateTime fromDate, DateTime toDate, int take, int skip);
        public Task<BuyDetailDtoResult> SearchBuysByDate(DateTime fromDate, DateTime toDate, int take, int skip);
        public Task<BuyDetailDtoResult> SearchOnlySupplier(string searchItem, int take, int skip);
        public string GetFactureNumber();
        public Task<BuyDetailDtoResult> GetAllBuysWithDetails(int take, int skip);
        public Product GetProductBarCode(string barCode);


    }
    public interface IBuyDetailRepository : IGenericRepository<BuyDetail>
    {

    }
}
