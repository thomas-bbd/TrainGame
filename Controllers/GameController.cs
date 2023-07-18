using Microsoft.AspNetCore.Mvc;

namespace TrainGame.Controllers;

[ApiController]
[Route("[controller]")]
public class GameController : ControllerBase
{
    [HttpGet]
    public IActionResult GetGame()
    {
        var data = new { message = "Hello, I am the game!" };

        return Ok(data);
    }

    [HttpGet("Item")]
    public IActionResult GetItem()
    {
        var data = new { message = "Hello, I am a train!" };
        
        return Ok(data);
    }
}