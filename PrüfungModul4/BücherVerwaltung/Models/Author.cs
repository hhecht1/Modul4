using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using BücherVerwaltung.Models;


namespace BücherVerwaltung.Models
{
    public class Author
    {
        public int Id { get; set; }
        public string? Name { get; set; }
        public ICollection<Book>? Books { get; set; } = new List<Book>();


    }
}