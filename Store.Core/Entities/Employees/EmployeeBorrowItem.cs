using System.ComponentModel.DataAnnotations.Schema;
using Store.Core.Entities.Products;

namespace Store.Core.Entities.Employees
{
    public class EmployeeBorrowItem : BaseEntity<int>
    {

        public int? Item_ID { get; set; }
        public int? Emp_ID { get; set; }
        public DateTime Date { get; set; }
        public string Time { get; set; }
        public float Quentity { get; set; }

        [ForeignKey("Emp_ID")]
        public virtual Employee Employee { get; set; }

        [ForeignKey("Item_ID")]
        public virtual Product Product { get; set; }
    }

}
