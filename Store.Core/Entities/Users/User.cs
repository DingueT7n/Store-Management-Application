namespace Store.Core.Entities.Users
{
    public class User : BaseEntity<int>
    {
        public string UserName { get; set; }
        public string Password { get; set; }
        public string type { get; set; }
        public int Stock_Id { get; set; }
        public decimal UserProfit { get; set; }
        // Navigation Properties
        public UserBuy UserBuy { get; set; }
        public UserCaisseAndBank UserCaisseAndBank { get; set; }
        public UserCustomer UserCustomer { get; set; }
        public UserDeservedAndTax UserDeservedAndTax { get; set; }
        public UserEmployee UserEmployee { get; set; }
        public UserProductAndStore UserProductAndStore { get; set; }
        public UserRefund UserRefund { get; set; }
        public UserSale UserSale { get; set; }
        public UserSetting UserSetting { get; set; }
        public UserSupplier UserSupplier { get; set; }


    }
}
