public static class ProductModules
{
    public static void MapProductEndpoints(this IEndpointRouteBuilder app)
    {
        var group = app.MapGroup("/api/v1/products");

        group.MapGet("/", GetAllProducts);
        group.MapGet("/{id}", GetProductById);
    }

    private static IResult GetAllProducts(IProductRepository repo)
        => Results.Ok(repo.List());

    private static IResult GetProductById(int id, IProductRepository repo)
        => repo.Find(id) is Product p ? Results.Ok(p) : Results.NotFound();
}

// Dummys für Kompilierbarkeit
public record Product(int Id, string Name);

public interface IProductRepository { List<Product> List(); Product? Find(int id); }

public class ProductRepository : IProductRepository
{
    public List<Product> List() => new List<Product> { new Product(1, "Laptop"), new Product(2, "Maus") };
    public Product? Find(int id) => List().FirstOrDefault(p => p.Id == id);
}