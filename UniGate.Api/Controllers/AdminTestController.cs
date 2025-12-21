/*using Microsoft.AspNetCore.Mvc;
using UniGate.Core.Interfaces;

namespace UniGate.Api.Controllers;

[ApiController]
[Route("api/admin/tests")]
public class AdminTestController : ControllerBase
{
    private readonly ITestService _testService;

    public AdminTestController(ITestService testService)
    {
        _testService = testService;
    }

    [HttpPost("create")]
    public async Task<IActionResult> Create([FromBody] object dto)
    {
        await _testService.CreateQuestionAsync(dto);
        return Ok(new { message = "Create OK" });
    }

    [HttpPut("update")]
    public async Task<IActionResult> Update([FromBody] object dto)
    {
        await _testService.UpdateQuestionAsync(dto);
        return Ok(new { message = "Update OK" });
    }
}
*/