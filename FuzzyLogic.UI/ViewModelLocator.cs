using Autofac;
using FuzzyLogic.DAL.Services.AccountService;
using FuzzyLogic.DAL.Services.AccountService.Validator;
using FuzzyLogic.DB.Context;
using FuzzyLogic.UI.Services;
using FuzzyLogic.UI.Services.Interfaces;
using FuzzyLogic.UI.ViewModels;
using Microsoft.EntityFrameworkCore;
using System;

namespace FuzzyLogic.UI
{
    internal static class ViewModelLocator
    {
        private static readonly IContainer _container;

        public static AuthViewModel AuthViewModel => _container.Resolve<AuthViewModel>();

        static ViewModelLocator()
        {
            var builder = new ContainerBuilder();

            builder.Register(_ =>
            {
                return new DbContextOptionsBuilder<FuzzyContext>()
                                .UseSqlite("DataSource=Database\\FuzzyLogicDB.db")
                                .Options;
            });
            builder.RegisterType<FuzzyContext>().AsSelf().SingleInstance();

            builder.RegisterType<MessageBoxService>().As<IMessageBoxService>();

            builder.RegisterType<AccountValidator>().As<IAccountValidator>();
            builder.RegisterType<AccountService>().AsImplementedInterfaces();

            builder.RegisterType<AuthViewModel>().AsSelf().SingleInstance();

            _container = builder.Build();
        }
    }
}
