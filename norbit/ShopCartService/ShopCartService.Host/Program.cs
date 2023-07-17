using ShopCardService.Infrastructure.Contexts;
using ShopCartService.Host.Routes;

var builder = WebApplication.CreateBuilder(args);

var connectionString = builder.Environment.IsDevelopment()
    ? builder.Configuration.GetConnectionString("DefaultConnection")
    : Environment.GetEnvironmentVariable("CONNECTION_STRING");

builder.Services.AddBusinessLogic(builder.Configuration, connectionString!);


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
