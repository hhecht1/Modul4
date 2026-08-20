using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;

namespace Fahrzeugverwaltung.Models;

public class Car
{
    public int Id { get; set; }
    public string? Model { get; set; }
    public decimal Price { get; set; }
    public int Horsepower { get; set; }
    public int ManufacturerId { get; set; }
    public Manufacturer Manufacturer { get; set; } = null!;
}