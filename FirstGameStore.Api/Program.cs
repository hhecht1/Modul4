public class Program
{
    public static void Main(string[] args)
    {

        const string GetNameEndPointName = "GetGame";



        // Konfiguration der Services für die App
        var builder = WebApplication.CreateBuilder(args);   // Builder Pattern

        var app = builder.Build();  // Instanz der WebApplication (Host)

        // HTTP-Pipeline, hier wird definiert was bei http-requests passiert
        app.MapGet("/", () => "Hello World!");



        List<GamesDto> games = new List<GamesDto>()
        {
            new GamesDto(1, "The Legend of Zelda: Breath of the Wild", "Action-Adventure", 59.99m, new DateOnly(2017, 3, 3)),
            new GamesDto(2, "Red Dead Redemption 2", "Action-Adventure", 59.99m, new DateOnly(2018, 10, 26)),
            new GamesDto(3, "The Witcher 3: Wild Hunt", "RPG", 39.99m, new DateOnly(2015, 5, 19)),
            new GamesDto(4, "Cyberpunk 2077", "RPG", 59.99m, new DateOnly(2020, 12, 10)),
            new GamesDto(5, "Minecraft", "Sandbox", 26.95m, new DateOnly(2011, 11, 18)),
            new GamesDto(6, "Fortnite", "Battle Royale", 0.00m, new DateOnly(2017, 7, 21)),
            new GamesDto(7, "Among Us", "Party", 4.99m, new DateOnly(2018, 6, 15)),
            new GamesDto(8, "Elden Ring", "Action-RPG", 59.99m, new DateOnly(2022, 2, 25)),
            new GamesDto(9, "Hogwarts Legacy", "Action-Adventure", 59.99m, new DateOnly(2023, 2, 10)),
            new GamesDto(10, "Starfield", "Action-RPG", 69.99m, new DateOnly(2023, 9, 6)),
            new GamesDto(11, "Baldur's Gate 3", "RPG", 59.99m, new DateOnly(2023, 8, 3)),
            new GamesDto(12, "Palworld", "Action-Adventure", 29.99m, new DateOnly(2024, 1, 19)),
            new GamesDto(13, "Dragon Age: Inquisition", "RPG", 39.99m, new DateOnly(2014, 11, 18)),
            new GamesDto(14, "Mass Effect Legendary Edition", "Action-RPG", 59.99m, new DateOnly(2021, 5, 14)),
            new GamesDto(15, "Fallout 4", "Action-RPG", 39.99m, new DateOnly(2015, 11, 10)),
            new GamesDto(16, "Skyrim", "Action-RPG", 39.99m, new DateOnly(2011, 11, 11)),
            new GamesDto(17, "GTA V", "Action-Adventure", 49.99m, new DateOnly(2013, 9, 17)),
            new GamesDto(18, "Halo Infinite", "FPS", 59.99m, new DateOnly(2021, 12, 8)),
            new GamesDto(19, "Call of Duty: Modern Warfare III", "FPS", 69.99m, new DateOnly(2023, 11, 10)),
            new GamesDto(20, "Destiny 2", "FPS", 0.00m, new DateOnly(2017, 9, 6)),
            new GamesDto(21, "Overwatch 2", "FPS", 0.00m, new DateOnly(2022, 10, 4)),
            new GamesDto(22, "League of Legends", "MOBA", 0.00m, new DateOnly(2009, 10, 27)),
            new GamesDto(23, "Dota 2", "MOBA", 0.00m, new DateOnly(2013, 7, 9)),
            new GamesDto(24, "Counter-Strike 2", "FPS", 0.00m, new DateOnly(2023, 9, 1)),
            new GamesDto(25, "Valorant", "FPS", 0.00m, new DateOnly(2020, 6, 2)),
            new GamesDto(26, "Stardew Valley", "Simulation", 14.99m, new DateOnly(2016, 2, 28)),
            new GamesDto(27, "The Sims 4", "Simulation", 39.99m, new DateOnly(2014, 9, 2))


        };
        app.MapGet("/games", () => games);

        app.MapGet("/games/{id}", (int id) => games.Find(game => game.Id == id)).WithName(GetNameEndPointName); // Findet ein Spiel anhand der ID und gibt es zurück, mit einem Namen für die Route

        app.MapGet("/games/price/{maxPrice}", (decimal maxPrice) => games.Where(game => game.Price <= maxPrice).ToList()); // Filtert die Spiele nach dem Preis und gibt eine Liste zurück

        app.MapGet("/games/genre/{genre}", (string genre) => games.FindAll(game => game.Genre == genre));


        app.MapPost("/games", (CreateGameDto newGame) =>
            {
                GamesDto game = new(
                games.Count + 1,  // problematisch, aber dazu später

                newGame.Name,
                newGame.Genre,
                newGame.Price,
                newGame.ReleaseDate
                );
                if (games.Any(g => g.Name == newGame.Name))
                {
                    return Results.BadRequest("Game existiert bereits");
                }

                games.Add(game);

                // Route , unique id  , body of the just created resource
                // return Results.Created();  // 201 Created, mit einem Location Header, aber ohne Body
                return Results.CreatedAtRoute(GetNameEndPointName, new { id = game.Id }, game);


            });

        // PUT /games/1
        app.MapPut("/games/{id}", (int id, UpdateGameDto updatedGame) =>
        {
            var index = games.FindIndex(game => game.Id == id);

            games[index] = new GamesDto(
                id,
                updatedGame.Name,
                updatedGame.Genre,
                updatedGame.Price,
                updatedGame.ReleaseDate
            );

            return Results.Accepted();
        });


        // DELETE /games/1
        app.MapDelete("/games/{id}", (int id) =>
        {
            games.RemoveAll(game => game.Id == id);

            return Results.NoContent();
        });










        app.Run();    // ausführen der App
    }
}