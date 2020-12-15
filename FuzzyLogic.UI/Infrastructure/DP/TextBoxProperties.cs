﻿using System.Windows;
using System.Windows.Media;

namespace FuzzyLogic.UI.Infrastructure.DP
{
    public class TextBoxProperties
    {
        public static ImageSource GetIcon(DependencyObject obj)
        {
            return (ImageSource)obj.GetValue(IconProperty);
        }

        public static void SetIcon(DependencyObject obj, ImageSource value)
        {
            obj.SetValue(IconProperty, value);
        }

        public static readonly DependencyProperty IconProperty =
            DependencyProperty.RegisterAttached("Icon", typeof(ImageSource), typeof(TextBoxProperties), new UIPropertyMetadata((ImageSource)null));
    }
}
