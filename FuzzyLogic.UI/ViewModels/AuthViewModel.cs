using DevExpress.Mvvm;
using FuzzyLogic.DAL.Models;
using FuzzyLogic.DAL.Services;
using FuzzyLogic.UI.Controls;
using System;
using System.Security;
using System.Windows;
using IMessageBoxService = FuzzyLogic.UI.Services.Interfaces.IMessageBoxService;

namespace FuzzyLogic.UI.ViewModels
{
    internal sealed class AuthViewModel : BaseViewModel
    {
        private readonly IAuthService _authService;
        private readonly IMessageBoxService MessageBoxService;

        public WindowState WindowState { get; set; }
        public string Login { get; set; }
        public AccountType SelectedAccountType { get; set; }

        #region Commands

        public DelegateCommand<CustomPasswordBox> SignInCommand { get; set; }
        public DelegateCommand<Tuple<SecureString, SecureString>> RegistrationCommand { get; set; }

        public DelegateCommand SkipCommand { get; set; }
        public DelegateCommand ExitCommand { get; set; }

        #endregion

        public AuthViewModel(IAuthService authService, IMessageBoxService mbService)
        {
            _authService = authService;
            MessageBoxService = mbService;

            SignInCommand = new DelegateCommand<CustomPasswordBox>(SignIn);
            RegistrationCommand = new DelegateCommand<Tuple<SecureString, SecureString>>(Registration);

            SkipCommand = new DelegateCommand(Skip);
            ExitCommand = new DelegateCommand(Exit);
        }

        private async void SignIn(CustomPasswordBox secureString)
        {
            var account = await _authService.TryLogin(Login, secureString.Password, SelectedAccountType);

            MessageBoxService.ShowMessage(Properties.Resources.CantAuthMessage, Properties.Resources.NotificationTitle, MessageBoxImage.Warning);
        }

        private void Registration(Tuple<SecureString, SecureString> passwords)
        {

        }

        private void Skip()
        {
            WindowState = WindowState.Minimized;
            RaisePropertyChanged(nameof(WindowState));
        }

        private void Exit()
        {
            Application.Current.Shutdown();
        }
    }
}
