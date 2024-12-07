namespace Store.Core.Entities.Users
{
    public class UserCustomer : BaseEntity<int>
    {
        public int User_Id { get; set; }
        public bool AllCustomers { get; set; }
        public bool AddCustomer { get; set; }
        public bool CustomerAccount { get; set; }
        public bool CustomerReport { get; set; }
        public User User { get; set; }

    }
}
