using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Text;

namespace PizzaService.Models
{
    public class Product
    {
        //[Key]
        public int Id { get; set; }
        public string Name { get; set; } = null!;  // Unterdrückt null Warnung, soll in db aber nicht null sein

        //[Required]
        //public string Name? { get; set; }

        [Column(TypeName = "decimal(6, 2)")]   // mit 2 Nachkomma Präzision
        public decimal Price { get; set; }

    }
}