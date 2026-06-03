using CommunityToolkit.Mvvm.ComponentModel;
using CommunityToolkit.Mvvm.Input;
using SpudAndUi.Models;
using SpudAndUi.Services;

namespace SpudAndUi.ViewModels;

public partial class HomeViewModel : ObservableObject
{
    [ObservableProperty]
    private VegetableItem potato = null!;

    [ObservableProperty]
    private VegetableItem onion = null!;

    public HomeViewModel()
    {
        var (potatoCount, onionCount) = PantryStorage.Load();
        Potato = new VegetableItem
        {
            Type = VegetableType.Potato,
            Count = potatoCount,
            LastUpdated = DateTime.Now
        };
        Onion = new VegetableItem
        {
            Type = VegetableType.Onion,
            Count = onionCount,
            LastUpdated = DateTime.Now
        };
        
    }

    [RelayCommand]
    private void IncreasePotato()
    {
        Potato!.Count++;
        Potato.LastUpdated = DateTime.Now;
        SavePantry();
    }

    [RelayCommand]
    private void DecreasePotato()
    {
        if (Potato!.Count > 0)
        {

            Potato.Count--;
            Potato.LastUpdated = DateTime.Now;
            SavePantry();
        }
        
    }

    [RelayCommand]
    private void IncreaseOnion()
    {
        Onion!.Count++;
        Onion.LastUpdated = DateTime.Now;
        SavePantry();
    }

    [RelayCommand]
    private void DecreaseOnion()
    {
        if (Onion!.Count > 0)
        {
            Onion.Count--;
            Onion.LastUpdated = DateTime.Now;
            SavePantry();
        }
        
    }


    private void SavePantry()
    {
        PantryStorage.Save(Potato!.Count, Onion!.Count);
    }



}