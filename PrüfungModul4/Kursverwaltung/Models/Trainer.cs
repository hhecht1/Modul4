using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;

namespace Kursverwaltung.Models;

public class Trainer
{
    [Key]
    public int Id { get; set; }
    [Required]
    [MaxLength(50)]
    public string? Name { get; set; }
    [Required]
    public string? Email { get; set; }
    public ICollection<Course> Courses { get; set; } = new List<Course>();
}