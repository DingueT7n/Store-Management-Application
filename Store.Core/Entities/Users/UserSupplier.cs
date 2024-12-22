namespace Store.Core.Entities.Users
{
    public class UserSupplier : BaseEntity<int>
    {
        public UserSupplier(bool b)
        {
            AllSuppliers = b;
            AddSuppliers = b;
            SuppliersAccount = b;
            SuppliersReport = b;
        }
        public UserSupplier()
        {

        }
        public int User_Id { get; set; }
        public bool AllSuppliers { get; set; }
        public bool AddSuppliers { get; set; }
        public bool SuppliersAccount { get; set; }
        public bool SuppliersReport { get; set; }
        public User User { get; set; }
    }
}
