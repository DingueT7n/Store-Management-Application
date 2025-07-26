using Microsoft.EntityFrameworkCore;
using Store.Core.Entities.Vouchers;
using Store.Core.Interfaces;
using Store.Infrastructure.Data;

namespace Store.Infrastructure.Repositories
{
    public class ReceiptVoucherRepository : GenericRepository<ReceiptVoucher>, IReceiptVoucherRepository
    {
        public ReceiptVoucherRepository(ApplicationDbContext context) : base(context)
        {
        }
        public async Task<List<ReceiptVoucher>> GetAllReciptVouchers()
        {

            try
            {
                var result = await _context.ReceiptVouchers.AsNoTracking()
                    .ToListAsync();
                return result;

            }
            catch (Exception)
            {
                throw;
            }

        }
        public async Task<List<SendVoucher>> GetAllSentVouchers()
        {

            try
            {
                var result = _context.SendVouchers.AsNoTracking()
                    .ToListAsync();
                return await result;

            }
            catch (Exception)
            {
                throw;
            }

        }
    }
    public class SendVoucherRepository : GenericRepository<SendVoucher>, ISendVoucherRepository
    {
        public SendVoucherRepository(ApplicationDbContext context) : base(context)
        {
        }



    }
}


