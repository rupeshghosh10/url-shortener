using Microsoft.AspNetCore.Mvc;
using TinyUrl.DTOs;
using TinyUrl.Service.Interface;

namespace TinyUrl.Controllers;

[ApiController]
[Route("[controller]")]
public class TinyUrlController(ITinyUrlService tinyUrlService) : ControllerBase
{
    [HttpPost]
    public ActionResult<ShortenUrlResponse> Post([FromBody] ShortenUrlRequest request)
    {
        var shortenUrKey = tinyUrlService.ShortenUrl(request.Url);
        var response = new ShortenUrlResponse
        {
            Key = shortenUrKey,
            ShortUrl = $"www.tinyurl.com/{shortenUrKey}",
            LongUrl = request.Url
        };
        return Ok(response);
    }
}