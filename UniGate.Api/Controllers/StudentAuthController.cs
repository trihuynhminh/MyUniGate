using Microsoft.AspNetCore.Mvc;
using UniGate.Api.DTOs;
using UniGate.Api.Services;

namespace UniGate.Api.Controllers;

[ApiController]
[Route("api/student/auth")]
public class StudentAuthController : ControllerBase
{
    private readonly IAuthService _authService;

    public StudentAuthController(IAuthService authService)
    {
        _authService = authService;
    }

    [HttpPost("register")]
    public async Task<IActionResult> Register([FromBody] RegisterRequest dto)
    {
        var result = await _authService.RegisterAsync(dto);
        return Ok(result);
    }
}
