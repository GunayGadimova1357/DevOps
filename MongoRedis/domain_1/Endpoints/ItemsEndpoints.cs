using System.Text.Json;
using domain_1.Models;
using domain_1.Repositories;
using domain_1.Services;

namespace domain_1.Endpoints;

public static class ItemsEndpoints
{
    public static void MapItems(this WebApplication app)
    {
        app.MapGet("/items", async (
            IItemRepository repo,
            ICacheService cache) =>
        {
            var cacheKey = "items";

            var cached = await cache.GetAsync(cacheKey);
            if (cached != null)
                return Results.Ok(JsonSerializer.Deserialize<List<Item>>(cached));

            var items = await repo.GetAllAsync();
            await cache.SetAsync(cacheKey, JsonSerializer.Serialize(items));

            return Results.Ok(items);
        });

        app.MapPost("/items", async (
            ItemCreate dto,
            IItemRepository repo) =>
        {
            var item = new Item { Name = dto.Name };
            await repo.AddAsync(item);
            return Results.Ok(item);
        });
    }
}
