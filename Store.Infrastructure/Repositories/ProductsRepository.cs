using Microsoft.EntityFrameworkCore;
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


        public List<ProductOutdated> GetAllProductOutdated()
        {
            try
            {
                var products = _context.ProductsQuantities
                    .Include(x => x.Product)
                                .Where(x => x.DateExpiration <= DateTime.Now && x.Qty > 0)
                    .Select(bd => new ProductOutdated
                    {
                        CodeBar = bd.Product.CodeBar,
                        DateExperation = bd.DateExpiration,
                        ProductName = bd.Product.ProductName, // Assuming `Name` is the property for the supplier's name
                        StoreName = bd.StoreName,
                        Quentity = bd.Qty
                    })
                    .ToList();
                return products;
            }
            catch (Exception ex)
            {

                throw new Exception("Error retrieving the buyFactures", ex);
            }
        }
        public List<ProductMinQty> GetAllProductMinQty()
        {
            try
            {
                var products = _context.Products
                    .Include(x => x.Category)
                                .Where(x => x.Quentity <= x.MinQty)
                    .Select(bd => new ProductMinQty
                    {
                        CodeBar = bd.CodeBar,
                        DateExperation = bd.DateExperation,
                        ProductName = bd.ProductName, // Assuming `Name` is the property for the supplier's name
                        CategoryName = bd.Category.CategoryName,
                        Quentity = bd.Quentity
                    })
                    .ToList();
                return products;
            }
            catch (Exception ex)
            {

                throw new Exception("Error retrieving the buyFactures", ex);
            }
        }
        public List<Product> SearchAll(string searchIteam)
        {

            try
            {
                return _context.Products.Include(x => x.Category).Where(x => x.Id.ToString() == searchIteam ||
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
        public List<ProductOutStore> GetAllOutStore(string t1, string barcode, DateTime dtpFrom, DateTime dtpTo)
        {
            try
            {
                var allTransfers = _context.ProductsOutStore
                      .Include(x => x.Product)
                      .AsEnumerable();
                if (barcode != string.Empty) allTransfers = allTransfers.Where(x => x.Product.CodeBar == barcode);
                if (t1 != string.Empty)
                    allTransfers = allTransfers.Where(x => x.StoreName == t1);

                allTransfers = allTransfers.Where(x => x.Date >= dtpFrom && x.Date <= dtpTo)
                     ;

                return allTransfers.ToList();
            }
            catch (Exception ex)
            {

                throw new Exception("Error retrieving the buyFactures", ex);
            }

        }
        public ProductOutStoreRepository(ApplicationDbContext context) : base(context)
        {
        }
    }
    public class ProductsQuantitieRepository : GenericRepository<ProductsQuantitie>, IProductsQuantitieRepository
    {
        public ResultProductQtyDto GetAllProductQty(string barcode)
        {
            try
            {
                var lastRefund = _context.ProductsQuantities
                    .Include(x => x.Product)
                                .Where(x => (barcode != string.Empty ? barcode == x.Product.CodeBar : true))


                    .Select(bd => new ProductQtyDto
                    {
                        Pro_ID = bd.Pro_ID,
                        DateExpiration = bd.DateExpiration,
                        ProductName = bd.Product.ProductName, // Assuming `Name` is the property for the supplier's name
                        StoreName = bd.StoreName,
                        Qty = bd.Qty,   // Assuming `Name` is the property for the product's name
                        Buy_Price = bd.Buy_Price,
                        Sale_PriceTax = bd.Sale_PriceTax,
                        BarCode = bd.Product.CodeBar,
                    })
                    .ToList();
                return new ResultProductQtyDto
                {
                    result = lastRefund,
                    count = _context.ReturnsDetails.Count()
                };
            }
            catch (Exception ex)
            {

                throw new Exception("Error retrieving the buyFactures", ex);
            }
        }
        public ResultProductQtyDto GetProductQty(int storeId, string barcode)
        {
            try
            {
                var lastRefund = _context.ProductsQuantities
                    .Include(x => x.Product)
                    .Where(x => x.Store_ID == storeId)
                    .Where(x => (barcode != string.Empty ? barcode == x.Product.CodeBar : true))
                    .Select(bd => new ProductQtyDto
                    {
                        Pro_ID = bd.Pro_ID,
                        DateExpiration = bd.DateExpiration,
                        ProductName = bd.Product.ProductName, // Assuming `Name` is the property for the supplier's name
                        StoreName = bd.StoreName,
                        Qty = bd.Qty,   // Assuming `Name` is the property for the product's name
                        Buy_Price = bd.Buy_Price,
                        Sale_PriceTax = bd.Sale_PriceTax,
                        BarCode = bd.Product.CodeBar,
                    })
                    .ToList();
                return new ResultProductQtyDto
                {
                    result = lastRefund,
                    count = _context.ReturnsDetails.Count()
                };
            }
            catch (Exception ex)
            {

                throw new Exception("Error retrieving the buyFactures", ex);
            }

        }
        public ProductsQuantitieRepository(ApplicationDbContext context) : base(context)
        {
        }
    }
    public class ProductTransferRepository : GenericRepository<ProductTransfer>, IProductTransferRepository
    {
        public List<ProductTransfer> GetAllTransfert(string t1, string t2, string barcode)
        {

            try
            {
                var allTransfers = _context.ProductsTransfers
                      .Include(x => x.Product)
                      .AsEnumerable();
                if (barcode != string.Empty) allTransfers = allTransfers.Where(x => x.Product.CodeBar == barcode);
                if (t1 != string.Empty)
                    allTransfers = allTransfers.Where(x => x.StoreFrom == t1);
                if (t2 != string.Empty)
                    allTransfers = allTransfers.Where(x => x.StoreTo == t2);



                //allTransfers = allTransfers.Where(x => DateTime.TryParse(x.Date, out var date) && date >= dtpFrom && date <= dtpTo)
                //     ;

                return allTransfers.ToList();
            }
            catch (Exception ex)
            {

                throw new Exception("Error retrieving the buyFactures", ex);
            }

        }
        public ProductTransferRepository(ApplicationDbContext context) : base(context)
        {
        }
    }
}
