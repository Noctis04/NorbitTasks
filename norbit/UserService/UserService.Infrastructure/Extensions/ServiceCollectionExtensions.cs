using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.DependencyInjection;
using UserService.Domain.Entity;
using UserService.Infrastructure.Contexts;
using UserService.Infrastructure.Managers;

namespace UserService.Infrastructure.Extensions;

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
        services.AddScoped<IUserManager, UserManager>();
        return services;
    }
    private static IServiceCollection AddDatabase(this IServiceCollection services, string connectionString)
    {
        services.AddDbContext<UserContext>(builder => builder.UseNpgsql(connectionString));
        return services;
    }
}
