using Microsoft.AspNetCore.Builder;
using Microsoft.Extensions.DependencyInjection;
using Microsoft.AspNetCore.Mvc;
// using MinimalAPI.Models;     
var builder = WebApplication.CreateBuilder(args);

// 1. Dependency Injection (Services registrieren)
builder.Services.AddSingleton<ITimeService, TimeService>();
builder.Services.AddScoped<IProductRepository, ProductRepository>();

var app = builder.Build();

// 2. Middleware-Pipeline konfigurieren
app.UseHttpsRedirection();

// 3. Endpoints definieren (Routing)    
app.MapGet("/", () => "Willkommen bei der .NET 10 Minimal API!");

app.MapGet("/time", (ITimeService timeService) =>
    Results.Ok(new { CurrentTime = timeService.GetLocalTime() }));



// 1. Route Parameter (Spezifische Ressource abrufen)
app.MapGet("/users/{id:int}", (int id) =>
    Results.Ok($"Benutzer mit ID {id} gesucht."));

// 2. Query Parameter (Filterung / Suche)
app.MapGet("/products", (string? search, int? page) =>
    Results.Ok($"Suche nach: {search}, Seite: {page ?? 1}"));

// 3. Body Parameter & Status Codes
app.MapPost("/orders", (OrderDto newOrder) =>
{
    // Logik zum Speichern der Bestellung...
    return Results.Created($"/orders/{newOrder.Id}", newOrder);
});

// 4. Header & Cookiemanipulation explizit abgreifen
app.MapGet("/agent", ([FromHeader(Name = "User-Agent")] string userAgent) =>
    Results.Ok($"Ihr Browser: {userAgent}"));

app.MapProductEndpoints(); // Erweiterungsmethode aus ProductModules.cs


app.Run();
public record OrderDto(int Id, string Product, int Quantity);



// Hilfs-Services für das Beispiel
public interface ITimeService { string GetLocalTime(); }
public class TimeService : ITimeService { public string GetLocalTime() => DateTime.Now.ToShortTimeString(); }


