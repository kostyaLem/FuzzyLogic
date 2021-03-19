using DevExpress.Mvvm;
using FuzzyLogic.DAL.Models;
using FuzzyLogic.DAL.Services;
using FuzzyLogic.UI.Controls;
using System;
using System.Security;
using System.Threading.Tasks;
using System.Windows;
using IMessageBoxService = FuzzyLogic.UI.Services.Interfaces.IMessageBoxService;

namespace FuzzyLogic.UI.ViewModels
{
    internal sealed class AuthViewModel : BaseViewModel
    {
        private readonly IAuthService _authService;
        private readonly IMessageBoxService _messageBoxService;

        public WindowState WindowState { get; set; }
        public string Login { get; set; }
        public AccountType SelectedAccountType { get; set; }

        #region Commands

        public AsyncCommand<CustomPasswordBox> SignInCommand { get; set; }
        public AsyncCommand<Tuple<string, string>> RegistrationCommand { get; set; }

        public DelegateCommand SkipCommand { get; set; }
        public DelegateCommand ExitCommand { get; set; }

        #endregion

        public AuthViewModel(IAuthService authService, IMessageBoxService messageBoxService)
        {
            _authService = authService;
            _messageBoxService = messageBoxService;

            SignInCommand = new AsyncCommand<CustomPasswordBox>(SignIn);
            RegistrationCommand = new AsyncCommand<Tuple<string, string>>(Registration);

            SkipCommand = new DelegateCommand(Skip);
            ExitCommand = new DelegateCommand(Exit);
        }

        private async Task SignIn(CustomPasswordBox secureString)
        {
            try
            {
                var account = await _authService.TryLoginAsync(Login, secureString.Password, SelectedAccountType);
            }
            catch(Exception e)
            {
                _messageBoxService.ShowMessage(e.Message, Properties.Resources.NotificationTitle, MessageBoxImage.Warning);
            }
        }

        private async Task Registration(Tuple<string, string> passwords)
        {
            try
            {
                var account = await _authService.CreateAccount(Login, passwords.Item1, passwords.Item2, SelectedAccountType);
            }
            catch
            {

            }
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
