using MyApi.Application.Abstractions.Repositories;
using MyApi.Domain.Entities;
using System.Collections.Concurrent;

namespace MyApi.Infrastructure.Persistence;

// Thread-sicheres In-Memory Repo (Perfekt für Demos und AOT-Tests)
public class ProductRepository : IProductRepository
{
    private static readonly ConcurrentDictionary<Guid, Product> _products = new();

    public Task<Product?> GetByIdAsync(Guid id, CancellationToken cancellationToken)
    {
        _products.TryGetValue(id, out var product);
        return Task.FromResult(product);
    }

    public Task AddAsync(Product product, CancellationToken cancellationToken)
    {
        _products[product.Id] = product;
        return Task.CompletedTask;
    }
}