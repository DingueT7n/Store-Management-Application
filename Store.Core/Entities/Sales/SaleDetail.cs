using Store.Core.Entities.Customers;
using Store.Core.Entities.Products;

namespace Store.Core.Entities.Sales
{
    public class SaleDetail : BaseEntity<int>
    {

        public int Order_ID { get; set; }
        public int Cust_ID { get; set; }
        public int Pro_ID { get; set; }
        public decimal Quentity { get; set; }
        public decimal Price { get; set; }
        public decimal Discount { get; set; }
        public decimal Total { get; set; }
        public decimal TaxValue { get; set; }
        public decimal PriceWithTax { get; set; }


        public virtual Sale Sale { get; set; }


        public virtual Product Product { get; set; }

        public virtual Customer Customer { get; set; }
    }
    public class SaleDetailDto
    {
        public int Order_ID { get; set; }
        public string CustomerName { get; set; }
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
}