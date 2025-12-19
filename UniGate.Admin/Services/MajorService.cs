using System.Net.Http.Json;
using UniGate.Core.Entities;
using UniGate.Shared.DTOs;

namespace UniGate.Admin.Services
{
    public class MajorService
    {
        private readonly HttpClient _http = new()
        {
            BaseAddress = new Uri("https://localhost:7062/")
        };

        public async Task<int> CreateAsync(MajorUpsertDto dto)
        {
            
            var res = await _http.PostAsJsonAsync("api/admin/majors", dto);
            if (!res.IsSuccessStatusCode)
            {
                var err = await res.Content.ReadAsStringAsync();
                throw new Exception(err);
            }

            var id = await res.Content.ReadFromJsonAsync<int>();
            return id;
        }
        

        public async Task<List<MajorAdminDto>> GetByUniversityAsync(int universityId)
        {
            return await _http.GetFromJsonAsync<List<MajorAdminDto>>(
                $"api/admin/majors?schoolId={universityId}"
            ) ?? new List<MajorAdminDto>();
        }

        public async Task DeleteAsync(int id)
        {
            var res = await _http.DeleteAsync($"api/admin/majors/{id}");
            res.EnsureSuccessStatusCode();
        }

        public async Task UpdateAsync(int id, MajorUpsertDto dto)
        {
            dto.Id = id;
            var res = await _http.PutAsJsonAsync($"api/admin/majors/{id}", dto);
            if (!res.IsSuccessStatusCode)
            {
                var err = await res.Content.ReadAsStringAsync();
                throw new Exception(err);
            }
        }
    }
}
