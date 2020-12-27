using System.Windows;
using System.Windows.Controls;
using System.Windows.Input;

namespace FuzzyLogic.UI.Controls
{
    public partial class WindowControlButtons : UserControl
    {
        public ICommand SkipCommand { get; set; }
        public ICommand ExpandCommand { get; set; }
        public ICommand CloseCommand { get; set; }

        public bool ShowExpanderButton
        {
            get { return (bool)GetValue(ShowExpanderButtonProperty); }
            set { SetValue(ShowExpanderButtonProperty, value); }
        }

        public static readonly DependencyProperty ShowExpanderButtonProperty =
            DependencyProperty.Register(nameof(ShowExpanderButton), typeof(bool), typeof(WindowControlButtons), new PropertyMetadata(true));


        public bool ShowSkipButton
        {
            get { return (bool)GetValue(ShowSkipButtonProperty); }
            set { SetValue(ShowSkipButtonProperty, value); }
        }

        public static readonly DependencyProperty ShowSkipButtonProperty =
            DependencyProperty.Register(nameof(ShowSkipButton), typeof(bool), typeof(WindowControlButtons), new PropertyMetadata(true));


        public bool ShowCloseButton
        {
            get { return (bool)GetValue(ShowCloseButtonProperty); }
            set { SetValue(ShowCloseButtonProperty, value); }
        }

        public static readonly DependencyProperty ShowCloseButtonProperty =
            DependencyProperty.Register(nameof(ShowCloseButton), typeof(bool), typeof(WindowControlButtons), new PropertyMetadata(true));


        public WindowControlButtons()
        {
            InitializeComponent();
        }
    }
}
