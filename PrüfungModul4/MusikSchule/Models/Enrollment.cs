using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
namespace MusikSchule.Models;

public class Enrollment
{
    public int Id { get; set; }
    public DateTime EnrolledAt { get; set; }
    public int StudentId { get; set; }
    public Student? Student { get; set; }
    public int CourseId { get; set; }
    public Course? Course { get; set; }
}