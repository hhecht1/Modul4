namespace PizzaService.Models
{
    public class Customer
    {
        public int Id { get; set; }
        public string FirstName { get; set; } = null!;  // Unterdrückt null Warnung, soll in db aber nicht null sein
        public string LastName { get; set; } = null!;   // Unterdrückt null Warnung, soll in db aber nicht null sein

        public string DateOfBirth { get; set; } = null!;  // Unterdrückt null Warnung, soll in db aber nicht null sein

        public string? Email { get; set; }          // darf in der db null sein

        public string? Address { get; set; }         // darf in der db null sein

        public string? Phone { get; set; }          // darf in der db null sein
        public ICollection<Order> Orders { get; set; } = null!;  // Navigation Property
    }


}