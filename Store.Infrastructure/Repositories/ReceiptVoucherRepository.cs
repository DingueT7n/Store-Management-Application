using Microsoft.EntityFrameworkCore;
using Store.Core.Entities.Vouchers;
using Store.Infrastructure.Data;

namespace Store.Infrastructure.Repositories
{
    public class ReceiptVoucherRepository : GenericRepository<ReceiptVoucher>
    {
        public ReceiptVoucherRepository(ApplicationDbContext context) : base(context)
        {
        }
        public List<ReceiptVoucher> GetAllReciptVouchers()
        {

            try
            {
                var result = _context.ReceiptVouchers.AsNoTracking()
                    .ToList();
                return result;

            }
            catch (Exception)
            {
                throw;
            }

        }
        public List<SendVoucher> GetAllSentVouchers()
        {

            try
            {
                var result = _context.SendVouchers.AsNoTracking()
                    .ToList();
                return result;

            }
            catch (Exception)
            {
                throw;
            }

        }

    }

}


