using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace Relationen.Models
{
    internal class Backpack
    {
        public int Id { get; set; }
        public string? Description { get; set; }
        public int CharacterId { get; set; } // Navigation Property to Character 1:1 Beziehung 
        public Character? Character { get; set; } // 1:1 Beziehung Navigation Property to Character
    }
}