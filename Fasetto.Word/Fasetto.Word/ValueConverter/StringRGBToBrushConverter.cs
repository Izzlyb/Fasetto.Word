using System;
using System.Globalization;
using System.Windows.Media;

namespace Fasetto.Word
{

    /// <summary>
    /// Converter that takes a RGB string to a hex code for color of the WPF brush:
    /// </summary>
    public class StringRGBToBrushConverter : BaseValueConverter<StringRGBToBrushConverter>
    {
        public override object Convert(object value, Type targetType, object parameter, CultureInfo culture)
        {
            return (SolidColorBrush) new BrushConverter().ConvertFrom($"#{value}");
        }

        public override object ConvertBack(object value, Type targetType, object parameter, CultureInfo culture)
        {
            throw new NotImplementedException();
        }
    }
}
