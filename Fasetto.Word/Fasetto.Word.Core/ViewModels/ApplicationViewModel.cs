using System;
using Fasetto.Word.Core;

namespace Fasetto.Word
{
    /// <summary>
    /// Application State as a view model
    /// </summary>
    public class ApplicationViewModel : BaseViewModel
    {

        /// <summary>
        /// The current application page, the page with the focus. 
        /// </summary>
        public ApplicationPage CurrentPage { get; set; } = ApplicationPage.Login;



        /// <summary>
        /// True if the side menu should be shown
        /// </summary>
        public bool SideMenuVisible { get; set; } = false;

    }
}
