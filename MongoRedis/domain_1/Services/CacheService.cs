using StackExchange.Redis;

namespace domain_1.Services;

public class CacheService : ICacheService
{
    private readonly IDatabase _cache;

    public CacheService(IConnectionMultiplexer redis)
    {
        _cache = redis.GetDatabase();
    }

    public async Task<string?> GetAsync(string key)
    {
        var value = await _cache.StringGetAsync(key);
        return value.HasValue ? value.ToString() : null;
    }

    public async Task SetAsync(string key, string value)
    {
        await _cache.StringSetAsync(key, value, TimeSpan.FromSeconds(30));
    }
}
