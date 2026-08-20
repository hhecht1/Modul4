using System;
using Microsoft.EntityFrameworkCore;
using Fahrzeugverwaltung.Models;
using Microsoft.Extensions.Configuration;

namespace Fahrzeugverwaltung.Data;

public class FahrzeugverwaltungContext : DbContext
{
    public DbSet<Manufacturer> Manufacturers { get; set; } = null!;
    public DbSet<Car> Cars { get; set; } = null!;

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
        modelBuilder.Entity<Manufacturer>()
        .HasKey(m => m.Id);
        modelBuilder.Entity<Manufacturer>()
        .Property(m => m.Name)
        .IsRequired()
        .HasMaxLength(100);
        modelBuilder.Entity<Manufacturer>()
        .Property(m => m.Country)
        .HasMaxLength(80);

        modelBuilder.Entity<Car>()
        .HasKey(c => c.Id);
        modelBuilder.Entity<Car>()
        .Property(c => c.Model)
        .IsRequired()
        .HasMaxLength(120);
        modelBuilder.Entity<Car>()
        .Property(c => c.Price)
        .HasPrecision(10, 2);
        modelBuilder.Entity<Car>()
        .HasOne(c => c.Manufacturer)
        .WithMany(m => m.Cars)
        .HasForeignKey(c => c.ManufacturerId);


    }
}