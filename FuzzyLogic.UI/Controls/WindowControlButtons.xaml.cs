using System.Windows;
using System.Windows.Controls;
using System.Windows.Input;

namespace FuzzyLogic.UI.Controls
{
    public partial class WindowControlButtons : UserControl
    {
        #region Commands

        public ICommand SkipCommand
        {
            get { return (ICommand)GetValue(SkipCommandProperty); }
            set { SetValue(SkipCommandProperty, value); }
        }
        public static readonly DependencyProperty SkipCommandProperty =
            DependencyProperty.Register(nameof(SkipCommand), typeof(ICommand), typeof(WindowControlButtons));


        public ICommand ExpandCommand
        {
            get { return (ICommand)GetValue(ExpandCommandProperty); }
            set { SetValue(ExpandCommandProperty, value); }
        }
        public static readonly DependencyProperty ExpandCommandProperty =
            DependencyProperty.Register(nameof(ExpandCommand), typeof(ICommand), typeof(WindowControlButtons));


        public ICommand CloseCommand
        {
            get { return (ICommand)GetValue(CloseCommandProperty); }
            set { SetValue(CloseCommandProperty, value); }
        }
        public static readonly DependencyProperty CloseCommandProperty =
            DependencyProperty.Register(nameof(CloseCommand), typeof(ICommand), typeof(WindowControlButtons));

        #endregion

        #region Properties

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

        #endregion

        public WindowControlButtons()
        {
            InitializeComponent();
        }
    }
}
