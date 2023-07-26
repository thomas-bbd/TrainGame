using Microsoft.AspNetCore.Mvc;
using TrainGame.Domain.Services;
using TrainGame.Domain.Models;
using TrainGame.Domain.Repository;
using Microsoft.AspNetCore.Authorization;

namespace TrainGame.Controllers;

[ApiController]
[Route("[controller]")]
[Authorize]
public class OptionController : ControllerBase
{
    private readonly IOptionRepository _optionRepository;

    public OptionController(IOptionRepository optionRepository)
    {
        _optionRepository = optionRepository;
    }

    [HttpGet]
    public IActionResult GetOptions()
    {
        var options = _optionRepository.ListAsync();
        return Ok(options);
    }
}