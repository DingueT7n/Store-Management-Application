using Store.Core.Entities.Customers;
namespace Store.Core.Entities.Sales
{
    public class Sale : BaseEntity<int>
    {

        public DateTime Date { get; set; }
        public string Time { get; set; }
        public string User_Name { get; set; }
        public decimal TotalOrder { get; set; }
        public decimal PaidUP { get; set; }
        public decimal Remain { get; set; }
        public int CustomerId { get; set; }
        public Customer Customer { get; set; }

    }
    public class sale8cm
    {
        public int OrderId { get; set; }           // Corresponds to 'رقم الفاتورة'
        public DateTime Date { get; set; }
        public string Time { get; set; }
        public string UserName { get; set; }
        public decimal TotalOrder { get; set; }
        public decimal PaidUP { get; set; }
        public decimal Remain { get; set; }
        public string CustomerName { get; set; }   // 'اسم العميل'
        public string ProductName { get; set; }    // 'اسم المنتج'
        public decimal Quentity { get; set; }          // 'الكمية'
        public decimal Price { get; set; }         // 'الوحدة سعر'
        public decimal Discount { get; set; }      // 'التخفيض'
        public decimal Total { get; set; }         // 'سعر منتج كلي'
    }

}
