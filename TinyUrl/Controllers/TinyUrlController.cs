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
        var response = new ShortenUrlResponse
        {
            Key = shortenUrKey,
            ShortUrl = $"www.tinyurl.com/{shortenUrKey}",
            LongUrl = request.Url
        };

        return Ok(response);
    }

    [HttpGet("/{key}")]
    public async Task<IActionResult> Get(string key)
    {
        try
        {
            var url = await tinyUrlService.GetUrl(key);
            return Redirect(url);
        }
        catch
        {
            return NotFound();
        }
    }
}