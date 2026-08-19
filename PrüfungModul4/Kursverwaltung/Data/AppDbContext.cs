using Kursverwaltung.Models;
using Microsoft.EntityFrameworkCore;

namespace Kursverwaltung.Data
{
    public class AppDbContext : DbContext
    {
        public AppDbContext(DbContextOptions<AppDbContext> options)
            : base(options)
        {
        }

        public DbSet<Trainer> Trainers { get; set; }

        public DbSet<Course> Courses { get; set; }
    }
}