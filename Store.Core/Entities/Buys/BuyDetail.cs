using System.ComponentModel.DataAnnotations.Schema;
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


        [ForeignKey("Order_ID")]
        public virtual Buy Buy { get; set; }

        [ForeignKey("Pro_ID")]
        public virtual Product Product { get; set; }

        [ForeignKey("Sup_ID")]
        public virtual Supplier Supplier { get; set; }
    }
}