using Lagerverwaltung.Data;
using Lagerverwaltung.Models;
using Microsoft.EntityFrameworkCore;


namespace Lagerverwaltung;

public class Program
{

    static void Main(string[] args)
    {
        using var context = new LagerverwaltungContext();
        context.Database.EnsureCreated();

        var supplier = new Supplier
        {
            Name = "Tech Supplies Inc.",
            Email = "office@techsupplies.com",
            Products = new List<Product>
            {
                new Product
                {
                    Name = "Laptop",
                    Price = 999.99m,
                    Stock = 10
                },
                new Product
                {
                    Name = "Smartphone",
                    Price = 499.99m,
                    Stock = 20
                },
                new Product
                {
                    Name = "Tablet",
                    Price = 299.99m,
                    Stock = 15
                }
            }

        };
        context.Suppliers.Add(supplier);
        context.SaveChanges();

        var suplliers = context.Suppliers
        .Include(s => s.Products)
        .ToList();

        foreach (var s in suplliers)
        {

            decimal totalValue = s.Products.Sum(p => p.Price * p.Stock);
            Console.WriteLine($"Lieferant: {s.Name}, Email: {s.Email}, Gesamtwert: {totalValue}");

            foreach (var p in s.Products ?? Enumerable.Empty<Product>())
            {
                Console.WriteLine($"  Produkt: {p.Name}, Preis: {p.Price}, Lagerbestand: {p.Stock}");
            }
        }

        var products = context.Products
        .AsNoTracking()
        .Where(p => p.Price > 50 && p.Stock > 0)
        .OrderByDescending(p => p.Price)
        .ToList();
        foreach (var p in products)
        {
            Console.WriteLine($"Produkt: {p.Name}, Preis: {p.Price}");
        }

        var smarphone = context.Products
        .FirstOrDefault(p => p.Name == "Smartphone");
        if (smarphone != null)
        {
            smarphone.Stock = 18;
            context.SaveChanges();
            Console.WriteLine($"Der Lagerbestand des Smartphones wurde auf 18 gesetzt. Neuer Lagerbestand: {smarphone.Stock}");
        }

        var tablet = context.Products
        .FirstOrDefault(p => p.Name == "Tablet");
        if (tablet != null)
        {
            context.Products.Remove(tablet);
            context.SaveChanges();
            Console.WriteLine($"Das Tablet wurde aus dem Lagerbestand entfernt.");
        }


    }
}