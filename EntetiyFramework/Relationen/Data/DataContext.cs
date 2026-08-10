using System;
using System.Collections.Generic;
using System.Text;
using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.Configuration.Json;
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
            // optionsBuilder.UseSqlServer("Server=TESTVM\\SQLEXPRESS;Database=Relationen;User Id=sa;Password=Passw0rd!;");

            var configuration = new ConfigurationBuilder()
                .SetBasePath(@"C:\Users\helge12\Desktop\c#\Modul4\EntetiyFramework\Relationen")
                .AddJsonFile("appsettings.json")
                .Build();

            var connectionString = configuration.GetConnectionString("DefaultConnection");
            optionsBuilder.UseSqlServer(connectionString);
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