using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;

namespace Aspnetcore_Auth.Controllers;

[Route("[controller]")]
[ApiController]
public class ApiController : ControllerBase
{
    [HttpGet("public")]
    public IActionResult Public()
    {
        return Ok(new
        {
            Message = "Hello from a public endpoint! You don't need to be authenticated to see this."
        });
    }

    [HttpGet("private")]
    [Authorize]
    public IActionResult Private()
    {
        return Ok(new
        {
            Message = "Hello from a private endpoint! You need to be authenticated to see this."
        });
    }

    [HttpGet("claims")]
    public IActionResult Claims()
    {
        return Ok(User.Claims.Select(c =>
            new
            {
                c.Type,
                c.Value
            }));
    }
}
