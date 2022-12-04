using System.Collections.Generic;

namespace Fasetto.Word
{
    public class ChatListDesignModel : ChatListViewModel
    {

        public static ChatListDesignModel Instance => new ChatListDesignModel();


        public ChatListDesignModel()
        {
            Items = new List<ChatListItemViewModel>
            {
                new ChatListItemViewModel
                {
                    Name = "Jacob",
                    Initials = "JB",
                    Message = "The membership begins either after a customer completes their second order",
                    ProfilePictureRGB = "17ff26",
                    NewContentAvailable = true
                },
                new ChatListItemViewModel
                {
                    Name = "Carter",
                    Initials = "CT",
                    Message = "To delete a watchlist, start by going to the Settings menu by clicking the gear icon",
                    ProfilePictureRGB = "e8b527",
                    NewContentAvailable = true
                },
                new ChatListItemViewModel
                {
                    Name = "Emma",
                    Initials = "EM",
                    Message = "We welcome you to join one or all of the sessions.",
                    ProfilePictureRGB = "e08019",
                    NewContentAvailable = false
                },
                new ChatListItemViewModel
                {
                    Name = "Thomas",
                    Initials = "TM",
                    Message = "Build a foundation of technical analysis with support, resistance and trends",
                    ProfilePictureRGB = "ff3e17",
                    NewContentAvailable = false
                }
            };
        }
    }
}



//,
//                new ChatListItemViewModel
//                {
//                    Name = "Shirley",
//                    Initials = "SL",
//                    Message = "Font Awesome Kits are the easiest way to get Font Awesome icons into your projects",
//                    ProfilePictureRGB = "e017ff",
//                    NewContentAvailable = true
//                },
//                new ChatListItemViewModel
//                {
//                    Name = "Nicole",
//                    Initials = "NC",
//                    Message = "Most electronic devices should work fine with an UPS that has a simulated sine wave outpu",
//                    ProfilePictureRGB = "17ff70",
//                    NewContentAvailable = true
//                }


