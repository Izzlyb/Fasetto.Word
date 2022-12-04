using System;
using System.Collections.Generic;
using System.Linq;
using System.Security;
using Fasetto.Word.Core;

namespace Fasetto.Word
{
    /// <summary>
    /// Interaction logic for ChatPage.xaml
    /// </summary>
    public partial class ChatPage : BasePage<LoginViewModel>
    {
        public ChatPage()
        {
            InitializeComponent();
        }

        public SecureString SecurePassword => throw new NotImplementedException();
    }
}
