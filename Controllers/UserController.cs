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

    [HttpPost("New")]
    public IActionResult PostNewUser()//[FromBody] MyModel model)
    {
        // Logic to process the posted data
        // model parameter contains the data sent in the request body

        // Return a response, such as success status or created resource
        var result = new { message = "Data received successfully" };
        return Ok(result);
    }

    [HttpGet("Score")]
    public IActionResult GetUserScore()
    {
        var data = new { message = "Hello, User Score!" };

        return Ok(data);
    }

    [HttpPost("Score/Update")]
    public IActionResult PostUserScore()//[FromBody] MyModel model)
    {
        // Logic to process the posted data
        // model parameter contains the data sent in the request body

        // Return a response, such as success status or created resource
        var result = new { message = "Data received successfully" };
        return Ok(result);
    }
}