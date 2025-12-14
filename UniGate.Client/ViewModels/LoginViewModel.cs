using System;
using CommunityToolkit.Mvvm.ComponentModel;
using CommunityToolkit.Mvvm.Input;
using System.Net.Http;
using System.Net.Http.Json; // Cần cái này để gửi JSON cho lẹ
using System.Threading.Tasks;
using System.Text.Json;
using System.Diagnostics;
using Avalonia.Controls;

namespace UniGate.Client.ViewModels;

public partial class LoginViewModel : ViewModelBase
{
    // 1. Khai báo "Chim đưa thư"
    private readonly HttpClient _httpClient;

    [ObservableProperty] private string _email = "";
    [ObservableProperty] private string _password = "";
    [ObservableProperty] private string _errorMessage = "";

    public LoginViewModel()
    {
        _httpClient = new HttpClient();
        // QUAN TRỌNG: Anh kiểm tra xem API anh đang chạy port nào? 
        // Thường là http://localhost:5151 hoặc http://localhost:5000
        _httpClient.BaseAddress = new Uri("http://localhost:5151/");
    }

    [RelayCommand]
    public async Task Login()
    {
        try
        {
            ErrorMessage = "Đang kết nối tới server...";

            // 1. Gói dữ liệu để gửi đi
            var loginData = new
            {
                email = Email,     // Phải khớp với API bên kia
                password = Password
            };

            // 2. Bắn tin hiệu POST tới API Login
            var response = await _httpClient.PostAsJsonAsync("api/User/login", loginData);

            // 3. Kiểm tra kết quả
            if (response.IsSuccessStatusCode)
            {
                // Đọc thông tin User trả về (nếu cần dùng sau này)
                var userContent = await response.Content.ReadAsStringAsync();
                Debug.WriteLine("Đăng nhập thành công: " + userContent);

                // 4. CHUYỂN TRANG (Về lại Dashboard)
                // Lưu ý: Đây là cách gọi tạm thời để truy cập vào MainViewModel từ con
                if (App.Current?.ApplicationLifetime is Avalonia.Controls.ApplicationLifetimes.IClassicDesktopStyleApplicationLifetime desktop)
                {
                    if (desktop.MainWindow?.DataContext is MainWindowViewModel mainVm)
                    {
                        mainVm.GoToHome(); // Gọi lệnh chuyển trang của thằng cha
                    }
                }
            }
            else
            {
                // Nếu thất bại (401 Unauthorized)
                ErrorMessage = "❌ Sai Email hoặc Mật khẩu rồi anh ơi!";
            }
        }
        catch (HttpRequestException)
        {
            ErrorMessage = "❌ Không kết nối được Server! (Anh đã chạy API chưa?)";
        }
        catch (Exception ex)
        {
            ErrorMessage = "❌ Lỗi lạ: " + ex.Message;
        }
    }
}