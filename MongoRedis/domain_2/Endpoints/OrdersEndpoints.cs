using domain_2.Data;
using domain_2.Models;
using Microsoft.EntityFrameworkCore;

namespace domain_2.Endpoints;

public static class OrdersEndpoints
{
    public static void MapOrders(this WebApplication app)
    {
        app.MapGet("/orders", async (OrdersDbContext db) =>
        {
            var orders = await db.Orders.ToListAsync();
            return Results.Ok(orders);
        });

        app.MapPost("/orders", async (Order order, OrdersDbContext db) =>
        {
            db.Orders.Add(order);
            await db.SaveChangesAsync();
            return Results.Created($"/orders/{order.Id}", order);
        });
    }
}

