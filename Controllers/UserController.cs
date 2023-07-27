using System.IdentityModel.Tokens.Jwt;
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
            Request.Headers.TryGetValue("Authorization", out var bearer);
            var jwt = bearer.ToString().Split(" ")[1];
            var handler = new JwtSecurityTokenHandler();
            var token = handler.ReadJwtToken(jwt);
            string username = token.Payload["username"].ToString() ?? string.Empty;
            // Get the user based on the userName
            var user = _userRepository.GetUser(username);

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
            Request.Headers.TryGetValue("Authorization", out var bearer);
            string userName = GetUsername(bearer);
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
            Request.Headers.TryGetValue("Authorization", out var bearer);
            string userName = GetUsername(bearer);
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
        Request.Headers.TryGetValue("Authorization", out var bearer);
        string userName = GetUsername(bearer);

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

    private string GetUsername(String bearer)
    {
        var jwt = bearer.ToString().Split(" ")[1];
        var handler = new JwtSecurityTokenHandler();
        var token = handler.ReadJwtToken(jwt);
        return token.Payload["username"].ToString() ?? string.Empty;
    }    
    
    [HttpGet("Scores")]
    public IActionResult GetUserScores()
    {
        var scores = _userRepository.ListAll();
        scores = scores.OrderByDescending(x => x.highScore).ToList();
        return Ok(scores.Take(10));
    }
}