namespace Store.Core.Entities.Users
{
    public class UserRefund : BaseEntity<int>
    {
        public int User_Id { get; set; }
        public bool RefundProduct { get; set; }
        public bool RefundReport { get; set; }
        public User User { get; set; }

    }
}
