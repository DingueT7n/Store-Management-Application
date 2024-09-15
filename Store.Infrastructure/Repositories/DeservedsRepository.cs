using Store.Core.Entities.AllDeserved;
using Store.Infrastructure.Data;

namespace Store.Infrastructure.Repositories
{
    public class DeservedsRepository : GenericRepository<Deserved>
    {
        public DeservedsRepository(ApplicationDbContext context) : base(context)
        {
        }


    }
}
