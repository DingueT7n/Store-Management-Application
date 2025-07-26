using System.Linq.Expressions;
using Microsoft.EntityFrameworkCore;
using Store.Core.Entities;
using Store.Core.Interfaces;
using Store.Infrastructure.Data;

namespace Store.Infrastructure.Repositories
{
    public class GenericRepository<T> : IGenericRepository<T> where T : BaseEntity<int>
    {
        internal ApplicationDbContext _context;

        public GenericRepository(ApplicationDbContext context)
        {
            _context = context;
        }

        public List<T> GetAllData()
        {
            try
            {

                return _context.Set<T>().AsNoTracking().ToList();

            }
            catch
            {
                return new List<T>();
            }
        }
        public async Task<string> AddAsync(T entity)
        {
            try
            {
                await _context.Set<T>().AddAsync(entity);
                await _context.SaveChangesAsync();
                return "1";
            }
            catch (Exception ex)
            {
                return ex.Message;
            }
        }

        public async Task<string> DeleteAsync(string id)
        {
            try
            {
                var entity = await _context.Set<T>().FindAsync(Convert.ToInt32(id));
                if (entity is not null)
                {
                    _context.Set<T>().Remove(entity);
                    await _context.SaveChangesAsync();
                }
            }
            catch (Exception ex)
            {

                return ex.Message;
            }

            return "1";
        }

        public T Find(string id)
        {
            try
            {
                IQueryable<T> query = _context.Set<T>().AsNoTracking().Where(x => x.Id.ToString() == id);
                return (query).FirstOrDefault();
            }
            catch (Exception)
            {

                return null;
            }

        }

        public T Get(int id)
        {
            try
            {
                return _context.Set<T>().Find(id);
            }
            catch
            {
                return null;
            }
        }

        public async Task<List<T>> GetAll() => await _context.Set<T>().AsNoTracking().ToListAsync();


        public IEnumerable<T> GetAll(params Expression<Func<T, object>>[] includes)
        {
            var query = _context.Set<T>().AsQueryable().AsNoTracking();
            foreach (var item in includes)
            {
                query = query.Include(item);
            }
            return query.ToList();
        }

        public async Task<List<T>> GetAllAsync() => await _context.Set<T>().AsNoTracking().ToListAsync();

        public async Task<IEnumerable<T>> GetAllAsync(params Expression<Func<T, object>>[] includes)
        {
            var query = _context.Set<T>().AsNoTracking().AsQueryable();
            foreach (var item in includes)
            {
                query = query.Include(item);
            }
            return await query.ToListAsync();
        }

        public async Task<T> GetAsync(int id) => await _context.Set<T>().FindAsync(id);

        public T GetById(int id, params Expression<Func<T, object>>[] includes)
        {
            throw new NotImplementedException();
        }

        public async Task<T> GetByIdAsync(int id, params Expression<Func<T, object>>[] includes)
        {
            IQueryable<T> query = _context.Set<T>().AsNoTracking().Where(x => x.Id == id);
            foreach (var item in includes)
            {
                query = query.Include(item);
            }

            return await (query).FirstOrDefaultAsync();
        }

        public List<T> GetDataByUser(string userId)
        {
            try
            {
                return _context.Set<T>().AsNoTracking().Where(x => x.Id.ToString() == userId).ToList();
            }
            catch (Exception)
            {

                return new List<T>();
            }
        }

        public bool IsConnected()
        {
            return _context.Database.CanConnect();
        }

        public List<T> SearchAll(string searchItem)
        {
            if (string.IsNullOrWhiteSpace(searchItem))
            {
                return new List<T>();
            }
            try
            {
                var properties = typeof(T).GetProperties();
                IQueryable<T> query = _context.Set<T>().AsNoTracking();

                // Dynamically build the query by checking each property
                query = query.Where(x => properties.Any(p =>
                    p.GetValue(x) != null &&
                    p.GetValue(x).ToString().Contains(searchItem, StringComparison.OrdinalIgnoreCase)
                ));

                return query.ToList();
            }
            catch (Exception)
            {
                // If there's an error, return an empty list
                return new List<T>();
            }
        }

        public List<T> SearchByUser(string userId, string searchItem)
        {
            if (string.IsNullOrWhiteSpace(searchItem))
            {
                return new List<T>();
            }
            try
            {
                var properties = typeof(T).GetProperties();
                IQueryable<T> query = _context.Set<T>();

                // Dynamically build the query by checking each property
                query = query.Where(x => x.Id.ToString() == userId).Where(x => properties.Any(p =>
                    p.GetValue(x) != null &&
                    p.GetValue(x).ToString().Contains(searchItem, StringComparison.OrdinalIgnoreCase)
                ));

                return query.ToList();
            }
            catch (Exception)
            {
                // If there's an error, return an empty list
                return new List<T>();
            }
        }

        public async Task<string> UpdateAsync(string id, T entity)
        {
            try
            {
                var existingEntity = await _context.Set<T>().FindAsync(Convert.ToInt32(id));
                if (existingEntity is null)
                    return "Entity not found";

                _context.Entry(existingEntity).CurrentValues.SetValues(entity);
                await _context.SaveChangesAsync();
                return "1";
            }
            catch (Exception ex)
            {
                return ex.Message;
            }
        }

        public async Task<bool> IsConnectedAsync()
        {
            return await _context.Database.CanConnectAsync();
        }
    }
}
