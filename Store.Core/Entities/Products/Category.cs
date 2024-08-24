namespace Store.Core.Entities.Products
{
    public class Category : BaseEntity<int>
    {
        public string CategoryName { get; set; }

        //public virtual ICollection<Product> Products { get; set; } = new HashSet<Product>();
        public override string ToString()
        {
            return $"{CategoryName}";
        }

    }
}