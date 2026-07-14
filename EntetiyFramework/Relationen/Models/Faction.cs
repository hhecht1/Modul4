using System;
using System.Collections.Generic;
using System.Text;

namespace Relationen.Models
{





    public class Faction
    {
        public int Id { get; set; }
        public string? Name { get; set; }

        public ICollection<Character>? Characters { get; set; } = new List<Character>(); // Navigation Property to Character 1:n Beziehung


    }
}