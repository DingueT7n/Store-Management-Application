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
        //public IEnumerable<Product> GetAllProducts()
        //{
        //    try
        //    {
        //        // Ensure _context is not null before accessing it
        //        if (_context == null)
        //        {
        //            throw new InvalidOperationException("The database context is not initialized.");
        //        }

        //        // Retrieve data from the database
        //        return _context.Products.ToList();
        //    }
        //    catch (Exception ex)
        //    {
        //        // Log the exception (this could be to a file, database, or any logging framework)
        //        Console.WriteLine($"An error occurred while retrieving data: {ex.Message}");

        //        // Return an empty list to indicate that no data was retrieved
        //        return new List<Product>();
        //    }
        //}
        public List<Product> SearchAll(string searchIteam)
        {

            try
            {
                return _context.Products.Where(x => x.Id.ToString() == searchIteam ||
                x.Quentity.ToString() == searchIteam ||
                x.ProductName.Contains(searchIteam) ||
                x.IsTaxed.ToString() == (searchIteam) ||
                x.SalePrice.ToString() == (searchIteam) ||
                x.Category.CategoryName.Contains(searchIteam)

                )
                    .OrderBy(x => x.Id).ToList();

            }
            catch
            {
                return new List<Product>();
            }
        }

        public List<Product> SearchByUser(string userId, string searchIteam)
        {
            try
            {
                return _context.Products.Where(x => x.Id.ToString() == userId).Where(x => x.Id.ToString() == searchIteam ||
                x.Quentity.ToString() == searchIteam ||
                x.ProductName.Contains(searchIteam) ||
                x.IsTaxed.ToString() == (searchIteam) ||
                x.SalePrice.ToString() == (searchIteam) ||
                x.Category.CategoryName.Contains(searchIteam)
                )
                    .OrderBy(x => x.Id).ToList();
            }
            catch
            {
                return new List<Product>();
            }
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
