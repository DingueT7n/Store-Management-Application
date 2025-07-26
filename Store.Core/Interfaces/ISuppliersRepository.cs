using Store.Core.Entities.Suppliers;

namespace Store.Core.Interfaces
{
    public interface ISuppliersRepository : IGenericRepository<Supplier>
    {
        public Task<List<Supplier>> SearchAll(string searchIteam);

    }
    public interface ISupplierMoneyRepository : IGenericRepository<SupplierMoney>
    {
        public Task<List<SupplierMoney>> SearchAll(string searchIteam);
        public Task<bool> DeleteFacture(string order_Id, string sup_id, string price);
        public Task<bool> TransactionOfSupplierDebt(string order_Id, string sup_Id, string price, string sup_Name, DateTime date);
        public Task<bool> UpdateFacture(string order_Id, string sup_Id, string price, string PayedValue);
        public Task<bool> TransactionOfEditingSupplierDebt(string order_Id, string sup_Id, string price, string sup_Name, string PayedValue, DateTime date
           );

    }
    public interface ISupplierReportRepository : IGenericRepository<SupplierReport>
    {
        public Task<SupplierReportDto> GetAllData(int skip, int take);
        public Task<SupplierReportDto> SearchBoth(string searchItem, DateTime fromDate, DateTime toDate, int take, int skip);
        public Task<SupplierReportDto> SearchOnlyDate(DateTime fromDate, DateTime toDate, int take, int skip);
        public Task<SupplierReportDto> SearchOnlySupplier(string searchItem, int take, int skip);

    }
}
