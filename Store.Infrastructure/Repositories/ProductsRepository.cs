using Store.Core.Entities.Products;
using Store.Core.Interfaces;
using Store.Infrastructure.Data;

namespace Store.Infrastructure.Repositories
{
    public class ProductsRepository : GenericRepository<Product>
    {
        public ProductsRepository(ApplicationDbContext context) : base(context)
        {
        }
    }
    public class ProductOutStoreRepository : GenericRepository<ProductOutStore>, IProductOutStoreRepository
    {
        public ProductOutStoreRepository(ApplicationDbContext context) : base(context)
        {
        }
    }
    public class ProductsQuantitieRepository : GenericRepository<ProductsQuantitie>, IProductsQuantitieRepository
    {
        public ProductsQuantitieRepository(ApplicationDbContext context) : base(context)
        {
        }
    }
    public class ProductTransferRepository : GenericRepository<ProductTransfer>, IProductTransferRepository
    {
        public ProductTransferRepository(ApplicationDbContext context) : base(context)
        {
        }
    }
}
