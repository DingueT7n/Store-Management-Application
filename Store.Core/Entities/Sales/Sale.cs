using Store.Core.Entities.Customers;
namespace Store.Core.Entities.Sales
{
    public class Sale : BaseEntity<int>
    {

        public DateTime Date { get; set; }
        public string Time { get; set; }
        public string User_Name { get; set; }
        public float TotalOrder { get; set; }
        public float PaidUP { get; set; }
        public float Remain { get; set; }
        public int CustomerId { get; set; }
        public Customer Customer { get; set; }




    }



}
