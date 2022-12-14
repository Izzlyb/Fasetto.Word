using Fasetto.Word.Core.IoC;
using System;

namespace Fasetto.Word
{
    /// <summary>
    /// Locates view models from the IoC container for use in binding in Xaml files:
    /// </summary>
    public class ViewModelLocator
    {
        #region Public Properties

        /// <summary>
        /// Singleton instance of the locator
        /// </summary>
        public static ViewModelLocator Instance { get; private set; } = new ViewModelLocator();

        /// <summary>
        /// The application view model
        /// </summary>
        public static ApplicationViewModel ApplicationViewModel => IoC.Get<ApplicationViewModel>();

        #endregion

    }
}
