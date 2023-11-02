using FirmaMAUI.ViewModels.Client;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace FirmaMAUI.ViewModels.Base
{
    public class ViewModelLocator
    {
        private static IServiceProvider _serviceProvider;
        private static IServiceCollection services;

        static ViewModelLocator()
        {
            services = new ServiceCollection();
            services.AddScoped<RuvViewModel>();
            services.AddScoped<AppShellViewModel>();
            _serviceProvider = services.BuildServiceProvider();
        }
        public RuvViewModel RuvViewModel
        {
            get => Resolve<RuvViewModel>();
        } 
        
        public AppShellViewModel AppShellViewModel
        {
            get => Resolve<AppShellViewModel>();
        }

        public static T Resolve<T>() where T : class
        {
            return _serviceProvider.GetRequiredService<T>();
        }
        public static void Register<T>(Func<T> function) where T : class
        {
            services.AddSingleton<T>((sp) => function());
            _serviceProvider = services.BuildServiceProvider();
        }
    }
}
