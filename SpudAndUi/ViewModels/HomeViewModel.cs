using CommunityToolkit.Mvvm.ComponentModel;
using SpudAndUi.Models;

namespace SpudAndUi.ViewModels;

public partial class HomeViewModel : ObservableObject
{
    [ObservableProperty]
    private VegetableItem potato = new() 
    { 
        Type = VegetableType.Potato, Count = 0, LastUpdated = DateTime.Now 
    };

    [ObservableProperty]
    private VegetableItem onion = new() 
    { 
        Type = VegetableType.Onion, Count = 0, LastUpdated = DateTime.Now 
    };
}