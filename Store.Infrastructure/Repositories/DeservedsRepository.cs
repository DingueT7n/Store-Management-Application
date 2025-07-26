using Microsoft.EntityFrameworkCore;
using Store.Core.Entities.AllDeserved;
using Store.Core.Interfaces;
using Store.Infrastructure.Data;

namespace Store.Infrastructure.Repositories
{
    public class DeservedsRepository : GenericRepository<Deserved>, IDeservedsRepository
    {
        public DeservedsRepository(ApplicationDbContext context) : base(context)
        {
        }
        public List<Deserved> GetAllData()
        {
            try
            {
                var query = _context.Deserveds.AsQueryable();
                var result = query.Include(x => x.DeservedType)
                    .OrderByDescending(x => x.Date).AsNoTracking()
                                  .ToList();
                return result;
            }
            catch
            {
                return new();
            }
        }
        public async Task<List<Deserved>> SearchBoth(string searchItem, DateTime fromDate, DateTime toDate)
        {
            try
            {
                var query = _context.Deserveds.Include(x => x.DeservedType)
                    .Where(x =>
                        (x.UserName.ToLower().Contains(searchItem.ToLower()) ||
                        x.Id.ToString() == searchItem || x.Price.ToString() == searchItem ||
                        x.Notes.Contains(searchItem) ||
                        x.DeservedType.Description.ToLower()
                        .Contains(searchItem.ToLower())) &&
                        fromDate <= x.Date && x.Date <= toDate);

                var result = await query
                    .OrderByDescending(x => x.Date).AsNoTracking()
                    .ToListAsync();

                return result;
            }
            catch
            {
                return new();
            }
        }
        public async Task<List<Deserved>> SearchOnlyDate(DateTime fromDate, DateTime toDate)
        {
            try
            {
                var query = _context.Deserveds.AsNoTracking().Include(x => x.DeservedType)
                    .Where(x => fromDate <= x.Date && x.Date <= toDate)
                    .OrderByDescending(x => x.Date);

                return await query.ToListAsync();
            }
            catch
            {
                return new();
            }
        }
        public async Task<List<Deserved>> SearchOnlyDeserved(string searchItem)
        {
            try
            {
                var query = _context.Deserveds.Include(x => x.DeservedType)
                    .Where(x =>
                       (x.UserName.ToLower().Contains(searchItem.ToLower()) ||
                        x.Id.ToString() == searchItem || x.Price.ToString() == searchItem || x.Notes.Contains(searchItem) || x.DeservedType.Description.ToLower().Contains(searchItem.ToLower())));
                var result = await query
                    .OrderByDescending(x => x.Date).AsNoTracking()
                    .ToListAsync();



                return result;
            }
            catch
            {
                return new();
            }
        }
        public class DeservedTypesRepository : GenericRepository<DeservedType>, IDeservedTypesRepository
        {
            public DeservedTypesRepository(ApplicationDbContext context) : base(context)
            {
            }
        }


    }
}
