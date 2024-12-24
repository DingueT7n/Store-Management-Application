using Microsoft.EntityFrameworkCore;
using Store.Core.Entities.Caisses;
using Store.Core.Interfaces;
using Store.Infrastructure.Data;

namespace Store.Infrastructure.Repositories
{
    public class CaissesRepository : GenericRepository<Caisse>
    {
        public CaissesRepository(ApplicationDbContext context) : base(context)
        {
        }
    }
    public class CaisseDepositRepository : GenericRepository<CaisseDeposit>, ICaisseDepositRepository
    {
        public (List<CaisseDeposit> Deposits, int TotalCount) GetAllDepositToCaisse(
             string t1,
             string barcode,
             DateTime dtpFrom,
             DateTime dtpTo,
             int take,
             int skip)
        {
            try
            {
                // Query base
                var query = _context.CaissesDeposits
                    .Include(x => x.Caisse)
                    .OrderBy(x => x.Date)
                    .AsQueryable();

                // Filter by barcode if provided
                if (!string.IsNullOrEmpty(barcode))
                    query = query.Where(x => x.Caisse.CaisseName == barcode || x.Name.Contains(barcode));

                // Filter by Caisse name if provided
                if (!string.IsNullOrEmpty(t1))
                    query = query.Where(x => x.Caisse != null && x.Caisse.CaisseName == t1);

                // Filter by date range
                query = query.Where(x => x.Date >= dtpFrom && x.Date <= dtpTo);

                // Calculate total count before applying pagination
                int totalCount = query.Count();

                // Apply pagination (skip and take)
                var deposits = query
                    .OrderBy(x => x.Date) // Ensure consistent ordering
                    .Skip(skip)
                    .Take(take)
                    .ToList();

                return (deposits, totalCount);
            }
            catch (Exception ex)
            {
                throw new Exception("Error retrieving the deposits", ex);
            }
        }
        public CaisseDepositRepository(ApplicationDbContext context) : base(context)
        {
        }
    }
    public class CaisseBankTransfereRepository : GenericRepository<CaisseBankTransfere>, ICaisseBankTransfereRepository
    {

        public CaisseBankTransfereRepository(ApplicationDbContext context) : base(context)
        {
        }

        public List<CaisseBankTransfere> GetAll(DateTime value1, DateTime value2)
        {
            try
            {
                var allTransfers = _context.CaissesBankTransferes
                      .AsEnumerable();


                allTransfers = allTransfers.Where(x => x.Date >= value1 && x.Date <= value2);
                return allTransfers.ToList();
            }
            catch (Exception ex)
            {

                throw new Exception("Error retrieving the buyFactures", ex);
            }
        }

        public List<CaisseBankTransfere> GetAllBankToCaisse(string t1, string barcode,
            DateTime value1, DateTime value2, bool @checked)
        {
            try
            {
                var allTransfers = _context.CaissesBankTransferes
                      .AsEnumerable();
                if (barcode != string.Empty) allTransfers = allTransfers.Where(x => x.Name.Contains(barcode));
                if (@checked && t1 != string.Empty)
                    allTransfers = allTransfers.Where(x => x.To_.ToString() == t1);
                allTransfers = allTransfers.Where(x => x.From_ == "بنك");

                allTransfers = allTransfers.Where(x => x.Date >= value1 && x.Date <= value2);
                return allTransfers.ToList();
            }
            catch (Exception ex)
            {

                throw new Exception("Error retrieving the buyFactures", ex);
            }
        }

        public List<CaisseBankTransfere> GetAllCaisseToBank(string t1, string barcode,
            DateTime value1, DateTime value2, bool @checked)
        {
            try
            {
                var allTransfers = _context.CaissesBankTransferes
                      .AsEnumerable();
                if (barcode != string.Empty) allTransfers = allTransfers.Where(x => x.Name.Contains(barcode));
                if (@checked && t1 != string.Empty)
                    allTransfers = allTransfers.Where(x => x.From_.ToString() == t1);
                allTransfers = allTransfers.Where(x => x.To_ == "بنك");

                allTransfers = allTransfers.Where(x => x.Date >= value1 && x.Date <= value2);
                return allTransfers.ToList();
            }
            catch (Exception ex)
            {

                throw new Exception("Error retrieving the buyFactures", ex);
            }
        }
    }
    public class CaisseTransfereRepository : GenericRepository<CaisseTransfere>, ICaisseTransfereRepository
    {
        public List<CaisseTransfere> GetAllDepositToCaisse(string t1, string t2, string barcode, DateTime dtpFrom, DateTime dtpTo)
        {
            try
            {
                var allTransfers = _context.CaissesTransferes
                    .Include(x => x.CaisseFrom)
                    .Include(x => x.CaisseTo)
                      .AsEnumerable();
                if (barcode != string.Empty) allTransfers = allTransfers.Where(x => x.Name.Contains(barcode) || x.Reason.Contains(barcode));
                if (t1 != string.Empty)
                    allTransfers = allTransfers.Where(x => x.Caisse_From.ToString() == t1);
                if (t2 != string.Empty)
                    allTransfers = allTransfers.Where(x => x.Caisse_To.ToString() == t2);

                allTransfers = allTransfers.Where(x => x.Date >= dtpFrom && x.Date <= dtpTo);
                return allTransfers.ToList();
            }
            catch (Exception ex)
            {

                throw new Exception("Error retrieving the buyFactures", ex);
            }
        }
        public CaisseTransfereRepository(ApplicationDbContext context) : base(context)
        {
        }
    }
    public class CaisseWithdrawRepository : GenericRepository<CaisseWithdraw>, ICaisseWithdrawRepository
    {
        public List<CaisseWithdraw> GetAllDepositToCaisse(string t1, string barcode, DateTime dtpFrom, DateTime dtpTo)
        {
            try
            {
                var allTransfers = _context.CaissesWithdraws
                    .Include(x => x.Caisse)
                      .AsEnumerable();
                if (barcode != string.Empty) allTransfers = allTransfers.Where(x => x.Caisse.CaisseName == barcode || x.Name.Contains(barcode));
                if (t1 != string.Empty)
                    allTransfers = allTransfers.Where(x => x.Caisse is not null && x.Caisse.CaisseName == t1);

                allTransfers = allTransfers.Where(x => x.Date >= dtpFrom && x.Date <= dtpTo)
                     ;

                return allTransfers.ToList();
            }
            catch (Exception ex)
            {

                throw new Exception("Error retrieving the buyFactures", ex);
            }
        }
        public CaisseWithdrawRepository(ApplicationDbContext context) : base(context)
        {
        }
    }

}
