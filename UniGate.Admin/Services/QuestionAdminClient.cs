using System;
using System.Collections.Generic;
using System.Net.Http;
using System.Net.Http.Json;
using System.Threading.Tasks;
using UniGate.Admin.Models;

namespace UniGate.Admin.Services
{
    public class QuestionAdminClient
    {
        private readonly HttpClient _client = new HttpClient
        {
            BaseAddress = new Uri("https://localhost:7062/")
        };

        public async Task<List<AdminQuestionDto>> GetAllAsync()
        {
            return await _client.GetFromJsonAsync<List<AdminQuestionDto>>(
                "api/admin/holland");
        }

        public async Task AddAsync(AdminQuestionDto q)
        {
            await _client.PostAsJsonAsync("api/admin/holland", q);
        }

        public async Task UpdateAsync(int id, AdminQuestionDto q)
        {
            await _client.PutAsJsonAsync($"api/admin/holland/{id}", q);
        }

        public async Task DeleteAsync(int id)
        {
            await _client.DeleteAsync($"api/admin/holland/{id}");
        }
    }
}
