using Store.Core.Entities.Products;
using Store.Infrastructure.Data;

namespace Store.Infrastructure.Repositories
{
    public class CategorysRepository : GenericRepository<Category>
    {
        public CategorysRepository(ApplicationDbContext context) : base(context)
        {
        }
    }

}
