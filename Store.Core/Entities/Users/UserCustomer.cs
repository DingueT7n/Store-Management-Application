namespace Store.Core.Entities.Users
{
    public class UserCustomer : BaseEntity<int>
    {
        public UserCustomer(bool b)
        {
            AllCustomers = b;
            AddCustomer = b;
            CustomerAccount = b;
            CustomerReport = b;
        }
        public UserCustomer()
        {

        }
        public int User_Id { get; set; }
        public bool AllCustomers { get; set; }
        public bool AddCustomer { get; set; }
        public bool CustomerAccount { get; set; }
        public bool CustomerReport { get; set; }
        public User User { get; set; }

    }
}
