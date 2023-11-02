namespace FirmaMAUI.Pages.Login;

public partial class InitialPage : ContentPage
{
	public InitialPage()
	{
		InitializeComponent();
        Routing.RegisterRoute(nameof(Login), typeof(Login));
    }

    private async void Button_Clicked(object sender, EventArgs e)
    {
        await Navigation.PushAsync(new Login());
    }

}

