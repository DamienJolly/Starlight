using Starlight.API.Communication.Messages;
using Starlight.API.Communication.Messages.Protocols;

namespace Starlight.Game.Messenger.Packets.Outgoing
{
    public class RoomInviteComposer : MessageComposer
    {
        private readonly uint SenderId;
        private readonly string Message;

        public RoomInviteComposer(uint senderId, string message) : base(Headers.RoomInviteComposer)
        {
            SenderId = senderId;
            Message = message;
        }

        public override void Compose(IServerMessage message)
        {
            message.WriteInt(SenderId);
            message.WriteString(Message);
        }
    }
}

