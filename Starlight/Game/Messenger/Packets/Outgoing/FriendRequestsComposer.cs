using Starlight.API.Communication.Messages;
using Starlight.API.Communication.Messages.Protocols;
using Starlight.API.Game.Messenger.Models;
using System.Collections.Generic;

namespace Starlight.Game.Messenger.Packets.Outgoing
{
    public class FriendRequestsComposer : MessageComposer
    {
        private readonly IList<IMessengerRequest> Requests;

        public FriendRequestsComposer(IList<IMessengerRequest> requests) : base(Headers.FriendRequestsComposer)
        {
            Requests = requests;
        }

        public override void Compose(IServerMessage message)
        {
            message.WriteInt(Requests.Count); // Dunno ?
            message.WriteInt(Requests.Count);
            foreach (IMessengerRequest request in Requests)
            {
                request.Compose(message);
            }
        }
    }
}

