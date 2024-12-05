namespace Store.Core.Entities.Products
{
    public class Product : BaseEntity<int>
    {
        public string CodeBar { get; set; }
        public string ProductName { get; set; }
        public decimal Quentity { get; set; }
        public decimal BuyPrice { get; set; }
        public decimal SalePrice { get; set; }
        public decimal WholesalePrice { get; set; }
        public decimal TaxValue { get; set; }
        public decimal SalePriceTax { get; set; }
        public bool IsTaxed { get; set; }
        public DateTime DateExperation { get; set; }
        public decimal MinQty { get; set; }
        public decimal MaxDiscount { get; set; }
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
        public virtual Product Product { get; set; }
    }
    public class ProductDiscount : BaseEntity<int>
    {
        public int Pro_Id { get; set; }
        public int Store_Id { get; set; }
        public decimal DiscountValue { get; set; }
        public decimal? Quentity { get; set; }
        public DateTime? DateStart { get; set; }
        public string? TimeStart { get; set; }
        public DateTime? DateEnd { get; set; }
        public string? TimeEnd { get; set; }

        public virtual Product Product { get; set; }
    }

    //Table BadProduct

}
