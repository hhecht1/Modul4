using Kursverwaltung.Data;
using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.Configuration;



var configuration = new ConfigurationBuilder()
    .SetBasePath(Directory.GetCurrentDirectory())
    .AddJsonFile("appsettings.json")
    .Build();

string connectionString =
    configuration.GetConnectionString("DefaultConnection")!;

var options = new DbContextOptionsBuilder<AppDbContext>()
    .UseSqlServer(connectionString)
    .Options;

using var context = new AppDbContext(options);

// Datenbank erstellen
context.Database.EnsureCreated();

Console.WriteLine("Datenbank wurde erstellt.");