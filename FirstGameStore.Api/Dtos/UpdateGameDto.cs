using System.ComponentModel.DataAnnotations;

namespace FirstGameStore.Api.Dtos;

public record UpdateGameDto(
    [Required] string Name,
    [Required] string Genre,
    [Range(0, double.MaxValue)] decimal Price,
    DateOnly ReleaseDate
);