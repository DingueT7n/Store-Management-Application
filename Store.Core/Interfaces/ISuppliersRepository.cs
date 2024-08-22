using Store.Core.Entities.Suppliers;

namespace Store.Core.Interfaces
{
    public interface ISuppliersRepository : IGenericRepository<Supplier>
    {

    }
    public interface ISupplierMoneyRepository : IGenericRepository<SupplierMoney>
    {

    }
    public interface ISupplierReportRepository : IGenericRepository<SupplierReport>
    {

    }
}
