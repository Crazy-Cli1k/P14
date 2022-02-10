using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace P14.Converters
{
    using System.Globalization;
    using System.Windows.Data;
    using System.Windows;
    class DiscountToStrikelineConverter : IValueConverter
    {
        public object Convert(object value, Type targetType, object parameter, CultureInfo culture)
        {
            bool HasDiscount = (bool)value;
            if (HasDiscount)
            {
                return TextDecorations.Strikethrough;
            }
            else
            {
                return new TextDecoration();
            }
        }

        public object ConvertBack(object value, Type targetType, object parameter, CultureInfo culture)
        {
            var decoration = value as TextDecoration;
            if (decoration != null)
            {
                return decoration.Location == TextDecorationLocation.Strikethrough;
            }
            else
            {
                return new ArgumentException();
            }
        }
    }
}
