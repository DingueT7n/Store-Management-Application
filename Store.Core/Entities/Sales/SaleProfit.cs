using Store.Core.Entities.Products;
namespace Store.Core.Entities.Sales
{
    public class SaleProfit : BaseEntity<int>
    {
        public int Order_ID { get; set; }
        public string Cust_Name { get; set; }
        public int Pro_ID { get; set; }
        public decimal Quentity { get; set; }
        public decimal Price { get; set; }
        public decimal Discount { get; set; }
        public decimal Total { get; set; }
        public decimal Tax_Value { get; set; }
        public decimal Price_Tax { get; set; }
        public string Time { get; set; }
        public decimal Buy_Price { get; set; }
        public virtual Sale Sale { get; set; }

        public virtual Product Product { get; set; }
    }



}
