using SpudAndUi.Views;
namespace SpudAndUi;

public partial class AppShell : Shell
{
    public AppShell()
    {
        InitializeComponent();

        if (CurrentItem == null && Items.Count > 0)
            CurrentItem = Items[0];
    }
}