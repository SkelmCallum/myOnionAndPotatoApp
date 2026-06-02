using CommunityToolkit.Mvvm.ComponentModel;
using CommunityToolkit.Mvvm.Input;
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


    [RelayCommand]
    private void IncreasePotato()
    {
        Potato.Count++;
        Potato.LastUpdated = DateTime.Now;
    }

    [RelayCommand]
    private void DecreasePotato()
    {
        if (Potato.Count > 0)
        {
            Potato.Count--;
            Potato.LastUpdated = DateTime.Now;
        }
    }

    [RelayCommand]
    private void IncreaseOnion()
    {
        Onion.Count++;
        Onion.LastUpdated = DateTime.Now;
    }

    [RelayCommand]
    private void DecreaseOnion()
    {
        if (Onion.Count > 0)
        {
            Onion.Count--;
            Onion.LastUpdated = DateTime.Now;
        }
    }

}