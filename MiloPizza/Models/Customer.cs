namespace PizzaService.Models
{
    public class Customer
    {
        public int Id { get; set; }
        public string FirstName { get; set; } = null!;
        public string LastName { get; set; } = null!;

        public string? Adress { get; set; }         // darf in der db null sein

        public string? Phone { get; set; }
        public ICollection<Order> Orders { get; set; } = null!;  // Navigation Property
    }


}