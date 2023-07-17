using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.DependencyInjection;
using BookService.Domain;
using BookService.Infastructure.Contexts;
using BookService.Infastructure.Managers;

namespace BookService.Infastructure.Extensions;

public static class ServiceCollectionExtensions
{
    /// <summary>
    ///     Добавляем бизнес-логику приложения
    /// </summary>
    /// <param name="services"><see cref="IServiceCollection"/></param>
    /// <param name="configuration"><see cref="IConfiguration"/></param>
    /// <returns><see cref="IServiceCollection"/></returns>
    public static IServiceCollection AddBusinessLogic(this IServiceCollection services, IConfiguration configuration)
    {
        services.AddManagers();
        services.AddDatabase(configuration);
        return services;
    }

    /// <summary>
    ///     Добавление менеджеров данных.
    /// </summary>
    /// <param name="services"><see cref="IServiceCollection"/></param>
    /// <returns><see cref="IServiceCollection"/></returns>
    private static IServiceCollection AddManagers(this IServiceCollection services)
    {
        services.AddScoped<IBookManager, BookManager>();
        return services;
    }

    // <summary>
    ///     Добавление Базы Данных.
    /// </summary>
    /// <param name="services"><see cref="IServiceCollection"/></param>
    /// <param name="configuration"><see cref="IConfiguration"/></param>
    /// <returns><see cref="IServiceCollection"/></returns>
    private static IServiceCollection AddDatabase(this IServiceCollection services, IConfiguration configuration)
    {
        services.AddDbContext<BookContext>(builder =>
            builder.UseNpgsql(
                configuration.GetConnectionString("DefaultConnection")));

        return services;
    }
}
