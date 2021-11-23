using Starlight.API.Communication.Messages;
using Starlight.API.Communication.Messages.Protocols;
using Starlight.API.Game.Messenger.Models;

namespace Starlight.Game.Messenger.Packets.Outgoing
{
    public class NewFriendRequestComposer : MessageComposer
    {
        private readonly IMessengerRequest Request;

        public NewFriendRequestComposer(IMessengerRequest request) : base(Headers.NewFriendRequestComposer)
        {
            Request = request;
        }

        public override void Compose(IServerMessage message)
        {
            Request.Compose(message);
        }
    }
}

