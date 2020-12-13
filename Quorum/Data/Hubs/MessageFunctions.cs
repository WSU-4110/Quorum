using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace Quorum.Data.Hubs
{
    public static class MessageFunctions
    {
        public const string SEND = "SendMessage";

        public const string BROADCAST = "Broadcast";

        public const string RECEIVE = "ReceiveMessage";
        
        public const string USEREVENT = "UserEvent";

        public const string REGISTER = "Register";

        public const string DISCONNECT = "OnDisconnectedAsync";
    }
}
