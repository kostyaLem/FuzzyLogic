using FuzzyLogic.UI.Services.Interfaces;
using System.Windows;

namespace FuzzyLogic.UI.Services
{
    public class MessageBoxService : IMessageBoxService
    {
        public bool ShowDialogMessage(string message, string title, MessageBoxImage image)
        {
            switch(MessageBox.Show(message, title, MessageBoxButton.YesNoCancel, image))
            {
                case MessageBoxResult.OK: return true;
                default: return false;
            }
        }

        public void ShowMessage(string message, string title, MessageBoxImage image)
        {
            MessageBox.Show(message, title, MessageBoxButton.OK, image);
        }
    }
}
