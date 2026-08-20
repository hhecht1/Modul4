using System;
using System.Collections.Generic;
using Fahrzeugverwaltung.Data;
using Fahrzeugverwaltung.Models;
using Microsoft.EntityFrameworkCore;

public class Program
{
    public static void Main(string[] args)
    {
        using var context = new FahrzeugverwaltungContext();

        context.Database.EnsureCreated();

        // Add new Manufacturer

        var bmw = new Manufacturer
        {
            Name = "BMW",
            Country = "Germany",
            Cars = new List<Car>
            {
                new Car
                {
                    Model = "BMW 320i",
                    Price=45.900m,
                    Horsepower = 184
                },
                new Car
                {
                    Model= "BMW M3",
                    Price=89.900m,
                    Horsepower = 510
                },
                new Car
                {
                    Model="BMW X1",
                    Price = 49.000m,
                    Horsepower = 170
                }

            }
        };
        context.Manufacturers.Add(bmw);
        context.SaveChanges();
        Console.WriteLine("Manufacturer and cars added successfully.");


        var manufactures = context.Manufacturers
            .Include(m => m.Cars)
            .AsNoTracking()
            .ToList();
        Console.WriteLine("Manufacturers and their cars:");

        foreach (var manufacturer in manufactures)
        {
            Console.WriteLine($"{manufacturer.Name} | Autos: ({manufacturer.Cars?.Count}) |Gesamtwert:  {manufacturer.Cars?.Sum(c => c.Price)} .€");
        }

        var expensiveCars = context.Cars
        .AsNoTracking()
        .Where(c => c.Price > 50000)
        .OrderByDescending(c => c.Horsepower)
        .ToList();

        Console.WriteLine("Expensive cars (Price > 50,000):");
        foreach (var car in expensiveCars)
        {
            Console.WriteLine($"{car.Model} | Price: {car.Price} | Horsepower: {car.Horsepower}");
        }

        var sortedCars = context.Cars
        .FirstOrDefault(c => c.Model == "BMW X1");
        if (sortedCars != null)
        {
            sortedCars.Price = 47.900m;
        }
        context.SaveChanges();
        Console.WriteLine("Updated BMW X1 price to 47,900 €.");

        var bmw320i = context.Cars
        .FirstOrDefault(c => c.Model == "BMW 320i");
        if (bmw320i != null)
        {
            context.Cars.Remove(bmw320i);

        }
        context.SaveChanges();
        Console.WriteLine("Deleted BMW 320i from the database.");




    }
}