namespace Store.Core.Entities.Users
{
    public class UserBuy : BaseEntity<int>
    {
        public int User_Id { get; set; }
        public bool NewBuy { get; set; }
        public bool BuyReports { get; set; }
        public User User { get; set; }

    }
}
