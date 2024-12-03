namespace Store.Core.Entities.Returns
{
    public class Return : BaseEntity<int>
    {
        public DateTime OrderDate { get; set; }
        public string Time { get; set; }
        public string OrderType { get; set; }
        public string User_Name { get; set; }
        public decimal TotalOrder { get; set; }
        public decimal PaidUP { get; set; }
        public decimal Remain { get; set; }
    }
}