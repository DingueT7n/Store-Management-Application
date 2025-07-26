using Store.Core.Entities.Products;
using Store.Core.Entities.Sales;

namespace Store.Core.Interfaces
{
    public interface ISalesRepository : IGenericRepository<Sale>
    {
        public Product GetProductBarCode(string barCode);
        public string GetFactureNumber();
        public Task<ResultSaleDetailDto> GetAllSalesWithDetails(int take, int skip);
        public Task<ResultSaleDetailDto> SearchBoth(string searchItem, DateTime fromDate, DateTime toDate, int take, int skip);
        public Task<ResultSaleDetailDto> SearchSalesByDate(DateTime fromDate, DateTime toDate, int take, int skip);
        public Task<ResultSaleDetailDto> SearchOnlySupplier(string searchItem, int take, int skip);
        //Task<Category> GetAsync(int id);
    }
    public interface ISaleDetailRepository : IGenericRepository<SaleDetail>
    {
        //Task<Category> GetAsync(int id);
    }
    public interface ISaleProfitRepository : IGenericRepository<SaleProfit>
    {
        public Task<SaleProfitDtoReturned> GetAllProfit(int take, int skip);
        public Task<SaleProfitDtoReturned> SearchBoth(string searchItem, DateTime fromDate, DateTime toDate, int take, int skip);
        public Task<SaleProfitDtoReturned> SearchSalesByDate(DateTime fromDate, DateTime toDate, int take, int skip);
        public Task<SaleProfitDtoReturned> SearchOnlyNames(string searchItem, int take, int skip);
        //Task<Category> GetAsync(int id);
    }
    public interface IProformaInvoiceRepository : IGenericRepository<ProformaInvoice>
    {
        //Task<Category> GetAsync(int id);
    }
    public interface IProformaInvoiceDetailsRepository : IGenericRepository<ProformaInvoiceDetails>
    {
        //Task<Category> GetAsync(int id);
    }
}
