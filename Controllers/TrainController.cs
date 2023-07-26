using Microsoft.AspNetCore.Mvc;
using TrainGame.Domain.Services;
using TrainGame.Domain.Models;
using TrainGame.Domain.Repository;
using Microsoft.AspNetCore.Authorization;

namespace TrainGame.Controllers;

[ApiController]
[Route("[controller]")]
[Authorize]
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