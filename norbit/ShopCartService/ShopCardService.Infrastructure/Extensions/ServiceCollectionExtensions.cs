using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.DependencyInjection;
using ShopCartService.Domain.Interfaces;

namespace ShopCardService.Infrastructure.Contexts;

public static class ServiceCollectionExtensions
{
    public static IServiceCollection AddBusinessLogic(this IServiceCollection services, IConfiguration configuration, string connectionString)
    {
        services.AddManagers();
        services.AddDatabase(connectionString);
        return services;
    }

    private static IServiceCollection AddManagers(this IServiceCollection services)
    {
        services.AddScoped<IShoppingCartManager, CartManager>();
        return services;
    }

    private static IServiceCollection AddDatabase(this IServiceCollection services, string connectionString)
    {
        services.AddDbContext<CartContext>(options => options.UseNpgsql(connectionString));
        return services;
    }
}
