using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;

namespace MusikSchule.Models;

public class Course
{
    public int Id { get; set; }
    public string? Name { get; set; }
    public decimal MonthlyPrice { get; set; }
    public int TeacherId { get; set; }
    public Teacher? Teacher { get; set; }
    public ICollection<Enrollment>? Enrollments { get; set; } = new List<Enrollment>();
}