namespace Store.Core.Entities.Vouchers
{
    public class ReceiptVoucher : BaseEntity<int>
    {
        public string ReciverName { get; set; }

        public float? Price { get; set; }

        public DateTime Date { get; set; }
        public string Time { get; set; }

        public string From { get; set; }

        public string Reason { get; set; }
    }
}
