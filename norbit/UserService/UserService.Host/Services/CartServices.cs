using Grpc.Core;
using Microsoft.AspNetCore.Http.HttpResults;
using ShopCartService;
using Microsoft.EntityFrameworkCore;
using UserService.Infrastructure.Contexts;
using UserService.Infrastructure.Managers;

namespace UserService.Host.Services;

public class CartServices : ShopCartService.CartService.CartServiceBase
{
    private readonly UserContext _context;
    private readonly ILogger<CartServices> _logger;
    public CartServices(ILogger<CartServices> logger, UserContext context)
    {
        _logger = logger;
        _context = context;
    }
    public override Task<GetCartByUserIdResponse> GetCartByUserId(GetCartByUserIdRequest request, ServerCallContext context)
    {
        UserManager newUM = new UserManager(_context);

        var reply = newUM.GetUserId(request.UserId);

        return Task.FromResult(new GetCartByUserIdResponse
        {
            UserId = reply
        });
    }
}
