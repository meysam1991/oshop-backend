using Microsoft.AspNetCore.Identity;
using Microsoft.AspNetCore.Identity.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore;
using Oshop.Entities;
using System.Data;
using System;
using System.Security.Claims;

namespace Oshop.Data
{
    public class OshopDbContext:IdentityDbContext<ApplicationUser, Role, int>
    {
        //public OshopDbContext(DbContextOptions options)
        //    : base(options)
        //{

        //}
        public OshopDbContext(DbContextOptions options)
            : base(options)
        {

        }
        //protected override void OnModelCreating(ModelBuilder modelBuilder)
        //{
        //    var entitiesAssembly = typeof(IEntity).Assembly;
        //    //modelBuilder.RegisterAllEntities<IEntity>(entitiesAssembly);
        //    modelBuilder.RegisterEntityTypeConfiguration(entitiesAssembly);
        //    modelBuilder.ApplyConfiguration(new ProductConfiguration());



        //}
        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            modelBuilder.ApplyConfiguration(new ProductConfiguration());
            base.OnModelCreating(modelBuilder);
        }
        public DbSet<Category> Categories { get; set; }
        public DbSet<Product> Products { get; set; }
    }
}
