using RestSharp;
using System.Collections.Generic;
using System.Threading.Tasks;
using UniGate.Core.Entities; // Dùng lại class University của anh

namespace UniGate.Client.Services;

public class ApiService
{
    private readonly RestClient _client;

    public ApiService()
    {
        // Địa chỉ API của anh (nhớ kiểm tra đúng cổng 5151 ko nha)
        _client = new RestClient("http://localhost:5151/api/");
    }

    public async Task<List<University>> GetUniversitiesAsync()
    {
        var request = new RestRequest("University", Method.Get);
        var response = await _client.ExecuteAsync<List<University>>(request);

        // Nếu có dữ liệu thì trả về, ko thì trả về danh sách rỗng
        return response.Data ?? new List<University>();
    }
}