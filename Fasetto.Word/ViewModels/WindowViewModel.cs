
using System.Windows;
using System.Windows.Input;

namespace Fasetto.Word
{
    public class WindowViewModel:BaseViewModel
    {
        #region Private Members
        private Window mWindow;
        /// <summary>
        /// The margin around the window to allow for a drop shadow
        /// </summary>
        private int mOuterMarginSize = 10;

        /// <summary>
        /// The radius of the edges of the window
        /// </summary>
        private int mWindowRadius = 10;
       
        #endregion
        #region Command
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
        /// The command to show the system menu of the window
        /// </summary>
        public ICommand MenuCommand { get; set; }
        #endregion
        #region Public Properties
        /// <summary>
        /// The size of the resize border around the window, taking into account the outer margin
        /// </summary>
        public int ResizeBorder { get; set; } = 6;
        public Thickness ResizeBorderThickness { get { return new Thickness(ResizeBorder+OuterMarginSize); } }

        public int OuterMarginSize
        {
            get
            {
                return mWindow.WindowState==WindowState.Maximized?0:mOuterMarginSize;
            }
            set
            {
                mOuterMarginSize = value;
            }
        }
        public int WindowRadius
        {
            get
            {
                return mWindow.WindowState == WindowState.Maximized ? 0 : mWindowRadius;
            }
            set
            {
                mWindowRadius = value;
            }
        }
        public CornerRadius WindowCornerRadius { get { return new CornerRadius(mWindowRadius); } }
        public Thickness OuterMarginSizeThickness { get { return new Thickness(OuterMarginSize); } }
        /// <summary>
        /// The height of the title bar / caption of the window
        /// </summary>
        public int TitleHeight { get; set; } = 42;
        public  GridLength TitleHeightGridLength { get { return new GridLength(TitleHeight); } }
        /// <summary>
        /// The smallest width the window can go to
        /// </summary>
        public double WindowMinimumWidth { get; set; } = 400;

        /// <summary>
        /// The smallest height the window can go to
        /// </summary>
        public double WindowMinimumHeight { get; set; } = 400;
        /// <summary>
        /// The padding of the inner content of the main window
        /// </summary>
        public Thickness InnerContentPadding { get; set; } = new Thickness(0);
        public ApplicationPage CurrentPage { get; set; } = ApplicationPage.Login;

        #endregion

        #region Constructeur
        /// <summary>
        /// Contructeur
        /// </summary>
        public WindowViewModel(Window window)
        {
            mWindow = window;
            mWindow.StateChanged += (sender, e) =>
            {
                OnPropertyChanged(nameof(ResizeBorderThickness));
                OnPropertyChanged(nameof(OuterMarginSize));
                OnPropertyChanged(nameof(OuterMarginSizeThickness));
                OnPropertyChanged(nameof(WindowRadius));
                OnPropertyChanged(nameof(WindowCornerRadius));
            };
            // Create commands
            MinimizeCommand = new RelayCommand(() => mWindow.WindowState = WindowState.Minimized);
            MaximizeCommand = new RelayCommand(() => mWindow.WindowState ^= WindowState.Maximized);
            CloseCommand = new RelayCommand(() => mWindow.Close());
            MenuCommand = new RelayCommand(() => SystemCommands.ShowSystemMenu(mWindow, GetMousePosition()));
        }


        #endregion
        
        #region Private Helpers

        /// <summary>
        /// Gets the current mouse position on the screen
        /// </summary>
        /// <returns></returns>
        private Point GetMousePosition()
        {
            // Position of the mouse relative to the window
            var position = Mouse.GetPosition(mWindow);

            // Add the window position so its a "ToScreen"
            return new Point(position.X + mWindow.Left, position.Y + mWindow.Top);
        }
        #endregion
    }
}
