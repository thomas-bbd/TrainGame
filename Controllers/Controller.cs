using Microsoft.AspNetCore.Mvc;

namespace TrainGame.Controllers;

[ApiController]
[Route("[controller]")]
public class Controller : ControllerBase
{

    [HttpGet]
    public String Test()
    {
        return "root controller";
    }
}