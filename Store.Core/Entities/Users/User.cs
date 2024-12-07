namespace Store.Core.Entities.Users
{
    public class User : BaseEntity<int>
    {
        public string UserName { get; set; }
        public string Password { get; set; }
        public string type { get; set; }
        public int Stock_Id { get; set; }
        public decimal UserProfit { get; set; }

    }
}
