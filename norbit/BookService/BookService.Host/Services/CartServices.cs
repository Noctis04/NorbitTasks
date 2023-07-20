using BookService.Infastructure.Contexts;
using BookService.Infastructure.Managers;
using Grpc.Core;
using Microsoft.AspNetCore.Http.HttpResults;
using ShopCartService;


namespace UserService.Host.Services;

public class CartServices : ShopCartService.CartService.CartServiceBase
{
    private readonly BookContext _context;
    private readonly ILogger<CartServices> _logger;
    public CartServices(ILogger<CartServices> logger, BookContext context)
    {
        _logger = logger;
        _context = context;
    }
    public override Task<AddCartItemResponse> AddCartItem(AddCartItemRequest request, ServerCallContext context)
    {
        BookManager newUM = new BookManager(_context);

        var reply = newUM.GetById(request.ProductId);

        return Task.FromResult(new AddCartItemResponse
        {
           ProductId = reply.Id, Name = reply.Title,Quantity = reply.Amount, Price = (int)reply.Price
        }) ;

    }
}
