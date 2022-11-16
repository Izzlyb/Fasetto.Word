using System;
using System.Security;
using System.Threading.Tasks;
using System.Windows.Input;

namespace Fasetto.Word
{
    /// <summary>
    /// ViewModel for login screen:
    /// </summary>
    public class LoginViewModel : BaseViewModel
    {

        #region Public Properties

        /// <summary>
        /// The email of the user thats logged in:
        /// </summary>
        public string Email { get; set; }

        /// <summary>
        /// Password of user.
        /// </summary>
        public SecureString Password { get; set; }


        /// <summary>
        /// a flag to indicate that the login process is running
        /// </summary>
        public bool LoginIsRunning { get; set; }
        #endregion


        #region Commands

        public ICommand LoginCommand { get; set; }

        #endregion


        #region Constructor
        /// <summary>
        /// Default Constructor
        /// </summary>
        public LoginViewModel()
        {

            LoginCommand = new RelayParameterizedCommand(async (parameter) => await Login(parameter));
        }


        /// <summary>
        /// Attempts to log the user in:
        /// </summary>
        /// <param name="parameter"> the <see cref="SecureString"/> passed in from the view for the users password </param>
        /// <returns></returns>
        /// <exception cref="NotImplementedException"></exception>
        public async Task Login(object parameter)
        {
            await RunCommand(() => this.LoginIsRunning, async () =>
            {
                await Task.Delay(5000);

                var email = this.Email;

                var pswd = (parameter as IHavePassword).SecurePassword.Unsecure();

            });
        }

        #endregion
    }
}
