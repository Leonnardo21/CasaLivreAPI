using CasaLivre.Domain.DTOs.Auth;
using CasaLivre.Domain.Interfaces;
using Microsoft.AspNetCore.Mvc;

namespace CasaLivre.API.Controllers;

[ApiController]
[Route("v1/auth")]
public class AuthController : ControllerBase
{
    private readonly IAuthService _authService;

    public AuthController(IAuthService authService)
    {
        _authService = authService;
    }
    
    [HttpPost("register")]
    public async Task<IActionResult> Register([FromBody] RegisterRequest request)
    {
        var response = await _authService.RegisterAsync(request);
        return response is null ? BadRequest("Usuário já existe.") : Ok(response);
    }

    [HttpPost("login")]
    public async Task<IActionResult> Login([FromBody] LoginRequest request)
    {
        var response = await _authService.LoginAsync(request);
        return response is null ? Unauthorized("Credenciais inválidas.") : Ok(response);
    }
}