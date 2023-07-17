using Microsoft.EntityFrameworkCore;
using ShopCartService.Domain.Entities;

namespace ShopCardService.Infrastructure.Contexts;

public sealed class CartContext : DbContext
{

    public DbSet<Cart> Carts { get; set; }
    public DbSet<CartItem> CartItems { get; set; }

    public CartContext(DbContextOptions<CartContext> options) : base(options)
    {
        Database.Migrate();
    }
}
