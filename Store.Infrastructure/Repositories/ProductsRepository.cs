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
                _context = new ApplicationDbContext();

                var product = _context.Products.FirstOrDefault(x => x.CodeBar == barCode);


                if (product == null)
                {
                    product = _context.Products.FirstOrDefault(x => x.ColisageBareCode == barCode);
                }


                if (product == null)
                {
                    product = _context.ProductFamilies
                        .Where(x => x.CodeBar == barCode)
                        .Select(x => x.Product)
                        .FirstOrDefault();
                }



                return product;
            }
            catch (Exception)
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


        public async Task<List<ProductOutdated>> GetAllProductOutdated()
        {
            try
            {
                _context = new ApplicationDbContext();

                var products = await _context.ProductsQuantities.AsNoTracking()
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
                    .ToListAsync();
                return products;
            }
            catch (Exception ex)
            {

                throw new Exception("Error retrieving the buyFactures", ex);
            }
        }
        public async Task<List<ProductMinQty>> GetAllProductMinQty(int skip, int take)
        {
            try
            {
                _context = new ApplicationDbContext();

                var products = await _context.Products.AsNoTracking()
                                .Where(x => x.Quentity <= x.MinQty)
                    .Select(bd => new ProductMinQty
                    {
                        CodeBar = bd.CodeBar,
                        DateExperation = bd.DateExperation,
                        ProductName = bd.ProductName, // Assuming `Name` is the property for the supplier's name
                        CategoryName = bd.Category.CategoryName,
                        Quentity = bd.Quentity
                    }).Skip(skip).Take(take)
                    .ToListAsync();
                return products;
            }
            catch (Exception ex)
            {

                throw new Exception("Error retrieving the buyFactures", ex);
            }
        }
        public List<Product> SearchAll(string searchItem, int pageSize, int skip)
        {

            try
            {
                _context = new ApplicationDbContext();
                IQueryable<Product> query = _context.Products.AsNoTracking();



                if (!string.IsNullOrEmpty(searchItem))
                {
                    query = query.Where(x => x.Id.ToString() == searchItem ||
                                             x.CodeBar == searchItem ||
                                             x.ColisageBareCode == searchItem ||
                                             x.ProductName.Contains(searchItem) ||
                                             x.IsTaxed.ToString() == searchItem ||
                                             x.SalePrice.ToString() == searchItem ||
                                             x.Category.CategoryName.Contains(searchItem));
                }

                // Apply pagination
                var result = query.OrderBy(x => x.Id)
                                  .Skip(skip)
                                  .Take(pageSize)
                                   .Include(x => x.Category)
                                    .Include(x => x.ProductFamilies)
                                  .ToList();

                // Add product family search result if applicable
                if (!string.IsNullOrEmpty(searchItem))
                {
                    var pf = _context.ProductFamilies
                        .Include(x => x.Product)
                        .FirstOrDefault(x => x.CodeBar == searchItem);
                    if (pf != null && !result.Contains(pf.Product))
                    {
                        result.Add(pf.Product);
                    }
                }

                return result;
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
                _context = new ApplicationDbContext();

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
                _context = new ApplicationDbContext();

                var allTransfers = _context.ProductsOutStore.AsNoTracking()
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
                _context = new ApplicationDbContext();

                var lastRefund = _context.ProductsQuantities.AsNoTracking()
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
                _context = new ApplicationDbContext();

                var lastRefund = _context.ProductsQuantities.AsNoTracking()
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
                _context = new ApplicationDbContext();

                var allTransfers = _context.ProductsTransfers.AsNoTracking()
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
    public class ProductDiscountRepository : GenericRepository<ProductDiscount>, IProductDiscountRepository
    {
        public List<ProductDiscount> GetAllData(DateTime dateStart, DateTime dateEnd, string barcode, string store)
        {

            try
            {
                _context = new ApplicationDbContext();

                var allTransfers = _context.ProductDiscounts.AsNoTracking()
                      .Include(x => x.Product)
                      .Include(x => x.Store)
                      .AsEnumerable();
                if (barcode != string.Empty) allTransfers = allTransfers.Where(x => x.Product.CodeBar == barcode);
                allTransfers = allTransfers.Where(x => x.DateStart >= dateStart && x.DateEnd >= dateEnd);

                if (store != string.Empty)
                    allTransfers = allTransfers.Where(x => x.Store.StoreName == store);
                //if (t2 != string.Empty)
                //    allTransfers = allTransfers.Where(x => x.StoreTo == t2);



                //allTransfers = allTransfers.Where(x => DateTime.TryParse(x.Date, out var date) && date >= dtpFrom && date <= dtpTo)
                //     ;

                return allTransfers.ToList();
            }
            catch (Exception ex)
            {

                throw new Exception("Error retrieving the buyFactures", ex);
            }

        }
        public ProductDiscountRepository(ApplicationDbContext context) : base(context)
        {
        }
    }
}
