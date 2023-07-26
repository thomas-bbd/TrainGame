using Microsoft.AspNetCore.Authentication;
using Microsoft.AspNetCore.Authentication.Google;
using Microsoft.AspNetCore.Mvc;
using System.Security.Claims;

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

        if (authenticateResult.Succeeded)
        {
            var googleUsername = HttpContext.User.FindFirstValue(ClaimTypes.Name);

            var claims = new List<Claim>
                {
                    new Claim(ClaimTypes.Name, googleUsername),
                };

            var identity = new ClaimsIdentity(claims, GoogleDefaults.AuthenticationScheme);
            var principal = new ClaimsPrincipal(identity);

            await HttpContext.SignInAsync(principal);

            return Redirect("/");
        }

        return BadRequest("Authentication failed.");
    }

    [HttpGet("logout")]
    public async Task<IActionResult> Logout()
    {
        await HttpContext.SignOutAsync("Cookies"); // Use "Cookies" authentication scheme here

        return Redirect("/");
    }
}
