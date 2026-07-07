namespace FirstGameStore.Api.Dtos;

public record GamesDto
(
    int Id,
    string Name,
    string Genre,
    decimal Price,
    DateOnly ReleaseDate
);