using System;
using System.Windows;
using System.Windows.Media.Animation;

namespace Fasetto.Word
{
    /// <summary>
    /// Base class to run any animation method when a boolean is set to true
    /// and a reverse animation when the boolean is set to false.
    /// </summary>
    /// <typeparam name="Parent"></typeparam>
    public abstract class AnimateBaseProperty<Parent> : BaseAttachedProperty<Parent, bool>
        where Parent : BaseAttachedProperty<Parent, bool>, new()
    {

        #region Public Properties

        /// <summary>
        /// A flag indicating if this is the first time this property 
        /// </summary>
        public bool FirstLoad { get; set; } = true;

        #endregion


        /// <summary>
        /// 
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="value"></param>
        public override void OnValueUpdated(DependencyObject sender, object value)
        {

            // Get the framework element
            if(!(sender is FrameworkElement element))
            {
                return;
            }

            // Don't fire if the value does not change
            if(sender.GetValue(ValueProperty) == value && !FirstLoad)
            {
                return;
            }

            if(FirstLoad)
            {
                // Create a single self-unhookable event
                // for the elements loaded event
                RoutedEventHandler onLoaded = null;
                onLoaded = (ss, ee) =>
                {
                    // Unhook ourselves
                    element.Loaded -= onLoaded;

                    // Do desired animation:
                    DoAnimation(element, (bool)value);

                    // No longer in first load
                    FirstLoad = false;
                };


                // Hook into the loaded event of the element  
                element.Loaded += onLoaded;
            }
            else
            {
                // Do desired animation
                DoAnimation(element, (bool)value);
            }

        }

        /// <summary>
        /// The animation method that is fired when the value changes
        /// </summary>
        /// <param name="element"></param>
        /// <param name="value"></param>
        protected virtual void DoAnimation(FrameworkElement element, bool value)
        {

        }
    }


    /// <summary>
    /// Animates a framework element sliding it in from the left on show
    /// and sliding out to the left to hide
    /// </summary>
    public class AnimateSlideInFromLeftProperty : AnimateBaseProperty<AnimateSlideInFromLeftProperty>
    {

        protected override async void DoAnimation(FrameworkElement element, bool value)
        {

            if( value )
            {
                // animate in 
                await element.SlideAndFadeInFromLeftAsync(FirstLoad ? 0 : 0.3f, keepMargin: false);
            }
            else
            {
                await element.SlideAndFadeOutToLeftAsync(FirstLoad ? 0 : 0.3f, keepMargin: false);
            }

        }
    }
}
