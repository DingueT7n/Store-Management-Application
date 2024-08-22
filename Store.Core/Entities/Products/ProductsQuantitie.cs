using System.ComponentModel.DataAnnotations.Schema;

namespace Store.Core.Entities.Products
{
    public class ProductsQuantitie : BaseEntity<int>
    {
        public int Pro_ID { get; set; }
        public int Store_ID { get; set; }
        public string StoreName { get; set; }
        public float Qty { get; set; }
        public float Buy_Price { get; set; }
        public float Sale_PriceTax { get; set; }


        [ForeignKey("Pro_ID")]
        public virtual Product Product { get; set; }

        [ForeignKey("Store_ID")]
        public virtual Core.Entities.Stores.Store Store { get; set; }
    }





}
