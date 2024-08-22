using Store.Core.Entities.Returns;
using Store.Core.Interfaces;
using Store.Infrastructure.Data;

namespace Store.Infrastructure.Repositories
{
    public class ReturnsRepository : GenericRepository<Return>, IReturnsRepository
    {
        public ReturnsRepository(ApplicationDbContext context) : base(context)
        {
        }
    }
    public class ReturnDetailRepository : GenericRepository<ReturnDetail>, IReturnDetailRepository
    {
        public ReturnDetailRepository(ApplicationDbContext context) : base(context)
        {
        }
    }
}
