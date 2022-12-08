using System.Windows;
using System;
using System.Windows.Media.Animation;

namespace Fasetto.Word
{

    /// <summary>
    /// Animation helpers for <see cref="Storyboard"/>
    /// </summary>
    public static class StoryboardHelpers
    {

        /// <summary>
        /// Add slide from right animation to the storyboard
        /// </summary>
        /// <param name="storyboard"> The storyboard to add the animation </param>
        /// <param name="seconds"> the time the animation will take </param>
        /// <param name="offset"> the distance to the right to start the animation from </param>
        /// <param name="decelerationRatio"> rate of deceleration </param>
        /// <param name="keepMargin">Wheter to keep the element at the same width during animation</param>
        public static void AddSlideFromRight(this Storyboard storyboard, float seconds, double offset, float decelerationRatio = 0.9f, bool keepMargin = true)
        {
            // Create the margin animate from right 
            var animation = new ThicknessAnimation
            {
                Duration = new Duration(TimeSpan.FromSeconds(seconds)),
                From = new Thickness(keepMargin ? offset : 0, 0, -offset, 0),
                To = new Thickness(0),
                DecelerationRatio = decelerationRatio
            };

            // set the target property name
            Storyboard.SetTargetProperty(animation, new PropertyPath("Margin"));

            // add this to the storyboard:
            storyboard.Children.Add(animation);

        }

        /// <summary>
        /// Add slide from left  animation to the storyboard
        /// </summary>
        /// <param name="storyboard"> The storyboard to add the animation </param>
        /// <param name="seconds"> the time the animation will take </param>
        /// <param name="offset"> the distance to the left to start the animation from </param>
        /// <param name="decelerationRatio"> rate of deceleration </param>
        /// <param name="keepMargin">Wheter to keep the element at the same width during animation</param>
        public static void AddSlideFromLeft(this Storyboard storyboard, float seconds, double offset, float decelerationRatio = 0.9f, bool keepMargin = true)
        {
            // Create the margin animate from right 
            var animation = new ThicknessAnimation
            {
                Duration = new Duration(TimeSpan.FromSeconds(seconds)),
                From = new Thickness(-offset, 0, keepMargin ? offset : 0, 0),
                To = new Thickness(0),
                DecelerationRatio = decelerationRatio
            };

            // set the target property name
            Storyboard.SetTargetProperty(animation, new PropertyPath("Margin"));

            // add this to the storyboard:
            storyboard.Children.Add(animation);

        }



        /// <summary>
        /// Add slide to the left animation to the storyboard
        /// </summary>
        /// <param name="storyboard"> The storyboard to add the animation </param>
        /// <param name="seconds"> the time the animation will take </param>
        /// <param name="offset"> the distance to the right to start the animation from </param>
        /// <param name="decelerationRatio"> rate of deceleration </param>
        /// <param name="keepMargin">Wheter to keep the element at the same width during animation</param>
        public static void AddSlideToLeft(this Storyboard storyboard, float seconds, double offset, float decelerationRatio = 0.9f, bool keepMargin = true)
        {
            // Create the margin animate from right 
            var animation = new ThicknessAnimation
            {
                Duration = new Duration(TimeSpan.FromSeconds(seconds)),
                From = new Thickness(0),
                To = new Thickness(-offset, 0, keepMargin ? offset : 0, 0),
                DecelerationRatio = decelerationRatio  
            };

            // set the target property name
            Storyboard.SetTargetProperty(animation, new PropertyPath("Margin"));

            // add this to the storyboard:
            storyboard.Children.Add(animation);

        }



        /// <summary>
        /// Add slide to the right animation to the storyboard
        /// </summary>
        /// <param name="storyboard"> The storyboard to add the animation </param>
        /// <param name="seconds"> the time the animation will take </param>
        /// <param name="offset"> the distance to the right to start the animation from </param>
        /// <param name="decelerationRatio"> rate of deceleration </param>
        /// <param name="keepMargin">Wheter to keep the element at the same width during animation</param>
        public static void AddSlideToRight(this Storyboard storyboard, float seconds, double offset, float decelerationRatio = 0.9f, bool keepMargin = true)
        {
            // Create the margin animate from right 
            var animation = new ThicknessAnimation
            {
                Duration = new Duration(TimeSpan.FromSeconds(seconds)),
                From = new Thickness(0),
                To = new Thickness(keepMargin ? offset : 0, 0, -offset, 0),
                DecelerationRatio = decelerationRatio
            };

            // set the target property name
            Storyboard.SetTargetProperty(animation, new PropertyPath("Margin"));

            // add this to the storyboard:
            storyboard.Children.Add(animation);

        }




        /// <summary>
        /// Add fade in animation to the storyboard
        /// </summary>
        /// <param name="storyboard"> The storyboard to add the animation </param>
        /// <param name="seconds"> the time the animation will take </param>
        public static void AddFadeIn(this Storyboard storyboard, float seconds)
        {
            // Create the margin animate from right 
            var animation = new DoubleAnimation
            {
                Duration = new Duration(TimeSpan.FromSeconds(seconds)),
                From = 0,
                To = 1
            };

            // set the target property name
            Storyboard.SetTargetProperty(animation, new PropertyPath("Opacity"));

            // add this to the storyboard:
            storyboard.Children.Add(animation);

        }

        /// <summary>
        /// Add fade out animation to the storyboard
        /// </summary>
        /// <param name="storyboard"> The storyboard to add the animation </param>
        /// <param name="seconds"> the time the animation will take </param>
        public static void AddFadeOut(this Storyboard storyboard, float seconds)
        {
            // Create the margin animate from right 
            var animation = new DoubleAnimation
            {
                Duration = new Duration(TimeSpan.FromSeconds(seconds)),
                From = 1,
                To = 0
            };

            // set the target property name
            Storyboard.SetTargetProperty(animation, new PropertyPath("Opacity"));

            // add this to the storyboard:
            storyboard.Children.Add(animation);

        }

    }
}
