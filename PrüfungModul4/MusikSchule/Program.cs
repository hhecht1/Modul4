using MusikSchule.Data;
using Microsoft.EntityFrameworkCore;
using MusikSchule.Models;

namespace MusikSchule;

public class Program
{
    static void Main(string[] args)
    {
        using var context = new MusikSchuleDbContext();
        context.Database.EnsureCreated();

        var teacher = new Teacher
        {
            FirstName = "Anna",
            LastName = "Müller",
            Email = "anna@music.at",

        };
        context.Teachers.Add(teacher);

        var course1 = new Course
        {
            Name = "Gitarre",
            Teacher = teacher
        };
        context.Courses.Add(course1);
        var course2 = new Course
        {
            Name = "Klavier",
            Teacher = teacher
        };
        context.Courses.Add(course2);
        var course3 = new Course
        {
            Name = "Gesang",
            Teacher = teacher
        };
        context.Courses.Add(course3);

        var maxberger = new Student
        {
            FirstName = "Max",
            LastName = "Berger",
            Email = "max@test.at"
        };
        context.Students.Add(maxberger);
        var lisahuber = new Student
        {
            FirstName = "Lisa",
            LastName = "Huber",
            Email = "lisa@test.at"
        };
        context.Students.Add(lisahuber);
        var tomwagner = new Student
        {
            FirstName = "Tom",
            LastName = "Wagner",
            Email = "tom@test.at"
        };
        context.Students.Add(tomwagner);

        context.Enrollments.AddRange(
            new Enrollment { Student = maxberger, Course = course1, EnrolledAt = DateTime.Now },
            new Enrollment { Student = lisahuber, Course = course2, EnrolledAt = DateTime.Now },
            new Enrollment { Student = tomwagner, Course = course3, EnrolledAt = DateTime.Now },
            new Enrollment { Student = maxberger, Course = course2, EnrolledAt = DateTime.Now },
            new Enrollment { Student = lisahuber, Course = course1, EnrolledAt = DateTime.Now },
            new Enrollment { Student = tomwagner, Course = course1, EnrolledAt = DateTime.Now }

        );
        context.AddRange(teacher, course1, course2, course3, maxberger, lisahuber, tomwagner);
        context.SaveChanges();


        // Abfrage der Kurse mit Lehrern und Enrollments

        var courses = context.Courses
        .Include(c => c.Teacher)
        .Include(c => c.Enrollments)
        .ToList();

        foreach (var c in courses)
        {
            Console.WriteLine($"Kurs: {c.Name}, Lehrer: {c.Teacher?.FirstName} {c.Teacher?.LastName}");
            int teilnehmer = c.Enrollments.Count;

            decimal umsatz = teilnehmer * c.MonthlyPrice;

            Console.WriteLine($"Teilnehmer: {teilnehmer}, Umsatz: {umsatz}");


        }


        // Alle Students inklusice Courses Laden

        var students = context.Students?
        .Include(s => s.Enrollments)
        .ThenInclude(e => e.Course)
        .ToList();

        Console.WriteLine("Alle Studenten mit Kursen:");
        foreach (var s in students ?? Enumerable.Empty<Student>())
        {
            Console.WriteLine($"Student: {s.FirstName} {s.LastName}");
            foreach (var enrollment in s.Enrollments ?? Enumerable.Empty<Enrollment>())
            {
                Console.WriteLine($"  Kurs: {enrollment.Course?.Name}, Eingeschrieben am: {enrollment.EnrolledAt}");
            }
        }

        // Student mit mind 2 Kursen

        var studentwithtwocourses = context.Students?
        .Include(s => s.Enrollments)
        .Where(s => s.Enrollments.Count >= 2)
        .ToList();

        Console.WriteLine("Studenten mit mindestens 2 Kursen:");
        foreach (var s in studentwithtwocourses ?? Enumerable.Empty<Student>())
        {
            Console.WriteLine($"Student: {s.FirstName} {s.LastName}, Anzahl Kurse: {s.Enrollments.Count}");
        }


        var teureKurse = context.Courses?
        .AsNoTracking()
        .Where(c => c.MonthlyPrice > 50)
        .ToList();


        Console.WriteLine("Kurse mit monatlichen Preis über 50:");
        foreach (var c in teureKurse ?? Enumerable.Empty<Course>())
        {
            Console.WriteLine($"Kurs: {c.Name}, Preis: {c.MonthlyPrice}");
        }


        // Projektion mit Select()

        var kursInfo = context.Courses?
        .Select(c => new
        {
            KursName = c.Name,
            LehrerName = c.Teacher.FirstName + " " + c.Teacher.LastName,
            TeilnehmerAnzahl = c.Enrollments.Count
        })
        .ToList();
        foreach (var info in kursInfo ?? Enumerable.Empty<dynamic>())
        {
            Console.WriteLine($"Kurs: {info.KursName}, Lehrer: {info.LehrerName}, Teilnehmer: {info.TeilnehmerAnzahl}");
        }


        var course = context.Courses?
        .FirstOrDefault(c => c.Name == "Klavier");
        if (course != null)
        {
            course.MonthlyPrice = 60;

            Console.WriteLine($"Der monatliche Preis des Kurses 'Klavier' wurde auf 60 gesetzt. Neuer Preis: {course.MonthlyPrice}");
        }
        context.SaveChanges();



        var student = context.Students?
        .Include(s => s.Enrollments)
        .FirstOrDefault(s => !s.Enrollments.Any());

        if (student != null)
        {
            // Student ist nicht in Kursen eingeschrieben
            context.Students?.Remove(student);
            Console.WriteLine($"Der Student {student.FirstName} {student.LastName} wurde gelöscht.");
        }
        else
        {
            Console.WriteLine("Es gibt keinen Studenten ohne Kurszuordnung zum Löschen.");
        }
        context.SaveChanges();












    }
}