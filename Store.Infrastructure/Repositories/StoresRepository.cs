using Microsoft.EntityFrameworkCore;
using Store.Core.Entities.Stores;
using Store.Core.Interfaces;
using Store.Infrastructure.Data;

namespace Store.Infrastructure.Repositories
{
    public class StoresRepository : GenericRepository<Store.Core.Entities.Stores.Store>, IStoresRepository
    {
        public StoresRepository(ApplicationDbContext context) : base(context)
        {
        }
    }
    public class InventoryCheckRepository : GenericRepository<Store.Core.Entities.Stores.InventoryCheck>, IInventoryCheckRepository
    {
        public InventoryCheckRepository(ApplicationDbContext context) : base(context)
        {
        }
    }
    public class InventorySessionRepository : GenericRepository<Store.Core.Entities.Stores.InventorySession>, IInventorySessionRepository
    {
        public InventorySessionRepository(ApplicationDbContext context) : base(context)
        {
        }

        public async Task<List<InventorySessionDTO>> GetAllInventorySession()
        {
            return await _context.InventorySessions.Include(x => x.Store).Select(b => new InventorySessionDTO
            {
                Id = b.Id,
                //StoreId = b.StoreId,
                Store = b.Store,
                PerformedBy = b.PerformedBy,
                DateStarted = b.DateStarted,
                DateEnded = b.DateEnded,
                AllStores = b.AllStores,
                Status = b.Status,
                Notes = b.Notes

            })
                 .ToListAsync();
        }
        public async Task<List<InventorySessionDTO>> GetAllInventorySession(string searchitem)
        {
            return await _context.InventorySessions
         .Include(x => x.Store)
         .Where(x =>
             (string.IsNullOrEmpty(searchitem)) ||
             (x.PerformedBy != null && x.PerformedBy.Contains(searchitem)) ||
             (x.Store != null && x.Store.StoreName != null && x.Store.StoreName.Contains(searchitem)) ||
             (x.Notes != null && x.Notes.Contains(searchitem))
         )
         .Select(b => new InventorySessionDTO
         {
             Id = b.Id,
             //StoreId = b.StoreId,
             Store = b.Store,
             PerformedBy = b.PerformedBy,
             DateStarted = b.DateStarted,
             DateEnded = b.DateEnded,
             AllStores = b.AllStores,
             Status = b.Status,
             Notes = b.Notes
         })
         .ToListAsync();
        }
    }
}
