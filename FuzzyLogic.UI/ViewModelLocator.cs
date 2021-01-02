using FuzzyLogic.UI.ViewModels;
using Microsoft.Extensions.DependencyInjection;
using System;

namespace FuzzyLogic.UI
{
    internal static class ViewModelLocator
    {
        private static IServiceProvider _provider;

        public static AuthViewModel AuthViewModel => _provider.GetRequiredService<AuthViewModel>();

        static ViewModelLocator()
        {
            var services = new ServiceCollection();

            services.AddSingleton<AuthViewModel>();

            _provider = services.BuildServiceProvider();
        }
    }
}
