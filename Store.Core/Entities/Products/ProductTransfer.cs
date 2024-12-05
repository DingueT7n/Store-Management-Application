namespace Store.Core.Entities.Products
{
    public class ProductTransfer : BaseEntity<int>
    {
        public int Pro_ID { get; set; }
        public string Pro_Name { get; set; }
        public string StoreFrom { get; set; }
        public string StoreTo { get; set; }
        public decimal Quentity { get; set; }
        public decimal BuyPrice { get; set; }
        public decimal SalePrice { get; set; }
        public string Date { get; set; }
        public string Name { get; set; }
        public string Reason { get; set; }




        public virtual Product Product { get; set; }
    }



}
