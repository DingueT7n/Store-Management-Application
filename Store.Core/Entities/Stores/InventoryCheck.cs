using Store.Core.Entities.Products;

namespace Store.Core.Entities.Stores
{

    public class InventoryCheck : BaseEntity<int>
    {
        public int ProductId { get; set; }
        public Product Product { get; set; }
        public decimal ExpectedQty { get; set; }  // Quantity from system
        public decimal ActualQty { get; set; }    // Quantity counted by user
        public decimal Difference => ActualQty - ExpectedQty;
        public decimal LossValue => Difference < 0 ? (-1 * Difference * Product.BuyPrice) : 0;
        public int InventorySessionId { get; set; }
        public InventorySession InventorySession { get; set; }
        public DateTime CheckedAt { get; set; } = DateTime.Now;
        public string CheckedBy { get; set; }
    }


}
