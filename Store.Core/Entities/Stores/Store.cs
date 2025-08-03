using Store.Core.Entities.Products;

namespace Store.Core.Entities.Stores
{
    public class Store : BaseEntity<int>
    {

        public string StoreName { get; set; }
        public override string ToString()
        {
            return StoreName;
        }
        public enum inventoryStatus
        {
            Open,
            Closed
        }
        public class InventorySession
        {
            public int Id { get; set; }
            public string PerformedBy { get; set; }
            public DateTime DateStarted { get; set; }
            public DateTime? DateEnded { get; set; }
            public inventoryStatus Status { get; set; } = inventoryStatus.Open;

            public string Notes { get; set; }

            public ICollection<InventoryCheck> InventoryChecks { get; set; }
        }
        public class InventoryCheck
        {
            public int Id { get; set; }

            public int ProductId { get; set; }
            public Product Product { get; set; }

            public decimal ExpectedQty { get; set; }  // Quantity from system
            public decimal ActualQty { get; set; }    // Quantity counted by user

            public decimal Difference => ActualQty - ExpectedQty;
            public decimal LossValue => Difference < 0 ? (-1 * Difference * Product.BuyPrice) : 0;

            public int InventorySessionId { get; set; }
            public InventorySession InventorySession { get; set; }
        }

    }
}
