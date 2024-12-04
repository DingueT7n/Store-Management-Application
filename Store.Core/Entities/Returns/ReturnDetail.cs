using Store.Core.Entities.Products;

namespace Store.Core.Entities.Returns
{
    public class ReturnDetail : BaseEntity<int>
    {
        public int Order_ID { get; set; }
        public int Pro_ID { get; set; }
        public string Sup_Name { get; set; }
        public string Cust_Name { get; set; }
        public string Date { get; set; }
        public decimal Qty { get; set; }
        public decimal Price { get; set; }
        public decimal Total { get; set; }
        public decimal TaxValue { get; set; }
        public decimal PriceWithTax { get; set; }
        public virtual Return Returns { get; set; }
        public virtual Product Product { get; set; }
    }

    public class ReturnDetailDto
    {
        public int Order_ID { get; set; }
        public DateTime DateFacture { get; set; }
        public string CustomerName { get; set; }
        public string SupplierName { get; set; }
        public DateTime DateRefund { get; set; }
        public string Time { get; set; }
        public string User_Name { get; set; }
        public string ProductName { get; set; }
        public decimal Quantity { get; set; }
        public decimal Price { get; set; }
        public decimal TotalPrice { get; set; }
        public decimal TaxValue { get; set; }
        public decimal PriceWithTax { get; set; }
        public decimal TotalFacture { get; set; }
        public decimal PaidUp { get; set; }
        public decimal Remain { get; set; }
    }

    public class ResultReturnDetailDto
    {
        public List<ReturnDetailDto> result;
        public int count;
    }
}