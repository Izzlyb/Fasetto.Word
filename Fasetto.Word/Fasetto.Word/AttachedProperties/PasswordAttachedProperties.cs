
using System.CodeDom;
using System.Windows;
using System.Windows.Controls;

namespace Fasetto.Word
{

    public class MonitorPasswordProperty : BaseAttachedProperty<MonitorPasswordProperty, bool>
    {

        public override void OnValueChanged(DependencyObject sender, DependencyPropertyChangedEventArgs e)
        {
            // Get the caller UI element where the value changed:
            var passwordBox = sender as PasswordBox;

            // Make sure that the UI element is a PasswordBox:
            if (passwordBox == null)
            {
                return;
            }

            // Remove all previous registered PaswordChanged functions to start with a clean slate
            passwordBox.PasswordChanged -= PasswordBox_PasswordChanged;

            // if the caller is a passwordBox, start listening out for PasswordBox changes:
            if ((bool)e.NewValue)
            {
                // Set the default value:
                HasTextProperty.SetValue(passwordBox);

                // Start listening out for changed in the PasswordBox UI element
                passwordBox.PasswordChanged += PasswordBox_PasswordChanged;
            }
        }


        /// <summary>
        /// call back function fired when the password box password value changes
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void PasswordBox_PasswordChanged(object sender, RoutedEventArgs e)
        {
            // Set the attached property HasText value 
            HasTextProperty.SetValue((PasswordBox)sender);
        }
    }

    /// <summary>
    /// The HasText attached property for the <see cref="PasswordBox"/> UI element:
    /// </summary>
    public class HasTextProperty : BaseAttachedProperty<HasTextProperty, bool> 
    {
        /// <summary>
        /// Set the HasText property based on if the caller <see cref="PasswordBox"/> UI element has any text:
        /// </summary>
        /// <param name="sender"></param>
        public static void SetValue(DependencyObject sender )
        {
            HasTextProperty.SetValue(sender, ((PasswordBox) sender).SecurePassword.Length > 0);
        }
    }





}
