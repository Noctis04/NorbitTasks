using Microsoft.EntityFrameworkCore;
using BookService.Domain;


namespace BookService.Infastructure.Contexts;
public sealed class BookContext : DbContext
{
    /// <summary>
    ///     Пользователи
    /// </summary>
    
    public DbSet<Book> Books => Set<Book>();

    public BookContext(DbContextOptions options) : base(options)
    {
        Database.Migrate();
    }
   protected override void OnConfiguring(DbContextOptionsBuilder optionsBuilder)
    {
        optionsBuilder.UseNpgsql("Server=localhost;Port=5432;Database=user_db;User Id=postgres;Password=password;");
    }
}