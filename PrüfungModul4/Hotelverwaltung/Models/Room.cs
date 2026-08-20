using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;


namespace Hotelverwaltung.Models;

public class Room
{
    public int Id { get; set; }
    public int RoomNumber { get; set; }
    public decimal PricePerNight { get; set; }
    public bool IsAvailable { get; set; }

    public int HotelId { get; set; }
    public Hotel Hotel { get; set; } = null!;

}