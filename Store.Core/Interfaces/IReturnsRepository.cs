using Store.Core.Entities.Returns;

namespace Store.Core.Interfaces
{
    public interface IReturnsRepository : IGenericRepository<Return>
    {
        //Task<Category> GetAsync(int id);
    }
    public interface IReturnDetailRepository : IGenericRepository<ReturnDetail>
    {
        //Task<Category> GetAsync(int id);
    }
}
