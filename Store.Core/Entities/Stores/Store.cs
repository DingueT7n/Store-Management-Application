namespace Store.Core.Entities.Stores
{
    public partial class Store : BaseEntity<int>
    {

        public string StoreName { get; set; }
        public override string ToString()
        {
            return StoreName;
        }



    }
    public enum InventoryType
    {
        Annual,
        Periodic,
        Rolling,
        ManualCorrection
    }
}
