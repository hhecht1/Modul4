using System.ComponentModel.DataAnnotations;
using System.Collections.Generic;

namespace Kursverwaltung.Models;

public class Course
{
    [Key]
    public int Id { get; set; }
    [Required]
    [MaxLength(100)]
    public string? Title { get; set; }
    [Required]
    public decimal Price { get; set; }
    public int TrainerId { get; set; }
    public Trainer? Trainer { get; set; }
}
