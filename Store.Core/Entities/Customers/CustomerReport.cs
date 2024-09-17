using Store.Core.Entities.Sales;

namespace Store.Core.Entities.Customers
{
    public class CustomerReport : BaseEntity<int>
    {
        public int Cust_ID { get; set; }
        public int Order_ID { get; set; }
        public string Cust_Name { get; set; }
        public decimal Price { get; set; }
        public DateTime Date { get; set; }
        public string Time { get; set; }
        public virtual Sale Sale { get; set; }
        public virtual Customer Customer { get; set; }
    }
    public class CustomerReportDto
    {
        public List<CustomerReport> Result { get; set; } = new List<CustomerReport>();
        public int count { get; set; }
    }
}