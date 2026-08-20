using Microsoft.EntityFrameworkCore;
using Hotelverwaltung.Models;
using Microsoft.Extensions.Configuration;


namespace Hotelverwaltung.Data;

public class HotelVerwaltungContext : DbContext
{
    public DbSet<Hotel> Hotels { get; set; } = null!;
    public DbSet<Room> Rooms { get; set; } = null!;

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
        modelBuilder.Entity<Hotel>()
        .HasKey(h => h.Id);
        modelBuilder.Entity<Hotel>()
        .Property(h => h.Name)
        .IsRequired()
        .HasMaxLength(120);
        modelBuilder.Entity<Hotel>()
        .Property(h => h.City)
        .IsRequired()
        .HasMaxLength(80);


        modelBuilder.Entity<Room>()
        .HasKey(r => r.Id);
        modelBuilder.Entity<Room>()
        .Property(r => r.RoomNumber)
        .IsRequired()
        .HasMaxLength(10);
        modelBuilder.Entity<Room>()
        .Property(r => r.PricePerNight)
        .HasPrecision(10, 2);

        modelBuilder.Entity<Hotel>()
        .HasMany(h => h.Rooms)
        .WithOne(r => r.Hotel)
        .HasForeignKey(r => r.HotelId);

    }
}