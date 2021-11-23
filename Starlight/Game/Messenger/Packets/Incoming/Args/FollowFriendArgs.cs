using Starlight.API.Communication.Messages;
using Starlight.API.Communication.Messages.Protocols;

namespace Starlight.Game.Messenger.Packets.Incoming.Args
{
    public class FollowFriendArgs : IMessageArgs
    {
        public uint TargetId { get; private set; }

        public void Parse(IClientMessage message)
        {
            TargetId = message.ReadUint();
        }
    }
}
