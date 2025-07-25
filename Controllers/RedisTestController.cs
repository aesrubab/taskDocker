using Microsoft.AspNetCore.Mvc;
using Microsoft.Extensions.Caching.Distributed;

[ApiController]
[Route("[controller]")]
public class RedisTestController : ControllerBase
{
    private readonly IDistributedCache _cache;

    public RedisTestController(IDistributedCache cache)
    {
        _cache = cache;
    }

    [HttpGet("set")]
    public async Task<IActionResult> Set()
    {
        await _cache.SetStringAsync("myKey", "Salam Rubab!");
        return Ok("Set edildi");
    }

    [HttpGet("get")]
    public async Task<IActionResult> Get()
    {
        var value = await _cache.GetStringAsync("myKey");
        return Ok(value ?? "Tapılmadı");
    }
}
