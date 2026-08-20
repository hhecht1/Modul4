using Hotelverwaltung.Data;
using Hotelverwaltung.Models;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Storage.ValueConversion.Internal;

namespace Hotelverwaltung;

public class Program
{
    static void Main(string[] args)
    {

        using var context = new HotelVerwaltungContext();

        context.Database.EnsureCreated();

        var alpenblick = new Hotel
        {
            Name = "Hotel Alpenblick",
            City = "Salzburg",

            Rooms = new List<Room>
            {
                new Room
                {
                    RoomNumber = 101,
                    PricePerNight = 120.00m,
                    IsAvailable = true
                },
                new Room
                {
                    RoomNumber = 102,
                    PricePerNight = 150.00m,
                    IsAvailable = true
                },
                new Room
                {
                    RoomNumber = 103,
                    PricePerNight = 200.00m,
                    IsAvailable = false
                }
            }
        };
        var meerblick = new Hotel
        {
            Name = "Hotel Meerblick",
            City = "Innsbruck",
            Rooms = new List<Room>
            {
                new Room
                {
                    RoomNumber = 201,
                    PricePerNight = 100.00m,
                    IsAvailable = true
                },
                new Room
                {
                    RoomNumber = 202,
                    PricePerNight = 130.00m,
                    IsAvailable = false
                }
            }

        };
        context.Hotels.Add(alpenblick);
        context.Hotels.Add(meerblick);
        context.SaveChanges();


        Console.WriteLine("Hotels and rooms added successfully.");

        // Retrieve and display hotels with their rooms
        var hotel = context.Hotels
        .Include(h => h.Rooms)
        .AsNoTracking()
        .ToList();

        foreach (var h in hotel)
        {
            Console.WriteLine($"Hotel: {h.Name} | City: {h.City} | Rooms: ({h.Rooms?.Count})");
            foreach (var room in h.Rooms ?? Enumerable.Empty<Room>())
            {
                Console.WriteLine($"  Room Number: {room.RoomNumber} | Price per Night: {room.PricePerNight} | Available: {room.IsAvailable}");


                decimal totalRevenue = h.Rooms?.Sum(r => r.PricePerNight) ?? 0m;
                Console.WriteLine($"  Total Revenue: {totalRevenue}");
            }
        }

        var availbleRooms = context.Rooms
        .AsNoTracking()
        .Where(r => r.IsAvailable && r.PricePerNight > 100)
        .OrderByDescending(r => r.PricePerNight)
        .ToList();

        foreach (var room in availbleRooms)
        {
            Console.WriteLine($"Available Room: {room.RoomNumber} | Price per Night: {room.PricePerNight} | Hotel: {room.Hotel?.Name}");
        }

        var room102 = context.Rooms
        .FirstOrDefault(r => r.RoomNumber == 102);
        if (room102 != null)
        {
            room102.PricePerNight = 149.90m;
            Console.WriteLine("Updated Room 102 price to 149.90 €.");
        }


        var room101 = context.Rooms
        .FirstOrDefault(r => r.RoomNumber == 101);
        if (room101 != null)
        {
            context.Rooms.Remove(room101);

            Console.WriteLine("Deleted Room 101 from the database.");
        }


        context.SaveChanges();






    }

}