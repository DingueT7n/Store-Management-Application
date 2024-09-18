using Store.Core.Entities.Products;
using Store.Core.Entities.Suppliers;


namespace Store.Core.Entities.Buys
{
    public class BuyDetail : BaseEntity<int>
    {
        public int Order_ID { get; set; }
        public int Sup_ID { get; set; }
        public int Pro_ID { get; set; }
        public decimal Quentity { get; set; }
        public decimal Price { get; set; }
        public decimal Discount { get; set; }
        public decimal Total { get; set; }
        public decimal TaxValue { get; set; }
        public decimal PriceWithTax { get; set; }
        public virtual Buy Buy { get; set; }
        public virtual Product Product { get; set; }
        public virtual Supplier Supplier { get; set; }
    }

    public class BuyDetailDto
    {
        public int Order_ID { get; set; }
        public string SupplierName { get; set; }
        public DateTime Date { get; set; }
        public string Time { get; set; }
        public string ProductName { get; set; }
        public decimal Quantity { get; set; }
        public decimal PriceWithTax { get; set; }
        public decimal Discount { get; set; }
        public decimal TotalPrice { get; set; }
        public string User_Name { get; set; }
        public decimal TotalFacture { get; set; }
        public decimal PaidUp { get; set; }
        public decimal Remain { get; set; }
    }
    public class BuyDetailDtoResult
    {
        public List<BuyDetailDto> result { get; set; }
        public int Count { get; set; }
    }
}