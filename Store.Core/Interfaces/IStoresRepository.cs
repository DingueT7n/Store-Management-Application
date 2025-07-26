using Store.Core.Entities.Vouchers;

namespace Store.Core.Interfaces
{
    public interface IStoresRepository : IGenericRepository<Core.Entities.Stores.Store>
    {
        //Task<Category> GetAsync(int id);
    }
    public interface IReceiptVoucherRepository : IGenericRepository<Core.Entities.Vouchers.ReceiptVoucher>
    {
        public Task<List<SendVoucher>> GetAllSentVouchers();
        public Task<List<ReceiptVoucher>> GetAllReciptVouchers();
        //Task<Category> GetAsync(int id);
    }
    public interface ISendVoucherRepository : IGenericRepository<Core.Entities.Vouchers.SendVoucher>
    {
        //Task<Category> GetAsync(int id);
    }
}
