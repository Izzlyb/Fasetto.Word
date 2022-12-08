using System.Threading.Tasks;
using System.Windows.Media.Animation;
using System.Windows.Controls;
using System.Windows;

namespace Fasetto.Word
{

    /// <summary>
    /// Helpers to animate framework elements in specific ways
    /// </summary>
    public static class FrameworkElementAnimations
    {

        /// <summary>
        /// Slides the element from the right
        /// </summary>
        /// <param name="element"> the element to animate </param>
        /// <param name="seconds"> the time the animation will take </param>
        /// <param name="keepMargin">Wheter to keep the element at the same width during animation</param>
        /// <returns></returns>
        public static async Task SlideAndFadeInFromRightAsync( this FrameworkElement element, float seconds = 0.3f , bool keepMargin = true)
        {
            // create the storyboard
            var sb = new Storyboard();

            // add slide from right animation: 
            sb.AddSlideFromRight(seconds, element.ActualWidth, keepMargin: keepMargin);

            // add fade in animation: 
            sb.AddFadeIn(seconds);

            // start the animation
            sb.Begin(element);

            // make element visible
            element.Visibility = Visibility.Visible;

            // Wait for it to finish:
            await Task.Delay((int)(seconds * 100));

        }


        /// <summary>
        /// Slides the element from the left
        /// </summary>
        /// <param name="element"> the element to animate </param>
        /// <param name="seconds"> the time the animation will take </param>
        /// <param name="keepMargin">Wheter to keep the element at the same width during animation</param>
        /// <returns></returns>
        public static async Task SlideAndFadeInFromLeftAsync(this FrameworkElement element, float seconds = 0.3f, bool keepMargin = true)
        {
            // create the storyboard
            var sb = new Storyboard();

            // add slide from right animation: 
            sb.AddSlideFromLeft(seconds, element.ActualWidth, keepMargin: keepMargin);

            // add fade in animation: 
            sb.AddFadeIn(seconds);

            // start the animation
            sb.Begin(element);

            // make element visible
            element.Visibility = Visibility.Visible;

            // Wait for it to finish:
            await Task.Delay((int)(seconds * 100));

        }




        /// <summary>
        /// Slides and fade out to the left 
        /// </summary>
        /// <param name="element"> the element to animate </param>
        /// <param name="seconds"> the time the animation will take </param>
        /// <param name="keepMargin">Wheter to keep the element at the same width during animation</param>
        /// <returns></returns>
        public static async Task SlideAndFadeOutToLeftAsync(this FrameworkElement element, float seconds = 0.3f, bool keepMargin = true)
        {
            // create the storyboard
            var sb = new Storyboard();

            // add slide from right animation: 
            sb.AddSlideToLeft(seconds, element.ActualWidth, keepMargin: keepMargin);

            // add fade in animation: 
            sb.AddFadeOut(seconds);

            // start the animation
            sb.Begin(element);

            // make element visible
            element.Visibility = Visibility.Visible;

            // Wait for it to finish:
            await Task.Delay((int)(seconds * 100));

        }

        /// <summary>
        /// Slides and fade out to the right
        /// </summary>
        /// <param name="element"> the element to animate </param>
        /// <param name="seconds"> the time the animation will take </param>
        /// <param name="keepMargin">Wheter to keep the element at the same width during animation</param>
        /// <returns></returns>
        public static async Task SlideAndFadeOutToRightAsync(this FrameworkElement element, float seconds = 0.3f, bool keepMargin = true)
        {
            // create the storyboard
            var sb = new Storyboard();

            // add slide from right animation: 
            sb.AddSlideToRight(seconds, element.ActualWidth, keepMargin: keepMargin);

            // add fade in animation: 
            sb.AddFadeOut(seconds);

            // start the animation
            sb.Begin(element);

            // make element visible
            element.Visibility = Visibility.Visible;

            // Wait for it to finish:
            await Task.Delay((int)(seconds * 100));

        }

    }
}


