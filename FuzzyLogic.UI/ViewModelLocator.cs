using FuzzyLogic.UI.ViewModels;
using Microsoft.Extensions.DependencyInjection;
using System;
using System.Collections.Generic;
using System.Text;

namespace FuzzyLogic.UI
{
    public class ViewModelLocator
    {
        private static IServiceProvider _provider;

        public static void Init()
        {
            var services = new ServiceCollection();

            services.AddSingleton<AuthViewModel>();
        }

    }
}
