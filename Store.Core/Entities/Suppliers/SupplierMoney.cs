using System.ComponentModel.DataAnnotations.Schema;
using Store.Core.Entities.Buys;

namespace Store.Core.Entities.Suppliers
{
    public class SupplierMoney : BaseEntity<int>
    {

        public int Sup_ID { get; set; }
        public int Order_ID { get; set; }
        public string SupplierName { get; set; }
        public float? Price { get; set; }
        public DateTime Order_Date { get; set; }
        public string Time { get; set; }
        public DateTime Reminder_Date { get; set; }


        [ForeignKey("Order_ID")]
        public virtual Buy Buy { get; set; }
        [ForeignKey("Sup_ID")]
        public virtual Supplier Supplier { get; set; }
    }

}
