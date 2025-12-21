using System;
using System.Collections.Generic;
using System.Net.Http;
using System.Net.Http.Json;
using System.Threading.Tasks;
using UniGate.Infrastructure.Entities; // ✅

namespace UniGate.Student.Services
{
    public class AdminApiService
    {
        private readonly HttpClient _client;

        public AdminApiService()
        {
            _client = new HttpClient();
            _client.BaseAddress = new Uri("https://localhost:5001/");
        }

        public async Task<List<HollandQuestion>> GetAllAsync()
        {
            return await _client.GetFromJsonAsync<List<HollandQuestion>>(
                "api/admin/holland");
        }

        public async Task AddAsync(HollandQuestion q)
        {
            await _client.PostAsJsonAsync("api/admin/holland", q);
        }

        public async Task DeleteAsync(int id)
        {
            await _client.DeleteAsync($"api/admin/holland/{id}");
        }
    }
}
