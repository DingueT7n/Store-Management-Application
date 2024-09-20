using Microsoft.EntityFrameworkCore;
using Store.Core.Entities.AllDeserved;
using Store.Infrastructure.Data;

namespace Store.Infrastructure.Repositories
{
    public class DeservedsRepository : GenericRepository<Deserved>
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
        public List<Deserved> SearchBoth(string searchItem, DateTime fromDate, DateTime toDate)
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

                var result = query
                    .OrderByDescending(x => x.Date).AsNoTracking()
                    .ToList();

                return result;
            }
            catch
            {
                return new();
            }
        }
        public List<Deserved> SearchOnlyDate(DateTime fromDate, DateTime toDate)
        {
            try
            {
                var query = _context.Deserveds.AsNoTracking().Include(x => x.DeservedType)
                    .Where(x => fromDate <= x.Date && x.Date <= toDate)
                    .OrderByDescending(x => x.Date);

                return query.ToList();
            }
            catch
            {
                return new();
            }
        }
        public List<Deserved> SearchOnlyCustomer(string searchItem)
        {
            try
            {
                var query = _context.Deserveds.Include(x => x.DeservedType)
                    .Where(x =>
                       (x.UserName.ToLower().Contains(searchItem.ToLower()) ||
                        x.Id.ToString() == searchItem || x.Price.ToString() == searchItem || x.Notes.Contains(searchItem) || x.DeservedType.Description.ToLower().Contains(searchItem.ToLower())));
                var result = query
                    .OrderByDescending(x => x.Date).AsNoTracking()
                    .ToList();



                return result;
            }
            catch
            {
                return new();
            }
        }

    }
}
