using System;
using System.Collections.Generic;
using System.Linq;
using Microsoft.EntityFrameworkCore;

namespace PrüfungModul4.Studiumverwaltung
{
    public class Student
    {
        public int Id { get; set; }
        public string? FirstName { get; set; } = "";
        public string? LastName { get; set; } = "";
        public int Age { get; set; }
    }

    public class SchoolContext : DbContext
    {
        public DbSet<Student> Students { get; set; }

        protected override void OnConfiguring(DbContextOptionsBuilder options)
        {
            options.UseSqlServer(@"Server=TESTVM\SWLEXPRESS;Database=TestDB;Trusted_Connection=True");
        }
    }

    public class Program
    {
        static void Main(string[] args)
        {
            using var context = new SchoolContext();

            //Create new Student
            if (!context.Students.Any())
            {
                context.Students.Add(new Student
                {
                    FirstName = "Max",
                    LastName = "Mustermann",
                    Age = 20
                }
                );
                context.Students.Add(new Student
                {
                    FirstName = "Anna",
                    LastName = "Müller",
                    Age = 22

                });
                context.SaveChanges();
            }

            // Filtern von Studenten 
            var students = context.Students
                .Where(s => s.Age > 20)
                .OrderBy(s => s.LastName)
                .ToList();
            Console.WriteLine("Students older than 20:");

            foreach (var student in students)
            {
                Console.WriteLine($"{student.FirstName} {student.LastName}, Age: {student.Age}");
            }
        }
    }
}
