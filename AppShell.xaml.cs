using FirmaMAUI.Pages.Formularios;
using FirmaMAUI.Pages.Login;

namespace FirmaMAUI
{
    public partial class AppShell : Shell
    {
        public AppShell()
        {
            InitializeComponent();
            
            Routing.RegisterRoute(nameof(InitialPage), typeof(InitialPage));
            Routing.RegisterRoute(nameof(Login), typeof(Login));
            Routing.RegisterRoute(nameof(MainPage), typeof(MainPage));
            Routing.RegisterRoute("Formularios/RUV", typeof(RUV));
            Routing.RegisterRoute("Formularios/RUV6", typeof(RUV6));
        }
        
        private  void MenuItem_Clicked(object sender, EventArgs e)
        {
            Application.Current.MainPage = new NavigationPage(new InitialPage());
        }
    }
}