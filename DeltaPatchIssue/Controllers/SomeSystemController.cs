using DeltaPatchIssue.Cache;
using DeltaPatchIssue.Models;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.OData.Deltas;
using Microsoft.AspNetCore.OData.Formatter;
using Microsoft.AspNetCore.OData.Query;
using Microsoft.AspNetCore.OData.Routing.Controllers;

namespace DeltaPatchIssue.Controllers;
//
// [ApiController]
// [Route("[controller]")]
public class SomeSystemController : ODataController
{
    private readonly ICacheService _cacheService;

    private readonly ILogger<SomeSystemController> _logger;

    public SomeSystemController(ILogger<SomeSystemController> logger, ICacheService cacheService)
    {
        _logger = logger;
        _cacheService = cacheService;
    }

    [EnableQuery]
    [HttpGet]
    public IActionResult Get()
    {
        return Ok(_cacheService.Get());
    }

    // [EnableQuery]
    // [HttpGet("{id}")]
    // public IActionResult GetOne([FromODataUri] string id)
    // {
    //     return Ok(_cacheService.Get(id));
    // }

    [HttpPost]
    public IActionResult Post([FromBody] SomeSystem system)
    {
        return Ok(_cacheService.Post(system));
    }

    [HttpPatch]
    public IActionResult Patch([FromODataUri] string key, [FromBody] Delta<SomeSystem> system)
    {
        return Ok(_cacheService.Patch(key, system));
    }
}