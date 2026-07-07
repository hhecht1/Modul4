using FirstGameStore.Api.Data;
using FirstGameStore.Api.Dtos;

namespace FirstGameStore.Api.Endpoints;

public static class GamesEndpoints
{
    const string GetGameEndpointName = "GetGame";

    private static readonly List<GamesDto> games = [.. GameData.Games];

    public static RouteGroupBuilder MapGamesEndpoints(this WebApplication app)
    {
        var group = app.MapGroup("/games");

        group.MapGet("/", GetAllGames);
        group.MapGet("/{id}", GetGameById).WithName(GetGameEndpointName);
        group.MapGet("/price/{maxPrice}", GetGamesByMaxPrice);
        group.MapGet("/genre/{genre}", GetGamesByGenre);
        group.MapPost("/", CreateGame);
        group.MapPut("/{id}", UpdateGame);
        group.MapDelete("/{id}", DeleteGame);

        return group;
    }

    private static IResult GetAllGames() => Results.Ok(games);

    private static IResult GetGameById(int id)
    {
        var game = games.Find(g => g.Id == id);
        return game is null ? Results.NotFound() : Results.Ok(game);
    }

    private static IResult GetGamesByMaxPrice(decimal maxPrice) =>
        Results.Ok(games.Where(g => g.Price <= maxPrice));

    private static IResult GetGamesByGenre(string genre) =>
        Results.Ok(games.Where(g => g.Genre.Equals(genre, StringComparison.OrdinalIgnoreCase)));

    private static IResult CreateGame(CreateGameDto newGame)
    {
        if (games.Any(g => g.Name == newGame.Name))
        {
            return Results.BadRequest("Game existiert bereits");
        }

        var nextId = games.Count == 0 ? 1 : games.Max(g => g.Id) + 1;

        GamesDto game = new(
            nextId,
            newGame.Name,
            newGame.Genre,
            newGame.Price,
            newGame.ReleaseDate);

        games.Add(game);

        return Results.CreatedAtRoute(
            GetGameEndpointName,
            new { id = game.Id },
            game);
    }

    private static IResult UpdateGame(int id, UpdateGameDto updatedGame)
    {
        var index = games.FindIndex(g => g.Id == id);

        if (index == -1)
        {
            return Results.NotFound();
        }

        games[index] = new GamesDto(
            id,
            updatedGame.Name,
            updatedGame.Genre,
            updatedGame.Price,
            updatedGame.ReleaseDate);

        return Results.Accepted();
    }

    private static IResult DeleteGame(int id)
    {
        games.RemoveAll(g => g.Id == id);
        return Results.NoContent();
    }
}