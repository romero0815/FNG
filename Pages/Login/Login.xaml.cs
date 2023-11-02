namespace FirmaMAUI.Pages.Login;

public partial class Login : ContentPage
{
    private int countTap = 0;
	public Login()
	{
		InitializeComponent();
        //this.user.Handler.PlatformView. (Android.Graphics.Color.Transparent);
    }

   

    private async void inicio_Clicked_1(object sender, EventArgs e)
    {
        await Navigation.PushAsync(new AppShell());
    }

    private void TapGestureRecognizer_Tapped(object sender, TappedEventArgs e)
    {
        if(countTap == 0)
        {
            Contraseña.IsPassword = false;
            countTap = 1;
            btn_pass.Source = "ojo.png";
        }
        else
        {
            Contraseña.IsPassword = true;
            countTap = 0;
            btn_pass.Source = "ojo_cerrado.png";
        }   

    }
}