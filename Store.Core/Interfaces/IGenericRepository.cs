using System.Linq.Expressions;
using Store.Core.Entities;

namespace Store.Core.Interfaces
{
    public interface IGenericRepository<T> where T : BaseEntity<int>
    {
        List<T> GetAllData(); // Admin
        Task<List<T>> GetAllAsync();
        List<T> GetDataByUser(string userId);
        List<T> SearchAll(string searchItem);
        List<T> SearchByUser(string userId, string searchItem);
        T Find(string id);
        Task<List<T>> GetAll();
        Task<string> DeleteAsync(string id);
        Task<T> GetAsync(int id);
        T Get(int id);
        Task<IEnumerable<T>> GetAllAsync(params Expression<Func<T, object>>[] includes);
        IEnumerable<T> GetAll(params Expression<Func<T, object>>[] includes);
        Task<T> GetByIdAsync(int id, params Expression<Func<T, object>>[] includes);
        T GetById(int id, params Expression<Func<T, object>>[] includes);

        bool IsConnected();
        Task<bool> IsConnectedAsync();
        Task<string> AddAsync(T entity); // 1 == succeded ? Error
        Task<string> UpdateAsync(string id, T entity);

    }
}
