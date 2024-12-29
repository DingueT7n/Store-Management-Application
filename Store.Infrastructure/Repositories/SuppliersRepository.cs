using Microsoft.EntityFrameworkCore;
using Store.Core.Entities.Suppliers;
using Store.Core.Interfaces;
using Store.Infrastructure.Data;

namespace Store.Infrastructure.Repositories
{
    public class SuppliersRepository : GenericRepository<Supplier>, ISuppliersRepository
    {
        public SuppliersRepository(ApplicationDbContext context) : base(context)
        {
        }

        public List<Supplier> SearchAll(string searchIteam)
        {

            try
            {
                _context = new ApplicationDbContext();
                return _context.Suppliers.Where(x => x.Id.ToString() == searchIteam ||
                x.SupplierName.ToString().Contains(searchIteam) ||
                x.Address.Contains(searchIteam) ||
                x.TotalDebts.ToString() == (searchIteam) ||
                x.Notes.Contains(searchIteam)

                )
                    .OrderBy(x => x.SupplierName).ToList();

            }
            catch
            {
                return new List<Supplier>();
            }
        }



    }
    public class SupplierMoneyRepository : GenericRepository<SupplierMoney>, ISupplierMoneyRepository
    {
        public SupplierMoneyRepository(ApplicationDbContext context) : base(context)
        {
        }

        public List<SupplierMoney> SearchAll(string searchIteam)
        {
            try
            {
                _context = new ApplicationDbContext();
                return _context.SuppliersMoneys.Where(x =>
                x.SupplierName.ToString().Contains(searchIteam) ||
                x.Id.ToString() == (searchIteam)
                )
                    .OrderBy(x => x.Id).ToList();

            }
            catch
            {
                return new List<SupplierMoney>();
            }
        }

        public bool DeleteFacture(string order_Id, string sup_id, string price)
        {

            try
            {
                _context = new ApplicationDbContext();
                var supplierMoney = _context.SuppliersMoneys.FirstOrDefault(x =>
                  x.Sup_ID.ToString() == sup_id && x.Order_ID.ToString() == order_Id &&
                  x.Price.ToString() == (price)
                  );
                _context.Remove(supplierMoney);
                _context.SaveChanges();
                return true;

            }
            catch
            {
                return false;
            }
        }

