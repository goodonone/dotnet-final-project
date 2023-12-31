using backend_api.Repositories;
using Microsoft.AspNetCore.Mvc;
using backend_api.Models;
// using Microsoft.AspNetCore.Routing.Constraints;

namespace backend_api.Controllers;

[ApiController]
[Route("api/[controller]/")]
public class AuthController : ControllerBase
{
    private readonly ILogger<AuthController> _logger;
    private readonly IAuthService _authService;

    public AuthController(ILogger<AuthController> logger, IAuthService service)
    {
        _logger = logger;
        _authService = service;
    }
    
    [HttpPost]
    [Route("register")]
    public ActionResult CreateUser(User user)
    {
        if (user == null || !ModelState.IsValid)
        {
            return BadRequest();
        }
        _authService.CreateUser(user);
        return NoContent();
    }

    [HttpGet]
    [Route("user")]
    public ActionResult GetUser(int userId)
    {
        if (userId == null || !ModelState.IsValid)
        {
            return BadRequest();
        }
        _authService.GetUserByUserId(userId);
        return NoContent();
    }

    [HttpGet]
    [Route("login")]
    public ActionResult<string> SignIn(string userName, string password)
    {
        if (string.IsNullOrWhiteSpace(userName) || string.IsNullOrWhiteSpace(password))
        {
            return BadRequest();
        }

        var token = _authService.SignIn(userName, password);

        if (string.IsNullOrWhiteSpace(token))
        {
            return Unauthorized();
        }

        return Ok(token);
    }

}