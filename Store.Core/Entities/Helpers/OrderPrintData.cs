namespace Store.Core.Entities.Helpers
{
    public class OrderPrintData : BaseEntity<int>
    {
        public byte[] Logo { get; set; }
        public string Name { get; set; }
        public string Address { get; set; }
        public string Description { get; set; }
        public string Phone1 { get; set; }
        public string Phone2 { get; set; }
    }
}
