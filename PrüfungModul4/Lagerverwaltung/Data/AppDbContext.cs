using System;
using Microsoft.EntityFrameworkCore;
using Lagerverwaltung.Models;
using Microsoft.Extensions.Configuration;

namespace Lagerverwaltung.Data;

public class LagerverwaltungContext : DbContext
{
    public DbSet<Product> Products { get; set; } = null!;
    public DbSet<Supplier> Suppliers { get; set; } = null!;




    protected override void OnConfiguring(DbContextOptionsBuilder optionsBuilder)
    {
        var configuration = new ConfigurationBuilder()
            .SetBasePath(AppContext.BaseDirectory)
            .AddJsonFile("appsettings.json", optional: false, reloadOnChange: true)
            .Build();

        var connectionString = configuration.GetConnectionString("DefaultConnection");
        optionsBuilder.UseSqlServer(connectionString);
    }


    protected override void OnModelCreating(ModelBuilder modelBuilder)
    {
        modelBuilder.Entity<Supplier>()
        .HasKey(s => s.Id);

        modelBuilder.Entity<Supplier>()
        .Property(s => s.Name)
        .IsRequired()
        .HasMaxLength(100);

        modelBuilder.Entity<Supplier>()
        .Property(s => s.Email)
        .IsRequired()
        .HasMaxLength(100);

        modelBuilder.Entity<Product>()
        .HasKey(p => p.Id);

        modelBuilder.Entity<Product>()
        .Property(p => p.Name)
        .IsRequired()
        .HasMaxLength(120);

        modelBuilder.Entity<Product>()
        .Property(p => p.Price)
        .HasPrecision(10, 2);

        modelBuilder.Entity<Supplier>()
        .HasMany(s => s.Products)
        .WithOne(p => p.Supplier)
        .HasForeignKey(p => p.SupplierId);


    }



}