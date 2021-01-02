using DevExpress.Mvvm;
using System.Windows;

namespace FuzzyLogic.UI.ViewModels
{
    internal sealed class AuthViewModel : BaseViewModel
    {
        public WindowState WindowState { get; set; }

        public DelegateCommand SkipCommand { get; set; }
        public DelegateCommand ExitCommand { get; set; }

        public AuthViewModel()
        {
            SkipCommand = new DelegateCommand(Skip);
            ExitCommand = new DelegateCommand(Exit);
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
