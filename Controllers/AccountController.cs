using Microsoft.AspNetCore.Authentication;
using Microsoft.AspNetCore.Authentication.Google;
using Microsoft.AspNetCore.Mvc;

[ApiController]
[Route("[controller]")]
public class AccountController : ControllerBase
{
    [HttpGet("login")]
    public IActionResult Login()
    {
        var properties = new AuthenticationProperties
        {
            RedirectUri = Url.Action(nameof(HandleGoogleResponse), "Account")
        };

        return Challenge(properties, GoogleDefaults.AuthenticationScheme);
    }

    [HttpGet("google-response")]
    public async Task<IActionResult> HandleGoogleResponse()
    {
        var authenticateResult = await HttpContext.AuthenticateAsync();
        // Handle the authentication result, e.g., retrieve user information and generate tokens

        // Redirect or return appropriate response
        return Ok();
    }
}
