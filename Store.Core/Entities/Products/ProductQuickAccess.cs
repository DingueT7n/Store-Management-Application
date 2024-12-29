namespace Store.Core.Entities.Products
{
    public class ProductQuickAccess : BaseEntity<int>
    {
        public int Pro_Id { get; set; }
        public string CodeBar { get; set; }
        public string ProductName { get; set; }
        public byte[] ProductImage { get; set; }
        public virtual Product Product { get; set; }
    }

    //Table BadProduct

}
