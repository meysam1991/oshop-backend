using Microsoft.EntityFrameworkCore;
using Oshop.Entities;

namespace Oshop.Data
{
    public class OshopDbContext:DbContext
    {
        public OshopDbContext(DbContextOptions options)
            : base(options)
        {

        }
        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            //var entitiesAssembly = typeof(IEntity).Assembly;
            ////modelBuilder.RegisterAllEntities<IEntity>(entitiesAssembly);
            //modelBuilder.RegisterEntityTypeConfiguration(entitiesAssembly);
            modelBuilder.ApplyConfiguration(new ProductConfiguration());
        }
        public DbSet<Category> Categories { get; set; }
        public DbSet<Product> Products { get; set; }
    }
}
