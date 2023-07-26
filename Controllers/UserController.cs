using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
using TrainGame.Domain.Models;
using TrainGame.Domain.Repository;
using TrainGame.Persistence.Contexts;

namespace TrainGame.Controllers;

[ApiController]
[Route("[controller]")]
[Authorize]
public class UserController : ControllerBase
{
    private readonly IUserRepository _userRepository;
    public UserController(IUserRepository userRepository)
    {
        _userRepository = userRepository;
    }

    [HttpGet]
    public IActionResult GetUser()
    {
        try
        {
            var userName = HttpContext.User.Identity.Name;

            // Get the user based on the userName
            var user = _userRepository.GetUser(userName);

            if (user != null)
            {
                return Ok(user);
            }
            else
            {
                return NotFound("User not found");
            }
        }
        catch (Exception ex)
        {
            return StatusCode(500, $"Error: {ex.Message}");
        }
    }

    [HttpPost("New")]
    public IActionResult PostNewUser()
    {
        try
        {
            var userName = HttpContext.User.Identity.Name;

            // Check if the user already exists
            var existingUser = _userRepository.GetUser(userName);
            if (existingUser != null)
            {
                return BadRequest("User already exists");
            }

            // Create a new User object with the userName
            var newUser = new User
            {
                userName = userName,
                highScore = 0
            };

            _userRepository.AddUser(newUser);

            return Ok("User added");
        }
        catch (Exception ex)
        {
            return StatusCode(500, $"Error: {ex.Message}");
        }
    }

    [HttpGet("Score")]
    public IActionResult GetUserScore()
    {
        try
        {
            var userName = HttpContext.User.Identity.Name;

            var user = _userRepository.GetUser(userName);
            if (user != null)
            {
                int highScore = user.highScore;
                return Ok(highScore);
            }
            else
            {
                return NotFound("No such user " + userName);
            }

        }
        catch (Exception ex)
        {
            return StatusCode(500, $"Error: {ex.Message}");
        }
    }

    [HttpPost("Score/Update")]
    public IActionResult PostUserScore(int Score)//[FromBody] MyModel model)
    {
        try
        {
            var userName = HttpContext.User.Identity.Name;

            var user = new User
            {
                userName = userName,
                highScore = 0
            };

            _userRepository.UpdateUserScore(user);

            return Ok("User added");
        }
        catch (Exception ex)
        {
            return StatusCode(500, $"Error: {ex.Message}");
        }
    }
}