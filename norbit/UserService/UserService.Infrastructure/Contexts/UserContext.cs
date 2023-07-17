using Microsoft.EntityFrameworkCore;
using UserService.Domain.Entity;

namespace UserService.Infrastructure.Contexts;

public class UserContext : DbContext
{
    public DbSet<User> Users => Set<User>();

    public UserContext(DbContextOptions options) : base(options)
    {
        Database.Migrate();
    }
}
