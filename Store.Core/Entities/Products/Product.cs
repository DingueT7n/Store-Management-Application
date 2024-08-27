using System.ComponentModel.DataAnnotations.Schema;

namespace Store.Core.Entities.Products
{
    public class Product : BaseEntity<int>
    {
        public string CodeBar { get; set; }
        public string ProductName { get; set; }
        public float Quentity { get; set; }
        public float BuyPrice { get; set; }
        public float SalePrice { get; set; }
        public float WholesalePrice { get; set; }
        public float TaxValue { get; set; }
        public float SalePriceTax { get; set; }
        public bool IsTaxed { get; set; }
        public DateTime DateExperation { get; set; }
        public float? MinQty { get; set; }
        public float? MaxDiscount { get; set; }
        public byte[] ProductImage { get; set; }


        // Navigation Properties
        public int CategoryId { get; set; } // Group
        public virtual Category Category { get; set; }
    }
    public class ProductQuickAccess : BaseEntity<int>
    {
        public int Pro_Id { get; set; }
        public string CodeBar { get; set; }
        public string ProductName { get; set; }
        public byte[] ProductImage { get; set; }
        [ForeignKey("Pro_Id")]
        public virtual Product Product { get; set; }
    }
    public class ProductDiscount : BaseEntity<int>
    {
        public int Pro_Id { get; set; }
        public int Store_Id { get; set; }
        public float DiscountValue { get; set; }
        public float? Quentity { get; set; }
        public DateTime? DateStart { get; set; }
        public string? TimeStart { get; set; }
        public DateTime? DateEnd { get; set; }
        public string? TimeEnd { get; set; }
        [ForeignKey("Pro_Id")]
        public virtual Product Product { get; set; }
    }

    //Table BadProduct

}
