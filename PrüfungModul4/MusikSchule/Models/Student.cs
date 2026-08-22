using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;

namespace MusikSchule.Models;

public class Student
{
    public int ID { get; set; }
    public string? FirstName { get; set; }
    public string? LastName { get; set; }
    public string? Email { get; set; }
    public ICollection<Enrollment>? Enrollments { get; set; } = new List<Enrollment>();
}