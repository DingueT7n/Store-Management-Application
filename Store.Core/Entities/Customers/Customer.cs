namespace Store.Core.Entities.Customers
{
    public class Customer : BaseEntity<int>
    {

        public string CustomerName { get; set; }
        public string Address { get; set; }
        public string PhoneNumber { get; set; }
        public string Notes { get; set; }
        public decimal MaxDebtAllowed { get; set; }
        public decimal TotalDebts { get; set; }
    }
}