namespace Store.Core.Entities.Users
{
    public class UserDeservedAndTax : BaseEntity<int>
    {
        public int User_Id { get; set; }
        public bool Deserved { get; set; }
        public bool Vouchers { get; set; }
        public User User { get; set; }

    }
}
