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

        public async Task<List<Supplier>> SearchAll(string searchIteam)
        {

            try
            {

                return await _context.Suppliers.Where(x => x.Id.ToString() == searchIteam ||
                x.SupplierName.ToString().Contains(searchIteam) ||
                x.Address.Contains(searchIteam) ||
                x.TotalDebts.ToString() == (searchIteam) ||
                x.Notes.Contains(searchIteam)

                )
                    .OrderBy(x => x.SupplierName).ToListAsync();

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

        public async Task<List<SupplierMoney>> SearchAll(string searchIteam)
        {
            try
            {

                return await _context.SuppliersMoneys.Where(x =>
                x.SupplierName.ToString().Contains(searchIteam) ||
                x.Id.ToString() == (searchIteam)
                )
                    .OrderBy(x => x.Id).ToListAsync();

            }
            catch
            {
                return new List<SupplierMoney>();
            }
        }

        public async Task<bool> DeleteFacture(string order_Id, string sup_id, string price)
        {

            try
            {

                var supplierMoney = await _context.SuppliersMoneys.FirstOrDefaultAsync(x =>
                  x.Sup_ID.ToString() == sup_id && x.Order_ID.ToString() == order_Id &&
                  x.Price.ToString() == (price)
                  );
                _context.Remove(supplierMoney);
                await _context.SaveChangesAsync();
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
        public async Task<bool> TransactionOfSupplierDebt(string order_Id, string sup_Id, string price, string sup_Name, DateTime date)
        {
            try
            {


                try
                {
                    // Validate inputs
                    if (!decimal.TryParse(price, out decimal parsedPrice))
                    {
                        throw new ArgumentException("Invalid price format.");
                    }
                    if (!int.TryParse(sup_Id, out int supplierId))
                    {
                        throw new ArgumentException("Invalid supplier ID format.");
                    }
                    if (!int.TryParse(order_Id, out int orderId))
                    {
                        throw new ArgumentException("Invalid order ID format.");
                    }

                    // Fetch supplier
                    Supplier supplier = await _context.Suppliers.FirstOrDefaultAsync(x => x.Id == supplierId);
                    if (supplier == null)
                    {
                        throw new InvalidOperationException("Supplier not found.");
                    }

                    // Update supplier debts
                    supplier.TotalDebts -= parsedPrice;
                    _context.Update(supplier);
                    await _context.SaveChangesAsync();


                    // Delete facture
                    if (!await DeleteFacture(order_Id, sup_Id, price))
                    {
                        throw new InvalidOperationException("Failed to delete facture.");
                    }

                    // Add supplier report
                    var supplierReport = new SupplierReport
                    {
                        Sup_ID = supplierId,
                        SupplierName = sup_Name,
                        Date = date,
                        Order_ID = orderId,
                        Price = parsedPrice,
                        Time = DateTime.Now.ToString("HH:mm")
                    };
                    await _context.SuppliersReports.AddAsync(supplierReport);
                    await _context.SaveChangesAsync();


                    return true;
                }
                catch (Exception ex)
                {
                    // Log exception details

                    Console.WriteLine($"Error: {ex.Message}");
                    return false;
                }


            }
            catch (Exception ex)
            {
                // Log exception details
                Console.WriteLine($"Error: {ex.Message}");
                return false;
            }
        }
        public async Task<bool> UpdateFacture(string order_Id, string sup_Id, string price, string PayedValue)
        {
            try
            {

                var suppliersMoneys = await _context.SuppliersMoneys.FirstOrDefaultAsync(x =>
                  x.Sup_ID.ToString() == sup_Id && x.Order_ID.ToString() == order_Id
                  );
                suppliersMoneys.Price = suppliersMoneys.Price - ConvertToFloat(PayedValue);
                _context.Update(suppliersMoneys);
                await _context.SaveChangesAsync();
                return true;
            }
            catch
            {
                return false;
            }
        }
        public async Task<bool> TransactionOfEditingSupplierDebt(string order_Id, string sup_Id, string price, string sup_Name, string PayedValue, DateTime date
            )
        {

            try
            {

                double diffrence = Convert.ToDouble(PayedValue);
                if (Convert.ToDouble(price) - diffrence <= 0)
                {
                    DeleteFacture(order_Id, sup_Id, price);
                    diffrence = Convert.ToDouble(price);
                }
                else
                    await UpdateFacture(order_Id, sup_Id, price, PayedValue);

                Supplier supplier = await _context.Suppliers.Where(x => x.Id.ToString() == sup_Id).FirstOrDefaultAsync();
                if (supplier is not null)
                {
                    supplier.TotalDebts = supplier.TotalDebts - ConvertToFloat(PayedValue.ToString());
                    _context.Update(supplier);


                }
                SupplierReport supplierReport = new SupplierReport();
                supplierReport.Sup_ID = Convert.ToInt32(sup_Id);
                supplierReport.SupplierName = sup_Name;
                supplierReport.Date = date;
                supplierReport.Order_ID = Convert.ToInt32(order_Id);
                supplierReport.Price = ConvertToFloat(PayedValue);
                supplierReport.Time = DateTime.Now.ToString("HH:mm");
                await _context.AddAsync(supplierReport);
                await _context.SaveChangesAsync();

                return true;
            }
            catch
            {

                return false;

            }
        }

    }
    public class SupplierReportRepository : GenericRepository<SupplierReport>, ISupplierReportRepository
    {
        public SupplierReportRepository(ApplicationDbContext context) : base(context)
        {
        }
        public async Task<SupplierReportDto> GetAllData(int skip, int take)
        {

            try
            {

                var query = _context.SuppliersReports.AsQueryable();
                // Filter by searchItem and date range
                var totalCount = await query.CountAsync();
                var result = await query.Include(x => x.Buy).Include(x => x.Supplier)
                    .OrderByDescending(x => x.Id)
                    .Skip(skip)
                    .Take(take)
                    .ToListAsync();



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
        public async Task<SupplierReportDto> SearchBoth(string searchItem, DateTime fromDate, DateTime toDate, int take, int skip)
        {

            try
            {

                var query = _context.SuppliersReports
                    .Where(x =>
                        (EF.Functions.Like(x.SupplierName, $"%{searchItem}%") ||
                        x.Order_ID.ToString() == searchItem) &&
                        fromDate <= x.Date && x.Date <= toDate);  // Filter by searchItem and date range

                var result = await query.Include(x => x.Buy).Include(x => x.Supplier)
                    .OrderByDescending(x => x.Id)
                    .Skip(skip)
                    .Take(take)
                    .ToListAsync();

                var totalCount = await query.CountAsync();  // Get total count after filtering

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
        public async Task<SupplierReportDto> SearchOnlyDate(DateTime fromDate, DateTime toDate, int take, int skip)
        {

            try
            {

                var query = _context.SuppliersReports.Include(x => x.Buy).Include(x => x.Supplier)
                    .Where(x => fromDate <= x.Date && x.Date <= toDate)
                    .OrderByDescending(x => x.Id);

                return new SupplierReportDto
                {
                    Result = await query.Skip(skip).Take(take).ToListAsync(),
                    count = await query.CountAsync()
                };
            }
            catch
            {
                return new SupplierReportDto();
            }
        }
        public async Task<SupplierReportDto> SearchOnlySupplier(string searchItem, int take, int skip)
        {

            try
            {

                var query = _context.SuppliersReports
                    .Where(x =>
                        EF.Functions.Like(x.SupplierName, $"%{searchItem}%") ||
                        x.Order_ID.ToString() == searchItem);

                var result = await query.Include(x => x.Buy).Include(x => x.Supplier)
                    .OrderByDescending(x => x.Id)
                    .Skip(skip)
                    .Take(take)
                    .ToListAsync();

                var totalCount = await query.CountAsync();

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
