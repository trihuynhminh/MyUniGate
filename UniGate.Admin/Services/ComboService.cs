using System;
using System.Collections.Generic;
using System.Linq;
using System.Net.Http.Json;
using System.Text;
using System.Threading.Tasks;
using UniGate.Shared.DTOs;

namespace UniGate.Admin.Services
{
    public class ComboService
    {
        private readonly HttpClient _http = new()
        {
            BaseAddress = new Uri("https://localhost:7062/")
        };

        public async Task<List<ComboDto>> GetAllAsync()
        {
            return await _http.GetFromJsonAsync<List<ComboDto>>("api/combos")
                ?? new List<ComboDto>();
        }
    }
}
