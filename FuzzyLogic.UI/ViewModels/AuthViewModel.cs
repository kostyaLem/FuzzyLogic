using DevExpress.Mvvm;
using System;
using System.Security;
using System.Windows;
using IMessageBoxService = FuzzyLogic.UI.Services.Interfaces.IMessageBoxService;

namespace FuzzyLogic.UI.ViewModels
{
    internal sealed class AuthViewModel : BaseViewModel
    {
        private IMessageBoxService MessageBoxService;

        public WindowState WindowState { get; set; }

        public DelegateCommand<SecureString> SignInCommand { get; set; }
        public DelegateCommand<Tuple<SecureString, SecureString>> RegistrationCommand { get; set; }

        public DelegateCommand SkipCommand { get; set; }
        public DelegateCommand ExitCommand { get; set; }

        public AuthViewModel(IMessageBoxService mbService)
        {
            MessageBoxService = mbService;

            SignInCommand = new DelegateCommand<SecureString>(SignIn);
            RegistrationCommand = new DelegateCommand<Tuple<SecureString, SecureString>>(Registration);

            SkipCommand = new DelegateCommand(Skip);
            ExitCommand = new DelegateCommand(Exit);
        }

        private void SignIn(SecureString secureString)
        {

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
