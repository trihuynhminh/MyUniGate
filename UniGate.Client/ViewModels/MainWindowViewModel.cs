using CommunityToolkit.Mvvm.ComponentModel;
using CommunityToolkit.Mvvm.Input;
using UniGate.Client.ViewModels;

namespace UniGate.Client.ViewModels;

public partial class MainWindowViewModel : ViewModelBase
{
    // Biến này chứa màn hình đang hiển thị (Kênh Tivi)
    [ObservableProperty]
    private ViewModelBase _currentPage;

    [ObservableProperty]
    private bool _isSidebarVisible = true;

    public MainWindowViewModel()
    {
        CurrentPage = new LoginViewModel();
        IsSidebarVisible = true;
    }

    // Lệnh chuyển trang (để gắn vào nút bấm)
    [RelayCommand]
    public void GoToUniversityList()
    {
        IsSidebarVisible = true;
        CurrentPage = new UniversityListViewModel();
    }

    // Ví dụ sau này anh làm thêm HomeViewModel thì thêm hàm này
    [RelayCommand]
    public void GoToHome()
    {
        IsSidebarVisible = true;
        CurrentPage = new HomeViewModel();
    }

    [RelayCommand]
    public void GoToLogin()
    {
        IsSidebarVisible = true;
        CurrentPage = new LoginViewModel();
    }

}