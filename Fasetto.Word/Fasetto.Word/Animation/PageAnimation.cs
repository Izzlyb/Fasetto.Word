
namespace Fasetto.Word
{
    /// <summary>
    /// Styles of page animation for appearing and desappearing 
    /// </summary>
    public enum PageAnimation
    {
        None = 0,
        /// <summary>
        /// This is the page that is created and slides from the 
        /// right side of the window as it is being created:
        /// </summary>
        SlideAndFadeInFromRight = 1,

        /// <summary>
        /// This is the type of page that is being closed and
        /// Fades to the left as it desappears:
        /// </summary>
        SlideAndFadeOutToLeft = 2

    }
}
