using Microsoft.AspNetCore.Mvc;
using TrainGame.Domain.Services;
using TrainGame.Domain.Models;
using Microsoft.AspNetCore.Authorization;

namespace TrainGame.Controllers;

[ApiController]
[Route("[controller]")]
[Authorize]
public class Controller : ControllerBase
{

    [HttpGet]
    public String Test()
    {
        return "root controller";
    }
}