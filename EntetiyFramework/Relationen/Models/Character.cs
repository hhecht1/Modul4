using System;
using System.Collections.Generic;
using System.Text;

namespace Relationen.Models
{
    public class Character
    {
        public int Id { get; set; }
        public string? Name { get; set; }
        public virtual Backpack? Backpack { get; set; } // Navigation Property to Backpack 1:1 Beziehung
        public ICollection<Faction>? Factions { get; set; } = new List<Faction>(); // Navigation Property to Faction n:n Beziehung

        public ICollection<Weapons>? Weapons { get; set; } = new List<Weapons>(); // Navigation Property to Weapons 1:n Beziehung


    }
}