using Microsoft.AspNetCore.Mvc;
using MovieMVC.Models;

namespace MovieMVC.Controllers
{
    public class MoviesController : Controller
    {
        public IActionResult Index()
        {
            var movies = new List<Movie>
            {
                new Movie { Id = 1, Title = "The Shawshank Redemption", Director = "Frank Darabont", Price = 9.99m },
                new Movie { Id = 2, Title = "The Godfather", Director = "Francis Ford Coppola", Price = 12.99m },
                new Movie { Id = 3, Title = "The Dark Knight", Director = "Christopher Nolan", Price = 14.99m },
                new Movie { Id = 4, Title = "Pulp Fiction", Director = "Quentin Tarantino", Price = 11.99m },
                new Movie { Id = 5, Title = "Forrest Gump", Director = "Robert Zemeckis", Price = 10.99m },
                new Movie { Id = 6, Title = "Inception", Director = "Christopher Nolan", Price = 13.99m },
                new Movie { Id = 7, Title = "The Matrix", Director = "Lana Wachowski", Price = 12.99m },
                new Movie { Id = 8, Title = "Titanic", Director = "James Cameron", Price = 11.99m },
                new Movie { Id = 9, Title = "Avatar", Director = "James Cameron", Price = 15.99m },
                new Movie { Id = 10, Title = "Gladiator", Director = "Ridley Scott", Price = 10.99m },
                new Movie { Id = 11, Title = "The Lion King", Director = "Jon Favreau", Price = 9.99m },
                new Movie { Id = 12, Title = "Interstellar", Director = "Christopher Nolan", Price = 14.99m },
                new Movie { Id = 13, Title = "The Avengers", Director = "Joss Whedon", Price = 12.99m },
                new Movie { Id = 14, Title = "Joker", Director = "Todd Phillips", Price = 13.99m },
                new Movie { Id = 15, Title = "The Silence of the Lambs", Director = "Jonathan Demme", Price = 10.99m },
                new Movie { Id = 16, Title = "Parasite", Director = "Bong Joon-ho", Price = 12.99m },
                new Movie { Id = 17, Title = "Dune", Director = "Denis Villeneuve", Price = 15.99m },
                new Movie { Id = 18, Title = "The Pursuit of Happyness", Director = "Gabriele Muccino", Price = 10.99m },
                new Movie { Id = 19, Title = "Jurassic Park", Director = "Steven Spielberg", Price = 11.99m },
                new Movie { Id = 20, Title = "Back to the Future", Director = "Robert Zemeckis", Price = 9.99m },
            };
            return View(movies);
        }

        public IActionResult Details(int id)
        {
            var movie = new Movie { Id = id, Title = "Sample Movie", Director = "Sample Director", Price = 9.99m };
            return View(movie);
        }
    }
}