using DeltaPatchIssue.Models;
using Microsoft.AspNetCore.OData.Deltas;

namespace DeltaPatchIssue.Cache;

public interface ICacheService
{
    SomeSystem Get(string key);
    IEnumerable<SomeSystem> Get();
    SomeSystem Post(SomeSystem system);
    SomeSystem Patch(string key, Delta<SomeSystem> system);
}