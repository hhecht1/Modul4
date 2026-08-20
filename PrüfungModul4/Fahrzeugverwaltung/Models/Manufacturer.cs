using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using Fahrzeugverwaltung.Models;
namespace Fahrzeugverwaltung.Models;


public class Manufacturer
{
    public int Id { get; set; }
    public string? Name { get; set; }
    public string? Country { get; set; }

    public ICollection<Car>? Cars { get; set; } = new List<Car>();
}
