using Store.Core.Entities.Suppliers;
using Store.Core.Interfaces;
using Store.Infrastructure.Data;

namespace Store.Infrastructure.Repositories
{
    public class SuppliersRepository : GenericRepository<Supplier>, ISuppliersRepository
    {
        public SuppliersRepository(ApplicationDbContext context) : base(context)
        {
        }
    }
    public class SupplierMoneyRepository : GenericRepository<SupplierMoney>, ISupplierMoneyRepository
    {
        public SupplierMoneyRepository(ApplicationDbContext context) : base(context)
        {
        }
    }
    public class SupplierReportRepository : GenericRepository<SupplierReport>, ISupplierReportRepository
    {
        public SupplierReportRepository(ApplicationDbContext context) : base(context)
        {
        }
    }
}
