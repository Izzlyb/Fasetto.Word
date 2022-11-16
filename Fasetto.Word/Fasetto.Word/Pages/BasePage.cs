using System;
using System.Threading.Tasks;
using System.Windows;
using System.Windows.Controls;

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
            get
            {
                return mViewModel;
            }
            set
            {
                if(mViewModel == value)
                {
                    return;
                }

                mViewModel = value;

                this.DataContext = mViewModel;
            }
        }

        #endregion


        #region Constructors

        public BasePage()
        {
            // if we are animating in, hide to begin with 
            if(this.PageLoadAnimation != PageAnimation.None)
            {
                this.Visibility = Visibility.Collapsed;
            }

            // Listen out for the page loading
            this.Loaded += BasePage_Loaded;

            // Create a default view model:
            this.ViewModel = new VM();
        }

        #endregion


        #region Animation Load/Unload page

        /// <summary>
        /// Once the page is loaded, perform any required animation:
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        /// <exception cref="NotImplementedException"></exception>
        private async void BasePage_Loaded(object sender, RoutedEventArgs e)
        {
            // Animate page in/loading a new page:
            await AnimateIn();
        }


        /// <summary>
        /// Animates the page coming into the screen from the right
        /// </summary>
        /// <returns></returns>
        public async Task AnimateIn()
        {
            // Make sure we have something to do/animate:
            if(this.PageLoadAnimation == PageAnimation.None)
            {
                return;
            }

            switch (this.PageLoadAnimation)
            {
                case PageAnimation.None:
                    break;

                case PageAnimation.SlideAndFadeInFromRight:

                    // Start the animation:
                    await this.SlideAndFadeInFromRight(this.SlideSeconds);

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
        public async Task AnimateOut()
        {
            // Make sure we have something to do/animate:
            if (this.PageUnloadAnimation == PageAnimation.None)
            {
                return;
            }

            switch (this.PageUnloadAnimation)
            {
                case PageAnimation.None:
                    break;

                case PageAnimation.SlideAndFadeInFromRight:

                    break;

                case PageAnimation.SlideAndFadeOutToLeft:

                    // Start the animation:
                    await this.SlideAndFadeOutToLeft(this.SlideSeconds * 5);

                    break;
            }

        }


        #endregion

        #region Animation Helpers




        #endregion

    }
}
