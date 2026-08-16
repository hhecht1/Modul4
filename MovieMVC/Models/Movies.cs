namespace MovieMVC.Models
{
    public class Movie
    {
        public int Id { get; set; }
        public string? Title { get; set; } = string.Empty;
        public string Director { get; set; } = string.Empty;
        public decimal Price { get; set; }
    }
}