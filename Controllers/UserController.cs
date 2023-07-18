using Microsoft.AspNetCore.Mvc;

namespace TrainGame.Controllers;

[ApiController]
[Route("[controller]")]
public class UserController : ControllerBase
{
    [HttpGet]
    public IActionResult GetUser()
    {
        var data = new { message = "Hello, User!" };

        return Ok(data);
    }

    [HttpGet("Score")]
    public IActionResult GetUserScore()
    {
        var data = new { message = "Hello, User Score!" };
        
        return Ok(data);
    }
}