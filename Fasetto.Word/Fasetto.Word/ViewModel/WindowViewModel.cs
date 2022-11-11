using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows;
using System.Windows.Input;

namespace Fasetto.Word.ViewModel
{
    public class WindowViewModel : BaseViewModel
    {

        #region Private Members

        /// <summary>
        /// The smallest width for the window to size
        /// </summary>
        public double WindowMinimumWidth { get; set; } = 400;

        /// <summary>
        /// The smallest height for the window to size
        /// </summary>
        public double WindowMinimumHeight { get; set; } = 400;

        /// <summary>
        /// The window this view model controls
        /// </summary>
        /// <param name="window"></param>
        private Window _mWindow;

        /// <summary>
        /// The margin around the window to allow for a drop shadow:
        /// </summary>
        private int mOuterMarginSize = 10;

        /// <summary>
        /// The radius of the edges of the window:
        /// </summary>
        private int mWindowsRadius = 10;

        #endregion

        #region Commands

        /// <summary>
        /// The command to minimize the window
        /// </summary>
        public ICommand MinimizeCommand { get; set; }

        /// <summary>
        /// The command to maximize the window
        /// </summary>
        public ICommand MaximizeCommand { get; set; }

        /// <summary>
        /// The command to close the window
        /// </summary>
        public ICommand CloseCommand { get; set; }

        /// <summary>
        /// The windows system menu at the upper left corner of the window.
        /// </summary>
        public ICommand SystemMenuCommand { get; set; }

        #endregion


        #region Public Properties

        /// <summary>
        /// The size of the resize border around the window
        /// </summary>
        public int ResizeBorder { get; set; } = 6;

        /// <summary>
        /// The size of the resize border around the window, taking into account the outer margin, for the drop shadow:
        /// </summary>
        public Thickness ResizeBorderThickness { get { return new Thickness(ResizeBorder + OuterMarginSize); } }

        /// <summary>
        /// The padding for the inner content of the main window 
        /// </summary>
        public Thickness InnerContentPadding { get { return new Thickness(ResizeBorder); } }

        /// <summary>
        /// The margin around the window to allow for a drop shadow:
        /// </summary>
        public int  OuterMarginSize
        {
            get
            {
                return _mWindow.WindowState == WindowState.Maximized ? 0 : mOuterMarginSize;
            }
            set
            {
                mOuterMarginSize = value;
            }
        }

        /// <summary>
        /// The margin around the window to allow for a drop window:
        /// </summary>
        public Thickness OuterMarginSizeThickness { get { return new Thickness(OuterMarginSize); } }

        /// <summary>
        /// The radius of the edges of the window:
        /// </summary>
        public int WindowsRadius
        {
            get
            {
                return _mWindow.WindowState == WindowState.Maximized ? 0 : mWindowsRadius;
            }
            set
            {
                mWindowsRadius = value;
            }
        }

        public CornerRadius WindowsCornerRadius { get { return new CornerRadius(WindowsRadius); } }

        /// <summary>
        /// The height of the title bar/caption of the window
        /// </summary>
        public int TitleHeight { get; set; } = 42;

        /// <summary>
        /// The height of the title bar/caption of the window
        /// </summary>
        public GridLength TitleHeightGridLength { get { return new GridLength(TitleHeight + ResizeBorder); } }

        #endregion

        #region Constructor
        /// <summary>
        /// Default Constructor
        /// </summary>
        /// <param name="window"></param>
        public WindowViewModel(Window window)
        {
            _mWindow = window;

            // Listen out for the window resizing:
            _mWindow.StateChanged += (sender, e) =>
            {
                // Fire off events for all properties that are affected by a resize:
                OnPropertyChanged(nameof(ResizeBorderThickness));
                OnPropertyChanged(nameof(OuterMarginSize));
                OnPropertyChanged(nameof(OuterMarginSizeThickness));
                OnPropertyChanged(nameof(WindowsRadius));
                OnPropertyChanged(nameof(WindowsCornerRadius));
            };

            // Create the icon command 
            MinimizeCommand = new RelayCommand(() => _mWindow.WindowState = WindowState.Minimized);
            MaximizeCommand = new RelayCommand(() => _mWindow.WindowState ^= WindowState.Maximized);
            CloseCommand = new RelayCommand(() => _mWindow.Close());
            SystemMenuCommand = new RelayCommand(() => SystemCommands.ShowSystemMenu(_mWindow, GetMousePosition()));

            // Fix window resize issue in WPF maximize window.
            var resizer = new WindowResizer(_mWindow);
        }

        #endregion

        #region Private Helpers  

        private Point GetMousePosition()
        {
            // Position of the mouse relative to the window:
            var position = Mouse.GetPosition(_mWindow);

            // Add the window position so its a "ToScreen"
            return new Point(position.X + _mWindow.Left, position.Y + _mWindow.Top);
        }

        #endregion
    }
}
