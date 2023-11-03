using FirmaMAUI.ViewModels.Base;

namespace FirmaMAUI.Pages.Formularios;

public partial class RUV2 : ContentPage
{
	public RUV2()
	{
		InitializeComponent();
	}

    protected override void OnAppearing()
    {
        ViewModelBase viewModel = BindingContext as ViewModelBase;
        _ = viewModel.InitializeAsync(null);
        base.OnAppearing();
    }

    private async void TapGestureRecognizer_Tapped(object sender, TappedEventArgs e)
    {
        await Navigation.PushAsync(new RUV6());
    }
}