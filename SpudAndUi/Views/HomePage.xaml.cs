using SpudAndUi.ViewModels;

namespace SpudAndUi.Views;

public partial class HomePage : ContentPage
{
    public HomePage()
    {
        InitializeComponent();
    }

    protected override void OnHandlerChanged()
    {
        base.OnHandlerChanged();

        if (BindingContext != null || Handler?.MauiContext?.Services == null)
            return;

        BindingContext = Handler.MauiContext.Services.GetRequiredService<HomeViewModel>();
    }
}