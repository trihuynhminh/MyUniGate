using System.Net.Http;
using System.Net.Http.Json;
using UniGate.Shared.DTOs;   // ComboDto

namespace UniGate.Admin.Services
{
    public class SubjectGroupService
    {
        private readonly HttpClient _http = new()
        {
            BaseAddress = new Uri("https://localhost:7062/")
        };

        // Lấy tất cả tổ hợp (GroupID, GroupName, Subjects)
        public async Task<List<SubjectGroupDto>> GetAllAsync()
        {
            return await _http.GetFromJsonAsync<List<SubjectGroupDto>>(
                "api/subject-groups"
            ) ?? new();
        }
    }
}
