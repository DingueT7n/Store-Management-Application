using Microsoft.EntityFrameworkCore;
using Store.Core.Entities.Caisses;
using Store.Core.Entities.Products;

namespace Store.Infrastructure.Data.Config.Seeders
{
    public class CategorySeed
    {
        public static void Seed(ModelBuilder modelBuilder)
        {
            modelBuilder.Entity<Category>().HasData(
                new Category { Id = 1, CategoryName = "اغذية عادية" },
                new Category { Id = 2, CategoryName = "اغذية الاطفال" },
                new Category { Id = 3, CategoryName = "محفظات اطفال" },
                new Category { Id = 4, CategoryName = "اغذية الاطفال" },
                new Category { Id = 5, CategoryName = "مشروبات غازية" },
                new Category { Id = 6, CategoryName = "هواتف رادمي" },
                new Category { Id = 7, CategoryName = "هاتف سامسونغ" },
                new Category { Id = 8, CategoryName = "فرماج" }

                );
        }
    }

    public class CaisseSeed
    {
        public static void Seed(ModelBuilder modelBuilder)
        {
            modelBuilder.Entity<Caisse>().HasData(
                new Caisse { Id = 1, CaisseName = "الصندوق الأول", MoneyinCaisse = 0 },
                     new Caisse { Id = 2, CaisseName = "الصندوق الثاني", MoneyinCaisse = 0 },
                     new Caisse { Id = 3, CaisseName = "الصندوق الثالث", MoneyinCaisse = 0 }
                );
        }
    }
}
