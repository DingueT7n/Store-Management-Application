namespace Store.Core.Entities.Users
{
    public class UserSale : BaseEntity<int>
    {
        public UserSale(bool b)
        {
            NewSale = b;
            SaleReports = b;
            SaleProfits = b;
        }
        public UserSale()
        {

        }

        public int User_Id { get; set; }
        public bool NewSale { get; set; }
        public bool SaleReports { get; set; }
        public bool SaleProfits { get; set; }
        public User User { get; set; }

    }
}
