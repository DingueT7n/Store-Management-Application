using Store.Core.Entities.Products;
namespace Store.Core.Entities.Sales
{
    public class SaleProfit : BaseEntity<int>
    {
        public int Order_ID { get; set; }
        public string Cust_Name { get; set; }
        public int Pro_ID { get; set; }
        public float? Quentity { get; set; }
        public float? Price { get; set; }
        public float? Discount { get; set; }
        public float? Total { get; set; }
        public float? Tax_Value { get; set; }
        public float? Price_Tax { get; set; }
        public string Time { get; set; }
        public float? Buy_Price { get; set; }


        public virtual Sale Sale { get; set; }

        public virtual Product Product { get; set; }
    }



}
