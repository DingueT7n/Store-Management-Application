using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;
using Store.Core.Entities.Products;

namespace Store.Infrastructure.Data.Config
{
    public class CategoryConfiguration : IEntityTypeConfiguration<Category>
    {
        public void Configure(EntityTypeBuilder<Category> builder)
        {
            builder.Property(x => x.Id).IsRequired();
            builder.Property(x => x.CategoryName).HasMaxLength(30);
            builder.HasData(
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


}
