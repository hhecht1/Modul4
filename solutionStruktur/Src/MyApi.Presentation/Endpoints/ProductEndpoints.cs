using MyApi.Presentation.Abstractions;
using MyApi.Application.Abstractions.Repositories;

namespace MyApi.Presentation.Endpoints;

public class ProductEndpoints : IEndpoint
{
    public void MapEndpoint(IEndpointRouteBuilder app)
    {
        // Gruppierung mit Versionierung für saubere URLs
        var group = app.MapGroup("/api/v1/products")
                       .WithTags("Products"); // Wichtig für OpenAPI

        group.MapPost("/", CreateProduct);
        group.MapGet("/{id:guid}", GetProduct);
    }

    private static async Task<IResult> CreateProduct(
        IProductRepository repo,
        CancellationToken ct)
    {
        var id = Guid.NewGuid();
        // Platzhalter für Command-Verarbeitung
        return Results.Created($"/api/v1/products/{id}", new { Id = id });
    }

    private static async Task<IResult> GetProduct(
        Guid id,
        IProductRepository repo,
        CancellationToken ct)
    {
        var product = await repo.GetByIdAsync(id, ct);
        return product is not null ? Results.Ok(product) : Results.NotFound();
    }
}
