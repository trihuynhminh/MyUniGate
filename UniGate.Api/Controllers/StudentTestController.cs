using Microsoft.AspNetCore.Mvc;
using UniGate.Core.Interfaces;

namespace UniGate.Api.Controllers;

[ApiController]
[Route("api/student/tests")]
public class StudentTestController : ControllerBase
{
    private readonly ITestService _testService;

    public StudentTestController(ITestService testService)
    {
        _testService = testService;
    }

    [HttpPost("submit")]
    public async Task<IActionResult> Submit([FromBody] object dto)
    {
        var result = await _testService.SubmitAsync(dto);
        return Ok(result);
    }
}
