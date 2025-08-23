using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace Store.Core.Entities.Products
{
    public class Product : BaseEntity<int>
    {

        public string CodeBar { get; set; }
        public string ProductName { get; set; }

        [Range(0, double.MaxValue, ErrorMessage = "الكمية يجب أن تكون قيمة موجبة.")]

        public decimal Quentity { get; set; }

        [Range(0, double.MaxValue, ErrorMessage = "سعر الشراء يجب أن يكون قيمة موجبة.")]
        [Column(TypeName = "decimal(18,2)")]
        public decimal BuyPrice { get; set; } = 0;
        public decimal SalePrice { get; set; } = 0;
        public decimal SalePriceSeconde { get; set; } = 0;
        public decimal WholesalePrice { get; set; } = 0;
        public decimal TaxValue { get; set; } = 0;
        public decimal SalePriceTax { get; set; } = 0;
        public bool IsTaxed { get; set; }
        public DateTime DateExperation { get; set; }
        public decimal MinQty { get; set; } = 0;
        public decimal MaxDiscount { get; set; } = 0;
        public decimal NbrProductInColis { get; set; } = 0;
        public string ColisageBareCode { get; set; } = "";

        public byte[] ProductImage { get; set; }


        // Navigation Properties
        public int CategoryId { get; set; } // Group
        public virtual Category Category { get; set; }
        public virtual ICollection<ProductFamily> ProductFamilies { get; set; } = new HashSet<ProductFamily>();
        [Column(TypeName = "decimal(18,3)")]
        public decimal Weight { get; set; } = 0;
        public override string ToString()
        {
            return ProductName;
        }

    }
    public class ProductDTO
    {

        public string CodeBar { get; set; }
        public string ProductName { get; set; }
        public decimal Quentity { get; set; }
        public decimal BuyPrice { get; set; } = 0;
        public decimal SalePrice { get; set; } = 0;
        public decimal SalePriceSeconde { get; set; } = 0;
        public decimal WholesalePrice { get; set; } = 0;
        public decimal MinQty { get; set; } = 0;
        public virtual Category Category { get; set; }
        public int Id { get; set; }


    }


    public class ProductFamily : BaseEntity<int>
    {
        public string CodeBar { get; set; }
        public int Pro_Id { get; set; }
        public virtual Product Product { get; set; }
    }


    public class ProductMinQty
    {
        public string CodeBar { get; set; }
        public string ProductName { get; set; }
        public decimal Quentity { get; set; }
        public DateTime DateExperation { get; set; }
        public string CategoryName { get; set; }

    }
    public class ProductOutdated
    {
        public string CodeBar { get; set; }
        public string ProductName { get; set; }
        public string StoreName { get; set; }
        public decimal Quentity { get; set; }
        public DateTime DateExperation { get; set; }

    }
    public class PaginatedResult<T>
    {
        public List<T> Items { get; set; }
        public int TotalCount { get; set; }
    }

    //Table BadProduct

}
