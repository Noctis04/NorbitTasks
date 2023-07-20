using Microsoft.EntityFrameworkCore;
using ShopCartService;
using UserService.Host.Routes;
using UserService.Infrastructure.Contexts;
using UserService.Infrastructure.Extensions;
using UserService.Infrastructure.Managers;
using UserService.Host.Services;

var builder = WebApplication.CreateBuilder(args);


var connectionString = builder.Environment.IsDevelopment()
    ? builder.Configuration.GetConnectionString("DefaultConnection")
    : Environment.GetEnvironmentVariable("CONNECTION_STRING");

builder.Services.AddDbContext<UserContext>(b =>b.UseNpgsql(connectionString));

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
app.AddUserRouter();

app.MapGrpcService<CartServices>();

app.UseSwagger();

app.UseSwaggerUI();

app.UseHttpsRedirection();

app.Run();
