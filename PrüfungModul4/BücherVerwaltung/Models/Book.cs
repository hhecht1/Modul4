using System;
using System.Collections.Generic;
using System.Linq;
using BücherVerwaltung.Models;

namespace BücherVerwaltung.Models
{
    public class Book
    {
        public int Id { get; set; }
        public string? Title { get; set; }
        public decimal Price { get; set; }
        public int PublishedYear { get; set; }
        public int AuthorId { get; set; }
        public Author Author { get; set; } = null!;
    }
}