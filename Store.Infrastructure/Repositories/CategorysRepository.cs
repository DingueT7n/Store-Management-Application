using Store.Core.Entities.Products;
using Store.Core.Interfaces;
using Store.Infrastructure.Data;

namespace Store.Infrastructure.Repositories
{
    public class CategorysRepository : GenericRepository<Category>, ICategoryRepository
    {
        public CategorysRepository(ApplicationDbContext context) : base(context)
        {
        }
    }

}
