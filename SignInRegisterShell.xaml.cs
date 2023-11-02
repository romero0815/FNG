using FirmaMAUI.Pages.Formularios;
using FirmaMAUI.Pages.Login;

namespace FirmaMAUI;

public partial class SignInRegisterShell : Shell
{
	public SignInRegisterShell()
	{
		InitializeComponent();
        RegisterRoutes();

    }

    private void RegisterRoutes()
    {
        Routing.RegisterRoute(nameof(MainPage), typeof(MainPage));
        Routing.RegisterRoute(nameof(Login), typeof(Login));
        Routing.RegisterRoute(nameof(InitialPage), typeof(InitialPage));
        Routing.RegisterRoute("Formularios/RUV", typeof(RUV));
    }
}