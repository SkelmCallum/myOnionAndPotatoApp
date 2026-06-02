using System.Windows.Input;
namespace SpudAndUi.Components;

public partial class PantryCard : ContentView
{
    // BindableProperty #1: The vegetable name (e.g., "Potato" or "Onion")
    public static readonly BindableProperty VegetableNameProperty =
        BindableProperty.Create(nameof(VegetableName), typeof(string), typeof(PantryCard), string.Empty);

    public string VegetableName
    {
        get => (string)GetValue(VegetableNameProperty);
        set => SetValue(VegetableNameProperty, value);
    }

    // BindableProperty #2: The emoji to display
    public static readonly BindableProperty EmojiProperty =
        BindableProperty.Create(nameof(Emoji), typeof(string), typeof(PantryCard), string.Empty);

    public string Emoji
    {
        get => (string)GetValue(EmojiProperty);
        set => SetValue(EmojiProperty, value);
    }

    // BindableProperty #3: The current count
    public static readonly BindableProperty CountProperty =
        BindableProperty.Create(nameof(Count), typeof(int), typeof(PantryCard), 0);

    public int Count
    {
        get => (int)GetValue(CountProperty);
        set => SetValue(CountProperty, value);
    }

    public static readonly BindableProperty IncreaseCommandProperty =
        BindableProperty.Create(nameof(IncreaseCommand), typeof(ICommand), typeof(PantryCard));

    public ICommand? IncreaseCommand
    {
        get => (ICommand?)GetValue(IncreaseCommandProperty);
        set => SetValue(IncreaseCommandProperty, value);
    }

    public static readonly BindableProperty DecreaseCommandProperty =
        BindableProperty.Create(nameof(DecreaseCommand), typeof(ICommand), typeof(PantryCard));

    public ICommand? DecreaseCommand
    {
        get => (ICommand?)GetValue(DecreaseCommandProperty);
        set => SetValue(DecreaseCommandProperty, value);
    }

    public PantryCard()
    {
        InitializeComponent();
    }
}