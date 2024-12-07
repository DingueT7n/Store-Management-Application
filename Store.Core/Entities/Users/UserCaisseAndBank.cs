namespace Store.Core.Entities.Users
{
    public class UserCaisseAndBank : BaseEntity<int>
    {
        public int User_Id { get; set; }
        public bool CaissesAndBanks { get; set; }
        public bool DepositToCaisse { get; set; }
        public bool DepositToBank { get; set; }
        public bool WithdrawFromCaisse { get; set; }
        public bool WithdrawFromBank { get; set; }
        public bool TransfertBetweenCaisse { get; set; }
        public bool TransfertBetweenCaisseAndBank { get; set; }
        public User User { get; set; }

    }
}
