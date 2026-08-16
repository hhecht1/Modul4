using System;
using System.Linq;
using Microsoft.EntityFrameworkCore;
using System.Collections.Generic;

namespace Kundenverwaltung
{

    public class Customer
    {
        public int Id { get; set; }
        public string? Name { get; set; } = "";
        public string? Email { get; set; } = "";
        // public int Orders { get; set; }

        public ICollection<Order> Orders { get; set; } = new List<Order>();
    }
    public class Order

    {
        public int Id { get; set; }
        public DateTime OrderDate { get; set; } = DateTime.Now;
        public decimal TotalPrice { get; set; }
        public int CustomerId { get; set; }
        public Customer Customer { get; set; } = null!;
    }

    public class CustomerContext : DbContext
    {
        public DbSet<Customer> Customers { get; set; }
        public DbSet<Order> Orders { get; set; }

        protected override void OnConfiguring(DbContextOptionsBuilder optionsBuilder)
        {
            optionsBuilder.UseSqlServer(@"Server=TESTVM\SWLEXPRESS;Database=TestDB;Trusted_Connection=True");
        }

        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            modelBuilder.Entity<Customer>()
            .HasMany(c => c.Orders)
            .WithOne(o => o.Customer)
            .HasForeignKey(o => o.CustomerId);
        }
    }

    public class Program
    {
        static void Main(string[] args)
        {
            using var context = new CustomerContext();

            // DatenBank wird erzeugt, wenn sie nicht existiert
            context.Database.EnsureCreated();
            // Kunde wird angelegt
            var customer = new Customer
            {
                Name = "Max Mustermann",
                Email = "max@test.at"
            };
            customer.Orders.Add(new Order
            {
                OrderDate = DateTime.Now,
                TotalPrice = 120.50m
            });

            customer.Orders.Add(new Order
            {
                OrderDate = DateTime.Now,
                TotalPrice = 49.90m

            });
            context.Customers.Add(customer);
            context.SaveChanges();


            var customers = context.Customers
            .Include(c => c.Orders)
            .ToList();

            foreach (var c in customers)
            {
                Console.WriteLine(c.Name);
                Console.WriteLine($"Bestellung: {c.Orders.Count}");

                decimal total = c.Orders.Sum(o => o.TotalPrice);
                Console.WriteLine($"Gesamtpreis: {total}");
                Console.WriteLine();

                var expensiveOrders = context.Orders
                .Where(o => o.TotalPrice > 50)
                .OrderByDescending(o => o.TotalPrice)
                .ToList();

                Console.WriteLine("Bestellungen über 50€:");
                foreach (var order in expensiveOrders)
                {
                    Console.WriteLine($"Bestellung: {order.Id}, Preis: {order.TotalPrice}");
                }
            }



        }
    }

}