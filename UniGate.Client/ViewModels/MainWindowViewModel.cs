using CommunityToolkit.Mvvm.ComponentModel;
using CommunityToolkit.Mvvm.Input;

namespace UniGate.Client.ViewModels;

public partial class MainWindowViewModel : ViewModelBase
{
    // Biến này chứa màn hình đang hiển thị (Kênh Tivi)
    [ObservableProperty]
    private ViewModelBase _currentPage;

    public MainWindowViewModel()
    {
        // Mặc định mở lên là vào trang Danh sách trường luôn
        CurrentPage = new UniversityListViewModel();
    }

    // Lệnh chuyển trang (để gắn vào nút bấm)
    [RelayCommand]
    public void GoToUniversityList()
    {
        CurrentPage = new UniversityListViewModel();
    }

    // Ví dụ sau này anh làm thêm HomeViewModel thì thêm hàm này
    // [RelayCommand]
    // public void GoToHome() => CurrentPage = new HomeViewModel();
}