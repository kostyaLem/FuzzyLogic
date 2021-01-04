using FuzzyLogic.UI.Controls;
using System;
using System.Globalization;
using System.Linq;
using System.Windows.Data;
using System.Windows.Markup;

namespace FuzzyLogic.UI.Infrastructure.Converters
{
    public class PasswordBoxToPasswordConverter : MarkupExtension, IValueConverter
    {
        public object Convert(object value, Type targetType, object parameter, CultureInfo culture)
        {
            if (value is CustomPasswordBox box)
            {
                return box.PBox.SecurePassword;
            }

            return Binding.DoNothing;
        }

        public object ConvertBack(object value, Type targetType, object parameter, CultureInfo culture)
        {
            throw new NotImplementedException();
        }

        public override object ProvideValue(IServiceProvider serviceProvider) => this;
    }

    public class PasswordBoxToPasswordsConverter : MarkupExtension, IMultiValueConverter
    {
        public object Convert(object[] values, Type targetType, object parameter, CultureInfo culture)
        {
            if (values.All(x => x is CustomPasswordBox))
            {
                return Tuple.Create((values[0] as CustomPasswordBox).PBox.SecurePassword, (values[1] as CustomPasswordBox).PBox.SecurePassword);
            }

            return Binding.DoNothing;
        }

        public object[] ConvertBack(object value, Type[] targetTypes, object parameter, CultureInfo culture)
        {
            throw new NotImplementedException();
        }

        public override object ProvideValue(IServiceProvider serviceProvider) => this;
    }
}
