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


    }
    public interface IProductOutStoreRepository : IGenericRepository<ProductOutStore>
    {
    }
    public interface IProductsQuantitieRepository : IGenericRepository<ProductsQuantitie>
    {
    }
    public interface IProductTransferRepository : IGenericRepository<ProductTransfer>
    {
    }

}
