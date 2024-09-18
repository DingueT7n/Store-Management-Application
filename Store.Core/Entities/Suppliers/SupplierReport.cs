using Store.Core.Entities.Buys;

namespace Store.Core.Entities.Suppliers
{
    public class SupplierReport : BaseEntity<int>
    {

        public int Sup_ID { get; set; }
        public int Order_ID { get; set; }
        public string SupplierName { get; set; }
        public decimal Price { get; set; }
        public DateTime Date { get; set; }
        public string Time { get; set; }


        public virtual Buy Buy { get; set; }

        public virtual Supplier Supplier { get; set; }
    }
    public class SupplierReportDto
    {

        public List<SupplierReport> Result { get; set; }
        public int count { get; set; }
    }

}
