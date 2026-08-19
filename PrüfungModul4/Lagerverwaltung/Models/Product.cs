using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;

namespace Lagerverwaltung.Models;

public class Product
{
    public int Id { get; set; }
    public string? Name { get; set; }
    public decimal Price { get; set; }
    public int Stock { get; set; }
    public int SupplierId { get; set; }

    public ICollection<Supplier>? Suppliers { get; set; } = new List<Supplier>();
    public Supplier? Supplier { get; set; }
}