using Microsoft.AspNetCore.Mvc;
using UniGate.Api.Services;
using UniGate.Api.DTOs;

namespace UniGate.Api.Controllers;

[ApiController]
[Route("api/[controller]")]
public class MajorController : ControllerBase
{
    private readonly MajorService _majorService;

    public MajorController(MajorService majorService)
    {
        _majorService = majorService;
    }

    [HttpPost("filter")]
    public async Task<IActionResult> FilterMajors([FromBody] FilterRequest request)
    {
        // Cập nhật dòng này: Truyền thêm request.PersonalityType
        var result = await _majorService.GetSuitableMajors(
            request.Score,
            request.Group,
            request.PersonalityType // <--- Thêm cái này
        );

        return Ok(result);
    }

}

// Class nhận dữ liệu từ Client gửi lên
public class FilterRequest
{
    public float Score { get; set; }
    public string Group { get; set; } = "";
    public string? PersonalityType { get; set; } // VD: "INTJ" hoặc null
}