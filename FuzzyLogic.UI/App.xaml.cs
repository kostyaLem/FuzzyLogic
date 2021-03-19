using FuzzyLogic.UI.Views;
using System.Windows;

namespace FuzzyLogic.UI
{
    /// <summary>
    /// Interaction logic for App.xaml
    /// </summary>
    public partial class App : Application
    {
        public App()
        {
            System.Threading.Thread.CurrentThread.CurrentUICulture = new System.Globalization.CultureInfo("en");
        }

        protected override void OnStartup(StartupEventArgs e)
        {
            var view = new AuthView().ShowDialog();

            base.OnStartup(e);
        }
    }
}
