using System;
using System.Collections.Generic;
using System.Linq;
using Microsoft.EntityFrameworkCore;

namespace EntetiyFramework
{


    public class Student
    {
        public int Id { get; set; }
        public string? FirstName { get; set; }
        public string? LastName { get; set; }
        public DateTime EnrollmentDate { get; set; }
        public string Fach { get; set; } = null!;

    }

    public class Schoolcontext : DbContext
    {
        public DbSet<Student> Students { get; set; } = null!;
        protected override void OnConfiguring(DbContextOptionsBuilder optionsBuilder)
        {
            optionsBuilder.UseSqlServer(@"Server=TESTVM\SQLEXPRESS;Database=OttoTest;User Id=Helge;Password=13122016;TrustServerCertificate=True;");
        }


    }



    public class Program
    {
        static void Main(string[] args)
        {
            Console.WriteLine("Hello World!");

            using (var context = new Schoolcontext())
            {
                var student = new Student
                {
                    FirstName = "Fritz",
                    LastName = "Doe",
                    EnrollmentDate = DateTime.Now,
                    Fach = "informatik"
                };
                var student2 = new Student
                {
                    FirstName = "Heinze",
                    LastName = "Doe",
                    EnrollmentDate = DateTime.Now,
                    Fach = "mathe"
                };
                context.Students.Add(student);
                context.Students.Add(student2);
                context.SaveChanges();
            }


        }
    }
}