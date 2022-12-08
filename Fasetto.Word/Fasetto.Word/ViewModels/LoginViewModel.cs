using System.Security;
using System.Threading.Tasks;
using System.Windows.Input;
using Fasetto.Word.Core;
using Fasetto.Word.Core.IoC;

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

        /// <summary>
        /// The command to login into the application
        /// </summary>
        public ICommand LoginCommand { get; set; }

        /// <summary>
        /// The command to RegisterAsync for a new account
        /// </summary>
        public ICommand RegisterAsyncCommand { get; set; }

        #endregion


        #region Constructor
        /// <summary>
        /// Default Constructor
        /// </summary>
        public LoginViewModel()
        {

            LoginCommand = new RelayParameterizedCommand(async (parameter) => await AsyncLogin(parameter));

            RegisterAsyncCommand = new RelayCommand(async () => await RegisterAsync());
        }

        /// <summary>
        /// Attempts to log the user in:
        /// </summary>
        /// <param name="parameter"> the <see cref="SecureString"/> passed in from the view for the users password </param>
        /// <returns></returns>
        /// <exception cref="NotImplementedException"></exception>
        public async Task AsyncLogin(object parameter)
        {
            await RunCommand(() => LoginIsRunning, async () =>
            {
                await Task.Delay(250);

                var email = Email;

                // IMPORTANT: Never store unsecure password in a variable that can be searched for in memory
                var pswd = (parameter as IHavePassword).SecurePassword.Unsecure();

            });
        }


        /// <summary>
        /// Takes user to the RegisterAsync page:
        /// </summary>
        /// <returns></returns>
        /// <exception cref="NotImplementedException"></exception>
        private async Task RegisterAsync()
        {

            IoC.Get<ApplicationViewModel>().SideMenuVisible ^= true;

            IoC.Get<ApplicationViewModel>().CurrentPage = ApplicationPage.Register;
            
            await Task.Delay(100);

            /// ((WindowViewModel)((MainWindow)Application.Current.MainWindow).DataContext).CurrentPage = ApplicationPage.Register;
        }


        #endregion
    }
}
