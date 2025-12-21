using System;
using System.Net.Http;
using System.Net.Http.Json;
using System.Threading.Tasks;

namespace UniGate.Admin.Services
{
    public class ApiClient
    {
        private readonly HttpClient _http;

        public ApiClient()
        {
            _http = new HttpClient
            {
                BaseAddress = new Uri("https://localhost:7001/") // đổi theo API thật
            };
        }

        public async Task<T> GetAsync<T>(string url)
        {
            return await _http.GetFromJsonAsync<T>(url);
        }

        public async Task<T> PostAsync<T>(string url, object data)
        {
            var res = await _http.PostAsJsonAsync(url, data);
            return await res.Content.ReadFromJsonAsync<T>();
        }


        public async Task PutAsync<T>(string url, T data)
        {
            var res = await _http.PutAsJsonAsync(url, data);
            res.EnsureSuccessStatusCode();
        }

        public async Task DeleteAsync(string url)
        {
            await _http.DeleteAsync(url);
        }
    }
}
