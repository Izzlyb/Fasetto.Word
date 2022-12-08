using System.Collections.Generic;
using System.Xml.Linq;

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
                    Initials = "DC",
                    Name = "Douglas",
                    Message = "The easiest way to use an Island inside an app is to use the NuGet...",
                    ProfilePictureRGB = "a3cc15",
                    NewContentAvailable = true
                },
                new ChatListItemViewModel
                {
                    Initials = "JJ",
                    Name = "Johanna",
                    Message = "The templates featured below also work with OpenOffice and Google Spreadsheet...",
                    ProfilePictureRGB = "d3bf23",
                    NewContentAvailable = true
                },
                new ChatListItemViewModel
                {Initials = "KI", Name = "Keith", Message = "Top companies choose Udemy Business to build in-demand...", ProfilePictureRGB = "7c2f17", NewContentAvailable = true},
                new ChatListItemViewModel
                {
                    Initials = "SL",
                    Name = "Shirley",
                    Message = "Font Awesome Kits are the easiest way to get Font Awesome icons into your projects",
                    ProfilePictureRGB = "5f1c99",
                    NewContentAvailable = true
                },
                new ChatListItemViewModel
                {
                    Initials = "NC",
                    Name = "Nicole",
                    Message = "Most electronic devices should work fine with an UPS that has a simulated sine",
                    ProfilePictureRGB = "372ad2",
                    NewContentAvailable = true
                },
                new ChatListItemViewModel
                {Initials = "TC", Name = "Thomas", Message = "Someone will tell me about their Security+ exam experience", ProfilePictureRGB = "b37f98", NewContentAvailable = true},
                new ChatListItemViewModel
                {Initials = "AA", Name = "Aaron", Message = "We’re improving developer productivity by moving the main devenv.exe process from 32-bit to 64-bit.", ProfilePictureRGB = "c72f17", NewContentAvailable = true},
            };
        }
    }
}

