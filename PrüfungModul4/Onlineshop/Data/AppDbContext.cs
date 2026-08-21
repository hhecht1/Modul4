using Microsoft.EntityFrameworkCore;
using Onlineshop.Models;
using Microsoft.Extensions.Configuration;
using Microsoft.EntityFrameworkCore.Metadata.Builders;

namespace Onlineshop.Data;

public class OnlineShopDbContext : DbContext
{
    public DbSet<Customer> Customers { get; set; } = null!;
    public DbSet<Order> Orders { get; set; } = null!;
    public DbSet<OrderItem> OrderItems { get; set; } = null!;
    public DbSet<Product> Products { get; set; } = null!;

    protected override void OnConfiguring(DbContextOptionsBuilder optionsBuilder)
    {
        var configuration = new ConfigurationBuilder()
            .SetBasePath(AppContext.BaseDirectory)
            .AddJsonFile("appsettings.json")
            .Build();
        var connectionString = configuration.GetConnectionString("DefaultConnection");
        optionsBuilder.UseSqlServer(connectionString);
    }

    protected override void OnModelCreating(ModelBuilder modelBuilder)
    {


        // Relationships
        modelBuilder.Entity<Customer>()
        .HasMany(c => c.Orders)
        .WithOne(o => o.Customer)
        .HasForeignKey(o => o.CustomerId);

        modelBuilder.Entity<Order>()
        .HasMany(o => o.OrderItems)
        .WithOne(oi => oi.Order)
        .HasForeignKey(oi => oi.OrderId);

        modelBuilder.Entity<Product>()
        .HasMany(p => p.OrderItems)
        .WithOne(oi => oi.Product)
        .HasForeignKey(oi => oi.ProductId);

        //Customer configuration
        modelBuilder.Entity<Customer>()
        .HasKey(c => c.Id);
        modelBuilder.Entity<Customer>()
        .Property(c => c.FirstName)
        .IsRequired()
        .HasMaxLength(80);
        modelBuilder.Entity<Customer>()
        .Property(c => c.LastName)
        .IsRequired()
        .HasMaxLength(80);
        modelBuilder.Entity<Customer>()
        .Property(c => c.Email)
        .IsRequired()
        .HasMaxLength(120);
        modelBuilder.Entity<Customer>()
        .HasIndex(c => c.Email)
        .IsUnique();

        //Order configuration
        modelBuilder.Entity<Order>()
        .HasKey(o => o.Id);
        modelBuilder.Entity<Order>()
        .Property(o => o.OrderDate)
        .IsRequired();

        //Product configuration
        modelBuilder.Entity<Product>()
        .HasKey(p => p.Id);
        modelBuilder.Entity<Product>()
        .Property(p => p.Name)
        .IsRequired()
        .HasMaxLength(120);
        modelBuilder.Entity<Product>()
        .Property(p => p.Price)
        .IsRequired()
        .HasPrecision(10, 2);
        modelBuilder.Entity<Product>()
        .Property(p => p.Stock)
        .IsRequired();



        //OrderItem configuration
        modelBuilder.Entity<OrderItem>()
        .HasKey(oi => oi.Id);
        modelBuilder.Entity<OrderItem>()
        .Property(oi => oi.Quantity)
        .IsRequired();
        modelBuilder.Entity<OrderItem>()
        .Property(oi => oi.UnitPrice)
        .IsRequired()
        .HasPrecision(10, 2);








    }
}
