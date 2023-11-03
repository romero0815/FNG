using FirmaMAUI.Pages.Controls;
using FirmaMAUI.ViewModels.Base;
using Newtonsoft.Json;
using Newtonsoft.Json.Linq;
using System.Text.Json.Serialization;

namespace FirmaMAUI.Pages.Formularios;

public partial class RUV : ContentPage
{
	public RUV()
	{
		InitializeComponent();

	}

    protected override void OnAppearing()
    {
        ViewModelBase viewModel = BindingContext as ViewModelBase;
        _ = viewModel.InitializeAsync(null);
        base.OnAppearing();
    }

    //private async void next_Clicked(object sender, EventArgs e)
    //{
    //    await Navigation.PushAsync(new RUV6());
    //}

    private async void TapGestureRecognizer_Tapped(object sender, TappedEventArgs e)
    {
        await Navigation.PushAsync(new RUV2());
    }
}