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
   
}