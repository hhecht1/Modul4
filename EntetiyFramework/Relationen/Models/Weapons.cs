using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace Relationen.Models
{
    public class Weapons
    {
        public int Id { get; set; }
        public string? Name { get; set; }
        public int? CharacterId { get; set; } // Navigation Property to Character 1:n Beziehung 
        public Character? Character { get; set; } // 1:n Beziehung Navigation Property to Character
    }
}