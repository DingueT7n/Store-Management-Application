using System.ComponentModel.DataAnnotations.Schema;
using Store.Core.Entities.Suppliers;

namespace Store.Core.Entities.Buys
{
    public class Buy : BaseEntity<int>
    {
        public DateTime Date { get; set; }
        public string Time { get; set; }
        public string User_Name { get; set; }
        public decimal Total { get; set; }
        public decimal PaidUP { get; set; }
        public decimal Remain { get; set; }
        public int SupplierId { get; set; }
        public Supplier Supplier { get; set; }
        [NotMapped]
        public ICollection<BuyDetail> BuyDetails { get; set; }
    }
}
