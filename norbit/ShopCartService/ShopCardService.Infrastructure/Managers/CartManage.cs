using ShopCartService.Domain.Interfaces;
using Microsoft.EntityFrameworkCore;
using ShopCartService.Domain.Entities;


namespace ShopCardService.Infrastructure.Contexts;

public class CartManager : IShoppingCartManager
{
    private readonly CartContext _context;

    public CartManager(CartContext context)
    {
        _context = context;
    }

    public Cart? GetCartByUserId(long userId)
    {
        return _context.Carts.FirstOrDefault(c => c.Id == userId);
    }
    public Cart CreateCart(Cart cart)
    {
        var entry = _context.Add(cart);
        _context.SaveChanges();
        return entry.Entity;
    }

    public CartItem AddCartItem(long cartId, CartItem item)
    {

        var cart = _context.Carts.FirstOrDefault(c => c.Id == cartId);
        if (cart is null)
        {
            return null;
          
        }

        cart.Items.Add(item);
        _context.Update(cart);
        _context.SaveChanges();

        return item;
    }

    public CartItem? UpdateCartItem(long cartId, CartItem item)
    {

        var cart = _context.Carts.Find(cartId);
        if (cart == null)
        {
            return null;

            //throw new ArgumentException("Неверный идентификатор корзины");
        }

        var existingItem = cart.Items.FirstOrDefault(i => i.ProductId == item.ProductId);
        if (existingItem == null)
        {
            return null;

            //throw new ArgumentException("Неверный идентификатор товара");
        }

        existingItem.Name = item.Name;
        existingItem.Price = item.Price;
        existingItem.Quantity = item.Quantity;

        var entry = _context.Update(item);
        _context.SaveChanges();
        return entry.Entity;
    }

    public CartItem? RemoveCartItem(long cartId, long itemId)
    {
        var cart = _context.Carts.Find(cartId);
        if (cart == null)
        {
            return null;

            //throw new ArgumentException("Неверный идентификатор корзины");
        }

        var item = cart.Items.FirstOrDefault(i => i.ProductId == itemId);
        if (item == null)
        {
            return null;
        
        //throw new ArgumentException("Неверный идентификатор товара");
        }

        cart.Items.Remove(item);
        _context.SaveChanges();
        return item;
    }

    public Cart? ClearCart(long cartId)
    {
        var cart = _context.Carts.Find(cartId);
        if (cart == null)
        {
            return null;

            //throw new ArgumentException("Неверный идентификатор товара");
        }

        cart.Items.Clear();
        _context.SaveChanges();
        return cart;
    }

    public int GetTotalPrice(long cartId)
    {
        var cart = _context.Carts.Find(cartId);
        if (cart == null)
        {
            return 0;
        }
        //throw new ArgumentException("Неверный идентификатор товара");

        int price = cart.Items.Sum(i => i.Price * i.Quantity);
        if (price != null)
             return price;
        else 
            return 0;
                
       
    }
}
