using System;
using System.Globalization;

namespace Fasetto.Word
{
    public class ApplicationPageValueConverter : BaseValueConverter<ApplicationPageValueConverter>
    {
        /// <summary>
        /// Converts the <see cref="ApplicationPage"/> the enum to an actual view/page instance.
        /// </summary>
        /// <param name="value"></param>
        /// <param name="targetType"></param>
        /// <param name="parameter"></param>
        /// <param name="culture"></param>
        /// <returns></returns>
        /// <exception cref="NotImplementedException"></exception>
        public override object Convert(object value, Type targetType, object parameter, CultureInfo culture)
        {
            /// Finds the appropriate page:
            switch ((ApplicationPage) value)
            {
                case ApplicationPage.Login:
                    return new LoginPage();

                default:
                    return null;
            }
        }

        public override object ConvertBack(object value, Type targetType, object parameter, CultureInfo culture)
        {
            throw new NotImplementedException();
        }
    }
}
