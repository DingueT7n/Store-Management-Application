namespace Store.Core.Entities.Users
{
    public class UserRefund : BaseEntity<int>
    {
        public UserRefund(bool b)
        {
            RefundProduct = b;
            RefundReport = b;
        }
        public UserRefund()
        {

        }
        public int User_Id { get; set; }
        public bool RefundProduct { get; set; }
        public bool RefundReport { get; set; }
        public User User { get; set; }

    }
}
