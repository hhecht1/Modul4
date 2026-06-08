namespace PizzaService.Models
{
    public class OrderDetail
    {
        public int Id { get; set; }
        public int Quantity { get; set; }
        public int ProductId { get; set; }
        public int OrderId { get; set; }

        // intersection tables to facitlitate m:n relations with navigation properties Order and Product
        public Order Order { get; set; } = null!;       // OrderId and ProductId represent FK-relationships -> aren't strictly required
        public Product Product { get; set; } = null!;

    }
}