using System;
using System.Threading.Tasks;
using System.Windows;
using System.Windows.Controls;
using Fasetto.Word.Core;

namespace Fasetto.Word
{
    /// <summary>
    /// A base page for all pages to gain base uniform functionality
    /// </summary>
    public class BasePage<VM> : Page
        where VM : BaseViewModel, new()
    {
        #region Private Members

        /// <summary>
        /// The view model associated with this page:
        /// </summary>
        private VM mViewModel;

        #endregion


        #region Public Properties 
        /// <summary>
        /// the animation play when the page is loaded/created:
        /// </summary>
        public PageAnimation PageLoadAnimation { get; set; } = PageAnimation.SlideAndFadeInFromRight;

        /// <summary>
        /// the animation pla when the page is being unloaded/closed:
        /// </summary>
        public PageAnimation PageUnloadAnimation { get; set; } = PageAnimation.SlideAndFadeOutToLeft;

        /// <summary>
        /// The time an animation takes to complete:
        /// </summary>
        public float SlideSeconds { get; set; } = 0.8f;

        /// <summary>
        /// This is the view model associated with this page:
        /// </summary>
        public VM ViewModel
        {
            get => mViewModel;
            set
            {
                if(mViewModel == value)
                {
                    return;
                }

                mViewModel = value;

                DataContext = mViewModel;
            }
        }

        #endregion


        #region Constructors

        public BasePage()
        {
            // if we are animating in, hide to begin with 
            if(PageLoadAnimation != PageAnimation.None)
            {
                Visibility = Visibility.Collapsed;
            }

            // Listen out for the page loading
            Loaded += BasePage_LoadedAsync;

            // Create a default view model:
            ViewModel = new VM();
        }

        #endregion


        #region Animation Load/Unload page

        /// <summary>
        /// Once the page is loaded, perform any required animation:
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        /// <exception cref="NotImplementedException"></exception>
        private async void BasePage_LoadedAsync(object sender, RoutedEventArgs e)
        {
            // Animate page in/loading a new page:
            await AnimateInAsync();
        }


        /// <summary>
        /// Animates the page coming into the screen from the right
        /// </summary>
        /// <returns></returns>
        public async Task AnimateInAsync()
        {
            // Make sure we have something to do/animate:
            if(PageLoadAnimation == PageAnimation.None)
            {
                return;
            }

            switch (PageLoadAnimation)
            {
                case PageAnimation.None:
                    break;

                case PageAnimation.SlideAndFadeInFromRight:

                    // Start the animation:
                    await this.SlideAndFadeInFromRightAsync(SlideSeconds);

                    break;

                case PageAnimation.SlideAndFadeOutToLeft:
                    break;
            }

        }


        /// <summary>
        /// Animates the page going out of the screen
        /// fading it out to the left 
        /// </summary>
        /// <returns></returns>
        public async Task AnimateOutAsync()
        {
            // Make sure we have something to do/animate:
            if (PageUnloadAnimation == PageAnimation.None)
            {
                return;
            }

            switch (PageUnloadAnimation)
            {
                case PageAnimation.None:
                    break;

                case PageAnimation.SlideAndFadeInFromRight:

                    break;

                case PageAnimation.SlideAndFadeOutToLeft:

                    // Start the animation:
                    await this.SlideAndFadeOutToLeftAsync(SlideSeconds * 2);

                    break;
            }

        }
        #endregion
    }
}
