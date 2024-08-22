using Store.Infrastructure.Data;

namespace Store.Infrastructure.Repositories
{
    public class StoresRepository : GenericRepository<Store.Core.Entities.Stores.Store>
    {
        public StoresRepository(ApplicationDbContext context) : base(context)
        {
        }
    }
}
