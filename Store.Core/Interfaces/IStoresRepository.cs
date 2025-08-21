using Store.Core.Entities.Stores;
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
    public interface IInventorySessionRepository : IGenericRepository<Core.Entities.Stores.InventorySession>
    {
        //Task<Category> GetAsync(int id);

        public Task<List<InventorySessionDTO>> GetAllInventorySession();
        public Task<List<InventorySessionDTO>> GetAllInventorySession(string searchitem);
    }
    public interface IInventoryCheckRepository : IGenericRepository<Core.Entities.Stores.InventoryCheck>
    {
        //Task<Category> GetAsync(int id);
    }
}
