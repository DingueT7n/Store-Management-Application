using Microsoft.EntityFrameworkCore;
using Store.Core.Entities.Caisses;
using Store.Core.Interfaces;
using Store.Infrastructure.Data;

namespace Store.Infrastructure.Repositories
{
    public class CaissesRepository : GenericRepository<Caisse>, ICaissesRepository
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
                    .OrderByDescending(x => x.Date)
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
                    .OrderByDescending(x => x.Date) // Ensure consistent ordering
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

        public async Task<List<CaisseBankTransfere>> GetAll(DateTime value1, DateTime value2)
        {
            try
            {
                var allTransfers = _context.CaissesBankTransferes
                      .AsQueryable();


                allTransfers = allTransfers.Where(x => x.Date >= value1 && x.Date <= value2);
                return await allTransfers.ToListAsync();
            }
            catch (Exception ex)
            {

                throw new Exception("Error retrieving the buyFactures", ex);
            }
        }

        public async Task<List<CaisseBankTransfere>> GetAllBankToCaisse(string t1, string barcode,
            DateTime value1, DateTime value2, bool @checked)
        {
            try
            {
                var allTransfers = _context.CaissesBankTransferes
                      .AsQueryable();
                if (barcode != string.Empty) allTransfers = allTransfers.Where(x => x.Name.Contains(barcode));
                if (@checked && t1 != string.Empty)
                    allTransfers = allTransfers.Where(x => x.To_.ToString() == t1);
                allTransfers = allTransfers.Where(x => x.From_ == "بنك");

                allTransfers = allTransfers.Where(x => x.Date >= value1 && x.Date <= value2);
                return await allTransfers.ToListAsync();
            }
            catch (Exception ex)
            {

                throw new Exception("Error retrieving the buyFactures", ex);
            }
        }

