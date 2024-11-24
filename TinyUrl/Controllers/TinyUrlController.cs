using Microsoft.AspNetCore.Mvc;
using TinyUrl.DTOs;
using TinyUrl.Service.Interface;

namespace TinyUrl.Controllers;

[ApiController]
[Route("[controller]")]
public class TinyUrlController(ITinyUrlService tinyUrlService) : ControllerBase
{
    [HttpPost]
    public async Task<ActionResult<ShortenUrlResponse>> Post([FromBody] ShortenUrlRequest request)
    {
        var shortenUrKey = await tinyUrlService.ShortenUrl(request.Url);
        var scheme = HttpContext.Request.Scheme;
        var domain = HttpContext.Request.Host.Value;
        var response = new ShortenUrlResponse
        {
            Key = shortenUrKey,
            ShortUrl = $"{scheme}://{domain}/{shortenUrKey}",
            LongUrl = request.Url
        };

        return Ok(response);
    }

    [HttpGet("/{key}")]
    public async Task<IActionResult> Get(string key)
    {
        var url = await tinyUrlService.GetUrl(key);
        if (url is null)
        {
            return NotFound();
        }

        return Redirect(url);
    }
}