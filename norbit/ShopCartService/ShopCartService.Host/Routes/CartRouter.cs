using ShopCartService.Domain.Interfaces;
using ShopCartService.Domain.Entities;


namespace ShopCartService.Host.Routes;

public static class CartRouter
{
    public static WebApplication AddCartRouter(this WebApplication application)
    {
        var cartGroup = application.MapGroup("/api/carts");

        cartGroup.MapGet(pattern: "/{userId:long}", handler: GetCartByUserId);
        cartGroup.MapPost(pattern: "/{cartId:long}/items", handler: AddCartItem);
        cartGroup.MapPut(pattern: "/{cartId:long}/items/{itemId:long}", handler: UpdateCartItem);
        cartGroup.MapDelete(pattern: "/{cartId:long}/items/{itemId:long}", handler: RemoveCartItem);
        cartGroup.MapDelete(pattern: "/{cartId:long}", handler: ClearCart);
        cartGroup.MapGet(pattern: "/{cartId:long}/totalPrice", handler: GetTotalPrice);

        return application;
    }

    private static IResult GetCartByUserId(long userId, IShoppingCartManager cartManager)
    {
        var cart = cartManager.GetCartByUserId(userId);
        return cart is null
            ? Results.NotFound()
            : Results.Ok(cart);
    }

    private static IResult AddCartItem(long cartId, CartItem item, IShoppingCartManager cartManager)
    {
        var addedItem = cartManager.AddCartItem(cartId, item);
        return Results.Ok(addedItem);
    }

    private static IResult UpdateCartItem(long cartId, long itemId, CartItem item, IShoppingCartManager cartManager)
    {
        item.ProductId = itemId;
        cartManager.UpdateCartItem(cartId, item);
        return Results.Ok();
    }

    private static IResult RemoveCartItem(long cartId, long itemId, IShoppingCartManager cartManager)
    {
        cartManager.RemoveCartItem(cartId, itemId);
        return Results.Ok();
    }

    private static IResult ClearCart(long cartId, IShoppingCartManager cartManager)
    {
        cartManager.ClearCart(cartId);
        return Results.Ok();
    }

    private static IResult GetTotalPrice(long cartId, IShoppingCartManager cartManager)
    {
        var totalPrice = cartManager.GetTotalPrice(cartId);
        return Results.Ok(totalPrice);
    }
}