        public async Task<List<CaisseBankTransfere>> GetAllCaisseToBank(string t1, string barcode,
            DateTime value1, DateTime value2, bool @checked)
        {
            try
            {
                var allTransfers = _context.CaissesBankTransferes
                      .AsQueryable();
                if (barcode != string.Empty) allTransfers = allTransfers.Where(x => x.Name.Contains(barcode));
                if (@checked && t1 != string.Empty)
                    allTransfers = allTransfers.Where(x => x.From_.ToString() == t1);
                allTransfers = allTransfers.Where(x => x.To_ == "بنك");

                allTransfers = allTransfers.Where(x => x.Date >= value1 && x.Date <= value2);
                return await allTransfers.ToListAsync();
            }
            catch (Exception ex)
            {

                throw new Exception("Error retrieving the buyFactures", ex);
            }
        }
    }
    public class CaisseTransfereRepository : GenericRepository<CaisseTransfere>, ICaisseTransfereRepository
    {
        public async Task<List<CaisseTransfere>> GetAllDepositToCaisse(string t1, string t2, string barcode, DateTime dtpFrom, DateTime dtpTo)
        {
            try
            {
                var allTransfers = _context.CaissesTransferes
                    .Include(x => x.CaisseFrom)
                    .Include(x => x.CaisseTo)
                      .AsQueryable();
                if (barcode != string.Empty) allTransfers = allTransfers.Where(x => x.Name.Contains(barcode) || x.Reason.Contains(barcode));
                if (t1 != string.Empty)
                    allTransfers = allTransfers.Where(x => x.Caisse_From.ToString() == t1);
                if (t2 != string.Empty)
                    allTransfers = allTransfers.Where(x => x.Caisse_To.ToString() == t2);

                allTransfers = allTransfers.Where(x => x.Date >= dtpFrom && x.Date <= dtpTo);
                return await allTransfers.ToListAsync();
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
        public (List<CaisseWithdraw> Deposits, int TotalCount) GetAllDepositToCaisse(string t1, string barcode, DateTime dtpFrom, DateTime dtpTo,
             int take,
             int skip)
        {
            try
            {
                var allTransfers = _context.CaissesWithdraws.OrderByDescending(x => x.Date)
                    .Include(x => x.Caisse)
                      .AsEnumerable();
                if (barcode != string.Empty) allTransfers = allTransfers.Where(x => x.Caisse.CaisseName == barcode || x.Name.Contains(barcode));
                if (t1 != string.Empty)
                    allTransfers = allTransfers.Where(x => x.Caisse is not null && x.Caisse.CaisseName == t1);

                allTransfers = allTransfers.Where(x => x.Date >= dtpFrom && x.Date <= dtpTo)
                     ;
                int totalCount = allTransfers.Count();

                // Apply pagination (skip and take)
                var deposits = allTransfers
                    .OrderByDescending(x => x.Date) // Ensure consistent ordering
                    .Skip(skip)
                    .Take(take)
                    .ToList();

                return (deposits, totalCount);

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

    public class CaisseStatusDetailRepository : GenericRepository<CaisseStatusDetail>, ICaisseStatusDetailRepository
    {
        public async Task<(List<CaisseStatusDetail> Deposits, int TotalCount)> GetAllStatus(
            string t1,

            string OperatorBy,
            DateTime dtpFrom,
            DateTime dtpTo,
            int take,
            int skip)
        {
            try
            {
                // Query base
                var query = _context.CaisseStatusDetails

                    .OrderByDescending(x => x.Id)
                    .AsQueryable();

                // Filter by barcode if provided

                if (!string.IsNullOrEmpty(OperatorBy))
                    query = query.Where(x =>
                        (!string.IsNullOrEmpty(x.OpenedBy) && x.OpenedBy.Contains(OperatorBy)) ||
                        (!string.IsNullOrEmpty(x.ClosedBy) && x.ClosedBy.Contains(OperatorBy)));


                // Filter by Caisse name if provided
                if (!string.IsNullOrEmpty(t1))
                    query = query.Where(x => x.Caisse != null && x.Caisse.CaisseName == t1);

                // Filter by date range

                query = query.Where(x => (x.OpeningTime != null ? (x.OpeningTime >= dtpFrom) : true)
                && ((x.ClosingTime != null ? (x.ClosingTime <= dtpTo) : true)));

                // Calculate total count before applying pagination
                int totalCount = await query.CountAsync();

                // Apply pagination (skip and take)
                var deposits = await query
                    .OrderByDescending(x => x.Id)
                    // Ensure consistent ordering
                    .Skip(skip)
                    .Take(take)
                    .ToListAsync();

                return (deposits, totalCount);
            }
            catch (Exception ex)
            {
                throw new Exception("Error retrieving the deposits", ex);
            }
        }
        public async Task<(List<CaisseOperation> Deposits, int TotalCount)> GetAllStatusOperations(
           string t1,

           string OperatorBy,
           DateTime dtpFrom,
           DateTime dtpTo,
           int take,
           int skip)
        {
            try
            {
                // Query base
                var query = _context.CaisseOperations
                    .Include(x => x.CaisseStatusDetail)
                    .OrderByDescending(x => x.Id)
                    .AsQueryable();

                // Filter by barcode if provided

                if (!string.IsNullOrEmpty(OperatorBy))
                    query = query.Where(x => x.CaisseStatusDetail.OpenedBy == OperatorBy || x.CaisseStatusDetail.OpenedBy.Contains(OperatorBy));
                if (!string.IsNullOrEmpty(OperatorBy))
                    query = query.Where(x => x.CaisseStatusDetail.ClosedBy == OperatorBy || x.CaisseStatusDetail.ClosedBy.Contains(OperatorBy));


                // Filter by Caisse name if provided
                if (!string.IsNullOrEmpty(t1))
                    query = query.Where(x => x.CaisseStatusDetail.Caisse != null && x.CaisseStatusDetail.Caisse.CaisseName == t1);

                // Filter by date range

                query = query.Where(x => (x.OperationDate.Date >= dtpFrom.Date)
                && (x.OperationDate.Date <= dtpTo.Date));

                // Calculate total count before applying pagination
                int totalCount = await query.CountAsync();

                // Apply pagination (skip and take)
                var deposits = await query
                    .OrderByDescending(x => x.Id)
                    // Ensure consistent ordering
                    .Skip(skip)
                    .Take(take)
                    .ToListAsync();

                return (deposits, totalCount);
            }
            catch (Exception ex)
            {
                throw new Exception("Error retrieving the deposits", ex);
            }
        }
        public CaisseStatusDetailRepository(ApplicationDbContext context) : base(context)
        {

        }
        public async Task OpenCaisse(int caisseId, string userName, decimal beforeMoney,
     decimal DA2000, decimal DA1000, decimal DA500, decimal DA200, decimal DA100, decimal DA50,
     decimal DA20, decimal DA10, decimal DA5, decimal Default)
        {
            var caisse = await _context.Caisses.FirstOrDefaultAsync(x => x.Id == caisseId);
            if (caisse == null)
                throw new ArgumentException("Caisse not found.");

            if (caisse.Status == CaisseStatus.Open)
                throw new InvalidOperationException("Caisse is already open.");

            caisse.Status = CaisseStatus.Open;
            _context.Caisses.Update(caisse);
            await _context.SaveChangesAsync();

            var caisseStatusDetail = new CaisseStatusDetail
            {
                CaisseId = caisseId,
                Status = CaisseStatus.Open,
                CaisseName = caisse.CaisseName,
                MoneyBeforeInCaisse = caisse.MoneyinCaisse,
                MoneyBefore = beforeMoney,
                OpeningTime = DateTime.Now,
                OpenedBy = userName
            };
            await _context.CaisseStatusDetails.AddAsync(caisseStatusDetail);
            await _context.SaveChangesAsync();

            var caisseOperation = new CaisseOperation
            {
                CaisseStatusDetailId = caisseStatusDetail.Id,
                Status = CaisseStatus.Open,
                Nbr2000DA = DA2000,
                Nbr1000DA = DA1000,
                Nbr500DA = DA500,
                Nbr200DA = DA200,
                Nbr100DA = DA100,
                Nbr50DA = DA50,
                Nbr20DA = DA20,
                Nbr10DA = DA10,
                Nbr5DA = DA5,
                ValueAddedDefault = Default,
                OperationDate = DateTime.Now,
                Time = DateTime.Now.ToString("HH:mm:ss"),
                PerformedBy = userName
            };
            await _context.CaisseOperations.AddAsync(caisseOperation);
            await _context.SaveChangesAsync();
        }
        public decimal BeforeOpening(int caisseId, decimal moneybefore
          )
        {


            try
            {


                var caisse = _context.Caisses.FirstOrDefault(x => x.Id == caisseId);
                if (caisse == null)
                    throw new ArgumentException("Caisse not found.");

                if (caisse.Status == CaisseStatus.Open)
                    throw new InvalidOperationException("Caisse is already Opened.");

                var lastStatus = _context.CaisseStatusDetails
                    .Where(x => x.CaisseId == caisseId && x.Status == CaisseStatus.Closed)
                    .OrderByDescending(x => x.Id)
                    .FirstOrDefault();

                if (lastStatus == null)
                    throw new InvalidOperationException("No open session found for this caisse.");

                var caisseDeposits = _context.CaissesDeposits.Where(x => x.Caisse_ID ==
                caisse.Id && (x.Date >= lastStatus.OpeningTime && x.Date <= DateTime.Now)).Sum(x => x.Money);
                var caisseWithdraw = _context.CaissesWithdraws.Where(x => x.Caisse_ID ==
                caisse.Id && (x.Date >= lastStatus.OpeningTime && x.Date <= DateTime.Now)).Sum(x => x.Money);

                lastStatus.IsBalanced = caisse.MoneyinCaisse == moneybefore;
                return (caisse.MoneyinCaisse) - moneybefore;
            }
            catch (Exception ex)
            {

                throw new InvalidOperationException(ex.Message);
            }
        }

        public decimal BeforeClosing(int caisseId, decimal moneyAfter
            )
        {


            try
            {


                var caisse = _context.Caisses.FirstOrDefault(x => x.Id == caisseId);
                if (caisse == null)
                    throw new ArgumentException("Caisse not found.");

                if (caisse.Status == CaisseStatus.Closed)
                    throw new InvalidOperationException("Caisse is already closed.");

                var lastStatus = _context.CaisseStatusDetails
                    .Where(x => x.CaisseId == caisseId && x.Status == CaisseStatus.Open)
                    .OrderByDescending(x => x.Id)
                    .FirstOrDefault();

                if (lastStatus == null)
                    throw new InvalidOperationException("No open session found for this caisse.");

                var caisseDeposits = _context.CaissesDeposits.Where(x => x.Caisse_ID ==
                caisse.Id && (x.Date >= lastStatus.OpeningTime && x.Date <= DateTime.Now)).Sum(x => x.Money);
                var caisseWithdraw = _context.CaissesWithdraws.Where(x => x.Caisse_ID ==
                caisse.Id && (x.Date >= lastStatus.OpeningTime && x.Date <= DateTime.Now)).Sum(x => x.Money);

                lastStatus.IsBalanced = ((caisseDeposits - caisseWithdraw) + lastStatus.MoneyBefore) == moneyAfter;
                return ((caisseDeposits - caisseWithdraw) + lastStatus.MoneyBefore) - moneyAfter;
            }
            catch (Exception ex)
            {

                throw new InvalidOperationException(ex.Message);
            }
        }

        public static string FormatTimeSpanToReadableString(TimeSpan timeSpan)
        {
            var parts = new List<string>();

            // Add days if present
            if (timeSpan.Days > 0)
                parts.Add($"{timeSpan.Days} {(timeSpan.Days == 1 ? "يوم" : "ايام")}");

            // Add hours if present
            if (timeSpan.Hours > 0)
                parts.Add($"{timeSpan.Hours} {(timeSpan.Hours == 1 ? "ساعة" : "ساعات")}");

            // Add minutes if present
            if (timeSpan.Minutes > 0)
                parts.Add($"{timeSpan.Minutes} {(timeSpan.Minutes == 1 ? "دقيقة" : "دقائق")}");

            // Add seconds if present
            if (timeSpan.Seconds > 0)
                parts.Add($"{timeSpan.Seconds} {(timeSpan.Seconds == 1 ? "ثانية" : "ثواني")}");

            // Join the parts with "and" for better readability
            return string.Join(" و ", parts);
        }

        public async Task CloseCaisse(int caisseId, string userName, decimal moneyAfter,
            decimal DA2000, decimal DA1000, decimal DA500, decimal DA200, decimal DA100, decimal DA50,
            decimal DA20, decimal DA10, decimal DA5, decimal Default)
        {

            using (var transaction = await _context.Database.BeginTransactionAsync())
            {
                try
                {


                    var caisse = await _context.Caisses.FirstOrDefaultAsync(x => x.Id == caisseId);
                    if (caisse == null)
                        throw new ArgumentException("Caisse not found.");

                    if (caisse.Status == CaisseStatus.Closed)
                        throw new InvalidOperationException("Caisse is already closed.");

                    var lastStatus = await _context.CaisseStatusDetails
                        .Where(x => x.CaisseId == caisseId && x.Status == CaisseStatus.Open)
                        .OrderByDescending(x => x.Id)
                        .FirstOrDefaultAsync();

                    if (lastStatus == null)
                        throw new InvalidOperationException("No open session found for this caisse.");

                    caisse.Status = CaisseStatus.Closed;
                    _context.Caisses.Update(caisse);
                    await _context.SaveChangesAsync();
                    lastStatus.ClosingTime = DateTime.Now;

                    var caisseDepositslist = await _context.CaissesDeposits.Where(x => x.Caisse_ID ==
                    caisse.Id && (x.Date >= lastStatus.OpeningTime && x.Date <= DateTime.Now)).ToListAsync();
                    var caisseDeposits = caisseDepositslist.Sum(x => x.Money);

                    var caisseWithdraw = _context.CaissesWithdraws.Where(x => x.Caisse_ID ==
                    caisse.Id && (x.Date >= lastStatus.OpeningTime && x.Date <= DateTime.Now)).Sum(x => x.Money);

                    lastStatus.Status = CaisseStatus.Closed;
                    lastStatus.MoneyAfterInCaisse = caisse.MoneyinCaisse;
                    lastStatus.MoneyAfter = moneyAfter;
                    lastStatus.ClosedBy = userName;
                    lastStatus.IsBalanced = ((caisseDeposits - caisseWithdraw) + lastStatus.MoneyBefore) == moneyAfter;

                    lastStatus.Duration = FormatTimeSpanToReadableString(lastStatus.ClosingTime.HasValue
                    ? (lastStatus.ClosingTime.Value - lastStatus.OpeningTime.Value)
                    : TimeSpan.Zero);


                    _context.CaisseStatusDetails.Update(lastStatus);
                    await _context.SaveChangesAsync();

                    var caisseOperation = new CaisseOperation
                    {
                        CaisseStatusDetailId = lastStatus.Id,
                        Status = CaisseStatus.Closed,
                        Nbr2000DA = DA2000,
                        Nbr1000DA = DA1000,
                        Nbr500DA = DA500,
                        Nbr200DA = DA200,
                        Nbr100DA = DA100,
                        Nbr50DA = DA50,
                        Nbr20DA = DA20,
                        Nbr10DA = DA10,
                        Nbr5DA = DA5,
                        ValueAddedDefault = Default,
                        OperationDate = DateTime.Now,
                        Time = DateTime.Now.ToString("HH:mm:ss"),
                        PerformedBy = userName
                    };
                    await _context.CaisseOperations.AddAsync(caisseOperation);
                    await _context.SaveChangesAsync();
                    await transaction.CommitAsync();
                }
                catch (Exception ex)
                {
                    await transaction.RollbackAsync();


                }
            }

        }
    }
    public class CaisseOperationRepository : GenericRepository<CaisseOperation>, ICaisseOperationRepository
    {

        public CaisseOperationRepository(ApplicationDbContext context) : base(context)
        {

        }

    }

}
