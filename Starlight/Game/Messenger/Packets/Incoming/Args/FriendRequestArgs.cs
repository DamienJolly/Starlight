using Starlight.API.Communication.Messages;
using Starlight.API.Communication.Messages.Protocols;

namespace Starlight.Game.Messenger.Packets.Incoming.Args
{
    public class FriendRequestArgs : IMessageArgs
    {
        public string Username { get; private set; }

        public void Parse(IClientMessage message)
        {
            Username = message.ReadString();
        }
    }
}
