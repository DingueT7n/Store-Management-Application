using System.ComponentModel.DataAnnotations.Schema;

namespace Store.Core.Entities.Products
{
    public class ProductTransfer : BaseEntity<int>
    {
        public int Pro_ID { get; set; }
        public string Pro_Name { get; set; }
        public string StoreFrom { get; set; }
        public string StoreTo { get; set; }
        public float Quentity { get; set; }
        public float BuyPrice { get; set; }
        public float SalePrice { get; set; }
        public string Date { get; set; }
        public string Name { get; set; }
        public string Reason { get; set; }
        public float TaxValue { get; set; }
        public float PriceTax { get; set; }
        public float SalePriceTax { get; set; }

        [ForeignKey("Pro_ID")]
        public virtual Product Product { get; set; }
    }


}
