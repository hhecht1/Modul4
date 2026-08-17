using System;
using System.Collections.Generic;
using System.Linq;
using Microsoft.EntityFrameworkCore;

namespace Produktverwaltung
{
    public class Category
    {
        public int Id { get; set; }
        public string? Name { get; set; } = "";
        public ICollection<Product> Products { get; set; } = new List<Product>();
    }

    public class Product
    {
        public int Id { get; set; }
        public string? Name { get; set; } = "";
        public decimal Price { get; set; }
        public int Stock { get; set; }
        public int CategoryId { get; set; }
        public Category Category { get; set; } = null!;
    }

    public class ShopContext : DbContext
    {
        public DbSet<Category> Categories { get; set; }
        public DbSet<Product> Products { get; set; }

        protected override void OnConfiguring(DbContextOptionsBuilder optionsBuilder)
        {
            optionsBuilder.UseSqlServer(@"
            Server=TESTVM\SWLEXPRESS;
            Database=TestDB;
            Trusted_Connection=True;
                            ");
        }

        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            modelBuilder.Entity<Product>()
            .HasOne(p => p.Category)
            .WithMany(c => c.Products)
            .HasForeignKey(p => p.CategoryId);

            modelBuilder.Entity<Category>()
            .Property(p => p.Name)
            .IsRequired()
            .HasMaxLength(100);
        }

    }

    public class Program
    {
        static void Main(string[] args)
        {
            using var context = new ShopContext();

            context.Database.EnsureCreated();

            var hardware = new Category
            {
                Name = "Hardware"
            };
            hardware.Products.Add(new Product
            {
                Name = "Tastatur",
                Price = 79.90m,
                Stock = 10
            });
            hardware.Products.Add(new Product
            {
                Name = "Maus",
                Price = 39.90m,
                Stock = 20
            });
            hardware.Products.Add(new Product
            {
                Name = "Monitor",
                Price = 249.99m,
                Stock = 5
            });
            context.Categories.Add(hardware);
            context.SaveChanges();

            var products = context.Products
                .AsNoTracking()
                .Include(p => p.Category)
                .Where(p => p.Price > 50)
                .OrderByDescending(p => p.Price)
                .ToList();

            foreach (var product in products)
            {
                Console.WriteLine($"Produkt: {product.Name}, Preis: {product.Price}, Kategorie: {product.Category.Name}");
            }

            var keyboard = context.Products
            .FirstOrDefault(p => p.Name == "Tastatur");

            if (keyboard != null)
            {
                keyboard.Stock = 9;
                context.SaveChanges();
            }


        }
    }
}