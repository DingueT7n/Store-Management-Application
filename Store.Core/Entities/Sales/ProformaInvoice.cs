using Store.Core.Entities.Customers;
using Store.Core.Entities.Products;

namespace Store.Core.Entities.Sales
{
    public class ProformaInvoice : BaseEntity<int>
    {
        public string InvoiceNumber { get; set; }
        public string UserName { get; set; }
        public string CustomerName { get; set; }
        public decimal TotalFaacture { get; set; }
        public DateTime Date { get; set; }
        public int CustomerId { get; set; }
        public Customer Customer { get; set; }
        public List<ProformaInvoiceDetails> Details { get; set; }
    }
    public class ProformaInvoiceDetails : BaseEntity<int>
    {
        public int ProformaId { get; set; }
        public int ProductId { get; set; }
        public string ProductName { get; set; }
        public decimal Quentity { get; set; }
        public decimal UnitPrice { get; set; }
        public decimal Discount { get; set; }
        public decimal Total { get; set; }
        public virtual ProformaInvoice ProformaInvoice { get; set; }
        public Product Product { get; set; }

    }
    public class ProformaInvoiceDTO
    {
        public int ProformaId { get; set; }
        public string UserName { get; set; }
        public string CustomerName { get; set; }
        public DateTime Date { get; set; }
        public decimal TotalFaacture { get; set; }
        public int NbrProducts { get; set; }

    }
    public class ListProformaInvoice
    {
        public List<ProformaInvoiceDTO> Data { get; set; }
        public int Count { get; set; }

    }



}
