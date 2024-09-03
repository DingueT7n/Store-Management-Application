using Microsoft.EntityFrameworkCore;
using Store.Core.Entities.Buys;
using Store.Core.Entities.Products;
using Store.Core.Entities.Suppliers;
using Store.Core.Interfaces;
using Store.Infrastructure.Data;

namespace Store.Infrastructure.Repositories
{
    public class BuysRepository : GenericRepository<Buy>
    {
        public BuysRepository(ApplicationDbContext context) : base(context)
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
        public string GetFactureNumber()
        {

            try
            {
                var lastBuy = _context.Buys.OrderByDescending(b => b.Id).FirstOrDefault();
                int nextId = (lastBuy != null) ? lastBuy.Id + 1 : 1;
                return nextId.ToString();
            }
            catch (Exception ex)
            {

                throw new Exception("Error retrieving the last facture number", ex);
            }

        }
        public List<BuyDetailDto> GetAllBuysWithDetails()
        {

            try
            {
                var lastBuy = _context.BuyDetails
                    .Include(x => x.Buy)
                    .Include(x => x.Product)
                    .Include(x => x.Supplier).Select(bd => new BuyDetailDto
                    {
                        Order_ID = bd.Order_ID,
                        Date = bd.Buy.Date,
                        Time = bd.Buy.Time,
                        User_Name = bd.Buy.User_Name,
                        TotalFacture = bd.Buy.Total,
                        PaidUp = bd.Buy.PaidUP,
                        Remain = bd.Buy.Remain,
                        SupplierName = bd.Supplier.SupplierName, // Assuming `Name` is the property for the supplier's name
                        ProductName = bd.Product.ProductName,   // Assuming `Name` is the property for the product's name
                        Quantity = bd.Quentity,
                        PriceWithTax = bd.PriceWithTax,
                        TotalPrice = bd.Total,
                        Discount = bd.Discount,
                    })
                    .ToList();
                return lastBuy;
            }
            catch (Exception ex)
            {

                throw new Exception("Error retrieving the buyFactures", ex);
            }

        }
        public bool TransactionOfEditingCustomerDebt(Buy buy, BuyDetail buyDetail, SupplierReport supplierReport)
        {
            using (var transaction = _context.Database.BeginTransaction())
            {
                try
                {

                    transaction.CommitAsync();
                    return true;
                }
                catch
                {
                    return false;
                }
            }
        }
    }
    public class BuyDetailRepository : GenericRepository<BuyDetail>, IBuyDetailRepository
    {
        public BuyDetailRepository(ApplicationDbContext context) : base(context)
        {
        }
    }


}
