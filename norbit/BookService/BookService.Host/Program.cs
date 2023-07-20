using BookService.Host.Routes;
using BookService.Infastructure.Contexts;
using BookService.Infastructure.Extensions;
using BookService.Infastructure.Managers;
using Microsoft.EntityFrameworkCore;
using ShopCartService;
using UserService.Host.Services;


var builder = WebApplication.CreateBuilder(args);

var connectionString = builder.Environment.IsDevelopment()
    ? builder.Configuration.GetConnectionString("DefaultConnection")
    : Environment.GetEnvironmentVariable("CONNECTION_STRING");

builder.Services.AddDbContext<BookContext>(b => b.UseNpgsql(connectionString));

const string myAllowSpecificOrigins = "_myAllowSpecificOrigins";
builder.Services.AddCors(options =>
{
    options.AddPolicy(name: myAllowSpecificOrigins,
        policyBuilder =>
        {
            policyBuilder
                .WithOrigins("*")
                .AllowAnyHeader()
                .AllowAnyMethod();
        });
});

builder.Services.AddBusinessLogic(builder.Configuration, connectionString!);


builder.Services.AddEndpointsApiExplorer();

builder.Services.AddSwaggerGen();

builder.Services.AddGrpc();

var app = builder.Build();

app.UseCors(myAllowSpecificOrigins);

app.AddBookRouter();

app.MapGrpcService<CartServices>();

app.UseSwagger();

app.UseSwaggerUI();

app.UseHttpsRedirection();

app.Run();
