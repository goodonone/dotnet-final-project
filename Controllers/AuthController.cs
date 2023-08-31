using backend_api.Repositories;
using Microsoft.AspNetCore.Mvc;
using backend_api.Models;

namespace backend_api.Controllers;

[ApiController]
[Route("api/[controller]")]
public class AuthController : ControllerBase 
{
    private readonly ILogger<AuthController> _logger;
    private readonly IAuthService _authService;

    public AuthController(ILogger<AuthController> logger, IAuthService service)
    {
        _logger = logger;
        _authService = service;
    }
}