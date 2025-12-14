using CommunityToolkit.Mvvm.ComponentModel;
using System.Collections.ObjectModel;
using UniGate.Client.Services;
using UniGate.Core.Entities;

namespace UniGate.Client.ViewModels; // QUAN TRỌNG: Phải đúng cái này

public partial class UniversityListViewModel : ViewModelBase
{
    private readonly ApiService _apiService;
    public ObservableCollection<University> Universities { get; } = new();

    public UniversityListViewModel()
    {
        _apiService = new ApiService();
        LoadData();
    }

    private async void LoadData()
    {
        var list = await _apiService.GetUniversitiesAsync();
        Universities.Clear();
        foreach (var uni in list)
        {
            Universities.Add(uni);
        }
    }
}