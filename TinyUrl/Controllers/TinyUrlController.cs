using Microsoft.AspNetCore.Mvc;

namespace TinyUrl.Controllers;

[ApiController]
[Route("[controller]")]
public class TinyUrlController : ControllerBase
{
    [HttpGet]
    public IActionResult Get()
    {
        return Ok("Hello World");
    }
}