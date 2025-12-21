using System;
using System.Collections.Generic;
using System.Net.Http;
using System.Net.Http.Json;
using System.Threading.Tasks;
using UniGate.Student.Models;

namespace UniGate.Student.Services
{
    public class ApiClient
    {
        private readonly HttpClient _http = new()
        {
            BaseAddress = new Uri("https://localhost:7062/")
        };

        public async Task<List<HollandQuestion>> GetHollandQuestionsAsync()
        {
            return await _http.GetFromJsonAsync<List<HollandQuestion>>(
                "api/holland/questions"
            ) ?? new();
        }
    }
}
