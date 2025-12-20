using domain_1.Models;

namespace domain_1.Repositories;

public interface IItemRepository
{
    Task<List<Item>> GetAllAsync();
    Task AddAsync(Item item);
}
