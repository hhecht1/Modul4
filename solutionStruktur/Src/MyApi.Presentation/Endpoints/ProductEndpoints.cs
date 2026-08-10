
using MyApi.Presentation.Abstractions;
using MyApi.Presentation.Endpoints;
using MyApi.Products.Application.Handlers;
using MyApi.Products.Application.Common.Interfaces;

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
        CreateProductCommand command,
        CreateProductHandler handler,
        CancellationToken ct)
    {
        var id = await handler.HandleAsync(command, ct);
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