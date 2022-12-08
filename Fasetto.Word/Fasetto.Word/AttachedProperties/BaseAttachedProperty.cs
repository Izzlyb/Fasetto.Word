
using System;
using System.Windows;

namespace Fasetto.Word
{
    /// <summary>
    /// A base attached property to replace the vanilla WPF attached property
    /// </summary>
    /// <typeparam name="Parent"> the parent class to be the attached property </typeparam>
    /// <typeparam name="Property"> the type of this attached property </typeparam>
    public abstract class BaseAttachedProperty<Parent, Property> 
        where Parent : BaseAttachedProperty<Parent, Property>, new()
    {
        #region Public Events

        /// <summary>
        /// Fired when the value changes:
        /// This method Action() is not static, so there can be a different one for every instance of the class.
        /// </summary>
        /// <param name="sender"> the sender </param>
        /// <param name="e"> the arguments </param>
        public event Action<DependencyObject, DependencyPropertyChangedEventArgs> ValueChange = (sender, e ) => { };


        /// <summary>
        /// Fired when the value changes, even when the value is the same:
        /// This method Action() is not static, so there can be a different one for every instance of the class.
        /// </summary>
        /// <param name="sender"> the sender </param>
        /// <param name="e"> the arguments </param>
        public event Action<DependencyObject, object> ValueUpdated = (sender, value) => { };


        #endregion


        #region Public Properties

        /// <summary>
        /// Singleton instance of our parent class:
        /// by declaring it static it is a singleton. there will be only
        /// one instance of this variable.
        /// </summary>
        public static Parent Instance { get; private set; } = new Parent();

        #endregion


        #region Attached Property Definitions

        /// <summary>
        /// the attached property for this class, defined as a dependencyproperty "Value"
        /// </summary>
        public static readonly DependencyProperty ValueProperty = 
            DependencyProperty.RegisterAttached("Value", 
                                    typeof(Property), 
                                    typeof(BaseAttachedProperty<Parent, Property>), 
                                    new UIPropertyMetadata(
                                                default(Property),
                                                new PropertyChangedCallback(OnValuePropertyChanged),
                                                new CoerceValueCallback(OnValuePropertyUpdated)
                                        ));


        /// <summary>
        /// the callback event when the <see cref="ValueProperty"/> is changed.
        /// </summary>
        /// <param name="d"> The UI element that had it's property changed </param>
        /// <param name="e"> the arguments for the event </param>
        /// <exception cref="NotImplementedException"></exception>
        private static void OnValuePropertyChanged(DependencyObject d, DependencyPropertyChangedEventArgs e)
        {

            // Call the parent function 
            Instance.OnValueChanged(d, e);

            // Call event listeners:
            Instance.ValueChange(d, e);
        }



        /// <summary>
        /// the callback event when the <see cref="ValueProperty"/> is changed. even if it is the same value
        /// </summary>
        /// <param name="d"> The UI element that had it's property changed </param>
        /// <param name="e"> the arguments for the event </param>
        /// <exception cref="NotImplementedException"></exception>
        private static object OnValuePropertyUpdated(DependencyObject d, object value)
        {

            // Call the parent function 
            Instance.OnValueUpdated(d, value);

            // Call event listeners:
            Instance.ValueUpdated(d, value);

            return value;
        }



        /// <summary>
        /// Get the attached property value:
        /// </summary>
        /// <param name="d"> the element to get the property from </param>
        /// <returns></returns>
        public static Property GetValue(DependencyObject d) => (Property)d.GetValue(ValueProperty);


        /// <summary>
        /// Set the value of the attached property:
        /// the method to set the value of the attached property
        /// </summary>
        /// <param name="d"> the element to get the property from  </param>
        /// <param name="value"> the value to set the property to </param>
        public static void SetValue(DependencyObject d, object value) => d.SetValue(ValueProperty, value);

        #endregion


        #region Event Methods

        /// <summary>
        /// the method that is called when any attached property of this type is changed
        /// </summary>
        /// <param name="sender"> the UI element that this property was changed for </param>
        /// <param name="e"> the arguments for this event </param>
        public virtual void OnValueChanged(DependencyObject sender, DependencyPropertyChangedEventArgs e) { }


        /// <summary>
        /// the method that is called when any attached property of this type is changed, or even if the value is not changed
        /// </summary>
        /// <param name="sender"> the UI element that this property was changed for </param>
        /// <param name="e"> the arguments for this event </param>
        public virtual void OnValueUpdated(DependencyObject sender, object value) { }



        #endregion
    }
}
