using Microsoft.Extensions.Caching.Distributed;

public class SampleService
{
    private readonly IDistributedCache _cache;

    public SampleService(IDistributedCache cache)
    {
        _cache = cache;
    }

    public async Task SetValueAsync(string key, string value)
    {
        await _cache.SetStringAsync(key, value);
    }

    public async Task<string?> GetValueAsync(string key)
    {
        return await _cache.GetStringAsync(key);
    }
}
