namespace Store.Core.Entities.AllDeserved
{
    public class TaxesReport : BaseEntity<int>
    {

        public int Order_Num { get; set; }

        public string Order_Type { get; set; }
        public string TaxType { get; set; }

        public string SupName { get; set; }

        public string CustName { get; set; }

        public decimal TotalOrder { get; set; }

        public decimal TotalTax { get; set; }

        public decimal TotalAfterTax { get; set; }

        public DateTime Date { get; set; }
    }
}
