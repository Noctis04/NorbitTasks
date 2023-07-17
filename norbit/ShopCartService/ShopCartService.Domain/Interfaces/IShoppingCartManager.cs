
using ShopCartService.Domain.Entities;
namespace ShopCartService.Domain.Interfaces;

public interface IShoppingCartManager
{
    Cart? GetCartByUserId(long userId);
    CartItem AddCartItem(long cartId, CartItem item);
    CartItem? UpdateCartItem(long cartId, CartItem item);
    CartItem? RemoveCartItem(long cartId, long itemId);
    Cart? ClearCart(long cartId);
    decimal GetTotalPrice(long cartId);
}
    