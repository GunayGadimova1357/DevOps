using domain_1.Models;
using MongoDB.Driver;

namespace domain_1.Repositories;

public class ItemRepository : IItemRepository
{
    private readonly IMongoCollection<Item> _collection;

    public ItemRepository(IMongoClient client)
    {
        var db = client.GetDatabase("items_db");
        _collection = db.GetCollection<Item>("items");
    }

    public async Task<List<Item>> GetAllAsync() =>
        await _collection.Find(_ => true).ToListAsync();

    public async Task AddAsync(Item item) =>
        await _collection.InsertOneAsync(item);
}
