using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.Configuration;
using PizzaService.Models;
using System.IO;
using System;

// Getting Started with Entity Framework Core [1 of 5] | Entity Framework Core for Beginners. dotnet 2022
// https://youtu.be/SryQxUeChMc?si=Mcv47j46lImkUkNi

namespace PizzaService.Data
{
    public class MiloPizzaContext : DbContext
    {
        // each DbSet maps to a table that will be created in the db
        public DbSet<Customer> Customer { get; set; } = null!;
        public DbSet<Order> Orders { get; set; } = null!;
        public DbSet<Product> Products { get; set; } = null!;
        public DbSet<OrderDetail> OrderDetails { get; set; } = null!;


        protected override void OnConfiguring(DbContextOptionsBuilder optionsBuilder)
        {
            //base.OnConfiguring(optionsBuilder);
            //optionsBuilder.UseSqlServer(@"Connection String here");

            // 1. Pfad zur appsettings.json definieren
            var configuration = new ConfigurationBuilder()
                .SetBasePath(Directory.GetCurrentDirectory())
                .AddJsonFile("appsettings.json")
                .Build();

            // 2. Connection String auslesen
            var connectionString = configuration.GetConnectionString("MiloDatabase");

            // 3. An EF Core übergeben
            optionsBuilder.UseSqlServer(connectionString);


            //    // Connection String für SQL Server SQL-Authentifizierung
            //    public SchoolContext() : base(@"Server=LAPTOP-VVRAIUTC;Database=MiloTest;User Id=millo;Password=sql2026;")
            //    {
            //    }

            //    // Diese Eigenschaft wird als Tabelle "Students" in SQL Server angelegt
            //    public DbSet<Student> Students { get; set; }
            //}

            // 2. Der angepasste DbContext für EF Core

            //protected override void OnConfiguring(DbContextOptionsBuilder optionsBuilder)
            //{
            //    // Verbindung zum SQL-Server mit SQL-Authentifizierung konfigurieren
            //    // TrustServerCertificate=True ist bei neueren SQL-Server-Verbindungen oft zwingend erforderlich
            //    optionsBuilder.UseSqlServer(@"Server=LAPTOP-VVRAIUTC;Database=MiloTest;User Id=milo;Password=sql2026;TrustServerCertificate=True;");


            //    // Trusted_Connection=True sagt EF Core, dass es Ihren Windows-User nutzen soll.
            //    // User Id und Password fallen hier komplett weg.
            //    //optionsBuilder.UseSqlServer(@"Server=LAPTOP-VVRAIUTC;Database=MiloTest;Trusted_Connection=True;TrustServerCertificate=True;");
            //}

            //protected override void OnConfiguring(DbContextOptionsBuilder optionsBuilder)
            //{
            //    // 1. Pfad zur appsettings.json definieren
            //    var configuration = new ConfigurationBuilder()
            //        .SetBasePath(Directory.GetCurrentDirectory())
            //        .AddJsonFile("appsettings.json")
            //        .Build();

            //    // 2. Connection String auslesen
            //    var connectionString = configuration.GetConnectionString("MiloDatabase");

            //    // 3. An EF Core übergeben
            //    optionsBuilder.UseSqlServer(connectionString);

            //}

        }
    }
}