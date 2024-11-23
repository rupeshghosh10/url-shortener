using Microsoft.AspNetCore.Mvc;
using TinyUrl.DTOs;

namespace TinyUrl.Controllers;

[ApiController]
[Route("[controller]")]
public class TinyUrlController : ControllerBase
{
    [HttpPost]
    public ActionResult<ShortenUrlResponse> Post([FromBody] ShortenUrlRequest request)
    {
        var response = new ShortenUrlResponse();
        return Ok(response);
    }
}