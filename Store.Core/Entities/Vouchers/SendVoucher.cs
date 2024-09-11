namespace Store.Core.Entities.Vouchers
{
    public class SendVoucher : BaseEntity<int>
    {
        public string SenderName { get; set; }

        public decimal Price { get; set; }

        public DateTime Date { get; set; }
        public string Time { get; set; }

        public string To { get; set; }

        public string Reason { get; set; }
    }
}
