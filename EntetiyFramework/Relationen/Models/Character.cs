using System;
using System.Collections.Generic;
using System.Text;

namespace Relationen.Models
{
    internal class Character
    {
        public int Id { get; set; }
        public string? Name { get; set; }
        public Backpack? Backpack { get; set; } // Navigation Property to Backpack 1:1 Beziehung
    }
}