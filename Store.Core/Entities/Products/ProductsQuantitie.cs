namespace Store.Core.Entities.Products
{
    public class ProductsQuantitie : BaseEntity<int>
    {
        public int Pro_ID { get; set; }
        public int Store_ID { get; set; }
        public string StoreName { get; set; }
        public decimal Qty { get; set; }
        public decimal Buy_Price { get; set; }
        public decimal Sale_PriceTax { get; set; }
        public DateTime DateExpiration { get; set; }
        public virtual Product Product { get; set; }
        public virtual Core.Entities.Stores.Store Store { get; set; }
    }





}
