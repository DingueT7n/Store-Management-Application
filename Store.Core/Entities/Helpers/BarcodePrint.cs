namespace Store.Core.Entities.Helpers
{
    public class BarcodePrint : BaseEntity<int>
    {

        public string ProductName { get; set; }
        public string ProductBarcode { get; set; }
        public string ProductPrice { get; set; }
        public string Barcode { get; set; }
    }
}
