using System.Linq.Expressions;
using Store.Core.Entities;

namespace Store.Core.Interfaces
{
    public interface IGenericRepository<T> where T : BaseEntity<int>
    {
        Task<IReadOnlyList<T>> GetAllAsync();
        IEnumerable<T> GetAll();
        Task<T> GetAsync(int id);
        T Get(int id);
        Task<IEnumerable<T>> GetAllAsync(params Expression<Func<T, object>>[] includes);
        IEnumerable<T> GetAll(params Expression<Func<T, object>>[] includes);
        Task<T> GetByIdAsync(int id, params Expression<Func<T, object>>[] includes);
        T GetById(int id, params Expression<Func<T, object>>[] includes);

        Task<bool> AddAsync(T entity);
        Task<bool> UpdateAsync(int id, T entity);
        Task<bool> DeleteAsync(int id);
    }
}
