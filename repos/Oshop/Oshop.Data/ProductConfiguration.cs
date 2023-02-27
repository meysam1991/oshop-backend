using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;
using Oshop.Entities;

namespace Oshop.Data
{
    public class ProductConfiguration : IEntityTypeConfiguration<Product>
    {
        public void Configure(EntityTypeBuilder<Product> builder)
        {
            builder.HasOne(a => a.Categories)
       .WithMany(b => b.Products)
       .HasForeignKey(x => x.CategoriesId)
       .OnDelete(DeleteBehavior.Cascade);


        }
    }
}
