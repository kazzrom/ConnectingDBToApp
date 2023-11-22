using CommunityToolkit.Mvvm.Messaging.Messages;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ConnectingDBToApp.Messages
{
    public class GetUsernameMessage : ValueChangedMessage<string>
    {
        public GetUsernameMessage(string value) : base(value)
        {
        }
    }
}
