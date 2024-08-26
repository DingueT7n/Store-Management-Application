namespace Store.Core.Entities.Suppliers
{
    public class Supplier : BaseEntity<int>
    {

        public string SupplierName { get; set; }
        public string Address { get; set; }
        public string PhoneNumber { get; set; }
        public string Notes { get; set; }
        public float? MaxDebtAllowed { get; set; }
        public float? TotalDebts { get; set; }


    }

}
