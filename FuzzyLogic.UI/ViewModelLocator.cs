using FuzzyLogic.DAL.Services;
using FuzzyLogic.DAL.Services.AccountService;
using FuzzyLogic.DB.Context;
using FuzzyLogic.UI.Services;
using FuzzyLogic.UI.Services.Interfaces;
using FuzzyLogic.UI.ViewModels;
using Microsoft.EntityFrameworkCore;
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

            services.AddDbContext<FuzzyContext>(new Action<DbContextOptionsBuilder>(x => x.UseSqlite("DataSource=Database\\FuzzyLogicDB.db")), ServiceLifetime.Transient);

            services.AddSingleton<AccountService>();
            services.AddSingleton<IAccountService>(x => x.GetRequiredService<AccountService>());
            services.AddSingleton<IAuthService>(x => x.GetRequiredService<AccountService>());

            services.AddSingleton<IMessageBoxService, MessageBoxService>();

            services.AddSingleton<AuthViewModel>();


            _provider = services.BuildServiceProvider();
        }
    }
}
