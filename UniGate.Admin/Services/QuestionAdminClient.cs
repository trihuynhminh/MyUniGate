using System;
using System.Collections.Generic;
using System.Net.Http;
using System.Net.Http.Json;
using System.Threading.Tasks;
using UniGate.Admin.Models;

namespace UniGate.Admin.Services;

public class QuestionAdminClient
{
    private readonly HttpClient _http;

    public QuestionAdminClient()
    {
        _http = new HttpClient
        {
            BaseAddress = new Uri("http://localhost:5151")
        };
    }

    public async Task<List<AdminQuestionDto>> GetQuestionsAsync(string testType)
    {
        return await _http.GetFromJsonAsync<List<AdminQuestionDto>>(
            $"/api/admin/questions?testType={testType}"
        ) ?? new();
    }

    public async Task<bool> AddQuestionAsync(AdminQuestionDto dto)
    {
        var res = await _http.PostAsJsonAsync("/api/admin/questions", dto);
        return res.IsSuccessStatusCode;
    }

    public async Task<bool> UpdateQuestionAsync(int id, AdminQuestionDto dto)
    {
        var res = await _http.PutAsJsonAsync($"/api/admin/questions/{id}", dto);
        return res.IsSuccessStatusCode;
    }

    public async Task<bool> DeleteQuestionAsync(int id)
    {
        var res = await _http.DeleteAsync($"/api/admin/questions/{id}");
        return res.IsSuccessStatusCode;
    }
}
