using Microsoft.Extensions.DependencyInjection;
using MyApi.Infrastructure.Persistence;

namespace MyApi.Infrastructure;

public static class DependencyInjection
{
    public static IServiceCollection AddInfrastructure(this IServiceCollection services)
    {
        services.AddSingleton<IProductRepository, ProductRepository>();
        return services;
    }
}
