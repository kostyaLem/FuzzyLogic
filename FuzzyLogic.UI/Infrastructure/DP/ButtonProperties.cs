using System.Windows;
using System.Windows.Media;

namespace FuzzyLogic.UI.Infrastructure.DP
{
    public class ButtonProperties
    {
        public static ImageSource GetImage(DependencyObject obj)
        {
            return (ImageSource)obj.GetValue(ImageProperty);
        }

        public static void SetImage(DependencyObject obj, ImageSource value)
        {
            obj.SetValue(ImageProperty, value);
        }

        public static readonly DependencyProperty ImageProperty =
            DependencyProperty.RegisterAttached("Image", typeof(ImageSource), typeof(ButtonProperties), new UIPropertyMetadata((ImageSource)null));
    }
}
