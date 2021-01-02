using System.ComponentModel;
using System.Windows;
using System.Windows.Controls;
using System.Windows.Media;

namespace FuzzyLogic.UI.Controls
{
    public class BaseCustomBox : UserControl, INotifyPropertyChanged
    {
        public double HintTextSize
        {
            get { return (double)GetValue(HintTextSizeProperty); }
            set { SetValue(HintTextSizeProperty, value); }
        }
        public static readonly DependencyProperty HintTextSizeProperty =
            DependencyProperty.Register(nameof(HintTextSize), typeof(double), typeof(CustomTextBox), new PropertyMetadata(12d));


        public double TextFontSize
        {
            get { return (double)GetValue(TextFontSizeProperty); }
            set { SetValue(TextFontSizeProperty, value); }
        }
        public static readonly DependencyProperty TextFontSizeProperty =
            DependencyProperty.Register(nameof(TextFontSize), typeof(double), typeof(CustomTextBox), new PropertyMetadata(12d));

        public ImageSource Icon
        {
            get { return (ImageSource)GetValue(IconProperty); }
            set { SetValue(IconProperty, value); }
        }
        public static readonly DependencyProperty IconProperty =
            DependencyProperty.Register(nameof(Icon), typeof(ImageSource), typeof(CustomTextBox));

        public event PropertyChangedEventHandler PropertyChanged;
        public void RaisePropertyChanged(string prop = null)
        {
            PropertyChanged?.Invoke(this, new PropertyChangedEventArgs(prop));
        }
    }
}
