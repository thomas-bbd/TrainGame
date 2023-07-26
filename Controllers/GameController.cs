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
    public Game CreateGame()
    {
        Game game = _gameService.CreateGame();
        game.currentQuestion = _gameService.NextQuestion(game.id);
        return game;
    }

    [HttpGet("Answer")]
    public bool Answer(string gameId, string answer)
    {
        return _gameService.CheckAnswer(gameId, answer);
    }

    [HttpGet("Question")]
    public Question Question(string gameId)
    {
        return _gameService.NextQuestion(gameId);
    }
}