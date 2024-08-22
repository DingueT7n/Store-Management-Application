namespace Store.Core.Entities.Products
{
    public class Product : BaseEntity<int>
    {
        public string CodeBar { get; set; }
        public string ProductName { get; set; }
        public float Quentity { get; set; }
        public float BuyPrice { get; set; }
        public float SalePrice { get; set; }
        public float WholesalePrice { get; set; }
        public float TaxValue { get; set; }
        public float SalePriceTax { get; set; }
        public bool IsTaxed { get; set; }
        public DateTime DateExperation { get; set; }
        public float? MinQty { get; set; }
        public float? MaxDiscount { get; set; }


        // Navigation Properties
        public int CategoryId { get; set; } // Group
        public virtual Category Category { get; set; }

        public virtual IEnumerable<ProductOutStore> ProductOutStore { get; set; } = new HashSet<ProductOutStore>();
        public virtual IEnumerable<ProductsQuantitie> ProductsQuantitie { get; set; } = new HashSet<ProductsQuantitie>();
        public virtual IEnumerable<ProductTransfer> ProductTransfer { get; set; } = new HashSet<ProductTransfer>();


        //public virtual ICollection<BuyDetail> BuyDetails { get; set; } // to navigate the buys
        //public virtual ICollection<SaleDetail> SellDetails { get; set; } // to navigate the sales
        //public virtual ICollection<ReturnDetail> ReturnsDetails { get; set; } // to navigate the returned items

    }


}
