// Controllers/HomeController.cs
using Microsoft.AspNetCore.Mvc;
using SimpleMVC.Models;

namespace SimpleMVC.Controllers
{
    public class HomeController : Controller
    {
        // Simuliert eine Datenbankabfrage
        private static readonly List<Book> _books = new List<Book>
        {
            new Book { Id = 1, Title = "Der Alchimist", Author = "Paulo Coelho", Price = 12.99m },
            new Book { Id = 2, Title = "1984", Author = "George Orwell", Price = 9.99m }
        };

        // URL: /Home/Index oder einfach /
        public IActionResult Index()
        {
            // Daten vom "Modell" holen und an die View übergeben
            return View(_books);
        }

        // URL: /Home/Details/1
        public IActionResult Details(int id)
        {
            var book = _books.FirstOrDefault(b => b.Id == id);

            if (book == null)
            {
                return NotFound(); // Gibt HTTP 404 zurück
            }

            return View(book);
        }
    }
}