        decimal ConvertToFloat(string value)
        {
            //float quantity;
            //if (float.TryParse(value, out quantity))
            //{
            //    return quantity;
            //}
            return Convert.ToDecimal(value);
        }
        public bool TransactionOfSupplierDebt(string order_Id, string sup_Id, string price, string sup_Name, DateTime date)
        {
            _context = new ApplicationDbContext();
            using (var transaction = _context.Database.BeginTransaction())
            {
                try
                {
                    Supplier supplier = _context.Suppliers.Where(x => x.Id.ToString() == sup_Id).FirstOrDefault();
                    if (supplier is not null)
                    {
                        supplier.TotalDebts = supplier.TotalDebts - ConvertToFloat(price);
                    }
                    _context.Update(supplier);
                    _context.SaveChanges();

                    DeleteFacture(order_Id, sup_Id, price);
                    SupplierReport supplierReport = new SupplierReport();
                    supplierReport.Sup_ID = Convert.ToInt32(sup_Id);
                    supplierReport.SupplierName = sup_Name;
                    supplierReport.Date = date;
                    supplierReport.Order_ID = Convert.ToInt32(order_Id);
                    supplierReport.Price = ConvertToFloat(price);
                    supplierReport.Time = DateTime.Now.ToString("HH:mm");
                    _context.Add(supplierReport);
                    _context.SaveChanges();
                    transaction.CommitAsync();
                    return true;
                }
                catch
                {
                    return false;
                }
            }
        }
        public bool UpdateFacture(string order_Id, string sup_Id, string price, string PayedValue)
        {
            try
            {
                _context = new ApplicationDbContext();
                var suppliersMoneys = _context.SuppliersMoneys.FirstOrDefault(x =>
                  x.Sup_ID.ToString() == sup_Id && x.Order_ID.ToString() == order_Id
                  );
                suppliersMoneys.Price = suppliersMoneys.Price - ConvertToFloat(PayedValue);
                _context.Update(suppliersMoneys);
                _context.SaveChanges();
                return true;
            }
            catch
            {
                return false;
            }
        }
        public bool TransactionOfEditingSupplierDebt(string order_Id, string sup_Id, string price, string sup_Name, string PayedValue, DateTime date
            )
        {
            using (var transaction = _context.Database.BeginTransaction())
            {
                try
                {
                    _context = new ApplicationDbContext();
                    double diffrence = Convert.ToDouble(PayedValue);
                    if (Convert.ToDouble(price) - diffrence <= 0)
                    {
                        DeleteFacture(order_Id, sup_Id, price);
                        diffrence = Convert.ToDouble(price);
                    }
                    else
                        UpdateFacture(order_Id, sup_Id, price, PayedValue);

                    Supplier supplier = _context.Suppliers.Where(x => x.Id.ToString() == sup_Id).FirstOrDefault();
                    if (supplier is not null)
                    {
                        supplier.TotalDebts = supplier.TotalDebts - ConvertToFloat(PayedValue.ToString());
                    }
                    _context.Update(supplier);
                    _context.SaveChanges();

                    SupplierReport supplierReport = new SupplierReport();
                    supplierReport.Sup_ID = Convert.ToInt32(sup_Id);
                    supplierReport.SupplierName = sup_Name;
                    supplierReport.Date = date;
                    supplierReport.Order_ID = Convert.ToInt32(order_Id);
                    supplierReport.Price = ConvertToFloat(PayedValue);
                    supplierReport.Time = DateTime.Now.ToString("HH:mm");
                    _context.Add(supplierReport);
                    _context.SaveChanges();
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
    public class SupplierReportRepository : GenericRepository<SupplierReport>, ISupplierReportRepository
    {
        public SupplierReportRepository(ApplicationDbContext context) : base(context)
        {
        }
        public SupplierReportDto GetAllData(int skip, int take)
        {

            try
            {
                _context = new ApplicationDbContext();
                var query = _context.SuppliersReports.AsQueryable();
                // Filter by searchItem and date range
                var totalCount = query.Count();
                var result = query.Include(x => x.Buy).Include(x => x.Supplier)
                    .OrderByDescending(x => x.Id)
                    .Skip(skip)
                    .Take(take)
                    .ToList();



                return new SupplierReportDto
                {
                    Result = result,
                    count = totalCount
                };
            }
            catch
            {
                return new SupplierReportDto();
            }

        }
        public SupplierReportDto SearchBoth(string searchItem, DateTime fromDate, DateTime toDate, int take, int skip)
        {

            try
            {
                _context = new ApplicationDbContext();
                var query = _context.SuppliersReports
                    .Where(x =>
                        (EF.Functions.Like(x.SupplierName, $"%{searchItem}%") ||
                        x.Order_ID.ToString() == searchItem) &&
                        fromDate <= x.Date && x.Date <= toDate);  // Filter by searchItem and date range

                var result = query.Include(x => x.Buy).Include(x => x.Supplier)
                    .OrderByDescending(x => x.Id)
                    .Skip(skip)
                    .Take(take)
                    .ToList();

                var totalCount = query.Count();  // Get total count after filtering

                return new SupplierReportDto
                {
                    Result = result,
                    count = totalCount
                };
            }
            catch
            {
                return new SupplierReportDto();
            }
        }
        public SupplierReportDto SearchOnlyDate(DateTime fromDate, DateTime toDate, int take, int skip)
        {

            try
            {
                _context = new ApplicationDbContext();
                var query = _context.SuppliersReports.Include(x => x.Buy).Include(x => x.Supplier)
                    .Where(x => fromDate <= x.Date && x.Date <= toDate)
                    .OrderByDescending(x => x.Id);

                return new SupplierReportDto
                {
                    Result = query.Skip(skip).Take(take).ToList(),
                    count = query.Count()
                };
            }
            catch
            {
                return new SupplierReportDto();
            }
        }
        public SupplierReportDto SearchOnlySupplier(string searchItem, int take, int skip)
        {

            try
            {
                _context = new ApplicationDbContext();
                var query = _context.SuppliersReports
                    .Where(x =>
                        EF.Functions.Like(x.SupplierName, $"%{searchItem}%") ||
                        x.Order_ID.ToString() == searchItem);

                var result = query.Include(x => x.Buy).Include(x => x.Supplier)
                    .OrderByDescending(x => x.Id)
                    .Skip(skip)
                    .Take(take)
                    .ToList();

                var totalCount = query.Count();

                return new SupplierReportDto
                {
                    Result = result,
                    count = totalCount
                };
            }
            catch
            {
                return new SupplierReportDto();
            }
        }
    }
}
