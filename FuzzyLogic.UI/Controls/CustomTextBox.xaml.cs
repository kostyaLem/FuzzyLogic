using System.Windows;

namespace FuzzyLogic.UI.Controls
{
    public partial class CustomTextBox : BaseCustomBox
    {
        public string Text
        {
            get { return (string)GetValue(TextProperty); }
            set { SetValue(TextProperty, value); }
        }
        public static readonly DependencyProperty TextProperty =
            DependencyProperty.Register(nameof(Text), typeof(string), typeof(CustomTextBox));

        public CustomTextBox()
        {
            InitializeComponent();
        }
    }
}
