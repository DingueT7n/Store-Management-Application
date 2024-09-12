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
    public class SaleProfitDto
    {
        public int Order_ID { get; set; }
        public int Pro_ID { get; set; }
        public string ProductName { get; set; }
        public string Cust_Name { get; set; }
        public decimal Tax_Value { get; set; }
        public decimal Quentity { get; set; }
        public decimal Price { get; set; }
        public decimal Buy_Price { get; set; }
        public decimal Discount { get; set; }
        public decimal Total { get; set; }

        public decimal profit { get; set; }
        public decimal TotalFacture { get; set; }
        public decimal PaidUp { get; set; }
        public decimal Remain { get; set; }
        public string Time { get; set; }
        public DateTime date { get; set; }
        public string Sallesman { get; set; }


    }



}
