namespace SpudAndUi.Models;

public enum VegetableType
{
    Potato,
    Onion
}

public class VegetableItem
{
    public VegetableType Type { get; set; }
    public int Count { get; set; }
    public DateTime LastUpdated { get; set; }
}