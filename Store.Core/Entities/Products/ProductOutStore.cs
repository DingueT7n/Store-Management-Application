using System.ComponentModel.DataAnnotations.Schema;

namespace Store.Core.Entities.Products
{
    public class ProductOutStore : BaseEntity<int>
    {

        public int Pro_ID { get; set; }
        public string ProductName { get; set; }
        public string StoreName { get; set; } // المخزن
        public float Quentity { get; set; }

        public DateTime Date { get; set; }
        public string Time { get; set; }
        public string Name { get; set; }
        public string Reason { get; set; }
        [ForeignKey("Pro_ID")]
        public virtual Product Product { get; set; }
    }


}
