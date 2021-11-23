using Starlight.API.Communication.Messages;
using Starlight.API.Communication.Messages.Protocols;
using Starlight.API.Game.Messenger.Models;

namespace Starlight.Game.Messenger.Packets.Outgoing
{
    public class NewConsoleMessageComposer : MessageComposer
    {
        private readonly IMessengerMessage PrivateMessage;

        public NewConsoleMessageComposer(IMessengerMessage privateMessage) : base(Headers.NewConsoleMessageComposer)
        {
            PrivateMessage = privateMessage;
        }

        public override void Compose(IServerMessage message)
        {
            PrivateMessage.Compose(message);
        }
    }
}

