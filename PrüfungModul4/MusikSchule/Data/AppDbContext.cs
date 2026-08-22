using System;
using MusikSchule.Models;
using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.Configuration;
namespace MusikSchule.Data;


public class MusikSchuleDbContext : DbContext
{
    public DbSet<Student> Students { get; set; }
    public DbSet<Teacher> Teachers { get; set; }
    public DbSet<Course> Courses { get; set; }
    public DbSet<Enrollment> Enrollments { get; set; }


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
        //Beziehungen

        modelBuilder.Entity<Teacher>()
        .HasMany(t => t.Courses)
        .WithOne(c => c.Teacher);

        modelBuilder.Entity<Student>()
        .HasMany(s => s.Enrollments)
        .WithOne(e => e.Student);

        modelBuilder.Entity<Course>()
        .HasMany(c => c.Enrollments)
        .WithOne(e => e.Course);

        modelBuilder.Entity<Enrollment>()
        .HasIndex(e => new { e.StudentId, e.CourseId })
        .IsUnique();




        //Konfigurationen Teacher

        modelBuilder.Entity<Teacher>()
        .HasKey(t => t.Id);
        modelBuilder.Entity<Teacher>()
        .Property(t => t.FirstName)
        .IsRequired()
        .HasMaxLength(80);
        modelBuilder.Entity<Teacher>()
        .Property(t => t.LastName)
        .IsRequired()
        .HasMaxLength(80);
        modelBuilder.Entity<Teacher>()
        .Property(t => t.Email)
        .IsRequired()
        .HasMaxLength(120);
        modelBuilder.Entity<Teacher>()
        .HasIndex(t => t.Email)
        .IsUnique();

        // Konfigurationen Student
        modelBuilder.Entity<Student>()
        .HasKey(s => s.ID);
        modelBuilder.Entity<Student>()
        .Property(s => s.FirstName)
        .IsRequired()
        .HasMaxLength(80);
        modelBuilder.Entity<Student>()
        .Property(s => s.LastName)
        .IsRequired()
        .HasMaxLength(80);
        modelBuilder.Entity<Student>()
        .Property(s => s.Email)
        .IsRequired()
        .HasMaxLength(120);
        modelBuilder.Entity<Student>()
        .HasIndex(s => s.Email)
        .IsUnique();

        // Konfigurationen Course
        modelBuilder.Entity<Course>()
        .HasKey(c => c.Id);
        modelBuilder.Entity<Course>()
        .HasKey(c => c.Id);
        modelBuilder.Entity<Course>()
        .Property(c => c.Name)
        .IsRequired();
        modelBuilder.Entity<Course>()
        .Property(c => c.MonthlyPrice)
        .HasPrecision(10, 2)
        .IsRequired();

        // Konfigurationen Enrollment
        modelBuilder.Entity<Enrollment>()
        .HasKey(e => e.Id);
        modelBuilder.Entity<Enrollment>()
        .Property(e => e.EnrolledAt)
        .IsRequired();





    }
}