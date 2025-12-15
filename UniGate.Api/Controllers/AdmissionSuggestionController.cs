using Microsoft.AspNetCore.Mvc;
using UniGate.Api.Services;
using System.Threading.Tasks;

namespace UniGate.Api.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class AdmissionSuggestionController : ControllerBase
    {
        private readonly AdmissionSuggestionService _suggestionService;

        public AdmissionSuggestionController(AdmissionSuggestionService suggestionService)
        {
            _suggestionService = suggestionService;
        }

        /// <summary>
        /// Lấy danh sách các ngành/trường gợi ý dựa trên điểm thi của người dùng.
        /// </summary>
        /// <param name="userId">ID của người dùng cần tính điểm (Lấy từ bảng Users).</param>
        /// <returns>Danh sách các ngành có khả năng đỗ.</returns>
        [HttpGet("{userId}")]
        [ProducesResponseType(typeof(List<Models.DTOs.AdmissionSuggestionDto>), 200)]
        public async Task<IActionResult> GetSuggestions(int userId)
        {
            var results = await _suggestionService.GetSuggestionsAsync(userId);

            if (results == null || !results.Any())
            {
                return NotFound($"Không tìm thấy dữ liệu điểm chuẩn hoặc điểm người dùng có ID: {userId}.");
            }

            return Ok(results);
        }
    }
}