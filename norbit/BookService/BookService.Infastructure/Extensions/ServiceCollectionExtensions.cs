using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.DependencyInjection;
using BookService.Domain;
using BookService.Infastructure.Contexts;
using BookService.Infastructure.Managers;

namespace BookService.Infastructure.Extensions;

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
        services.AddScoped<IBookManager, BookManager>();
        return services;
    }


    private static IServiceCollection AddDatabase(this IServiceCollection services, string connectionString)
    {
        services.AddDbContext<BookContext>(builder => builder.UseNpgsql(connectionString));
        return services;
    }
}
