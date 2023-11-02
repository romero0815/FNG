using FirmaMAUI.Pages.Login;
using FirmaMAUI.Renders;

namespace FirmaMAUI
{
    public partial class App : Application
    {
        public App()
        {
            InitializeComponent();

            MainPage = new NavigationPage(new InitialPage());

            Microsoft.Maui.Handlers.EntryHandler.Mapper.AppendToMapping(nameof(MyEntry), (handler, view) =>
            {
#if __ANDROID__
                handler.PlatformView.SetBackgroundColor(Android.Graphics.Color.Transparent);
#elif __IOS__
                handler.PlatformView.BackgroundColor = UIKit.UIColor.Clear;
                handler.PlatformView.BorderStyle = UIKit.UITextBorderStyle.None;

#endif
            });
        }
    }
}