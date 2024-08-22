using System.Linq.Expressions;
using Microsoft.EntityFrameworkCore;
using Store.Core.Entities;
using Store.Core.Interfaces;
using Store.Infrastructure.Data;

namespace Store.Infrastructure.Repositories
{
    public class GenericRepository<T> : IGenericRepository<T> where T : BaseEntity<int>
    {
        private ApplicationDbContext _context;

        public GenericRepository(ApplicationDbContext context)
        {
            _context = context;
        }


        public async Task<bool> AddAsync(T entity)
        {
            await _context.Set<T>().AddAsync(entity);
            await _context.SaveChangesAsync();
            return true;
        }

        public async Task<bool> DeleteAsync(int id)
        {
            var entity = await _context.Set<T>().FindAsync(id);
            if (entity is null)
                return false;
            _context.Set<T>().Remove(entity);
            await _context.SaveChangesAsync();
            return true;
        }

        public T Get(int id)
        {
            throw new NotImplementedException();
        }

        public IEnumerable<T> GetAll() => _context.Set<T>().AsNoTracking().ToList();


        public IEnumerable<T> GetAll(params Expression<Func<T, object>>[] includes)
        {
            var query = _context.Set<T>().AsQueryable();
            foreach (var item in includes)
            {
                query = query.Include(item);
            }
            return query.ToList();
        }

        public async Task<IReadOnlyList<T>> GetAllAsync() => await _context.Set<T>().AsNoTracking().ToListAsync();

        public async Task<IEnumerable<T>> GetAllAsync(params Expression<Func<T, object>>[] includes)
        {
            var query = _context.Set<T>().AsQueryable();
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
            IQueryable<T> query = _context.Set<T>().Where(x => x.Id == id);
            foreach (var item in includes)
            {
                query = query.Include(item);
            }

            return await (query).FirstOrDefaultAsync();
        }

        public async Task<bool> UpdateAsync(int id, T entity)
        {


            if (entity == null)
            {
                return false;
            }


            var existingEntity = await _context.Set<T>().FindAsync(id);

            if (existingEntity == null)
            {
                return false;
            }


            _context.Entry(existingEntity).CurrentValues.SetValues(entity);


            try
            {
                await _context.SaveChangesAsync();
                return true;
            }
            catch (DbUpdateException ex)
            {

                return false;
            }
        }
    }
}
