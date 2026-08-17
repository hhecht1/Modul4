using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.Options;
// using Microsoft.Extensions.Configuration.Json;
using Relationen.Models;
using System.IO;
namespace Relationen.Data
{
    internal class DataContext : DbContext
    {
        // DB Sets

        public DbSet<Character> Characters { get; set; }
        public DbSet<Backpack> Backpacks { get; set; }

        public DbSet<Weapons> Weapons { get; set; }


        // Connection to DB via OnConfiguring
        protected override void OnConfiguring(DbContextOptionsBuilder optionsBuilder)
        {
            if (!optionsBuilder.IsConfigured)
            {
                var configuration = new ConfigurationBuilder()
                    .SetBasePath(AppContext.BaseDirectory)
                    .AddJsonFile("appsettings.json", optional: false, reloadOnChange: true)
                    .Build();

                var connectionString = configuration.GetConnectionString("DefaultConnection");
                optionsBuilder.UseSqlServer(connectionString);
            }
        }
        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            modelBuilder.Entity<Character>()
                .HasOne(c => c.Backpack)
                .WithOne(b => b.Character)
                .HasForeignKey<Backpack>(b => b.CharacterId);

            modelBuilder.Entity<Character>()
                .HasMany(c => c.Weapons)
                .WithOne(w => w.Character)
                .HasForeignKey(w => w.CharacterId)
                .OnDelete(DeleteBehavior.Cascade); // Löscht Waffen, wenn Charakter gelöscht wird

            modelBuilder.Entity<Character>()
                .HasMany(c => c.Factions)
                .WithMany(f => f.Characters)
                .UsingEntity(j => j.ToTable("Zwischentabelle")); // Optional: Eigener Name für die Join-Tabelle
        }






    }
}