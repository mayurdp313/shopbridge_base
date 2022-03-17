using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.EntityFrameworkCore;
using Shopbridge_base.Domain.Models;

namespace Shopbridge_base.Data
{
    public class Shopbridge_Context : DbContext
    {
        public Shopbridge_Context()
        {
        }
        public Shopbridge_Context(DbContextOptions<Shopbridge_Context> options)
            : base(options)
        {
            Database.Migrate();
        }

        public DbSet<Product> Products { get; set; }
        public DbSet<Category> Categories { get; set; }

        protected override void OnModelCreating(ModelBuilder builder)
        {
            base.OnModelCreating(builder);
            seedCategory(builder);
            seedProduct(builder);
        }

        void seedCategory(ModelBuilder builder)
        {
            builder.Entity<Category>().HasData(
        new Category { CategoryId = 1, CategoryName = "Electronics", CategoryDescription = "Electronics" },
        new Category { CategoryId = 2, CategoryName = "Mobile", CategoryDescription = "Mobile" },
        new Category { CategoryId = 3, CategoryName = "Furniture", CategoryDescription = "Furniture" }
    );
        }
        void seedProduct(ModelBuilder builder)
        {
            builder.Entity<Product>().HasData(
        new Product { Product_Id = 1, ProductName = "LG 21 LED", ProductDescription = "TV", CategoryId = 1, Price = 12, Quantity = 2 },
         new Product { Product_Id = 8, ProductName = "Samsun 55 LED", ProductDescription = "TV", CategoryId = 1, Price = 12, Quantity = 2 },

         new Product { Product_Id = 9, ProductName = "samsung 81 LED", ProductDescription = "TV", CategoryId = 1, Price = 12, Quantity = 2 },

        new Product { Product_Id = 2, ProductName = "Samsung s21", ProductDescription = "Mobile", CategoryId = 2, Price = 12, Quantity = 2 },
         new Product { Product_Id = 4, ProductName = "Samsung A50", ProductDescription = "Mobile", CategoryId = 2, Price = 12, Quantity = 2 },
          new Product { Product_Id = 5, ProductName = "Nokia n80", ProductDescription = "Mobile", CategoryId = 2, Price = 12, Quantity = 2 },
           new Product { Product_Id = 6, ProductName = "Nokia s02", ProductDescription = "Mobile", CategoryId = 2, Price = 12, Quantity = 2 },
           new Product { Product_Id = 7, ProductName = "oppo s21", ProductDescription = "Mobile", CategoryId = 2, Price = 12, Quantity = 2 },
        new Product { Product_Id = 3, ProductName = "Table 4x8", ProductDescription = "Table", CategoryId = 3, Price = 12, Quantity = 2 }
    );
        }
    }
}
