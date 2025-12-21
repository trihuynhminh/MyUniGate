using System;
using System.Collections.Generic;
using System.Linq;
using System.Net.Http.Json;
using System.Text;
using System.Threading.Tasks;
using UniGate.Shared.DTOs;

namespace UniGate.Admin.Services
{
    public class AdmissionService
    {
        private readonly HttpClient _http = new()
        {
            BaseAddress = new Uri("https://localhost:7062/")
        };

        public async Task UpsertAsync(AdmissionUpsertRequest req)
        {
            var res = await _http.PostAsJsonAsync(
                "api/admin/admissions/upsert", req);
            var body = await res.Content.ReadAsStringAsync();
            MessageBox.Show(body);

            res.EnsureSuccessStatusCode();
        }
    }

}
