using System.ComponentModel.DataAnnotations.Schema;
using Store.Core.Entities.Products;

namespace Store.Core.Entities.Returns
{
    public class ReturnDetail : BaseEntity<int>
    {

        public int Order_ID { get; set; }  // Foreign key to Return
        public int Pro_ID { get; set; }
        public string Sup_Name { get; set; }
        public string Cust_Name { get; set; }
        public string Date { get; set; }
        public float Qty { get; set; }
        public float Price { get; set; }
        public float Total { get; set; }
        public float TaxValue { get; set; }
        public float PriceWithTax { get; set; }


        // Navigation property for the relationship with Returns
        [ForeignKey("Order_ID")]
        public virtual Return Returns { get; set; }


        [ForeignKey("Pro_ID")]
        public virtual Product Product { get; set; }
    }
}