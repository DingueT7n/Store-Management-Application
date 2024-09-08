using Store.Core.Entities.Customers;
using Store.Core.Entities.Products;

namespace Store.Core.Entities.Sales
{
    public class SaleDetail : BaseEntity<int>
    {

        public int Order_ID { get; set; }
        public int Cust_ID { get; set; }
        public int Pro_ID { get; set; }
        public float Quentity { get; set; }
        public float Price { get; set; }
        public float Discount { get; set; }
        public float Total { get; set; }
        public float TaxValue { get; set; }
        public float PriceWithTax { get; set; }


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