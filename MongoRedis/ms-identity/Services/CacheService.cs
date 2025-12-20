using System.Text.Json;
using StackExchange.Redis;

namespace ms_identity.Services;

public class CacheService : ICacheService
{
    private readonly IDatabase _cache;

    public CacheService(IConnectionMultiplexer redis)
    {
        _cache = redis.GetDatabase();
    }

    public async Task<T?> GetAsync<T>(string key)
    {
        var value = await _cache.StringGetAsync(key);
        return value.HasValue
            ? JsonSerializer.Deserialize<T>(value!)
            : default;
    }

    public async Task SetAsync<T>(string key, T value, TimeSpan ttl)
    {
        await _cache.StringSetAsync(
            key,
            JsonSerializer.Serialize(value),
            ttl
        );
    }
}
