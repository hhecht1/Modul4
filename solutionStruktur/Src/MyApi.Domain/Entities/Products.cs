namespace MyApi.Domain.Entities;

public class Product
{
    public Guid Id { get; private set; }
    public string Name { get; private set; } = string.Empty;
    public decimal Price { get; private set; }

    // .NET 10 Parameterless Constructor für ORM/Serialisierung nötig
    private Product() { }

    public Product(Guid id, string name, decimal price)
    {
        if (string.IsNullOrWhiteSpace(name)) throw new ArgumentException("Name darf nicht leer sein.");
        if (price < 0) throw new ArgumentException("Preis darf nicht negativ sein.");

        Id = id;
        Name = name;
        Price = price;
    }
}