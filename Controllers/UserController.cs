using System.IdentityModel.Tokens.Jwt;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
using TrainGame.Domain.Models;
using TrainGame.Domain.Repository;

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

    [HttpPost("Score/Update")]
    public IActionResult PostUserScore([FromBody] UpdateScore score)//[FromBody] MyModel model)
    {
        try
        {
            Request.Headers.TryGetValue("Authorization", out var bearer);
            string userName = GetUsername(bearer);
            var user = _userRepository.GetUser(userName);
            if (user == null)
            {
                user = new User{userName = userName, highScore=0};
                _userRepository.AddUser(user);
            }
            if (user.highScore < score.score)
            {
                user.highScore = score.score;
                _userRepository.UpdateUserScore(user);
                return Ok("User score updated");

            }
            return Ok("Doesn't beat their high score");

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