using CommunityToolkit.Mvvm.ComponentModel;
using CommunityToolkit.Mvvm.Input;
using System;
using System.Collections.ObjectModel;
using UniGate.Client.Services;
using UniGate.Core.Entities;

namespace UniGate.Client.ViewModels;

public partial class HomeViewModel : ViewModelBase
{
    // 1. Biến hiển thị Lời chào (Thay đổi theo giờ)
    [ObservableProperty]
    private string _greeting;

    // 2. Biến hiển thị Ngày tháng năm
    [ObservableProperty]
    private string _currentDate;

    // 3. Mấy cái số liệu thống kê (Tạm thời gán cứng để demo giao diện Dashboard)
    [ObservableProperty]
    private int _totalUniversities = 15; // Ví dụ: Đã có 15 trường trong CSDL

    [ObservableProperty]
    private int _totalUsers = 120; // Ví dụ: 120 sinh viên tham gia

    public HomeViewModel()
    {
        // Lấy ngày hiện tại
        CurrentDate = "Hôm nay, " + DateTime.Now.ToString("dd/MM/yyyy");

        // Logic hiển thị lời chào thông minh
        var hour = DateTime.Now.Hour;
        if (hour < 12)
            Greeting = "Chào buổi sáng, anh Trí! ☀️";
        else if (hour < 18)
            Greeting = "Chào buổi chiều, anh Trí! ⛅";
        else
            Greeting = "Chào buổi tối, anh Trí! 🌙";
    }

    // Sau này có thể thêm nút "Làm mới dữ liệu" ở đây
    [RelayCommand]
    public void RefreshData()
    {
        // Code gọi API thống kê sẽ nằm ở đây
        Greeting = "Dữ liệu đã được cập nhật!";
    }
}