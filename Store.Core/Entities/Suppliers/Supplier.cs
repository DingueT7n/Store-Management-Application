namespace Store.Core.Entities.Suppliers
{
    public class Supplier : BaseEntity<int>
    {

        public string SupplierName { get; set; }
        public string Address { get; set; }
        public string PhoneNumber { get; set; }
        public string Notes { get; set; }
        public virtual IEnumerable<SupplierMoney> SupplierMoney { get; set; } = new HashSet<SupplierMoney>();


        //public virtual IEnumerable<BuyDetail> BuyDetails { get; set; }
    }

}
