using System.Windows;

namespace FuzzyLogic.UI.Views
{
    /// <summary>
    /// Interaction logic for AuthView.xaml
    /// </summary>
    public partial class AuthView : Window
    {
        public AuthView()
        {
            InitializeComponent();

        }

        private void Window_MouseDown(object sender, System.Windows.Input.MouseButtonEventArgs e)
        {
            DragMove();
        }
    }
}
