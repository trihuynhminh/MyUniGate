using System;
using System.Collections.Generic;
using System.Net.Http;
using System.Net.Http.Json;
using System.Threading.Tasks;
using UniGate.Shared.DTOs;

namespace UniGate.Admin.Services
{
    public class UniversityService
    {
        private readonly HttpClient _http;

        public UniversityService()
        {
            _http = new HttpClient
            {
                BaseAddress = new Uri("https://localhost:7062/")
            };
        }

        public async Task<List<UniversityDto>> GetAllAsync(string? keyword = null)
        {
            string url = "api/universities";
            if (!string.IsNullOrWhiteSpace(keyword))
                url += $"?keyword={keyword}";

            return await _http.GetFromJsonAsync<List<UniversityDto>>(url)
                   ?? new List<UniversityDto>();
        }

        public async Task DeleteAsync(int id)
        {
            var res = await _http.DeleteAsync($"api/universities/{id}");
            res.EnsureSuccessStatusCode();
        }

        public async Task CreateAsync(UniversityCreateRequest req)
        {
            var res = await _http.PostAsJsonAsync("api/universities", req);
            res.EnsureSuccessStatusCode();
        }

        public async Task UpdateAsync(int id, UniversityUpdateRequest req)
        {
            var res = await _http.PutAsJsonAsync($"api/universities/{id}", req);
            res.EnsureSuccessStatusCode();
        }
    }
}
