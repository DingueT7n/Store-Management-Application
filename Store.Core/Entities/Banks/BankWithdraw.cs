namespace Store.Core.Entities.Banks
{
    public class BankWithdraw : BaseEntity<int>
    {
        public decimal Money { get; set; }
        public DateTime Date { get; set; }
        public string Time { get; set; }
        public string Name { get; set; }
        public string Type { get; set; }
        public string Reason { get; set; }
    }

}
