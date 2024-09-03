using Store.Core.Entities.Products;
using Store.Core.Entities.Suppliers;


namespace Store.Core.Entities.Buys
{
    public class BuyDetail : BaseEntity<int>
    {
        public int Order_ID { get; set; }
        public int Sup_ID { get; set; }
        public int Pro_ID { get; set; }
        public float Quentity { get; set; }
        public float Price { get; set; }
        public float Discount { get; set; }
        public float Total { get; set; }
        public float TaxValue { get; set; }
        public float PriceWithTax { get; set; }
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
        public float Quantity { get; set; }
        public float PriceWithTax { get; set; }
        public float Discount { get; set; }
        public float TotalPrice { get; set; }
        public string User_Name { get; set; }
        public float TotalFacture { get; set; }
        public float PaidUp { get; set; }
        public float Remain { get; set; }
    }
}