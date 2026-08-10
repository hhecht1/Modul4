
using MyApi.Domain.Entities;
using MyApi.Application.Abstractions.Repositories;

namespace MyApi.Application.Products.Commands;

// .NET 10 Record für stark typisierte Eingabedaten
public record CreateProductCommand(string Name, decimal Price);

public class CreateProductHandler
{
    private readonly IProductRepository _repository;
    public CreateProductHandler(IProductRepository repository) => _repository = repository;

    public async Task<Guid> HandleAsync(CreateProductCommand command, CancellationToken cancellationToken)
    {
        var product = new Product(Guid.NewGuid(), command.Name, command.Price);
        await _repository.AddAsync(product, cancellationToken);
        return product.Id;
    }
}