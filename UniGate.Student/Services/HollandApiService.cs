using System;
using System.Net.Http;
using System.Net.Http.Json;
using System.Threading.Tasks;
using UniGate.Student.Models;

public class HollandApiService
{
    private readonly HttpClient _http = new HttpClient
    {
        BaseAddress = new Uri("https://localhost:7062/")
    };

    public async Task<HollandSubmitResponse> SubmitAsync(object request)
    {
        var response = await _http.PostAsJsonAsync("api/holland/submit", request);
        response.EnsureSuccessStatusCode();
        return await response.Content.ReadFromJsonAsync<HollandSubmitResponse>();
    }
}
