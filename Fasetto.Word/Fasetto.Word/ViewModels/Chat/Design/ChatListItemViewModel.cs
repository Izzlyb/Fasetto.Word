using Fasetto.Word.Core;

namespace Fasetto.Word
{
    /// <summary>
    /// a view model for each chat list item in 
    /// overview chat list
    /// </summary>
    public class ChatListItemViewModel : BaseViewModel
    {

        #region Constructor

        /// <summary>
        /// the display name of the chat list item:
        /// </summary>
        public string Name { get; set; }

        /// <summary>
        /// The message header in the chat list item
        /// </summary>
        public string Message { get; set; }

        public string Initials { get; set; }

        /// <summary>
        /// the RGB values (in hex) for the background color of the profile picture,
        /// for example ff00ff for red and  blue mixed color.
        /// </summary>
        public string ProfilePictureRGB { get; set; }

        /// <summary>
        /// True if there are unread messages in the chat:
        /// </summary>
        public bool NewContentAvailable { get; set; }

        #endregion
    }
}


