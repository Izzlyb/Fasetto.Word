
namespace Fasetto.Word
{

    /// <summary>
    /// the design-time data for a <see cref="ChatListItemViewModel"/> to 
    /// work with during the development process
    /// </summary>
    public class ChatListItemDesignModel : ChatListItemViewModel
    {

        #region Constructor

        /// <summary>
        /// The default constructor with default values:
        /// </summary>
        public ChatListItemDesignModel()
        {
            Initials = "DB";

            Name = "Debra";

            // Message = "This chat app is awesome!!! I bet it will be fast too...";
            Message = "The easiest way to use an Island inside an app is to use the NuGet packages that we provide";

            ProfilePictureRGB = "7fff17";
            
            NewContentAvailable = true;
        }

        #endregion

        #region Singleton

        /// <summary>
        /// the single instance of the design model using an inline getter :
        /// </summary>
        public static ChatListItemDesignModel Instance => new ChatListItemDesignModel();

        #endregion

    }
}
