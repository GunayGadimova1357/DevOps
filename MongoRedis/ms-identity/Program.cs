using Microsoft.EntityFrameworkCore;
using ms_identity.Data;
using ms_identity.Endpoints;
using ms_identity.Services;
using Scalar.AspNetCore;
using StackExchange.Redis;

var builder = WebApplication.CreateBuilder(args);

builder.Services.AddOpenApi();

// ENV
var postgresConn = Environment.GetEnvironmentVariable("POSTGRES_CONNECTION")
    ?? throw new Exception("POSTGRES_CONNECTION is not set");

var redisConn = Environment.GetEnvironmentVariable("REDIS_CONNECTION")
    ?? throw new Exception("REDIS_CONNECTION is not set");


// Postgres
builder.Services.AddDbContext<AppDbContext>(opt =>
    opt.UseNpgsql(postgresConn));

// Redis
builder.Services.AddSingleton<IConnectionMultiplexer>(
    ConnectionMultiplexer.Connect(redisConn));
builder.Services.AddSingleton<ICacheService, CacheService>();

builder.Services.AddEndpointsApiExplorer();

var app = builder.Build();

// create db
using (var scope = app.Services.CreateScope())
{
    var db = scope.ServiceProvider.GetRequiredService<AppDbContext>();
    db.Database.EnsureCreated();
}

app.MapOpenApi();
app.MapUsers();
app.MapScalarApiReference();

app.Run();
