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
        public decimal Qty { get; set; }
        public decimal Price { get; set; }
        public decimal Total { get; set; }
        public decimal TaxValue { get; set; }
        public decimal PriceWithTax { get; set; }


        // Navigation property for the relationship with Returns

        public virtual Return Returns { get; set; }



        public virtual Product Product { get; set; }
    }
}