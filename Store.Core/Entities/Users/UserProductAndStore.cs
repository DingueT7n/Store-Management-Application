namespace Store.Core.Entities.Users
{
    public class UserProductAndStore : BaseEntity<int>
    {
        public UserProductAndStore(bool b)
        {
            AllProducts = b;
            AddProduct = b;
            AllCategories = b;
            StoreInventory = b;
            TransfertReport = b;
            ProductOutStoreReport = b;
            allStores = b;
        }
        public UserProductAndStore()
        {

        }
        public int User_Id { get; set; }
        public bool AllProducts { get; set; }
        public bool AddProduct { get; set; }
        public bool allStores { get; set; }
        public bool AllCategories { get; set; }
        public bool StoreInventory { get; set; }
        public bool TransfertReport { get; set; }
        public bool ProductOutStoreReport { get; set; }
        public User User { get; set; }

    }
}
