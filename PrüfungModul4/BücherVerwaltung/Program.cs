using BücherVerwaltung.Data;
using BücherVerwaltung.Models;
using Microsoft.EntityFrameworkCore;

namespace BücherVerwaltung.Data
{
    public class BücherVerwaltungContext : DbContext
    {
        public DbSet<Author> Authors { get; set; }
        public DbSet<Book> Books { get; set; }

        protected override void OnConfiguring(DbContextOptionsBuilder optionsBuilder)
        {
            base.OnConfiguring(optionsBuilder);
            var configuration = new ConfigurationBuilder()
                .SetBasePath(AppContext.BaseDirectory)
                .AddJsonFile("appsettings.json", optional: false, reloadOnChange: true)
                .Build();
            var connectionString = configuration.GetConnectionString("DefaultConnection");
            optionsBuilder.UseSqlServer(connectionString);
        }
    }
}

namespace BücherVerwaltung
{
    class Program
    {
        static void Main(string[] args)
        {
            using var context = new BücherVerwaltungContext();
            context.Database.EnsureCreated();
            var author = new Author
            {
                Name = "Stephen King",
                Books = new List<Book>
               {
                   new Book { Title = "The Shining", Price = 19.99m, PublishedYear = 1977 },
                   new Book { Title = "It", Price = 14.99m, PublishedYear = 1986 }
               }
            };
            context.Authors.Add(author);
            context.SaveChanges();


            Console.WriteLine($"++++++ Autoren mit Büchern +++++++");


            var authors = context.Authors
            .Include(a => a.Books)
             .ToList();

            foreach (var a in authors)
            {
                Console.WriteLine($"Autor: {a.Name}");

                foreach (var b in a.Books ?? Enumerable.Empty<Book>())
                {
                    Console.WriteLine($"  Buch: {b.Title}, Preis: {b.Price}, Erscheinungsjahr: {b.PublishedYear}");
                }
            }


            Console.WriteLine();
            Console.WriteLine($"*** Bücher über 15 Euro ***");

            var expensiveBooks = context.Books
            .AsNoTracking()
            .Where(b => b.Price > 15)
            .OrderByDescending(b => b.Price)
            .ToList();

            foreach (var b in expensiveBooks)
            {
                Console.WriteLine($"Buch: {b.Title}, Preis: {b.Price}, Erscheinungsjahr: {b.PublishedYear}");
            }
        }


    }
}

