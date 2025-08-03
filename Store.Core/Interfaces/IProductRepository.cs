using Store.Core.Entities.Products;

namespace Store.Core.Interfaces
{
    public interface IProductRepository : IGenericRepository<Product>
    {
        //Task<IEnumerable<Product>> GetAllAsync(Product ProdParam);
        //Task<bool> AddAsync(Product Prod);
        //Task<bool> UpdateAsync(int id, Product Prod);
        //Task<bool> DeleteAsyncWithPicture(int id);
        //Task<int> CountProductsAsync(Product ProdParam);
        public Product GetProductBarCode(string barCode);
        public Task<List<ProductOutdated>> GetAllProductOutdated();
        public Task<List<ProductMinQty>> GetAllProductMinQty(int skip, int take);
        public Task<List<Product>> SearchAll(string searchItem, int pageSize, int skip);
        public List<Product> SearchByUser(string userId, string searchIteam);


    }
    public interface IProductOutStoreRepository : IGenericRepository<ProductOutStore>
    {
        public Task<List<ProductOutStore>> GetAllOutStore(string t1, string barcode, DateTime dtpFrom, DateTime dtpTo);
    }
    public interface IProductsQuantitieRepository : IGenericRepository<ProductsQuantitie>
    {
        public Task<ResultProductQtyDto> GetAllProductQty(string barcode, int skip, int take);
        public Task<ResultProductQtyDto> GetProductQty(int storeId, string barcode, int skip, int take);
    }
    public interface IProductTransferRepository : IGenericRepository<ProductTransfer>
    {
        public Task<List<ProductTransfer>> GetAllTransfert(string t1, string t2, string barcode);
    }
    public interface IProductDiscountRepository : IGenericRepository<ProductDiscount>
    {
        public Task<List<ProductDiscount>> GetAllData(DateTime dateStart, DateTime dateEnd, string barcode, string store);
    }

}
