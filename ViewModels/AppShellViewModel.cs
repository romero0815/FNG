using FirmaMAUI.ViewModels.Base;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Input;

namespace FirmaMAUI.ViewModels
{
    public class AppShellViewModel : ViewModelBase
    {
        public AppShellViewModel() { }

        public ICommand GoToRuvCommand
        {
            get => new Command(() => NavigateTo("Formularios/RUV", null));
        }

        private void NavigateTo(string route, string messagingKey)
        {
            Shell.Current.FlyoutIsPresented = false;
            Shell.Current.GoToAsync(route);
        }
    }
}
