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





    }
}