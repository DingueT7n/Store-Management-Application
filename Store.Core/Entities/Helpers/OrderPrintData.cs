namespace Store.Core.Entities.Helpers
{
    public class OrderPrintData : BaseEntity<int>
    {
        public string Logo { get; set; }
        public string Name { get; set; }
        public string Address { get; set; }
        public string Description { get; set; }
        public string Phone1 { get; set; }
        public string Fax { get; set; }
        public string CompteRib { get; set; }
        public string RC { get; set; }
        public string AI { get; set; }
        public string IDFiscal { get; set; }
        public string NIS { get; set; }
    }
}
