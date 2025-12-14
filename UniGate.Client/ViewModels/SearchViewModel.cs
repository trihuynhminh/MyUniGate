using System;
using System.Collections.Generic;
using System.Threading.Tasks;
using System.Net.Http;
using System.Net.Http.Json;
using System.Collections.ObjectModel;
using CommunityToolkit.Mvvm.ComponentModel;
using CommunityToolkit.Mvvm.Input;
using UniGate.Client.Models;

namespace UniGate.Client.ViewModels;

public partial class SearchViewModel : ViewModelBase
{
    // 1. Thêm dấu ! (null-forgiving) để bảo compiler: "Yên tâm, tui khởi tạo trong Constructor rồi"
    private readonly HttpClient _httpClient = null!;

    // 2. Thêm dấu ? để chấp nhận biến này có thể null (vì TextBox có thể chưa nhập gì)
    [ObservableProperty]
    private string? _scoreInput;

    // 3. Khối thi thì mặc định là A00, nhưng cứ để ? cho an toàn
    [ObservableProperty]
    private string? _selectedGroup = "A00";

    [ObservableProperty]
    private string _statusMessage = "";

    public ObservableCollection<MajorDto> SearchResults { get; } = new();

    public List<string> SubjectGroups { get; } = new() { "A00", "A01", "B00", "C00", "D01" };

    public SearchViewModel()
    {
        _httpClient = new HttpClient { BaseAddress = new Uri("http://localhost:5151/") };
    }

    [RelayCommand]
    public async Task Search()
    {
        // Vì bên trên khai báo là string? (có thể null)
        // Nên ở đây dùng ?? "" (nếu null thì lấy rỗng) là HỢP LỆ và HẾT CẢNH BÁO
        if (!float.TryParse(ScoreInput ?? "", out float score))
        {
            StatusMessage = "❌ Vui lòng nhập điểm số hợp lệ!";
            return;
        }

        StatusMessage = "⏳ Đang tìm kiếm...";
        SearchResults.Clear();

        try
        {
            var request = new { score = score, group = SelectedGroup ?? "A00" };

            var response = await _httpClient.PostAsJsonAsync("api/Major/filter", request);

            if (response.IsSuccessStatusCode)
            {
                // ReadFromJsonAsync trả về List? (có thể null)
                // Dùng ?? new() để đảm bảo biến list không bao giờ null
                var list = await response.Content.ReadFromJsonAsync<List<MajorDto>>() ?? new List<MajorDto>();

                if (list.Count > 0)
                {
                    foreach (var item in list) SearchResults.Add(item);
                    StatusMessage = $"✅ Tìm thấy {list.Count} ngành phù hợp!";
                }
                else
                {
                    StatusMessage = "⚠️ Không tìm thấy ngành nào phù hợp.";
                }
            }
            else
            {
                StatusMessage = "⚠️ Lỗi từ máy chủ (Server Error).";
            }
        }
        catch (Exception ex)
        {
            StatusMessage = "❌ Lỗi kết nối: " + ex.Message;
        }
    }
}