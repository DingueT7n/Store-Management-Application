using Store.Core.Entities.Sales;

namespace Store.Core.Entities.Customers
{
    public class CustomerMoney : BaseEntity<int>
    {

        public int Cust_ID { get; set; }
        public int Order_ID { get; set; }
        public string Cust_Name { get; set; }
        public float Price { get; set; }
        public DateTime Order_Date { get; set; }
        public DateTime Reminder_Date { get; set; }
        public string Time { get; set; }

        public virtual Sale Sale { get; set; }


        public virtual Customer Customer { get; set; }
    }
    public class CustomerDto
    {

        public int Cust_ID { get; set; }
        public int Order_ID { get; set; }
        public string Cust_Name { get; set; }
        public float Price { get; set; }
        public DateTime Order_Date { get; set; }
        public DateTime Reminder_Date { get; set; }
        public string Time { get; set; }

        public int Id { get; set; }
    }
}