using Grpc.Core;
using Microsoft.EntityFrameworkCore;
using ShopCardService.Infrastructure.Contexts;
using ShopCartService.Host.Routes;

var builder = WebApplication.CreateBuilder(args);

var connectionString = builder.Environment.IsDevelopment()
    ? builder.Configuration.GetConnectionString("DefaultConnection")
    : Environment.GetEnvironmentVariable("CONNECTION_STRING");

builder.Services.AddBusinessLogic(builder.Configuration, connectionString!);

builder.Services.AddDbContext<CartContext>(b => b.UseNpgsql(connectionString));

builder.Services.AddEndpointsApiExplorer();
builder.Services.AddSwaggerGen();

builder.Services.AddGrpc();

var app = builder.Build();

app.MapGrpcService<CartManager>();

app.AddCartRouter();

 app.UseSwagger();

 app.UseSwaggerUI();

app.UseHttpsRedirection();

app.Run();

//internal class Test : CartService.CartServiceBase
//{
//    public override Task<AddCartItemResponse> AddCartItem(AddCartItemRequest request, ServerCallContext context)
//    {
//        return base.AddCartItem(request, context);
//    }

//    public override Task<ClearCartResponse> ClearCart(ClearCartRequest request, ServerCallContext context)
//    {
//        return base.ClearCart(request, context);
//    }

//    public override Task<GetCartByUserIdResponse> GetCartByUserId(GetCartByUserIdRequest request, ServerCallContext context)
//    {
//        return base.GetCartByUserId(request, context);
//    }

//    public override Task<GetTotalPriceResponse> GetTotalPrice(GetTotalPriceRequest request, ServerCallContext context)
//    {
//        return base.GetTotalPrice(request, context);
//    }

//    public override Task<RemoveCartItemResponse> RemoveCartItem(RemoveCartItemRequest request, ServerCallContext context)
//    {
//        return base.RemoveCartItem(request, context);
//    }

//    public override Task<UpdateCartItemResponse> UpdateCartItem(UpdateCartItemRequest request, ServerCallContext context)
//    {
//        return base.UpdateCartItem(request, context);
//    }
//}