using System.Collections.Generic;
using System.Net.Http;
using System.Net.Http.Json;
using System.Threading.Tasks;
using UniGate.Student.Models;

namespace UniGate.Student.Services
{
    public class AdminHollandApiService
    {
        private readonly HttpClient _client;

        public AdminHollandApiService()
        {
            _client = new HttpClient
            {
                BaseAddress = new System.Uri("https://localhost:7062/")
            };
        }

        // ================= GET ALL =================
        public async Task<List<HollandQuestion>> GetAllAsync()
        {
            return await _client.GetFromJsonAsync<List<HollandQuestion>>(
                "api/admin/holland"
            );
        }

        // ================= CREATE =================
        public async Task CreateAsync(HollandQuestion question)
        {
            await _client.PostAsJsonAsync(
                "api/admin/holland",
                question
            );
        }

        // ================= UPDATE =================
        public async Task UpdateAsync(HollandQuestion question)
        {
            await _client.PutAsJsonAsync(
                $"api/admin/holland/{question.Id}",
                question
            );
        }

        // ================= DELETE =================
        public async Task DeleteAsync(int id)
        {
            await _client.DeleteAsync(
                $"api/admin/holland/{id}"
            );
        }
    }
}
