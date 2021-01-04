using System.Windows;

namespace FuzzyLogic.UI.Services.Interfaces
{
    public interface IMessageBoxService
    {
        public void ShowMessage(string message, string title, MessageBoxImage image);

        public bool ShowDialogMessage(string message, string title, MessageBoxImage image);
    }
}
