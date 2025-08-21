namespace Store.Core.Entities.Stores
{
    public enum inventoryStatus
    {
        Open,
        Closed
    }
    public class InventorySession : BaseEntity<int>
    {
        public int? StoreId { get; set; }
        public Store? Store { get; set; }
        public string PerformedBy { get; set; }
        public bool AllStores { get; set; } = false; // Indicates if this inventory session is for all stores
        public DateTime DateStarted { get; set; }
        public DateTime? DateEnded { get; set; }
        public inventoryStatus Status { get; set; } = inventoryStatus.Open;
        // public InventoryType Type { get; set; } = InventoryType.Annual;
        public string Notes { get; set; }

        public ICollection<InventoryCheck> InventoryChecks { get; set; }
    }
    public class InventorySessionDTO
    {
        //public int? StoreId { get; set; }
        public int Id { get; set; }
        public Store? Store { get; set; }
        public string PerformedBy { get; set; }
        public DateTime DateStarted { get; set; }
        public DateTime? DateEnded { get; set; }
        public bool AllStores { get; set; }
        public inventoryStatus Status { get; set; } = inventoryStatus.Open;
        // public InventoryType Type { get; set; } = InventoryType.Annual;
        public string Notes { get; set; }
    }


}
