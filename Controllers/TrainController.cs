using Microsoft.AspNetCore.Mvc;
using TrainGame.Domain.Services;
using TrainGame.Domain.Models;
using TrainGame.Domain.Repository;


namespace TrainGame.Controllers;

[ApiController]
[Route("[controller]")]
public class TrainController : ControllerBase
{
    private readonly ITrainRepository _trainRepository;

    public TrainController(ITrainRepository trainRepository)
    {
        _trainRepository = trainRepository;
    }

    [HttpGet]
    public IActionResult GetTrains()
    {
        var trains = _trainRepository.ListAsync();
        return Ok(trains);
    }
}