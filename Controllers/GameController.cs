using Microsoft.AspNetCore.Mvc;
using TrainGame.Domain.Services;
using TrainGame.Domain.Models;


namespace TrainGame.Controllers;

[ApiController]
[Route("[controller]")]
public class GameController : ControllerBase
{
    private readonly IGameService _gameService;

    public GameController(IGameService gameService)
    {
        _gameService = gameService;
    }

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

    [HttpGet("Game")]
    public Game CreateGame()
    {
        return _gameService.CreateGame();
    }
}