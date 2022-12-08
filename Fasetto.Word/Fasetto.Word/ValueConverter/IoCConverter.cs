using Fasetto.Word.Core;
using Fasetto.Word.Core.IoC;
using System;
using System.Globalization;

namespace Fasetto.Word
{
    /// <summary>
    /// Converts a string name to a service pulled from the IoC container:
    /// </summary>
    public class IoCConverter : BaseValueConverter<IoCConverter>
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
            switch ((string)parameter)
            {
                case nameof(ApplicationViewModel):
                    return IoC.Get<ApplicationViewModel>();

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
