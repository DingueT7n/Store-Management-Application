using Store.Core.Entities.AllDeserved;

namespace Store.Core.Interfaces
{
    public interface IDeservedsRepository : IGenericRepository<Deserved>
    {
        public Task<List<Deserved>> SearchBoth(string searchItem, DateTime fromDate, DateTime toDate);
        public Task<List<Deserved>> SearchOnlyDate(DateTime fromDate, DateTime toDate);
        public Task<List<Deserved>> SearchOnlyDeserved(string searchItem);
        public List<Deserved> GetAllData();
    }
    public interface IDeservedTypesRepository : IGenericRepository<DeservedType>
    {
    }
}
