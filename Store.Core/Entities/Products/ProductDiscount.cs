namespace Store.Core.Entities.Products
{
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
        public virtual Stores.Store Store { get; set; }
    }

    //Table BadProduct

}
