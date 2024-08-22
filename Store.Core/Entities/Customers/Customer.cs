namespace Store.Core.Entities.Customers
{
    public class Customer : BaseEntity<int>
    {

        public string CustomerName { get; set; }
        public string Address { get; set; }
        public string PhoneNumber { get; set; }
        public string Notes { get; set; }

        ICollection<CustomerMoney> DebtMoney { get; set; } = new List<CustomerMoney>();
        ICollection<CustomerReport> Reports { get; set; } = new List<CustomerReport>();

    }
}