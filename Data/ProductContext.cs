using Microsoft.EntityFrameworkCore;
using System;
using System.Data;
using WebApplication1.Interfaces;

namespace WebApplication1.Data
{
    public class ProductContext:DbContext
    {
        public ProductContext(DbContextOptions<ProductContext> options) : base(options) { }
        public DbSet<Product> Products { get; set; }
        public DbSet<Customer> Customers { get; set; }
        public DbSet<Order> Orders { get; set; }
        protected override void OnConfiguring(DbContextOptionsBuilder optionsBuilder)
        {
            optionsBuilder.UseSqlServer("server=(localdb)\\MSSQLLocalDB;Database=ProductDb;Integrated Security=True");
        }
        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            base.OnModelCreating(modelBuilder);
            modelBuilder.Entity<Product>().HasData(new Product[]
            {
                new(){Id=1,Name="bilgisayar",CreateDate=DateTime.Now.AddDays(-3),Price=2500,Stock=2,ImagePath="test"},
                new(){Id=4,Name="tablet",CreateDate=DateTime.Now.AddDays(-30),Price=1200,Stock=5,ImagePath = "test"},
                new(){Id=2,Name="motorsiklet",CreateDate=DateTime.Now.AddDays(-63),Price=15000,Stock = 2,ImagePath = "test" },
                new(){Id=5,Name="kalem",CreateDate=DateTime.Now.AddDays(-5),Price=963, Stock = 6, ImagePath = "test"}
            }) ;

        }
    }
}
