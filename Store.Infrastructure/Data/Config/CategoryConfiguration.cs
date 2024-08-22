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
                new Category { Id = 1, CategoryName = "Category One " },
                new Category { Id = 2, CategoryName = "Category two " },
                new Category { Id = 3, CategoryName = "Category Three " }

                );
        }
    }


}
