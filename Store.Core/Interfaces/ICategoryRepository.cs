using Store.Core.Entities.Products;

namespace Store.Core.Interfaces
{
    public interface ICategoryRepository : IGenericRepository<Category>
    {
        //Task<Category> GetAsync(int id);
    }
}
