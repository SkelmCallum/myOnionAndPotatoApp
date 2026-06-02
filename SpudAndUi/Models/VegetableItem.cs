using CommunityToolkit.Mvvm.ComponentModel;

namespace SpudAndUi.Models;

public enum VegetableType
{
    Potato,
    Onion
}

public partial class VegetableItem : ObservableObject
{
    public VegetableType Type { get; set; }

    [ObservableProperty]
    private int count;

    [ObservableProperty]
    private DateTime lastUpdated;
}
