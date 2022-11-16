using System.Threading.Tasks;
using System.Windows.Media.Animation;
using System.Windows.Controls;
using System.Windows;

namespace Fasetto.Word
{

    /// <summary>
    /// Helpers to animate pages in specific ways. Any type of pages.
    /// PageAnimations objects can work with any page animation even if its not a BasePage
    /// storyboard helpers can work only on storyboards. add effects to any storyboard.
    /// </summary>
    public static class PageAnimations
    {

        /// <summary>
        /// Slides the page from the right
        /// </summary>
        /// <param name="page"> the page to animate </param>
        /// <param name="seconds"> the time the animation will take </param>
        /// <returns></returns>

        public static async Task SlideAndFadeInFromRight( this Page page, float seconds )
        {
            // create the storyboard
            var sb = new Storyboard();

            // add slide from right animation: 
            sb.AddSlideFromRight(seconds, page.WindowWidth);

            // add fade in animation: 
            sb.AddFadeIn(seconds);

            // start the animation
            sb.Begin(page);

            // make page visible
            page.Visibility = Visibility.Visible;

            // Wait for it to finish:
            await Task.Delay((int)(seconds * 1000));

        }


        /// <summary>
        /// Slides and fade out to the left 
        /// </summary>
        /// <param name="page"> the page to animate </param>
        /// <param name="seconds"> the time the animation will take </param>
        /// <returns></returns>
        public static async Task SlideAndFadeOutToLeft(this Page page, float seconds)
        {
            // create the storyboard
            var sb = new Storyboard();

            // add slide from right animation: 
            sb.AddSlideToLeft(seconds, page.WindowWidth);

            // add fade in animation: 
            sb.AddFadeOut(seconds);

            // start the animation
            sb.Begin(page);

            // make page visible
            page.Visibility = Visibility.Visible;

            // Wait for it to finish:
            await Task.Delay((int)(seconds * 1000));

        }

    }
}



