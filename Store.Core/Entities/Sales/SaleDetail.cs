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
}