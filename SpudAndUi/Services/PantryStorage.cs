using Microsoft.Maui.Storage;

namespace SpudAndUi.Services;

public static class PantryStorage
{
    private const string PotatoCountKey = "potato_count";
    private const string OnionCountKey = "onion_count";

    public static void Save(int potatoCount, int onionCount)
    {
        Preferences.Set(PotatoCountKey, potatoCount);
        Preferences.Set(OnionCountKey, onionCount);
    }

    public static (int PotatoCount, int OnionCount) Load()
    {
        int potato = Preferences.Get(PotatoCountKey, 0);
        int onion = Preferences.Get(OnionCountKey, 0);
        return (potato, onion);
    }
}