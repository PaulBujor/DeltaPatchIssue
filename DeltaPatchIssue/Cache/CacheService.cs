using DeltaPatchIssue.Models;
using Microsoft.AspNetCore.OData.Deltas;
using Newtonsoft.Json;

namespace DeltaPatchIssue.Cache;

public class CacheService : ICacheService
{
    private readonly IDictionary<string, SomeSystem> _cache = new Dictionary<string, SomeSystem>();

    public SomeSystem Get(string key)
    {
        return _cache[key];
    }

    public IEnumerable<SomeSystem> Get()
    {
        return _cache.Values;
    }

    public SomeSystem Post(SomeSystem system)
    {
        system.Key = Guid.NewGuid().ToString();
        _cache[system.Key] = system;
        return system;
    }

    public SomeSystem Patch(string key, Delta<SomeSystem> system)
    {
        if (!_cache.ContainsKey(key)) throw new Exception("Missing object in cache, post first");

        var existingEntry = _cache[key];
        // var clone = JsonConvert.DeserializeObject<SomeSystem>(JsonConvert.SerializeObject(existingEntry));
        system.Patch(existingEntry);
        _cache[key] = existingEntry;
        return existingEntry;
    }
}