using System.Windows;

namespace FuzzyLogic.UI.Controls
{
    public partial class CustomPasswordBox : BaseCustomBox
    {
        public bool? HintDisplayed { get; private set; }

        public CustomPasswordBox()
        {
            InitializeComponent();

            HintDisplayed = true;
        }

        private void PasswordBox_LostFocus(object sender, RoutedEventArgs e)
        {
            if (PBox.SecurePassword.Length == 0)
            {
                HintDisplayed = true;
                RaisePropertyChanged(nameof(HintDisplayed));
            }
        }

        private void PasswordBox_GotFocus(object sender, RoutedEventArgs e)
        {
            HintDisplayed = null;
            RaisePropertyChanged(nameof(HintDisplayed));
        }
    }
}
