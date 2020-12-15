using System.Windows;
using System.Windows.Input;

namespace FuzzyLogic.UI.Views
{
    public partial class AuthView : Window
    {
        public AuthView()
        {
            InitializeComponent();
        }

        private void Window_MouseDown(object sender, MouseButtonEventArgs e)
        {
            if (e.LeftButton == MouseButtonState.Pressed)
                DragMove();
        }
    }
}
