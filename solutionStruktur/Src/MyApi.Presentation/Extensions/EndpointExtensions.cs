using MyApi.Presentation.Abstractions;
using MyApi.Presentation.Endpoints;

namespace MyApi.Presentation.Extensions;

public static class EndpointExtensions
{
    // AOT-sichere Registrierung der Endpoints
    public static IServiceCollection AddEndpoints(this IServiceCollection services)
    {
        return services;
    }

    public static WebApplication MapAllEndpoints(this WebApplication app)
    {
        // Explizite Zuweisung verhindert Reflection-Overhead beim Starten
        IEndpoint[] endpoints = new IEndpoint[]
        {
            new ProductEndpoints()
            // Hier weitere Endpoints einfach anfügen (z.B. new OrderEndpoints())
        };

        foreach (var endpoint in endpoints)
        {
            endpoint.MapEndpoint(app);
        }

        return app;
    }
}